using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands
{
    public struct Ytenant_ConfigurationCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? AuditTrackerActived { get; set; }
        public int? AuditCRUDActived { get; set; }
        public int? TenantID { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration