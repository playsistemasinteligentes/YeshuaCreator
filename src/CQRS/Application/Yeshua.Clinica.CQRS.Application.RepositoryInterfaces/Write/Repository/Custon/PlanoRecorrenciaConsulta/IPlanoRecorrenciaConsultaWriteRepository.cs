using Clinica.Atendimentos;
namespace IRepository.Write;
public partial interface IPlanoRecorrenciaConsultaWriteRepository
{
    ResultadoRecorrencia Prever(int tenant, int actor, PedidoRecorrencia pedido, DateTime agoraUtc);
    ResultadoRecorrencia Confirmar(int tenant, int actor, string planoId, bool revisado, IReadOnlyList<EscolhaRecorrencia> escolhas, DateTime agoraUtc);
}
