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
                    public interface ITipoTesteEntity
{
    Decimal? TT_ESPECIFICACAO { get; set; }
    string TT_ORIGEM_ESPECIFICACAO { get; set; }
    string TT_IMPRIME_NO_LAUDO { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    int TT_ID { get; set; }
    string TT_NOME { get; set; }
    string TT_DESC { get; set; }
    Decimal? TT_TOL_MAIS { get; set; }
    Decimal? TT_TOL_MENOS { get; set; }
    string TT_NORMA { get; set; }
    string TT_INICIO_PROCESSO { get; set; }
    int TA_ID { get; set; }
    string UNI_ID { get; set; }
    int? TT_N_AMOSTRAS_P_TESTE { get; set; }
    int? TT_MAX_DEF_CRITICO { get; set; }
    int? TT_MAX_DEF_GRAVE { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration