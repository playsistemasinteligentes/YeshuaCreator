using Shered.DB;
namespace IQuery.Read
{
    public interface IMovimentoFinanceiroQueryRead 
    {
        public QueryModel MovimentoFinanceiroQuery(Command.Read.MovimentoFinanceiroReadCommand Command );
        public QueryModel MovimentoFinanceiroContaDebitoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoFinanceiroContaCreditoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoFinanceiroTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoFinanceiroUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByIdOrigemQuery(string value );
        public QueryModel ExistsByContaDebitoIdQuery(int value );
        public QueryModel ExistsByContaCreditoIdQuery(int value );
        public QueryModel ExistsByValorQuery(Decimal value );
        public QueryModel ExistsByDataMovimentoQuery(DateTime value );
        public QueryModel ExistsByDataVencimentoQuery(DateTime value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByIdOrigemQuery(string value );
        public QueryModel FirstByContaDebitoIdQuery(int value );
        public QueryModel FirstByContaCreditoIdQuery(int value );
        public QueryModel FirstByValorQuery(Decimal value );
        public QueryModel FirstByDataMovimentoQuery(DateTime value );
        public QueryModel FirstByDataVencimentoQuery(DateTime value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration