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
            this.Query = $@" INSERT INTO YconfigNotification (Id, TenantID, EmailSmtpClient, EmailPort, EmailUserName, EmailPassword, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@Id, @TenantID, @EmailSmtpClient, @EmailPort, @EmailUserName, @EmailPassword, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = YconfigNotification.Id,
                TenantID = YconfigNotification.TenantID,
                EmailSmtpClient = YconfigNotification.EmailSmtpClient,
                EmailPort = YconfigNotification.EmailPort,
                EmailUserName = YconfigNotification.EmailUserName,
                EmailPassword = YconfigNotification.EmailPassword,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYconfigNotificationQuery(IYconfigNotificationEntity YconfigNotification)
        {
            this.Query = $@" UPDATE YconfigNotification SET TenantID = @TenantID, EmailSmtpClient = @EmailSmtpClient, EmailPort = @EmailPort, EmailUserName = @EmailUserName, EmailPassword = @EmailPassword WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = YconfigNotification.TenantID,
                EmailSmtpClient = YconfigNotification.EmailSmtpClient,
                EmailPort = YconfigNotification.EmailPort,
                EmailUserName = YconfigNotification.EmailUserName,
                EmailPassword = YconfigNotification.EmailPassword,
                Id = YconfigNotification.Id,
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
        public QueryModel UpdateEmailSmtpClient(IYconfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE YconfigNotification SET EmailSmtpClient = @EmailSmtpClient WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailSmtpClient = entity.EmailSmtpClient,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailPort(IYconfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE YconfigNotification SET EmailPort = @EmailPort WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailPort = entity.EmailPort,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailUserName(IYconfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE YconfigNotification SET EmailUserName = @EmailUserName WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailUserName = entity.EmailUserName,
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