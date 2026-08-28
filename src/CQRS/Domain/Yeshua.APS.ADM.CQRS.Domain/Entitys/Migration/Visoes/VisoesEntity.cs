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
                    public partial class VisoesEntity : IVisoesEntity
{
    public int VIS_ID { get; set; }
    public int VIS_PLANID { get; set; }
    public string VIS_FORMULA { get; set; }
    public int CAB_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal VisoesEntity(int vis_id, int vis_planid, string vis_formula, int cab_id ){
 VIS_ID = vis_id; 
 VIS_PLANID = vis_planid; 
 VIS_FORMULA = vis_formula; 
 CAB_ID = cab_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (VIS_ID == null)
   this._erroMensagem.Add("VIS ID deve ser informado.");
   if (VIS_PLANID == null)
   this._erroMensagem.Add("VIS PLANID deve ser informado.");
   if (CAB_ID == null)
   this._erroMensagem.Add("CAB ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration