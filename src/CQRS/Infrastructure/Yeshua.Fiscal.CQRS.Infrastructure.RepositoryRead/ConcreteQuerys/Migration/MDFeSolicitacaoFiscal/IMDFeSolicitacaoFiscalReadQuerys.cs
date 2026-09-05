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
    public interface IMDFeSolicitacaoFiscalQueryRead 
    {
        public QueryModel MDFeSolicitacaoFiscalQuery(Command.Read.MDFeSolicitacaoFiscalReadCommand Command );
        public QueryModel MDFeSolicitacaoFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeSolicitacaoFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByCargaIdQuery(string value );
        public QueryModel ExistsByAmbienteQuery(int value );
        public QueryModel ExistsByUFCarregamentoQuery(string value );
        public QueryModel ExistsByUFDescarregamentoQuery(string value );
        public QueryModel ExistsByPlacaVeiculoQuery(string value );
        public QueryModel ExistsByCondutorDocumentoQuery(string value );
        public QueryModel ExistsByDocumentosOriginariosJsonQuery(string value );
        public QueryModel ExistsByTransporteSnapshotJsonQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByCargaIdQuery(string value );
        public QueryModel FirstByAmbienteQuery(int value );
        public QueryModel FirstByUFCarregamentoQuery(string value );
        public QueryModel FirstByUFDescarregamentoQuery(string value );
        public QueryModel FirstByPlacaVeiculoQuery(string value );
        public QueryModel FirstByCondutorDocumentoQuery(string value );
        public QueryModel FirstByDocumentosOriginariosJsonQuery(string value );
        public QueryModel FirstByTransporteSnapshotJsonQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration