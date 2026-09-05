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
                    public partial class ObjetoControlavelEntity : IObjetoControlavelEntity
{
    public int? Id { get; set; }
    public string OBJ_ID { get; set; }
    public string OBJ_DESCRICAO { get; set; }
    public string OBJ_TIPO { get; set; }
    public string OBJ_GRUPO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ObjetoControlavelEntity(int? id, string obj_id, string obj_descricao, string obj_tipo, string obj_grupo ){
 Id = id; 
 OBJ_ID = obj_id; 
 OBJ_DESCRICAO = obj_descricao; 
 OBJ_TIPO = obj_tipo; 
 OBJ_GRUPO = obj_grupo; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(OBJ_ID))
   this._erroMensagem.Add("OBJ ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration