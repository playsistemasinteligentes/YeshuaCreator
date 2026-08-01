using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct SesoesD30Command : ICommandRead
    {
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration