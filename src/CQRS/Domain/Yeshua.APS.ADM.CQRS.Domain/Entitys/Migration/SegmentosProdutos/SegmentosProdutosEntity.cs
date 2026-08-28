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
                    public partial class SegmentosProdutosEntity : ISegmentosProdutosEntity
{
    public int? Id { get; set; }
    public string GRS_ID { get; set; }
    public string PRO_ID { get; set; }
    public string SEG_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal SegmentosProdutosEntity(int? id, string grs_id, string pro_id, string seg_id ){
 Id = id; 
 GRS_ID = grs_id; 
 PRO_ID = pro_id; 
 SEG_ID = seg_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(GRS_ID))
   this._erroMensagem.Add("GRS ID deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID))
   this._erroMensagem.Add("PRO ID deve ser informado.");
   if(string.IsNullOrEmpty(SEG_ID))
   this._erroMensagem.Add("SEG ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration