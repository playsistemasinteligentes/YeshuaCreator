using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct PacienteGeralCommand : ICommandRead
    {
        public string Nome {  get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration