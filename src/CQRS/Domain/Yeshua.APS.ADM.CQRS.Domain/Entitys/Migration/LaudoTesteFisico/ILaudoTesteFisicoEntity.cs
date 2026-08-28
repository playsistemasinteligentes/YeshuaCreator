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
                    public interface ILaudoTesteFisicoEntity
{
    int? Id { get; set; }
    int LTF_ID { get; set; }
    DateTime? LTF_EMISSAO { get; set; }
    Decimal? LTF_VALOR { get; set; }
    string LTF_OBS { get; set; }
    string LTF_STATUS { get; set; }
    string ORD_ID { get; set; }
    string ROT_PRO_ID { get; set; }
    int? FPR_SEQ_REPETICAO { get; set; }
    int? USE_ID { get; set; }
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