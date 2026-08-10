using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dominio.Deployment;
using Dominio.Migration;
using Interfaces.Schemas;

namespace Dominio.Schemas;

public sealed class DeploymentSchema : ISchemaCodeGeneration
{
    // Cada aplicativo gera seu manifesto isolado; DeploymentEnvironmentSchema agrega o ambiente.
    private readonly DeploymentModel _model;
    private readonly List<DeploymentWorkloadDefinition> _workloads = new();

    public DeploymentSchema(string application, string solutionDirectory)
    {
        if (string.IsNullOrWhiteSpace(application))
            throw new ArgumentException("O nome do aplicativo deve ser informado.", nameof(application));
        if (string.IsNullOrWhiteSpace(solutionDirectory))
            throw new ArgumentException("O diretorio da solucao deve ser informado.", nameof(solutionDirectory));

        _solutionDirectory = solutionDirectory;
        _model = new DeploymentModel { Application = application.Trim() };
    }

    public string _solutionDirectory { get; set; }

    public DeploymentSchema AddResource(
        string name,
        DeploymentResourceKind kind,
        Action<DeploymentResourceBuilder>? configure = null)
    {
        name = Required(name, nameof(name));
        if (_model.Resources.Any(resource =>
            string.Equals(resource.Name, name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"O recurso '{name}' ja foi declarado.");
        }

        var resource = new DeploymentResource
        {
            Name = name,
            Identity = ApplicationIdentity(_model.Application, name),
            Kind = kind
        };
        configure?.Invoke(new DeploymentResourceBuilder(resource));
        _model.Resources.Add(resource);
        return this;
    }

    public DeploymentSchema AddWorkload(
        string name,
        Action<DeploymentWorkloadBuilder> configure)
    {
        name = Required(name, nameof(name));
        ArgumentNullException.ThrowIfNull(configure);
        if (_workloads.Any(workload =>
            string.Equals(workload.Model.Name, name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"O workload '{name}' ja foi declarado.");
        }

        var definition = new DeploymentWorkloadDefinition
        {
            Model = new DeploymentWorkload
            {
                Name = name,
                Identity = ApplicationIdentity(_model.Application, name)
            }
        };
        configure(new DeploymentWorkloadBuilder(definition));
        _workloads.Add(definition);
        _model.Workloads.Add(definition.Model);
        return this;
    }

    public void CodeGenaration(MigrationBase migration)
    {
        CreateModel(migration);
        GenerateDockerfiles();

        var outputPath = Path.Combine(
            _solutionDirectory,
            "infra",
            _model.Application,
            "Migration",
            "deployment-model.json");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
        File.WriteAllText(outputPath, JsonSerializer.Serialize(_model, JsonOptions()));
    }

    public DeploymentModel CreateModel(MigrationBase migration)
    {
        ArgumentNullException.ThrowIfNull(migration);
        Validate();
        return _model;
    }

    private void GenerateDockerfiles()
    {
        foreach (var definition in _workloads)
        {
            switch (definition.Model.Source.Kind)
            {
                case DeploymentWorkloadSourceKind.Project:
                    GenerateProjectDockerfile(definition);
                    break;
                case DeploymentWorkloadSourceKind.BuildContext:
                    ScaffoldCustomDockerfile(definition);
                    break;
            }
        }
    }

    private void GenerateProjectDockerfile(DeploymentWorkloadDefinition definition)
    {
        var projectPath = definition.Model.Source.ProjectPath!;
        var absoluteProjectPath = ResolvePath(projectPath);
        if (!File.Exists(absoluteProjectPath))
        {
            throw new FileNotFoundException(
                $"O projeto do workload '{definition.Model.Name}' nao foi encontrado.",
                absoluteProjectPath);
        }

        var relativeDockerfile = DeploymentWorkloadBuilder.NormalizePath(Path.Combine(
            "infra",
            _model.Application,
            "Migration",
            "workloads",
            definition.Model.Name,
            "Dockerfile"));
        var absoluteDockerfile = ResolvePath(relativeDockerfile);
        Directory.CreateDirectory(Path.GetDirectoryName(absoluteDockerfile)!);
        File.WriteAllText(
            absoluteDockerfile,
            BuildDotNetDockerfile(projectPath, definition.ProjectRuntime));

        definition.Model.Source = new DeploymentWorkloadSource
        {
            Kind = DeploymentWorkloadSourceKind.Project,
            ProjectPath = projectPath,
            BuildContext = ".",
            Dockerfile = relativeDockerfile
        };
    }

    private void ScaffoldCustomDockerfile(DeploymentWorkloadDefinition definition)
    {
        var source = definition.Model.Source;
        var buildContext = ResolvePath(source.BuildContext!);
        if (!Directory.Exists(buildContext))
        {
            throw new DirectoryNotFoundException(
                $"O contexto de build do workload '{definition.Model.Name}' nao foi encontrado: {buildContext}");
        }

        var dockerfilePath = Path.Combine(buildContext, source.Dockerfile!);
        if (File.Exists(dockerfilePath))
            return;
        if (definition.DockerfileTemplate is null)
        {
            throw new FileNotFoundException(
                $"O Dockerfile do workload '{definition.Model.Name}' nao foi encontrado e nenhum scaffold foi declarado.",
                dockerfilePath);
        }

        Directory.CreateDirectory(Path.GetDirectoryName(dockerfilePath)!);
        var template = definition.DockerfileTemplate;
        var content = new StringBuilder()
            .AppendLine($"# yeshua-template: {template.Name}/v{template.Version}")
            .AppendLine("# custon: este arquivo foi criado uma vez e nao sera sobrescrito pela Engine")
            .AppendLine(template.Content)
            .ToString();
        File.WriteAllText(dockerfilePath, content);
    }

    private string BuildDotNetDockerfile(string projectPath, DotNetRuntimeKind runtime)
    {
        var assemblyName = Path.GetFileNameWithoutExtension(projectPath);
        var runtimeImage = runtime == DotNetRuntimeKind.AspNetCore
            ? "mcr.microsoft.com/dotnet/aspnet:8.0"
            : "mcr.microsoft.com/dotnet/runtime:8.0";

        return $$"""
            # generated: Dominio.Schemas.DeploymentSchema
            FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
            WORKDIR /src
            COPY . .
            RUN dotnet publish {{projectPath}} -c Release -o /app/publish

            FROM {{runtimeImage}}
            WORKDIR /app
            COPY --from=build /app/publish .
            ENTRYPOINT ["dotnet", "{{assemblyName}}.dll"]
            """;
    }

    private void Validate()
    {
        var targets = _model.Resources.Select(resource => resource.Name)
            .Concat(_model.Workloads.Select(workload => workload.Name))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var resourceNames = _model.Resources.Select(resource => resource.Name)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var resource in _model.Resources)
        {
            if (resource.Parent is not null && !resourceNames.Contains(resource.Parent))
            {
                throw new InvalidOperationException(
                    $"O recurso '{resource.Name}' possui o pai inexistente '{resource.Parent}'.");
            }
        }

        foreach (var definition in _workloads)
        {
            var workload = definition.Model;
            if (!definition.SourceWasSet)
                throw new InvalidOperationException($"O workload '{workload.Name}' nao possui origem.");

            foreach (var requirement in workload.Requires)
            {
                if (!targets.Contains(requirement))
                {
                    throw new InvalidOperationException(
                        $"O workload '{workload.Name}' depende do recurso ou workload inexistente '{requirement}'.");
                }
            }

            foreach (var mount in workload.Mounts)
            {
                if (!resourceNames.Contains(mount.Resource))
                {
                    throw new InvalidOperationException(
                        $"O workload '{workload.Name}' monta o recurso inexistente '{mount.Resource}'.");
                }
            }

            var portNames = workload.Ports.Select(port => port.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);
            if (portNames.Count != workload.Ports.Count)
                throw new InvalidOperationException($"O workload '{workload.Name}' possui portas duplicadas.");
            if (workload.HealthCheck?.Port is not null &&
                !portNames.Contains(workload.HealthCheck.Port))
            {
                throw new InvalidOperationException(
                    $"O healthcheck do workload '{workload.Name}' referencia a porta inexistente '{workload.HealthCheck.Port}'.");
            }
        }
    }

    private string ResolvePath(string path)
    {
        var platformPath = path.Replace('/', Path.DirectorySeparatorChar);
        return Path.IsPathRooted(platformPath)
            ? platformPath
            : Path.Combine(_solutionDirectory, platformPath);
    }

    private static JsonSerializerOptions JsonOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() }
        };
    }

    private static string ApplicationIdentity(string application, string name)
    {
        return $"{NormalizeIdentity(application)}-{NormalizeIdentity(name)}";
    }

    private static string NormalizeIdentity(string value)
    {
        var normalized = new string(value.Trim().ToLowerInvariant()
            .Select(character => char.IsLetterOrDigit(character) ? character : '-')
            .ToArray());
        while (normalized.Contains("--", StringComparison.Ordinal))
            normalized = normalized.Replace("--", "-", StringComparison.Ordinal);
        return normalized.Trim('-');
    }

    private static string Required(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("O valor deve ser informado.", parameterName);
        return value.Trim();
    }
}
