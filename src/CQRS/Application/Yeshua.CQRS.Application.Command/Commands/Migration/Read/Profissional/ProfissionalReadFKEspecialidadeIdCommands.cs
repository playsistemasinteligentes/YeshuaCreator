using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct ProfissionalReadFKEspecialidadeIdCommand : ICommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration