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
                    public partial class PlanocontasEntity : IPlanocontasEntity
{
    public int PLA_ID { get; set; }
    public string PLA_CODIGO { get; set; }
    public string PLA_DESCRICAO { get; set; }
    public int PLA_TIPO { get; set; }
    public string PLA_NATUREZA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal PlanocontasEntity(int pla_id, string pla_codigo, string pla_descricao, int pla_tipo, string pla_natureza ){
 PLA_ID = pla_id; 
 PLA_CODIGO = pla_codigo; 
 PLA_DESCRICAO = pla_descricao; 
 PLA_TIPO = pla_tipo; 
 PLA_NATUREZA = pla_natureza; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (PLA_ID == null)
   this._erroMensagem.Add("PLA ID deve ser informado.");
   if(string.IsNullOrEmpty(PLA_CODIGO))
   this._erroMensagem.Add("PLA CODIGO deve ser informado.");
   if(string.IsNullOrEmpty(PLA_DESCRICAO))
   this._erroMensagem.Add("PLA DESCRICAO deve ser informado.");
   if (PLA_TIPO == null)
   this._erroMensagem.Add("PLA TIPO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration