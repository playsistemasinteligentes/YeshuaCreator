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
                    public partial class PlanoacaoEntity : IPlanoacaoEntity
{
    public int PLA_ID { get; set; }
    public string PLA_DESCRICAO { get; set; }
    public int? MET_ID { get; set; }
    public string PLA_STATUS { get; set; }
    public DateTime? PLA_DATA { get; set; }
    public string PLA_METAPERIODO { get; set; }
    public string PLA_VLRPERIODO { get; set; }
    public string PLA_METACULADO { get; set; }
    public string PLA_VLRACUMULADO { get; set; }
    public string PLA_REFERENCIA { get; set; }
    public int USE_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal PlanoacaoEntity(int pla_id, string pla_descricao, int? met_id, string pla_status, DateTime? pla_data, string pla_metaperiodo, string pla_vlrperiodo, string pla_metaculado, string pla_vlracumulado, string pla_referencia, int use_id ){
 PLA_ID = pla_id; 
 PLA_DESCRICAO = pla_descricao; 
 MET_ID = met_id; 
 PLA_STATUS = pla_status; 
 PLA_DATA = (pla_data < (new DateTime(1800, 1, 1))) ? DateTime.Now : pla_data; 
 PLA_METAPERIODO = pla_metaperiodo; 
 PLA_VLRPERIODO = pla_vlrperiodo; 
 PLA_METACULADO = pla_metaculado; 
 PLA_VLRACUMULADO = pla_vlracumulado; 
 PLA_REFERENCIA = pla_referencia; 
 USE_ID = use_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(PLA_DESCRICAO))
   this._erroMensagem.Add("PLA DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration