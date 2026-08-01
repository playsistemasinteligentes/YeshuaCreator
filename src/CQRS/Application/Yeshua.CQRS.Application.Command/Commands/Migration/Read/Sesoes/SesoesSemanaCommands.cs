using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct SesoesSemanaCommand : ICommandRead
    {
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration