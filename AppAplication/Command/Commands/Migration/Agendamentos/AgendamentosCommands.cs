using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public class AgendamentosCrudCommand : ICommand
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int ProfissionalId { get; set; }
        public int ServicoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Status { get; set; }
    }
}
