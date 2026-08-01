using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IMovimentoFinanceiroQueryWrite 
     {
        public QueryModel InserirMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro);
        public QueryModel UpdateMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro);
        QueryModel UpdateIdOrigem(int id, string value);
        QueryModel UpdateContaDebitoId(int id, int value);
        QueryModel UpdateValor(int id, Decimal value);
        QueryModel UpdateDataMovimento(int id, DateTime value);
        QueryModel UpdateDataVencimento(int id, DateTime value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMovimentoFinanceiroQuery(IMovimentoFinanceiroEntity MovimentoFinanceiro);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration