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
                    public partial class CondicaoPagamentoEntity : ICondicaoPagamentoEntity
{
    public int? Id { get; set; }
    public string CON_ID { get; set; }
    public string CON_DESCRICAO { get; set; }
    public int? CON_PARCELAS { get; set; }
    public Decimal? CON_VALOR_ACRECIMO { get; set; }
    public string CON_INTEGRACAO_ERP { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CondicaoPagamentoEntity(int? id, string con_id, string con_descricao, int? con_parcelas, Decimal? con_valor_acrecimo, string con_integracao_erp ){
 Id = id; 
 CON_ID = con_id; 
 CON_DESCRICAO = con_descricao; 
 CON_PARCELAS = con_parcelas; 
 CON_VALOR_ACRECIMO = con_valor_acrecimo; 
 CON_INTEGRACAO_ERP = con_integracao_erp; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CON_ID))
   this._erroMensagem.Add("CON ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration