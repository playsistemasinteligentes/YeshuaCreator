using Shered.DB;
namespace IQuery.Read
{
    public interface IMovimentacaoFinanceiraQueryRead 
    {
        public QueryModel MovimentacaoFinanceiraQuery(Command.Read.MovimentacaoFinanceiraReadCommand Command);
        public QueryModel MovimentacaoFinanceiraPacienteIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel MovimentacaoFinanceiraServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByPacienteIdQuery(int value);
        public QueryModel ExistsByServicoIdQuery(int value);
        public QueryModel ExistsByValorQuery(Decimal value);
        public QueryModel ExistsByTipoMovimentacaoQuery(int value);
        public QueryModel ExistsByDataMovimentacaoQuery(DateTime value);
        public QueryModel ExistsBySaldoAtualQuery(Decimal value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByPacienteIdQuery(int value);
        public QueryModel FirstByServicoIdQuery(int value);
        public QueryModel FirstByValorQuery(Decimal value);
        public QueryModel FirstByTipoMovimentacaoQuery(int value);
        public QueryModel FirstByDataMovimentacaoQuery(DateTime value);
        public QueryModel FirstBySaldoAtualQuery(Decimal value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration