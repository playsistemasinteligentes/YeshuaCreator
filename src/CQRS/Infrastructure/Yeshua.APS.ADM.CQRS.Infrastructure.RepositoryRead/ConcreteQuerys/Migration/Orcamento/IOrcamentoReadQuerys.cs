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
    public interface IOrcamentoQueryRead 
    {
        public QueryModel OrcamentoQuery(Command.Read.OrcamentoReadCommand Command );
        public QueryModel OrcamentoCLI_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OrcamentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OrcamentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByORC_IDQuery(int value );
        public QueryModel ExistsByREP_IDQuery(string value );
        public QueryModel ExistsByCON_IDQuery(string value );
        public QueryModel ExistsByORC_TIPO_FRETEQuery(string value );
        public QueryModel ExistsByORC_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByCLI_IDQuery(string value );
        public QueryModel ExistsByVER_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByORC_IDQuery(int value );
        public QueryModel FirstByREP_IDQuery(string value );
        public QueryModel FirstByCON_IDQuery(string value );
        public QueryModel FirstByORC_TIPO_FRETEQuery(string value );
        public QueryModel FirstByORC_EMISSAOQuery(DateTime value );
        public QueryModel FirstByCLI_IDQuery(string value );
        public QueryModel FirstByVER_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration