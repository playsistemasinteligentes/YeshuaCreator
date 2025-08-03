using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct YpermissionModulesReadCommand : ICommandRead
    {
        public string Id { get; set; }
        public string Description { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration