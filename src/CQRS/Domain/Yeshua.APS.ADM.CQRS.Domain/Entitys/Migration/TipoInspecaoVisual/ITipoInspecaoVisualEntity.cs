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
                    public interface ITipoInspecaoVisualEntity
{
    int? Id { get; set; }
    int TIV_ID { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    string TIV_NOME { get; set; }
    string TIV_DESCRICAO { get; set; }
    string TIV_FECHAMENTO { get; set; }
    string TIV_AMOSTRA_ALEATORIA { get; set; }
    int? TIV_N_AMOSTRAS { get; set; }
    string TIV_MEDIDA { get; set; }
    Decimal? TIV_ESPECIFICACAO { get; set; }
    Decimal? TIV_TOL_MAIS { get; set; }
    Decimal? TIV_TOL_MENOS { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration