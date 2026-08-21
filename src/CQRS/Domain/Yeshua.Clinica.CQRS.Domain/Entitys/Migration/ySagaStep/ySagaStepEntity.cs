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
                    public partial class ySagaStepEntity : IySagaStepEntity
{
    public int? Id { get; set; }
    public int SagaId { get; set; }
    public string StepKey { get; set; }
    public int IndexOrder { get; set; }
    public string CorrelationId { get; set; }
    public int Status { get; set; }
    public int ExecutionCount { get; set; }
    public DateTime? LastExecutionAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string ErrorMessage { get; set; }
    public string Payload { get; set; }
    public int RetryCount { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ySagaStepEntity(int? id, int sagaid, string stepkey, int indexorder, string correlationid, int status, int executioncount, DateTime? lastexecutionat, DateTime? completedat, string errormessage, string payload, int retrycount ){
 Id = id; 
 SagaId = sagaid; 
 StepKey = stepkey; 
 IndexOrder = indexorder; 
 CorrelationId = correlationid; 
 Status = status; 
 ExecutionCount = executioncount; 
 LastExecutionAt = (lastexecutionat < (new DateTime(1800, 1, 1))) ? DateTime.Now : lastexecutionat; 
 CompletedAt = (completedat < (new DateTime(1800, 1, 1))) ? DateTime.Now : completedat; 
 ErrorMessage = errormessage; 
 Payload = payload; 
 RetryCount = retrycount; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (SagaId == null)
   this._erroMensagem.Add("Saga deve ser informado.");
   if(string.IsNullOrEmpty(StepKey))
   this._erroMensagem.Add("Step Key deve ser informado.");
   if (IndexOrder == null)
   this._erroMensagem.Add("Index Order deve ser informado.");
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
   if (Status == null)
   this._erroMensagem.Add("Status deve ser informado.");
   if (ExecutionCount == null)
   this._erroMensagem.Add("Execuções deve ser informado.");
   if (RetryCount == null)
   this._erroMensagem.Add("Tentativas deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration