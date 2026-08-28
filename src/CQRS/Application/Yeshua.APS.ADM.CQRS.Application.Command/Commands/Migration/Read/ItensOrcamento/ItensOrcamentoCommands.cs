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
namespace Command.Read
{
    public struct ItensOrcamentoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? ITO_ID { get; set; }
        public int? ORC_ID { get; set; }
        public int? TIP_ID { get; set; }
        public string PRO_ID { get; set; }
        public string ITO_OBS { get; set; }
        public Decimal? ITO_QUANTIDADE { get; set; }
        public Decimal? ITO_CUSTO { get; set; }
        public Decimal? ITO_MARGEM { get; set; }
        public Decimal? ITO_VALOR_UNITARIO { get; set; }
        public DateTime? ITO_VERSSAO_CUSTO { get; set; }
        public string ITO_STATUS { get; set; }
        public Decimal? ITO_ERP_CUSTOS_FIXOS { get; set; }
        public Decimal? ITO_ERP_CUSTOS_VARIAVEIS { get; set; }
        public Decimal? ITO_ERP_DESPESAS_VAR_VENDA { get; set; }
        public Decimal? ITO_ERP_IMPOSTOS { get; set; }
        public string GRP_ID_COMPOSICAO { get; set; }
        public Decimal? ITO_LARGURA { get; set; }
        public Decimal? ITO_COMPRIMENTO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration