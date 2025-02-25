using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public class ServicoCrudCommand : ICommand
    {
        public int Id { get; set; }
        public int GrupoServicoId { get; set; }
        public string Nome { get; set; }
        public Decimal Valor { get; set; }
    }
}
