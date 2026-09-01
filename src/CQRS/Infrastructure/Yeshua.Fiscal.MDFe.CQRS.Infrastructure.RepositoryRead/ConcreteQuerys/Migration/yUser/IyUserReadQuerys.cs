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
    public interface IyUserQueryRead 
    {
        public QueryModel yUserQuery(Command.Read.yUserReadCommand Command , bool TakeOffTenantID = false);
        public QueryModel yUserTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel ExistsByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByNomeQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByEmailQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsBySenhaQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByNomeQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByEmailQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstBySenhaQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration