using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct MovimentacaoFinanceiraReadFKUserIdCommand : ICommand
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration