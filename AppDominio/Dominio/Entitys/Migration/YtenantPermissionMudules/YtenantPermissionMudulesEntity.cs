
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YtenantPermissionMudulesEntity : IYtenantPermissionMudulesEntity
{
    public int? Id { get; set; }
    public string permissionModulesId { get; set; }
    public int? TenantID { get; set; }
    public DateTime? ValidUntil { get; set; }
    private List<string> _erroMensagem = null;
 internal YtenantPermissionMudulesEntity(int? id, string permissionmodulesid, int? tenantid, DateTime? validuntil ){
 Id = id; 
 permissionModulesId = permissionmodulesid; 
 TenantID = tenantid; 
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