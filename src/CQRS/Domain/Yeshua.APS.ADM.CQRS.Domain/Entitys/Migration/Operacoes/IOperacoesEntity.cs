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
                    public interface IOperacoesEntity
{
    int? Id { get; set; }
    string OPE_TIPO_REGISTRO { get; set; }
    string OPE_ID { get; set; }
    string GMA_ID { get; set; }
    string MAQ_ID { get; set; }
    string PRO_ID { get; set; }
    string OPE_EXCECAO { get; set; }
    int ROT_SEQ_TRANFORMACAO { get; set; }
    string ORD_ID { get; set; }
    int FPR_SEQ_REPETICAO { get; set; }
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