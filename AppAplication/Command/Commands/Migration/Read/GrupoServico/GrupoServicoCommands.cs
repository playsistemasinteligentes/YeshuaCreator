using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands.Read
{
    public struct GrupoServicoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration