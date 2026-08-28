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
    public interface IIndicadoresDimencoesQueryRead 
    {
        public QueryModel IndicadoresDimencoesQuery(Command.Read.IndicadoresDimencoesReadCommand Command );
        public QueryModel IndicadoresDimencoesIND_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel IndicadoresDimencoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel IndicadoresDimencoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByDIM_IDQuery(int value );
        public QueryModel ExistsByIND_IDQuery(int value );
        public QueryModel ExistsByDIM_DESCRICAOQuery(string value );
        public QueryModel ExistsByDIM_SQLQuery(string value );
        public QueryModel ExistsByDIM_CONEXAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByDIM_IDQuery(int value );
        public QueryModel FirstByIND_IDQuery(int value );
        public QueryModel FirstByDIM_DESCRICAOQuery(string value );
        public QueryModel FirstByDIM_SQLQuery(string value );
        public QueryModel FirstByDIM_CONEXAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration