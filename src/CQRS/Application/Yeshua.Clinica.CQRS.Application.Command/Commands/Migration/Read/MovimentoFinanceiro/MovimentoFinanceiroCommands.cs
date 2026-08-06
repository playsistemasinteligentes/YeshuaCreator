using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct MovimentoFinanceiroReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string IdOrigem { get; set; }
        public int? ContaDebitoId { get; set; }
        public Decimal? Valor { get; set; }
        public DateTime? DataMovimento { get; set; }
        public DateTime? DataVencimento { get; set; }
        public List<int> Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration