using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IMovimentacaoFinanceiraQueryWrite 
     {
        public QueryModel InserirMovimentacaoFinanceiraQuery(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira);
        public QueryModel UpdateMovimentacaoFinanceiraQuery(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira);
        public QueryModel UpdatePacienteId(IMovimentacaoFinanceiraEntity entity);
        public QueryModel UpdateServicoId(IMovimentacaoFinanceiraEntity entity);
        public QueryModel UpdateValor(IMovimentacaoFinanceiraEntity entity);
        public QueryModel UpdateTipoMovimentacao(IMovimentacaoFinanceiraEntity entity);
        public QueryModel UpdateDataMovimentacao(IMovimentacaoFinanceiraEntity entity);
        public QueryModel UpdateSaldoAtual(IMovimentacaoFinanceiraEntity entity);
        public QueryModel DeleteMovimentacaoFinanceiraQuery(IMovimentacaoFinanceiraEntity MovimentacaoFinanceira);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration