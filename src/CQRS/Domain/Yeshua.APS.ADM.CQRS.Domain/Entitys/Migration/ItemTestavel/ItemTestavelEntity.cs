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
                    public partial class ItemTestavelEntity : IItemTestavelEntity
{
    public int? Id { get; set; }
    public int ITE_ID { get; set; }
    public string ITE_DESCRICAO { get; set; }
    public string ITE_OBS { get; set; }
    public int? ITE_NUMERO_DE_TESTES { get; set; }
    public string ITE_CONDICIONAL_DE_AVALIACAO { get; set; }
    public Decimal? ITE_VALOR_DA_CONDICIONAL { get; set; }
    public string ITE_VALOR_CALCULADO_DA_CONDICIONAL { get; set; }
    public string ITE_TIPO_AVALIACAO_FINAL { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ItemTestavelEntity(int? id, int ite_id, string ite_descricao, string ite_obs, int? ite_numero_de_testes, string ite_condicional_de_avaliacao, Decimal? ite_valor_da_condicional, string ite_valor_calculado_da_condicional, string ite_tipo_avaliacao_final ){
 Id = id; 
 ITE_ID = ite_id; 
 ITE_DESCRICAO = ite_descricao; 
 ITE_OBS = ite_obs; 
 ITE_NUMERO_DE_TESTES = ite_numero_de_testes; 
 ITE_CONDICIONAL_DE_AVALIACAO = ite_condicional_de_avaliacao; 
 ITE_VALOR_DA_CONDICIONAL = ite_valor_da_condicional; 
 ITE_VALOR_CALCULADO_DA_CONDICIONAL = ite_valor_calculado_da_condicional; 
 ITE_TIPO_AVALIACAO_FINAL = ite_tipo_avaliacao_final; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration