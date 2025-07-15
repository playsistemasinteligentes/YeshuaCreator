
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Ytenant_ConfigurationEntity : IYtenant_ConfigurationEntity
{
    public int? Id { get; set; }
    public int? AuditTrackerActived { get; set; }
    public int? AuditCRUDActived { get; set; }
    public int? TenantID { get; set; }
    private List<string> _erroMensagem = null;
 internal Ytenant_ConfigurationEntity(int? id, int? audittrackeractived, int? auditcrudactived, int? tenantid ){
 Id = id; 
 AuditTrackerActived = audittrackeractived; 
 AuditCRUDActived = auditcrudactived; 
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