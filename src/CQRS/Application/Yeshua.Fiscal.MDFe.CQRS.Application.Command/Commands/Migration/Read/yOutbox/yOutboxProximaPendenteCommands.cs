using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yOutboxProximaPendenteCommand : ICommandRead
    {
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration