using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yGrantReadCommand : ICommandRead
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration