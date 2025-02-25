using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public class GrupoServicoCrudCommand : ICommand
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
