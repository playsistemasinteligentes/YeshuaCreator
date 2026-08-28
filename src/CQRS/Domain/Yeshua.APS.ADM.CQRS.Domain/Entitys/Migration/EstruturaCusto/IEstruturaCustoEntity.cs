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
                    public interface IEstruturaCustoEntity
{
    int EST_ID { get; set; }
    int? ITO_ID { get; set; }
    string ORD_ID { get; set; }
    string PRO_ID { get; set; }
    string PRO_ID_PRODUTO { get; set; }
    string PRO_ID_COMPONENTE { get; set; }
    string PRO_TIPO_CUSTO { get; set; }
    string PRO_GRUPO_CONTABIL { get; set; }
    int EST_ORDEM { get; set; }
    string EST_GRUPO { get; set; }
    Decimal EST_QUANT { get; set; }
    Decimal EST_VALOR_TOTAL { get; set; }
    string EST_DATA_BASE { get; set; }
    Decimal EST_BASE_PRODUCAO { get; set; }
    Decimal? EST_NIVEL { get; set; }
    int? FPR_SEQ_REPETICAO { get; set; }
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