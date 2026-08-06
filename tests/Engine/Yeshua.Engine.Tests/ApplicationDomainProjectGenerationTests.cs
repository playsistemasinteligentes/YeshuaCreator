using Dominio.Migration;
using Dominio.Schemas.CQRS;

namespace TestMigration;

[TestClass]
public class ApplicationDomainProjectGenerationTests
{
    [TestMethod]
    public void AppSolutionGenerateCreatesApplicationDomainProject()
    {
        var solutionDirectory = Path.Combine(
            Path.GetTempPath(),
            "Yeshua.Engine.Tests",
            Guid.NewGuid().ToString("N"));

        try
        {
            var sharedProjectDirectory = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Domain",
                "Yeshua.CQRS.Domain");
            Directory.CreateDirectory(sharedProjectDirectory);

            File.WriteAllText(
                Path.Combine(sharedProjectDirectory, "Yeshua.CQRS.Domain.csproj"),
                "<Project Sdk=\"Microsoft.NET.Sdk\"><PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup></Project>");
            File.WriteAllText(
                Path.Combine(solutionDirectory, "YeshuaCreator.sln"),
                "Microsoft Visual Studio Solution File, Format Version 12.00\r\n" +
                "# Visual Studio Version 17\r\n" +
                "VisualStudioVersion = 17.0.31903.59\r\n" +
                "MinimumVisualStudioVersion = 10.0.40219.1\r\n" +
                "Global\r\nEndGlobal\r\n");

            var generator = new CSharpCQRS("Fiscal.MDFe", solutionDirectory);
            generator.AppSolutionGenerate(null!);

            var migration = new ApplicationMigration();
            migration.Up();
            generator.AppDominioGenerateDominioEntitys(migration);

            var applicationProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Domain",
                "Yeshua.Fiscal.MDFe.CQRS.Domain",
                "Yeshua.Fiscal.MDFe.CQRS.Domain.csproj");

            Assert.IsTrue(File.Exists(applicationProjectPath));
            Assert.IsTrue(File.Exists(Path.Combine(
                Path.GetDirectoryName(applicationProjectPath)!,
                "Entitys",
                "Migration",
                "MDFe",
                "MDFeEntity.cs")));
            Assert.IsFalse(File.Exists(Path.Combine(
                sharedProjectDirectory,
                "Entitys",
                "Migration",
                "MDFe",
                "MDFeEntity.cs")));
            var applicationProjectContent = File.ReadAllText(applicationProjectPath);
            StringAssert.Contains(
                applicationProjectContent,
                @"..\Yeshua.CQRS.Domain\Yeshua.CQRS.Domain.csproj");

            var solutionPath = Path.Combine(solutionDirectory, "YeshuaCreator.sln");
            const string relativeApplicationProjectPath =
                @"src\CQRS\Domain\Yeshua.Fiscal.MDFe.CQRS.Domain\Yeshua.Fiscal.MDFe.CQRS.Domain.csproj";
            var solutionContent = File.ReadAllText(solutionPath);
            StringAssert.Contains(solutionContent, relativeApplicationProjectPath);

            generator.AppSolutionGenerate(null!);

            Assert.AreEqual(applicationProjectContent, File.ReadAllText(applicationProjectPath));
            Assert.AreEqual(
                solutionContent,
                File.ReadAllText(solutionPath),
                "A segunda execucao nao deve alterar novamente o projeto ou a solucao.");
        }
        finally
        {
            if (Directory.Exists(solutionDirectory))
                Directory.Delete(solutionDirectory, true);
        }
    }

    private sealed class ApplicationMigration : MigrationBase
    {
        public override void Up()
        {
            AddEntity("MDFe");
        }
    }
}
