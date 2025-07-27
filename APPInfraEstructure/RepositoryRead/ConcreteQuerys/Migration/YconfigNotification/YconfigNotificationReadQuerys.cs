using Shered.DB;
using Command.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Query.Read 
{
    public class YconfigNotificationQueryRead : QueryBase, IYconfigNotificationQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public YconfigNotificationQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel YconfigNotificationQuery(Command.Read.YconfigNotificationReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, TenantID, EmailSmtpClient, EmailPort, EmailUserName, EmailPassword, Deleted, Changed, UserId from YconfigNotification ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.TenantID.HasValue) parametersDict["TenantID"] = Command.TenantID.Value;
if (Command.TenantID.HasValue) whereClauses.Add($"TenantID = @TenantID");
if (!string.IsNullOrEmpty(Command.EmailSmtpClient)) parametersDict["EmailSmtpClient"] = $"%{Command.EmailSmtpClient}%";
if (!string.IsNullOrEmpty(Command.EmailSmtpClient)) whereClauses.Add($"EmailSmtpClient like @EmailSmtpClient");
if (Command.EmailPort.HasValue) parametersDict["EmailPort"] = Command.EmailPort.Value;
if (Command.EmailPort.HasValue) whereClauses.Add($"EmailPort = @EmailPort");
if (!string.IsNullOrEmpty(Command.EmailUserName)) parametersDict["EmailUserName"] = $"%{Command.EmailUserName}%";
if (!string.IsNullOrEmpty(Command.EmailUserName)) whereClauses.Add($"EmailUserName like @EmailUserName");
if (!string.IsNullOrEmpty(Command.EmailPassword)) parametersDict["EmailPassword"] = $"%{Command.EmailPassword}%";
if (!string.IsNullOrEmpty(Command.EmailPassword)) whereClauses.Add($"EmailPassword like @EmailPassword");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {getBackEndFieldWitchWhere(" AND ")} {string.Join(" AND ", whereClauses)}"; 
            else if (!string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
                 this.Query += $" WHERE {getBackEndFieldWitchWhere()}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            parametersDict["Offset"] = offset;
            parametersDict["PageSize"] = pageSize;
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel YconfigNotificationTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Ytenant ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      this.Parameters = new { Id = numero}; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      this.Parameters = new { 
                       Id = $"%{Command.searchFK}%", 
                       Nome = $"%{Command.searchFK}%", 
                      }; 
                      whereClauses.Add($" Id like @Id "); 
                      whereClauses.Add($" Nome like @Nome "); 
                 }
            }
            if (whereClauses.Any() && !string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {getBackEndFieldWitchWhere()} AND ({string.Join(" OR ", whereClauses)})"; 
            else if (whereClauses.Any() && string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {string.Join(" OR ", whereClauses)}"; 
            else if (!whereClauses.Any() && !string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {getBackEndFieldWitchWhere()}"; 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")} TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailSmtpClientQuery(string value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")} EmailSmtpClient = @EmailSmtpClient";
            var parameters = new { EmailSmtpClient = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailPortQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")} EmailPort = @EmailPort";
            var parameters = new { EmailPort = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailUserNameQuery(string value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")} EmailUserName = @EmailUserName";
            var parameters = new { EmailUserName = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailPasswordQuery(string value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")} EmailPassword = @EmailPassword";
            var parameters = new { EmailPassword = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")} Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")}  Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")}  TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailSmtpClientQuery(string value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")}  EmailSmtpClient = @EmailSmtpClient";
            var parameters = new { EmailSmtpClient = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailPortQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")}  EmailPort = @EmailPort";
            var parameters = new { EmailPort = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailUserNameQuery(string value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")}  EmailUserName = @EmailUserName";
            var parameters = new { EmailUserName = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailPasswordQuery(string value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")}  EmailPassword = @EmailPassword";
            var parameters = new { EmailPassword = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")}  Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere(" AND ")}  UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        private string getBackEndFieldWitchWhere(string sql = "")
        {
         return $" (Deleted = 0) "+sql;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration