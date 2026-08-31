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
                    public partial class CTeEntradaOficialEntity : ICTeEntradaOficialEntity
{
    public int? Id { get; set; }
    public string CorrelationId { get; set; }
    public string SourceApplication { get; set; }
    public string SourceModule { get; set; }
    public string SourceMessageId { get; set; }
    public string MessageType { get; set; }
    public string MessageVersion { get; set; }
    public DateTime ReceivedAtUtc { get; set; }
    public string PayloadHash { get; set; }
    public string PayloadStorageKey { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CTeEntradaOficialEntity(int? id, string correlationid, string sourceapplication, string sourcemodule, string sourcemessageid, string messagetype, string messageversion, DateTime receivedatutc, string payloadhash, string payloadstoragekey, int status ){
 Id = id; 
 CorrelationId = correlationid; 
 SourceApplication = sourceapplication; 
 SourceModule = sourcemodule; 
 SourceMessageId = sourcemessageid; 
 MessageType = messagetype; 
 MessageVersion = messageversion; 
 ReceivedAtUtc = (receivedatutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : receivedatutc; 
 PayloadHash = payloadhash; 
 PayloadStorageKey = payloadstoragekey; 
 Status = status; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
   if(string.IsNullOrEmpty(SourceApplication))
   this._erroMensagem.Add("Aplicacao Origem deve ser informado.");
   if(string.IsNullOrEmpty(SourceMessageId))
   this._erroMensagem.Add("Mensagem Origem deve ser informado.");
   if(string.IsNullOrEmpty(MessageType))
   this._erroMensagem.Add("Tipo da Mensagem deve ser informado.");
   if(string.IsNullOrEmpty(MessageVersion))
   this._erroMensagem.Add("Versao da Mensagem deve ser informado.");
   if (ReceivedAtUtc == null || ReceivedAtUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Recebido em UTC deve ser informado.");
   if(string.IsNullOrEmpty(PayloadHash))
   this._erroMensagem.Add("Hash do Payload deve ser informado.");
   if (Status == null)
   this._erroMensagem.Add("Status da Entrada deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration