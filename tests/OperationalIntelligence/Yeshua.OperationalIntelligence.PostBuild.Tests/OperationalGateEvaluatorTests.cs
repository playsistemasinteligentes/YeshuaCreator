using Yeshua.OperationalIntelligence.PostBuild;

namespace Yeshua.OperationalIntelligence.PostBuild.Tests;

[TestClass]
public sealed class OperationalGateEvaluatorTests
{
    [TestMethod]
    public void EvaluateKeepsUnprovenGatesMissing()
    {
        var checks = new[]
        {
            Passed("BuildIntegrity"),
            Passed("VersionIntegrity"),
            Passed("ApiLiveness"),
            Passed("CrudSmoke")
        };

        var gates = OperationalGateEvaluator.Evaluate(checks);

        Assert.AreEqual("Passed", gates.Single(gate => gate.Gate == "G2").Status);
        Assert.AreEqual("Passed", gates.Single(gate => gate.Gate == "G4").Status);
        Assert.AreEqual("Passed", gates.Single(gate => gate.Gate == "G7").Status);
        Assert.AreEqual("Missing", gates.Single(gate => gate.Gate == "G1").Status);
        Assert.AreEqual("Missing", gates.Single(gate => gate.Gate == "G3").Status);
        Assert.AreEqual("Missing", gates.Single(gate => gate.Gate == "G5").Status);
        Assert.AreEqual("Missing", gates.Single(gate => gate.Gate == "G6").Status);
    }

    [TestMethod]
    public void EvaluatePassesOnlyWhenEveryExplicitGateEvidencePasses()
    {
        var checks = Enumerable.Range(1, 7)
            .Select(number => new PostBuildCheckResult(
                $"EvidenceG{number}",
                "Passed",
                true,
                0,
                "confirmed",
                [$"G{number}"]))
            .ToArray();

        var gates = OperationalGateEvaluator.Evaluate(checks);

        Assert.AreEqual(7, gates.Count);
        Assert.IsTrue(gates.All(gate => gate.Status == "Passed"));
    }

    [TestMethod]
    public void EvaluateFailsGateWhenRequiredEvidenceWasSkipped()
    {
        var gates = OperationalGateEvaluator.Evaluate(
        [
            new PostBuildCheckResult(
                "DirectedD2",
                "Skipped",
                true,
                0,
                "D2 was not executed.",
                ["G6"])
        ]);

        var gate = gates.Single(item => item.Gate == "G6");
        Assert.AreEqual("Failed", gate.Status);
        StringAssert.Contains(gate.Gaps.Single(), "Skipped");
    }

    private static PostBuildCheckResult Passed(string name) =>
        new(name, "Passed", true, 1, "confirmed");
}
