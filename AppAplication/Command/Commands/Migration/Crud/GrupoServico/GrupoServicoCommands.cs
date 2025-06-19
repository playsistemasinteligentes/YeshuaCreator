using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands
{
    public struct GrupoServicoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration