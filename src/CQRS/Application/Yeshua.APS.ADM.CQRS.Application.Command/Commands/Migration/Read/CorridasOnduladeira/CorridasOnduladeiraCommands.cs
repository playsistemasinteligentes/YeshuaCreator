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
    public struct CorridasOnduladeiraReadCommand : ICommandRead
    {
        public string BOL_ID { get; set; }
        public string BOL_ID_ORIGEM { get; set; }
        public Decimal? PRO_LARGURA_PECA { get; set; }
        public Decimal? PRO_LARGURA_PECA_PROGRAMADO { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA_PROGRAMADO { get; set; }
        public Decimal? PRO_UTILIZOU_REFILE_OBRIGATORIO { get; set; }
        public string PRO_VINCOS_RECALCULADOS { get; set; }
        public string COR_SOLVER { get; set; }
        public Decimal? COR_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? COR_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? COR_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
        public Decimal? COR_CUSTO_RESINA_PROGRAMADOS { get; set; }
        public Decimal? COR_TOLERANCIA_MENOS { get; set; }
        public Decimal? COR_TOLERANCIA_MAIS { get; set; }
        public int? COR_PILHAS_POR_PALETE { get; set; }
        public string COR_COR_FILA { get; set; }
        public Decimal? COR_M_LINEAR_REALIZADO { get; set; }
        public string PRO_ID_PALETE { get; set; }
        public string COR_STATUS_PALETE { get; set; }
        public Decimal? COR_GRUPO_PRODUTIVO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public int? COR_ID { get; set; }
        public string COR_STATUS { get; set; }
        public string COR_STATUS_INTERFACE { get; set; }
        public string MAQ_ID { get; set; }
        public int? COR_ID_INTERFACE { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? COR_SEQUENCIA_ORIGEM { get; set; }
        public string ORD_ID { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public int? COR_FACAO { get; set; }
        public int? COR_FORMATO_BOBINA { get; set; }
        public DateTime? COR_INICIO_PREVISTO { get; set; }
        public DateTime? COR_FIM_PREVISTO { get; set; }
        public string PRO_ID { get; set; }
        public int? COR_QTD_PLANEJADO { get; set; }
        public int? PRO_QTD_PACAS { get; set; }
        public int? COR_PECAS_LARGURA { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration