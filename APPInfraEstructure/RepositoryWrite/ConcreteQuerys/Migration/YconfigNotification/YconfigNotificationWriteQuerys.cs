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
    public class YconfigNotificationQueryWrite : QueryBase, IYconfigNotificationQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YconfigNotificationQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYconfigNotificationQuery(IYconfigNotificationEntity YconfigNotification)
        {
            this.Query = $@" INSERT INTO YconfigNotification (Id, EmailAdress, EmailPassword, TenantID) OUTPUT INSERTED.ID VALUES(@Id, @EmailAdress, @EmailPassword, @TenantID) ";
            this.Parameters = new
            {
                Id = YconfigNotification.Id,
                EmailAdress = YconfigNotification.EmailAdress,
                EmailPassword = YconfigNotification.EmailPassword,
                TenantID = _correntUser.TenentID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYconfigNotificationQuery(IYconfigNotificationEntity YconfigNotification)
        {
            this.Query = $@" UPDATE YconfigNotification SET EmailAdress = @EmailAdress, EmailPassword = @EmailPassword, TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailAdress = YconfigNotification.EmailAdress,
                EmailPassword = YconfigNotification.EmailPassword,
                TenantID = YconfigNotification.TenantID,
                Id = YconfigNotification.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailAdress(IYconfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE YconfigNotification SET EmailAdress = @EmailAdress WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailAdress = entity.EmailAdress,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailPassword(IYconfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE YconfigNotification SET EmailPassword = @EmailPassword WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailPassword = entity.EmailPassword,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IYconfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE YconfigNotification SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYconfigNotificationQuery(IYconfigNotificationEntity YconfigNotification)
        {
            this.Query = $@" DELETE FROM YconfigNotification WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = YconfigNotification.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration