namespace Dominio.Deployment;

public sealed class DeploymentEnvironmentModel
{
    public string Version { get; init; } = "1.0";
    public string Environment { get; init; } = string.Empty;
    public string Domain { get; init; } = string.Empty;
    public List<string> Applications { get; init; } = new();
    public List<DeploymentEnvironmentResource> Resources { get; init; } = new();
    public List<DeploymentEnvironmentWorkload> Workloads { get; init; } = new();
    public List<DeploymentStaticRoute> StaticRoutes { get; init; } = new();
}

public sealed class DeploymentEnvironmentResource
{
    public string Identity { get; init; } = string.Empty;
    public DeploymentResourceKind Kind { get; init; }
    public string? Parent { get; set; }
    public string? Image { get; set; }
    public List<string> Applications { get; init; } = new();
    public Dictionary<string, string> Configuration { get; init; } = new();
    public Dictionary<string, string> RuntimeConfiguration { get; init; } = new();
    public List<DeploymentSecretReference> Secrets { get; init; } = new();
    public List<DeploymentPersistence> Persistence { get; init; } = new();
    public Dictionary<string, string> PersistenceBindings { get; init; } = new();
    public List<DeploymentPublishedPort> PublishedPorts { get; init; } = new();
}

public sealed class DeploymentEnvironmentWorkload
{
    public string Application { get; init; } = string.Empty;
    public required DeploymentWorkload Workload { get; init; }
}

public sealed class DeploymentPublishedPort
{
    public int HostPort { get; init; }
    public int ContainerPort { get; init; }
}

public sealed class DeploymentStaticRoute
{
    public string Resource { get; init; } = string.Empty;
    public string Route { get; init; } = string.Empty;
    public string ResourcePath { get; init; } = string.Empty;
}

internal sealed class DeploymentEnvironmentDefinition
{
    public string Name { get; init; } = string.Empty;
    public string SolutionDirectory { get; init; } = string.Empty;
    public string Domain { get; set; } = string.Empty;
    public List<string> Applications { get; } = new();
    public Dictionary<string, DeploymentResourceProviderDefinition> Providers { get; } =
        new(StringComparer.OrdinalIgnoreCase);
    public List<DeploymentStaticRoute> StaticRoutes { get; } = new();
}

internal sealed class DeploymentResourceProviderDefinition
{
    public string Identity { get; init; } = string.Empty;
    public string? Image { get; set; }
    public Dictionary<string, string> Configuration { get; } = new();
    public Dictionary<string, string> PersistenceBindings { get; } = new();
    public List<DeploymentPublishedPort> PublishedPorts { get; } = new();
}
