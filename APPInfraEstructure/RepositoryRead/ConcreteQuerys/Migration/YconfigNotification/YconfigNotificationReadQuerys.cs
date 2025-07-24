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
            this.Query = $@" select Id, EmailAdress, EmailPassword, TenantID, Deleted, UserId from YconfigNotification ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.EmailAdress)) parametersDict["EmailAdress"] = $"%{Command.EmailAdress}%";
if (!string.IsNullOrEmpty(Command.EmailAdress)) whereClauses.Add($"EmailAdress like @EmailAdress");
if (!string.IsNullOrEmpty(Command.EmailPassword)) parametersDict["EmailPassword"] = $"%{Command.EmailPassword}%";
if (!string.IsNullOrEmpty(Command.EmailPassword)) whereClauses.Add($"EmailPassword like @EmailPassword");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {getBackEndFieldWitchWhere()} {string.Join(" AND ", whereClauses)}"; 
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
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailAdressQuery(string value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere()} EmailAdress = @EmailAdress";
            var parameters = new { EmailAdress = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailPasswordQuery(string value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere()} EmailPassword = @EmailPassword";
            var parameters = new { EmailPassword = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getBackEndFieldWitchWhere()} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailAdressQuery(string value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere()} EmailAdress = @EmailAdress";
            var parameters = new { EmailAdress = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailPasswordQuery(string value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere()} EmailPassword = @EmailPassword";
            var parameters = new { EmailPassword = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getBackEndFieldWitchWhere()} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        private string getBackEndFieldWitchWhere()
        {
         return $" (TenantID = {_correntUser.TenantID} AND Deleted = '') AND ";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration