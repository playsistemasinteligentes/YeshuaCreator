
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
    public string JobId { get; set; }
    public string CorrelationId { get; set; }
    public string Type { get; set; }
    public string Payload { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SentAt { get; set; }
    public int RetryCount { get; set; }
    public string LastError { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal yOutboxEntity(int? id, string correlationid, string type, string payload, int status, DateTime createdat, DateTime? sentat, int retrycount, string lasterror ){
 Id = id; 
 CorrelationId = correlationid; 
 Type = type; 
 Payload = payload; 
 Status = status; 
 CreatedAt = (createdat < (new DateTime(1800, 1, 1))) ? DateTime.Now : createdat; 
 SentAt = (sentat < (new DateTime(1800, 1, 1))) ? DateTime.Now : sentat; 
 RetryCount = retrycount; 
 LastError = lasterror; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("Correlation Id deve ser informado.");
   if(string.IsNullOrEmpty(Type))
   this._erroMensagem.Add("Tipo da Mensagem deve ser informado.");
   if(string.IsNullOrEmpty(Payload))
   this._erroMensagem.Add("Payload deve ser informado.");
   if (Status == null)
   this._erroMensagem.Add("Status deve ser informado.");
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