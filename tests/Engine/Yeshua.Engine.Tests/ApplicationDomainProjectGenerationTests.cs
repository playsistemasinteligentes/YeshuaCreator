using Dominio.Migration;
using Dominio.Schemas.CQRS;
using Dominio.Deployment;
using Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;

namespace TestMigration;

[TestClass]
public class ApplicationDomainProjectGenerationTests
{
    [TestMethod]
    public void DependencInjectionGeneratesSagaRegistryOnlyWhenDslContainsSaga()
    {
        var directory = Path.Combine(Path.GetTempPath(), "Yeshua.Engine.Tests", Guid.NewGuid().ToString("N"));

        try
        {
            var migrationWithoutSaga = new ApplicationWithoutSagaMigration();
            migrationWithoutSaga.Up();
            var withoutSagaPath = Path.Combine(directory, "WithoutSaga.cs");
            new SourceCodeInfraestructureDependencInjectionInjectionMigration(
                    migrationWithoutSaga,
                    InfraEstrutctureType.API)
                .WriteCode(null, withoutSagaPath, Path.Combine(directory, "WithoutSagaCuston.cs"));

            var withoutSagaContent = File.ReadAllText(withoutSagaPath);
            Assert.IsFalse(withoutSagaContent.Contains("Command.Receivers.Migration.Saga"));
            Assert.IsFalse(withoutSagaContent.Contains("ISagaResolverRegistry"));

            var migrationWithSaga = new ApplicationMigration();
            migrationWithSaga.Up();
            var withSagaPath = Path.Combine(directory, "WithSaga.cs");
            new SourceCodeInfraestructureDependencInjectionInjectionMigration(
                    migrationWithSaga,
                    InfraEstrutctureType.API)
                .WriteCode(null, withSagaPath, Path.Combine(directory, "WithSagaCuston.cs"));

            var withSagaContent = File.ReadAllText(withSagaPath);
            StringAssert.Contains(withSagaContent, "using Command.Receivers.Migration.Saga;");
            StringAssert.Contains(
                withSagaContent,
                "builder.Services.AddTransient<ISagaResolverRegistry, SagaResolverRegistry>();");
        }
        finally
        {
            if (Directory.Exists(directory))
                Directory.Delete(directory, true);
        }
    }

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

            var sharedCommandProjectDirectory = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Application",
                "Yeshua.CQRS.Application.Command");
            Directory.CreateDirectory(sharedCommandProjectDirectory);
            File.WriteAllText(
                Path.Combine(sharedCommandProjectDirectory, "Yeshua.CQRS.Application.Command.csproj"),
                "<Project Sdk=\"Microsoft.NET.Sdk\"><PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup></Project>");

            var sharedRepositoryInterfacesProjectDirectory = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Application",
                "Yeshua.CQRS.Application.RepositoryInterfaces");
            Directory.CreateDirectory(sharedRepositoryInterfacesProjectDirectory);
            File.WriteAllText(
                Path.Combine(
                    sharedRepositoryInterfacesProjectDirectory,
                    "Yeshua.CQRS.Application.RepositoryInterfaces.csproj"),
                "<Project Sdk=\"Microsoft.NET.Sdk\"><PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup></Project>");

            var sharedInfrastructureProjectDirectory = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.CQRS.Infrastructure.Shared");
            Directory.CreateDirectory(sharedInfrastructureProjectDirectory);
            File.WriteAllText(
                Path.Combine(
                    sharedInfrastructureProjectDirectory,
                    "Yeshua.CQRS.Infrastructure.Shared.csproj"),
                "<Project Sdk=\"Microsoft.NET.Sdk\"><PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup></Project>");

            var sharedFrontProjectDirectory = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.CQRS.Infrastructure.Front");
            Directory.CreateDirectory(Path.Combine(sharedFrontProjectDirectory, "wwwroot", "spa"));
            File.WriteAllText(
                Path.Combine(sharedFrontProjectDirectory, "Yeshua.CQRS.Infrastructure.Front.csproj"),
                "<Project Sdk=\"Microsoft.NET.Sdk.Web\"><PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup></Project>");
            var sharedFrontIndexPath = Path.Combine(
                sharedFrontProjectDirectory,
                "wwwroot",
                "spa",
                "index.html");
            File.WriteAllText(sharedFrontIndexPath, "front-v1");
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
            generator.AppAplicationGenerateCommandReceivers(migration);
            generator.AppAplicationGenerateCommandCommands(migration);
            generator.AppAplicationGenerateRepositoryInterfacesRead(migration);
            generator.AppAplicationGenerateRepositoryInterfacesWrite(migration);
            generator.AppInfraestructureGenerateReadConcreteRepository(migration);
            generator.AppInfraestructureGenerateReadConcreteQuerys(migration);
            generator.AppInfraestructureGenerateWriteConcreteRepository(migration);
            generator.AppInfraestructureGenerateWriteConcreteQuerys(migration);
            generator.AppInfraestructureGenerateAPI(migration);
            generator.AppInfraestructureGenerateWorker(migration);
            generator.ModulesGenerate(migration);

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

            var applicationRepositoryInterfacesProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Application",
                "Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces",
                "Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces.csproj");
            Assert.IsTrue(File.Exists(applicationRepositoryInterfacesProjectPath));
            Assert.IsTrue(File.Exists(Path.Combine(
                Path.GetDirectoryName(applicationRepositoryInterfacesProjectPath)!,
                "Read",
                "Repository",
                "Migration",
                "MDFe",
                "IMDFeRepositoryInterfacesRead.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                Path.GetDirectoryName(applicationRepositoryInterfacesProjectPath)!,
                "Write",
                "Repository",
                "Migration",
                "MDFe",
                "IMDFeWriteRepository.cs")));
            Assert.IsFalse(File.Exists(Path.Combine(
                sharedRepositoryInterfacesProjectDirectory,
                "Read",
                "Repository",
                "Migration",
                "MDFe",
                "IMDFeRepositoryInterfacesRead.cs")));

            var applicationRepositoryInterfacesProjectContent = File.ReadAllText(
                applicationRepositoryInterfacesProjectPath);
            StringAssert.Contains(
                applicationRepositoryInterfacesProjectContent,
                @"..\Yeshua.CQRS.Application.RepositoryInterfaces\Yeshua.CQRS.Application.RepositoryInterfaces.csproj");
            StringAssert.Contains(
                applicationRepositoryInterfacesProjectContent,
                @"..\..\Domain\Yeshua.Fiscal.MDFe.CQRS.Domain\Yeshua.Fiscal.MDFe.CQRS.Domain.csproj");

            var applicationCommandProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Application",
                "Yeshua.Fiscal.MDFe.CQRS.Application.Command",
                "Yeshua.Fiscal.MDFe.CQRS.Application.Command.csproj");
            Assert.IsTrue(File.Exists(applicationCommandProjectPath));
            Assert.IsTrue(File.Exists(Path.Combine(
                Path.GetDirectoryName(applicationCommandProjectPath)!,
                "Commands",
                "Migration",
                "Crud",
                "MDFe",
                "MDFeCommands.cs")));
            Assert.IsFalse(File.Exists(Path.Combine(
                sharedCommandProjectDirectory,
                "Commands",
                "Migration",
                "Crud",
                "MDFe",
                "MDFeCommands.cs")));
            var sagaWorkerPath = Path.Combine(
                Path.GetDirectoryName(applicationCommandProjectPath)!,
                "Patterns",
                "Migration",
                "Saga",
                "SagaWorkerCommandHandler.cs");
            var sagaInboxWorkerPath = Path.Combine(
                Path.GetDirectoryName(applicationCommandProjectPath)!,
                "Patterns",
                "Migration",
                "Saga",
                "SagaInboxWorkerCommandHandler.cs");
            Assert.IsTrue(File.Exists(sagaWorkerPath));
            Assert.IsTrue(File.Exists(sagaInboxWorkerPath));
            StringAssert.Contains(
                File.ReadAllText(sagaWorkerPath),
                "private readonly SagaResolverRegistry _registry;");

            var applicationCommandProjectContent = File.ReadAllText(applicationCommandProjectPath);
            StringAssert.Contains(
                applicationCommandProjectContent,
                @"..\Yeshua.CQRS.Application.Command\Yeshua.CQRS.Application.Command.csproj");
            StringAssert.Contains(
                applicationCommandProjectContent,
                @"..\..\Domain\Yeshua.Fiscal.MDFe.CQRS.Domain\Yeshua.Fiscal.MDFe.CQRS.Domain.csproj");
            StringAssert.Contains(
                applicationCommandProjectContent,
                @"..\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces.csproj");

            var applicationInfrastructureRepositoryReadProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead.csproj");
            Assert.IsTrue(File.Exists(applicationInfrastructureRepositoryReadProjectPath));
            var applicationInfrastructureRepositoryReadDirectory =
                Path.GetDirectoryName(applicationInfrastructureRepositoryReadProjectPath)!;
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureRepositoryReadDirectory,
                "ConcreteRepository",
                "Migration",
                "MDFe",
                "MDFeReadRepository.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureRepositoryReadDirectory,
                "ConcreteQuerys",
                "Migration",
                "MDFe",
                "MDFeReadQuerys.cs")));
            Assert.IsFalse(File.Exists(Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.CQRS.Infrastructure.RepositoryRead",
                "ConcreteRepository",
                "Migration",
                "MDFe",
                "MDFeReadRepository.cs")));
            var applicationInfrastructureRepositoryReadProjectContent = File.ReadAllText(
                applicationInfrastructureRepositoryReadProjectPath);
            StringAssert.Contains(
                applicationInfrastructureRepositoryReadProjectContent,
                @"..\Yeshua.CQRS.Infrastructure.Shared\Yeshua.CQRS.Infrastructure.Shared.csproj");
            StringAssert.Contains(
                applicationInfrastructureRepositoryReadProjectContent,
                @"..\..\Application\Yeshua.Fiscal.MDFe.CQRS.Application.Command\Yeshua.Fiscal.MDFe.CQRS.Application.Command.csproj");
            StringAssert.Contains(
                applicationInfrastructureRepositoryReadProjectContent,
                @"..\..\Application\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces.csproj");
            Assert.IsFalse(
                applicationInfrastructureRepositoryReadProjectContent.Contains(
                    @"..\Yeshua.CQRS.Infrastructure.RepositoryRead\Yeshua.CQRS.Infrastructure.RepositoryRead.csproj"),
                "O RepositoryRead do aplicativo nao deve depender do projeto legado compartilhado.");

            var applicationInfrastructureRepositoryWriteProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite.csproj");
            Assert.IsTrue(File.Exists(applicationInfrastructureRepositoryWriteProjectPath));
            var applicationInfrastructureRepositoryWriteDirectory =
                Path.GetDirectoryName(applicationInfrastructureRepositoryWriteProjectPath)!;
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureRepositoryWriteDirectory,
                "ConcreteRepository",
                "Migration",
                "MDFe",
                "MDFeWriteRepository.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureRepositoryWriteDirectory,
                "ConcreteQuerys",
                "Migration",
                "MDFe",
                "MDFeWriteQuerys.cs")));
            Assert.IsFalse(File.Exists(Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.CQRS.Infrastructure.RepositoryWrite",
                "ConcreteRepository",
                "Migration",
                "MDFe",
                "MDFeWriteRepository.cs")));
            var applicationInfrastructureRepositoryWriteProjectContent = File.ReadAllText(
                applicationInfrastructureRepositoryWriteProjectPath);
            StringAssert.Contains(
                applicationInfrastructureRepositoryWriteProjectContent,
                @"..\Yeshua.CQRS.Infrastructure.Shared\Yeshua.CQRS.Infrastructure.Shared.csproj");
            StringAssert.Contains(
                applicationInfrastructureRepositoryWriteProjectContent,
                @"..\..\Application\Yeshua.Fiscal.MDFe.CQRS.Application.Command\Yeshua.Fiscal.MDFe.CQRS.Application.Command.csproj");
            StringAssert.Contains(
                applicationInfrastructureRepositoryWriteProjectContent,
                @"..\..\Application\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces.csproj");
            Assert.IsFalse(
                applicationInfrastructureRepositoryWriteProjectContent.Contains(
                    "Infrastructure.RepositoryRead",
                    StringComparison.OrdinalIgnoreCase),
                "O RepositoryWrite do aplicativo nao deve depender de RepositoryRead.");

            var applicationInfrastructureSharedProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared.csproj");
            Assert.IsTrue(File.Exists(applicationInfrastructureSharedProjectPath));
            var applicationInfrastructureSharedProjectContent = File.ReadAllText(
                applicationInfrastructureSharedProjectPath);
            StringAssert.Contains(
                applicationInfrastructureSharedProjectContent,
                @"..\Yeshua.CQRS.Infrastructure.Shared\Yeshua.CQRS.Infrastructure.Shared.csproj");
            StringAssert.Contains(
                applicationInfrastructureSharedProjectContent,
                @"..\..\Domain\Yeshua.Fiscal.MDFe.CQRS.Domain\Yeshua.Fiscal.MDFe.CQRS.Domain.csproj");
            StringAssert.Contains(
                applicationInfrastructureSharedProjectContent,
                @"..\..\Application\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces.csproj");
            Assert.IsTrue(File.Exists(Path.Combine(
                Path.GetDirectoryName(applicationInfrastructureSharedProjectPath)!,
                "Patterns",
                "Strategy",
                "Migration",
                "ITestNotification",
                "EmailNotification.cs")));
            Assert.IsFalse(File.Exists(Path.Combine(
                sharedInfrastructureProjectDirectory,
                "Patterns",
                "Strategy",
                "Migration",
                "ITestNotification",
                "EmailNotification.cs")));

            var applicationInfrastructureApiProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.csproj");
            Assert.IsTrue(File.Exists(applicationInfrastructureApiProjectPath));
            var applicationInfrastructureApiDirectory =
                Path.GetDirectoryName(applicationInfrastructureApiProjectPath)!;
            Assert.IsTrue(File.Exists(Path.Combine(applicationInfrastructureApiDirectory, "Program.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(applicationInfrastructureApiDirectory, "StateResults.cs")));
            var applicationInfrastructureApiLaunchSettingsPath = Path.Combine(
                applicationInfrastructureApiDirectory,
                "Properties",
                "launchSettings.json");
            Assert.IsTrue(File.Exists(applicationInfrastructureApiLaunchSettingsPath));
            StringAssert.Contains(
                File.ReadAllText(applicationInfrastructureApiLaunchSettingsPath),
                "\"launchUrl\": \"swagger\"");
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureApiDirectory,
                "Services",
                "CurrentUserHttp.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureApiDirectory,
                "Migration",
                "EndPoints.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureApiDirectory,
                "Migration",
                "DependencInjection.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureApiDirectory,
                "Migration",
                "Modules.cs")));
            Assert.IsFalse(File.Exists(Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.CQRS.Infrastructure.Api",
                "Migration",
                "EndPoints.cs")));

            var applicationInfrastructureApiProjectContent =
                File.ReadAllText(applicationInfrastructureApiProjectPath);
            StringAssert.Contains(
                applicationInfrastructureApiProjectContent,
                @"..\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared.csproj");
            StringAssert.Contains(
                applicationInfrastructureApiProjectContent,
                @"..\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead.csproj");
            StringAssert.Contains(
                applicationInfrastructureApiProjectContent,
                @"..\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite.csproj");
            StringAssert.Contains(
                applicationInfrastructureApiProjectContent,
                @"..\..\Domain\Yeshua.Fiscal.MDFe.CQRS.Domain\Yeshua.Fiscal.MDFe.CQRS.Domain.csproj");
            Assert.IsFalse(
                applicationInfrastructureApiProjectContent.Contains("Yeshua.Engine", StringComparison.OrdinalIgnoreCase),
                "A API do aplicativo nao deve depender da Engine em tempo de execucao.");

            var applicationInfrastructureWorkerProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Worker",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Worker.csproj");
            Assert.IsTrue(File.Exists(applicationInfrastructureWorkerProjectPath));
            var applicationInfrastructureWorkerDirectory =
                Path.GetDirectoryName(applicationInfrastructureWorkerProjectPath)!;
            Assert.IsTrue(File.Exists(Path.Combine(applicationInfrastructureWorkerDirectory, "Program.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureWorkerDirectory,
                "Migration",
                "WorkerInfrastructure.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureWorkerDirectory,
                "Migration",
                "DependencInjection.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(
                applicationInfrastructureWorkerDirectory,
                "Migration",
                "WorkersBuilder.cs")));
            Assert.IsFalse(File.Exists(Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.CQRS.Infrastructure.Worker",
                "Migration",
                "WorkersBuilder.cs")));

            var applicationInfrastructureWorkerProjectContent =
                File.ReadAllText(applicationInfrastructureWorkerProjectPath);
            StringAssert.Contains(
                applicationInfrastructureWorkerProjectContent,
                @"..\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared.csproj");
            StringAssert.Contains(
                applicationInfrastructureWorkerProjectContent,
                @"..\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead.csproj");
            StringAssert.Contains(
                applicationInfrastructureWorkerProjectContent,
                @"..\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite.csproj");
            Assert.IsFalse(
                applicationInfrastructureWorkerProjectContent.Contains("Yeshua.Engine", StringComparison.OrdinalIgnoreCase),
                "O Worker do aplicativo nao deve depender da Engine em tempo de execucao.");

            var applicationInfrastructureFrontProjectPath = Path.Combine(
                solutionDirectory,
                "src",
                "CQRS",
                "Infrastructure",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Front",
                "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Front.csproj");
            Assert.IsTrue(File.Exists(applicationInfrastructureFrontProjectPath));
            var applicationInfrastructureFrontDirectory =
                Path.GetDirectoryName(applicationInfrastructureFrontProjectPath)!;
            var applicationInfrastructureFrontIndexPath = Path.Combine(
                applicationInfrastructureFrontDirectory,
                "wwwroot",
                "spa",
                "index.html");
            Assert.AreEqual("front-v1", File.ReadAllText(applicationInfrastructureFrontIndexPath));
            var applicationInfrastructureFrontCustomPath = Path.Combine(
                applicationInfrastructureFrontDirectory,
                "wwwroot",
                "Custon",
                "extensions.js");
            Assert.IsTrue(File.Exists(applicationInfrastructureFrontCustomPath));
            var applicationInfrastructureFrontProjectContent = File.ReadAllText(
                applicationInfrastructureFrontProjectPath);
            Assert.IsFalse(
                applicationInfrastructureFrontProjectContent.Contains(
                    "ProjectReference",
                    StringComparison.OrdinalIgnoreCase),
                "O Front do aplicativo deve ser publicavel sem dependencia de runtime para a matriz.");

            var solutionPath = Path.Combine(solutionDirectory, "YeshuaCreator.sln");
            const string relativeApplicationProjectPath =
                @"src\CQRS\Domain\Yeshua.Fiscal.MDFe.CQRS.Domain\Yeshua.Fiscal.MDFe.CQRS.Domain.csproj";
            var solutionContent = File.ReadAllText(solutionPath);
            StringAssert.Contains(solutionContent, relativeApplicationProjectPath);
            const string relativeApplicationCommandProjectPath =
                @"src\CQRS\Application\Yeshua.Fiscal.MDFe.CQRS.Application.Command\Yeshua.Fiscal.MDFe.CQRS.Application.Command.csproj";
            StringAssert.Contains(solutionContent, relativeApplicationCommandProjectPath);
            const string relativeApplicationRepositoryInterfacesProjectPath =
                @"src\CQRS\Application\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces\Yeshua.Fiscal.MDFe.CQRS.Application.RepositoryInterfaces.csproj";
            StringAssert.Contains(solutionContent, relativeApplicationRepositoryInterfacesProjectPath);
            const string relativeApplicationInfrastructureRepositoryReadProjectPath =
                @"src\CQRS\Infrastructure\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryRead.csproj";
            StringAssert.Contains(solutionContent, relativeApplicationInfrastructureRepositoryReadProjectPath);
            const string relativeApplicationInfrastructureRepositoryWriteProjectPath =
                @"src\CQRS\Infrastructure\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.RepositoryWrite.csproj";
            StringAssert.Contains(solutionContent, relativeApplicationInfrastructureRepositoryWriteProjectPath);
            const string relativeApplicationInfrastructureSharedProjectPath =
                @"src\CQRS\Infrastructure\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Shared.csproj";
            StringAssert.Contains(solutionContent, relativeApplicationInfrastructureSharedProjectPath);
            const string relativeApplicationInfrastructureApiProjectPath =
                @"src\CQRS\Infrastructure\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.csproj";
            StringAssert.Contains(solutionContent, relativeApplicationInfrastructureApiProjectPath);
            const string relativeApplicationInfrastructureWorkerProjectPath =
                @"src\CQRS\Infrastructure\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Worker\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Worker.csproj";
            StringAssert.Contains(solutionContent, relativeApplicationInfrastructureWorkerProjectPath);
            const string relativeApplicationInfrastructureFrontProjectPath =
                @"src\CQRS\Infrastructure\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Front\Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Front.csproj";
            StringAssert.Contains(solutionContent, relativeApplicationInfrastructureFrontProjectPath);
            StringAssert.Contains(
                solutionContent,
                @") = ""Yeshua.CQRS.Application"", ""Yeshua.CQRS.Application"",");
            Assert.IsFalse(
                solutionContent.Contains(
                    @") = ""Yeshua.CQRS.Application.Command"", ""Yeshua.CQRS.Application.Command"","),
                "O projeto Command do aplicativo nao deve criar uma nova pasta de solucao.");

            File.WriteAllText(applicationInfrastructureFrontCustomPath, "custom-preserved");
            File.WriteAllText(sharedFrontIndexPath, "front-v2");
            generator.AppSolutionGenerate(null!);

            Assert.AreEqual(applicationProjectContent, File.ReadAllText(applicationProjectPath));
            Assert.AreEqual(applicationCommandProjectContent, File.ReadAllText(applicationCommandProjectPath));
            Assert.AreEqual(
                applicationRepositoryInterfacesProjectContent,
                File.ReadAllText(applicationRepositoryInterfacesProjectPath));
            Assert.AreEqual(
                applicationInfrastructureRepositoryReadProjectContent,
                File.ReadAllText(applicationInfrastructureRepositoryReadProjectPath));
            Assert.AreEqual(
                applicationInfrastructureRepositoryWriteProjectContent,
                File.ReadAllText(applicationInfrastructureRepositoryWriteProjectPath));
            Assert.AreEqual(
                applicationInfrastructureSharedProjectContent,
                File.ReadAllText(applicationInfrastructureSharedProjectPath));
            Assert.AreEqual(
                applicationInfrastructureApiProjectContent,
                File.ReadAllText(applicationInfrastructureApiProjectPath));
            Assert.AreEqual(
                applicationInfrastructureWorkerProjectContent,
                File.ReadAllText(applicationInfrastructureWorkerProjectPath));
            Assert.AreEqual(
                applicationInfrastructureFrontProjectContent,
                File.ReadAllText(applicationInfrastructureFrontProjectPath));
            Assert.AreEqual("front-v2", File.ReadAllText(applicationInfrastructureFrontIndexPath));
            Assert.AreEqual("custom-preserved", File.ReadAllText(applicationInfrastructureFrontCustomPath));
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

    [TestMethod]
    public void AppStudioGenerateEntityDictionaryCreatesDictionaryInsideConfiguredStudio()
    {
        var solutionDirectory = Path.Combine(
            Path.GetTempPath(),
            "Yeshua.Engine.Tests",
            Guid.NewGuid().ToString("N"));
        const string studioProjectName = "Yeshua.Studio.Fiscal.MDFe";
        var studioProjectDirectory = Path.Combine(
            solutionDirectory,
            "src",
            "Studio",
            studioProjectName);

        try
        {
            Directory.CreateDirectory(studioProjectDirectory);
            File.WriteAllText(
                Path.Combine(studioProjectDirectory, $"{studioProjectName}.csproj"),
                "<Project Sdk=\"Microsoft.NET.Sdk\" />");

            var migration = new ApplicationMigration();
            migration.Up();
            var generator = new CSharpCQRS(
                "Fiscal.MDFe",
                solutionDirectory,
                studioProjectName);

            generator.AppStudioGenerateEntityDictionary(migration);

            var dictionaryPath = Path.Combine(
                studioProjectDirectory,
                "Dominio",
                "ORM",
                "entities.cs");
            Assert.IsTrue(File.Exists(dictionaryPath));
            var dictionaryContent = File.ReadAllText(dictionaryPath);
            StringAssert.Contains(
                dictionaryContent,
                "namespace Yeshua.Studio.Fiscal.MDFe.Domain.Entities");
            StringAssert.Contains(dictionaryContent, "public class MDFe");
            StringAssert.Contains(
                dictionaryContent,
                "//Dominio.Schemas.CQRS.SourceCodeEntityInternalMigration");
        }
        finally
        {
            if (Directory.Exists(solutionDirectory))
                Directory.Delete(solutionDirectory, true);
        }
    }

    [TestMethod]
    public void DeploymentSchemaRepresentsOperationalRequirementsWithoutSecretValues()
    {
        var solutionDirectory = CreateDeploymentProjects("Fiscal.MDFe", "Yeshua.Studio.Fiscal.MDFe");

        try
        {
            var migration = new ApplicationWithoutSagaMigration();
            migration.Up();
            var schema = new DeploymentSchema("Fiscal.MDFe", solutionDirectory)
                .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
                    .IdentifiedBy("sql01")
                    .Secret("SA_PASSWORD", "sql01-sa-password")
                    .Persistent("sql-data", "/var/opt/mssql"))
                .AddResource("database", DeploymentResourceKind.DatabaseCatalog, resource => resource
                    .HostedBy("sqlserver")
                    .Configure("Catalog", "MDFE"))
                .AddWorkload("api", workload => workload
                    .FromProject("src/CQRS/Infrastructure/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.csproj")
                    .Requires("database")
                    .Secret("ConnectionStrings__Default", "mdfe-database-connection")
                    .ExposeHttp("http", 7214, "/mdfe/yapi")
                    .TcpHealthCheck("http")
                    .Scale(2)
                    .Resources("250m", "256Mi", "1", "1Gi"))
                .AddWorkload("migration", workload => workload
                    .FromProject(
                        "src/Studio/Yeshua.Studio.Fiscal.MDFe/Yeshua.Studio.Fiscal.MDFe.csproj",
                        DotNetRuntimeKind.Runtime)
                    .Requires("database")
                    .RunOnce());

            var model = schema.CreateModel(migration);

            var server = model.Resources.Single(resource => resource.Name == "sqlserver");
            Assert.AreEqual(DeploymentResourceKind.DatabaseServer, server.Kind);
            Assert.AreEqual("sql01", server.Identity);
            Assert.AreEqual("sql01-sa-password", server.Secrets.Single().Secret);
            Assert.AreEqual("/var/opt/mssql", server.Persistence.Single().MountPath);
            var catalog = model.Resources.Single(resource => resource.Name == "database");
            Assert.AreEqual(DeploymentResourceKind.DatabaseCatalog, catalog.Kind);
            Assert.AreEqual("fiscal-mdfe-database", catalog.Identity);
            Assert.AreEqual("sqlserver", catalog.Parent);
            Assert.AreEqual("MDFE", catalog.Configuration["Catalog"]);

            var api = model.Workloads.Single(workload => workload.Name == "api");
            Assert.AreEqual("fiscal-mdfe-api", api.Identity);
            Assert.AreEqual(DeploymentWorkloadSourceKind.Project, api.Source.Kind);
            Assert.AreEqual(DeploymentWorkloadMode.Service, api.Mode);
            Assert.AreEqual(2, api.Replicas);
            Assert.AreEqual("mdfe-database-connection", api.Secrets.Single().Secret);
            Assert.AreEqual(7214, api.Ports.Single().ContainerPort);
            Assert.AreEqual("/mdfe/yapi", api.Ports.Single().Route);
            Assert.AreEqual(DeploymentHealthCheckKind.Tcp, api.HealthCheck!.Kind);
            Assert.AreEqual("1Gi", api.Compute!.MemoryLimit);

            var migrationWorkload = model.Workloads.Single(workload => workload.Name == "migration");
            Assert.AreEqual(DeploymentWorkloadMode.Job, migrationWorkload.Mode);
            Assert.AreEqual(1, migrationWorkload.Replicas);

            schema.CodeGenaration(migration);
            var apiDockerfile = Path.Combine(
                solutionDirectory,
                "infra",
                "Fiscal.MDFe",
                "Migration",
                "workloads",
                "api",
                "Dockerfile");
            Assert.IsTrue(File.Exists(apiDockerfile));
            var dockerfileContent = File.ReadAllText(apiDockerfile);
            StringAssert.Contains(dockerfileContent, "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.csproj");
            StringAssert.Contains(dockerfileContent, "Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.dll");
        }
        finally
        {
            Directory.Delete(solutionDirectory, true);
        }
    }

    [TestMethod]
    public void DeploymentSchemaTreatsCustomAndGeneratedProcessesAsWorkloads()
    {
        var solutionDirectory = CreateDeploymentProjects("Clinica", "Yeshua.Studio.AppClinicas");

        try
        {
            var customContext = Path.Combine(solutionDirectory, "infra", "Clinica", "Custon", "ai-worker");
            Directory.CreateDirectory(customContext);
            File.WriteAllText(Path.Combine(customContext, "requirements.txt"), "celery==5.3.6");
            Directory.CreateDirectory(Path.Combine(customContext, "app"));

            var migration = new ApplicationWithQueueMigration();
            migration.Up();
            var schema = new DeploymentSchema("Clinica", solutionDirectory)
                .AddResource("rabbitmq", DeploymentResourceKind.MessageBroker, resource => resource
                    .IdentifiedBy("rabbit01"))
                .AddWorkload("worker", workload => workload
                    .FromProject("src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Worker/Yeshua.Clinica.CQRS.Infrastructure.Worker.csproj")
                    .Requires("rabbitmq"))
                .AddWorkload("ai-worker", workload => workload
                    .FromBuildContext("infra/Clinica/Custon/ai-worker")
                    .ScaffoldDockerfile(DockerfileTemplate.PythonWorker(template => template
                        .InstallSystemPackages("ffmpeg")
                        .Command("celery", "-A", "app.celery_app", "worker")))
                    .Requires("rabbitmq")
                    .Consumes("audio.transcribe.outbox")
                    .Produces("audio.transcribed.inbox"));

            var model = schema.CreateModel(migration);

            var generated = model.Workloads.Single(workload => workload.Name == "worker");
            var custom = model.Workloads.Single(workload => workload.Name == "ai-worker");
            Assert.AreEqual(DeploymentWorkloadSourceKind.Project, generated.Source.Kind);
            Assert.AreEqual(DeploymentWorkloadSourceKind.BuildContext, custom.Source.Kind);
            CollectionAssert.Contains(custom.Requires, "rabbitmq");
            CollectionAssert.Contains(custom.Consumes, "audio.transcribe.outbox");
            CollectionAssert.Contains(custom.Produces, "audio.transcribed.inbox");

            schema.CodeGenaration(migration);
            var customDockerfile = Path.Combine(customContext, "Dockerfile");
            Assert.IsTrue(File.Exists(customDockerfile));
            StringAssert.Contains(File.ReadAllText(customDockerfile), "yeshua-template: python-worker/v1");

            File.WriteAllText(customDockerfile, "# customizado pelo desenvolvedor");
            schema.CodeGenaration(migration);
            Assert.AreEqual("# customizado pelo desenvolvedor", File.ReadAllText(customDockerfile));
        }
        finally
        {
            Directory.Delete(solutionDirectory, true);
        }
    }

    [TestMethod]
    public void DeploymentSchemaUsesTheSameLogicalResourceIdentityAcrossApplications()
    {
        var solutionDirectory = CreateDeploymentProjects("Fiscal.MDFe", "Yeshua.Studio.Fiscal.MDFe");

        try
        {
            var migration = new ApplicationWithoutSagaMigration();
            migration.Up();

            var mdfe = new DeploymentSchema("Fiscal.MDFe", solutionDirectory)
                .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
                    .IdentifiedBy("sql01"))
                .CreateModel(migration);
            var clinica = new DeploymentSchema("Clinica", solutionDirectory)
                .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
                    .IdentifiedBy("sql01"))
                .CreateModel(migration);

            Assert.AreEqual("sql01", mdfe.Resources.Single().Identity);
            Assert.AreEqual("sql01", clinica.Resources.Single().Identity);
        }
        finally
        {
            Directory.Delete(solutionDirectory, true);
        }
    }

    [TestMethod]
    public void DeploymentEnvironmentAggregatesSharedResourcesAndGeneratesIndependentDeploys()
    {
        var solutionDirectory = CreateDeploymentProjects("Clinica", "Yeshua.Studio.AppClinicas");

        try
        {
            CreateProject(
                solutionDirectory,
                "src/CQRS/Infrastructure/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.csproj");
            var migration = new ApplicationWithoutSagaMigration();
            migration.Up();

            new DeploymentSchema("Clinica", solutionDirectory)
                .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
                    .IdentifiedBy("sql01")
                    .Configure("Engine", "SqlServer")
                    .Secret("MSSQL_SA_PASSWORD", "sql01-sa-password")
                    .Persistent("sql-data", "/var/opt/mssql"))
                .AddResource("database", DeploymentResourceKind.DatabaseCatalog, resource => resource
                    .HostedBy("sqlserver")
                    .Configure("Catalog", "CLINICA"))
                .AddWorkload("api", workload => workload
                    .FromProject("src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api/Yeshua.Clinica.CQRS.Infrastructure.Api.csproj")
                    .Requires("database")
                    .Secret("ConnectionStrings__Default", "clinica-database-connection")
                    .ExposeHttp("http", 7214, "/yapi"))
                .CodeGenaration(migration);

            new DeploymentSchema("Fiscal.MDFe", solutionDirectory)
                .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
                    .IdentifiedBy("sql01")
                    .Configure("Engine", "SqlServer")
                    .Secret("MSSQL_SA_PASSWORD", "sql01-sa-password")
                    .Persistent("sql-data", "/var/opt/mssql"))
                .AddResource("database", DeploymentResourceKind.DatabaseCatalog, resource => resource
                    .HostedBy("sqlserver")
                    .Configure("Catalog", "MDFE"))
                .AddWorkload("api", workload => workload
                    .FromProject("src/CQRS/Infrastructure/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.csproj")
                    .Requires("database")
                    .Secret("ConnectionStrings__Default", "mdfe-database-connection")
                    .ExposeHttp("http", 7214, "/mdfe/yapi", "/yapi"))
                .CodeGenaration(migration);

            var model = new DeploymentEnvironmentSchema("Production", solutionDirectory)
                .Domain("example.test")
                .IncludeApplication("Clinica", "Fiscal.MDFe")
                .ProvideResource("sql01", provider => provider
                    .FromImage("mcr.microsoft.com/mssql/server:2022-latest")
                    .BindPersistence("sql-data", "/srv/yeshua/sql"))
                .Generate();

            Assert.AreEqual(1, model.Resources.Count(resource => resource.Identity == "sql01"));
            Assert.AreEqual(2, model.Resources.Count(resource => resource.Kind == DeploymentResourceKind.DatabaseCatalog));
            Assert.AreEqual(2, model.Workloads.Count);

            var output = Path.Combine(solutionDirectory, "infra", "Environments", "Production", "Migration");
            var compose = File.ReadAllText(Path.Combine(output, "docker-compose.yml"));
            StringAssert.Contains(compose, "/srv/yeshua/sql:/var/opt/mssql");
            StringAssert.Contains(compose, "${SQL01_SA_PASSWORD}");
            StringAssert.Contains(compose, "clinica-api:");
            StringAssert.Contains(compose, "fiscal-mdfe-api:");
            Assert.IsFalse(compose.Contains("container_name", StringComparison.OrdinalIgnoreCase));
            Assert.IsFalse(compose.Contains("sql-password-value", StringComparison.Ordinal));

            var nginx = File.ReadAllText(Path.Combine(output, "nginx", "conf.d", "00-http.conf"));
            StringAssert.Contains(nginx, "rewrite ^/mdfe/yapi(?:/(.*))?$ /yapi/$1 break;");

            var clinicaDeploy = File.ReadAllText(Path.Combine(output, "deploy-clinica.sh"));
            var mdfeDeploy = File.ReadAllText(Path.Combine(output, "deploy-fiscal-mdfe.sh"));
            StringAssert.Contains(clinicaDeploy, "clinica-api");
            Assert.IsFalse(clinicaDeploy.Contains("fiscal-mdfe-api", StringComparison.Ordinal));
            StringAssert.Contains(mdfeDeploy, "fiscal-mdfe-api");
            Assert.IsFalse(mdfeDeploy.Contains("clinica-api", StringComparison.Ordinal));
            Assert.IsFalse(clinicaDeploy.Contains("compose down", StringComparison.OrdinalIgnoreCase));
            Assert.IsFalse(mdfeDeploy.Contains("compose down", StringComparison.OrdinalIgnoreCase));
            Assert.IsFalse(clinicaDeploy.Contains('\r'));
            Assert.IsFalse(mdfeDeploy.Contains('\r'));
        }
        finally
        {
            Directory.Delete(solutionDirectory, true);
        }
    }

    [TestMethod]
    public void DeploymentEnvironmentRejectsConflictingSharedResourceDeclarations()
    {
        var solutionDirectory = CreateDeploymentProjects("Clinica", "Yeshua.Studio.AppClinicas");

        try
        {
            var migration = new ApplicationWithoutSagaMigration();
            migration.Up();
            new DeploymentSchema("Clinica", solutionDirectory)
                .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
                    .IdentifiedBy("sql01")
                    .Configure("Engine", "SqlServer"))
                .CodeGenaration(migration);
            new DeploymentSchema("Fiscal.MDFe", solutionDirectory)
                .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
                    .IdentifiedBy("sql01")
                    .Configure("Engine", "PostgreSql"))
                .CodeGenaration(migration);

            var schema = new DeploymentEnvironmentSchema("Production", solutionDirectory)
                .Domain("example.test")
                .IncludeApplication("Clinica", "Fiscal.MDFe")
                .ProvideResource("sql01", provider => provider.FromImage("database:test"));

            var exception = Assert.ThrowsException<InvalidOperationException>(() => schema.CreateModel());
            StringAssert.Contains(exception.Message, "declaracoes incompativeis");
        }
        finally
        {
            Directory.Delete(solutionDirectory, true);
        }
    }

    private static string CreateDeploymentProjects(string application, string studioProjectName)
    {
        var solutionDirectory = Path.Combine(
            Path.GetTempPath(),
            "Yeshua.Engine.Tests",
            Guid.NewGuid().ToString("N"));
        var projectPaths = new[]
        {
            Path.Combine(
                "src",
                "CQRS",
                "Infrastructure",
                $"Yeshua.{application}.CQRS.Infrastructure.Api",
                $"Yeshua.{application}.CQRS.Infrastructure.Api.csproj"),
            Path.Combine(
                "src",
                "CQRS",
                "Infrastructure",
                $"Yeshua.{application}.CQRS.Infrastructure.Front",
                $"Yeshua.{application}.CQRS.Infrastructure.Front.csproj"),
            Path.Combine(
                "src",
                "CQRS",
                "Infrastructure",
                $"Yeshua.{application}.CQRS.Infrastructure.Worker",
                $"Yeshua.{application}.CQRS.Infrastructure.Worker.csproj"),
            Path.Combine("src", "Studio", studioProjectName, $"{studioProjectName}.csproj")
        };

        foreach (var relativePath in projectPaths)
        {
            var path = Path.Combine(solutionDirectory, relativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, "<Project Sdk=\"Microsoft.NET.Sdk\" />");
        }

        return solutionDirectory;
    }

    private static void CreateProject(string solutionDirectory, string relativePath)
    {
        var path = Path.Combine(solutionDirectory, relativePath.Replace('/', Path.DirectorySeparatorChar));
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, "<Project Sdk=\"Microsoft.NET.Sdk\" />");
    }

    private sealed class ApplicationMigration : MigrationBase
    {
        public override void Up()
        {
            AddEntity("MDFe")
                .AddColumn("Id", "ID").Int().Key();
            AddUsecaseGroup("Saga")
                .AddUseCaseSubGrup("Test")
                .AddSaga("TestSaga")
                .AddStepGroup("Main")
                .AddStep("Start");
            AddUsecaseGroup("Notifications")
                .AddUseCaseSubGrup("Send")
                .AddCommand("Send", new TestMessage())
                .Strategy(typeof(ITestNotification))
                .AddAgregateStrategy(typeof(TestMessage));
        }
    }

    private enum TestNotificationType
    {
        Email = 1
    }

    private interface ITestNotification
    {
        TestNotificationType Type { get; }
        void Send(ITestMessage message);
    }

    private interface ITestMessage
    {
        string Destination { get; set; }
    }

    private sealed class TestMessage : ITestMessage
    {
        public string Destination { get; set; } = string.Empty;
    }

    private sealed class ApplicationWithoutSagaMigration : MigrationBase
    {
        public override void Up()
        {
            AddEntity("MDFe")
                .AddColumn("Id", "ID").Int().Key();
        }
    }

    private sealed class ApplicationWithQueueMigration : MigrationBase
    {
        public override void Up()
        {
            AddEntity("Session")
                .AddColumn("Id", "ID").Int().Key();
            AddUsecaseGroup("Saga")
                .AddUseCaseSubGrup("Test")
                .AddSaga("TestSaga")
                .AddStepGroup("Main")
                .AddStep("Start")
                .AddOutBoxPollingWorker(
                    "ai.tasks",
                    Dominio.ExchangeType.topic,
                    "audio.transcribe.outbox",
                    "audio.transcribe");
        }
    }
}
