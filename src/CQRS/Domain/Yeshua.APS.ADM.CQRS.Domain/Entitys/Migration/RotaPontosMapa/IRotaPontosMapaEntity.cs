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
                    public interface IRotaPontosMapaEntity
{
    int? Id { get; set; }
    string ROT_ID { get; set; }
    string PON_ID_DESTINO { get; set; }
    string PON_ID_ORIGEM { get; set; }
    Decimal? ROT_CUSTO_TOTAL { get; set; }
    string PON_ID_ROTEIRO { get; set; }
    int? ROT_ORDEM_ROTEIRO { get; set; }
    string ROT_TIPO { get; set; }
    Decimal? ROT_DISTANCIA { get; set; }
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