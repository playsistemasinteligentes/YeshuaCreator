using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yFileUploadReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string IdempotencyKey { get; set; }
        public string Type { get; set; }
        public List<int> Status { get; set; }
        public string FilePath { get; set; }
        public long? FileSize { get; set; }
        public string ContentType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration