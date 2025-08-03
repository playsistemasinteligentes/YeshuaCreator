
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YuserPermissionActionsEntity : IYuserPermissionActionsEntity
{
    public int? PerfilId { get; set; }
    public string permissionActionsId { get; set; }
    public bool? Grant { get; set; }
    public bool? Create { get; set; }
    public bool? Read { get; set; }
    public bool? Update { get; set; }
    public bool? Delete { get; set; }
    public DateTime? ValidUntil { get; set; }
    private List<string> _erroMensagem = null;
 internal YuserPermissionActionsEntity(int? perfilid, string permissionactionsid, bool? grant, bool? create, bool? read, bool? update, bool? delete, DateTime? validuntil ){
 PerfilId = perfilid; 
 permissionActionsId = permissionactionsid; 
 Grant = grant; 
 Create = create; 
 Read = read; 
 Update = update; 
 Delete = delete; 
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