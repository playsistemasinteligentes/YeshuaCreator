using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct MovimentacaoFinanceiraReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? PacienteId { get; set; }
        public int? ServicoId { get; set; }
        public Decimal? Valor { get; set; }
        public int? TipoMovimentacao { get; set; }
        public DateTime? DataMovimentacao { get; set; }
        public Decimal? SaldoAtual { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration