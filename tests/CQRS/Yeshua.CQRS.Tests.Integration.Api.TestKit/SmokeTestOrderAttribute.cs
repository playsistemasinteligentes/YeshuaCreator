namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

[AttributeUsage(AttributeTargets.Class)]
public sealed class SmokeTestOrderAttribute : Attribute
{
    public SmokeTestOrderAttribute(int order)
    {
        Order = order;
    }

    public int Order { get; }
}
