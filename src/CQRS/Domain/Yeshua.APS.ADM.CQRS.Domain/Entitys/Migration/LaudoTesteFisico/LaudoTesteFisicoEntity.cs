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
                    public partial class LaudoTesteFisicoEntity : ILaudoTesteFisicoEntity
{
    public int? Id { get; set; }
    public int LTF_ID { get; set; }
    public DateTime? LTF_EMISSAO { get; set; }
    public Decimal? LTF_VALOR { get; set; }
    public string LTF_OBS { get; set; }
    public string LTF_STATUS { get; set; }
    public string ORD_ID { get; set; }
    public string ROT_PRO_ID { get; set; }
    public int? FPR_SEQ_REPETICAO { get; set; }
    public int? USE_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal LaudoTesteFisicoEntity(int? id, int ltf_id, DateTime? ltf_emissao, Decimal? ltf_valor, string ltf_obs, string ltf_status, string ord_id, string rot_pro_id, int? fpr_seq_repeticao, int? use_id ){
 Id = id; 
 LTF_ID = ltf_id; 
 LTF_EMISSAO = (ltf_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : ltf_emissao; 
 LTF_VALOR = ltf_valor; 
 LTF_OBS = ltf_obs; 
 LTF_STATUS = ltf_status; 
 ORD_ID = ord_id; 
 ROT_PRO_ID = rot_pro_id; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
 USE_ID = use_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (LTF_ID == null)
   this._erroMensagem.Add("LTF ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration