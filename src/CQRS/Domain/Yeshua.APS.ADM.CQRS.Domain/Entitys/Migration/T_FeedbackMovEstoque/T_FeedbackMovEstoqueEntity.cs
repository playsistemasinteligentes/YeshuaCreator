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
                    public partial class T_FeedbackMovEstoqueEntity : IT_FeedbackMovEstoqueEntity
{
    public int? Id { get; set; }
    public int FeedbackId { get; set; }
    public int MovimentoEstoqueId { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_FeedbackMovEstoqueEntity(int? id, int feedbackid, int movimentoestoqueid ){
 Id = id; 
 FeedbackId = feedbackid; 
 MovimentoEstoqueId = movimentoestoqueid; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (FeedbackId == null)
   this._erroMensagem.Add("FeedbackId deve ser informado.");
   if (MovimentoEstoqueId == null)
   this._erroMensagem.Add("MovimentoEstoqueId deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration