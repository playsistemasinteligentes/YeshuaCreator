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
                    public partial class OcorrenciaEntity : IOcorrenciaEntity
{
    public string OCO_ID { get; set; }
    public string OCO_DESCRICAO { get; set; }
    public int TIP_ID { get; set; }
    public string GMA_ID { get; set; }
    public string MAQ_ID { get; set; }
    public int? SPR { get; set; }
    public string OCO_SUB_TIPO { get; set; }
    public string SUB_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal OcorrenciaEntity(string oco_id, string oco_descricao, int tip_id, string gma_id, string maq_id, int? spr, string oco_sub_tipo, string sub_id ){
 OCO_ID = oco_id; 
 OCO_DESCRICAO = oco_descricao; 
 TIP_ID = tip_id; 
 GMA_ID = gma_id; 
 MAQ_ID = maq_id; 
 SPR = spr; 
 OCO_SUB_TIPO = oco_sub_tipo; 
 SUB_ID = sub_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(OCO_ID))
   this._erroMensagem.Add("OCO ID deve ser informado.");
   if(string.IsNullOrEmpty(OCO_DESCRICAO))
   this._erroMensagem.Add("OCO DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration