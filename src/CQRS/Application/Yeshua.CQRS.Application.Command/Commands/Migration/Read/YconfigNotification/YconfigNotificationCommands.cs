using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yConfigNotificationReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? TenantID { get; set; }
        public string EmailSmtpClient { get; set; }
        public int? EmailPort { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration