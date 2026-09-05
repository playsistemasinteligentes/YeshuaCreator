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
                    public partial class FeedbackEntity : IFeedbackEntity
{
    public int Id { get; set; }
    public DateTime DataInicial { get; set; }
    public DateTime Datafinal { get; set; }
    public string MaquinaId { get; set; }
    public string OcorrenciaId { get; set; }
    public string TurnoId { get; set; }
    public string TurmaId { get; set; }
    public int UsuarioId { get; set; }
    public string OrderId { get; set; }
    public string ProdutoId { get; set; }
    public string Observacoes { get; set; }
    public Decimal Grupo { get; set; }
    public string DiaTurma { get; set; }
    public int? SequenciaTransformacao { get; set; }
    public int? SequenciaRepeticao { get; set; }
    public Decimal QuantidadePulsos { get; set; }
    public Decimal? QuantidadePecasPorPulso { get; set; }
    public Decimal? FEE_QTD_TOTAL_PRODUCAO_AJUSTADA { get; set; }
    public string BOL_ID { get; set; }
    public int? COR_SEQUENCIA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal FeedbackEntity(int id, DateTime datainicial, DateTime datafinal, string maquinaid, string ocorrenciaid, string turnoid, string turmaid, int usuarioid, string orderid, string produtoid, string observacoes, Decimal grupo, string diaturma, int? sequenciatransformacao, int? sequenciarepeticao, Decimal quantidadepulsos, Decimal? quantidadepecasporpulso, Decimal? fee_qtd_total_producao_ajustada, string bol_id, int? cor_sequencia ){
 Id = id; 
 DataInicial = (datainicial < (new DateTime(1800, 1, 1))) ? DateTime.Now : datainicial; 
 Datafinal = (datafinal < (new DateTime(1800, 1, 1))) ? DateTime.Now : datafinal; 
 MaquinaId = maquinaid; 
 OcorrenciaId = ocorrenciaid; 
 TurnoId = turnoid; 
 TurmaId = turmaid; 
 UsuarioId = usuarioid; 
 OrderId = orderid; 
 ProdutoId = produtoid; 
 Observacoes = observacoes; 
 Grupo = grupo; 
 DiaTurma = diaturma; 
 SequenciaTransformacao = sequenciatransformacao; 
 SequenciaRepeticao = sequenciarepeticao; 
 QuantidadePulsos = quantidadepulsos; 
 QuantidadePecasPorPulso = quantidadepecasporpulso; 
 FEE_QTD_TOTAL_PRODUCAO_AJUSTADA = fee_qtd_total_producao_ajustada; 
 BOL_ID = bol_id; 
 COR_SEQUENCIA = cor_sequencia; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(DataInicial == null || DataInicial < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("DataInicial deve ser informado.");
   if(Datafinal == null || Datafinal < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Datafinal deve ser informado.");
   if(string.IsNullOrEmpty(MaquinaId))
   this._erroMensagem.Add("MaquinaId deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration