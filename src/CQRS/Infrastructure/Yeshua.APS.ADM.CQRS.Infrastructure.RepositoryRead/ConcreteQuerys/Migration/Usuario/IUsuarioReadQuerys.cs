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
    public interface IUsuarioQueryRead 
    {
        public QueryModel UsuarioQuery(Command.Read.UsuarioReadCommand Command );
        public QueryModel UsuarioTURM_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel UsuarioTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel UsuarioUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByUSE_NOMEQuery(string value );
        public QueryModel ExistsByUSE_EMAILQuery(string value );
        public QueryModel ExistsByUSE_SENHAQuery(string value );
        public QueryModel ExistsByTURM_IDQuery(string value );
        public QueryModel ExistsByUSE_ATIVOQuery(int value );
        public QueryModel ExistsByUSE_CODERPQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByUSE_NOMEQuery(string value );
        public QueryModel FirstByUSE_EMAILQuery(string value );
        public QueryModel FirstByUSE_SENHAQuery(string value );
        public QueryModel FirstByTURM_IDQuery(string value );
        public QueryModel FirstByUSE_ATIVOQuery(int value );
        public QueryModel FirstByUSE_CODERPQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration