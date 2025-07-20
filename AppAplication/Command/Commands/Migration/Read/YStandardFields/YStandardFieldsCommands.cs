using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct YStandardFieldsReadCommand : ICommandRead
    {
        public bool? Deleted { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration