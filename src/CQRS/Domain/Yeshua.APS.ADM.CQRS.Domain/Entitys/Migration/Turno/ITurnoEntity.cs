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
                    public interface ITurnoEntity
{
    string Id { get; set; }
    string Descricao { get; set; }
    int TURN_PRIORIDADE { get; set; }
    DateTime? TURN_HORA_INI_DIA1 { get; set; }
    DateTime? TURN_HORA_FIM_DIA1 { get; set; }
    DateTime? TURN_HORA_INI_DIA2 { get; set; }
    DateTime? TURN_HORA_FIM_DIA2 { get; set; }
    DateTime? TURN_HORA_INI_DIA3 { get; set; }
    DateTime? TURN_HORA_FIM_DIA3 { get; set; }
    DateTime? TURN_HORA_INI_DIA4 { get; set; }
    DateTime? TURN_HORA_FIM_DIA4 { get; set; }
    DateTime? TURN_HORA_INI_DIA5 { get; set; }
    DateTime? TURN_HORA_FIM_DIA5 { get; set; }
    DateTime? TURN_HORA_INI_DIA6 { get; set; }
    DateTime? TURN_HORA_FIM_DIA6 { get; set; }
    DateTime? TURN_HORA_INI_DIA7 { get; set; }
    DateTime? TURN_HORA_FIM_DIA7 { get; set; }
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