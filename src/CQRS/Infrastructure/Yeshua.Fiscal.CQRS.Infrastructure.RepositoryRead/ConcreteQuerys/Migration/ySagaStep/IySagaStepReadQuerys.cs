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
    public interface IySagaStepQueryRead 
    {
        public QueryModel ySagaStepQuery(Command.Read.ySagaStepReadCommand Command , bool TakeOffTenantID = false);
        public QueryModel ySagaStepSagaIdQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel ySagaStepTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel ySagaStepUserIdQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false);
        public QueryModel ExistsByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsBySagaIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByStepKeyQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByIndexOrderQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByCorrelationIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByStatusQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByExecutionCountQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByLastExecutionAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByCompletedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByErrorMessageQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByPayloadQuery(string value , bool TakeOffTenantID = false);
        public QueryModel ExistsByRetryCountQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel ExistsByUserIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstBySagaIdQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByStepKeyQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByIndexOrderQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByCorrelationIdQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByStatusQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByExecutionCountQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByLastExecutionAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByCompletedAtQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByErrorMessageQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByPayloadQuery(string value , bool TakeOffTenantID = false);
        public QueryModel FirstByRetryCountQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByTenantIDQuery(int value , bool TakeOffTenantID = false);
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffTenantID = false);
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffTenantID = false);
        public QueryModel FirstByUserIdQuery(int value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration