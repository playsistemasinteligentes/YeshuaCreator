using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Comandos.Commands
{
    public class ClinicaCommand : ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
