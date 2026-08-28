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
                    public partial class TipoAvaliacaoEntity : ITipoAvaliacaoEntity
{
    public int TA_ID { get; set; }
    public string TA_DESC { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TipoAvaliacaoEntity(int ta_id, string ta_desc ){
 TA_ID = ta_id; 
 TA_DESC = ta_desc; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (TA_ID == null)
   this._erroMensagem.Add("TA ID deve ser informado.");
   if(string.IsNullOrEmpty(TA_DESC))
   this._erroMensagem.Add("TA DESC deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration