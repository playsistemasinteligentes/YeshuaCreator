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
                    public interface IFilaProducaoEntity
{
    int? Id { get; set; }
    string ORD_ID { get; set; }
    string ROT_PRO_ID { get; set; }
    Decimal FPR_QUANTIDADE_PREVISTA { get; set; }
    string ROT_MAQ_ID { get; set; }
    DateTime FPR_DATA_INICIO_PREVISTA { get; set; }
    DateTime FPR_DATA_FIM_PREVISTA { get; set; }
    DateTime FPR_DATA_FIM_MAXIMA { get; set; }
    int ROT_SEQ_TRANFORMACAO { get; set; }
    int FPR_SEQ_REPETICAO { get; set; }
    string FPR_OBS_PRODUCAO { get; set; }
    string FPR_STATUS { get; set; }
    Decimal? FPR_TEMPO_DECORRIDO_SETUP { get; set; }
    Decimal? FPR_TEMPO_DECORRIDO_SETUPA { get; set; }
    Decimal? FPR_TEMPO_DECORRIDO_PERFORMANC { get; set; }
    Decimal? FPR_TEMPO_DECO_PEQUENA_PARADA { get; set; }
    Decimal? FPR_QTD_PERFORMANCE { get; set; }
    Decimal? FPR_QTD_SETUP { get; set; }
    Decimal? FPR_QTD_PRODUZIDA { get; set; }
    Decimal? FPR_TEMPO_TEORICO_PERFORMANCE { get; set; }
    Decimal? FPR_TEMPO_RESTANTE_PERFORMANC { get; set; }
    Decimal? FPR_VELOCIDADE_P_ATINGIR_META { get; set; }
    Decimal? FPR_QTD_RESTANTE { get; set; }
    Decimal? FPR_VELO_ATU_PC_SEGUNDO { get; set; }
    Decimal? FPR_PERFORMANCE_PROJETADA { get; set; }
    Decimal? FPR_TEMPO_RESTANTE_TOTAL { get; set; }
    DateTime? FPR_FIM_PREVISTO_ATUAL { get; set; }
    int? FPR_PRODUZINDO { get; set; }
    Decimal? FPR_ORDEM_NA_FILA { get; set; }
    string FPR_ID_INTEGRACAO { get; set; }
    string FPR_TRUNCADO { get; set; }
    DateTime? FPR_DATA_TRUNC_INI { get; set; }
    DateTime? FPR_DATA_TRUNC_FIM { get; set; }
    int FPR_ID { get; set; }
    string FPR_COR_FILA { get; set; }
    string MAQ_ID_MANUAL { get; set; }
    string MAQ_ID_RESTRINGIDA { get; set; }
    DateTime FPR_PREVISAO_MATERIA_PRIMA { get; set; }
    DateTime? FPR_DATA_NECESSIDADE_INICIO_PRODUCAO { get; set; }
    DateTime? FPR_DATA_NECESSIDADE_FIM_PRODUCAO { get; set; }
    Decimal? FPR_GRUPO_PRODUTIVO { get; set; }
    DateTime? FPR_INICIO_GRUPO_PRODUTIVO { get; set; }
    DateTime? FPR_FIM_GRUPO_PRODUTIVO { get; set; }
    string FPR_COR_BICO1 { get; set; }
    string FPR_COR_BICO2 { get; set; }
    string FPR_COR_BICO3 { get; set; }
    string FPR_COR_BICO4 { get; set; }
    string FPR_COR_BICO5 { get; set; }
    Decimal? FPR_META_SETUP { get; set; }
    string FPR_ORD_ID_REPROGRAMADO { get; set; }
    int? FPR_PRIORIDADE { get; set; }
    int? FPR_SEQ_INCLUSAO_FILA { get; set; }
    int? FPR_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
    int? FPR_ID_ORIGEM { get; set; }
    DateTime? FPR_DATA_ENTREGA { get; set; }
    string EQU_ID { get; set; }
    Decimal? FPR_GRUPO_PRODUTIVO_MANUAL { get; set; }
    DateTime? FPR_EMISSAO { get; set; }
    string FPR_MOTIVO_PULA_FILA { get; set; }
    string OCO_ID { get; set; }
    Decimal? FPR_TOLERANCIA_MENOS { get; set; }
    Decimal? FPR_TOLERANCIA_MAIS { get; set; }
    DateTime? FPR_DATA_ENCERRAMENTO { get; set; }
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