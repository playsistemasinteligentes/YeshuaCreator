using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public struct GrupoServicoCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration