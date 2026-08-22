using Dominio.Schemas.CQRS;

namespace TestMigration;

[TestClass]
public class RuntimeIdentityGenerationTests
{
    [TestMethod]
    public void ClinicaGenerationCreatesRuntimeIdentityArtifactsAndBuildMetadata()
    {
        var solutionDirectory = Path.Combine(
            Path.GetTempPath(),
            "Yeshua.Engine.Tests",
            Guid.NewGuid().ToString("N"));

        try
        {
            var infrastructureDirectory = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure");
            var apiProject = CreateProject(
                infrastructureDirectory,
                "Yeshua.Clinica.CQRS.Infrastructure.Api");
            var workerProject = CreateProject(
                infrastructureDirectory,
                "Yeshua.Clinica.CQRS.Infrastructure.Worker");
            Directory.CreateDirectory(Path.Combine(
                infrastructureDirectory,
                "Yeshua.Clinica.CQRS.Infrastructure.Shared"));

            var generator = new CSharpCQRS("Clinica", solutionDirectory);
            generator.AppInfrastructureGenerateRuntimeIdentity();
            generator.AppInfrastructureGenerateRuntimeIdentity();

            var providerPath = Path.Combine(
                infrastructureDirectory,
                "Yeshua.Clinica.CQRS.Infrastructure.Shared",
                "Operational",
                "Migration",
                "RuntimeIdentityProvider.cs");
            var reporterPath = Path.Combine(
                infrastructureDirectory,
                "Yeshua.Clinica.CQRS.Infrastructure.Worker",
                "Migration",
                "Operational",
                "RuntimeIdentityReporter.cs");

            Assert.IsTrue(File.Exists(providerPath));
            Assert.IsTrue(File.Exists(reporterPath));
            StringAssert.Contains(File.ReadAllText(providerPath), "artifact: GENERATED_REGENERABLE");
            StringAssert.Contains(File.ReadAllText(providerPath), "class RuntimeIdentityProvider");
            StringAssert.Contains(File.ReadAllText(reporterPath), "class RuntimeIdentityReporter");

            AssertBuildMetadata(apiProject);
            AssertBuildMetadata(workerProject);
        }
        finally
        {
            if (Directory.Exists(solutionDirectory))
                Directory.Delete(solutionDirectory, true);
        }
    }

    private static string CreateProject(string infrastructureDirectory, string projectName)
    {
        var projectDirectory = Path.Combine(infrastructureDirectory, projectName);
        Directory.CreateDirectory(projectDirectory);
        var projectPath = Path.Combine(projectDirectory, $"{projectName}.csproj");
        File.WriteAllText(
            projectPath,
            "<Project Sdk=\"Microsoft.NET.Sdk.Web\"><PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup></Project>");
        return projectPath;
    }

    private static void AssertBuildMetadata(string projectPath)
    {
        var project = File.ReadAllText(projectPath);
        Assert.AreEqual(1, Count(project, "Include=\"Yeshua.Application\""));
        Assert.AreEqual(1, Count(project, "Include=\"Yeshua.Version\""));
        Assert.AreEqual(1, Count(project, "Include=\"Yeshua.CommitSha\""));
        Assert.AreEqual(1, Count(project, "Include=\"Yeshua.BuildTimestampUtc\""));
        StringAssert.Contains(project, "Value=\"Clinica\"");
    }

    private static int Count(string source, string value)
    {
        return source.Split(value, StringSplitOptions.None).Length - 1;
    }
}
