using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public struct Y_PerfilPermitionsCrudCommand : ICommand
    {
        public int? PerfilId { get; set; }
        public string PermitionsId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration