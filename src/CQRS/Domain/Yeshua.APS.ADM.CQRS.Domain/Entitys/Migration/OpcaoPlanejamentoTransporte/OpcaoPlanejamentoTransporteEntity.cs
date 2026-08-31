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
                    public partial class OpcaoPlanejamentoTransporteEntity : IOpcaoPlanejamentoTransporteEntity
{
    public string OpcaoId { get; set; }
    public string GrupoDecisaoId { get; set; }
    public Decimal? Peso { get; set; }
    public Decimal? Volume { get; set; }
    public Decimal? CustoEstimado { get; set; }
    public Decimal? AderenciaCubagem { get; set; }
    public Decimal? AderenciaJanelaEntrega { get; set; }
    public string RiscoResumo { get; set; }
    public string PedidosResumo { get; set; }
    public string OpcoesConflitantesResumo { get; set; }
    private List<string> _erroMensagem = null;
 internal OpcaoPlanejamentoTransporteEntity(string opcaoid, string grupodecisaoid, Decimal? peso, Decimal? volume, Decimal? custoestimado, Decimal? aderenciacubagem, Decimal? aderenciajanelaentrega, string riscoresumo, string pedidosresumo, string opcoesconflitantesresumo ){
 OpcaoId = opcaoid; 
 GrupoDecisaoId = grupodecisaoid; 
 Peso = peso; 
 Volume = volume; 
 CustoEstimado = custoestimado; 
 AderenciaCubagem = aderenciacubagem; 
 AderenciaJanelaEntrega = aderenciajanelaentrega; 
 RiscoResumo = riscoresumo; 
 PedidosResumo = pedidosresumo; 
 OpcoesConflitantesResumo = opcoesconflitantesresumo; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(OpcaoId))
   this._erroMensagem.Add("Opcao deve ser informado.");
   if(string.IsNullOrEmpty(GrupoDecisaoId))
   this._erroMensagem.Add("Grupo Decisao deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration