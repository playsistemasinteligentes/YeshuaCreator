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
                    public partial class RegistrosOnduladeiraEntity : IRegistrosOnduladeiraEntity
{
    public int? Id { get; set; }
    public int REG_ID { get; set; }
    public string REG_RESPOSTA { get; set; }
    public string REG_STATUS { get; set; }
    public DateTime REG_DATA_INICIO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal RegistrosOnduladeiraEntity(int? id, int reg_id, string reg_resposta, string reg_status, DateTime reg_data_inicio ){
 Id = id; 
 REG_ID = reg_id; 
 REG_RESPOSTA = reg_resposta; 
 REG_STATUS = reg_status; 
 REG_DATA_INICIO = (reg_data_inicio < (new DateTime(1800, 1, 1))) ? DateTime.Now : reg_data_inicio; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (REG_ID == null)
   this._erroMensagem.Add("REG ID deve ser informado.");
   if(string.IsNullOrEmpty(REG_RESPOSTA))
   this._erroMensagem.Add("REG RESPOSTA deve ser informado.");
   if(string.IsNullOrEmpty(REG_STATUS))
   this._erroMensagem.Add("REG STATUS deve ser informado.");
   if (REG_DATA_INICIO == null || REG_DATA_INICIO < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("REG DATA INICIO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration