using Dominio.Entitys.YconfigNotification;
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
            this.Query = $@" select Id, EmailAdress, EmailPassword, TenantID from YconfigNotification ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.EmailAdress)) parametersDict["EmailAdress"] = $"%{Command.EmailAdress}%";
if (!string.IsNullOrEmpty(Command.EmailAdress)) whereClauses.Add($"EmailAdress like @EmailAdress");
if (!string.IsNullOrEmpty(Command.EmailPassword)) parametersDict["EmailPassword"] = $"%{Command.EmailPassword}%";
if (!string.IsNullOrEmpty(Command.EmailPassword)) whereClauses.Add($"EmailPassword like @EmailPassword");
if (Command.TenantID.HasValue) parametersDict["TenantID"] = Command.TenantID.Value;
if (Command.TenantID.HasValue) whereClauses.Add($"TenantID = @TenantID");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {getTenant()} {string.Join(" AND ", whereClauses)}"; 
            else if (!string.IsNullOrEmpty(getTenant())) 
                 this.Query += $" WHERE {getTenant()}"; 
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
            if (whereClauses.Any() && !string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {getTenant()} ({string.Join(" OR ", whereClauses)})"; 
            else if (whereClauses.Any() && string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {string.Join(" OR ", whereClauses)}"; 
            else if (!whereClauses.Any() && !string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {getTenant()}"; 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailAdressQuery(string value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getTenant()} EmailAdress = @EmailAdress";
            var parameters = new { EmailAdress = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailPasswordQuery(string value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getTenant()} EmailPassword = @EmailPassword";
            var parameters = new { EmailPassword = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigNotification WHERE {getTenant()} TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailAdressQuery(string value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getTenant()} EmailAdress = @EmailAdress";
            var parameters = new { EmailAdress = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailPasswordQuery(string value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getTenant()} EmailPassword = @EmailPassword";
            var parameters = new { EmailPassword = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigNotification WHERE {getTenant()} TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        private string getTenant()
        {
         return $" TenantID = {_correntUser.TenentID} AND ";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration