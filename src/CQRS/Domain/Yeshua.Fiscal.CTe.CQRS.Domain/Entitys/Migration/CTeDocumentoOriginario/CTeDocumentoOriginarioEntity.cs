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
                    public partial class CTeDocumentoOriginarioEntity : ICTeDocumentoOriginarioEntity
{
    public int? Id { get; set; }
    public int CTeSolicitacaoFiscalId { get; set; }
    public string TipoDocumento { get; set; }
    public string ChaveAcesso { get; set; }
    public string Numero { get; set; }
    public string Serie { get; set; }
    public string EmitenteDocumento { get; set; }
    public string DestinatarioDocumento { get; set; }
    public Decimal? ValorDocumento { get; set; }
    public Decimal? PesoBruto { get; set; }
    public string SnapshotJson { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CTeDocumentoOriginarioEntity(int? id, int ctesolicitacaofiscalid, string tipodocumento, string chaveacesso, string numero, string serie, string emitentedocumento, string destinatariodocumento, Decimal? valordocumento, Decimal? pesobruto, string snapshotjson ){
 Id = id; 
 CTeSolicitacaoFiscalId = ctesolicitacaofiscalid; 
 TipoDocumento = tipodocumento; 
 ChaveAcesso = chaveacesso; 
 Numero = numero; 
 Serie = serie; 
 EmitenteDocumento = emitentedocumento; 
 DestinatarioDocumento = destinatariodocumento; 
 ValorDocumento = valordocumento; 
 PesoBruto = pesobruto; 
 SnapshotJson = snapshotjson; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (CTeSolicitacaoFiscalId == null)
   this._erroMensagem.Add("Solicitacao CT-e deve ser informado.");
   if(string.IsNullOrEmpty(TipoDocumento))
   this._erroMensagem.Add("Tipo Documento deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration