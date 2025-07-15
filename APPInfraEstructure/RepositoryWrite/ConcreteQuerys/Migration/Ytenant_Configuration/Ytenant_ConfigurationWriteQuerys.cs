using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Ytenant_Configuration
{
    public class Ytenant_ConfigurationWriteQuery : QueryBase
    {
        public QueryModel InserirYtenant_ConfigurationQuery(IYtenant_ConfigurationEntity Ytenant_Configuration)
        {
            this.Query = $@" INSERT INTO Ytenant_Configuration (Id, AuditTrackerActived, AuditCRUDActived, TenantID) OUTPUT INSERTED.ID VALUES(@Id, @AuditTrackerActived, @AuditCRUDActived, @TenantID) ";
            this.Parameters = new
            {
                Id = Ytenant_Configuration.Id,
                AuditTrackerActived = Ytenant_Configuration.AuditTrackerActived,
                AuditCRUDActived = Ytenant_Configuration.AuditCRUDActived,
                TenantID = Ytenant_Configuration.TenantID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYtenant_ConfigurationQuery(IYtenant_ConfigurationEntity Ytenant_Configuration)
        {
            this.Query = $@" UPDATE Ytenant_Configuration SET AuditTrackerActived = @AuditTrackerActived, AuditCRUDActived = @AuditCRUDActived, TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = Ytenant_Configuration.AuditTrackerActived,
                AuditCRUDActived = Ytenant_Configuration.AuditCRUDActived,
                TenantID = Ytenant_Configuration.TenantID,
                Id = Ytenant_Configuration.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditTrackerActived(IYtenant_ConfigurationEntity entity)
        {
            this.Query = $@" UPDATE Ytenant_Configuration SET AuditTrackerActived = @AuditTrackerActived WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = entity.AuditTrackerActived,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditCRUDActived(IYtenant_ConfigurationEntity entity)
        {
            this.Query = $@" UPDATE Ytenant_Configuration SET AuditCRUDActived = @AuditCRUDActived WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditCRUDActived = entity.AuditCRUDActived,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IYtenant_ConfigurationEntity entity)
        {
            this.Query = $@" UPDATE Ytenant_Configuration SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYtenant_ConfigurationQuery(IYtenant_ConfigurationEntity Ytenant_Configuration)
        {
            this.Query = $@" DELETE FROM Ytenant_Configuration WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Ytenant_Configuration.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration