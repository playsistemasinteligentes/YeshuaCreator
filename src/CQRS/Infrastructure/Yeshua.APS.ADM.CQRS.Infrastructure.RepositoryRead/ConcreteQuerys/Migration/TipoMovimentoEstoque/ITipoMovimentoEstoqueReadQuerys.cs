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
    public interface ITipoMovimentoEstoqueQueryRead 
    {
        public QueryModel TipoMovimentoEstoqueQuery(Command.Read.TipoMovimentoEstoqueReadCommand Command );
        public QueryModel TipoMovimentoEstoqueTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TipoMovimentoEstoqueUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByTIP_IDQuery(string value );
        public QueryModel ExistsByTIP_DESCRICAOQuery(string value );
        public QueryModel ExistsByTIP_TYPEQuery(int value );
        public QueryModel ExistsBySPRQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByTIP_IDQuery(string value );
        public QueryModel FirstByTIP_DESCRICAOQuery(string value );
        public QueryModel FirstByTIP_TYPEQuery(int value );
        public QueryModel FirstBySPRQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration