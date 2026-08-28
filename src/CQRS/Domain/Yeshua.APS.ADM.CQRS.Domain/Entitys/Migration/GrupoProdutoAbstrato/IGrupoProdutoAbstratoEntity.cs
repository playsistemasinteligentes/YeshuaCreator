// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IGrupoProdutoAbstratoEntity
{
    string GRP_ID { get; set; }
    string GRP_DESCRICAO { get; set; }
    int? TEM_ID { get; set; }
    Decimal? GRP_TIPO { get; set; }
    string GRP_PAP_ONDA { get; set; }
    Decimal? GRP_PAP_GRAMATURA { get; set; }
    Decimal? GRP_PAP_ALTURA { get; set; }
    string GRP_PAP_NOME_COMERCIAL { get; set; }
    string GRP_ATIVO { get; set; }
    DateTime? GRP_DT_CRIACAO { get; set; }
    string GRP_PAPEL1 { get; set; }
    string GRP_PAPEL2 { get; set; }
    string GRP_PAPEL3 { get; set; }
    string GRP_PAPEL4 { get; set; }
    string GRP_PAPEL5 { get; set; }
    string GRP_ID_INTEGRACAO { get; set; }
    string GRP_ID_INTEGRACAO_ERP { get; set; }
    int? GRP_TYPE { get; set; }
    Decimal? GRP_PERFORMANCE { get; set; }
    Decimal? GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO { get; set; }
    string GRP_RESINA { get; set; }
    string GRP_ENDURECEDOR_MIOLO { get; set; }
    int VIN_ID { get; set; }
    Decimal? GRP_COLUNA_DE { get; set; }
    Decimal? GRP_COLUNA_ATE { get; set; }
    Decimal? GRP_CRUSH { get; set; }
    string GRP_ID_FAMILIA { get; set; }
    Decimal? GRP_REFILE_LARGURA { get; set; }
    Decimal? GRP_REFILE_COMPRIMENTO { get; set; }
    string GRP_TIPO_LAP { get; set; }
    string GRP_LAP_PROLONGADO { get; set; }
    Decimal? GRP_TAMANHO_LAP_OND_SIMPLES { get; set; }
    Decimal? GRP_TAMANHO_LAP_OND_DUPLA { get; set; }
    Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES { get; set; }
    Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA { get; set; }
    string GRP_FEFCO { get; set; }
    int? GRP_TOLERANCIA_DIMENCAO_CHAPA_DE { get; set; }
    int? GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE { get; set; }
    string GRP_PREFIXO_ID_PRODUTO { get; set; }
    Decimal? GRP_COLUNA_CAIXA { get; set; }
    Decimal? GRP_COLUNA_CHAPA { get; set; }
    Decimal? GRP_MULLEN { get; set; }
    int? GRP_TENDENCIA_TOLERANCIA_PEDIDO { get; set; }
    Decimal? GRP_PERCENTUAL_PERDA_MEDIA { get; set; }
    int? GRP_FILTRA_SEQ_TRANS { get; set; }
    string GRP_IMG_CAIXA { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration