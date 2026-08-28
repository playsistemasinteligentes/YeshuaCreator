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
                    public interface IItensCalendarioEntity
{
    int ICA_ID { get; set; }
    DateTime ICA_DATA_DE { get; set; }
    DateTime ICA_DATA_ATE { get; set; }
    string ICA_OBSERVACAO { get; set; }
    int ICA_TIPO { get; set; }
    string URM_ID { get; set; }
    string URN_ID { get; set; }
    int CAL_ID { get; set; }
    string MAQ_ID { get; set; }
    string PRO_ID { get; set; }
    int? ICA_LIMPESA_MAQUINA { get; set; }
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