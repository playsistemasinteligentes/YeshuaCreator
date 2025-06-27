using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Y_Tenant_Configuration
{
    public class Y_Tenant_ConfigurationWriteQuery : QueryBase
    {
        public QueryModel InserirY_Tenant_ConfigurationQuery(Y_Tenant_ConfigurationEntity Y_Tenant_Configuration)
        {
            this.Query = $@" INSERT INTO Y_Tenant_Configuration (Id, AuditTrackerActived, AuditCRUDActived, TenantID) OUTPUT INSERTED.ID VALUES(@Id, @AuditTrackerActived, @AuditCRUDActived, @TenantID) ";
            this.Parameters = new
            {
                Id = Y_Tenant_Configuration.Id,
                AuditTrackerActived = Y_Tenant_Configuration.AuditTrackerActived,
                AuditCRUDActived = Y_Tenant_Configuration.AuditCRUDActived,
                TenantID = Y_Tenant_Configuration.TenantID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_Tenant_ConfigurationQuery(Y_Tenant_ConfigurationEntity Y_Tenant_Configuration)
        {
            this.Query = $@" UPDATE Y_Tenant_Configuration SET AuditTrackerActived = @AuditTrackerActived, AuditCRUDActived = @AuditCRUDActived, TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = Y_Tenant_Configuration.AuditTrackerActived,
                AuditCRUDActived = Y_Tenant_Configuration.AuditCRUDActived,
                TenantID = Y_Tenant_Configuration.TenantID,
                Id = Y_Tenant_Configuration.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_Tenant_ConfigurationQuery(Y_Tenant_ConfigurationEntity Y_Tenant_Configuration)
        {
            this.Query = $@" DELETE FROM Y_Tenant_Configuration WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Y_Tenant_Configuration.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration