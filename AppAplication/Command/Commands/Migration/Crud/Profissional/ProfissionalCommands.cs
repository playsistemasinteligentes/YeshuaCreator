using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands
{
    public struct ProfissionalCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int? EspecialidadeId { get; set; }
        public string Telefone { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration