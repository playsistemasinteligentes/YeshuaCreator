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
                    public partial class VariavelEntity : IVariavelEntity
{
    public int? Id { get; set; }
    public int VAR_ID { get; set; }
    public string VAR_DESCRICAO { get; set; }
    public int? CON_ID { get; set; }
    public int VAR_MODO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal VariavelEntity(int? id, int var_id, string var_descricao, int? con_id, int var_modo ){
 Id = id; 
 VAR_ID = var_id; 
 VAR_DESCRICAO = var_descricao; 
 CON_ID = con_id; 
 VAR_MODO = var_modo; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (VAR_ID == null)
   this._erroMensagem.Add("VAR ID deve ser informado.");
   if(string.IsNullOrEmpty(VAR_DESCRICAO))
   this._erroMensagem.Add("VAR DESCRICAO deve ser informado.");
   if (VAR_MODO == null)
   this._erroMensagem.Add("VAR MODO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration