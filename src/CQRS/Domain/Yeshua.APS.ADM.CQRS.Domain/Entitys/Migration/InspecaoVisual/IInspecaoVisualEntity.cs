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
                    public interface IInspecaoVisualEntity
{
    int IPV_ID { get; set; }
    string IPV_VALOR { get; set; }
    int? IPV_ID_OPERADOR { get; set; }
    int? IPV_ID_LIBERACAO { get; set; }
    string IPV_OBS { get; set; }
    DateTime? IPV_DATA_COLETA { get; set; }
    DateTime? IPV_DATA_AVAL { get; set; }
    int? TIV_ID { get; set; }
    string TURN_ID { get; set; }
    string TURM_ID { get; set; }
    string ORD_ID { get; set; }
    string ROT_PRO_ID { get; set; }
    string ROT_MAQ_ID { get; set; }
    int? ROT_SEQ_TRANSFORMACAO { get; set; }
    int? FPR_SEQ_REPETICAO { get; set; }
    string IPV_STATUS_LIBERACAO { get; set; }
    Decimal? IPV_VALOR_MEDIDA { get; set; }
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