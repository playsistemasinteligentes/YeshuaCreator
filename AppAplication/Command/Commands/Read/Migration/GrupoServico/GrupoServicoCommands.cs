using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public struct GrupoServicoReadCommand : ICommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration