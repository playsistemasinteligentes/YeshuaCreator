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
            this.Query = $@" select Id, AuditTrackerActived, AuditCRUDActived, TenantID, Deleted, Changed, UserId from YconfigArcteture ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.AuditTrackerActived.HasValue) parametersDict["AuditTrackerActived"] = Command.AuditTrackerActived.Value;
if (Command.AuditTrackerActived.HasValue) whereClauses.Add($"AuditTrackerActived = @AuditTrackerActived");
if (Command.AuditCRUDActived.HasValue) parametersDict["AuditCRUDActived"] = Command.AuditCRUDActived.Value;
if (Command.AuditCRUDActived.HasValue) whereClauses.Add($"AuditCRUDActived = @AuditCRUDActived");
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
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByAuditTrackerActivedQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")} AuditTrackerActived = @AuditTrackerActived";
            var parameters = new { AuditTrackerActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByAuditCRUDActivedQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")} AuditCRUDActived = @AuditCRUDActived";
            var parameters = new { AuditCRUDActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")} Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")}  Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByAuditTrackerActivedQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")}  AuditTrackerActived = @AuditTrackerActived";
            var parameters = new { AuditTrackerActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByAuditCRUDActivedQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")}  AuditCRUDActived = @AuditCRUDActived";
            var parameters = new { AuditCRUDActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")}  Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM YconfigArcteture WHERE {getBackEndFieldWitchWhere(" AND ")}  UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        private string getBackEndFieldWitchWhere(string sql = "")
        {
         return $" (TenantID = {_correntUser.TenantID} AND Deleted = 0) "+sql;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration