using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YperfilPermitionsCrudCommand : ICommand
    {
        public int? PerfilId { get; set; }
        public string PermitionsId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration