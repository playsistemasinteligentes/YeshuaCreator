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
                    public partial class NFeProdutoSnapshotEntity : INFeProdutoSnapshotEntity
{
    public int? Id { get; set; }
    public int? DocumentoFiscalOriginarioId { get; set; }
    public string CorrelationId { get; set; }
    public string? CargaId { get; set; }
    public string? PedidoId { get; set; }
    public string ChaveAcesso { get; set; }
    public string? EmitenteDocumento { get; set; }
    public string? DestinatarioDocumento { get; set; }
    public string? UFOrigem { get; set; }
    public string? UFDestino { get; set; }
    public string? MunicipioOrigemCodigoIbge { get; set; }
    public string? MunicipioDestinoCodigoIbge { get; set; }
    public Decimal? ValorDocumento { get; set; }
    public Decimal? PesoBruto { get; set; }
    public Decimal? Volume { get; set; }
    public string? XmlStorageKey { get; set; }
    public string? SnapshotJson { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal NFeProdutoSnapshotEntity(int? id, int? documentofiscaloriginarioid, string correlationid, string? cargaid, string? pedidoid, string chaveacesso, string? emitentedocumento, string? destinatariodocumento, string? uforigem, string? ufdestino, string? municipioorigemcodigoibge, string? municipiodestinocodigoibge, Decimal? valordocumento, Decimal? pesobruto, Decimal? volume, string? xmlstoragekey, string? snapshotjson, int status ){
 Id = id; 
 DocumentoFiscalOriginarioId = documentofiscaloriginarioid; 
 CorrelationId = correlationid; 
 CargaId = cargaid; 
 PedidoId = pedidoid; 
 ChaveAcesso = chaveacesso; 
 EmitenteDocumento = emitentedocumento; 
 DestinatarioDocumento = destinatariodocumento; 
 UFOrigem = uforigem; 
 UFDestino = ufdestino; 
 MunicipioOrigemCodigoIbge = municipioorigemcodigoibge; 
 MunicipioDestinoCodigoIbge = municipiodestinocodigoibge; 
 ValorDocumento = valordocumento; 
 PesoBruto = pesobruto; 
 Volume = volume; 
 XmlStorageKey = xmlstoragekey; 
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
   if(string.IsNullOrEmpty(ChaveAcesso))
   this._erroMensagem.Add("Chave de Acesso deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration