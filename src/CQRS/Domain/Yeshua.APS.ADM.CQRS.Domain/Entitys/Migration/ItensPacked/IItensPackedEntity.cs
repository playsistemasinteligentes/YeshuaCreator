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
                    public interface IItensPackedEntity
{
    int? Id { get; set; }
    int IPA_ID { get; set; }
    string CAR_ID { get; set; }
    string PRO_ID { get; set; }
    string ORD_ID { get; set; }
    Decimal? IPA_COORDC { get; set; }
    Decimal? IPA_COORDL { get; set; }
    Decimal? IPA_COORDA { get; set; }
    Decimal? IPA_DIMC { get; set; }
    Decimal? IPA_DIML { get; set; }
    Decimal? IPA_DIMA { get; set; }
    Decimal? IPA_QTD_POR_PALETE { get; set; }
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