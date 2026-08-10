using System.Text;
using System.Text.Json;

namespace Dominio.Deployment;

public sealed class DeploymentResourceBuilder
{
    private readonly DeploymentResource _resource;

    internal DeploymentResourceBuilder(DeploymentResource resource)
    {
        _resource = resource;
    }

    public DeploymentResourceBuilder IdentifiedBy(string identity)
    {
        _resource.Identity = Required(identity, nameof(identity));
        return this;
    }

    public DeploymentResourceBuilder HostedBy(string parent)
    {
        _resource.Parent = Required(parent, nameof(parent));
        return this;
    }

    public DeploymentResourceBuilder Configure(string key, string value)
    {
        _resource.Configuration[Required(key, nameof(key))] = Required(value, nameof(value));
        return this;
    }

    public DeploymentResourceBuilder Secret(string target, string secret)
    {
        _resource.Secrets.Add(new DeploymentSecretReference
        {
            Target = Required(target, nameof(target)),
            Secret = Required(secret, nameof(secret))
        });
        return this;
    }

    public DeploymentResourceBuilder Persistent(string name, string mountPath)
    {
        _resource.Persistence.Add(new DeploymentPersistence
        {
            Name = Required(name, nameof(name)),
            MountPath = Required(mountPath, nameof(mountPath))
        });
        return this;
    }

    private static string Required(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("O valor deve ser informado.", parameterName);
        return value.Trim();
    }
}

public sealed class DeploymentWorkloadBuilder
{
    private readonly DeploymentWorkloadDefinition _definition;

    internal DeploymentWorkloadBuilder(DeploymentWorkloadDefinition definition)
    {
        _definition = definition;
    }

    public DeploymentWorkloadBuilder FromProject(
        string projectPath,
        DotNetRuntimeKind runtime = DotNetRuntimeKind.AspNetCore)
    {
        EnsureSourceWasNotSet();
        _definition.ProjectRuntime = runtime;
        _definition.Model.Source = new DeploymentWorkloadSource
        {
            Kind = DeploymentWorkloadSourceKind.Project,
            ProjectPath = NormalizePath(Required(projectPath, nameof(projectPath)))
        };
        return this;
    }

    public DeploymentWorkloadBuilder FromBuildContext(
        string buildContext,
        string dockerfile = "Dockerfile")
    {
        EnsureSourceWasNotSet();
        _definition.Model.Source = new DeploymentWorkloadSource
        {
            Kind = DeploymentWorkloadSourceKind.BuildContext,
            BuildContext = NormalizePath(Required(buildContext, nameof(buildContext))),
            Dockerfile = NormalizePath(Required(dockerfile, nameof(dockerfile)))
        };
        return this;
    }

    public DeploymentWorkloadBuilder FromImage(string image)
    {
        EnsureSourceWasNotSet();
        _definition.Model.Source = new DeploymentWorkloadSource
        {
            Kind = DeploymentWorkloadSourceKind.Image,
            Image = Required(image, nameof(image))
        };
        return this;
    }

    public DeploymentWorkloadBuilder ScaffoldDockerfile(DockerfileTemplate template)
    {
        ArgumentNullException.ThrowIfNull(template);
        if (_definition.Model.Source.Kind != DeploymentWorkloadSourceKind.BuildContext)
        {
            throw new InvalidOperationException(
                "O scaffold de Dockerfile exige um workload criado com FromBuildContext.");
        }

        _definition.DockerfileTemplate = template;
        return this;
    }

    public DeploymentWorkloadBuilder RunOnce()
    {
        _definition.Model.Mode = DeploymentWorkloadMode.Job;
        _definition.Model.Replicas = 1;
        return this;
    }

    public DeploymentWorkloadBuilder Scale(int replicas)
    {
        if (replicas < 1)
            throw new ArgumentOutOfRangeException(nameof(replicas), "A escala deve ser maior que zero.");
        if (_definition.Model.Mode == DeploymentWorkloadMode.Job && replicas != 1)
            throw new InvalidOperationException("Um workload de execucao unica deve possuir uma replica.");

        _definition.Model.Replicas = replicas;
        return this;
    }

    public DeploymentWorkloadBuilder Requires(params string[] dependencies)
    {
        AddDistinct(_definition.Model.Requires, dependencies);
        return this;
    }

    public DeploymentWorkloadBuilder Consumes(params string[] messages)
    {
        AddDistinct(_definition.Model.Consumes, messages);
        return this;
    }

    public DeploymentWorkloadBuilder Produces(params string[] messages)
    {
        AddDistinct(_definition.Model.Produces, messages);
        return this;
    }

    public DeploymentWorkloadBuilder Configure(string key, string value)
    {
        _definition.Model.Configuration[Required(key, nameof(key))] = Required(value, nameof(value));
        return this;
    }

    public DeploymentWorkloadBuilder Secret(string target, string secret)
    {
        _definition.Model.Secrets.Add(new DeploymentSecretReference
        {
            Target = Required(target, nameof(target)),
            Secret = Required(secret, nameof(secret))
        });
        return this;
    }

    public DeploymentWorkloadBuilder ExposeHttp(
        string name,
        int containerPort,
        string? route = null,
        string? upstreamRoute = null)
    {
        if (containerPort is < 1 or > 65535)
            throw new ArgumentOutOfRangeException(nameof(containerPort));
        if (route is not null && !route.StartsWith('/'))
            throw new ArgumentException("A rota HTTP deve iniciar com '/'.", nameof(route));
        if (upstreamRoute is not null && !upstreamRoute.StartsWith('/'))
            throw new ArgumentException("A rota interna HTTP deve iniciar com '/'.", nameof(upstreamRoute));

        _definition.Model.Ports.Add(new DeploymentPort
        {
            Name = Required(name, nameof(name)),
            ContainerPort = containerPort,
            Protocol = DeploymentPortProtocol.Http,
            Route = route,
            UpstreamRoute = upstreamRoute
        });
        return this;
    }

    public DeploymentWorkloadBuilder Mount(string resource, string mountPath, bool readOnly = false)
    {
        _definition.Model.Mounts.Add(new DeploymentMount
        {
            Resource = Required(resource, nameof(resource)),
            MountPath = Required(mountPath, nameof(mountPath)),
            ReadOnly = readOnly
        });
        return this;
    }

    public DeploymentWorkloadBuilder TcpHealthCheck(
        string port,
        int intervalSeconds = 30,
        int timeoutSeconds = 5,
        int retries = 3)
    {
        _definition.Model.HealthCheck = new DeploymentHealthCheck
        {
            Kind = DeploymentHealthCheckKind.Tcp,
            Port = Required(port, nameof(port)),
            IntervalSeconds = Positive(intervalSeconds, nameof(intervalSeconds)),
            TimeoutSeconds = Positive(timeoutSeconds, nameof(timeoutSeconds)),
            Retries = Positive(retries, nameof(retries))
        };
        return this;
    }

    public DeploymentWorkloadBuilder HttpHealthCheck(
        string port,
        string path,
        int intervalSeconds = 30,
        int timeoutSeconds = 5,
        int retries = 3)
    {
        if (!path.StartsWith('/'))
            throw new ArgumentException("O caminho do healthcheck deve iniciar com '/'.", nameof(path));

        _definition.Model.HealthCheck = new DeploymentHealthCheck
        {
            Kind = DeploymentHealthCheckKind.Http,
            Port = Required(port, nameof(port)),
            Path = path,
            IntervalSeconds = Positive(intervalSeconds, nameof(intervalSeconds)),
            TimeoutSeconds = Positive(timeoutSeconds, nameof(timeoutSeconds)),
            Retries = Positive(retries, nameof(retries))
        };
        return this;
    }

    public DeploymentWorkloadBuilder CommandHealthCheck(params string[] command)
    {
        var values = command.Select(value => Required(value, nameof(command))).ToArray();
        if (values.Length == 0)
            throw new ArgumentException("O comando do healthcheck deve ser informado.", nameof(command));

        _definition.Model.HealthCheck = new DeploymentHealthCheck
        {
            Kind = DeploymentHealthCheckKind.Command,
            Command = values
        };
        return this;
    }

    public DeploymentWorkloadBuilder Resources(
        string? cpuRequest = null,
        string? memoryRequest = null,
        string? cpuLimit = null,
        string? memoryLimit = null)
    {
        _definition.Model.Compute = new DeploymentComputeResources
        {
            CpuRequest = Optional(cpuRequest),
            MemoryRequest = Optional(memoryRequest),
            CpuLimit = Optional(cpuLimit),
            MemoryLimit = Optional(memoryLimit)
        };
        return this;
    }

    private void EnsureSourceWasNotSet()
    {
        if (_definition.SourceWasSet)
            throw new InvalidOperationException("O workload deve possuir apenas uma origem.");
        _definition.SourceWasSet = true;
    }

