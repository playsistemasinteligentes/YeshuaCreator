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
    public interface IParamQueryRead 
    {
        public QueryModel ParamQuery(Command.Read.ParamReadCommand Command );
        public QueryModel ParamTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ParamUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPAR_IDQuery(string value );
        public QueryModel ExistsByPAR_DESCRICAOQuery(string value );
        public QueryModel ExistsByPAR_VALOR_SQuery(string value );
        public QueryModel ExistsByPAR_VALOR_NQuery(Decimal value );
        public QueryModel ExistsByPAR_VALOR_DQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByPAR_IDQuery(string value );
        public QueryModel FirstByPAR_DESCRICAOQuery(string value );
        public QueryModel FirstByPAR_VALOR_SQuery(string value );
        public QueryModel FirstByPAR_VALOR_NQuery(Decimal value );
        public QueryModel FirstByPAR_VALOR_DQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration