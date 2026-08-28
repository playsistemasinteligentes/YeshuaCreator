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
                    public interface ITesteFisicoEntity
{
    int? Id { get; set; }
    int TES_ID { get; set; }
    int? ITE_ID { get; set; }
    int? USR_ID { get; set; }
    string TES_NOME_TECNICO { get; set; }
    int? TES_AMOSTRA { get; set; }
    string TES_OP { get; set; }
    Decimal? TES_VALOR_NUMERICO { get; set; }
    DateTime? TES_VALOR_DATA { get; set; }
    string TES_VALOR_TEXTO { get; set; }
    DateTime? TES_EMISSAO { get; set; }
    string ORD_ID { get; set; }
    string PRO_ID { get; set; }
    string MAQ_ID { get; set; }
    int? FPR_SEQ_REPETICAO { get; set; }
    int? FPR_SEQ_TRANFORMACAO { get; set; }
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