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
    public interface ILotesQueryRead 
    {
        public QueryModel LotesQuery(Command.Read.LotesReadCommand Command );
        public QueryModel LotesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel LotesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMOV_LOTEQuery(string value );
        public QueryModel ExistsByMOV_SUB_LOTEQuery(string value );
        public QueryModel ExistsByLOT_LARGURAQuery(Decimal value );
        public QueryModel ExistsByLOT_COMPRIMENTOQuery(Decimal value );
        public QueryModel ExistsByLOT_DIAMETROQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMOV_LOTEQuery(string value );
        public QueryModel FirstByMOV_SUB_LOTEQuery(string value );
        public QueryModel FirstByLOT_LARGURAQuery(Decimal value );
        public QueryModel FirstByLOT_COMPRIMENTOQuery(Decimal value );
        public QueryModel FirstByLOT_DIAMETROQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration