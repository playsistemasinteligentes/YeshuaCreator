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
        protected readonly IExecutionContext _executionContext;
        public yConfigNotificationQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryConfigNotificationQuery(IyConfigNotificationEntity yConfigNotification)
        {
            this.Query = $@" INSERT INTO yConfigNotification (Id, TenantID, EmailSmtpClient, EmailPort, EmailUserName, EmailPassword, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@Id, @TenantID, @EmailSmtpClient, @EmailPort, @EmailUserName, @EmailPassword, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = yConfigNotification.Id,
                TenantID = _executionContext.TenantID,
                EmailSmtpClient = yConfigNotification.EmailSmtpClient,
                EmailPort = yConfigNotification.EmailPort,
                EmailUserName = yConfigNotification.EmailUserName,
                EmailPassword = yConfigNotification.EmailPassword,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
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
                UserId = _executionContext.UserId,
                Id = yConfigNotification.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yConfigNotification SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailSmtpClient(int id, string value)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailSmtpClient = @EmailSmtpClient WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailSmtpClient = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailPort(int id, int value)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailPort = @EmailPort WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailPort = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailUserName(int id, string value)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailUserName = @EmailUserName WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailUserName = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmailPassword(int id, string value)
        {
            this.Query = $@" UPDATE yConfigNotification SET EmailPassword = @EmailPassword WHERE Id = @Id ";
            this.Parameters = new
            {
                EmailPassword = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yConfigNotification SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yConfigNotification SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yConfigNotification SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
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