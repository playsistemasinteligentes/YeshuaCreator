using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class SourceSearchTool : IMcpTool
{
    private readonly ISourceContextRepository _repository;
    private readonly McpToolArgumentReader _arguments;

    public SourceSearchTool(
        ISourceContextRepository repository,
        McpToolArgumentReader arguments)
    {
        _repository = repository;
        _arguments = arguments;
    }

    public string Name => "yeshua.source.search";
    public string Description => "Searches the indexed Yeshua source snapshot by field, class, or function.";
    public object InputSchema => McpToolSchemas.SourceSearch();

    public async Task<McpToolResult> CallAsync(
        JsonElement arguments,
        CancellationToken cancellationToken)
    {
        var application = _arguments.RequiredString(arguments, "application");
        var kind = _arguments.RequiredString(arguments, "kind");
        var query = _arguments.RequiredString(arguments, "query");
        var version = _arguments.String(arguments, "version");
        var maxDepth = _arguments.Integer(arguments, "maxDepth");
        var maxResults = _arguments.Integer(arguments, "maxResults");

        SourceContextResponse response = kind.ToLowerInvariant() switch
        {
            "field" => await _repository.SearchFieldAsync(
                new FieldSearchRequest
                {
                    Application = application,
                    Version = version,
                    Field = query,
                    MaxDepth = maxDepth,
                    MaxResults = maxResults
                },
                cancellationToken),
            "class" => await _repository.SearchClassAsync(
                new ClassSearchRequest
                {
                    Application = application,
                    Version = version,
                    Class = query,
                    MaxDepth = maxDepth,
                    MaxResults = maxResults
                },
                cancellationToken),
            "function" => await _repository.SearchFunctionAsync(
                new FunctionSearchRequest
                {
                    Application = application,
                    Version = version,
                    Function = query,
                    File = _arguments.String(arguments, "file"),
                    Line = _arguments.Integer(arguments, "line"),
                    MaxDepth = maxDepth,
                    MaxResults = maxResults
                },
                cancellationToken),
            _ => throw new ArgumentException("kind must be field, class, or function.")
        };

        return McpToolResult.Ok("Source search completed.", response);
    }
}
