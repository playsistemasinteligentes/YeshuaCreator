using Xunit;

namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

public sealed class IntegrationFactAttribute : FactAttribute
{
    public IntegrationFactAttribute()
    {
        if (!ApiIntegrationSettings.IsConfigured)
            Skip = ApiIntegrationSettings.NotConfiguredMessage;
    }
}
