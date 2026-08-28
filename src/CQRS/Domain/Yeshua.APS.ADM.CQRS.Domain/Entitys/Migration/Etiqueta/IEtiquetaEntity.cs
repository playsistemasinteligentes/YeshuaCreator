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
                    public interface IEtiquetaEntity
{
    int ETI_ID { get; set; }
    DateTime? ETI_EMISSAO { get; set; }
    string ETI_CODIGO_BARRAS { get; set; }
    int? ETI_SEQUENCIA { get; set; }
    int? ETI_NUMERO_COPIAS { get; set; }
    string ETI_STATUS { get; set; }
    DateTime? ETI_DATA_FABRICACAO { get; set; }
    string ETI_COD_BARRAS_ORIGINAL { get; set; }
    string ETI_OP_ORIGINAL { get; set; }
    string MAQ_ID { get; set; }
    int? IMP_ID { get; set; }
    int? USE_ID { get; set; }
    string ORD_ID { get; set; }
    string ROT_PRO_ID { get; set; }
    int? ROT_SEQ_TRANFORMACAO { get; set; }
    int? FPR_SEQ_REPETICAO { get; set; }
    Decimal? ETI_QUANTIDADE_PALETE { get; set; }
    string ETI_LOTE { get; set; }
    string ETI_SUB_LOTE { get; set; }
    int? ETI_IMPRIMIR_DE { get; set; }
    int? ETI_IMPRIMIR_ATE { get; set; }
    string BOL_ID { get; set; }
    int? COR_SEQUENCIA { get; set; }
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