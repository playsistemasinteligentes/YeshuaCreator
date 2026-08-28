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
                    public partial class IndicadoresDepartamentosEntity : IIndicadoresDepartamentosEntity
{
    public int INDDEP_ID { get; set; }
    public int DEP_ID { get; set; }
    public int IND_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal IndicadoresDepartamentosEntity(int inddep_id, int dep_id, int ind_id ){
 INDDEP_ID = inddep_id; 
 DEP_ID = dep_id; 
 IND_ID = ind_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (INDDEP_ID == null)
   this._erroMensagem.Add("INDDEP ID deve ser informado.");
   if (DEP_ID == null)
   this._erroMensagem.Add("DEP ID deve ser informado.");
   if (IND_ID == null)
   this._erroMensagem.Add("IND ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration