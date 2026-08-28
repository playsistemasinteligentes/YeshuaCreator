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
                    public interface IMapaEntity
{
    int? Id { get; set; }
    int MAP_ID { get; set; }
    string PON_ID { get; set; }
    string PON_ID_VIZINHO { get; set; }
    Decimal MAP_DISTANCIA { get; set; }
    Decimal? MAP_CUSTO_PEDAGIO_POR_EIXO { get; set; }
    int? ROD_ID { get; set; }
    Decimal? MAP_ALTURA_ROD { get; set; }
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