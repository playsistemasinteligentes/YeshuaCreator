using Dominio;
using Dominio.Schemas.CQRS;
namespace Yeshua.Engine.Tests;
[TestClass]
public class RepeatedForeignKeyDictionaryTests
{
    [TestMethod]
    public void Repeated_foreign_keys_keep_first_navigation_and_generate_distinct_names()
    {
        var user=new Entity("User");user.AddColumn("Id","ID").Int().Key();
        var visit=new Entity("Visit");visit.AddColumn("OwnerId","Owner").Int().FK("User","Id");
        visit.AddColumn("ReviewerId","Reviewer").Int().FK("User","Id");
        foreach(var c in visit.AddColumns.Where(c=>c.IsFK))c.EntityFK=user;
        var path=Path.Combine(Path.GetTempPath(),Guid.NewGuid()+".cs");
        try
        {
            new SourceCodeEntityInternalMigration([user,visit]).WriteMigrationCode(path);
            var code=File.ReadAllText(path);
            StringAssert.Contains(code,"public User User { get; set; }");
            StringAssert.Contains(code,"public User User_ReviewerId { get; set; }");
            Assert.AreEqual(1,code.Split("public User User { get; set; }").Length-1);
        }
        finally { File.Delete(path); }
    }
}
