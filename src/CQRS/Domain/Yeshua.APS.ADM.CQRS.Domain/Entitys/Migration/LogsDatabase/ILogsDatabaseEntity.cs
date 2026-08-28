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
                    public interface ILogsDatabaseEntity
{
    int LOGS_ID { get; set; }
    string LOGS_TABLE { get; set; }
    string LOGS_KEY { get; set; }
    string LOGS_KEY1 { get; set; }
    string LOGS_KEY2 { get; set; }
    string LOGS_KEY3 { get; set; }
    string LOGS_KEY4 { get; set; }
    string LOGS_COLUMN { get; set; }
    string LOGS_BEFORE { get; set; }
    string LOGS_AFTER { get; set; }
    string LOGS_ACTION { get; set; }
    DateTime LOGS_DATE { get; set; }
    int USE_ID { get; set; }
    string LOGS_ORIGEM { get; set; }
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