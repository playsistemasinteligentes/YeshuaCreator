using Presenca.Editorial;
namespace IRepository.Write;
public partial interface IIdentidadePublicadoraWriteRepository
{ ResultadoEditorial Executar(int tenant,int actor,PedidoEditorial pedido); }
