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
                    public partial class TipoTesteEntity : ITipoTesteEntity
{
    public Decimal? TT_ESPECIFICACAO { get; set; }
    public string TT_ORIGEM_ESPECIFICACAO { get; set; }
    public string TT_IMPRIME_NO_LAUDO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public int TT_ID { get; set; }
    public string TT_NOME { get; set; }
    public string TT_DESC { get; set; }
    public Decimal? TT_TOL_MAIS { get; set; }
    public Decimal? TT_TOL_MENOS { get; set; }
    public string TT_NORMA { get; set; }
    public string TT_INICIO_PROCESSO { get; set; }
    public int TA_ID { get; set; }
    public string UNI_ID { get; set; }
    public int? TT_N_AMOSTRAS_P_TESTE { get; set; }
    public int? TT_MAX_DEF_CRITICO { get; set; }
    public int? TT_MAX_DEF_GRAVE { get; set; }
    private List<string> _erroMensagem = null;
 internal TipoTesteEntity(Decimal? tt_especificacao, string tt_origem_especificacao, string tt_imprime_no_laudo, int tt_id, string tt_nome, string tt_desc, Decimal? tt_tol_mais, Decimal? tt_tol_menos, string tt_norma, string tt_inicio_processo, int ta_id, string uni_id, int? tt_n_amostras_p_teste, int? tt_max_def_critico, int? tt_max_def_grave ){
 TT_ESPECIFICACAO = tt_especificacao; 
 TT_ORIGEM_ESPECIFICACAO = tt_origem_especificacao; 
 TT_IMPRIME_NO_LAUDO = tt_imprime_no_laudo; 
 TT_ID = tt_id; 
 TT_NOME = tt_nome; 
 TT_DESC = tt_desc; 
 TT_TOL_MAIS = tt_tol_mais; 
 TT_TOL_MENOS = tt_tol_menos; 
 TT_NORMA = tt_norma; 
 TT_INICIO_PROCESSO = tt_inicio_processo; 
 TA_ID = ta_id; 
 UNI_ID = uni_id; 
 TT_N_AMOSTRAS_P_TESTE = tt_n_amostras_p_teste; 
 TT_MAX_DEF_CRITICO = tt_max_def_critico; 
 TT_MAX_DEF_GRAVE = tt_max_def_grave; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (TT_ID == null)
   this._erroMensagem.Add("TT ID deve ser informado.");
   if(string.IsNullOrEmpty(TT_NOME))
   this._erroMensagem.Add("TT NOME deve ser informado.");
   if(string.IsNullOrEmpty(TT_DESC))
   this._erroMensagem.Add("TT DESC deve ser informado.");
   if(string.IsNullOrEmpty(TT_INICIO_PROCESSO))
   this._erroMensagem.Add("TT INICIO PROCESSO deve ser informado.");
   if (TA_ID == null)
   this._erroMensagem.Add("TA ID deve ser informado.");
   if(string.IsNullOrEmpty(UNI_ID))
   this._erroMensagem.Add("UNI ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration