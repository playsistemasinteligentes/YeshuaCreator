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
                    public partial class T_DepartamentosEntity : IT_DepartamentosEntity
{
    public int DEP_ID { get; set; }
    public string DEP_NOME { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_DepartamentosEntity(int dep_id, string dep_nome ){
 DEP_ID = dep_id; 
 DEP_NOME = dep_nome; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (DEP_ID == null)
   this._erroMensagem.Add("DEP ID deve ser informado.");
   if(string.IsNullOrEmpty(DEP_NOME))
   this._erroMensagem.Add("DEP NOME deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration