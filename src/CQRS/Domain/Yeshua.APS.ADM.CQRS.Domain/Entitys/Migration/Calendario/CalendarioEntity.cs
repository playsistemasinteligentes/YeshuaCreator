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
                    public partial class CalendarioEntity : ICalendarioEntity
{
    public int CAL_ID { get; set; }
    public string CAL_DESCRICAO { get; set; }
    public int? CAL_DIVIDE_DIA_EM { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CalendarioEntity(int cal_id, string cal_descricao, int? cal_divide_dia_em ){
 CAL_ID = cal_id; 
 CAL_DESCRICAO = cal_descricao; 
 CAL_DIVIDE_DIA_EM = cal_divide_dia_em; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (CAL_ID == null)
   this._erroMensagem.Add("CAL ID deve ser informado.");
   if(string.IsNullOrEmpty(CAL_DESCRICAO))
   this._erroMensagem.Add("CAL DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration