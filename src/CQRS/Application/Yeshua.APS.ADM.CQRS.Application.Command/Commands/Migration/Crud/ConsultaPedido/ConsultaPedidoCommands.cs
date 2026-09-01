// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct ConsultaPedidoCrudCommand : ICommand
    {
        public string PedidoId { get; set; }
        public string ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string RazaoSocial { get; set; }
        public string ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public string Status { get; set; }
        public string Estagio { get; set; }
        public DateTime DataEntregaDe { get; set; }
        public DateTime DataEntregaAte { get; set; }
        public DateTime? EmbarqueAlvo { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal SaldoAProduzir { get; set; }
        public Decimal? SaldoAExpedir { get; set; }
        public string CorFila { get; set; }
        public string PedidoCliente { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration