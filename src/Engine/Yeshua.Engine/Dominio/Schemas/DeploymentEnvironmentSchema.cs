using System.Text.Json;
using System.Text.Json.Serialization;
using Dominio.Deployment;

namespace Dominio.Schemas;

public sealed class DeploymentEnvironmentSchema
{
    private readonly DeploymentEnvironmentDefinition _definition;

    public DeploymentEnvironmentSchema(string environment, string solutionDirectory)
    {
        if (string.IsNullOrWhiteSpace(environment))
            throw new ArgumentException("O nome do ambiente deve ser informado.", nameof(environment));
        if (string.IsNullOrWhiteSpace(solutionDirectory))
            throw new ArgumentException("O diretorio da solucao deve ser informado.", nameof(solutionDirectory));

        _definition = new DeploymentEnvironmentDefinition
        {
            Name = environment.Trim(),
            SolutionDirectory = solutionDirectory
        };
    }

    public DeploymentEnvironmentSchema Domain(string domain)
    {
        _definition.Domain = Required(domain, nameof(domain));
        return this;
    }

    public DeploymentEnvironmentSchema IncludeApplication(params string[] applications)
    {
        foreach (var application in applications.Select(value => Required(value, nameof(applications))))
        {
            if (!_definition.Applications.Contains(application, StringComparer.OrdinalIgnoreCase))
                _definition.Applications.Add(application);
        }
        return this;
    }

    public DeploymentEnvironmentSchema ProvideResource(
        string identity,
        Action<DeploymentResourceProviderBuilder> configure)
    {
        identity = Required(identity, nameof(identity));
        ArgumentNullException.ThrowIfNull(configure);
        if (_definition.Providers.ContainsKey(identity))
            throw new InvalidOperationException($"O provider do recurso '{identity}' ja foi declarado.");

        var provider = new DeploymentResourceProviderDefinition { Identity = identity };
        configure(new DeploymentResourceProviderBuilder(provider));
        _definition.Providers.Add(identity, provider);
        return this;
    }

    public DeploymentEnvironmentSchema MapStorage(
        string resourceIdentity,
        string route,
        string resourcePath)
    {
        if (!route.StartsWith('/'))
            throw new ArgumentException("A rota deve iniciar com '/'.", nameof(route));

        _definition.StaticRoutes.Add(new DeploymentStaticRoute
        {
            Resource = Required(resourceIdentity, nameof(resourceIdentity)),
            Route = route,
            ResourcePath = Required(resourcePath, nameof(resourcePath))
        });
        return this;
    }

    public DeploymentEnvironmentModel Generate()
    {
        var model = CreateModel();
        var outputDirectory = OutputDirectory();
        Directory.CreateDirectory(outputDirectory);
        File.WriteAllText(
            Path.Combine(outputDirectory, "environment-model.json"),
            JsonSerializer.Serialize(model, JsonOptions()));

        new DockerComposeRenderer(_definition.SolutionDirectory, outputDirectory)
            .Render(model);
        return model;
    }

    public DeploymentEnvironmentModel CreateModel()
    {
        if (_definition.Applications.Count == 0)
            throw new InvalidOperationException("O ambiente deve possuir pelo menos um aplicativo.");
        if (string.IsNullOrWhiteSpace(_definition.Domain))
            throw new InvalidOperationException("O dominio do ambiente deve ser informado.");

        var model = new DeploymentEnvironmentModel
        {
            Environment = _definition.Name,
            Domain = _definition.Domain,
            Applications = _definition.Applications.ToList(),
            StaticRoutes = _definition.StaticRoutes.ToList()
        };

        foreach (var application in _definition.Applications)
            MergeApplication(model, LoadApplicationManifest(application));

        ApplyProviders(model);
        Validate(model);
        return model;
    }

    private DeploymentModel LoadApplicationManifest(string application)
    {
        var path = Path.Combine(
            _definition.SolutionDirectory,
            "infra",
            application,
            "Migration",
            "deployment-model.json");
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"O manifesto do aplicativo '{application}' nao foi encontrado. Execute o Studio com --deployment-only.",
                path);
        }

        var manifest = JsonSerializer.Deserialize<DeploymentModel>(File.ReadAllText(path), JsonOptions())
            ?? throw new InvalidOperationException($"O manifesto '{path}' e invalido.");
        if (!string.Equals(manifest.Application, application, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"O manifesto '{path}' pertence ao aplicativo '{manifest.Application}'.");
        }
        return manifest;
    }

    private static void MergeApplication(DeploymentEnvironmentModel environment, DeploymentModel application)
    {
        var resourceIdentities = application.Resources.ToDictionary(
            resource => resource.Name,
            resource => resource.Identity,
            StringComparer.OrdinalIgnoreCase);
        var workloadIdentities = application.Workloads.ToDictionary(
            workload => workload.Name,
            workload => workload.Identity,
            StringComparer.OrdinalIgnoreCase);

        foreach (var resource in application.Resources)
        {
            var parentIdentity = resource.Parent is null
                ? null
                : resourceIdentities[resource.Parent];
            MergeResource(environment, application.Application, resource, parentIdentity);
        }

        foreach (var workload in application.Workloads)
        {
            var clone = CloneWorkload(workload);
            clone.Requires.Clear();
            clone.Requires.AddRange(workload.Requires.Select(requirement =>
                resourceIdentities.TryGetValue(requirement, out var resourceIdentity)
                    ? resourceIdentity
                    : workloadIdentities.TryGetValue(requirement, out var workloadIdentity)
                        ? workloadIdentity
                        : requirement));
            clone.Mounts.Clear();
            clone.Mounts.AddRange(workload.Mounts.Select(mount => new DeploymentMount
            {
                Resource = resourceIdentities[mount.Resource],
                MountPath = mount.MountPath,
                ReadOnly = mount.ReadOnly
            }));

            environment.Workloads.Add(new DeploymentEnvironmentWorkload
            {
                Application = application.Application,
                Workload = clone
            });
        }
    }

    private static void MergeResource(
        DeploymentEnvironmentModel environment,
        string application,
        DeploymentResource resource,
        string? parentIdentity)
    {
        var existing = environment.Resources.SingleOrDefault(candidate =>
            string.Equals(candidate.Identity, resource.Identity, StringComparison.OrdinalIgnoreCase));
        if (existing is null)
        {
            environment.Resources.Add(new DeploymentEnvironmentResource
            {
                Identity = resource.Identity,
                Kind = resource.Kind,
                Parent = parentIdentity,
                Applications = new List<string> { application },
                Configuration = new Dictionary<string, string>(resource.Configuration),
                Secrets = resource.Secrets.Select(CloneSecret).ToList(),
                Persistence = resource.Persistence.Select(ClonePersistence).ToList()
            });
            return;
        }

        if (existing.Kind != resource.Kind ||
            !DictionaryEqual(existing.Configuration, resource.Configuration) ||
            !SecretListEqual(existing.Secrets, resource.Secrets) ||
            !PersistenceListEqual(existing.Persistence, resource.Persistence) ||
            !string.Equals(existing.Parent, parentIdentity, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"O recurso logico '{resource.Identity}' possui declaracoes incompativeis entre aplicativos.");
        }
        if (!existing.Applications.Contains(application, StringComparer.OrdinalIgnoreCase))
            existing.Applications.Add(application);
    }

    private void ApplyProviders(DeploymentEnvironmentModel model)
    {
        foreach (var provider in _definition.Providers.Values)
        {
            var resource = model.Resources.SingleOrDefault(candidate =>
                string.Equals(candidate.Identity, provider.Identity, StringComparison.OrdinalIgnoreCase));
            if (resource is null)
                throw new InvalidOperationException($"O provider referencia o recurso inexistente '{provider.Identity}'.");

            resource.Image = provider.Image;
            foreach (var item in provider.Configuration)
                resource.RuntimeConfiguration[item.Key] = item.Value;
            foreach (var item in provider.PersistenceBindings)
                resource.PersistenceBindings[item.Key] = item.Value;
            resource.PublishedPorts.AddRange(provider.PublishedPorts);
        }
    }

    private static void Validate(DeploymentEnvironmentModel model)
    {
        var identities = model.Resources.Select(resource => resource.Identity)
            .Concat(model.Workloads.Select(workload => workload.Workload.Identity))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var persistentResources = model.Resources
            .Where(resource => resource.Persistence.Count > 0)
            .Select(resource => resource.Identity)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var resource in model.Resources.Where(resource =>
            resource.Kind is DeploymentResourceKind.DatabaseServer or
                DeploymentResourceKind.MessageBroker or
                DeploymentResourceKind.Cache))
        {
            if (string.IsNullOrWhiteSpace(resource.Image))
                throw new InvalidOperationException($"O recurso '{resource.Identity}' nao possui provider de imagem.");
        }

        foreach (var workload in model.Workloads.Select(item => item.Workload))
        {
            foreach (var requirement in workload.Requires)
            {
                if (!identities.Contains(requirement))
                    throw new InvalidOperationException($"O workload '{workload.Identity}' depende de '{requirement}' inexistente.");
            }
        }

        foreach (var staticRoute in model.StaticRoutes)
        {
            if (!persistentResources.Contains(staticRoute.Resource))
                throw new InvalidOperationException($"A rota estatica referencia o storage inexistente '{staticRoute.Resource}'.");
        }

        foreach (var resource in model.Resources)
        {
            var persistenceNames = resource.Persistence.Select(item => item.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);
            foreach (var binding in resource.PersistenceBindings.Keys)
            {
                if (!persistenceNames.Contains(binding))
                {
                    throw new InvalidOperationException(
                        $"O recurso '{resource.Identity}' associa a persistencia inexistente '{binding}'.");
                }
            }
        }

        var duplicatedRoute = model.Workloads
            .SelectMany(item => item.Workload.Ports
                .Where(port => port.Route is not null)
                .Select(port => port.Route!))
            .Concat(model.StaticRoutes.Select(route => route.Route))
            .GroupBy(route => route, StringComparer.OrdinalIgnoreCase)
            .FirstOrDefault(group => group.Count() > 1);
        if (duplicatedRoute is not null)
            throw new InvalidOperationException($"A rota '{duplicatedRoute.Key}' foi declarada mais de uma vez.");
    }

    private static DeploymentWorkload CloneWorkload(DeploymentWorkload source)
    {
        return new DeploymentWorkload
        {
            Name = source.Name,
            Identity = source.Identity,
            Mode = source.Mode,
            Source = source.Source,
            Replicas = source.Replicas,
            Requires = source.Requires.ToList(),
            Consumes = source.Consumes.ToList(),
            Produces = source.Produces.ToList(),
            Configuration = new Dictionary<string, string>(source.Configuration),
            Secrets = source.Secrets.Select(CloneSecret).ToList(),
            Ports = source.Ports.ToList(),
            Mounts = source.Mounts.ToList(),
            HealthCheck = source.HealthCheck,
            Compute = source.Compute
        };
    }

    private static DeploymentSecretReference CloneSecret(DeploymentSecretReference source)
    {
        return new DeploymentSecretReference { Target = source.Target, Secret = source.Secret };
    }

    private static DeploymentPersistence ClonePersistence(DeploymentPersistence source)
    {
        return new DeploymentPersistence { Name = source.Name, MountPath = source.MountPath };
    }

    private static bool DictionaryEqual(
        IReadOnlyDictionary<string, string> left,
        IReadOnlyDictionary<string, string> right)
    {
        return left.Count == right.Count && left.All(item =>
            right.TryGetValue(item.Key, out var value) && string.Equals(item.Value, value, StringComparison.Ordinal));
    }

    private static bool SecretListEqual(
        IReadOnlyCollection<DeploymentSecretReference> left,
        IReadOnlyCollection<DeploymentSecretReference> right)
    {
        return left.Count == right.Count && left.All(item => right.Any(candidate =>
            string.Equals(candidate.Target, item.Target, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(candidate.Secret, item.Secret, StringComparison.OrdinalIgnoreCase)));
    }

    private static bool PersistenceListEqual(
        IReadOnlyCollection<DeploymentPersistence> left,
        IReadOnlyCollection<DeploymentPersistence> right)
    {
        return left.Count == right.Count && left.All(item => right.Any(candidate =>
            string.Equals(candidate.Name, item.Name, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(candidate.MountPath, item.MountPath, StringComparison.Ordinal)));
    }

    private string OutputDirectory()
    {
        return Path.Combine(
            _definition.SolutionDirectory,
            "infra",
            "Environments",
            _definition.Name,
            "Migration");
    }

    private static JsonSerializerOptions JsonOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() }
        };
    }

    private static string Required(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("O valor deve ser informado.", parameterName);
        return value.Trim();
    }
}
