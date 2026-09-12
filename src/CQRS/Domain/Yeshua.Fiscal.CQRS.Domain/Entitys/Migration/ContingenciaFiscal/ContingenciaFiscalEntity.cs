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
                    public partial class ContingenciaFiscalEntity : IContingenciaFiscalEntity
{
    public int? Id { get; set; }
    public int? EmissaoFiscalTransporteId { get; set; }
    public int? EntradaFiscalContingenciaId { get; set; }
    public string CorrelationId { get; set; }
    public string CargaId { get; set; }
    public int TipoSolicitante { get; set; }
    public int Ambiente { get; set; }
    public string? EmitenteDocumento { get; set; }
    public string? TomadorDocumento { get; set; }
    public string? TransportadorDocumento { get; set; }
    public int? QuantidadeDocumentos { get; set; }
    public int? QuantidadeCTe { get; set; }
    public int? QuantidadeMDFe { get; set; }
    public Decimal? ValorCarga { get; set; }
    public Decimal? PesoBruto { get; set; }
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
 internal ContingenciaFiscalEntity(int? id, int? emissaofiscaltransporteid, int? entradafiscalcontingenciaid, string correlationid, string cargaid, int tiposolicitante, int ambiente, string? emitentedocumento, string? tomadordocumento, string? transportadordocumento, int? quantidadedocumentos, int? quantidadecte, int? quantidademdfe, Decimal? valorcarga, Decimal? pesobruto, string? ultimamensagem, DateTime criadoemutc, DateTime? atualizadoemutc, DateTime? concluidoemutc, int status ){
 Id = id; 
 EmissaoFiscalTransporteId = emissaofiscaltransporteid; 
 EntradaFiscalContingenciaId = entradafiscalcontingenciaid; 
 CorrelationId = correlationid; 
 CargaId = cargaid; 
 TipoSolicitante = tiposolicitante; 
 Ambiente = ambiente; 
 EmitenteDocumento = emitentedocumento; 
 TomadorDocumento = tomadordocumento; 
 TransportadorDocumento = transportadordocumento; 
 QuantidadeDocumentos = quantidadedocumentos; 
 QuantidadeCTe = quantidadecte; 
 QuantidadeMDFe = quantidademdfe; 
 ValorCarga = valorcarga; 
 PesoBruto = pesobruto; 
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
   if(string.IsNullOrEmpty(CargaId))
   this._erroMensagem.Add("Carga deve ser informado.");
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