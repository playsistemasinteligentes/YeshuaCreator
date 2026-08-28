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
                    public partial class CorConfiguracaoGraficoEntity : ICorConfiguracaoGraficoEntity
{
    public string COR_ID { get; set; }
    public Decimal COR_PERCENTUAL_INI { get; set; }
    public Decimal COR_PERCENTUAL_FIM { get; set; }
    public string COR_DESCRICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CorConfiguracaoGraficoEntity(string cor_id, Decimal cor_percentual_ini, Decimal cor_percentual_fim, string cor_descricao ){
 COR_ID = cor_id; 
 COR_PERCENTUAL_INI = cor_percentual_ini; 
 COR_PERCENTUAL_FIM = cor_percentual_fim; 
 COR_DESCRICAO = cor_descricao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(COR_ID))
   this._erroMensagem.Add("COR ID deve ser informado.");
   if (COR_PERCENTUAL_INI == null)
   this._erroMensagem.Add("COR PERCENTUAL INI deve ser informado.");
   if (COR_PERCENTUAL_FIM == null)
   this._erroMensagem.Add("COR PERCENTUAL FIM deve ser informado.");
   if(string.IsNullOrEmpty(COR_DESCRICAO))
   this._erroMensagem.Add("COR DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration