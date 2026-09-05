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
                    public partial class TesteFisicoEntity : ITesteFisicoEntity
{
    public int? Id { get; set; }
    public int TES_ID { get; set; }
    public int? ITE_ID { get; set; }
    public int? USR_ID { get; set; }
    public string TES_NOME_TECNICO { get; set; }
    public int? TES_AMOSTRA { get; set; }
    public string TES_OP { get; set; }
    public Decimal? TES_VALOR_NUMERICO { get; set; }
    public DateTime? TES_VALOR_DATA { get; set; }
    public string TES_VALOR_TEXTO { get; set; }
    public DateTime? TES_EMISSAO { get; set; }
    public string ORD_ID { get; set; }
    public string PRO_ID { get; set; }
    public string MAQ_ID { get; set; }
    public int? FPR_SEQ_REPETICAO { get; set; }
    public int? FPR_SEQ_TRANFORMACAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TesteFisicoEntity(int? id, int tes_id, int? ite_id, int? usr_id, string tes_nome_tecnico, int? tes_amostra, string tes_op, Decimal? tes_valor_numerico, DateTime? tes_valor_data, string tes_valor_texto, DateTime? tes_emissao, string ord_id, string pro_id, string maq_id, int? fpr_seq_repeticao, int? fpr_seq_tranformacao ){
 Id = id; 
 TES_ID = tes_id; 
 ITE_ID = ite_id; 
 USR_ID = usr_id; 
 TES_NOME_TECNICO = tes_nome_tecnico; 
 TES_AMOSTRA = tes_amostra; 
 TES_OP = tes_op; 
 TES_VALOR_NUMERICO = tes_valor_numerico; 
 TES_VALOR_DATA = (tes_valor_data < (new DateTime(1800, 1, 1))) ? DateTime.Now : tes_valor_data; 
 TES_VALOR_TEXTO = tes_valor_texto; 
 TES_EMISSAO = (tes_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : tes_emissao; 
 ORD_ID = ord_id; 
 PRO_ID = pro_id; 
 MAQ_ID = maq_id; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
 FPR_SEQ_TRANFORMACAO = fpr_seq_tranformacao; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration