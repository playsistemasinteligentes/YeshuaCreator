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
                    public partial class CTeRomaneioConsolidadoEntity : ICTeRomaneioConsolidadoEntity
{
    public int? Id { get; set; }
    public int EntradaOficialId { get; set; }
    public string CorrelationId { get; set; }
    public string RomaneioId { get; set; }
    public string CargaId { get; set; }
    public DateTime ConsolidadoEmUtc { get; set; }
    public string UFInicio { get; set; }
    public string UFFim { get; set; }
    public string MunicipioInicioCodigoIbge { get; set; }
    public string MunicipioFimCodigoIbge { get; set; }
    public string EmitenteDocumento { get; set; }
    public string TomadorDocumento { get; set; }
    public string RotaSnapshotJson { get; set; }
    public string CargaSnapshotJson { get; set; }
    public string PreferenciasFiscaisJson { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CTeRomaneioConsolidadoEntity(int? id, int entradaoficialid, string correlationid, string romaneioid, string cargaid, DateTime consolidadoemutc, string ufinicio, string uffim, string municipioiniciocodigoibge, string municipiofimcodigoibge, string emitentedocumento, string tomadordocumento, string rotasnapshotjson, string cargasnapshotjson, string preferenciasfiscaisjson, int status ){
 Id = id; 
 EntradaOficialId = entradaoficialid; 
 CorrelationId = correlationid; 
 RomaneioId = romaneioid; 
 CargaId = cargaid; 
 ConsolidadoEmUtc = (consolidadoemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : consolidadoemutc; 
 UFInicio = ufinicio; 
 UFFim = uffim; 
 MunicipioInicioCodigoIbge = municipioiniciocodigoibge; 
 MunicipioFimCodigoIbge = municipiofimcodigoibge; 
 EmitenteDocumento = emitentedocumento; 
 TomadorDocumento = tomadordocumento; 
 RotaSnapshotJson = rotasnapshotjson; 
 CargaSnapshotJson = cargasnapshotjson; 
 PreferenciasFiscaisJson = preferenciasfiscaisjson; 
 Status = status; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (EntradaOficialId == null)
   this._erroMensagem.Add("Entrada Oficial deve ser informado.");
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
   if(string.IsNullOrEmpty(RomaneioId))
   this._erroMensagem.Add("Romaneio deve ser informado.");
   if (ConsolidadoEmUtc == null || ConsolidadoEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Consolidado em UTC deve ser informado.");
   if(string.IsNullOrEmpty(UFInicio))
   this._erroMensagem.Add("UF Inicio deve ser informado.");
   if(string.IsNullOrEmpty(UFFim))
   this._erroMensagem.Add("UF Fim deve ser informado.");
   if (Status == null)
   this._erroMensagem.Add("Status do Romaneio deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration