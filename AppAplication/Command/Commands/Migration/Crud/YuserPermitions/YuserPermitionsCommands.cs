using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YuserPermitionsCrudCommand : ICommand
    {
        public string PermitionsId { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration