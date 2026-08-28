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
    public interface IT_FavoritosQueryRead 
    {
        public QueryModel T_FavoritosQuery(Command.Read.T_FavoritosReadCommand Command );
        public QueryModel T_FavoritosUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_FavoritosID_INDICADORQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_FavoritosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_FavoritosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIDFAVORITOQuery(int value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByID_INDICADORQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIDFAVORITOQuery(int value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByID_INDICADORQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration