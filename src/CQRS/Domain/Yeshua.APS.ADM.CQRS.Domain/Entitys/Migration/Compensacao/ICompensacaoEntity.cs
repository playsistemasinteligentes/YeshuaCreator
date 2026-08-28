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
                    public interface ICompensacaoEntity
{
    int? Id { get; set; }
    int COM_ID { get; set; }
    string GRP_ID { get; set; }
    string OND_ID { get; set; }
    int? COM_VINCO1_OND { get; set; }
    int? COM_VINCO2_OND { get; set; }
    int? COM_VINCO3_OND { get; set; }
    int? COM_VINCO4_OND { get; set; }
    int? COM_VINCO5_OND { get; set; }
    int? COM_VINCO6_OND { get; set; }
    int? COM_VINCO7_OND { get; set; }
    int? COM_VINCO8_OND { get; set; }
    int? COM_VINCO9_OND { get; set; }
    int? COM_VINCO10_OND { get; set; }
    int? COM_VINCO1_CONVERSAO { get; set; }
    int? COM_VINCO2_CONVERSAO { get; set; }
    int? COM_VINCO3_CONVERSAO { get; set; }
    int? COM_VINCO4_CONVERSAO { get; set; }
    int? COM_VINCO5_CONVERSAO { get; set; }
    int? COM_VINCO6_CONVERSAO { get; set; }
    int? COM_VINCO7_CONVERSAO { get; set; }
    int? COM_VINCO8_CONVERSAO { get; set; }
    int? COM_VINCO9_CONVERSAO { get; set; }
    int? COM_VINCO10_CONVERSAO { get; set; }
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