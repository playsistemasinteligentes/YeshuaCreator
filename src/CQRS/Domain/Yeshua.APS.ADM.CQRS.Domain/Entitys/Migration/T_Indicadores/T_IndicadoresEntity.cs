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
                    public partial class T_IndicadoresEntity : IT_IndicadoresEntity
{
    public int IND_ID { get; set; }
    public string IND_DESCRICAO { get; set; }
    public int NEG_ID { get; set; }
    public string DESC_CALCULO { get; set; }
    public int IND_TIPOCOMPARADOR { get; set; }
    public int? IND_GRAFICO { get; set; }
    public string IND_CONEXAO { get; set; }
    public DateTime? IND_DTCRIACAO { get; set; }
    public string RESPOSAVELIND { get; set; }
    public string RESPOSAVELCARGA { get; set; }
    public string PROCEXTRACAO { get; set; }
    public string PER_ID { get; set; }
    public string DIM_ID { get; set; }
    public string DOM_EMPRESA { get; set; }
    public string DOM_FILIAL { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_IndicadoresEntity(int ind_id, string ind_descricao, int neg_id, string desc_calculo, int ind_tipocomparador, int? ind_grafico, string ind_conexao, DateTime? ind_dtcriacao, string resposavelind, string resposavelcarga, string procextracao, string per_id, string dim_id, string dom_empresa, string dom_filial ){
 IND_ID = ind_id; 
 IND_DESCRICAO = ind_descricao; 
 NEG_ID = neg_id; 
 DESC_CALCULO = desc_calculo; 
 IND_TIPOCOMPARADOR = ind_tipocomparador; 
 IND_GRAFICO = ind_grafico; 
 IND_CONEXAO = ind_conexao; 
 IND_DTCRIACAO = (ind_dtcriacao < (new DateTime(1800, 1, 1))) ? DateTime.Now : ind_dtcriacao; 
 RESPOSAVELIND = resposavelind; 
 RESPOSAVELCARGA = resposavelcarga; 
 PROCEXTRACAO = procextracao; 
 PER_ID = per_id; 
 DIM_ID = dim_id; 
 DOM_EMPRESA = dom_empresa; 
 DOM_FILIAL = dom_filial; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (IND_ID == null)
   this._erroMensagem.Add("IND ID deve ser informado.");
   if(string.IsNullOrEmpty(IND_DESCRICAO))
   this._erroMensagem.Add("IND DESCRICAO deve ser informado.");
   if (NEG_ID == null)
   this._erroMensagem.Add("NEG ID deve ser informado.");
   if (IND_TIPOCOMPARADOR == null)
   this._erroMensagem.Add("IND TIPOCOMPARADOR deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration