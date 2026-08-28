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
    public interface IColaboradorQueryRead 
    {
        public QueryModel ColaboradorQuery(Command.Read.ColaboradorReadCommand Command );
        public QueryModel ColaboradorTURM_idQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ColaboradorTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ColaboradorUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByCOL_CPFQuery(string value );
        public QueryModel ExistsByCOL_NOMEQuery(string value );
        public QueryModel ExistsByCOL_NASCIMENTOQuery(DateTime value );
        public QueryModel ExistsByCOL_EMAILQuery(string value );
        public QueryModel ExistsByCOL_MATRICULAQuery(string value );
        public QueryModel ExistsByTURM_idQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByCOL_CPFQuery(string value );
        public QueryModel FirstByCOL_NOMEQuery(string value );
        public QueryModel FirstByCOL_NASCIMENTOQuery(DateTime value );
        public QueryModel FirstByCOL_EMAILQuery(string value );
        public QueryModel FirstByCOL_MATRICULAQuery(string value );
        public QueryModel FirstByTURM_idQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration