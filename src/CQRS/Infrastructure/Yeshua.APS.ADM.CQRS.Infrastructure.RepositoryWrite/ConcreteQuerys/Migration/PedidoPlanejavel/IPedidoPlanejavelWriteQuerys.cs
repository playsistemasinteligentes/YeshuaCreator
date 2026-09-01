// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IPedidoPlanejavelQueryWrite 
     {
        public QueryModel InserirPedidoPlanejavelQuery(IPedidoPlanejavelEntity PedidoPlanejavel);
        public QueryModel UpdatePedidoPlanejavelQuery(IPedidoPlanejavelEntity PedidoPlanejavel);
        QueryModel UpdateClienteId(string pedidoid, string value);
        QueryModel UpdateClienteNome(string pedidoid, string value);
        QueryModel UpdateEstado(string pedidoid, string value);
        QueryModel UpdateMunicipio(string pedidoid, string value);
        QueryModel UpdateRegiao(string pedidoid, string value);
        QueryModel UpdateBairro(string pedidoid, string value);
        QueryModel UpdateRotaId(string pedidoid, string value);
        QueryModel UpdateEmbarqueAlvo(string pedidoid, DateTime value);
        QueryModel UpdateDataEntregaDe(string pedidoid, DateTime value);
        QueryModel UpdateDataEntregaAte(string pedidoid, DateTime value);
        QueryModel UpdatePeso(string pedidoid, Decimal value);
        QueryModel UpdateVolume(string pedidoid, Decimal value);
        QueryModel UpdateSaldoAExpedir(string pedidoid, Decimal value);
        QueryModel UpdateStatus(string pedidoid, string value);
        QueryModel UpdateCargaAtualId(string pedidoid, string value);
        QueryModel UpdateVersaoPlanejamento(string pedidoid, string value);
        QueryModel UpdateAlertasResumo(string pedidoid, string value);
        public QueryModel DeletePedidoPlanejavelQuery(IPedidoPlanejavelEntity PedidoPlanejavel);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration