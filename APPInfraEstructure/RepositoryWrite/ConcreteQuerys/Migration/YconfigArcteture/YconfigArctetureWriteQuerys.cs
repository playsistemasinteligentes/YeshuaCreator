using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.YconfigArcteture
{
    public class YconfigArctetureWriteQuery : QueryBase
    {
        public QueryModel InserirYconfigArctetureQuery(IYconfigArctetureEntity YconfigArcteture)
        {
            this.Query = $@" INSERT INTO YconfigArcteture (Id, AuditTrackerActived, AuditCRUDActived, TenantID) OUTPUT INSERTED.ID VALUES(@Id, @AuditTrackerActived, @AuditCRUDActived, @TenantID) ";
            this.Parameters = new
            {
                Id = YconfigArcteture.Id,
                AuditTrackerActived = YconfigArcteture.AuditTrackerActived,
                AuditCRUDActived = YconfigArcteture.AuditCRUDActived,
                TenantID = YconfigArcteture.TenantID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYconfigArctetureQuery(IYconfigArctetureEntity YconfigArcteture)
        {
            this.Query = $@" UPDATE YconfigArcteture SET AuditTrackerActived = @AuditTrackerActived, AuditCRUDActived = @AuditCRUDActived, TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = YconfigArcteture.AuditTrackerActived,
                AuditCRUDActived = YconfigArcteture.AuditCRUDActived,
                TenantID = YconfigArcteture.TenantID,
                Id = YconfigArcteture.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditTrackerActived(IYconfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE YconfigArcteture SET AuditTrackerActived = @AuditTrackerActived WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = entity.AuditTrackerActived,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditCRUDActived(IYconfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE YconfigArcteture SET AuditCRUDActived = @AuditCRUDActived WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditCRUDActived = entity.AuditCRUDActived,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IYconfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE YconfigArcteture SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYconfigArctetureQuery(IYconfigArctetureEntity YconfigArcteture)
        {
            this.Query = $@" DELETE FROM YconfigArcteture WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = YconfigArcteture.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration