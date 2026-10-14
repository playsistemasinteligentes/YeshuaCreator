using Dominio;
using Dominio.Schemas.CQRS;

namespace TestMigration;

[TestClass]
public class UseCaseSharedTypesTests
{
    [TestMethod]
    public void LaterMigrationInSameGroupPreservesEarlierNestedTypes()
    {
        var first = new UseCaseGroup("Memorias");
        first.AddUseCaseSubGrup("YouTube").AddCommand("Listar", new Input(), new Output());
        var later = new UseCaseGroup("Memorias");
        later.AddUseCaseSubGrup("YouTube").AddCommand("Salvar", new Input(), new Input());
        var generated = new Probe(later, new[] { first, later }).Render();
        StringAssert.Contains(generated, "record ChannelInfo");
        StringAssert.Contains(generated, "string ChannelId");
        Assert.AreEqual(1, generated.Split("record ChannelInfo").Length - 1);
    }

    private sealed class Probe(UseCaseGroup current, IEnumerable<UseCaseGroup> groups)
        : SourceCodeAplicationCommandCommandsUseCaseGroup(current, groups)
    {
        public string Render() => GenerateCode().ToString();
    }
    public sealed record Input();
    public sealed record Output(List<ChannelInfo>? Channels = null);
    public sealed record ChannelInfo(string ChannelId);
}
