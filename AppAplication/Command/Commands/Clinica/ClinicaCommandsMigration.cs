using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Comandos.Commands
{
    public class ClinicaCommand : ICommand
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeReduzido { get; set; }
        public string Endereco { get; set; }
        public string Fone { get; set; }
    }
}
