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
    public struct EstruturaCustoReadCommand : ICommandRead
    {
        public int? EST_ID { get; set; }
        public int? ITO_ID { get; set; }
        public string ORD_ID { get; set; }
        public string PRO_ID { get; set; }
        public string PRO_ID_PRODUTO { get; set; }
        public string PRO_ID_COMPONENTE { get; set; }
        public string PRO_TIPO_CUSTO { get; set; }
        public string PRO_GRUPO_CONTABIL { get; set; }
        public int? EST_ORDEM { get; set; }
        public string EST_GRUPO { get; set; }
        public Decimal? EST_QUANT { get; set; }
        public Decimal? EST_VALOR_TOTAL { get; set; }
        public string EST_DATA_BASE { get; set; }
        public Decimal? EST_BASE_PRODUCAO { get; set; }
        public Decimal? EST_NIVEL { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration