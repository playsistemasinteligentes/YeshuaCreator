using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Repositories;
using Yeshua.OperationalIntelligence.Api.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Application;

// Coordinates existing indexed evidence; no second index, graph or generated app manual.
public sealed class SourceSearch(ISourceContextRepository repository, IOptions<OperationalIntelligenceOptions>? options = null)
{
    private readonly string _searchUrl = SearchUrl(options?.Value ?? new());

    public async Task<SourceExplorationResponse> SearchAsync(SourceExplorationRequest input, CancellationToken token)
    {
        var request = Normalize(input);
        if (request.Kind == "applications")
        {
            var all = (await repository.GetApplicationsAsync(token))
                .Where(app => request.Query is null || app.Name.Contains(request.Query, StringComparison.OrdinalIgnoreCase))
                .Where(app => request.Application is null || app.Name.Equals(request.Application, StringComparison.OrdinalIgnoreCase))
                .OrderBy(app => app.Name, StringComparer.Ordinal).ToArray();
            var page = all.Skip(request.Offset).Take(request.MaxResults).ToArray();
            var next = page.Select(app => new SourceSearchNext("Consultar versões indexadas.",
                request with { Kind = "builds", Application = app.Name, Query = null, Offset = 0 })).ToList();
            AddPage(next, request, all.Length);
            return new(request.Kind, null, page, [], [], [], [], [], [], WithUrls(next),
                page.Length == 0 ? ["Nenhum aplicativo indexado corresponde ao filtro. O catálogo não comprova acesso de uma conta."] : []);
        }
        if (request.Kind == "builds")
        {
            var all = (await repository.GetBuildsAsync(request.Application!, token))
                .Where(build => (request.Version is null || build.Version == request.Version)
                    && (request.Query is null || build.Version.Contains(request.Query, StringComparison.OrdinalIgnoreCase))
                    && (!request.BuildId.HasValue || build.BuildId == request.BuildId))
                .OrderByDescending(build => build.GeneratedAtUtc).ThenBy(build => build.BuildId).ToArray();
            var page = all.Skip(request.Offset).Take(request.MaxResults).ToArray();
            var next = page.Select(build => new SourceSearchNext("Explorar a DSL deste snapshot.",
                request with { Kind = "dsl", Application = build.Application, Version = build.Version,
                    BuildId = build.BuildId, Query = null, Offset = 0, IncludeContent = true })).ToList();
            AddPage(next, request, all.Length);
            return new(request.Kind, null, [], page, [], [], [], [], [], WithUrls(next),
                page.Length == 0 ? ["Nenhum build indexado corresponde ao filtro; não há fonte confirmado para esta consulta."] : []);
        }

        var context = request.Kind switch
        {
            "field" => await repository.SearchFieldAsync(new FieldSearchRequest
            {
                Application = request.Application!, Version = request.Version, BuildId = request.BuildId,
                Field = request.Query!, MaxDepth = request.MaxDepth, MaxResults = request.MaxResults
            }, token),
            "class" => await repository.SearchClassAsync(new ClassSearchRequest
            {
                Application = request.Application!, Version = request.Version, BuildId = request.BuildId,
                Class = request.Query!, MaxDepth = request.MaxDepth, MaxResults = request.MaxResults
            }, token),
            "function" => await repository.SearchFunctionAsync(new FunctionSearchRequest
            {
                Application = request.Application!, Version = request.Version, BuildId = request.BuildId,
                Function = request.Query!, File = request.File, Line = request.Line,
                MaxDepth = request.MaxDepth, Direction = request.Direction, MaxResults = request.MaxResults
            }, token),
            _ => await repository.DiscoverFilesAsync(new SourceDiscoveryRequest
            {
                Application = request.Application!, Version = request.Version, BuildId = request.BuildId,
                Kind = request.Kind, Query = request.Query, File = request.File,
                MaxResults = request.MaxResults, Offset = request.Offset
            }, token)
        };
        // Every continuation pins the actual build, even when the first search asked for latest.
        request = request with { Application = context.Build.Application, Version = context.Build.Version, BuildId = context.Build.BuildId };
        var warnings = context.Warnings.ToList();
        if (request.Kind is "screen" or "action" or "metadata")
            warnings.Add("Arquivos candidatos por caminho/referência textual; não comprovam vínculo semântico de botão, regra ou execução. Leia a DSL/metadados e o código.");
        if (request.Kind == "dsl")
            warnings.Add("DSL original das migrations; representa declarações e alterações, não um novo manifesto consolidado nem o estado runtime.");
        var files = context.SourceFiles.DistinctBy(file => file.File, StringComparer.OrdinalIgnoreCase)
            .Take(request.MaxResults).ToArray();
        if (request.Kind == "screen" && files.Length > 1)
            warnings.Add("Os arquivos podem atender telas ou fluxos diferentes. Confirme a entrada/roteamento nos links de início antes de combinar botões e instruções de arquivos distintos.");
        var nextSteps = files.Take(request.MaxFiles).Select(file => new SourceSearchNext($"Ler contexto de {Path.GetFileName(file.File)} no mesmo snapshot.",
            request with { Kind = "file", Query = null, File = file.File, Line = SnippetStart(context, request, file.File),
                EndLine = context.Matches.FirstOrDefault(match => SameFile(match.File, file.File))?.EndLine,
                IncludeContent = true, Offset = 0, MaxFiles = 1 })).ToList();
        foreach (var file in files.Take(request.MaxFiles))
        {
            if ((request.Kind is "screen" or "action") && SnippetStart(context, request, file.File) > 1)
                nextSteps.Add(new($"Ler início de {Path.GetFileName(file.File)} para identificar entrada, eventos e contexto anterior.",
                    request with { Kind = "file", Query = null, File = file.File, Line = 1,
                        EndLine = null, IncludeContent = true, Offset = 0, MaxFiles = 1 }));
        }
        if (files.Length == 0 && (request.Kind is "screen" or "action") && request.File is null && request.Offset == 0)
        {
            warnings.Add("Sem coincidência literal não significa que a função não exista. Use o próximo link para descobrir os termos declarados, sem inventar outra URL.");
            var byApplication = request.Query is not null &&
                !request.Query.Equals(request.Application, StringComparison.OrdinalIgnoreCase);
            nextSteps.Add(new(byApplication ? "Explorar telas pelo nome do aplicativo." : "Consultar a DSL para descobrir telas e ações declaradas.",
                request with { Kind = byApplication ? "screen" : "dsl", Query = byApplication ? request.Application : null,
                    Line = null, EndLine = null, IncludeContent = true, Offset = 0 }));
        }
        if (context.NextOffset.HasValue)
            nextSteps.Add(new("Próxima página, com os mesmos filtros e snapshot.", request with { Offset = context.NextOffset.Value }));
        if (request.Kind is "field" or "class" or "function")
        {
            if (request.MaxDepth < 3)
                nextSteps.Add(new("Aprofundar relações técnicas; não é evidência de execução.", request with { MaxDepth = request.MaxDepth + 1 }));
            if (request.Kind == "function" && request.Direction == "both" && request.MaxDepth > 0)
            {
                nextSteps.Add(new("Consultar somente chamadores.", request with { Direction = "upstream" }));
                nextSteps.Add(new("Consultar somente funções chamadas.", request with { Direction = "downstream" }));
            }
            warnings.Add("Relações limitadas durante a busca, com um caminho representativo por função; não é enumeração de todos os caminhos possíveis.");
            if (context.Matches.Count >= request.MaxResults || context.References.Count >= request.MaxResults || context.Chains.Count >= request.MaxResults)
                warnings.Add("Uma lista atingiu maxResults. Refine o símbolo/arquivo ou aumente maxResults; resultados limitados não significam ausência de outras relações.");
        }

        var snippets = new List<SourceSnippet>();
        if (request.IncludeContent)
        {
            var selected = files.Take(request.MaxFiles).ToArray();
            var contents = await repository.GetSourceContentsAsync(context.Build.BuildId, selected.Select(file => file.File).ToArray(), token);
            var remaining = request.MaxContentChars;
            for (var fileIndex = 0; fileIndex < selected.Length; fileIndex++)
            {
                var file = selected[fileIndex];
                var fileBudget = remaining / (selected.Length - fileIndex);
                var source = contents.FirstOrDefault(item => item.File.Equals(file.File, StringComparison.OrdinalIgnoreCase));
                if (source is null)
                {
                    warnings.Add($"Conteúdo não encontrado no snapshot: {file.File}.");
                    continue;
                }
                var lines = source.Content.Replace("\r\n", "\n").Split('\n');
                var start = SnippetStart(context, request, file.File);
                var declaration = context.Matches.FirstOrDefault(match => SameFile(match.File, file.File) && match.StartLine == start);
                var targetEnd = request.EndLine ?? declaration?.EndLine ?? Math.Min(lines.Length, start + request.MaxLines - 1);
                if (start > lines.Length)
                {
                    warnings.Add($"Linha {start} não existe em {file.File} ({lines.Length} linhas).");
                    continue;
                }
                targetEnd = Math.Min(targetEnd, lines.Length);
                var end = Math.Min(targetEnd, start + request.MaxLines - 1);
                var builder = new System.Text.StringBuilder();
                var includedEnd = start - 1;
                for (var line = start; line <= end; line++)
                {
                    var hasPreviousLine = includedEnd >= start;
                    var cost = lines[line - 1].Length + (hasPreviousLine ? 1 : 0);
                    if (cost > fileBudget - builder.Length) break;
                    if (hasPreviousLine) builder.Append('\n');
                    builder.Append(lines[line - 1]);
                    includedEnd = line;
                }
                if (includedEnd < start)
                {
                    warnings.Add($"Orçamento de conteúdo insuficiente para a linha {start} de {file.File}; use o link desse arquivo com maxFiles=1 ou aumente maxContentChars.");
                    continue;
                }
                remaining -= builder.Length;
                var complete = includedEnd >= targetEnd;
                snippets.Add(new(file.File, start, includedEnd, lines.Length, builder.ToString(), complete));
                if (!complete || (request.Kind == "file" && includedEnd < lines.Length && !request.EndLine.HasValue))
                    nextSteps.Add(new("Continuar trecho, sem perder a versão.", request with
                    {
                        Kind = "file", Query = null, File = file.File, Line = includedEnd + 1,
                        EndLine = complete ? null : targetEnd, IncludeContent = true, MaxFiles = 1, Offset = 0
                    }));
            }
        }
        return new(request.Kind, context.Build, [], [], context.Matches.Take(request.MaxResults).ToArray(),
            context.References.Take(request.MaxResults).ToArray(), context.Chains.Take(request.MaxResults).ToArray(),
            files, snippets, WithUrls(nextSteps), warnings.Distinct(StringComparer.Ordinal).ToArray());
    }

    private static int SnippetStart(SourceContextResponse context, SourceExplorationRequest request, string file)
    {
        if (request.Line.HasValue) return request.Line.Value;
        var match = FirstLine(context, file);
        if (request.Kind is not ("screen" or "action")) return match;
        var extension = Path.GetExtension(file).ToLowerInvariant();
        if (extension is ".html" or ".htm" or ".cshtml" or ".razor" or ".vue") return 1;
        return Math.Max(1, match - Math.Min(20, request.MaxLines / 4));
    }

    private SourceSearchNext[] WithUrls(List<SourceSearchNext> next)
    {
        var linked = new SourceSearchNext[next.Count];
        for (var index = 0; index < next.Count; index++)
        {
            var arguments = JsonSerializer.SerializeToElement(next[index].Arguments,
                SourceExplorationJson.Default.SourceExplorationRequest);
            var pairs = new List<string>();
            foreach (var field in arguments.EnumerateObject())
            {
                if (field.Value.ValueKind == JsonValueKind.Null) continue;
                var value = field.Value.ValueKind == JsonValueKind.String
                    ? field.Value.GetString()! : field.Value.GetRawText();
                pairs.Add(Uri.EscapeDataString(field.Name) + "=" + Uri.EscapeDataString(value));
            }
            linked[index] = next[index] with { Url = _searchUrl + "?" + string.Join("&", pairs) };
        }
        return linked;
    }

