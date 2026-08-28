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
                    public interface ICalendarioDisponibilidadeVeiculosEntity
{
    int? Id { get; set; }
    int CDV_ID { get; set; }
    DateTime? CDV_DATA_DE { get; set; }
    DateTime? CDV_DATA_ATE { get; set; }
    int? CDV_SEGUNDA { get; set; }
    int? CDV_TERCA { get; set; }
    int? CDV_QUARTA { get; set; }
    int? CDV_QUINTA { get; set; }
    int? CDV_SEXTA { get; set; }
    int? CDV_SABADO { get; set; }
    int? CDV_DOMINGO { get; set; }
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