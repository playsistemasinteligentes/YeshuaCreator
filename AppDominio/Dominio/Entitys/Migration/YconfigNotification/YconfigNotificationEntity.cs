
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YconfigNotificationEntity : IYconfigNotificationEntity
{
    public int? Id { get; set; }
    public string EmailAdress { get; set; }
    public string EmailPassword { get; set; }
    public int? TenantID { get; set; }
    private List<string> _erroMensagem = null;
 internal YconfigNotificationEntity(int? id, string emailadress, string emailpassword, int? tenantid ){
 Id = id; 
 EmailAdress = emailadress; 
 EmailPassword = emailpassword; 
 TenantID = tenantid; 
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