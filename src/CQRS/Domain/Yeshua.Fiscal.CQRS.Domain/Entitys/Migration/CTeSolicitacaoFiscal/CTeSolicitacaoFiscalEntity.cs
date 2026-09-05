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
                    public partial class CTeSolicitacaoFiscalEntity : ICTeSolicitacaoFiscalEntity
{
    public int? Id { get; set; }
    public int? EntradaOficialId { get; set; }
    public int? RomaneioConsolidadoId { get; set; }
    public string CorrelationId { get; set; }
    public int Ambiente { get; set; }
    public string UFEmitente { get; set; }
    public string EmitenteDocumento { get; set; }
    public int ProdutoFiscal { get; set; }
    public int TipoCTe { get; set; }
    public int TipoServico { get; set; }
    public int Modal { get; set; }
    public int Globalizado { get; set; }
    public string UFInicio { get; set; }
    public string UFFim { get; set; }
    public string MunicipioInicioCodigoIbge { get; set; }
    public string MunicipioFimCodigoIbge { get; set; }
    public Decimal? ValorServico { get; set; }
    public Decimal? ValorCarga { get; set; }
    public string PreferenciasManifestoJson { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CTeSolicitacaoFiscalEntity(int? id, int? entradaoficialid, int? romaneioconsolidadoid, string correlationid, int ambiente, string ufemitente, string emitentedocumento, int produtofiscal, int tipocte, int tiposervico, int modal, int globalizado, string ufinicio, string uffim, string municipioiniciocodigoibge, string municipiofimcodigoibge, Decimal? valorservico, Decimal? valorcarga, string preferenciasmanifestojson, int status ){
 Id = id; 
 EntradaOficialId = entradaoficialid; 
 RomaneioConsolidadoId = romaneioconsolidadoid; 
 CorrelationId = correlationid; 
 Ambiente = ambiente; 
 UFEmitente = ufemitente; 
 EmitenteDocumento = emitentedocumento; 
 ProdutoFiscal = produtofiscal; 
 TipoCTe = tipocte; 
 TipoServico = tiposervico; 
 Modal = modal; 
 Globalizado = globalizado; 
 UFInicio = ufinicio; 
 UFFim = uffim; 
 MunicipioInicioCodigoIbge = municipioiniciocodigoibge; 
 MunicipioFimCodigoIbge = municipiofimcodigoibge; 
 ValorServico = valorservico; 
 ValorCarga = valorcarga; 
 PreferenciasManifestoJson = preferenciasmanifestojson; 
 Status = status; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
   if(string.IsNullOrEmpty(UFEmitente))
   this._erroMensagem.Add("UF Emitente deve ser informado.");
   if(string.IsNullOrEmpty(EmitenteDocumento))
   this._erroMensagem.Add("Emitente Documento deve ser informado.");
   if(string.IsNullOrEmpty(UFInicio))
   this._erroMensagem.Add("UF Inicio deve ser informado.");
   if(string.IsNullOrEmpty(UFFim))
   this._erroMensagem.Add("UF Fim deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration