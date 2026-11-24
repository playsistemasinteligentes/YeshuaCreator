using Presenca.Editorial;
namespace IRepository.Write;
public partial interface IIdentidadePublicadoraWriteRepository
{
 ResultadoEditorial Executar(int tenant,int actor,PedidoEditorial pedido,string processingScope="");
 IReadOnlyList<TrabalhoEditorial> Entradas(string scope);
 void ConfirmarEntrada(int id,string scope,int sagaId);
 void RejeitarEntrada(int id,string scope,string code);
 ResultadoEditorial RegistrarOrigem(int tenant,int actor,string contrato,string payload,string scope);
 void PersistirExecucao(TrabalhoEditorial item,string scope);
 TrabalhoEditorial? RetirarSaida(string scope);
 void ConcluirSaida(TrabalhoEditorial item,string scope,string estado,string codigo,ReciboDistribuicao? recibo,TimeSpan? atraso=null,string natureza="Unknown");
 List<EntregaPublica> ListarPortal(int tenant,EntregaPublica atual,string scope);
 void ProvisionarInicial(int tenant,int actor,string identidade,string nome);
}
