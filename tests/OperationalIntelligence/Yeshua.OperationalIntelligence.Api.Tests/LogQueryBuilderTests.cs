using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class LogQueryBuilderTests
{
    [TestMethod]
    public void BuildRuntimeUsesLabelsAndEscapedIdentityFilters()
    {
        var query = LogQueryBuilder.BuildRuntime(
            "Fiscal",
            "Production",
            "1.2.3",
            "root-1",
            "operation-1\" |~ \"unsafe",
            "entity-1",
            "trace-1");

        StringAssert.Contains(query, "service_name=~\".*Fiscal.*\"");
        StringAssert.Contains(query, "deployment_environment_name=~\".*Production.*\"");
        StringAssert.Contains(query, "service_version=\"1.2.3\"");
        StringAssert.Contains(query, "|= \"root-1\"");
        StringAssert.Contains(query, "|= \"operation-1\\\" |~ \\\"unsafe\"");
        StringAssert.Contains(query, "|= \"entity-1\"");
        StringAssert.Contains(query, "|= \"trace-1\"");
    }
}
