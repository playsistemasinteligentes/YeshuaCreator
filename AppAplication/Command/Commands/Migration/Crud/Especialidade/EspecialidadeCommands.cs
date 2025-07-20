using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct EspecialidadeCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration