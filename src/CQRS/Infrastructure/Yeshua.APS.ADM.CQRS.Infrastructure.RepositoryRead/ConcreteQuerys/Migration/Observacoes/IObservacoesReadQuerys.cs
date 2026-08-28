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
    public interface IObservacoesQueryRead 
    {
        public QueryModel ObservacoesQuery(Command.Read.ObservacoesReadCommand Command );
        public QueryModel ObservacoesCLI_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ObservacoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ObservacoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByOBS_IDQuery(int value );
        public QueryModel ExistsByOBS_TIPOQuery(string value );
        public QueryModel ExistsByOBS_DESCRICAOQuery(string value );
        public QueryModel ExistsByCLI_IDQuery(string value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel ExistsByOBS_INTEGRACAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByOBS_IDQuery(int value );
        public QueryModel FirstByOBS_TIPOQuery(string value );
        public QueryModel FirstByOBS_DESCRICAOQuery(string value );
        public QueryModel FirstByCLI_IDQuery(string value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel FirstByOBS_INTEGRACAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration