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
                    public partial class EstruturaCustoEntity : IEstruturaCustoEntity
{
    public int EST_ID { get; set; }
    public int? ITO_ID { get; set; }
    public string ORD_ID { get; set; }
    public string PRO_ID { get; set; }
    public string PRO_ID_PRODUTO { get; set; }
    public string PRO_ID_COMPONENTE { get; set; }
    public string PRO_TIPO_CUSTO { get; set; }
    public string PRO_GRUPO_CONTABIL { get; set; }
    public int EST_ORDEM { get; set; }
    public string EST_GRUPO { get; set; }
    public Decimal EST_QUANT { get; set; }
    public Decimal EST_VALOR_TOTAL { get; set; }
    public string EST_DATA_BASE { get; set; }
    public Decimal EST_BASE_PRODUCAO { get; set; }
    public Decimal? EST_NIVEL { get; set; }
    public int? FPR_SEQ_REPETICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal EstruturaCustoEntity(int est_id, int? ito_id, string ord_id, string pro_id, string pro_id_produto, string pro_id_componente, string pro_tipo_custo, string pro_grupo_contabil, int est_ordem, string est_grupo, Decimal est_quant, Decimal est_valor_total, string est_data_base, Decimal est_base_producao, Decimal? est_nivel, int? fpr_seq_repeticao ){
 EST_ID = est_id; 
 ITO_ID = ito_id; 
 ORD_ID = ord_id; 
 PRO_ID = pro_id; 
 PRO_ID_PRODUTO = pro_id_produto; 
 PRO_ID_COMPONENTE = pro_id_componente; 
 PRO_TIPO_CUSTO = pro_tipo_custo; 
 PRO_GRUPO_CONTABIL = pro_grupo_contabil; 
 EST_ORDEM = est_ordem; 
 EST_GRUPO = est_grupo; 
 EST_QUANT = est_quant; 
 EST_VALOR_TOTAL = est_valor_total; 
 EST_DATA_BASE = est_data_base; 
 EST_BASE_PRODUCAO = est_base_producao; 
 EST_NIVEL = est_nivel; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (EST_ID == null)
   this._erroMensagem.Add("EST ID deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID))
   this._erroMensagem.Add("PRO ID deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID_PRODUTO))
   this._erroMensagem.Add("PRO ID PRODUTO deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID_COMPONENTE))
   this._erroMensagem.Add("PRO ID COMPONENTE deve ser informado.");
   if(string.IsNullOrEmpty(PRO_TIPO_CUSTO))
   this._erroMensagem.Add("PRO TIPO CUSTO deve ser informado.");
   if(string.IsNullOrEmpty(PRO_GRUPO_CONTABIL))
   this._erroMensagem.Add("PRO GRUPO CONTABIL deve ser informado.");
   if (EST_ORDEM == null)
   this._erroMensagem.Add("EST ORDEM deve ser informado.");
   if(string.IsNullOrEmpty(EST_GRUPO))
   this._erroMensagem.Add("EST GRUPO deve ser informado.");
   if (EST_QUANT == null)
   this._erroMensagem.Add("EST QUANT deve ser informado.");
   if (EST_VALOR_TOTAL == null)
   this._erroMensagem.Add("EST VALOR TOTAL deve ser informado.");
   if(string.IsNullOrEmpty(EST_DATA_BASE))
   this._erroMensagem.Add("EST DATA BASE deve ser informado.");
   if (EST_BASE_PRODUCAO == null)
   this._erroMensagem.Add("EST BASE PRODUCAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration