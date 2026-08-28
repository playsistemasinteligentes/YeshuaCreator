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
                    public interface IOrderTrackEntity
{
    int? Id { get; set; }
    int OTK_ID { get; set; }
    Decimal OTK_SEQUENCIA { get; set; }
    int OTK_VERSSAO { get; set; }
    string ORD_ID { get; set; }
    string OTK_EVENTO { get; set; }
    DateTime? OTK_DATA_NECESSIDADE_DE { get; set; }
    DateTime? OTK_DATA_NECESSIDADE_ATE { get; set; }
    DateTime? OTK_DATA_PREVISTA { get; set; }
    DateTime? OTK_DATA_REALIZADA { get; set; }
    int? FPR_ID { get; set; }
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