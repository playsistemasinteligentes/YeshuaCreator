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
                    public partial class ParamEntity : IParamEntity
{
    public string PAR_ID { get; set; }
    public string PAR_DESCRICAO { get; set; }
    public string PAR_VALOR_S { get; set; }
    public Decimal PAR_VALOR_N { get; set; }
    public DateTime PAR_VALOR_D { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ParamEntity(string par_id, string par_descricao, string par_valor_s, Decimal par_valor_n, DateTime par_valor_d ){
 PAR_ID = par_id; 
 PAR_DESCRICAO = par_descricao; 
 PAR_VALOR_S = par_valor_s; 
 PAR_VALOR_N = par_valor_n; 
 PAR_VALOR_D = (par_valor_d < (new DateTime(1800, 1, 1))) ? DateTime.Now : par_valor_d; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(PAR_ID))
   this._erroMensagem.Add("PAR ID deve ser informado.");
   if(string.IsNullOrEmpty(PAR_DESCRICAO))
   this._erroMensagem.Add("PAR DESCRICAO deve ser informado.");
   if(string.IsNullOrEmpty(PAR_VALOR_S))
   this._erroMensagem.Add("PAR VALOR S deve ser informado.");
   if(PAR_VALOR_D == null || PAR_VALOR_D < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("PAR VALOR D deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration