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
                    public partial class EmissaoFiscalTransporteDocumentoEntity : IEmissaoFiscalTransporteDocumentoEntity
{
    public int? Id { get; set; }
    public int EmissaoFiscalTransporteId { get; set; }
    public int? DocumentoFiscalId { get; set; }
    public int? DocumentoFiscalOriginarioId { get; set; }
    public int? NFeProdutoSnapshotId { get; set; }
    public int ProdutoFiscal { get; set; }
    public int Papel { get; set; }
    public string? TipoEvento { get; set; }
    public string? ChaveAcesso { get; set; }
    public string? XmlStorageKey { get; set; }
    public string? PdfStorageKey { get; set; }
    public string? Protocolo { get; set; }
    public string? CodigoRetorno { get; set; }
    public string? MensagemRetorno { get; set; }
    public DateTime CriadoEmUtc { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal EmissaoFiscalTransporteDocumentoEntity(int? id, int emissaofiscaltransporteid, int? documentofiscalid, int? documentofiscaloriginarioid, int? nfeprodutosnapshotid, int produtofiscal, int papel, string? tipoevento, string? chaveacesso, string? xmlstoragekey, string? pdfstoragekey, string? protocolo, string? codigoretorno, string? mensagemretorno, DateTime criadoemutc, int status ){
 Id = id; 
 EmissaoFiscalTransporteId = emissaofiscaltransporteid; 
 DocumentoFiscalId = documentofiscalid; 
 DocumentoFiscalOriginarioId = documentofiscaloriginarioid; 
 NFeProdutoSnapshotId = nfeprodutosnapshotid; 
 ProdutoFiscal = produtofiscal; 
 Papel = papel; 
 TipoEvento = tipoevento; 
 ChaveAcesso = chaveacesso; 
 XmlStorageKey = xmlstoragekey; 
 PdfStorageKey = pdfstoragekey; 
 Protocolo = protocolo; 
 CodigoRetorno = codigoretorno; 
 MensagemRetorno = mensagemretorno; 
 CriadoEmUtc = (criadoemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : criadoemutc; 
 Status = status; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(CriadoEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criado em UTC deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration