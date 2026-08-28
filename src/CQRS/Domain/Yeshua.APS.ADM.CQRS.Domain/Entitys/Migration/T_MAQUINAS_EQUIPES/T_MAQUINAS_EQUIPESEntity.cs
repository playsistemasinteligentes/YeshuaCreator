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
                    public partial class T_MAQUINAS_EQUIPESEntity : IT_MAQUINAS_EQUIPESEntity
{
    public int? Id { get; set; }
    public string MAQ_ID { get; set; }
    public string EQU_ID { get; set; }
    public int? CAL_ID { get; set; }
    public string CLI_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_MAQUINAS_EQUIPESEntity(int? id, string maq_id, string equ_id, int? cal_id, string cli_id ){
 Id = id; 
 MAQ_ID = maq_id; 
 EQU_ID = equ_id; 
 CAL_ID = cal_id; 
 CLI_ID = cli_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(MAQ_ID))
   this._erroMensagem.Add("MAQ ID deve ser informado.");
   if(string.IsNullOrEmpty(EQU_ID))
   this._erroMensagem.Add("EQU ID deve ser informado.");
   if(string.IsNullOrEmpty(CLI_ID))
   this._erroMensagem.Add("CLI ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration