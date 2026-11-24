using System.Text.Json;
using Command.Patterns.OutBox;
using Presenca.Editorial;
using Presenca.Distribution;
namespace Presenca.Tests;
public class ThreeOriginPortalTests
{
 [Fact] public void Public_hash_is_interoperable_with_the_python_producer_for_unicode_and_html()
 {var c=new ConteudoPublico("Título público 😀","Texto <p> com aspas \" e +",[],"Educação",[],[],[],"Autor");Assert.Equal("B75D002F73DB2A63ABDDF9A8DF709E1A7217489728B2832123B22D9F49ABA6A2",ContratosEditoriais.HashPublico(c));}
 [Fact] public async Task Three_public_origins_build_and_activate_one_static_release_with_receipts()
 {
  var manual=DistributionTests.Delivery("Portal","manual");
  EntregaPublica Origin(string type,string id,string contract)
  {
   var e=DistributionTests.Delivery("Portal",id);
   var input=new EntradaEditorialV1(e.IdentidadeId,"producer",id,"https://example.org/"+id,1,type,type=="aula",e.Conteudo,ContratosEditoriais.HashPublico(e.Conteudo));
   var validated=ContratosEditoriais.Validar(contract,JsonSerializer.Serialize(input,IntegracaoJson.Default.EntradaEditorialV1));
   return e with {Conteudo=validated.Conteudo};
  }
  var factory=Origin("pull_request","factory","MovimentoFabricaDisponivel.v1");
  var academy=Origin("aula","academy","SolicitacaoPublicacaoEducacional.v1");
  var repo=new PortalRepository{Items=[manual,factory,academy]};
  var options=DistributionTests.Options(academy);
  var root=Path.Combine(Path.GetTempPath(),"presenca-three-origins-"+Guid.NewGuid().ToString("N"));
  options.Canais["profile"].Origin="https://public.example.org/";options.Canais["profile"].ReleaseRoot=root;
  try
  {
   var strategy=new PortalDeliveryStrategy(options,repo);var result=await strategy.DeliverAsync(DistributionTests.Request(academy),default);
   var receipt=result!.result.Deserialize(IntegracaoJson.Default.ReciboDistribuicao)!;
   Assert.Equal(receipt.IdExterno,new DirectoryInfo(Path.Combine(root,"current")).LinkTarget);
   foreach(var article in repo.Items)Assert.True(File.Exists(Path.Combine(root,"current","noticias",article.PautaId,"index.html")));
   Assert.Equal(3,Directory.GetDirectories(Path.Combine(root,"current","noticias")).Length);
   var replay=await strategy.DeliverAsync(DistributionTests.Request(academy),default);Assert.Equal(receipt,replay!.result.Deserialize(IntegracaoJson.Default.ReciboDistribuicao));
  }
  finally{if(Directory.Exists(root))Directory.Delete(root,true);}
 }
 [Theory][InlineData("SolicitacaoPublicacaoEducacional.v1",false)][InlineData("unknown.v1",true)]
 public void Unapproved_or_unknown_educational_origins_cannot_enter(string contract,bool approved)
 {
  var e=DistributionTests.Delivery("Portal");var input=new EntradaEditorialV1(e.IdentidadeId,"producer","aula-1","https://example.org/aula/1",1,"aula",approved,e.Conteudo,ContratosEditoriais.HashPublico(e.Conteudo));
  Assert.Throws<EditorialException>(()=>ContratosEditoriais.Validar(contract,JsonSerializer.Serialize(input,IntegracaoJson.Default.EntradaEditorialV1)));
 }
 internal sealed class PortalRepository:IRepository.Write.IIdentidadePublicadoraWriteRepository
 {
  public List<EntregaPublica> Items {get;set;}=[];
  public List<EntregaPublica> ListarPortal(int t,EntregaPublica e,string s)=>Items;
  public ResultadoEditorial Executar(int t,int a,PedidoEditorial p,string s="")=>throw new NotSupportedException();
  public IReadOnlyList<TrabalhoEditorial> Entradas(string s)=>throw new NotSupportedException();
  public void ConfirmarEntrada(int id,string s,int saga)=>throw new NotSupportedException();
  public void RejeitarEntrada(int id,string s,string code)=>throw new NotSupportedException();
  public ResultadoEditorial RegistrarOrigem(int t,int a,string c,string p,string s)=>throw new NotSupportedException();
  public void PersistirExecucao(TrabalhoEditorial item,string scope)=>throw new NotSupportedException();
  public TrabalhoEditorial? RetirarSaida(string s)=>throw new NotSupportedException();
  public void ConcluirSaida(TrabalhoEditorial item,string s,string e,string c,ReciboDistribuicao? r,TimeSpan? delay=null,string natureza="Unknown")=>throw new NotSupportedException();
  public void ProvisionarInicial(int t,int a,string id,string name)=>throw new NotSupportedException();
 }
}
