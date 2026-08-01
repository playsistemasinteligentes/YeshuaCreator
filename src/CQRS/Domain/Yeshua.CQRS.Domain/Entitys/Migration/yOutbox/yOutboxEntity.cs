
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yOutboxEntity : IyOutboxEntity
{
    public int? Id { get; set; }
    public string MessageId { get; set; }
    public string Type { get; set; }
    public string EntityType { get; set; }
    public string EntityId { get; set; }
    public string CorrelationId { get; set; }
    public string Payload { get; set; }
    public int Status { get; set; }
    public int TransportType { get; set; }
    public string TransportData { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SentAt { get; set; }
    public int RetryCount { get; set; }
    public string LastError { get; set; }
    public DateTime? ProcessingAt { get; set; }
    public DateTime? NextAttemptAt { get; set; }
    public int? SagaId { get; set; }
    public int? SagaStepId { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal yOutboxEntity(int? id, string messageid, string type, string entitytype, string entityid, string correlationid, string payload, int status, int transporttype, string transportdata, DateTime createdat, DateTime? sentat, int retrycount, string lasterror, DateTime? processingat, DateTime? nextattemptat, int? sagaid, int? sagastepid ){
 Id = id; 
 MessageId = messageid; 
 Type = type; 
 EntityType = entitytype; 
 EntityId = entityid; 
 CorrelationId = correlationid; 
 Payload = payload; 
 Status = status; 
 TransportType = transporttype; 
 TransportData = transportdata; 
 CreatedAt = (createdat < (new DateTime(1800, 1, 1))) ? DateTime.Now : createdat; 
 SentAt = (sentat < (new DateTime(1800, 1, 1))) ? DateTime.Now : sentat; 
 RetryCount = retrycount; 
 LastError = lasterror; 
 ProcessingAt = (processingat < (new DateTime(1800, 1, 1))) ? DateTime.Now : processingat; 
 NextAttemptAt = (nextattemptat < (new DateTime(1800, 1, 1))) ? DateTime.Now : nextattemptat; 
 SagaId = sagaid; 
 SagaStepId = sagastepid; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Type))
   this._erroMensagem.Add("Tipo da Mensagem deve ser informado.");
   if(string.IsNullOrEmpty(Payload))
   this._erroMensagem.Add("Payload deve ser informado.");
   if (Status == null)
   this._erroMensagem.Add("Status deve ser informado.");
   if (TransportType == null)
   this._erroMensagem.Add("Tipo de Transporte deve ser informado.");
   if (CreatedAt == null || CreatedAt < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criado em deve ser informado.");
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