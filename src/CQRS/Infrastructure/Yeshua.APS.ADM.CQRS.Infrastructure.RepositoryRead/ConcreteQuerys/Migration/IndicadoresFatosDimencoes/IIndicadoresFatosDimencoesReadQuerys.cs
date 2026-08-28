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
    public interface IIndicadoresFatosDimencoesQueryRead 
    {
        public QueryModel IndicadoresFatosDimencoesQuery(Command.Read.IndicadoresFatosDimencoesReadCommand Command );
        public QueryModel IndicadoresFatosDimencoesIND_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel IndicadoresFatosDimencoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel IndicadoresFatosDimencoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByFAT_IDQuery(string value );
        public QueryModel ExistsByIND_IDQuery(int value );
        public QueryModel ExistsByDIM_IDQuery(int value );
        public QueryModel ExistsByFAT_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByFAT_IDQuery(string value );
        public QueryModel FirstByIND_IDQuery(int value );
        public QueryModel FirstByDIM_IDQuery(int value );
        public QueryModel FirstByFAT_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration