using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Dominio.Deployment;

internal sealed class DockerComposeRenderer
{
    private readonly string _solutionDirectory;
    private readonly string _outputDirectory;

    public DockerComposeRenderer(string solutionDirectory, string outputDirectory)
    {
        _solutionDirectory = Path.GetFullPath(solutionDirectory);
        _outputDirectory = Path.GetFullPath(outputDirectory);
    }

    public void Render(DeploymentEnvironmentModel model)
    {
        Directory.CreateDirectory(_outputDirectory);
        var nginxDirectory = Path.Combine(_outputDirectory, "nginx", "conf.d");
        Directory.CreateDirectory(nginxDirectory);

        File.WriteAllText(Path.Combine(_outputDirectory, "docker-compose.yml"), RenderCompose(model));
        File.WriteAllText(Path.Combine(_outputDirectory, ".env.example"), RenderEnvironmentExample(model));
        File.WriteAllText(Path.Combine(nginxDirectory, "00-http.conf"), RenderNginx(model, useTls: false));
        File.WriteAllText(Path.Combine(nginxDirectory, "10-https.conf.disabled"), RenderNginx(model, useTls: true));
        WriteShellScript(Path.Combine(_outputDirectory, "bootstrap-environment.sh"), RenderBootstrap(model));

        foreach (var application in model.Applications)
        {
            WriteShellScript(
                Path.Combine(_outputDirectory, $"deploy-{Slug(application)}.sh"),
                RenderApplicationDeploy(model, application));
        }

        WriteShellScript(Path.Combine(_outputDirectory, "deploy-all.sh"), RenderAllDeploy(model));
    }

    private string RenderCompose(DeploymentEnvironmentModel model)
    {
        var sb = new StringBuilder()
            .AppendLine("# generated: Dominio.Deployment.DockerComposeRenderer")
            .AppendLine("# pendencia: criar os catalogos de banco antes da primeira migration em servidor vazio.")
            .AppendLine("# observacao: os valores de segredo serao definidos em etapa posterior; este arquivo usa somente referencias.")
            .AppendLine($"name: {Yaml($"yeshua-{Slug(model.Environment)}")}")
            .AppendLine("services:");

        foreach (var resource in ContainerResources(model))
            AppendResourceService(sb, resource);

        foreach (var item in model.Workloads.OrderBy(item => item.Workload.Identity, StringComparer.OrdinalIgnoreCase))
            AppendWorkloadService(sb, model, item.Workload);

        AppendGatewayService(sb, model);

        sb.AppendLine("networks:")
            .AppendLine("  yeshua-net:")
            .AppendLine("    name: yeshua-net");

        var volumes = NamedVolumes(model).ToList();
        if (volumes.Count > 0)
        {
            sb.AppendLine("volumes:");
            foreach (var volume in volumes)
                sb.AppendLine($"  {volume}:");
        }

        return sb.ToString();
    }

    private void AppendResourceService(StringBuilder sb, DeploymentEnvironmentResource resource)
    {
        sb.AppendLine($"  {resource.Identity}:")
            .AppendLine($"    image: {Yaml(resource.Image!)}")
            .AppendLine("    restart: unless-stopped");

        AppendEnvironment(sb, resource.RuntimeConfiguration, resource.Secrets, 4);

        if (resource.PublishedPorts.Count > 0)
        {
            sb.AppendLine("    ports:");
            foreach (var port in resource.PublishedPorts)
                sb.AppendLine($"      - {Yaml($"{port.HostPort}:{port.ContainerPort}")}");
        }

        if (resource.Persistence.Count > 0)
        {
            sb.AppendLine("    volumes:");
            foreach (var persistence in resource.Persistence)
            {
                sb.AppendLine(
                    $"      - {Yaml($"{PersistenceSource(resource, persistence)}:{persistence.MountPath}")}");
            }
        }

        AppendResourceHealthCheck(sb, resource);
        sb.AppendLine("    networks:")
            .AppendLine("      - yeshua-net");
    }

    private void AppendWorkloadService(
        StringBuilder sb,
        DeploymentEnvironmentModel model,
        DeploymentWorkload workload)
    {
        sb.AppendLine($"  {workload.Identity}:");
        AppendWorkloadSource(sb, workload.Source);
        sb.AppendLine($"    restart: {Yaml(workload.Mode == DeploymentWorkloadMode.Job ? "no" : "unless-stopped")}");

        if (workload.Mode == DeploymentWorkloadMode.Job)
        {
            sb.AppendLine("    profiles:")
                .AppendLine("      - jobs");
        }

        var configuration = new Dictionary<string, string>(workload.Configuration);
        var httpPort = workload.Ports.FirstOrDefault(port => port.Protocol == DeploymentPortProtocol.Http);
        if (httpPort is not null && workload.Source.Kind == DeploymentWorkloadSourceKind.Project)
            configuration.TryAdd("ASPNETCORE_URLS", $"http://0.0.0.0:{httpPort.ContainerPort}");
        AppendEnvironment(sb, configuration, workload.Secrets, 4);

        var dependencies = ResolveServiceDependencies(model, workload.Requires).ToList();
        if (dependencies.Count > 0)
        {
            sb.AppendLine("    depends_on:");
            foreach (var dependency in dependencies)
            {
                sb.AppendLine($"      {dependency.Identity}:")
                    .AppendLine($"        condition: {dependency.Condition}");
            }
        }

        if (workload.Ports.Count > 0)
        {
            sb.AppendLine("    expose:");
            foreach (var port in workload.Ports)
                sb.AppendLine($"      - {Yaml(port.ContainerPort.ToString())}");
        }

        if (workload.Mounts.Count > 0)
        {
            sb.AppendLine("    volumes:");
            foreach (var mount in workload.Mounts)
            {
                var resource = FindResource(model, mount.Resource);
                var persistence = resource.Persistence.FirstOrDefault()
                    ?? throw new InvalidOperationException(
                        $"O recurso '{resource.Identity}' usado por '{workload.Identity}' nao possui persistencia.");
                var suffix = mount.ReadOnly ? ":ro" : string.Empty;
                sb.AppendLine(
                    $"      - {Yaml($"{PersistenceSource(resource, persistence)}:{mount.MountPath}{suffix}")}");
            }
        }

        AppendWorkloadHealthCheck(sb, workload);

        if (workload.Replicas > 1)
        {
            sb.AppendLine("    deploy:")
                .AppendLine($"      replicas: {workload.Replicas}");
        }

        if (!string.IsNullOrWhiteSpace(workload.Compute?.CpuLimit))
            sb.AppendLine($"    cpus: {Yaml(NormalizeCpu(workload.Compute.CpuLimit!))}");
        if (!string.IsNullOrWhiteSpace(workload.Compute?.MemoryLimit))
            sb.AppendLine($"    mem_limit: {Yaml(workload.Compute.MemoryLimit!)}");

        sb.AppendLine("    networks:")
            .AppendLine("      - yeshua-net");
    }

