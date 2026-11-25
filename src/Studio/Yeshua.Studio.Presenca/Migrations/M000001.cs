using Dominio;
using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;
namespace Yeshua.Studio.Presenca;
[Migration(000001)]
public sealed class M000001 : MigrationBase
{
 public override void Up()
 {
  AddModule("PRESENCA", "Presença");
  AddCustomPage("PRESENCA", "Redação", "presenca-redacao", "presenca.editorial", "Presença");
  AddEntity("IdentidadePublicadora").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("Nome", "Nome").Varchar(500)
   .AddColumn("Ativa", "Ativa").Int();
  AddEntity("VinculoIdentidadePublicadora").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("UsuarioId", "UsuarioId").Int()
   .AddColumn("Permissoes", "Permissoes").Int()
   .AddColumn("Versao", "Versao").Int();
  AddEntity("Plataforma").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("Codigo", "Codigo").Varchar(500)
   .AddColumn("Capacidades", "Capacidades").Varchar(500);
  AddEntity("Canal").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("Plataforma", "Plataforma").Varchar(500)
   .AddColumn("Destino", "Destino").Varchar(500)
   .AddColumn("Conexao", "Conexao").Varchar(500);
  AddEntity("Pauta").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("VersaoAtual", "VersaoAtual").Int()
   .AddColumn("Origem", "Origem").Varchar(500);
  AddEntity("OrigemPauta").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("PautaId", "PautaId").Varchar(500)
   .AddColumn("Produtor", "Produtor").Varchar(500)
   .AddColumn("MovimentoId", "MovimentoId").Varchar(500);
  AddEntity("Conteudo").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("PautaId", "PautaId").Varchar(500);
  AddEntity("ConteudoVersao").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("PautaId", "PautaId").Varchar(500)
   .AddColumn("Numero", "Numero").Int()
   .AddColumn("Hash", "Hash").Varchar(500)
   .AddColumn("Estado", "Estado").Varchar(500)
   .AddColumn("Snapshot", "Snapshot").VarcharMax().ClassifyOperationalData(OperationalDataClassification.NeverCapture);
  AddEntity("Material").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("VersaoId", "VersaoId").Varchar(500)
   .AddColumn("StorageKey", "StorageKey").Varchar(500)
   .AddColumn("Hash", "Hash").Varchar(500)
   .AddColumn("Licenca", "Licenca").Varchar(500);
  AddEntity("Aprovacao").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("VersaoId", "VersaoId").Varchar(500)
   .AddColumn("Hash", "Hash").Varchar(500)
   .AddColumn("Destinos", "Destinos").VarcharMax().ClassifyOperationalData(OperationalDataClassification.NeverCapture);
  AddEntity("Publicacao").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("VersaoId", "VersaoId").Varchar(500)
   .AddColumn("Hash", "Hash").Varchar(500);
  AddEntity("PublicacaoDestino").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("VersaoId", "VersaoId").Varchar(500)
   .AddColumn("CanalId", "CanalId").Varchar(500)
   .AddColumn("Estado", "Estado").Varchar(500)
   .AddColumn("Tentativas", "Tentativas").Int()
   .AddColumn("ProximaTentativaUtc", "ProximaTentativaUtc").DateTime()
   .AddColumn("ReciboExterno", "ReciboExterno").Varchar(500)
   .AddColumn("UrlPublica", "UrlPublica").Varchar(500);
  AddEntity("AuditoriaEditorial").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("Operacao", "Operacao").Varchar(500)
   .AddColumn("RegistroId", "RegistroId").Varchar(500);
  AddEntity("ReciboEntrada").AddModule("PRESENCA").InternalToUseCase("Presenca", "Editorial", "ExecutarEditorial")
   .AddColumn("Id", "ID").Varchar(64).Key()
   .AddColumn("IdentidadeId", "IdentidadeId").Varchar(64)
   .AddColumn("Operacao", "Operacao").Varchar(500)
   .AddColumn("Hash", "Hash").Varchar(500)
   .AddColumn("Resultado", "Resultado").VarcharMax().ClassifyOperationalData(OperationalDataClassification.NeverCapture);
  var commands = AddUsecaseGroup("Presenca").AddUseCaseSubGrup("Editorial");
  commands.AddCommand("CriarIdentidade", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("DefinirVinculo", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("ConfigurarCanal", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("CriarPautaManual", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("SalvarRascunho", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("ConsultarIdentidades", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("ConsultarRedacao", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("SubmeterRevisao", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("AprovarVersao", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("RejeitarVersao", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("SolicitarPublicacao", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("ConsultarOperacao", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("ReprocessarEntrega", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("ReconciliarEntrega", new EditorialInput(), new EditorialOutput()).Authorization(Authorization.User).AddScope("presenca.editorial");
  commands.AddCommand("ExecutarEditorial", new ExecucaoEditorialInput(), new EditorialOutput()).Internal();
 }
}
public class EditorialInput
{
 public string IdentidadeId {get;set;} = "";
 public string RegistroId {get;set;} = "";
 public string Chave {get;set;} = "";
 public int VersaoEsperada {get;set;}
 public string Dados {get;set;} = "{}";
}
public sealed class ExecucaoEditorialInput { public string Operacao {get;set;} = ""; public string IdentidadeId {get;set;} = ""; public string RegistroId {get;set;} = ""; public string Chave {get;set;} = ""; public int VersaoEsperada {get;set;} public string Dados {get;set;} = "{}"; }
public sealed class EditorialOutput { public string Resultado {get;set;} = ""; }
