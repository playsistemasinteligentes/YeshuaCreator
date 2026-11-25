using Command.Patterns.OutBox;
using Presenca.Editorial;
using Presenca.Portal;
namespace Presenca.Distribution;
public sealed class PortalDeliveryStrategy(PresencaOptions options,IRepository.Write.IIdentidadePublicadoraWriteRepository repository):IOutboxDeliveryStrategy
{
 public int TransportType=>2;
 public Task<ExternalExecutionResult?> DeliverAsync(OutboxDeliveryRequest request,CancellationToken cancellationToken)
 {
  var current=(EntregaPublica)request.Message.Payload;
  var profile=PresencaDeliveryFactory.Perfil(options,request.TenantId,current);
  if(!Path.IsPathFullyQualified(profile.ReleaseRoot)||!RegrasEditoriais.UrlSegura(profile.Origin))throw new OutboxDeliveryException("PRESENCA_PORTAL_NOT_CONFIGURED","Portal indisponível.",false);
  var items=repository.ListarPortal(request.TenantId,current,request.Message.ProcessingScope??"");
  var assets=new Dictionary<string,byte[]>();long total=0;
  foreach(var m in items.SelectMany(i=>i.Conteudo.Materiais).DistinctBy(m=>m.Hash))
  {
   cancellationToken.ThrowIfCancellationRequested();
   if(!Path.IsPathFullyQualified(profile.MaterialRoot))throw new EditorialException("PRESENCA_MATERIAL_ROOT_REQUIRED");
   var path=Path.GetFullPath(Path.Combine(profile.MaterialRoot,m.StorageKey));
   if(!path.StartsWith(Path.TrimEndingDirectorySeparator(Path.GetFullPath(profile.MaterialRoot))+Path.DirectorySeparatorChar,StringComparison.Ordinal))throw new EditorialException("PRESENCA_MATERIAL_INVALID");
   for(var info=new FileInfo(path) as FileSystemInfo;info!=null;info=info is FileInfo f?f.Directory:((DirectoryInfo)info).Parent)
    if(info.LinkTarget!=null)throw new EditorialException("PRESENCA_MATERIAL_INVALID");
   var length=new FileInfo(path).Length;total+=length;
   if(length!=m.Tamanho||total>64_000_000)throw new EditorialException("PRESENCA_MATERIAL_CAPACITY");
   assets.Add(m.Hash,File.ReadAllBytes(path));
  }
  var articles=items.Select(e=>new ArtigoPortal(e.PautaId,e.Numero,e.Hash,e.Conteudo,e.PublicadoEm)).ToArray();
  var release=PortalEstatico.Construir(new Uri(profile.Origin),articles,assets);
  PortalEstatico.Preparar(profile.ReleaseRoot,release);
  cancellationToken.ThrowIfCancellationRequested();
  PortalEstatico.Ativar(profile.ReleaseRoot,release.Id,articles.ToDictionary(a=>a.Id+":"+a.Versao,a=>a.Hash));
  var receipt=new ReciboDistribuicao(release.Id,new Uri(new Uri(profile.Origin),"noticias/"+current.PautaId+"/").AbsoluteUri);
  return Task.FromResult<ExternalExecutionResult?>(PresencaDeliveryFactory.Sucesso(request,receipt));
 }
}
