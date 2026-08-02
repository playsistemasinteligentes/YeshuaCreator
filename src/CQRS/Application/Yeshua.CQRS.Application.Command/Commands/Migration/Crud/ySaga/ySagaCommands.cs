using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct ySagaCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string KeyCurrentStep { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public DateTime? NextExecutionAt { get; set; }
        public DateTime? LockedAt { get; set; }
        public string LockedBy { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration