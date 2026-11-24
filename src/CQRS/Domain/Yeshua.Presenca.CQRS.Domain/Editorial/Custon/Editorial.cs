using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Presenca.Editorial;

[Flags]
public enum PermissaoEditorial { Ler=1, Redigir=2, Revisar=4, Aprovar=8, Publicar=16, Operar=32, Administrar=64, Integrar=128 }
public sealed class EditorialException(string code, int status=400) : Exception(code) { public int Status {get;}=status; }
public sealed record PedidoEditorial(string Operacao, string IdentidadeId, string RegistroId, string Chave, int VersaoEsperada, string Dados);
public sealed class DadosEditorial
{
 public int Offset {get;set;}
 public string AgendadaParaUtc {get;set;}="";
 public string Nome {get;set;}="";
 public int UsuarioId {get;set;}
 public int Permissoes {get;set;}
 public string Plataforma {get;set;}="";
 public string Destino {get;set;}="";
 public string Conexao {get;set;}="";
 public string Manchete {get;set;}="";
 public string Corpo {get;set;}="";
 public string[] Fontes {get;set;}=[];
 public string ClassificacaoPrincipal {get;set;}="";
 public string[] ClassificacoesSecundarias {get;set;}=[];
 public string[] Tags {get;set;}=[];
 public MaterialEditorial[] Materiais {get;set;}=[];
 public string AutorPublico {get;set;}="";
 public string[] Canais {get;set;}=[];
 public bool Publicavel {get;set;}
 public string Motivo {get;set;}="";
 public string ReciboExterno {get;set;}="";
 public string UrlPublica {get;set;}="";
}
public sealed record MaterialEditorial(string StorageKey, string Hash, long Tamanho, string Tipo, string Autor, string Licenca, string TextoAlternativo);
// Only this allowlist may cross the public boundary. No internal origin or audit data.
public sealed record ConteudoPublico(string Manchete, string Corpo, string[] Fontes, string ClassificacaoPrincipal,
 string[] ClassificacoesSecundarias, string[] Tags, MaterialEditorial[] Materiais, string AutorPublico);
