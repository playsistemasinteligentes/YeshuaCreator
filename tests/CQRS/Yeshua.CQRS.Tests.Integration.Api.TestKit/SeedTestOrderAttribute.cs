namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

[AttributeUsage(AttributeTargets.Class)]
public sealed class SeedTestOrderAttribute : Attribute
{
    public SeedTestOrderAttribute(int order)
    {
        Order = order;
    }

    public int Order { get; }
}

