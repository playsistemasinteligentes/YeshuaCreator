using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public struct ServicoReadCommand : ICommand
    {
        public int? Id { get; set; }
        public int? GrupoServicoId { get; set; }
        public string Nome { get; set; }
        public Decimal? Valor { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration