using Presenca.Portal;
using Presenca.Editorial;
using System.Text;
using System.Text.Json;
namespace Presenca.Tests;
public class PortalTests
{
 private static ArtigoPortal Article(string id,string title="Uma notícia")
 {var data=EditorialTests.Example();data.Manchete=title;var content=RegrasEditoriais.Conteudo(data);return new(id,1,RegrasEditoriais.Hash(JsonSerializer.Serialize(content,EditorialJson.Default.ConteudoPublico)),content,DateTimeOffset.Parse("2026-11-24T10:00:00Z"));}
 private static ReleasePortal Release(params ArtigoPortal[] articles)=>PortalEstatico.Construir(new("https://public.example.org/"),articles,new Dictionary<string,byte[]>());
 [Fact] public void Static_build_is_deterministic_with_canonical_links_and_no_script_injection()
 {var a=Article(new string('A',64),"<script>alert('x')</script>");var r1=Release(a);var r2=Release(a);Assert.Equal(r1.Id,r2.Id);var html=Encoding.UTF8.GetString(r1.Arquivos[$"noticias/{a.Id}/index.html"]);Assert.Contains("&lt;script&gt;",html);Assert.DoesNotContain("<script>alert",html);Assert.Contains("rel=\"canonical\"",html);Assert.Contains("application/ld+json",html);Assert.Contains("@context",html);Assert.Contains("sitemap.xml",Encoding.UTF8.GetString(r1.Arquivos["robots.txt"]));}
 [Fact] public void Redirects_only_target_existing_local_pages()
 {var a=Article(new string('A',64));var r=PortalEstatico.Construir(new("https://public.example.org/"),[a],new Dictionary<string,byte[]>(),new Dictionary<string,string>{{"/antigo/","/noticias/"+a.Id+"/"}});Assert.Contains("http-equiv=\"refresh\"",Encoding.UTF8.GetString(r.Arquivos["antigo/index.html"]));Assert.Throws<EditorialException>(()=>PortalEstatico.Construir(new("https://public.example.org/"),[a],new Dictionary<string,byte[]>(),new Dictionary<string,string>{{"/antigo/","https://evil.example/"}}));}
 [Fact] public void Corrupt_snapshot_is_not_rendered()
 {var a=Article(new string('A',64)) with {Hash=new string('0',64)};Assert.Throws<EditorialException>(()=>Release(a));}
 [Fact] public void Approval_is_revalidated_on_activation_and_rollback()
 {
  var root=Path.Combine(Path.GetTempPath(),"presenca-test-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(root);
  try
  {
   var a=Article(new string('A',64));var b=Article(new string('B',64));var r1=Release(a);var r2=Release(a,b);
   PortalEstatico.Preparar(root,r1);PortalEstatico.Preparar(root,r2);
   var allowed=new Dictionary<string,string>{{a.Id+":1",a.Hash},{b.Id+":1",b.Hash}};
   PortalEstatico.Ativar(root,r1.Id,allowed);Assert.Equal(r1.Id,new DirectoryInfo(Path.Combine(root,"current")).LinkTarget);
   PortalEstatico.Ativar(root,r2.Id,allowed);Assert.Equal(r2.Id,new DirectoryInfo(Path.Combine(root,"current")).LinkTarget);
   PortalEstatico.Ativar(root,r1.Id,allowed);Assert.Equal(r1.Id,new DirectoryInfo(Path.Combine(root,"current")).LinkTarget);
   allowed.Clear();Assert.Throws<EditorialException>(()=>PortalEstatico.Ativar(root,r2.Id,allowed));Assert.Equal(r1.Id,new DirectoryInfo(Path.Combine(root,"current")).LinkTarget);
   File.AppendAllText(Path.Combine(root,r2.Id,"index.html"),"tampered");Assert.Throws<EditorialException>(()=>PortalEstatico.Ativar(root,r2.Id,new Dictionary<string,string>{{a.Id+":1",a.Hash},{b.Id+":1",b.Hash}}));
  }
  finally{Directory.Delete(root,true);}
 }
 [Fact] public void Every_internal_link_points_to_a_built_page()
 {var release=Release(Article(new string('A',64)));foreach(var (path,bytes) in release.Arquivos.Where(p=>p.Key.EndsWith(".html"))){var html=Encoding.UTF8.GetString(bytes);foreach(System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(html,"href=\"(/[^\"]*)\"")){var href=m.Groups[1].Value;Assert.True(release.Arquivos.ContainsKey(href.TrimStart('/')+"index.html"),$"{path}: {href}");}}}
}
