
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yConfigNotificationEntity : IyConfigNotificationEntity
{
    public int? Id { get; set; }
    public int? TenantID { get; set; }
    public string EmailSmtpClient { get; set; }
    public int? EmailPort { get; set; }
    public string EmailUserName { get; set; }
    public string EmailPassword { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal yConfigNotificationEntity(int? id, string emailsmtpclient, int? emailport, string emailusername, string emailpassword ){
 Id = id; 
 EmailSmtpClient = emailsmtpclient; 
 EmailPort = emailport; 
 EmailUserName = emailusername; 
 EmailPassword = emailpassword; 
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