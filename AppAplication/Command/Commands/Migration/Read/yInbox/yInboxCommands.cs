using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yInboxReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string MessageId { get; set; }
        public string Type { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string Payload { get; set; }
        public List<int> Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public int? RetryCount { get; set; }
        public string LastError { get; set; }
        public int? SagaId { get; set; }
        public int? SagaStepId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration