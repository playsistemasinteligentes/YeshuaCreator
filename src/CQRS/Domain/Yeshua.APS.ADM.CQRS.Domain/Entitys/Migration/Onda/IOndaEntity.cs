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
                    public interface IOndaEntity
{
    string OND_ID { get; set; }
    Decimal OND_ESPESSURA { get; set; }
    Decimal? OND_PESO_COLA { get; set; }
    Decimal? OND_RENDIMENTO_ONDA_1 { get; set; }
    Decimal? OND_RENDIMENTO_ONDA_2 { get; set; }
    int? OND_PROFUNDIDADE_VINCO { get; set; }
    string OND_ID_INTEGRACAO { get; set; }
    int VIN_ID { get; set; }
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