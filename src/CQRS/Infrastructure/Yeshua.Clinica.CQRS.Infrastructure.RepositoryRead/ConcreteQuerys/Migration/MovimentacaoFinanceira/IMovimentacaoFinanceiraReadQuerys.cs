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
    public interface IMovimentacaoFinanceiraQueryRead 
    {
        public QueryModel MovimentacaoFinanceiraQuery(Command.Read.MovimentacaoFinanceiraReadCommand Command );
        public QueryModel MovimentacaoFinanceiraPacienteIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentacaoFinanceiraServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentacaoFinanceiraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentacaoFinanceiraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByPacienteIdQuery(int value );
        public QueryModel ExistsByServicoIdQuery(int value );
        public QueryModel ExistsByValorQuery(Decimal value );
        public QueryModel ExistsByTipoMovimentacaoQuery(int value );
        public QueryModel ExistsByDataMovimentacaoQuery(DateTime value );
        public QueryModel ExistsBySaldoAtualQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByPacienteIdQuery(int value );
        public QueryModel FirstByServicoIdQuery(int value );
        public QueryModel FirstByValorQuery(Decimal value );
        public QueryModel FirstByTipoMovimentacaoQuery(int value );
        public QueryModel FirstByDataMovimentacaoQuery(DateTime value );
        public QueryModel FirstBySaldoAtualQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration