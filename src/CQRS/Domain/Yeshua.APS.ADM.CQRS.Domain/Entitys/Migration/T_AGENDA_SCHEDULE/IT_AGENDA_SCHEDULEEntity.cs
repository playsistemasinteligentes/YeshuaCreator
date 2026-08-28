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
                    public interface IT_AGENDA_SCHEDULEEntity
{
    int? Id { get; set; }
    int AGE_ID { get; set; }
    DateTime? AGE_DATA_ESPECIFICA { get; set; }
    string AGE_HORARIO_INICIO { get; set; }
    string AGE_HORARIO_FIM { get; set; }
    string AGE_SEGUNDA { get; set; }
    string AGE_TERCA { get; set; }
    string AGE_QUARTA { get; set; }
    string AGE_QUINTA { get; set; }
    string AGE_SEXTA { get; set; }
    string AGE_SABADO { get; set; }
    string AGE_DOMINGO { get; set; }
    Decimal? AGE_INTERVALO { get; set; }
    string AGE_ORDEM_EXECUCAO { get; set; }
    string AGE_PARAMETROS { get; set; }
    string AGE_EXCECAO { get; set; }
    string AGE_DESCRICAO { get; set; }
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