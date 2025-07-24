using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct YconfigNotificationReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string EmailAdress { get; set; }
        public string EmailPassword { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration