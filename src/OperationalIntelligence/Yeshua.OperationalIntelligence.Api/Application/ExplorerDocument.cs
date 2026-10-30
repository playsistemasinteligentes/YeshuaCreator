namespace Yeshua.OperationalIntelligence.Api.Application;

public sealed class ExplorerDocument
{
    public string Text { get; }

    public ExplorerDocument()
    {
        using var stream = typeof(ExplorerDocument).Assembly.GetManifestResourceStream(
            "Yeshua.OperationalIntelligence.Api.Documentation.Explorer.md")
            ?? throw new InvalidOperationException("Explorer document is missing.");
        using var reader = new StreamReader(stream);
        Text = reader.ReadToEnd();
    }
}