    private static void AddDistinct(List<string> destination, IEnumerable<string> values)
    {
        foreach (var value in values.Select(value => Required(value, nameof(values))))
        {
            if (!destination.Contains(value, StringComparer.OrdinalIgnoreCase))
                destination.Add(value);
        }
    }

    private static int Positive(int value, string parameterName)
    {
        if (value < 1)
            throw new ArgumentOutOfRangeException(parameterName);
        return value;
    }

    private static string Required(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("O valor deve ser informado.", parameterName);
        return value.Trim();
    }

    private static string? Optional(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }

    internal static string NormalizePath(string path)
    {
        return path.Replace('\\', '/');
    }
}

public sealed class DockerfileTemplate
{
    internal DockerfileTemplate(string name, int version, string content)
    {
        Name = name;
        Version = version;
        Content = content;
    }

    public string Name { get; }
    public int Version { get; }
    internal string Content { get; }

    public static DockerfileTemplate PythonWorker(Action<PythonDockerfileTemplateBuilder> configure)
    {
        var builder = new PythonDockerfileTemplateBuilder();
        configure(builder);
        return builder.Build();
    }
}

public sealed class PythonDockerfileTemplateBuilder
{
    private string _pythonVersion = "3.11";
    private string _workingDirectory = "/app";
    private string _requirements = "requirements.txt";
    private string _sourceDirectory = "app";
    private readonly List<string> _systemPackages = new();
    private readonly List<string> _command = new();

    public PythonDockerfileTemplateBuilder PythonVersion(string version)
    {
        _pythonVersion = Required(version, nameof(version));
        return this;
    }

    public PythonDockerfileTemplateBuilder WorkingDirectory(string path)
    {
        _workingDirectory = Required(path, nameof(path));
        return this;
    }

    public PythonDockerfileTemplateBuilder InstallSystemPackages(params string[] packages)
    {
        foreach (var package in packages.Select(value => Required(value, nameof(packages))))
        {
            if (!_systemPackages.Contains(package, StringComparer.OrdinalIgnoreCase))
                _systemPackages.Add(package);
        }
        return this;
    }

    public PythonDockerfileTemplateBuilder InstallRequirements(string path)
    {
        _requirements = Required(path, nameof(path));
        return this;
    }

    public PythonDockerfileTemplateBuilder CopyDirectory(string path)
    {
        _sourceDirectory = Required(path, nameof(path));
        return this;
    }

    public PythonDockerfileTemplateBuilder Command(params string[] command)
    {
        _command.Clear();
        _command.AddRange(command.Select(value => Required(value, nameof(command))));
        return this;
    }

    internal DockerfileTemplate Build()
    {
        if (_command.Count == 0)
            throw new InvalidOperationException("O comando do template Python deve ser informado.");

        var content = new StringBuilder()
            .AppendLine($"FROM python:{_pythonVersion}-slim")
            .AppendLine()
            .AppendLine($"WORKDIR {_workingDirectory}")
            .AppendLine();

        if (_systemPackages.Count > 0)
        {
            content.AppendLine("RUN apt-get update && apt-get install -y \\")
                .Append("    ")
                .Append(string.Join(" \\\n    ", _systemPackages))
                .AppendLine(" \\")
                .AppendLine("    && rm -rf /var/lib/apt/lists/*")
                .AppendLine();
        }

        content.AppendLine($"COPY {_requirements} .")
            .AppendLine($"RUN pip install --no-cache-dir -r {Path.GetFileName(_requirements)}")
            .AppendLine()
            .AppendLine($"COPY {_sourceDirectory} ./{_sourceDirectory}")
            .AppendLine()
            .AppendLine("ENV PYTHONUNBUFFERED=1")
            .AppendLine()
            .AppendLine($"CMD {JsonSerializer.Serialize(_command)}");

        return new DockerfileTemplate("python-worker", 1, content.ToString());
    }

    private static string Required(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("O valor deve ser informado.", parameterName);
        return value.Trim();
    }
}

internal sealed class DeploymentWorkloadDefinition
{
    public required DeploymentWorkload Model { get; init; }
    public bool SourceWasSet { get; set; }
    public DotNetRuntimeKind ProjectRuntime { get; set; } = DotNetRuntimeKind.AspNetCore;
    public DockerfileTemplate? DockerfileTemplate { get; set; }
}
