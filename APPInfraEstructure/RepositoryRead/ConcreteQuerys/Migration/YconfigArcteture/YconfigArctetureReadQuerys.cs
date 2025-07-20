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
    public class YconfigArctetureQueryRead : QueryBase, IYconfigArctetureQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public YconfigArctetureQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel YconfigArctetureQuery(Command.Read.YconfigArctetureReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, AuditTrackerActived, AuditCRUDActived, TenantID from YconfigArcteture ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.AuditTrackerActived.HasValue) parametersDict["AuditTrackerActived"] = Command.AuditTrackerActived.Value;
if (Command.AuditTrackerActived.HasValue) whereClauses.Add($"AuditTrackerActived = @AuditTrackerActived");
if (Command.AuditCRUDActived.HasValue) parametersDict["AuditCRUDActived"] = Command.AuditCRUDActived.Value;
if (Command.AuditCRUDActived.HasValue) whereClauses.Add($"AuditCRUDActived = @AuditCRUDActived");
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
        public QueryModel YconfigArctetureTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command)
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
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByAuditTrackerActivedQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getTenant()} AuditTrackerActived = @AuditTrackerActived";
            var parameters = new { AuditTrackerActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByAuditCRUDActivedQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getTenant()} AuditCRUDActived = @AuditCRUDActived";
            var parameters = new { AuditCRUDActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getTenant()} TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByAuditTrackerActivedQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getTenant()} AuditTrackerActived = @AuditTrackerActived";
            var parameters = new { AuditTrackerActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByAuditCRUDActivedQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getTenant()} AuditCRUDActived = @AuditCRUDActived";
            var parameters = new { AuditCRUDActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getTenant()} TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        private string getTenant()
        {
         return $" TenantID = {_correntUser.TenentID} AND ";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration