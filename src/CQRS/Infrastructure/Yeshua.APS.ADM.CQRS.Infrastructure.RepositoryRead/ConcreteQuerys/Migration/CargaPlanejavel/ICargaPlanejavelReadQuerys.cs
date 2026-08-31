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
    public interface ICargaPlanejavelQueryRead 
    {
        public QueryModel CargaPlanejavelQuery(Command.Read.CargaPlanejavelReadCommand Command );
        public QueryModel ExistsByCargaIdQuery(string value );
        public QueryModel ExistsByStatusQuery(string value );
        public QueryModel ExistsByTransportadoraIdQuery(string value );
        public QueryModel ExistsByVeiculoIdQuery(string value );
        public QueryModel ExistsByTipoVeiculoIdQuery(int value );
        public QueryModel ExistsByPesoTeoricoQuery(Decimal value );
        public QueryModel ExistsByVolumeTeoricoQuery(Decimal value );
        public QueryModel ExistsByInicioJanelaEmbarqueQuery(DateTime value );
        public QueryModel ExistsByFimJanelaEmbarqueQuery(DateTime value );
        public QueryModel ExistsByEmbarqueAlvoQuery(DateTime value );
        public QueryModel ExistsByQuantidadePedidosQuery(int value );
        public QueryModel ExistsByAlertasResumoQuery(string value );
        public QueryModel FirstByCargaIdQuery(string value );
        public QueryModel FirstByStatusQuery(string value );
        public QueryModel FirstByTransportadoraIdQuery(string value );
        public QueryModel FirstByVeiculoIdQuery(string value );
        public QueryModel FirstByTipoVeiculoIdQuery(int value );
        public QueryModel FirstByPesoTeoricoQuery(Decimal value );
        public QueryModel FirstByVolumeTeoricoQuery(Decimal value );
        public QueryModel FirstByInicioJanelaEmbarqueQuery(DateTime value );
        public QueryModel FirstByFimJanelaEmbarqueQuery(DateTime value );
        public QueryModel FirstByEmbarqueAlvoQuery(DateTime value );
        public QueryModel FirstByQuantidadePedidosQuery(int value );
        public QueryModel FirstByAlertasResumoQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration