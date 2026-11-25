using Presenca.Editorial;
namespace IRepository.Read;
public partial interface IIdentidadePublicadoraReadRepository
{ ResultadoEditorial Consultar(int tenant,int actor,PedidoEditorial pedido); }
public partial interface IIdentidadePublicadoraReadRepository
{
 RepositoryInterfaces.Patterns.Worker.WorkerQueueHealthSnapshot SaudeDistribuicao();
 IReadOnlyList<RepositoryInterfaces.Patterns.Worker.WorkerQueueSickItem> ItensDoentesDistribuicao(int limit);
}
