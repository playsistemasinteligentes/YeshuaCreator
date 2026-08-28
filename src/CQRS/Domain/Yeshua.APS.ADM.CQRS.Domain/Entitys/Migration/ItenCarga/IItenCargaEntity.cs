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
                    public interface IItenCargaEntity
{
    int? Id { get; set; }
    string CAR_ID { get; set; }
    string ORD_ID { get; set; }
    DateTime ITC_ENTREGA_PLANEJADA { get; set; }
    DateTime ITC_ENTREGA_REALIZADA { get; set; }
    int ITC_ORDEM_ENTREGA { get; set; }
    Decimal ITC_QTD_PLANEJADA { get; set; }
    Decimal ITC_QTD_REALIZADA { get; set; }
    string ORD_HASH_KEY { get; set; }
    string NOT_ID { get; set; }
    DateTime? NOT_EMISSAO { get; set; }
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