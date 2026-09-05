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
                    public partial class ProtocoloOnduladeiraEntity : IProtocoloOnduladeiraEntity
{
    public int? Id { get; set; }
    public string PTO_ID { get; set; }
    public string PTO_CHAVE { get; set; }
    public string MAQ_ID { get; set; }
    public string PTO_COMANDO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ProtocoloOnduladeiraEntity(int? id, string pto_id, string pto_chave, string maq_id, string pto_comando ){
 Id = id; 
 PTO_ID = pto_id; 
 PTO_CHAVE = pto_chave; 
 MAQ_ID = maq_id; 
 PTO_COMANDO = pto_comando; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(PTO_ID))
   this._erroMensagem.Add("PTO ID deve ser informado.");
   if(string.IsNullOrEmpty(PTO_CHAVE))
   this._erroMensagem.Add("PTO CHAVE deve ser informado.");
   if(string.IsNullOrEmpty(MAQ_ID))
   this._erroMensagem.Add("MAQ ID deve ser informado.");
   if(string.IsNullOrEmpty(PTO_COMANDO))
   this._erroMensagem.Add("PTO COMANDO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration