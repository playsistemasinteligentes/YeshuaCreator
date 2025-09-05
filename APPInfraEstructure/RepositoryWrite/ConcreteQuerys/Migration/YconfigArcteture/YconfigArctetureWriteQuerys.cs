using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class yConfigArctetureQueryWrite : QueryBase, IyConfigArctetureQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public yConfigArctetureQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture)
        {
            this.Query = $@" INSERT INTO yConfigArcteture (Id, AuditTrackerActived, AuditCRUDActived, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@Id, @AuditTrackerActived, @AuditCRUDActived, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = yConfigArcteture.Id,
                AuditTrackerActived = yConfigArcteture.AuditTrackerActived,
                AuditCRUDActived = yConfigArcteture.AuditCRUDActived,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture)
        {
            this.Query = $@" UPDATE yConfigArcteture SET AuditTrackerActived = @AuditTrackerActived, AuditCRUDActived = @AuditCRUDActived, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = yConfigArcteture.AuditTrackerActived,
                AuditCRUDActived = yConfigArcteture.AuditCRUDActived,
                TenantID = yConfigArcteture.TenantID,
                Deleted = yConfigArcteture.Deleted,
                Changed = yConfigArcteture.Changed,
                UserId = yConfigArcteture.UserId,
                Id = yConfigArcteture.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditTrackerActived(IyConfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE yConfigArcteture SET AuditTrackerActived = @AuditTrackerActived WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = entity.AuditTrackerActived,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditCRUDActived(IyConfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE yConfigArcteture SET AuditCRUDActived = @AuditCRUDActived WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditCRUDActived = entity.AuditCRUDActived,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyConfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE yConfigArcteture SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyConfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE yConfigArcteture SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyConfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE yConfigArcteture SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyConfigArctetureEntity entity)
        {
            this.Query = $@" UPDATE yConfigArcteture SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture)
        {
            this.Query = $@" DELETE FROM yConfigArcteture WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yConfigArcteture.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration