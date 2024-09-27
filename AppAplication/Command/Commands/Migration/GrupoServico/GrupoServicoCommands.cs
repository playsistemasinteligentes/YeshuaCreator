using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Comandos.Commands
{
    public class GrupoServicoCommand : ICommand
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
