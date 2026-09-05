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
    public interface ICTeRomaneioConsolidadoQueryRead 
    {
        public QueryModel CTeRomaneioConsolidadoQuery(Command.Read.CTeRomaneioConsolidadoReadCommand Command );
        public QueryModel CTeRomaneioConsolidadoEntradaOficialIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeRomaneioConsolidadoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeRomaneioConsolidadoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByEntradaOficialIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByRomaneioIdQuery(string value );
        public QueryModel ExistsByCargaIdQuery(string value );
        public QueryModel ExistsByConsolidadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByUFInicioQuery(string value );
        public QueryModel ExistsByUFFimQuery(string value );
        public QueryModel ExistsByMunicipioInicioCodigoIbgeQuery(string value );
        public QueryModel ExistsByMunicipioFimCodigoIbgeQuery(string value );
        public QueryModel ExistsByEmitenteDocumentoQuery(string value );
        public QueryModel ExistsByTomadorDocumentoQuery(string value );
        public QueryModel ExistsByRotaSnapshotJsonQuery(string value );
        public QueryModel ExistsByCargaSnapshotJsonQuery(string value );
        public QueryModel ExistsByPreferenciasFiscaisJsonQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByEntradaOficialIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByRomaneioIdQuery(string value );
        public QueryModel FirstByCargaIdQuery(string value );
        public QueryModel FirstByConsolidadoEmUtcQuery(DateTime value );
        public QueryModel FirstByUFInicioQuery(string value );
        public QueryModel FirstByUFFimQuery(string value );
        public QueryModel FirstByMunicipioInicioCodigoIbgeQuery(string value );
        public QueryModel FirstByMunicipioFimCodigoIbgeQuery(string value );
        public QueryModel FirstByEmitenteDocumentoQuery(string value );
        public QueryModel FirstByTomadorDocumentoQuery(string value );
        public QueryModel FirstByRotaSnapshotJsonQuery(string value );
        public QueryModel FirstByCargaSnapshotJsonQuery(string value );
        public QueryModel FirstByPreferenciasFiscaisJsonQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration