using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
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