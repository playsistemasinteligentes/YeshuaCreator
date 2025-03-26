using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public struct YuserReadCommand : ICommand
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration