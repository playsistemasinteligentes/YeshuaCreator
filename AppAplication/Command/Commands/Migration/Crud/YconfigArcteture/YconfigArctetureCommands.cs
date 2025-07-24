using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YconfigArctetureCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? AuditTrackerActived { get; set; }
        public int? AuditCRUDActived { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration