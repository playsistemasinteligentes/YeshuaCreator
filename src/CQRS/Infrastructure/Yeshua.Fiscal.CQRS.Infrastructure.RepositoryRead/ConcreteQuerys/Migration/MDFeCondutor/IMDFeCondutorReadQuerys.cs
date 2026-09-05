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
    public interface IMDFeCondutorQueryRead 
    {
        public QueryModel MDFeCondutorQuery(Command.Read.MDFeCondutorReadCommand Command );
        public QueryModel MDFeCondutorMDFeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeCondutorTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeCondutorUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMDFeSolicitacaoFiscalIdQuery(int value );
        public QueryModel ExistsByNomeQuery(string value );
        public QueryModel ExistsByDocumentoQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMDFeSolicitacaoFiscalIdQuery(int value );
        public QueryModel FirstByNomeQuery(string value );
        public QueryModel FirstByDocumentoQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration