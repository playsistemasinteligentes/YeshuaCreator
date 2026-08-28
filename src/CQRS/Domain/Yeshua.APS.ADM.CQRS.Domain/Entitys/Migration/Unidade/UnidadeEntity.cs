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
                    public partial class UnidadeEntity : IUnidadeEntity
{
    public int UNI_ID { get; set; }
    public string DEESCRICAO { get; set; }
    public string UN { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal UnidadeEntity(int uni_id, string deescricao, string un ){
 UNI_ID = uni_id; 
 DEESCRICAO = deescricao; 
 UN = un; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (UNI_ID == null)
   this._erroMensagem.Add("UNI ID deve ser informado.");
   if(string.IsNullOrEmpty(DEESCRICAO))
   this._erroMensagem.Add("DEESCRICAO deve ser informado.");
   if(string.IsNullOrEmpty(UN))
   this._erroMensagem.Add("UN deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration