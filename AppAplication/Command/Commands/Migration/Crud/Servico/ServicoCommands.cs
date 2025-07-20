using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct ServicoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? GrupoServicoId { get; set; }
        public string Nome { get; set; }
        public Decimal Valor { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration