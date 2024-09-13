using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Comandos.Commands
{
    public class AtendimentoCommand : ICommand
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime UltimaInteracao { get; set; }
    }
}
