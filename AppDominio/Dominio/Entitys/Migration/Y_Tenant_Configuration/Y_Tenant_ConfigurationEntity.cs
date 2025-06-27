
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_Tenant_ConfigurationEntity
                    {
                public int? Id { get; set; }
    public int? AuditTrackerActived { get; set; }
    public int? AuditCRUDActived { get; set; }
    public int? TenantID { get; set; }
    private List<string> _erroMensagem = null;
 public Y_Tenant_ConfigurationEntity(int? id, int? audittrackeractived, int? auditcrudactived, int? tenantid ){
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

                public bool isValidInsert()
                {
                    return isValidData();
                }
                public bool isValidUpdate()
                {
                    return isValidData();
                }
                public bool isValidDelete()
                {
                    return true;
                }
                public List<string> getErroMensagens()
                {
                    return this._erroMensagem;
                }
            }
        }//Dominio.Schemas.CQRS.SourceCodeEntityMigration