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
                    public partial class T_USER_GRUPOEntity : IT_USER_GRUPOEntity
{
    public int? Id { get; set; }
    public int GRU_ID { get; set; }
    public int ID_USUARIO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_USER_GRUPOEntity(int? id, int gru_id, int id_usuario ){
 Id = id; 
 GRU_ID = gru_id; 
 ID_USUARIO = id_usuario; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (GRU_ID == null)
   this._erroMensagem.Add("GRU ID deve ser informado.");
   if (ID_USUARIO == null)
   this._erroMensagem.Add("ID USUARIO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration