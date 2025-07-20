using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct ServicoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? GrupoServicoId { get; set; }
        public string Nome { get; set; }
        public Decimal? Valor { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration