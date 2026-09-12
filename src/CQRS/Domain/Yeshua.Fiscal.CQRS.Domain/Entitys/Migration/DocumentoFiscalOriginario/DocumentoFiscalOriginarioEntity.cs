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
                    public partial class DocumentoFiscalOriginarioEntity : IDocumentoFiscalOriginarioEntity
{
    public int? Id { get; set; }
    public int? DocumentoFiscalId { get; set; }
    public string CorrelationId { get; set; }
    public string SourceApplication { get; set; }
    public string? SourceModule { get; set; }
    public string SourceMessageId { get; set; }
    public string TipoDocumento { get; set; }
    public string? ChaveAcesso { get; set; }
    public string? Numero { get; set; }
    public string? Serie { get; set; }
    public string? EmitenteDocumento { get; set; }
    public string? DestinatarioDocumento { get; set; }
    public Decimal? ValorDocumento { get; set; }
    public Decimal? PesoBruto { get; set; }
    public Decimal? Volume { get; set; }
    public string? SnapshotJson { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal DocumentoFiscalOriginarioEntity(int? id, int? documentofiscalid, string correlationid, string sourceapplication, string? sourcemodule, string sourcemessageid, string tipodocumento, string? chaveacesso, string? numero, string? serie, string? emitentedocumento, string? destinatariodocumento, Decimal? valordocumento, Decimal? pesobruto, Decimal? volume, string? snapshotjson, int status ){
 Id = id; 
 DocumentoFiscalId = documentofiscalid; 
 CorrelationId = correlationid; 
 SourceApplication = sourceapplication; 
 SourceModule = sourcemodule; 
 SourceMessageId = sourcemessageid; 
 TipoDocumento = tipodocumento; 
 ChaveAcesso = chaveacesso; 
 Numero = numero; 
 Serie = serie; 
 EmitenteDocumento = emitentedocumento; 
 DestinatarioDocumento = destinatariodocumento; 
 ValorDocumento = valordocumento; 
 PesoBruto = pesobruto; 
 Volume = volume; 
 SnapshotJson = snapshotjson; 
 Status = status; 
 Deleted = false; 
 Changed = DateTime.Now; 
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