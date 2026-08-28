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
    public interface IVincoQueryRead 
    {
        public QueryModel VincoQuery(Command.Read.VincoReadCommand Command );
        public QueryModel VincoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel VincoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByVIN_IDQuery(int value );
        public QueryModel ExistsByVIN_DESCRICAOQuery(string value );
        public QueryModel ExistsByVIN_ID_DESLOCAMENTOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByVIN_IDQuery(int value );
        public QueryModel FirstByVIN_DESCRICAOQuery(string value );
        public QueryModel FirstByVIN_ID_DESLOCAMENTOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration