
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yUserGrantEntity : IyUserGrantEntity
{
    public int? Id { get; set; }
    public int? PerfilId { get; set; }
    public string GrantId { get; set; }
    public bool? Grant { get; set; }
    public bool? Create { get; set; }
    public bool? Read { get; set; }
    public bool? Update { get; set; }
    public bool? Delete { get; set; }
    public DateTime? ValidUntil { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal yUserGrantEntity(int? id, int? perfilid, string grantid, bool? grant, bool? create, bool? read, bool? update, bool? delete, DateTime? validuntil ){
 Id = id; 
 PerfilId = perfilid; 
 GrantId = grantid; 
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