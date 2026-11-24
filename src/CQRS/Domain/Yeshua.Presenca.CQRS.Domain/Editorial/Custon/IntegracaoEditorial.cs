using System.Text.Json;
using System.Text.Json.Serialization;
namespace Presenca.Editorial;
// Payload public allowlist. Envelope identities/tenant remain in YeshuaModuleEvent.
public sealed record EntradaEditorialV1(string IdentidadeId,string Produtor,string MovimentoId,string Referencia,
 int Revisao,string Tipo,bool AprovadaNaOrigem,ConteudoPublico Conteudo,string Hash);
public sealed record EntradaSagaV1(string Contrato,string Json);
public sealed record StatusEducacionalV1(string MovimentoId,int Revisao,string Estado,string UrlPublica,string Codigo);
public sealed record EntregaPublica(string Id,string IdentidadeId,string PautaId,int Numero,string VersaoId,string Hash,
 string Plataforma,string Destino,string Conexao,ConteudoPublico Conteudo,DateTimeOffset PublicadoEm);
public sealed record ReciboDistribuicao(string IdExterno,string UrlPublica);
public sealed class TrabalhoEditorial
{
 public int Id {get;set;}
 public int TenantID {get;set;}
 public int UserId {get;set;}
 public string MessageId {get;set;}="";
 public string Type {get;set;}="";
 public string Payload {get;set;}="";
 public string CorrelationId {get;set;}="";
 public string EntityId {get;set;}="";
 public DateTime ProcessingAt {get;set;}
 public int RetryCount {get;set;}
 public int ManualRetryBase {get;set;}
 public string RootOperationId {get;set;}="";
 public string OperationId {get;set;}="";
 public string ExecutionId {get;set;}="";
 public string CausationId {get;set;}="";
}
public sealed record AuditoriaEditorialInfo(string Operacao,string RegistroId,int UserId,DateTime Changed);
public static class ContratosEditoriais
{
 public static string HashPublico(ConteudoPublico c)
 {
  var fields=new List<string>{"presenca.public.v1",c.Manchete,c.Corpo,c.Fontes.Length.ToString(System.Globalization.CultureInfo.InvariantCulture)};
  fields.AddRange(c.Fontes);fields.Add(c.ClassificacaoPrincipal);fields.Add(c.ClassificacoesSecundarias.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));fields.AddRange(c.ClassificacoesSecundarias);
  fields.Add(c.Tags.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));fields.AddRange(c.Tags);fields.Add(c.Materiais.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
  foreach(var m in c.Materiais)fields.AddRange(new[]{m.StorageKey,m.Hash,m.Tamanho.ToString(System.Globalization.CultureInfo.InvariantCulture),m.Tipo,m.Autor,m.Licenca,m.TextoAlternativo});
  fields.Add(c.AutorPublico);
  return RegrasEditoriais.Hash(string.Concat(fields.Select(f=>System.Text.Encoding.UTF8.GetByteCount(f).ToString(System.Globalization.CultureInfo.InvariantCulture)+":"+f)));
 }
 public static string Contrato(string source)=>source switch {"Fabrica"=>"MovimentoFabricaDisponivel.v1","Academia"=>"SolicitacaoPublicacaoEducacional.v1",_=>throw new EditorialException("PRESENCA_SOURCE_DENIED",403)};
 public static EntradaEditorialV1 Validar(string contrato,string json)
 {
  if(json.Length>100_000)throw new EditorialException("PRESENCA_INPUT_INVALID");
  EntradaEditorialV1 input;
  try {input=JsonSerializer.Deserialize(json,IntegracaoJson.Default.EntradaEditorialV1)??throw new JsonException();}
  catch(JsonException){throw new EditorialException("PRESENCA_CONTRACT_INVALID");}
  RegrasEditoriais.ValidarId(input.IdentidadeId);RegrasEditoriais.Texto(input.Produtor,120);RegrasEditoriais.Texto(input.MovimentoId,120);
  if(input.Revisao<1||!RegrasEditoriais.UrlSegura(input.Referencia)||input.Referencia.Length>500||input.Conteudo is null)throw new EditorialException("PRESENCA_CONTRACT_INVALID");
  if(contrato=="SolicitacaoPublicacaoEducacional.v1")
  {if(input.Tipo!="aula"||!input.AprovadaNaOrigem)throw new EditorialException("PRESENCA_ORIGIN_APPROVAL_REQUIRED",403);}
  else if(contrato!="MovimentoFabricaDisponivel.v1"||input.Tipo is not ("issue" or "pull_request" or "release" or "deploy"))throw new EditorialException("PRESENCA_CONTRACT_INVALID");
  var c=input.Conteudo;
  var validated=RegrasEditoriais.Conteudo(new(){Manchete=c.Manchete,Corpo=c.Corpo,AutorPublico=c.AutorPublico,Fontes=c.Fontes,ClassificacaoPrincipal=c.ClassificacaoPrincipal,ClassificacoesSecundarias=c.ClassificacoesSecundarias,Tags=c.Tags,Materiais=c.Materiais});
  if(input.Hash!=HashPublico(validated))throw new EditorialException("PRESENCA_ORIGIN_HASH_CONFLICT",409);
  return input with {Conteudo=validated};
 }
 public static TimeSpan Backoff(int attempt,TimeSpan? minimum=null)=>TimeSpan.FromSeconds(Math.Max(Math.Min(3600,Math.Pow(2,Math.Clamp(attempt,1,12))),Math.Min(86400,minimum?.TotalSeconds??0)));
}
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive=true,UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow)]
[JsonSerializable(typeof(EntradaEditorialV1))]
[JsonSerializable(typeof(EntradaSagaV1))]
[JsonSerializable(typeof(StatusEducacionalV1))]
[JsonSerializable(typeof(EntregaPublica))]
[JsonSerializable(typeof(ReciboDistribuicao))]
[JsonSerializable(typeof(List<AuditoriaEditorialInfo>))]
public partial class IntegracaoJson:JsonSerializerContext;