    private static string SearchUrl(OperationalIntelligenceOptions options)
    {
        if (!OperationalIntelligenceOptions.IsValidPublicBaseUrl(options.PublicBaseUrl))
            throw new ArgumentException("Configure OperationalIntelligence:PublicBaseUrl com a URL pública da API.");
        return new Uri(new Uri(options.PublicBaseUrl.TrimEnd('/') + "/"), "api/source-context/search").AbsoluteUri;
    }

    private static int FirstLine(SourceContextResponse context, string file) => Math.Max(1,
        context.Matches.FirstOrDefault(match => SameFile(match.File, file) && match.StartLine.HasValue)?.StartLine
        ?? context.References.FirstOrDefault(reference => SameFile(reference.File, file))?.Line ?? 1);

    private static bool SameFile(string? left, string right) => string.Equals(left, right, StringComparison.OrdinalIgnoreCase);

    private static void AddPage(List<SourceSearchNext> next, SourceExplorationRequest request, int total)
    {
        if (request.Offset + request.MaxResults < total)
            next.Add(new("Próxima página do catálogo.", request with { Offset = request.Offset + request.MaxResults }));
    }

    private static SourceExplorationRequest Normalize(SourceExplorationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Kind)) throw new ArgumentException("kind deve ser informado como texto não vazio.");
        request = request with { Kind = request.Kind.Trim().ToLowerInvariant(), Application = Clean(request.Application),
            Version = Clean(request.Version), Query = Clean(request.Query), File = Clean(request.File),
            Direction = request.Direction?.Trim().ToLowerInvariant() ?? "" };
        if (request.Kind is not ("applications" or "builds" or "dsl" or "metadata" or "screen" or "action" or "file" or "field" or "class" or "function"))
            throw new ArgumentException("kind: applications, builds, dsl, metadata, screen, action, file, field, class ou function.");
        if (request.Kind != "applications" && request.Application is null)
            throw new ArgumentException("application é obrigatório; comece por kind=applications para descobrir os nomes.");
        if (request.Kind is "field" or "class" or "function" && request.Query is null)
            throw new ArgumentException("query é obrigatório para campo, classe ou função.");
        if (request.Kind is "field" or "class" or "function" && request.Offset != 0)
            throw new ArgumentException("offset pagina catálogos/arquivos. Para símbolos, refine query/file ou maxResults.");
        if (request.Kind is "field" or "class" && request.File is not null)
            throw new ArgumentException("file delimita busca de função ou descoberta de arquivos; para campo/classe use o nome qualificado em query.");
        if (request.BuildId == Guid.Empty) throw new ArgumentException("buildId deve identificar um snapshot válido.");
        if (request.Direction is not ("both" or "upstream" or "downstream")) throw new ArgumentException("direction: both, upstream ou downstream.");
        if (request.Kind is "applications" or "builds" && request.File is not null)
            throw new ArgumentException("file não se aplica a catálogos; escolha kind=file, dsl, screen, action ou metadata.");
        if (request.Application?.Length > 100 || request.Version?.Length > 200 || request.Query?.Length > 200 || request.File?.Length > 1000)
            throw new ArgumentException("Filtros excedem o tamanho máximo (application 100, version/query 200, file 1000).");
        if (request.MaxDepth is < 0 or > 3 || request.MaxResults is < 1 or > 50 || request.Offset is < 0 or > 10000
            || request.MaxFiles is < 1 or > 5 || request.MaxLines is < 1 or > 400 || request.MaxContentChars is < 100 or > 50000)
            throw new ArgumentException("Limites: maxDepth 0..3, maxResults 1..50, offset 0..10000, maxFiles 1..5, maxLines 1..400, maxContentChars 100..50000.");
        if (request.Line is <= 0 || request.EndLine is <= 0 || (request.EndLine.HasValue && (!request.Line.HasValue || request.EndLine < request.Line)))
            throw new ArgumentException("Use line/endLine positivos, com endLine >= line.");
        if (request.Line.HasValue && request.File is null)
            throw new ArgumentException("Informe file ao selecionar line, para manter o recorte explícito.");
        return request;
    }

    private static string? Clean(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
