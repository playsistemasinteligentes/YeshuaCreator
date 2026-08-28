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
    public interface ILogsDatabaseQueryRead 
    {
        public QueryModel LogsDatabaseQuery(Command.Read.LogsDatabaseReadCommand Command );
        public QueryModel LogsDatabaseUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel LogsDatabaseTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel LogsDatabaseUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByLOGS_IDQuery(int value );
        public QueryModel ExistsByLOGS_TABLEQuery(string value );
        public QueryModel ExistsByLOGS_KEYQuery(string value );
        public QueryModel ExistsByLOGS_KEY1Query(string value );
        public QueryModel ExistsByLOGS_KEY2Query(string value );
        public QueryModel ExistsByLOGS_KEY3Query(string value );
        public QueryModel ExistsByLOGS_KEY4Query(string value );
        public QueryModel ExistsByLOGS_COLUMNQuery(string value );
        public QueryModel ExistsByLOGS_BEFOREQuery(string value );
        public QueryModel ExistsByLOGS_AFTERQuery(string value );
        public QueryModel ExistsByLOGS_ACTIONQuery(string value );
        public QueryModel ExistsByLOGS_DATEQuery(DateTime value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByLOGS_ORIGEMQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByLOGS_IDQuery(int value );
        public QueryModel FirstByLOGS_TABLEQuery(string value );
        public QueryModel FirstByLOGS_KEYQuery(string value );
        public QueryModel FirstByLOGS_KEY1Query(string value );
        public QueryModel FirstByLOGS_KEY2Query(string value );
        public QueryModel FirstByLOGS_KEY3Query(string value );
        public QueryModel FirstByLOGS_KEY4Query(string value );
        public QueryModel FirstByLOGS_COLUMNQuery(string value );
        public QueryModel FirstByLOGS_BEFOREQuery(string value );
        public QueryModel FirstByLOGS_AFTERQuery(string value );
        public QueryModel FirstByLOGS_ACTIONQuery(string value );
        public QueryModel FirstByLOGS_DATEQuery(DateTime value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByLOGS_ORIGEMQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration