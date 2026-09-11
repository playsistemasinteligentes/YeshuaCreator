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
                    public partial class EntradaFiscalContingenciaEntity : IEntradaFiscalContingenciaEntity
{
    public int? Id { get; set; }
    public string CorrelationId { get; set; }
    public string CargaId { get; set; }
    public int TipoSolicitante { get; set; }
    public int Ambiente { get; set; }
    public string SourceApplication { get; set; }
    public string SourceModule { get; set; }
    public string SourceMessageId { get; set; }
    public string EmitenteFiscalDocumento { get; set; }
    public string TomadorDocumento { get; set; }
    public string TransportadorDocumento { get; set; }
    public string RemetenteDocumento { get; set; }
    public string DestinatarioDocumento { get; set; }
    public string UFInicio { get; set; }
    public string UFFim { get; set; }
    public string MunicipioInicioCodigoIbge { get; set; }
    public string MunicipioFimCodigoIbge { get; set; }
    public string RNTRC { get; set; }
    public string PlacaVeiculo { get; set; }
    public string UFVeiculo { get; set; }
    public string CondutorDocumento { get; set; }
    public string CondutorNome { get; set; }
    public int? QuantidadeDocumentos { get; set; }
    public Decimal? ValorCarga { get; set; }
    public Decimal? PesoBruto { get; set; }
    public Decimal? Volume { get; set; }
    public string PendenciasJson { get; set; }
    public string SnapshotJson { get; set; }
    public string EmissaoFiscalCorrelationId { get; set; }
    public int? EmissaoFiscalSagaId { get; set; }
    public DateTime CriadoEmUtc { get; set; }
    public DateTime? AtualizadoEmUtc { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal EntradaFiscalContingenciaEntity(int? id, string correlationid, string cargaid, int tiposolicitante, int ambiente, string sourceapplication, string sourcemodule, string sourcemessageid, string emitentefiscaldocumento, string tomadordocumento, string transportadordocumento, string remetentedocumento, string destinatariodocumento, string ufinicio, string uffim, string municipioiniciocodigoibge, string municipiofimcodigoibge, string rntrc, string placaveiculo, string ufveiculo, string condutordocumento, string condutornome, int? quantidadedocumentos, Decimal? valorcarga, Decimal? pesobruto, Decimal? volume, string pendenciasjson, string snapshotjson, string emissaofiscalcorrelationid, int? emissaofiscalsagaid, DateTime criadoemutc, DateTime? atualizadoemutc, int status ){
 Id = id; 
 CorrelationId = correlationid; 
 CargaId = cargaid; 
 TipoSolicitante = tiposolicitante; 
 Ambiente = ambiente; 
 SourceApplication = sourceapplication; 
 SourceModule = sourcemodule; 
 SourceMessageId = sourcemessageid; 
 EmitenteFiscalDocumento = emitentefiscaldocumento; 
 TomadorDocumento = tomadordocumento; 
 TransportadorDocumento = transportadordocumento; 
 RemetenteDocumento = remetentedocumento; 
 DestinatarioDocumento = destinatariodocumento; 
 UFInicio = ufinicio; 
 UFFim = uffim; 
 MunicipioInicioCodigoIbge = municipioiniciocodigoibge; 
 MunicipioFimCodigoIbge = municipiofimcodigoibge; 
 RNTRC = rntrc; 
 PlacaVeiculo = placaveiculo; 
 UFVeiculo = ufveiculo; 
 CondutorDocumento = condutordocumento; 
 CondutorNome = condutornome; 
 QuantidadeDocumentos = quantidadedocumentos; 
 ValorCarga = valorcarga; 
 PesoBruto = pesobruto; 
 Volume = volume; 
 PendenciasJson = pendenciasjson; 
 SnapshotJson = snapshotjson; 
 EmissaoFiscalCorrelationId = emissaofiscalcorrelationid; 
 EmissaoFiscalSagaId = emissaofiscalsagaid; 
 CriadoEmUtc = (criadoemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : criadoemutc; 
 AtualizadoEmUtc = (atualizadoemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : atualizadoemutc; 
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
   if(string.IsNullOrEmpty(SourceApplication))
   this._erroMensagem.Add("Aplicacao Origem deve ser informado.");
   if(string.IsNullOrEmpty(SourceMessageId))
   this._erroMensagem.Add("Mensagem Origem deve ser informado.");
   if(CriadoEmUtc == null || CriadoEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criado em UTC deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration