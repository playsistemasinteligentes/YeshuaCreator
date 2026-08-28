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
                    public partial class FechamentoTesteEntity : IFechamentoTesteEntity
{
    public int? Id { get; set; }
    public int FEC_ID { get; set; }
    public int? FEC_QTD { get; set; }
    public string GRP_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal FechamentoTesteEntity(int? id, int fec_id, int? fec_qtd, string grp_id ){
 Id = id; 
 FEC_ID = fec_id; 
 FEC_QTD = fec_qtd; 
 GRP_ID = grp_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (FEC_ID == null)
   this._erroMensagem.Add("FEC ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration