using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public class ProfissionalReadCommand : ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EspecialidadeId { get; set; }
        public string Telefone { get; set; }
    }
}
