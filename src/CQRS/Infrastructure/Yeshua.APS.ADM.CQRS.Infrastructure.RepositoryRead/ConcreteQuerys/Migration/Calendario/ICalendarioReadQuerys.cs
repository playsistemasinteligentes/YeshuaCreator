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
    public interface ICalendarioQueryRead 
    {
        public QueryModel CalendarioQuery(Command.Read.CalendarioReadCommand Command );
        public QueryModel CalendarioTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CalendarioUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByCAL_IDQuery(int value );
        public QueryModel ExistsByCAL_DESCRICAOQuery(string value );
        public QueryModel ExistsByCAL_DIVIDE_DIA_EMQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByCAL_IDQuery(int value );
        public QueryModel FirstByCAL_DESCRICAOQuery(string value );
        public QueryModel FirstByCAL_DIVIDE_DIA_EMQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration