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
                    public partial class AuditoriaEntity : IAuditoriaEntity
{
    public int ID { get; set; }
    public DateTime DATA { get; set; }
    public int USE_ID { get; set; }
    public string ROTINA { get; set; }
    public string HISTORICO { get; set; }
    public string CHAVE { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal AuditoriaEntity(int id, DateTime data, int use_id, string rotina, string historico, string chave ){
 ID = id; 
 DATA = (data < (new DateTime(1800, 1, 1))) ? DateTime.Now : data; 
 USE_ID = use_id; 
 ROTINA = rotina; 
 HISTORICO = historico; 
 CHAVE = chave; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (ID == null)
   this._erroMensagem.Add("ID deve ser informado.");
   if (DATA == null || DATA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("DATA deve ser informado.");
   if (USE_ID == null)
   this._erroMensagem.Add("USE ID deve ser informado.");
   if(string.IsNullOrEmpty(ROTINA))
   this._erroMensagem.Add("ROTINA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration