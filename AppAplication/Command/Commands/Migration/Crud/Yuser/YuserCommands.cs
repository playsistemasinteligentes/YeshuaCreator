using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YuserCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration