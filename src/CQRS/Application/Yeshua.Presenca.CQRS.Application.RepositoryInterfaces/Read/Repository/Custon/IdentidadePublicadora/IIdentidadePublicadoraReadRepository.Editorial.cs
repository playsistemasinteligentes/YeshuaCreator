using Presenca.Editorial;
namespace IRepository.Read;
public partial interface IIdentidadePublicadoraReadRepository
{ ResultadoEditorial Consultar(int tenant,int actor,PedidoEditorial pedido); }
