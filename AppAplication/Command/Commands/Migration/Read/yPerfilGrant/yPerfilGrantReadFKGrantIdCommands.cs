using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yPerfilGrantReadFKGrantIdCommand : ICommand
    {
        public string Id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration