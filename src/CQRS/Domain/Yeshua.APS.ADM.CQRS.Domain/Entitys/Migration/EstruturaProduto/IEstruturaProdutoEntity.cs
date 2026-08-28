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
                    public interface IEstruturaProdutoEntity
{
    int? Id { get; set; }
    DateTime EST_DATA_VALIDADE { get; set; }
    string PRO_ID_PRODUTO { get; set; }
    string PRO_ID_COMPONENTE { get; set; }
    Decimal EST_QUANT { get; set; }
    DateTime EST_DATA_INCLUSAO { get; set; }
    Decimal EST_BASE_PRODUCAO { get; set; }
    string EST_TIPO_REQUISICAO { get; set; }
    string EST_CODIGO_DE_EXCECAO { get; set; }
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