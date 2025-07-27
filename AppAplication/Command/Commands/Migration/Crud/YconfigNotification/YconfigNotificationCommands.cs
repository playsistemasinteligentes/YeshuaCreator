using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YconfigNotificationCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? TenantID { get; set; }
        public string EmailSmtpClient { get; set; }
        public int? EmailPort { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration