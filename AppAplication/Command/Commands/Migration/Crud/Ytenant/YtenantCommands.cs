using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YtenantCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int CnpjCpf { get; set; }
        public string Nome { get; set; }
        public int? UserIDAdmin { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration