using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct MDFeEncerramentoGeralCommand : ICommandRead
    {
        public int Situacao {  get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration