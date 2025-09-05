using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct SesoesSemanaCommand : ICommandRead
    {
        public DateTime DataInicio {  get; set; }
        public int Id {  get; set; }
        public string Nome {  get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration