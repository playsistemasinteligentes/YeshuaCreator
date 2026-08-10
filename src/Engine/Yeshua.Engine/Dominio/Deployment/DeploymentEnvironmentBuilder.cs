namespace Dominio.Deployment;

public sealed class DeploymentResourceProviderBuilder
{
    private readonly DeploymentResourceProviderDefinition _definition;

    internal DeploymentResourceProviderBuilder(DeploymentResourceProviderDefinition definition)
    {
        _definition = definition;
    }

    public DeploymentResourceProviderBuilder FromImage(string image)
    {
        _definition.Image = Required(image, nameof(image));
        return this;
    }

    public DeploymentResourceProviderBuilder Configure(string key, string value)
    {
        _definition.Configuration[Required(key, nameof(key))] = Required(value, nameof(value));
        return this;
    }

    public DeploymentResourceProviderBuilder Publish(int hostPort, int containerPort)
    {
        if (hostPort is < 1 or > 65535)
            throw new ArgumentOutOfRangeException(nameof(hostPort));
        if (containerPort is < 1 or > 65535)
            throw new ArgumentOutOfRangeException(nameof(containerPort));

        _definition.PublishedPorts.Add(new DeploymentPublishedPort
        {
            HostPort = hostPort,
            ContainerPort = containerPort
        });
        return this;
    }

    public DeploymentResourceProviderBuilder BindPersistence(string persistence, string hostPath)
    {
        _definition.PersistenceBindings[Required(persistence, nameof(persistence))] =
            Required(hostPath, nameof(hostPath));
        return this;
    }

    private static string Required(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("O valor deve ser informado.", parameterName);
        return value.Trim();
    }
}
