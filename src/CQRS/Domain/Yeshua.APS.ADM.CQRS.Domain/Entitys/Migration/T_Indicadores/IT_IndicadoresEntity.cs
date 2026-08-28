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
                    public interface IT_IndicadoresEntity
{
    int IND_ID { get; set; }
    string IND_DESCRICAO { get; set; }
    int NEG_ID { get; set; }
    string DESC_CALCULO { get; set; }
    int IND_TIPOCOMPARADOR { get; set; }
    int? IND_GRAFICO { get; set; }
    string IND_CONEXAO { get; set; }
    DateTime? IND_DTCRIACAO { get; set; }
    string RESPOSAVELIND { get; set; }
    string RESPOSAVELCARGA { get; set; }
    string PROCEXTRACAO { get; set; }
    string PER_ID { get; set; }
    string DIM_ID { get; set; }
    string DOM_EMPRESA { get; set; }
    string DOM_FILIAL { get; set; }
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