public sealed class VersaoEditorial
{
 public string Id {get;set;}="";
 public string PautaId {get;set;}="";
 public int Numero {get;set;}
 public string Hash {get;set;}="";
 public string Estado {get;set;}="";
 public string Snapshot {get;set;}="";
 public int UserId {get;set;}
}
public sealed class IdentidadeEditorial { public string Id {get;set;}=""; public string Nome {get;set;}=""; }
public sealed class CanalEditorial { public string Id {get;set;}=""; public string Plataforma {get;set;}=""; public string Destino {get;set;}=""; }
public sealed class ResultadoEditorial
{
 public string Id {get;set;}="";
 public int Versao {get;set;}
 public string Estado {get;set;}="";
 public bool TemMais {get;set;}
 public string AuditoriaJson {get;set;}="[]";
 public DateTimeOffset SaudeConsultadaEmUtc {get;set;}
 public List<SaudeFilaEditorial> SaudeFilas {get;set;}=[];
 public List<IdentidadeEditorial> Identidades {get;set;}=[];
 public List<CanalEditorial> Canais {get;set;}=[];
 public List<VersaoEditorial> Versoes {get;set;}=[];
 public List<EntregaEditorial> Entregas {get;set;}=[];
 public List<RetornoEducacionalEditorial> RetornosEducacionais {get;set;}=[];
}
public sealed class SaudeFilaEditorial
{
 public string Fila {get;set;}="";
 public long Prontas {get;set;}
 public long Agendadas {get;set;}
 public long EmProcessamento {get;set;}
 public long Concluidas {get;set;}
 public long FalhasFinais {get;set;}
 public long ResultadosIncertos {get;set;}
 public long MaisAntigaSegundos {get;set;}
}
public sealed class RetornoEducacionalEditorial
{
 public string Id {get;set;}="";
 public string Estado {get;set;}="";
 public int Tentativas {get;set;}
 public string CodigoErro {get;set;}="";
}
public sealed class EntregaEditorial
{
 public string Id {get;set;}="";
 public string VersaoId {get;set;}="";
 public string CodigoErro {get;set;}="";
 public string NaturezaFalha {get;set;}="";
 public string CanalId {get;set;}="";
 public string Estado {get;set;}="";
 public int Tentativas {get;set;}
 public string ReciboExterno {get;set;}="";
 public string UrlPublica {get;set;}="";
}
public static class RegrasEditoriais
{
 public static string Hash(string text)=>Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(text)));
 // Length-prefixed encoding prevents ambiguous scopes, including user supplied separators.
 public static string Id(params string[] parts)=>Hash(string.Concat(parts.Select(p=>$"{p.Length}:{p}")));
 public static void Autorizar(int tenant, int actor, int grant, PermissaoEditorial required)
 {
  if(tenant<=0 || actor<=0 || (grant&(int)required)!=(int)required) throw new EditorialException("PRESENCA_FORBIDDEN",403);
 }
 public static PermissaoEditorial Permissao(string operation)=>operation switch {
  "CriarPautaManual" or "SalvarRascunho" or "SubmeterRevisao" => PermissaoEditorial.Redigir,
  "AprovarVersao" => PermissaoEditorial.Aprovar,
  "RejeitarVersao" => PermissaoEditorial.Revisar,
  "SolicitarPublicacao" => PermissaoEditorial.Publicar,
  "ReprocessarEntrega" or "ReprocessarStatusEducacional" or "ReconciliarEntrega" or "ConsultarOperacao" => PermissaoEditorial.Operar,
  "CriarIdentidade" or "DefinirVinculo" or "ConfigurarCanal" => PermissaoEditorial.Administrar,
  "ConsultarRedacao" or "ConsultarAuditoria" => PermissaoEditorial.Ler,
  _ => throw new EditorialException("PRESENCA_OPERATION_INVALID") };
 public static DadosEditorial Dados(string json)
 {
  if(string.IsNullOrWhiteSpace(json) || json.Length>100_000) throw new EditorialException("PRESENCA_INPUT_INVALID");
  try {
   var data=JsonSerializer.Deserialize(json,EditorialJson.Default.DadosEditorial) ?? throw new EditorialException("PRESENCA_INPUT_INVALID");
   if(data.Nome is null||data.Plataforma is null||data.Destino is null||data.Conexao is null||data.Manchete is null||data.Corpo is null||data.ClassificacaoPrincipal is null||data.AutorPublico is null||data.Motivo is null||data.ReciboExterno is null||data.UrlPublica is null||data.Canais is null||data.Fontes is null||data.Tags is null||data.ClassificacoesSecundarias is null||data.Materiais is null)
    throw new EditorialException("PRESENCA_INPUT_INVALID");
   return data;
  }
  catch(JsonException) {throw new EditorialException("PRESENCA_INPUT_INVALID");}
 }
 public static string Canonico(PedidoEditorial p, DadosEditorial d)=>JsonSerializer.Serialize(
  new PedidoEditorial(p.Operacao,p.IdentidadeId,p.RegistroId,p.Chave,p.VersaoEsperada,JsonSerializer.Serialize(d,EditorialJson.Default.DadosEditorial)), EditorialJson.Default.PedidoEditorial);
 public static void ValidarPedido(PedidoEditorial p)
 {
  if(string.IsNullOrWhiteSpace(p.Chave)||p.Chave.Length>128||p.VersaoEsperada<0) throw new EditorialException("PRESENCA_REQUEST_INVALID");
  ValidarId(p.IdentidadeId);
  if(p.RegistroId is null)throw new EditorialException("PRESENCA_REQUEST_INVALID");
  if(p.RegistroId.Length>0)ValidarId(p.RegistroId);
 }
 public static void ValidarId(string id)
 {if(id is null||id.Length!=64||!id.All(Uri.IsHexDigit)) throw new EditorialException("PRESENCA_ID_INVALID");}
 public static void Texto(string value,int max)
 {if(string.IsNullOrWhiteSpace(value)||value.Length>max||value.Any(c=>char.IsControl(c)&&c!='\n'&&c!='\r'&&c!='\t'))throw new EditorialException("PRESENCA_TEXT_INVALID");}
 public static bool UrlSegura(string value)=>Uri.TryCreate(value,UriKind.Absolute,out var u)&&u.Scheme=="https"&&string.IsNullOrEmpty(u.UserInfo)&&!u.IsLoopback;
 public static ConteudoPublico Conteudo(DadosEditorial d)
 {
  Texto(d.Manchete,200);Texto(d.Corpo,50_000);Texto(d.ClassificacaoPrincipal,80);Texto(d.AutorPublico,120);
  if(d.Fontes is null||d.Tags is null||d.ClassificacoesSecundarias is null||d.Materiais is null||d.Fontes.Length>20||d.Tags.Length>20||d.ClassificacoesSecundarias.Length>10||d.Materiais.Length>20)
   throw new EditorialException("PRESENCA_COLLECTION_INVALID");
  if(d.Fontes.Any(s=>!UrlSegura(s)||s.Length>500))throw new EditorialException("PRESENCA_SOURCE_INVALID");
  foreach(var text in d.Tags.Concat(d.ClassificacoesSecundarias))Texto(text,80);
  foreach(var m in d.Materiais)
  {
   if(m is null||string.IsNullOrEmpty(m.StorageKey)||m.StorageKey.Length>200||m.StorageKey.Contains("..")||m.StorageKey.StartsWith('/')||m.StorageKey.Contains('\\')||m.StorageKey.Contains(':')||m.Tamanho<=0||m.Tamanho>25_000_000||(m.Hash is null||m.Hash.Length!=64)||!m.Hash.All(Uri.IsHexDigit))
    throw new EditorialException("PRESENCA_MATERIAL_INVALID");
   Texto(m.Autor,120);Texto(m.Licenca,200);Texto(m.TextoAlternativo,300);
   if(m.Tipo is not ("image/png" or "image/jpeg" or "image/webp"))throw new EditorialException("PRESENCA_MATERIAL_TYPE_INVALID");
  }
  // Plain text is intentional: HTML is encoded by the static renderer, never executed.
  return new(d.Manchete.Trim(),d.Corpo.Trim(),d.Fontes,d.ClassificacaoPrincipal.Trim(),d.ClassificacoesSecundarias,d.Tags,d.Materiais,d.AutorPublico.Trim());
 }
 public static string Transicao(string estado,string operation,int author,int actor,bool publicavel)
 {
  return (estado,operation) switch {
   ("Rascunho","SubmeterRevisao")=>"EmRevisao",
   ("EmRevisao","AprovarVersao") when author!=actor&&publicavel=>"Aprovada",
   ("EmRevisao","RejeitarVersao")=>"Rejeitada",
   _=>throw new EditorialException("PRESENCA_TRANSITION_DENIED",409) };
 }
 public static void Concorrencia(int current,int expected)
 {if(current!=expected)throw new EditorialException("PRESENCA_VERSION_CONFLICT",409);}
}
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive=true,UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow)]
[JsonSerializable(typeof(PedidoEditorial))]
[JsonSerializable(typeof(DadosEditorial))]
[JsonSerializable(typeof(ConteudoPublico))]
[JsonSerializable(typeof(ResultadoEditorial))]
[JsonSerializable(typeof(List<VersaoEditorial>))]
[JsonSerializable(typeof(List<EntregaEditorial>))]
[JsonSerializable(typeof(string[]))]
public partial class EditorialJson : JsonSerializerContext;