    private void AppendWorkloadSource(StringBuilder sb, DeploymentWorkloadSource source)
    {
        switch (source.Kind)
        {
            case DeploymentWorkloadSourceKind.Project:
                sb.AppendLine("    build:")
                    .AppendLine($"      context: {Yaml(RelativePath(_solutionDirectory))}")
                    .AppendLine($"      dockerfile: {Yaml(source.Dockerfile!)}");
                break;
            case DeploymentWorkloadSourceKind.BuildContext:
                var context = Path.GetFullPath(
                    source.BuildContext!.Replace('/', Path.DirectorySeparatorChar),
                    _solutionDirectory);
                sb.AppendLine("    build:")
                    .AppendLine($"      context: {Yaml(RelativePath(context))}")
                    .AppendLine($"      dockerfile: {Yaml(source.Dockerfile!)}");
                break;
            case DeploymentWorkloadSourceKind.Image:
                sb.AppendLine($"    image: {Yaml(source.Image!)}");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(source.Kind), source.Kind, null);
        }
    }

    private static void AppendEnvironment(
        StringBuilder sb,
        IReadOnlyDictionary<string, string> configuration,
        IEnumerable<DeploymentSecretReference> secrets,
        int indentation)
    {
        var values = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var item in configuration)
            values[item.Key] = item.Value;
        foreach (var secret in secrets)
            values[secret.Target] = $"${{{EnvironmentVariable(secret.Secret)}}}";
        if (values.Count == 0)
            return;

        var spaces = new string(' ', indentation);
        sb.AppendLine($"{spaces}environment:");
        foreach (var item in values)
            sb.AppendLine($"{spaces}  {Yaml(item.Key)}: {Yaml(item.Value)}");
    }

    private static void AppendResourceHealthCheck(StringBuilder sb, DeploymentEnvironmentResource resource)
    {
        string command = resource.Kind switch
        {
            DeploymentResourceKind.DatabaseServer =>
                "bash -c '</dev/tcp/127.0.0.1/1433'",
            DeploymentResourceKind.MessageBroker => "rabbitmq-diagnostics -q ping",
            DeploymentResourceKind.Cache => "redis-cli ping",
            _ => string.Empty
        };
        if (command.Length == 0)
            return;

        AppendHealthCheck(sb, new[] { "CMD-SHELL", command }, 30, 5, 10);
    }

    private static void AppendWorkloadHealthCheck(StringBuilder sb, DeploymentWorkload workload)
    {
        if (workload.HealthCheck is null)
            return;

        var health = workload.HealthCheck;
        IReadOnlyList<string> command = health.Kind switch
        {
            DeploymentHealthCheckKind.Command => health.Command,
            DeploymentHealthCheckKind.Tcp => new[]
            {
                "CMD-SHELL",
                $"bash -c '</dev/tcp/127.0.0.1/{ResolvePort(workload, health.Port)}'"
            },
            DeploymentHealthCheckKind.Http => new[]
            {
                "CMD-SHELL",
                $"curl --fail --silent http://127.0.0.1:{ResolvePort(workload, health.Port)}{health.Path} > /dev/null"
            },
            _ => throw new ArgumentOutOfRangeException()
        };
        AppendHealthCheck(sb, command, health.IntervalSeconds, health.TimeoutSeconds, health.Retries);
    }

    private static void AppendHealthCheck(
        StringBuilder sb,
        IReadOnlyList<string> command,
        int intervalSeconds,
        int timeoutSeconds,
        int retries)
    {
        sb.AppendLine("    healthcheck:")
            .AppendLine($"      test: {JsonSerializer.Serialize(command)}")
            .AppendLine($"      interval: {intervalSeconds}s")
            .AppendLine($"      timeout: {timeoutSeconds}s")
            .AppendLine($"      retries: {retries}");
    }

    private static int ResolvePort(DeploymentWorkload workload, string? name)
    {
        return workload.Ports.Single(port =>
            string.Equals(port.Name, name, StringComparison.OrdinalIgnoreCase)).ContainerPort;
    }

    private static void AppendGatewayService(StringBuilder sb, DeploymentEnvironmentModel model)
    {
        sb.AppendLine("  gateway:")
            .AppendLine("    image: nginx:1.27-alpine")
            .AppendLine("    restart: unless-stopped")
            .AppendLine("    ports:")
            .AppendLine($"      - {Yaml("80:80")}")
            .AppendLine($"      - {Yaml("443:443")}")
            .AppendLine("    volumes:")
            .AppendLine($"      - {Yaml("./nginx/conf.d:/etc/nginx/conf.d:ro")}")
            .AppendLine($"      - {Yaml("/etc/letsencrypt:/etc/letsencrypt:ro")}");

        foreach (var resource in StaticRouteResources(model))
        {
            var persistence = resource.Persistence.First();
            sb.AppendLine(
                $"      - {Yaml($"{PersistenceSource(resource, persistence)}:{persistence.MountPath}:ro")}");
        }

        sb.AppendLine("    networks:")
            .AppendLine("      - yeshua-net");
    }

    private static string RenderEnvironmentExample(DeploymentEnvironmentModel model)
    {
        var secrets = model.Resources.SelectMany(resource => resource.Secrets)
            .Concat(model.Workloads.SelectMany(item => item.Workload.Secrets))
            .Select(secret => EnvironmentVariable(secret.Secret))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(value => value, StringComparer.OrdinalIgnoreCase);

        var sb = new StringBuilder()
            .AppendLine("# Copie para .env e preencha fora do controle de versao.")
            .AppendLine("# Nenhum valor de segredo e gerado pela Engine.");
        foreach (var secret in secrets)
            sb.AppendLine($"{secret}=");
        return sb.ToString();
    }

    private static string RenderNginx(DeploymentEnvironmentModel model, bool useTls)
    {
        var routes = model.Workloads
            .SelectMany(item => item.Workload.Ports
                .Where(port => port.Protocol == DeploymentPortProtocol.Http && port.Route is not null)
                .Select(port => new ProxyRoute(
                    item.Workload.Identity,
                    port.ContainerPort,
                    port.Route!,
                    port.UpstreamRoute)))
            .OrderByDescending(route => route.Route.Length)
            .ThenBy(route => route.Route, StringComparer.OrdinalIgnoreCase)
            .ToList();
        var staticRoutes = model.StaticRoutes
            .OrderByDescending(route => route.Route.Length)
            .ThenBy(route => route.Route, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var sb = new StringBuilder()
            .AppendLine("# generated: Dominio.Deployment.DockerComposeRenderer")
            .AppendLine("server {")
            .AppendLine(useTls ? "    listen 443 ssl;" : "    listen 80;")
            .AppendLine($"    server_name {model.Domain};")
            .AppendLine("    resolver 127.0.0.11 ipv6=off valid=30s;");

        if (useTls)
        {
            sb.AppendLine($"    ssl_certificate /etc/letsencrypt/live/{model.Domain}/fullchain.pem;")
                .AppendLine($"    ssl_certificate_key /etc/letsencrypt/live/{model.Domain}/privkey.pem;");
        }

        foreach (var route in staticRoutes)
        {
            sb.AppendLine()
                .AppendLine($"    location {route.Route} {{")
                .AppendLine($"        alias {route.ResourcePath};")
                .AppendLine("    }");
        }

        foreach (var route in routes)
        {
            var variable = Slug(route.Workload).Replace('-', '_');
            sb.AppendLine()
                .AppendLine($"    location {route.Route} {{")
                .AppendLine($"        set ${variable}_upstream {route.Workload}:{route.Port};");
            if (route.UpstreamRoute is not null)
            {
                var externalRoute = Regex.Escape(route.Route.TrimEnd('/'));
                var upstreamRoute = route.UpstreamRoute.TrimEnd('/');
                sb.AppendLine(
                    $"        rewrite ^{externalRoute}(?:/(.*))?$ {upstreamRoute}/$1 break;");
            }
            sb.AppendLine($"        proxy_pass http://${variable}_upstream;")
                .AppendLine("        proxy_http_version 1.1;")
                .AppendLine("        proxy_set_header Host $host;")
                .AppendLine("        proxy_set_header X-Real-IP $remote_addr;")
                .AppendLine("        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;")
                .AppendLine("        proxy_set_header X-Forwarded-Proto $scheme;")
                .AppendLine("        proxy_set_header Upgrade $http_upgrade;")
                .AppendLine("        proxy_set_header Connection $connection_upgrade;")
                .AppendLine("    }");
        }

        sb.AppendLine("}");
        var map = useTls
            ? string.Empty
            : "map $http_upgrade $connection_upgrade {\n    default upgrade;\n    '' close;\n}\n\n";
        return map + sb;
    }

    private static string RenderBootstrap(DeploymentEnvironmentModel model)
    {
        var resources = ContainerResources(model).Select(resource => resource.Identity).ToList();
        var sb = ScriptHeader()
            .AppendLine("# Sobe somente os recursos compartilhados da maquina.")
            .AppendLine("require_env");
        if (resources.Count > 0)
            sb.AppendLine($"docker compose up -d --wait {string.Join(' ', resources)}");
        return sb.ToString();
    }

    private static string RenderApplicationDeploy(DeploymentEnvironmentModel model, string application)
    {
        var items = model.Workloads
            .Where(item => string.Equals(item.Application, application, StringComparison.OrdinalIgnoreCase))
            .Select(item => item.Workload)
            .ToList();
        var builds = items.Where(workload => workload.Source.Kind != DeploymentWorkloadSourceKind.Image)
            .Select(workload => workload.Identity)
            .ToList();
        var jobs = items.Where(workload => workload.Mode == DeploymentWorkloadMode.Job)
            .Select(workload => workload.Identity)
            .ToList();
        var services = items.Where(workload => workload.Mode == DeploymentWorkloadMode.Service)
            .Select(workload => workload.Identity)
            .ToList();
        var resources = RequiredContainerResources(model, items).ToList();

        var sb = ScriptHeader()
            .AppendLine($"# Deploy independente do aplicativo {application}.")
            .AppendLine("require_env");
        if (resources.Count > 0)
            sb.AppendLine($"docker compose up -d --wait {string.Join(' ', resources)}");
        if (builds.Count > 0)
            sb.AppendLine($"docker compose build {string.Join(' ', builds)}");
        foreach (var job in jobs)
            sb.AppendLine($"docker compose --profile jobs run --rm {job}");
        if (services.Count > 0)
        {
            var scale = items
                .Where(workload => workload.Mode == DeploymentWorkloadMode.Service && workload.Replicas > 1)
                .Select(workload => $"--scale {workload.Identity}={workload.Replicas}");
            sb.Append("docker compose up -d ")
                .Append(string.Join(' ', scale))
                .Append(' ')
                .AppendLine(string.Join(' ', services));
        }
        sb.AppendLine("docker compose up -d gateway")
            .AppendLine("docker compose ps");
        return sb.ToString();
    }

    private static string RenderAllDeploy(DeploymentEnvironmentModel model)
    {
        var sb = ScriptHeader()
            .AppendLine("./bootstrap-environment.sh");
        foreach (var application in model.Applications)
            sb.AppendLine($"./deploy-{Slug(application)}.sh");
        return sb.ToString();
    }

    private static StringBuilder ScriptHeader()
    {
        return new StringBuilder()
            .AppendLine("#!/usr/bin/env bash")
            .AppendLine("set -euo pipefail")
            .AppendLine()
            .AppendLine("SCRIPT_DIR=\"$(cd \"$(dirname \"${BASH_SOURCE[0]}\")\" && pwd)\"")
            .AppendLine("cd \"$SCRIPT_DIR\"")
            .AppendLine()
            .AppendLine("require_env() {")
            .AppendLine("  if [[ ! -f .env ]]; then")
            .AppendLine("    echo \"Arquivo .env ausente. Use .env.example como lista de referencias.\" >&2")
            .AppendLine("    exit 1")
            .AppendLine("  fi")
            .AppendLine("}")
            .AppendLine();
    }

    private static IEnumerable<DeploymentEnvironmentResource> ContainerResources(DeploymentEnvironmentModel model)
    {
        return model.Resources
            .Where(resource => resource.Kind is DeploymentResourceKind.DatabaseServer or
                DeploymentResourceKind.MessageBroker or DeploymentResourceKind.Cache)
            .OrderBy(resource => resource.Identity, StringComparer.OrdinalIgnoreCase);
    }

    private static IEnumerable<DeploymentEnvironmentResource> StaticRouteResources(DeploymentEnvironmentModel model)
    {
        var identities = model.StaticRoutes.Select(route => route.Resource)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        return model.Resources.Where(resource => identities.Contains(resource.Identity));
    }

    private static IEnumerable<string> NamedVolumes(DeploymentEnvironmentModel model)
    {
        return model.Resources.SelectMany(resource => resource.Persistence
                .Where(persistence => !resource.PersistenceBindings.ContainsKey(persistence.Name))
                .Select(persistence => VolumeName(resource.Identity, persistence.Name)))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(value => value, StringComparer.OrdinalIgnoreCase);
    }

    private static IEnumerable<ServiceDependency> ResolveServiceDependencies(
        DeploymentEnvironmentModel model,
        IEnumerable<string> requirements)
    {
        var dependencies = new Dictionary<string, ServiceDependency>(StringComparer.OrdinalIgnoreCase);
        foreach (var requirement in requirements)
        {
            var resource = model.Resources.SingleOrDefault(candidate =>
                string.Equals(candidate.Identity, requirement, StringComparison.OrdinalIgnoreCase));
            if (resource is not null)
            {
                if (resource.Kind == DeploymentResourceKind.DatabaseCatalog)
                {
                    var parent = resource.Parent
                        ?? throw new InvalidOperationException($"O catalogo '{resource.Identity}' nao possui servidor.");
                    dependencies[parent] = new ServiceDependency(parent, "service_healthy");
                }
                else if (resource.Kind != DeploymentResourceKind.Storage)
                {
                    dependencies[resource.Identity] = new ServiceDependency(resource.Identity, "service_healthy");
                }
                continue;
            }

            var workload = model.Workloads.Single(candidate =>
                string.Equals(candidate.Workload.Identity, requirement, StringComparison.OrdinalIgnoreCase));
            dependencies[workload.Workload.Identity] =
                new ServiceDependency(workload.Workload.Identity, "service_started");
        }
        return dependencies.Values.OrderBy(value => value.Identity, StringComparer.OrdinalIgnoreCase);
    }

    private static IEnumerable<string> RequiredContainerResources(
        DeploymentEnvironmentModel model,
        IReadOnlyCollection<DeploymentWorkload> applicationWorkloads)
    {
        var applicationIdentities = applicationWorkloads.Select(workload => workload.Identity)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var required = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var pending = new Queue<string>(applicationWorkloads.SelectMany(workload => workload.Requires));
        while (pending.TryDequeue(out var identity))
        {
            var resource = model.Resources.SingleOrDefault(candidate =>
                string.Equals(candidate.Identity, identity, StringComparison.OrdinalIgnoreCase));
            if (resource is not null)
            {
                if (resource.Kind == DeploymentResourceKind.DatabaseCatalog && resource.Parent is not null)
                    required.Add(resource.Parent);
                else if (resource.Kind is DeploymentResourceKind.DatabaseServer or
                    DeploymentResourceKind.MessageBroker or DeploymentResourceKind.Cache)
                    required.Add(resource.Identity);
                continue;
            }

            var dependency = model.Workloads.SingleOrDefault(item =>
                string.Equals(item.Workload.Identity, identity, StringComparison.OrdinalIgnoreCase));
            if (dependency is not null && applicationIdentities.Contains(dependency.Workload.Identity))
            {
                foreach (var nested in dependency.Workload.Requires)
                    pending.Enqueue(nested);
            }
        }
        return required.OrderBy(value => value, StringComparer.OrdinalIgnoreCase);
    }

    private static DeploymentEnvironmentResource FindResource(DeploymentEnvironmentModel model, string identity)
    {
        return model.Resources.Single(resource =>
            string.Equals(resource.Identity, identity, StringComparison.OrdinalIgnoreCase));
    }

    private string RelativePath(string path)
    {
        return DeploymentWorkloadBuilder.NormalizePath(Path.GetRelativePath(_outputDirectory, path));
    }

    private static string EnvironmentVariable(string secret)
    {
        var value = new StringBuilder();
        foreach (var character in secret.ToUpperInvariant())
            value.Append(char.IsLetterOrDigit(character) ? character : '_');
        return value.ToString();
    }

    private static string NormalizeCpu(string cpu)
    {
        if (cpu.EndsWith('m') && decimal.TryParse(cpu[..^1], out var millicpu))
            return (millicpu / 1000m).ToString(System.Globalization.CultureInfo.InvariantCulture);
        return cpu;
    }

    private static string Slug(string value)
    {
        var slug = new StringBuilder();
        foreach (var character in value.ToLowerInvariant())
        {
            if (char.IsLetterOrDigit(character))
                slug.Append(character);
            else if (slug.Length > 0 && slug[^1] != '-')
                slug.Append('-');
        }
        return slug.ToString().Trim('-');
    }

    private static string VolumeName(string resource, string persistence)
    {
        return Slug($"{resource}-{persistence}");
    }

    private static string PersistenceSource(
        DeploymentEnvironmentResource resource,
        DeploymentPersistence persistence)
    {
        return resource.PersistenceBindings.TryGetValue(persistence.Name, out var hostPath)
            ? hostPath
            : VolumeName(resource.Identity, persistence.Name);
    }

    private static string Yaml(string value)
    {
        return JsonSerializer.Serialize(value);
    }

    private static void WriteShellScript(string path, string content)
    {
        File.WriteAllText(path, content.Replace("\r\n", "\n"));
    }

    private sealed record ServiceDependency(string Identity, string Condition);
    private sealed record ProxyRoute(string Workload, int Port, string Route, string? UpstreamRoute);
}
