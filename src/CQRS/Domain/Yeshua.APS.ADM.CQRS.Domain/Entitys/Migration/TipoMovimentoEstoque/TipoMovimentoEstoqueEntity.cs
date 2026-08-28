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
                    public partial class TipoMovimentoEstoqueEntity : ITipoMovimentoEstoqueEntity
{
    public string TIP_ID { get; set; }
    public string TIP_DESCRICAO { get; set; }
    public int TIP_TYPE { get; set; }
    public int SPR { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TipoMovimentoEstoqueEntity(string tip_id, string tip_descricao, int tip_type, int spr ){
 TIP_ID = tip_id; 
 TIP_DESCRICAO = tip_descricao; 
 TIP_TYPE = tip_type; 
 SPR = spr; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(TIP_ID))
   this._erroMensagem.Add("TIP ID deve ser informado.");
   if(string.IsNullOrEmpty(TIP_DESCRICAO))
   this._erroMensagem.Add("TIP DESCRICAO deve ser informado.");
   if (TIP_TYPE == null)
   this._erroMensagem.Add("TIP TYPE deve ser informado.");
   if (SPR == null)
   this._erroMensagem.Add("SPR deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration