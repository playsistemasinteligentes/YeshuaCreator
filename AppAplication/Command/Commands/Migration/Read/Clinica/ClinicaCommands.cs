using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
using RepositoryInterfaces.Patterns.Repository;
namespace Command.Commands.Read
{
    public struct ClinicaReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration