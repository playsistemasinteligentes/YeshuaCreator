using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public struct ClinicaCrudCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool PageWhithCount { get; set; }
        public Pagination Paginacao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration