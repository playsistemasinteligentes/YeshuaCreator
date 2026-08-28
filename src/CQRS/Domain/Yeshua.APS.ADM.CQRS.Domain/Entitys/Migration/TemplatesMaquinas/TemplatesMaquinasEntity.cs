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
                    public partial class TemplatesMaquinasEntity : ITemplatesMaquinasEntity
{
    public int? Id { get; set; }
    public int TEM_ID { get; set; }
    public string MAQ_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TemplatesMaquinasEntity(int? id, int tem_id, string maq_id ){
 Id = id; 
 TEM_ID = tem_id; 
 MAQ_ID = maq_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (TEM_ID == null)
   this._erroMensagem.Add("TEM ID deve ser informado.");
   if(string.IsNullOrEmpty(MAQ_ID))
   this._erroMensagem.Add("MAQ ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration