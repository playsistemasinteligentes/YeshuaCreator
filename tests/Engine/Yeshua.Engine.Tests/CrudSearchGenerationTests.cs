using System.Reflection;
using Dominio;
using Dominio.Migration;
using Dominio.Schemas.CQRS;
using Migration.Dominio;

namespace TestMigration;

[TestClass]
public class CrudSearchGenerationTests
{
    [TestMethod]
    public void LaterMigrationCanReplaceSearchProjectionWithoutDroppingColumnsOrOtherQueries()
    {
        var original=new Fixture(); original.Up();
        var later=new Fixture(); later.Up();
        var entity=original.Entitys.Single();
        var query=later.Entitys.Single().Queries.Single();
        typeof(Entity).GetMethod("CopyMetadataFrom",BindingFlags.Instance|BindingFlags.NonPublic)!
            .Invoke(entity,[later.Entitys.Single()]);
        Assert.AreEqual(1,entity.Queries.Count);
        Assert.AreSame(query,entity.Queries.Single());
        Assert.AreEqual(4,entity.AddColumns.Count);
    }

    [TestMethod]
    public void SearchKeepsContainsAsAParameterAndUsesTheActualDateField()
    {
        var fixture=new Fixture();fixture.Up();
        var entity=fixture.Entitys.Single();
        var meta=((IQueryWithMeta)entity.Queries.Single()).Meta;
        foreach(var condition in meta.WhereParameters.Values.SelectMany(x=>x))
            condition.Column=fixture.GetColumn(condition.EntityName,condition.Field);
        var name=meta.WhereParameters["Geral"].Single(x=>x.Field=="Nome");
        Assert.AreEqual("LIKE",name.Operator);
        var code=Generate(new SourceCodeInfraestructureQueryReadMigration(entity,false));
        StringAssert.Contains(code,"LIKE @Nome_");
        StringAssert.Contains(code,"%{Command.Nome}%");
        StringAssert.Contains(code,"Command.DataHora > (DateTime)SqlDateTime.MinValue");
        Assert.IsFalse(code.Contains("Command.DataFim",StringComparison.Ordinal));
        var command=new SourceCodeAplicationCommandCommandsMigration(new Dominio.Schemas.CQRS.Abstraction.Command());
        Assert.AreEqual("int?",command.GetFriendlyTypeName(typeof(int?)));
        Assert.AreEqual("DateTime?",command.GetFriendlyTypeName(typeof(DateTime?)));
        Assert.AreEqual("List<int>",command.GetFriendlyTypeName(typeof(List<int>)));
    }

    [TestMethod]
    public void FormMetadataUsesDomainRequiredLengthAndEditability()
    {
        var fixture=new Fixture();fixture.Up();
        var code=Generate(new SourceCodeInfraestructureAPIEndpointsMigration(fixture,"Fixture"));
        StringAssert.Contains(code,"id = \"nome\", label = \"Nome\", type = \"string\", required = true, editable = true, maxLength = 150");
        StringAssert.Contains(code,"required = false, editable = false");
        StringAssert.Contains(code,"quickSearches = Array.Empty<object>()");
    }

    private static string Generate(SourceCodeBase generator)
    {
        var folder=Path.Combine(Path.GetTempPath(),"Yeshua.Engine.Tests",Guid.NewGuid().ToString("N"));
        try
        {
            Directory.CreateDirectory(folder);
            var path=Path.Combine(folder,"generated.cs");var custom=Path.Combine(folder,"custom.cs");
            File.WriteAllText(custom,"preserved");generator.WriteCode(null,path,custom);
            Assert.AreEqual("preserved",File.ReadAllText(custom));return File.ReadAllText(path);
        }
        finally { if(Directory.Exists(folder))Directory.Delete(folder,true); }
    }
    private sealed class Fixture:MigrationBase
    {
        public override void Up()
        {
            AddEntity("Cadastro").AddColumn("Id","ID").Int().Key().Incremento()
                .AddColumn("Nome","Nome").Varchar(150).NotNull()
                .AddColumn("DataHora","Horário").DateTime()
                .AddColumn("Status","Status").Int().EditFront(false);
            AddQuery<Cadastro>("Standard",q=>q.Where("Geral",s=>s.Nome.Contains("")&&s.DataHora>=DateTime.Today)
                .Select(s=>new{s.Id,s.Nome,s.DataHora}));
        }
    }
    public class Cadastro
    {
        public int? Id {get;set;}
        public string Nome {get;set;}="";
        public DateTime? DataHora {get;set;}
    }
}
