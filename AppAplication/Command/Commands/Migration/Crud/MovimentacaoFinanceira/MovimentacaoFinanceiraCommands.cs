using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands
{
    public struct MovimentacaoFinanceiraCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? PacienteId { get; set; }
        public int? ServicoId { get; set; }
        public Decimal Valor { get; set; }
        public int TipoMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public Decimal SaldoAtual { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration