using Dominio.Migration;
namespace Yeshua.Studio.Presenca;
[Migration(000002)]
public sealed class M000002 : MigrationBase
{
 public override void Up()
 {
  AlterEntity("OrigemPauta")
   .AddColumn("Referencia", "Referência externa").Varchar(500)
   .AddColumn("Revisao", "Revisão de origem").Int()
   .AddColumn("Hash", "Hash público").Varchar(64)
   .AddColumn("Contrato", "Contrato").Varchar(100);
  AlterEntity("AuditoriaEditorial").AddColumn("Motivo","Motivo").Varchar(500).ClassifyOperationalData(Dominio.OperationalDataClassification.NeverCapture);
  AlterEntity("ConteudoVersao").AddColumn("OrigemRevisao","Revisão na origem").Int();
  AlterEntity("PublicacaoDestino").AddColumn("CodigoErro", "Código seguro").Varchar(100)
   .AddColumn("NaturezaFalha","Natureza da falha").Varchar(20)
   .AddColumn("RetryPossivel","Retry autorizado possível").Boolean();
  var commands=AddUsecaseGroup("Presenca").AddUseCaseSubGrup("Editorial");
  commands.AddCommand("ProcessarPresenca",new CicloPresencaInput(),new CicloPresencaOutput()).Internal().IsWorker();
  commands.AddCommand("ConsultarAuditoria",new EditorialInput(),new EditorialOutput()).AddScope("presenca.editorial");
  commands.AddSaga("ReceberOrigemEditorial")
   .StartsFromYeshuaModuleEvent("Fabrica","MovimentoFabricaDisponivel",1,"MovimentosFabrica","publicarMovimento")
   .StartsFromYeshuaModuleEvent("Academia","SolicitacaoPublicacaoEducacional",1,"PublicarAula","solicitarPublicacao")
   .AddStepGroup("entrada").AddStep("registrarPautaDeOrigem");
  ConfigureSagaWorkers(loopMilliseconds:1000,generateQueueWorkers:true);
 }
}
public sealed class CicloPresencaInput { }
public sealed class CicloPresencaOutput { public int Claimed {get;set;} public int Processed {get;set;} public int Failed {get;set;} }
