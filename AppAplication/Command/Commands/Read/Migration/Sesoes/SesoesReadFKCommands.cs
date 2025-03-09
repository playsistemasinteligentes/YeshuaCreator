using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public class SesoesReadFKCommand : ICommand
    {
        public int? Id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration