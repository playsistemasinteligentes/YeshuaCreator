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
    public class YconfigArctetureQueryWrite : QueryBase, IYconfigArctetureQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YconfigArctetureQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYconfigArctetureQuery(IYconfigArctetureEntity YconfigArcteture)
        {
            this.Query = $@" INSERT INTO YconfigArcteture (Id, AuditTrackerActived, AuditCRUDActived, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@Id, @AuditTrackerActived, @AuditCRUDActived, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = YconfigArcteture.Id,
                AuditTrackerActived = YconfigArcteture.AuditTrackerActived,
                AuditCRUDActived = YconfigArcteture.AuditCRUDActived,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYconfigArctetureQuery(IYconfigArctetureEntity YconfigArcteture)
        {
            this.Query = $@" UPDATE YconfigArcteture SET AuditTrackerActived = @AuditTrackerActived, AuditCRUDActived = @AuditCRUDActived WHERE Id = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = YconfigArcteture.AuditTrackerActived,
                AuditCRUDActived = YconfigArcteture.AuditCRUDActived,
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
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration