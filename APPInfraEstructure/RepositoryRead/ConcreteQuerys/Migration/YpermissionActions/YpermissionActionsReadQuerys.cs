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
    public class YpermissionActionsQueryRead : QueryBase, IYpermissionActionsQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public YpermissionActionsQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel YpermissionActionsQuery(Command.Read.YpermissionActionsReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Description, TenantID, Deleted, Changed, UserId from YpermissionActions ";
if (!string.IsNullOrEmpty(Command.Id)) parametersDict["Id"] = $"%{Command.Id}%";
if (!string.IsNullOrEmpty(Command.Id)) whereClauses.Add($"Id like @Id");
if (!string.IsNullOrEmpty(Command.Description)) parametersDict["Description"] = $"%{Command.Description}%";
if (!string.IsNullOrEmpty(Command.Description)) whereClauses.Add($"Description like @Description");
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
        public QueryModel ExistsByIdQuery(string value)
        {
            var sql = $"SELECT 1 FROM YpermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDescriptionQuery(string value)
        {
            var sql = $"SELECT 1 FROM YpermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Description = @Description";
            var parameters = new { Description = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM YpermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YpermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(string value)
        {
            var sql = $"SELECT * FROM YpermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDescriptionQuery(string value)
        {
            var sql = $"SELECT * FROM YpermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Description = @Description";
            var parameters = new { Description = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value)
        {
            var sql = $"SELECT * FROM YpermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM YpermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  UserId = @UserId";
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