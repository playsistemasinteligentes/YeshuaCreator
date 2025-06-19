using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands.Read
{
    public struct MovimentacaoFinanceiraReadFKPacienteIdCommand : ICommand
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration