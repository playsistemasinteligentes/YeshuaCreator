using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IMovimentoFinanceiroQueryWrite 
     {
        public QueryModel InserirMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro);
        public QueryModel UpdateMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro);
        public QueryModel UpdateIdOrigem(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateContaDebitoId(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateValor(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateDataMovimento(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateDataVencimento(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateStatus(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateTenantID(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateDeleted(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateChanged(IMovimentoFinanceiroEntity entity);
        public QueryModel UpdateUserId(IMovimentoFinanceiroEntity entity);
        public QueryModel DeleteMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration