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
    public class yConfigNotificationQueryWrite : QueryBase, IyConfigNotificationQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public yConfigNotificationQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification)
        {
            this.Query = $@" INSERT INTO yConfigNotification (Id, TenantID, EmailSmtpClient, EmailPort, EmailUserName, EmailPassword, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@Id, @TenantID, @EmailSmtpClient, @EmailPort, @EmailUserName, @EmailPassword, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = yConfigNotification.Id,
                TenantID = _currentUser.TenantID,
                EmailSmtpClient = yConfigNotification.EmailSmtpClient,
                EmailPort = yConfigNotification.EmailPort,
                EmailUserName = yConfigNotification.EmailUserName,
                EmailPassword = yConfigNotification.EmailPassword,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailSmtpClient = @EmailSmtpClient, EmailPort = @EmailPort, EmailUserName = @EmailUserName, EmailPassword = @EmailPassword, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailSmtpClient = yConfigNotification.EmailSmtpClient,
                EmailPort = yConfigNotification.EmailPort,
                EmailUserName = yConfigNotification.EmailUserName,
                EmailPassword = yConfigNotification.EmailPassword,
                Changed = yConfigNotification.Changed,
                UserId = _currentUser.UserId,
                Id = yConfigNotification.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyConfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE yConfigNotification SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailSmtpClient(IyConfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailSmtpClient = @EmailSmtpClient WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailSmtpClient = entity.EmailSmtpClient,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailPort(IyConfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailPort = @EmailPort WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailPort = entity.EmailPort,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailUserName(IyConfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailUserName = @EmailUserName WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailUserName = entity.EmailUserName,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailPassword(IyConfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailPassword = @EmailPassword WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailPassword = entity.EmailPassword,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyConfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE yConfigNotification SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyConfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE yConfigNotification SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyConfigNotificationEntity entity)
        {
            this.Query = $@" UPDATE yConfigNotification SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification)
        {
            this.Query = $@" DELETE FROM yConfigNotification WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yConfigNotification.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration