using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Comandos.Commands
{
    public class ExecoesCalendarioCommand : ICommand
    {
        public int Id { get; set; }
        public DateTime De { get; set; }
        public DateTime Ate { get; set; }
    }
}
