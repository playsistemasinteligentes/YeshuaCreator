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
    public struct GrupoProdutoAbstratoReadCommand : ICommandRead
    {
        public string GRP_ID { get; set; }
        public string GRP_DESCRICAO { get; set; }
        public int? TEM_ID { get; set; }
        public Decimal? GRP_TIPO { get; set; }
        public string GRP_PAP_ONDA { get; set; }
        public Decimal? GRP_PAP_GRAMATURA { get; set; }
        public Decimal? GRP_PAP_ALTURA { get; set; }
        public string GRP_PAP_NOME_COMERCIAL { get; set; }
        public string GRP_ATIVO { get; set; }
        public DateTime? GRP_DT_CRIACAO { get; set; }
        public string GRP_PAPEL1 { get; set; }
        public string GRP_PAPEL2 { get; set; }
        public string GRP_PAPEL3 { get; set; }
        public string GRP_PAPEL4 { get; set; }
        public string GRP_PAPEL5 { get; set; }
        public string GRP_ID_INTEGRACAO { get; set; }
        public string GRP_ID_INTEGRACAO_ERP { get; set; }
        public int? GRP_TYPE { get; set; }
        public Decimal? GRP_PERFORMANCE { get; set; }
        public Decimal? GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO { get; set; }
        public string GRP_RESINA { get; set; }
        public string GRP_ENDURECEDOR_MIOLO { get; set; }
        public int? VIN_ID { get; set; }
        public Decimal? GRP_COLUNA_DE { get; set; }
        public Decimal? GRP_COLUNA_ATE { get; set; }
        public Decimal? GRP_CRUSH { get; set; }
        public string GRP_ID_FAMILIA { get; set; }
        public Decimal? GRP_REFILE_LARGURA { get; set; }
        public Decimal? GRP_REFILE_COMPRIMENTO { get; set; }
        public string GRP_TIPO_LAP { get; set; }
        public string GRP_LAP_PROLONGADO { get; set; }
        public Decimal? GRP_TAMANHO_LAP_OND_SIMPLES { get; set; }
        public Decimal? GRP_TAMANHO_LAP_OND_DUPLA { get; set; }
        public Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES { get; set; }
        public Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA { get; set; }
        public string GRP_FEFCO { get; set; }
        public int? GRP_TOLERANCIA_DIMENCAO_CHAPA_DE { get; set; }
        public int? GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE { get; set; }
        public string GRP_PREFIXO_ID_PRODUTO { get; set; }
        public Decimal? GRP_COLUNA_CAIXA { get; set; }
        public Decimal? GRP_COLUNA_CHAPA { get; set; }
        public Decimal? GRP_MULLEN { get; set; }
        public int? GRP_TENDENCIA_TOLERANCIA_PEDIDO { get; set; }
        public Decimal? GRP_PERCENTUAL_PERDA_MEDIA { get; set; }
        public int? GRP_FILTRA_SEQ_TRANS { get; set; }
        public string GRP_IMG_CAIXA { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration