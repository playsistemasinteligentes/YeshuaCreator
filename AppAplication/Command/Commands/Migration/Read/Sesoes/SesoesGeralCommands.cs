using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct SesoesGeralCommand : ICommandRead
    {
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration