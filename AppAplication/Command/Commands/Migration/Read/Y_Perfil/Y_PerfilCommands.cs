using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public struct Y_PerfilReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Description { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration