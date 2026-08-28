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
                    public interface IMaquinaEntity
{
    string Id { get; set; }
    string Descricao { get; set; }
    string Status { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    int? CAL_ID { get; set; }
    string MAQ_CONTROL_IP { get; set; }
    string GMA_ID { get; set; }
    DateTime? MAQ_ULTIMA_ATUALIZACAO { get; set; }
    int? MAQ_SIRENE_SEMAFORO { get; set; }
    string MAQ_COR_SEMAFORO { get; set; }
    string MAQ_ID_MAQ_PAI { get; set; }
    int? MAQ_TIPO_CONTADOR { get; set; }
    string MAQ_TIPO_PLANEJAMENTO { get; set; }
    int? MAQ_AVALIA_CUSTO { get; set; }
    int? FPR_ID_OP_PRODUZINDO { get; set; }
    int? MAQ_CONGELA_FILA { get; set; }
    int? MAQ_TEMPO_MIN_PARADA { get; set; }
    int? MAQ_QTD_CORES { get; set; }
    string MAQ_ID_INTEGRACAO { get; set; }
    string MAQ_ID_INTEGRACAO_ERP { get; set; }
    Decimal? MAQ_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
    string EQU_ID { get; set; }
    Decimal? MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR { get; set; }
    string MAQ_ACOMPANHA_LOTE_PILOTO { get; set; }
    int? MAQ_ID_SENSOR { get; set; }
    int? MAQ_DEBOUNCING_LOW { get; set; }
    int? MAQ_DEBOUNCING_HIGHT { get; set; }
    int? MAQ_TIPO_SINAL { get; set; }
    int? TEM_ID { get; set; }
    Decimal? MAQ_COMPRIMENTO_CHAPA_DE { get; set; }
    Decimal? MAQ_COMPRIMENTO_CHAPA_ATE { get; set; }
    Decimal? MAQ_LARGURA_CHAPA_DE { get; set; }
    Decimal? MAQ_LARGURA_CHAPA_ATE { get; set; }
    Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR { get; set; }
    Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR { get; set; }
    Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR { get; set; }
    Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR { get; set; }
    Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_DE { get; set; }
    Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_ATE { get; set; }
    Decimal? MAQ_LARGURA_ENTRE_VINCO_DE { get; set; }
    Decimal? MAQ_LARGURA_ENTRE_VINCO_ATE { get; set; }
    Decimal? MAQ_ALTURA_ENTRE_VINCO_DE { get; set; }
    Decimal? MAQ_ALTURA_ENTRE_VINCO_ATE { get; set; }
    Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE { get; set; }
    Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE { get; set; }
    Decimal? MAQ_ABA_DE { get; set; }
    Decimal? MAQ_ABA_ATE { get; set; }
    Decimal? MAQ_LAP_DE { get; set; }
    Decimal? MAQ_LAP_ATE { get; set; }
    string MAQ_ONDAS { get; set; }
    string MAQ_PROLONGA_LAP { get; set; }
    Decimal? MAQ_LARGURA_IMPRESSAO { get; set; }
    Decimal? MAQ_COMPRIMENTO_IMPRESSAO { get; set; }
    Decimal? MAQ_ROLO_DISPOSITIVO_DE { get; set; }
    Decimal? MAQ_ROLO_DISPOSITIVO_ATE { get; set; }
    string MAQ_FAMILIAS { get; set; }
    Decimal? MAQ_REFILE_MINIMO { get; set; }
    Decimal? MAQ_LARGURA_UTIL { get; set; }
    Decimal? MAQ_TOTAL_ACO { get; set; }
    string MAQ_FECHAMENTO { get; set; }
    Decimal? MAQ_OPERACAO_VINCAR { get; set; }
    Decimal? MAQ_OPERACAO_MONTA_DIVISAO { get; set; }
    Decimal? MAQ_OPERACAO_SERRAR { get; set; }
    string MAQ_TIPO_LAP { get; set; }
    Decimal? MAQ_INDICE_PARADAS_POR_OP { get; set; }
    int? MAQ_PERDA_MAXIMA { get; set; }
    int? MAQ_TOTAL_PECAS_REFILANDO { get; set; }
    int? MAQ_TOTAL_PECAS_NAO_REFILANDO { get; set; }
    int? MAQ_TOTAL_VINCOS { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration