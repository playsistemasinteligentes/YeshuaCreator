using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YperfilCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Description { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration