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
                    public partial class MDFeSolicitacaoFiscalEntity : IMDFeSolicitacaoFiscalEntity
{
    public int? Id { get; set; }
    public string CorrelationId { get; set; }
    public string CargaId { get; set; }
    public int Ambiente { get; set; }
    public string UFCarregamento { get; set; }
    public string UFDescarregamento { get; set; }
    public string PlacaVeiculo { get; set; }
    public string CondutorDocumento { get; set; }
    public string DocumentosOriginariosJson { get; set; }
    public string TransporteSnapshotJson { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MDFeSolicitacaoFiscalEntity(int? id, string correlationid, string cargaid, int ambiente, string ufcarregamento, string ufdescarregamento, string placaveiculo, string condutordocumento, string documentosoriginariosjson, string transportesnapshotjson, int status ){
 Id = id; 
 CorrelationId = correlationid; 
 CargaId = cargaid; 
 Ambiente = ambiente; 
 UFCarregamento = ufcarregamento; 
 UFDescarregamento = ufdescarregamento; 
 PlacaVeiculo = placaveiculo; 
 CondutorDocumento = condutordocumento; 
 DocumentosOriginariosJson = documentosoriginariosjson; 
 TransporteSnapshotJson = transportesnapshotjson; 
 Status = status; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
   if(string.IsNullOrEmpty(UFCarregamento))
   this._erroMensagem.Add("UF de Carregamento deve ser informado.");
   if(string.IsNullOrEmpty(UFDescarregamento))
   this._erroMensagem.Add("UF de Descarregamento deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration