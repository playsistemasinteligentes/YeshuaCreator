namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed record LogSourceSignal(
    string Kind,
    string Symbol,
    string? File,
    int? Line,
    string Evidence,
    double Confidence);

