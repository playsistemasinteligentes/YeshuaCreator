namespace Presenca.Distribution;
public sealed class PresencaOptions
{
 public string AcademiaBaseUrl {get;set;}="";
 public bool Enabled {get;set;}
 public Dictionary<string,CanalProfile> Canais {get;set;}=new(StringComparer.Ordinal);
}
public sealed class CanalProfile
{
 public int TenantId {get;set;}
 public string IdentidadeId {get;set;}="";
 public string Plataforma {get;set;}="";
 public string Destino {get;set;}="";
 public string Token {get;set;}="";
 public string RepositoryId {get;set;}="";
 public string CategoryId {get;set;}="";
 public string Origin {get;set;}="";
 public string ReleaseRoot {get;set;}="";
 public string MaterialRoot {get;set;}="";
}
