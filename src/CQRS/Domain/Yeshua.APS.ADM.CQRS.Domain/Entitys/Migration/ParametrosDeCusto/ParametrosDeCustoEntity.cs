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
                    public partial class ParametrosDeCustoEntity : IParametrosDeCustoEntity
{
    public int? Id { get; set; }
    public int PAR_ID { get; set; }
    public string PRO_ID { get; set; }
    public string CUS_ID { get; set; }
    public string PAR_VALOR { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ParametrosDeCustoEntity(int? id, int par_id, string pro_id, string cus_id, string par_valor ){
 Id = id; 
 PAR_ID = par_id; 
 PRO_ID = pro_id; 
 CUS_ID = cus_id; 
 PAR_VALOR = par_valor; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (PAR_ID == null)
   this._erroMensagem.Add("PAR ID deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID))
   this._erroMensagem.Add("PRO ID deve ser informado.");
   if(string.IsNullOrEmpty(CUS_ID))
   this._erroMensagem.Add("CUS ID deve ser informado.");
   if(string.IsNullOrEmpty(PAR_VALOR))
   this._erroMensagem.Add("PAR VALOR deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration