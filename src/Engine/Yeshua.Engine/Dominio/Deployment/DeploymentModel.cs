namespace Dominio.Deployment;

public enum DeploymentResourceKind
{
    DatabaseServer,
    DatabaseCatalog,
    MessageBroker,
    Storage,
    Cache
}

public enum DeploymentWorkloadMode
{
    Service,
    Job
}

public enum DeploymentWorkloadSourceKind
{
    Project,
    BuildContext,
    Image
}

public enum DeploymentPortProtocol
{
    Http,
    Tcp
}

public enum DeploymentHealthCheckKind
{
    Http,
    Tcp,
    Command
}

public enum DotNetRuntimeKind
{
    AspNetCore,
    Runtime
}

public sealed class DeploymentModel
{
    public string Version { get; init; } = "1.0";
    public string Application { get; init; } = string.Empty;
    public List<DeploymentResource> Resources { get; init; } = new();
    public List<DeploymentWorkload> Workloads { get; init; } = new();
}

public sealed class DeploymentResource
{
    public string Name { get; init; } = string.Empty;
    public string Identity { get; set; } = string.Empty;
    public DeploymentResourceKind Kind { get; init; }
    public string? Parent { get; set; }
    public Dictionary<string, string> Configuration { get; init; } = new();
    public List<DeploymentSecretReference> Secrets { get; init; } = new();
    public List<DeploymentPersistence> Persistence { get; init; } = new();
}

public sealed class DeploymentWorkload
{
    public string Name { get; init; } = string.Empty;
    public string Identity { get; init; } = string.Empty;
    public DeploymentWorkloadMode Mode { get; set; } = DeploymentWorkloadMode.Service;
    public DeploymentWorkloadSource Source { get; set; } = new();
    public int Replicas { get; set; } = 1;
    public List<string> Requires { get; init; } = new();
    public List<string> Consumes { get; init; } = new();
    public List<string> Produces { get; init; } = new();
    public Dictionary<string, string> Configuration { get; init; } = new();
    public List<DeploymentSecretReference> Secrets { get; init; } = new();
    public List<DeploymentPort> Ports { get; init; } = new();
    public List<DeploymentMount> Mounts { get; init; } = new();
    public DeploymentHealthCheck? HealthCheck { get; set; }
    public DeploymentComputeResources? Compute { get; set; }
}

public sealed class DeploymentWorkloadSource
{
    public DeploymentWorkloadSourceKind Kind { get; init; }
    public string? ProjectPath { get; init; }
    public string? BuildContext { get; init; }
    public string? Dockerfile { get; init; }
    public string? Image { get; init; }
}

public sealed class DeploymentSecretReference
{
    public string Target { get; init; } = string.Empty;
    public string Secret { get; init; } = string.Empty;
}

public sealed class DeploymentPersistence
{
    public string Name { get; init; } = string.Empty;
    public string MountPath { get; init; } = string.Empty;
}

public sealed class DeploymentPort
{
    public string Name { get; init; } = string.Empty;
    public int ContainerPort { get; init; }
    public DeploymentPortProtocol Protocol { get; init; }
    public string? Route { get; init; }
    public string? UpstreamRoute { get; init; }
}

public sealed class DeploymentMount
{
    public string Resource { get; init; } = string.Empty;
    public string MountPath { get; init; } = string.Empty;
    public bool ReadOnly { get; init; }
}

public sealed class DeploymentHealthCheck
{
    public DeploymentHealthCheckKind Kind { get; init; }
    public string? Port { get; init; }
    public string? Path { get; init; }
    public IReadOnlyList<string> Command { get; init; } = Array.Empty<string>();
    public int IntervalSeconds { get; init; } = 30;
    public int TimeoutSeconds { get; init; } = 5;
    public int Retries { get; init; } = 3;
}

public sealed class DeploymentComputeResources
{
    public string? CpuRequest { get; init; }
    public string? CpuLimit { get; init; }
    public string? MemoryRequest { get; init; }
    public string? MemoryLimit { get; init; }
}
