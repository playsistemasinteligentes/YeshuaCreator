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
    public interface IGrupoMaquinaQueryRead 
    {
        public QueryModel GrupoMaquinaQuery(Command.Read.GrupoMaquinaReadCommand Command );
        public QueryModel GrupoMaquinaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel GrupoMaquinaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByGMA_IDQuery(string value );
        public QueryModel ExistsByGMA_DESCRICAOQuery(string value );
        public QueryModel ExistsByGMA_STATUSQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByGMA_IDQuery(string value );
        public QueryModel FirstByGMA_DESCRICAOQuery(string value );
        public QueryModel FirstByGMA_STATUSQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration