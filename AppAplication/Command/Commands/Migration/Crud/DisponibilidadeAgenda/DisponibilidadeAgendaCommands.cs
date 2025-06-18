using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public struct DisponibilidadeAgendaCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? ProfissionalId { get; set; }
        public DateTime DataHora { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration