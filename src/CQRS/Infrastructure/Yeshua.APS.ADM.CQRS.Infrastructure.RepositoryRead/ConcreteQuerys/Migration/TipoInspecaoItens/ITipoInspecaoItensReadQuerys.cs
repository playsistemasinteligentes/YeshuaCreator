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
    public interface ITipoInspecaoItensQueryRead 
    {
        public QueryModel TipoInspecaoItensQuery(Command.Read.TipoInspecaoItensReadCommand Command );
        public QueryModel TipoInspecaoItensTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TipoInspecaoItensUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTII_IDQuery(int value );
        public QueryModel ExistsByTIV_IDQuery(int value );
        public QueryModel ExistsByITI_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTII_IDQuery(int value );
        public QueryModel FirstByTIV_IDQuery(int value );
        public QueryModel FirstByITI_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration