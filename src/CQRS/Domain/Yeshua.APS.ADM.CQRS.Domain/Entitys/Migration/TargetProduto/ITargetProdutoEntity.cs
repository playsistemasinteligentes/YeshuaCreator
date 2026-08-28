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
                    public interface ITargetProdutoEntity
{
    int TAR_ID { get; set; }
    int? MOV_ID { get; set; }
    string ORD_ID { get; set; }
    string PRO_ID { get; set; }
    string MAQ_ID { get; set; }
    string UNI_ID { get; set; }
    string TURM_ID { get; set; }
    string TURN_ID { get; set; }
    int? USE_ID { get; set; }
    string TAR_DIA_TURMA { get; set; }
    Decimal TAR_META_PERFORMANCE { get; set; }
    Decimal? TAR_REALIZADO_PERFORMANCE { get; set; }
    Decimal? TAR_PERCENTUAL_REALIZADO_PERFORMANCE { get; set; }
    Decimal? TAR_PROXIMA_META_PERFORMANCE { get; set; }
    Decimal TAR_META_TEMPO_SETUP { get; set; }
    Decimal? TAR_REALIZADO_TEMPO_SETUP { get; set; }
    Decimal? TAR_PROXIMA_META_TEMPO_SETUP { get; set; }
    Decimal TAR_META_TEMPO_SETUP_AJUSTE { get; set; }
    Decimal? TAR_REALIZADO_TEMPO_SETUP_AJUSTE { get; set; }
    Decimal? TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE { get; set; }
    string OCO_ID_PERFORMANCE { get; set; }
    string TAR_OBS_PERFORMANCE { get; set; }
    string OCO_ID_SETUP { get; set; }
    string TAR_OBS_SETUP { get; set; }
    string OCO_ID_SETUPA { get; set; }
    string TAR_OBS_SETUPA { get; set; }
    string TAR_TIPO_FEEDBACK_PERFORMANCE { get; set; }
    string TAR_TIPO_FEEDBACK_SETUP { get; set; }
    string TAR_TIPO_FEEDBACK_SETUP_AJUSTE { get; set; }
    Decimal? TAR_QTD_SETUP_AJUSTE { get; set; }
    Decimal? TAR_QTD { get; set; }
    int? TAR_PARAMETRO_TIME_WORK_STOP_MACHINE { get; set; }
    int? TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE { get; set; }
    int? ROT_SEQ_TRANFORMACAO { get; set; }
    int? FPR_SEQ_REPETICAO { get; set; }
    Decimal? TAR_PERFORMANCE_MAX_VERDE { get; set; }
    Decimal? TAR_PERFORMANCE_MIN_VERDE { get; set; }
    Decimal? TAR_SETUP_MAX_VERDE { get; set; }
    Decimal? TAR_SETUP_MIN_VERDE { get; set; }
    Decimal? TAR_SETUPA_MAX_VERDE { get; set; }
    Decimal? TAR_SETUPA_MIN_VERDE { get; set; }
    Decimal? TAR_PERFORMANCE_MIN_AMARELO { get; set; }
    Decimal? TAR_SETUP_MAX_AMARELO { get; set; }
    Decimal? TAR_SETUPA_MAX_AMARELO { get; set; }
    string TAR_OBS_OP_PARCIAL { get; set; }
    string TAR_OCO_ID_OP_PARCIAL { get; set; }
    string TAR_COR_PERFORMANCE { get; set; }
    string TAR_COR_SETUP_GERAL { get; set; }
    string TAR_COR_SETUP { get; set; }
    string TAR_COR_SETUPA { get; set; }
    DateTime? TAR_DIA_TURMA_D { get; set; }
    Decimal? FEE_QTD_PECAS_POR_PULSO { get; set; }
    Decimal? TAR_QTD_PERDAS { get; set; }
    DateTime? TAR_DATA_INICIAL { get; set; }
    DateTime? TAR_DATA_FINAL { get; set; }
    string TAR_APROVADO { get; set; }
    int? TAR_TEMPO_PRODUZINDO { get; set; }
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