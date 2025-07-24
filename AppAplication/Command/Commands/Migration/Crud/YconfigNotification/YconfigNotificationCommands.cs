using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YconfigNotificationCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string EmailAdress { get; set; }
        public string EmailPassword { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration