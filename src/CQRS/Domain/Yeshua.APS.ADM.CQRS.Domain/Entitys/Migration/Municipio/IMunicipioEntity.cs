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
                    public interface IMunicipioEntity
{
    string MUN_ID { get; set; }
    string MUN_NOME { get; set; }
    string UF_COD { get; set; }
    string MUN_CODIGO_IBGE { get; set; }
    Decimal? MUN_LATITUDE { get; set; }
    Decimal? MUN_LONGITUDE { get; set; }
    string MUN_ID_INTEGRACAO_ERP { get; set; }
    string MUN_CODIGO_SIAFI { get; set; }
    string MUN_CODIGO_CNPJ { get; set; }
    Decimal? MUN_DISTANCIA_KM { get; set; }
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