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
                    public partial class TenantCatalogoEntity : ITenantCatalogoEntity
{
    public int? Id { get; set; }
    public string Catalogo { get; set; }
    public int? TenantID { get; set; }
    public DateTime ValidUntil { get; set; }
    public string OperationalEntityId { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal TenantCatalogoEntity(int? id, string catalogo, DateTime validuntil ){
 Id = id; 
 Catalogo = catalogo; 
 ValidUntil = (validuntil < (new DateTime(1800, 1, 1))) ? DateTime.Now : validuntil; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Catalogo))
   this._erroMensagem.Add("Catalogo deve ser informado.");
   if(ValidUntil < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Valido ate deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration