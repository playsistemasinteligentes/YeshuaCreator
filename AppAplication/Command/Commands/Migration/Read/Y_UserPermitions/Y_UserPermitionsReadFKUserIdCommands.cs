using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public struct Y_UserPermitionsReadFKUserIdCommand : ICommand
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration