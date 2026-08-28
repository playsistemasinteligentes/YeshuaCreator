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
    public interface IVisoesQueryRead 
    {
        public QueryModel VisoesQuery(Command.Read.VisoesReadCommand Command );
        public QueryModel VisoesVIS_PLANIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel VisoesCAB_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel VisoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel VisoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByVIS_IDQuery(int value );
        public QueryModel ExistsByVIS_PLANIDQuery(int value );
        public QueryModel ExistsByVIS_FORMULAQuery(string value );
        public QueryModel ExistsByCAB_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByVIS_IDQuery(int value );
        public QueryModel FirstByVIS_PLANIDQuery(int value );
        public QueryModel FirstByVIS_FORMULAQuery(string value );
        public QueryModel FirstByCAB_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration