using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public struct Y_PerfilCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Description { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration