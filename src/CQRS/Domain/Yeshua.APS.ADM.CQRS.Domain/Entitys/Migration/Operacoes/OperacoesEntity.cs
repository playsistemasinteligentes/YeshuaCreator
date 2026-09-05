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
                    public partial class OperacoesEntity : IOperacoesEntity
{
    public int? Id { get; set; }
    public string OPE_TIPO_REGISTRO { get; set; }
    public string OPE_ID { get; set; }
    public string GMA_ID { get; set; }
    public string MAQ_ID { get; set; }
    public string PRO_ID { get; set; }
    public string OPE_EXCECAO { get; set; }
    public int ROT_SEQ_TRANFORMACAO { get; set; }
    public string ORD_ID { get; set; }
    public int FPR_SEQ_REPETICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal OperacoesEntity(int? id, string ope_tipo_registro, string ope_id, string gma_id, string maq_id, string pro_id, string ope_excecao, int rot_seq_tranformacao, string ord_id, int fpr_seq_repeticao ){
 Id = id; 
 OPE_TIPO_REGISTRO = ope_tipo_registro; 
 OPE_ID = ope_id; 
 GMA_ID = gma_id; 
 MAQ_ID = maq_id; 
 PRO_ID = pro_id; 
 OPE_EXCECAO = ope_excecao; 
 ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao; 
 ORD_ID = ord_id; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(OPE_TIPO_REGISTRO))
   this._erroMensagem.Add("OPE TIPO REGISTRO deve ser informado.");
   if(string.IsNullOrEmpty(OPE_ID))
   this._erroMensagem.Add("OPE ID deve ser informado.");
   if(string.IsNullOrEmpty(MAQ_ID))
   this._erroMensagem.Add("MAQ ID deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID))
   this._erroMensagem.Add("PRO ID deve ser informado.");
   if(string.IsNullOrEmpty(ORD_ID))
   this._erroMensagem.Add("ORD ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration