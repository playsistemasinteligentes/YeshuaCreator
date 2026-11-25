using Dominio.Migration;
namespace Yeshua.Studio.Presenca;
[Migration(000003)]
public sealed class M000003 : MigrationBase
{
 public override void Up()
 {
  AddUsecaseGroup("Presenca").AddUseCaseSubGrup("Editorial")
   .AddCommand("ReprocessarStatusEducacional",new EditorialInput(),new EditorialOutput()).AddScope("presenca.editorial");
 }
}
