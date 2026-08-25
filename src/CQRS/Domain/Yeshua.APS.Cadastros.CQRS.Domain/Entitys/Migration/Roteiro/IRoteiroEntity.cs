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
                    public interface IRoteiroEntity
{
    string MAQ_ID { get; set; }
    string PRO_ID { get; set; }
    int ROT_SEQ_TRANFORMACAO { get; set; }
    string GMA_ID { get; set; }
    Decimal? ROT_PECAS_POR_PULSO { get; set; }
    Decimal? ROT_PRIORIDADE_INFORMADA { get; set; }
    string ROT_ACAO { get; set; }
    Decimal ROT_PERFORMANCE { get; set; }
    Decimal? ROT_TEMPO_SETUP { get; set; }
    Decimal? ROT_TEMPO_SETUP_AJUSTE { get; set; }
    int? ROT_VA_PARA_SEQ_TRANSFORMACAO { get; set; }
    string ROT_STATUS { get; set; }
    Decimal? ROT_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
    int? ROT_AVALIA_CUSTO { get; set; }
    string ROT_OPERACOES { get; set; }
    string ROT_EXCECAO_OPERACOES { get; set; }
    Decimal? ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR { get; set; }
    string ROT_LINHA_DIRETA { get; set; }
    int? TEM_ID { get; set; }
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