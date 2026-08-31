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
    public interface IExperienciaPlanejamentoTransporteQueryRead 
    {
        public QueryModel ExperienciaPlanejamentoTransporteQuery(Command.Read.ExperienciaPlanejamentoTransporteReadCommand Command );
        public QueryModel ExperienciaPlanejamentoTransporteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExperienciaPlanejamentoTransporteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTipoQuery(int value );
        public QueryModel ExistsByReferenciaQuery(string value );
        public QueryModel ExistsByPedidoIdQuery(string value );
        public QueryModel ExistsByClienteIdQuery(string value );
        public QueryModel ExistsByMunicipioQuery(string value );
        public QueryModel ExistsByRegiaoQuery(string value );
        public QueryModel ExistsByRotaIdQuery(string value );
        public QueryModel ExistsByPesoQuery(Decimal value );
        public QueryModel ExistsByVolumeQuery(Decimal value );
        public QueryModel ExistsByObservacaoQuery(string value );
        public QueryModel ExistsByCriadoEmQuery(DateTime value );
        public QueryModel ExistsByCriadoPorQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTipoQuery(int value );
        public QueryModel FirstByReferenciaQuery(string value );
        public QueryModel FirstByPedidoIdQuery(string value );
        public QueryModel FirstByClienteIdQuery(string value );
        public QueryModel FirstByMunicipioQuery(string value );
        public QueryModel FirstByRegiaoQuery(string value );
        public QueryModel FirstByRotaIdQuery(string value );
        public QueryModel FirstByPesoQuery(Decimal value );
        public QueryModel FirstByVolumeQuery(Decimal value );
        public QueryModel FirstByObservacaoQuery(string value );
        public QueryModel FirstByCriadoEmQuery(DateTime value );
        public QueryModel FirstByCriadoPorQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration