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
                    public partial class CargaPlanejavelEntity : ICargaPlanejavelEntity
{
    public string CargaId { get; set; }
    public string Status { get; set; }
    public string TransportadoraId { get; set; }
    public string VeiculoId { get; set; }
    public int? TipoVeiculoId { get; set; }
    public Decimal? PesoTeorico { get; set; }
    public Decimal? VolumeTeorico { get; set; }
    public DateTime? InicioJanelaEmbarque { get; set; }
    public DateTime? FimJanelaEmbarque { get; set; }
    public DateTime? EmbarqueAlvo { get; set; }
    public int? QuantidadePedidos { get; set; }
    public string AlertasResumo { get; set; }
    private List<string> _erroMensagem = null;
 internal CargaPlanejavelEntity(string cargaid, string status, string transportadoraid, string veiculoid, int? tipoveiculoid, Decimal? pesoteorico, Decimal? volumeteorico, DateTime? iniciojanelaembarque, DateTime? fimjanelaembarque, DateTime? embarquealvo, int? quantidadepedidos, string alertasresumo ){
 CargaId = cargaid; 
 Status = status; 
 TransportadoraId = transportadoraid; 
 VeiculoId = veiculoid; 
 TipoVeiculoId = tipoveiculoid; 
 PesoTeorico = pesoteorico; 
 VolumeTeorico = volumeteorico; 
 InicioJanelaEmbarque = (iniciojanelaembarque < (new DateTime(1800, 1, 1))) ? DateTime.Now : iniciojanelaembarque; 
 FimJanelaEmbarque = (fimjanelaembarque < (new DateTime(1800, 1, 1))) ? DateTime.Now : fimjanelaembarque; 
 EmbarqueAlvo = (embarquealvo < (new DateTime(1800, 1, 1))) ? DateTime.Now : embarquealvo; 
 QuantidadePedidos = quantidadepedidos; 
 AlertasResumo = alertasresumo; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CargaId))
   this._erroMensagem.Add("Carga deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration