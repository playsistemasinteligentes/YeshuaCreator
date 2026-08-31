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
                    public partial class CenarioPlanejamentoTransporteEntity : ICenarioPlanejamentoTransporteEntity
{
    public string CenarioId { get; set; }
    public string Descricao { get; set; }
    public string Objetivo { get; set; }
    public int? QuantidadeCargas { get; set; }
    public int? QuantidadePedidosNaoAtendidos { get; set; }
    public Decimal? CustoTotal { get; set; }
    public Decimal? AderenciaCubagem { get; set; }
    public Decimal? AtrasoPrevisto { get; set; }
    public string AlertasResumo { get; set; }
    private List<string> _erroMensagem = null;
 internal CenarioPlanejamentoTransporteEntity(string cenarioid, string descricao, string objetivo, int? quantidadecargas, int? quantidadepedidosnaoatendidos, Decimal? custototal, Decimal? aderenciacubagem, Decimal? atrasoprevisto, string alertasresumo ){
 CenarioId = cenarioid; 
 Descricao = descricao; 
 Objetivo = objetivo; 
 QuantidadeCargas = quantidadecargas; 
 QuantidadePedidosNaoAtendidos = quantidadepedidosnaoatendidos; 
 CustoTotal = custototal; 
 AderenciaCubagem = aderenciacubagem; 
 AtrasoPrevisto = atrasoprevisto; 
 AlertasResumo = alertasresumo; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CenarioId))
   this._erroMensagem.Add("Cenario deve ser informado.");
   if(string.IsNullOrEmpty(Descricao))
   this._erroMensagem.Add("Descricao deve ser informado.");
   if(string.IsNullOrEmpty(Objetivo))
   this._erroMensagem.Add("Objetivo deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration