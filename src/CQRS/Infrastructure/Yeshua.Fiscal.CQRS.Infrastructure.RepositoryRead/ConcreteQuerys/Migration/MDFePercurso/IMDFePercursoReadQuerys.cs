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
    public interface IMDFePercursoQueryRead 
    {
        public QueryModel MDFePercursoQuery(Command.Read.MDFePercursoReadCommand Command );
        public QueryModel MDFePercursoMDFeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFePercursoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFePercursoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMDFeSolicitacaoFiscalIdQuery(int value );
        public QueryModel ExistsByUFQuery(string value );
        public QueryModel ExistsByOrdemQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMDFeSolicitacaoFiscalIdQuery(int value );
        public QueryModel FirstByUFQuery(string value );
        public QueryModel FirstByOrdemQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration