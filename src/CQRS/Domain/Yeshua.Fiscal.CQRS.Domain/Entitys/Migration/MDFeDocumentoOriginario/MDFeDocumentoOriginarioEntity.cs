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
                    public partial class MDFeDocumentoOriginarioEntity : IMDFeDocumentoOriginarioEntity
{
    public int? Id { get; set; }
    public int MDFeSolicitacaoFiscalId { get; set; }
    public int? DocumentoFiscalOriginarioId { get; set; }
    public string TipoDocumento { get; set; }
    public string? ChaveAcesso { get; set; }
    public string? SnapshotJson { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal MDFeDocumentoOriginarioEntity(int? id, int mdfesolicitacaofiscalid, int? documentofiscaloriginarioid, string tipodocumento, string? chaveacesso, string? snapshotjson ){
 Id = id; 
 MDFeSolicitacaoFiscalId = mdfesolicitacaofiscalid; 
 DocumentoFiscalOriginarioId = documentofiscaloriginarioid; 
 TipoDocumento = tipodocumento; 
 ChaveAcesso = chaveacesso; 
 SnapshotJson = snapshotjson; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
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