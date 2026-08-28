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
                    public partial class EtiquetaEntity : IEtiquetaEntity
{
    public int ETI_ID { get; set; }
    public DateTime? ETI_EMISSAO { get; set; }
    public string ETI_CODIGO_BARRAS { get; set; }
    public int? ETI_SEQUENCIA { get; set; }
    public int? ETI_NUMERO_COPIAS { get; set; }
    public string ETI_STATUS { get; set; }
    public DateTime? ETI_DATA_FABRICACAO { get; set; }
    public string ETI_COD_BARRAS_ORIGINAL { get; set; }
    public string ETI_OP_ORIGINAL { get; set; }
    public string MAQ_ID { get; set; }
    public int? IMP_ID { get; set; }
    public int? USE_ID { get; set; }
    public string ORD_ID { get; set; }
    public string ROT_PRO_ID { get; set; }
    public int? ROT_SEQ_TRANFORMACAO { get; set; }
    public int? FPR_SEQ_REPETICAO { get; set; }
    public Decimal? ETI_QUANTIDADE_PALETE { get; set; }
    public string ETI_LOTE { get; set; }
    public string ETI_SUB_LOTE { get; set; }
    public int? ETI_IMPRIMIR_DE { get; set; }
    public int? ETI_IMPRIMIR_ATE { get; set; }
    public string BOL_ID { get; set; }
    public int? COR_SEQUENCIA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal EtiquetaEntity(int eti_id, DateTime? eti_emissao, string eti_codigo_barras, int? eti_sequencia, int? eti_numero_copias, string eti_status, DateTime? eti_data_fabricacao, string eti_cod_barras_original, string eti_op_original, string maq_id, int? imp_id, int? use_id, string ord_id, string rot_pro_id, int? rot_seq_tranformacao, int? fpr_seq_repeticao, Decimal? eti_quantidade_palete, string eti_lote, string eti_sub_lote, int? eti_imprimir_de, int? eti_imprimir_ate, string bol_id, int? cor_sequencia ){
 ETI_ID = eti_id; 
 ETI_EMISSAO = (eti_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : eti_emissao; 
 ETI_CODIGO_BARRAS = eti_codigo_barras; 
 ETI_SEQUENCIA = eti_sequencia; 
 ETI_NUMERO_COPIAS = eti_numero_copias; 
 ETI_STATUS = eti_status; 
 ETI_DATA_FABRICACAO = (eti_data_fabricacao < (new DateTime(1800, 1, 1))) ? DateTime.Now : eti_data_fabricacao; 
 ETI_COD_BARRAS_ORIGINAL = eti_cod_barras_original; 
 ETI_OP_ORIGINAL = eti_op_original; 
 MAQ_ID = maq_id; 
 IMP_ID = imp_id; 
 USE_ID = use_id; 
 ORD_ID = ord_id; 
 ROT_PRO_ID = rot_pro_id; 
 ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
 ETI_QUANTIDADE_PALETE = eti_quantidade_palete; 
 ETI_LOTE = eti_lote; 
 ETI_SUB_LOTE = eti_sub_lote; 
 ETI_IMPRIMIR_DE = eti_imprimir_de; 
 ETI_IMPRIMIR_ATE = eti_imprimir_ate; 
 BOL_ID = bol_id; 
 COR_SEQUENCIA = cor_sequencia; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (ETI_ID == null)
   this._erroMensagem.Add("ETI ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration