using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Comandos.Commands
{
    public class ServicoCommand : ICommand
    {
        public int Id { get; set; }
        public int GrupoServicoId { get; set; }
        public string Nome { get; set; }
        public Decimal Valor { get; set; }
    }
}
