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
                    public interface ICargaPrevistaEntity
{
    int? Id { get; set; }
    string CAR_ID { get; set; }
    string ORD_ID { get; set; }
    Decimal ITC_QTD_PLANEJADA { get; set; }
    DateTime? CAR_PREVISAO_MATERIA_PRIMA { get; set; }
    DateTime? CAR_DATA_INICIO_PREVISTO { get; set; }
    DateTime? CAR_DATA_INICIO_REALIZADO { get; set; }
    DateTime? CAR_DATA_FIM_PREVISTO { get; set; }
    DateTime? CAR_DATA_FIM_REALIZADO { get; set; }
    DateTime? CAR_INICIO_JANELA_EMBARQUE { get; set; }
    DateTime? CAR_FIM_JANELA_EMBARQUE { get; set; }
    DateTime? CAR_EMBARQUE_ALVO { get; set; }
    Decimal? CAR_STATUS { get; set; }
    Decimal? CAR_PESO_TEORICO { get; set; }
    Decimal? CAR_VOLUME_TEORICO { get; set; }
    Decimal? CAR_PESO_REAL { get; set; }
    Decimal? CAR_VOLUME_REAL { get; set; }
    Decimal? CAR_PESO_EMBALAGEM { get; set; }
    Decimal? CAR_PESO_ENTRADA { get; set; }
    Decimal? CAR_PESO_SAIDA { get; set; }
    string CAR_ID_DOCA { get; set; }
    string VEI_PLACA { get; set; }
    int? TIP_ID { get; set; }
    string TRA_ID { get; set; }
    Decimal? CAR_GRUPO_PRODUTIVO { get; set; }
    string ROT_ID { get; set; }
    string CAR_OBSERVACAO_DE_TRANSPORTE { get; set; }
    string CAR_JUSTIFICATIVA_DE_CARREGAMENTO { get; set; }
    string OCO_ID { get; set; }
    string CAR_ID_JUNTADA { get; set; }
    string CAR_OBSERVACAO_OTIMIZADOR { get; set; }
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