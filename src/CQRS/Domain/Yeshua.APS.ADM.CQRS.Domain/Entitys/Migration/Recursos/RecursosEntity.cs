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
                    public partial class RecursosEntity : IRecursosEntity
{
    public string REC_ID { get; set; }
    public string REC_DESCRICAO { get; set; }
    public int? CAL_ID { get; set; }
    public string REC_CONTROL_IP { get; set; }
    public string GRE_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal RecursosEntity(string rec_id, string rec_descricao, int? cal_id, string rec_control_ip, string gre_id ){
 REC_ID = rec_id; 
 REC_DESCRICAO = rec_descricao; 
 CAL_ID = cal_id; 
 REC_CONTROL_IP = rec_control_ip; 
 GRE_ID = gre_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(REC_ID))
   this._erroMensagem.Add("REC ID deve ser informado.");
   if(string.IsNullOrEmpty(REC_DESCRICAO))
   this._erroMensagem.Add("REC DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration