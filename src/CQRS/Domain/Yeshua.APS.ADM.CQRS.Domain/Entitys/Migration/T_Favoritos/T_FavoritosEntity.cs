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
                    public partial class T_FavoritosEntity : IT_FavoritosEntity
{
    public int IDFAVORITO { get; set; }
    public int USE_ID { get; set; }
    public int ID_INDICADOR { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_FavoritosEntity(int idfavorito, int use_id, int id_indicador ){
 IDFAVORITO = idfavorito; 
 USE_ID = use_id; 
 ID_INDICADOR = id_indicador; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (IDFAVORITO == null)
   this._erroMensagem.Add("IDFAVORITO deve ser informado.");
   if (USE_ID == null)
   this._erroMensagem.Add("USE ID deve ser informado.");
   if (ID_INDICADOR == null)
   this._erroMensagem.Add("ID INDICADOR deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration