using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public struct ServicoReadFKGrupoServicoIdCommand : ICommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration