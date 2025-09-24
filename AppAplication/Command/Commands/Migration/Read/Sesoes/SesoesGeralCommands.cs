using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct SesoesGeralCommand : ICommandRead
    {
        public DateTime DataInicio {  get; set; }
        public DateTime DataFim {  get; set; }
        public List<int> StatusAgendamento {  get; set; }
        public List<int> StatusProntuario {  get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration