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
                    public partial class T_NegocioEntity : IT_NegocioEntity
{
    public int NEG_ID { get; set; }
    public string NEG_DESCRICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_NegocioEntity(int neg_id, string neg_descricao ){
 NEG_ID = neg_id; 
 NEG_DESCRICAO = neg_descricao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (NEG_ID == null)
   this._erroMensagem.Add("NEG ID deve ser informado.");
   if(string.IsNullOrEmpty(NEG_DESCRICAO))
   this._erroMensagem.Add("NEG DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration