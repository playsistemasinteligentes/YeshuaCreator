
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yUserModuleEntity : IyUserModuleEntity
{
    public int? Id { get; set; }
    public string ModuleId { get; set; }
    public int? UserId { get; set; }
    public DateTime? ValidUntil { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    private List<string> _erroMensagem = null;
 internal yUserModuleEntity(int? id, string moduleid, int? userid, DateTime? validuntil ){
 Id = id; 
 ModuleId = moduleid; 
 UserId = userid; 
 ValidUntil = (validuntil < (new DateTime(1800, 1, 1))) ? DateTime.Now : validuntil; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration