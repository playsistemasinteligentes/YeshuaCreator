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
                    public partial class DocumentoFiscalEntity : IDocumentoFiscalEntity
{
    public int? Id { get; set; }
    public string CorrelationId { get; set; }
    public int ProdutoFiscal { get; set; }
    public string ChaveAcesso { get; set; }
    public int? Serie { get; set; }
    public int? Numero { get; set; }
    public int Ambiente { get; set; }
    public string UFEmitente { get; set; }
    public string EmitenteDocumento { get; set; }
    public string DestinatarioDocumento { get; set; }
    public string XmlStorageKey { get; set; }
    public string XmlHash { get; set; }
    public string ProtocoloAutorizacao { get; set; }
    public string CodigoRetorno { get; set; }
    public string MensagemRetorno { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal DocumentoFiscalEntity(int? id, string correlationid, int produtofiscal, string chaveacesso, int? serie, int? numero, int ambiente, string ufemitente, string emitentedocumento, string destinatariodocumento, string xmlstoragekey, string xmlhash, string protocoloautorizacao, string codigoretorno, string mensagemretorno, int status ){
 Id = id; 
 CorrelationId = correlationid; 
 ProdutoFiscal = produtofiscal; 
 ChaveAcesso = chaveacesso; 
 Serie = serie; 
 Numero = numero; 
 Ambiente = ambiente; 
 UFEmitente = ufemitente; 
 EmitenteDocumento = emitentedocumento; 
 DestinatarioDocumento = destinatariodocumento; 
 XmlStorageKey = xmlstoragekey; 
 XmlHash = xmlhash; 
 ProtocoloAutorizacao = protocoloautorizacao; 
 CodigoRetorno = codigoretorno; 
 MensagemRetorno = mensagemretorno; 
 Status = status; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration