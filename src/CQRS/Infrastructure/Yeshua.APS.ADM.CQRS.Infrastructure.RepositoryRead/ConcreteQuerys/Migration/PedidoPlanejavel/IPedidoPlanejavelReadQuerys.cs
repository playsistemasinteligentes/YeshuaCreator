// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
namespace IQuery.Read
{
    public interface IPedidoPlanejavelQueryRead 
    {
        public QueryModel PedidoPlanejavelQuery(Command.Read.PedidoPlanejavelReadCommand Command );
        public QueryModel ExistsByPedidoIdQuery(string value );
        public QueryModel ExistsByClienteIdQuery(string value );
        public QueryModel ExistsByClienteNomeQuery(string value );
        public QueryModel ExistsByEstadoQuery(string value );
        public QueryModel ExistsByMunicipioQuery(string value );
        public QueryModel ExistsByRegiaoQuery(string value );
        public QueryModel ExistsByBairroQuery(string value );
        public QueryModel ExistsByRotaIdQuery(string value );
        public QueryModel ExistsByEmbarqueAlvoQuery(DateTime value );
        public QueryModel ExistsByDataEntregaDeQuery(DateTime value );
        public QueryModel ExistsByDataEntregaAteQuery(DateTime value );
        public QueryModel ExistsByPesoQuery(Decimal value );
        public QueryModel ExistsByVolumeQuery(Decimal value );
        public QueryModel ExistsBySaldoAExpedirQuery(Decimal value );
        public QueryModel ExistsByStatusQuery(string value );
        public QueryModel ExistsByCargaAtualIdQuery(string value );
        public QueryModel ExistsByVersaoPlanejamentoQuery(string value );
        public QueryModel ExistsByAlertasResumoQuery(string value );
        public QueryModel FirstByPedidoIdQuery(string value );
        public QueryModel FirstByClienteIdQuery(string value );
        public QueryModel FirstByClienteNomeQuery(string value );
        public QueryModel FirstByEstadoQuery(string value );
        public QueryModel FirstByMunicipioQuery(string value );
        public QueryModel FirstByRegiaoQuery(string value );
        public QueryModel FirstByBairroQuery(string value );
        public QueryModel FirstByRotaIdQuery(string value );
        public QueryModel FirstByEmbarqueAlvoQuery(DateTime value );
        public QueryModel FirstByDataEntregaDeQuery(DateTime value );
        public QueryModel FirstByDataEntregaAteQuery(DateTime value );
        public QueryModel FirstByPesoQuery(Decimal value );
        public QueryModel FirstByVolumeQuery(Decimal value );
        public QueryModel FirstBySaldoAExpedirQuery(Decimal value );
        public QueryModel FirstByStatusQuery(string value );
        public QueryModel FirstByCargaAtualIdQuery(string value );
        public QueryModel FirstByVersaoPlanejamentoQuery(string value );
        public QueryModel FirstByAlertasResumoQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration