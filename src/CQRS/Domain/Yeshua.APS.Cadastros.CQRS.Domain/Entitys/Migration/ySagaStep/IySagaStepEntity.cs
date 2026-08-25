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
                    public interface IySagaStepEntity
{
    int? Id { get; set; }
    int SagaId { get; set; }
    string StepKey { get; set; }
    int IndexOrder { get; set; }
    string CorrelationId { get; set; }
    int Status { get; set; }
    int ExecutionCount { get; set; }
    DateTime? LastExecutionAt { get; set; }
    DateTime? CompletedAt { get; set; }
    string ErrorMessage { get; set; }
    string Payload { get; set; }
    int RetryCount { get; set; }
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