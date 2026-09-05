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
                    public partial class yTokenEntity : IyTokenEntity
{
    public int? Id { get; set; }
    public string TokenHash { get; set; }
    public string Description { get; set; }
    public string ConnectorKey { get; set; }
    public bool Active { get; set; }
    public DateTime? ValidUntil { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUsedAt { get; set; }
    public int? TenantID { get; set; }
    public int? UserId { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    private List<string> _erroMensagem = null;
 internal yTokenEntity(int? id, string tokenhash, string description, string connectorkey, DateTime? validuntil, DateTime? lastusedat ){
 Id = id; 
 TokenHash = tokenhash; 
 Description = description; 
 ConnectorKey = connectorkey; 
 ValidUntil = (validuntil < (new DateTime(1800, 1, 1))) ? DateTime.Now : validuntil; 
 LastUsedAt = (lastusedat < (new DateTime(1800, 1, 1))) ? DateTime.Now : lastusedat; 
 Active = true; 
 CreatedAt = DateTime.Now; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(TokenHash))
   this._erroMensagem.Add("Hash do Token deve ser informado.");
   if(string.IsNullOrEmpty(ConnectorKey))
   this._erroMensagem.Add("Conector deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration