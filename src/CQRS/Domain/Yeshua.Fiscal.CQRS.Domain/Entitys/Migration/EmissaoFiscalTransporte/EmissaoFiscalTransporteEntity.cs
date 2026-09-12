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
                    public partial class EmissaoFiscalTransporteEntity : IEmissaoFiscalTransporteEntity
{
    public int? Id { get; set; }
    public string CorrelationId { get; set; }
    public int OrigemFluxo { get; set; }
    public string? CargaId { get; set; }
    public string? RomaneioId { get; set; }
    public int Ambiente { get; set; }
    public string? EmitenteDocumento { get; set; }
    public string? TomadorDocumento { get; set; }
    public string? TransportadorDocumento { get; set; }
    public string? UFInicio { get; set; }
    public string? UFFim { get; set; }
    public string? MunicipioInicioCodigoIbge { get; set; }
    public string? MunicipioFimCodigoIbge { get; set; }
    public int? QuantidadeNFe { get; set; }
    public int? QuantidadeCTe { get; set; }
    public int? QuantidadeMDFe { get; set; }
    public Decimal? ValorCarga { get; set; }
    public Decimal? PesoBruto { get; set; }
    public Decimal? Volume { get; set; }
    public string? UltimaMensagem { get; set; }
    public DateTime CriadoEmUtc { get; set; }
    public DateTime? AtualizadoEmUtc { get; set; }
    public DateTime? ConcluidoEmUtc { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal EmissaoFiscalTransporteEntity(int? id, string correlationid, int origemfluxo, string? cargaid, string? romaneioid, int ambiente, string? emitentedocumento, string? tomadordocumento, string? transportadordocumento, string? ufinicio, string? uffim, string? municipioiniciocodigoibge, string? municipiofimcodigoibge, int? quantidadenfe, int? quantidadecte, int? quantidademdfe, Decimal? valorcarga, Decimal? pesobruto, Decimal? volume, string? ultimamensagem, DateTime criadoemutc, DateTime? atualizadoemutc, DateTime? concluidoemutc, int status ){
 Id = id; 
 CorrelationId = correlationid; 
 OrigemFluxo = origemfluxo; 
 CargaId = cargaid; 
 RomaneioId = romaneioid; 
 Ambiente = ambiente; 
 EmitenteDocumento = emitentedocumento; 
 TomadorDocumento = tomadordocumento; 
 TransportadorDocumento = transportadordocumento; 
 UFInicio = ufinicio; 
 UFFim = uffim; 
 MunicipioInicioCodigoIbge = municipioiniciocodigoibge; 
 MunicipioFimCodigoIbge = municipiofimcodigoibge; 
 QuantidadeNFe = quantidadenfe; 
 QuantidadeCTe = quantidadecte; 
 QuantidadeMDFe = quantidademdfe; 
 ValorCarga = valorcarga; 
 PesoBruto = pesobruto; 
 Volume = volume; 
 UltimaMensagem = ultimamensagem; 
 CriadoEmUtc = (criadoemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : criadoemutc; 
 AtualizadoEmUtc = atualizadoemutc.HasValue && atualizadoemutc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : atualizadoemutc; 
 ConcluidoEmUtc = concluidoemutc.HasValue && concluidoemutc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : concluidoemutc; 
 Status = status; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
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