using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct SesoesGeralCommand : ICommandRead
    {
        public System.DateTime DataInicio {  get; set; }
        public  Paginacao {  get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration