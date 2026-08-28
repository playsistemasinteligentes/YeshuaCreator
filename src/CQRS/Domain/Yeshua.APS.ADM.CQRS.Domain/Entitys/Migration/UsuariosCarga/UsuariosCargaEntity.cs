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
                    public partial class UsuariosCargaEntity : IUsuariosCargaEntity
{
    public int? Id { get; set; }
    public int USE_ID { get; set; }
    public string CAR_ID { get; set; }
    public string RGO_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal UsuariosCargaEntity(int? id, int use_id, string car_id, string rgo_id ){
 Id = id; 
 USE_ID = use_id; 
 CAR_ID = car_id; 
 RGO_ID = rgo_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (USE_ID == null)
   this._erroMensagem.Add("USE ID deve ser informado.");
   if(string.IsNullOrEmpty(CAR_ID))
   this._erroMensagem.Add("CAR ID deve ser informado.");
   if(string.IsNullOrEmpty(RGO_ID))
   this._erroMensagem.Add("RGO ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration