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
    public interface IyTokenQueryRead 
    {
        public QueryModel yTokenQuery(Command.Read.yTokenReadCommand Command , bool TakeOffTenantID = false);
        public QueryModel yTokenTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel yTokenUserIdQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel ExistsByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByTokenHashQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByDescriptionQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByConnectorKeyQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByActiveQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel ExistsByValidUntilQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByCreatedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByLastUsedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByUserIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByTokenHashQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByDescriptionQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByConnectorKeyQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByActiveQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel FirstByValidUntilQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByCreatedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByLastUsedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByUserIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration