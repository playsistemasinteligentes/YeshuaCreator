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
                    public partial class InformacoesComplementaresEntity : IInformacoesComplementaresEntity
{
    public int INF_ID { get; set; }
    public string INF_DESCRICAO { get; set; }
    public Decimal INF_VALOR { get; set; }
    public int MET_ID { get; set; }
    public string INF_DATA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal InformacoesComplementaresEntity(int inf_id, string inf_descricao, Decimal inf_valor, int met_id, string inf_data ){
 INF_ID = inf_id; 
 INF_DESCRICAO = inf_descricao; 
 INF_VALOR = inf_valor; 
 MET_ID = met_id; 
 INF_DATA = inf_data; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(INF_DESCRICAO))
   this._erroMensagem.Add("INF DESCRICAO deve ser informado.");
   if(string.IsNullOrEmpty(INF_DATA))
   this._erroMensagem.Add("INF DATA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration