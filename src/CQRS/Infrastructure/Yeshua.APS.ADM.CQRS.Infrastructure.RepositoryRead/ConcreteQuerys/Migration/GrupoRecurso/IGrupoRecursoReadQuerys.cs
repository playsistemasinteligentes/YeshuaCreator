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
    public interface IGrupoRecursoQueryRead 
    {
        public QueryModel GrupoRecursoQuery(Command.Read.GrupoRecursoReadCommand Command );
        public QueryModel GrupoRecursoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel GrupoRecursoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByGRE_IDQuery(string value );
        public QueryModel ExistsByGRE_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByGRE_IDQuery(string value );
        public QueryModel FirstByGRE_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration