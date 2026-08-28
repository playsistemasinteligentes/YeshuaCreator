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
                    public partial class UsuarioPerfilEntity : IUsuarioPerfilEntity
{
    public int? Id { get; set; }
    public int USE_ID { get; set; }
    public int PER_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal UsuarioPerfilEntity(int? id, int use_id, int per_id ){
 Id = id; 
 USE_ID = use_id; 
 PER_ID = per_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (USE_ID == null)
   this._erroMensagem.Add("USE ID deve ser informado.");
   if (PER_ID == null)
   this._erroMensagem.Add("PER ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration