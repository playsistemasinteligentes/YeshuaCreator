using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public class EspecialidadeReadCommand : ICommand
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
