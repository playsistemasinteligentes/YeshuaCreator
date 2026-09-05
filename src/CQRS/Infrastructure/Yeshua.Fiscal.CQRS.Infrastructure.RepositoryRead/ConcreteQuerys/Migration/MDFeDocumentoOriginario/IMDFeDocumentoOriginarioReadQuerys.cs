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
    public interface IMDFeDocumentoOriginarioQueryRead 
    {
        public QueryModel MDFeDocumentoOriginarioQuery(Command.Read.MDFeDocumentoOriginarioReadCommand Command );
        public QueryModel MDFeDocumentoOriginarioMDFeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeDocumentoOriginarioDocumentoFiscalOriginarioIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeDocumentoOriginarioTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeDocumentoOriginarioUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMDFeSolicitacaoFiscalIdQuery(int value );
        public QueryModel ExistsByDocumentoFiscalOriginarioIdQuery(int value );
        public QueryModel ExistsByTipoDocumentoQuery(string value );
        public QueryModel ExistsByChaveAcessoQuery(string value );
        public QueryModel ExistsBySnapshotJsonQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMDFeSolicitacaoFiscalIdQuery(int value );
        public QueryModel FirstByDocumentoFiscalOriginarioIdQuery(int value );
        public QueryModel FirstByTipoDocumentoQuery(string value );
        public QueryModel FirstByChaveAcessoQuery(string value );
        public QueryModel FirstBySnapshotJsonQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration