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
                    public interface IPlanoacaoEntity
{
    int PLA_ID { get; set; }
    string PLA_DESCRICAO { get; set; }
    int? MET_ID { get; set; }
    string PLA_STATUS { get; set; }
    DateTime? PLA_DATA { get; set; }
    string PLA_METAPERIODO { get; set; }
    string PLA_VLRPERIODO { get; set; }
    string PLA_METACULADO { get; set; }
    string PLA_VLRACUMULADO { get; set; }
    string PLA_REFERENCIA { get; set; }
    int USE_ID { get; set; }
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