using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Presenca.Editorial;
namespace Presenca.Portal;
public sealed record ArtigoPortal(string Id,int Versao,string Hash,ConteudoPublico Conteudo,DateTimeOffset PublicadoEm);
public sealed record ReferenciaPortal(string Id,int Versao,string Hash);
public sealed record ManifestoPortal(Dictionary<string,string> Arquivos,ReferenciaPortal[] Artigos);
public sealed record ReleasePortal(string Id,ManifestoPortal Manifesto,Dictionary<string,byte[]> Arquivos);
public sealed record SchemaArticle(string context,string type,string headline,string datePublished,string url,string author);
public static class PortalEstatico
{
 [System.Runtime.InteropServices.DllImport("libc",EntryPoint="rename",SetLastError=true)]
 private static extern int Rename(string source,string destination);
 private static string Html(string text)=>WebUtility.HtmlEncode(text);
 private static readonly UTF8Encoding Utf8=new(false);
 public static ReleasePortal Construir(Uri origem,IReadOnlyCollection<ArtigoPortal> artigos,IReadOnlyDictionary<string,byte[]> materiais,IReadOnlyDictionary<string,string>? redirecionamentos=null)
 {
  if(!RegrasEditoriais.UrlSegura(origem.AbsoluteUri)||origem.AbsolutePath!="/"||origem.Query.Length>0||origem.Fragment.Length>0)throw new EditorialException("PRESENCA_PORTAL_ORIGIN_INVALID");
  if(artigos.Count>1000||artigos.Select(a=>a.Id).Distinct().Count()!=artigos.Count)throw new EditorialException("PRESENCA_PORTAL_ARTICLES_INVALID");
  var files=new Dictionary<string,byte[]>(StringComparer.Ordinal);
  void Put(string path,string value)=>files.Add(path,Utf8.GetBytes(value));
  var ordered=artigos.OrderBy(a=>a.Id,StringComparer.Ordinal).ToArray();
  var list=new StringBuilder();
  foreach(var a in ordered)
  {
   RegrasEditoriais.ValidarId(a.Id);
   if(a.Versao<1||a.Hash!=RegrasEditoriais.Hash(JsonSerializer.Serialize(a.Conteudo,EditorialJson.Default.ConteudoPublico)))throw new EditorialException("PRESENCA_PORTAL_HASH_INVALID");
   var path=$"noticias/{a.Id}/index.html";
   var canonical=new Uri(origem,$"noticias/{a.Id}/").AbsoluteUri;
   var body=new StringBuilder($"<article><h1>{Html(a.Conteudo.Manchete)}</h1><p>Por {Html(a.Conteudo.AutorPublico)}</p><time datetime=\"{a.PublicadoEm.ToUniversalTime():O}\">{a.PublicadoEm.ToUniversalTime():yyyy-MM-dd}</time>");
   foreach(var paragraph in a.Conteudo.Corpo.Replace("\r","").Split('\n',StringSplitOptions.RemoveEmptyEntries))body.Append($"<p>{Html(paragraph)}</p>");
   foreach(var m in a.Conteudo.Materiais)
   {
    if(!materiais.TryGetValue(m.Hash,out var bytes)||bytes.LongLength!=m.Tamanho)throw new EditorialException("PRESENCA_PORTAL_MATERIAL_MISSING");
    var hash=Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(bytes));
    if(!hash.Equals(m.Hash,StringComparison.OrdinalIgnoreCase))throw new EditorialException("PRESENCA_PORTAL_MATERIAL_HASH_INVALID");
    var ext=m.Tipo switch {"image/png"=>"png","image/jpeg"=>"jpg","image/webp"=>"webp",_=>throw new EditorialException("PRESENCA_MATERIAL_TYPE_INVALID")};
    if(!ImagemValida(bytes,ext))throw new EditorialException("PRESENCA_PORTAL_MATERIAL_FORMAT_INVALID");
    var asset=$"assets/{hash}.{ext}";files.TryAdd(asset,bytes.ToArray());
    body.Append($"<figure><img src=\"/{asset}\" alt=\"{Html(m.TextoAlternativo)}\" loading=\"lazy\"><figcaption>{Html(m.Autor)} · {Html(m.Licenca)}</figcaption></figure>");
   }
   if(a.Conteudo.Fontes.Length>0)
   {
    body.Append("<h2>Fontes</h2><ul>");
    foreach(var url in a.Conteudo.Fontes)
    {if(!RegrasEditoriais.UrlSegura(url))throw new EditorialException("PRESENCA_SOURCE_INVALID");body.Append($"<li><a rel=\"noopener noreferrer\" href=\"{Html(url)}\">{Html(url)}</a></li>");}
    body.Append("</ul>");
   }
   body.Append("</article>");
   var schema=JsonSerializer.Serialize(new SchemaArticle("https://schema.org","Article",a.Conteudo.Manchete,a.PublicadoEm.ToUniversalTime().ToString("O"),canonical,a.Conteudo.AutorPublico),PortalJson.Default.SchemaArticle)
    .Replace("\"context\":","\"@context\":").Replace("\"type\":","\"@type\":");
   Put(path,Pagina(a.Conteudo.Manchete,canonical,body.ToString(),schema));
   list.Append($"<li><a href=\"/noticias/{a.Id}/\">{Html(a.Conteudo.Manchete)}</a></li>");
  }
  Put("index.html",Pagina("Play Sistemas",origem.AbsoluteUri,$"<h1>Play Sistemas</h1><p>Software e engenharia de sistemas.</p><h2>Artigos e notícias</h2><ul>{list}</ul>"));
  Put("yeshua/index.html",Pagina("Yeshua",new Uri(origem,"yeshua/").AbsoluteUri,"<h1>Yeshua</h1><p>Fábrica de software orientada por uma metalinguagem de domínio.</p><a href=\"/produtos/\">Produtos</a>"));
  Put("produtos/index.html",Pagina("Produtos",new Uri(origem,"produtos/").AbsoluteUri,"<h1>Produtos</h1><a href=\"/yeshua/\">Engenharia Yeshua</a>"));
  if(redirecionamentos!=null)
   foreach(var (from,to) in redirecionamentos.OrderBy(p=>p.Key,StringComparer.Ordinal))
   {
    if(!System.Text.RegularExpressions.Regex.IsMatch(from,@"^/[a-z0-9/-]{1,199}/$")||from.Contains("//")||from.Contains("..")||!to.StartsWith('/')||to.Contains("..")||!to.EndsWith('/')||!files.ContainsKey(to.TrimStart('/')+"index.html"))throw new EditorialException("PRESENCA_PORTAL_REDIRECT_INVALID");
    var redirectPath=from.TrimStart('/')+"index.html";
    if(files.ContainsKey(redirectPath))throw new EditorialException("PRESENCA_PORTAL_REDIRECT_COLLISION");
    var destination=new Uri(origem,to).AbsoluteUri;
    Put(redirectPath,Pagina("Página movida",destination,$"<h1>Página movida</h1><a href=\"{Html(to)}\">Abrir endereço permanente</a>").Replace("</head>",$"<meta http-equiv=\"refresh\" content=\"0;url={Html(to)}\"></head>"));
   }
  var ns=XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");
  var paths=new[]{"","yeshua/","produtos/"}.Concat(ordered.Select(a=>$"noticias/{a.Id}/"));
  Put("sitemap.xml",new XDocument(new XElement(ns+"urlset",paths.Select(p=>new XElement(ns+"url",new XElement(ns+"loc",new Uri(origem,p).AbsoluteUri))))).ToString());
  Put("robots.txt",$"User-agent: *\nAllow: /\nSitemap: {new Uri(origem,"sitemap.xml").AbsoluteUri}\n");
  var manifest=new ManifestoPortal(files.OrderBy(x=>x.Key,StringComparer.Ordinal).ToDictionary(x=>x.Key,x=>Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(x.Value))),ordered.Select(a=>new ReferenciaPortal(a.Id,a.Versao,a.Hash)).ToArray());
  var manifestText=JsonSerializer.Serialize(manifest,PortalJson.Default.ManifestoPortal);
  var id=RegrasEditoriais.Hash(manifestText);
  Put("manifest.json",manifestText);return new(id,manifest,files);
 }
 private static bool ImagemValida(byte[] bytes,string ext)=>ext switch {
  "png"=>bytes.AsSpan().StartsWith(new byte[]{137,80,78,71,13,10,26,10}),
  "jpg"=>bytes.Length>3&&bytes[0]==255&&bytes[1]==216&&bytes[2]==255,
  "webp"=>bytes.Length>12&&Encoding.ASCII.GetString(bytes,0,4)=="RIFF"&&Encoding.ASCII.GetString(bytes,8,4)=="WEBP",_=>false};
 private static string Pagina(string title,string canonical,string body,string schema="")=>$"<!doctype html><html lang=\"pt-BR\"><head><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width,initial-scale=1\"><title>{Html(title)} · Play Sistemas</title><meta name=\"description\" content=\"{Html(title)}\"><link rel=\"canonical\" href=\"{Html(canonical)}\"><meta property=\"og:title\" content=\"{Html(title)}\"><meta property=\"og:url\" content=\"{Html(canonical)}\"><meta property=\"og:type\" content=\"article\"><meta name=\"twitter:card\" content=\"summary\">{(schema.Length>0?$"<script type=\"application/ld+json\">{schema}</script>":"")}</head><body><a href=\"#conteudo\">Pular para o conteúdo</a><header><nav aria-label=\"Principal\"><a href=\"/\">Play Sistemas</a> · <a href=\"/yeshua/\">Yeshua</a> · <a href=\"/produtos/\">Produtos</a></nav></header><main id=\"conteudo\">{body}</main></body></html>\n";
 // Writes only a new immutable release; activation remains a separate explicit action.
 public static string Preparar(string root,ReleasePortal release)
 {
  RegrasEditoriais.ValidarId(release.Id);Directory.CreateDirectory(root);
  var final=Path.Combine(root,release.Id);
  if(Directory.Exists(final)){Verificar(final,release.Id);return final;}
  var staging=Path.Combine(root,".preparing-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(staging);
  try
  {
   foreach(var (path,bytes) in release.Arquivos)
   {
    if(path.Contains("..")||path.Contains('\\')||Path.IsPathRooted(path))throw new EditorialException("PRESENCA_PORTAL_PATH_INVALID");
    var target=Path.Combine(staging,path);Directory.CreateDirectory(Path.GetDirectoryName(target)!);File.WriteAllBytes(target,bytes);
   }
   Verificar(staging,release.Id);
   try {Directory.Move(staging,final);}
   catch(IOException) when(Directory.Exists(final)){Verificar(final,release.Id);}
   return final;
  }
  finally{if(Directory.Exists(staging))Directory.Delete(staging,true);}
 }
 private static ManifestoPortal Verificar(string directory,string id)
 {
  var text=File.ReadAllText(Path.Combine(directory,"manifest.json"));
  if(RegrasEditoriais.Hash(text)!=id)throw new EditorialException("PRESENCA_PORTAL_MANIFEST_INVALID");
  var manifest=JsonSerializer.Deserialize(text,PortalJson.Default.ManifestoPortal)!;
  var actual=Directory.GetFiles(directory,"*",SearchOption.AllDirectories).Select(p=>Path.GetRelativePath(directory,p)).Order(StringComparer.Ordinal);
  if(!actual.SequenceEqual(manifest.Arquivos.Keys.Append("manifest.json").Order(StringComparer.Ordinal)))throw new EditorialException("PRESENCA_PORTAL_RELEASE_CHANGED");
  foreach(var (file,hash) in manifest.Arquivos)
  {
   if(file.Contains("..")||file.Contains('\\')||Path.IsPathRooted(file))throw new EditorialException("PRESENCA_PORTAL_PATH_INVALID");
   var path=Path.Combine(directory,file);
   if(new FileInfo(path).LinkTarget!=null||Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(path)))!=hash)throw new EditorialException("PRESENCA_PORTAL_RELEASE_CHANGED");
  }
  return manifest;
 }
 public static void Ativar(string root,string id,IReadOnlyDictionary<string,string> aprovadas)
 {
  if(!OperatingSystem.IsLinux())throw new PlatformNotSupportedException("Atomic activation requires the verified Linux filesystem path.");
  RegrasEditoriais.ValidarId(id);
  using var gate=new FileStream(Path.Combine(root,".activation.lock"),FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.None);
  var dir=Path.Combine(root,id);
  if(new DirectoryInfo(dir).LinkTarget!=null)throw new EditorialException("PRESENCA_PORTAL_PATH_INVALID");
  var manifest=Verificar(dir,id);
  foreach(var article in manifest.Artigos)
   if(!aprovadas.TryGetValue(article.Id+":"+article.Versao,out var hash)||hash!=article.Hash)throw new EditorialException("PRESENCA_PORTAL_APPROVAL_REVOKED",409);
  var link=Path.Combine(root,".activate-"+Guid.NewGuid().ToString("N"));
  Directory.CreateSymbolicLink(link,id);
  try{if(Rename(link,Path.Combine(root,"current"))!=0)throw new System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastPInvokeError());}
  finally{if(new DirectoryInfo(link).LinkTarget!=null)File.Delete(link);}
 }
}
[JsonSerializable(typeof(ManifestoPortal))]
[JsonSerializable(typeof(SchemaArticle))]
public partial class PortalJson : JsonSerializerContext;
