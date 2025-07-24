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
    public class YpserPermitionsQueryRead : QueryBase, IYpserPermitionsQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public YpserPermitionsQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel YpserPermitionsQuery(Command.Read.YpserPermitionsReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select PermitionsId, TenantID, Deleted, UserId from YpserPermitions ";
if (!string.IsNullOrEmpty(Command.PermitionsId)) parametersDict["PermitionsId"] = $"%{Command.PermitionsId}%";
if (!string.IsNullOrEmpty(Command.PermitionsId)) whereClauses.Add($"PermitionsId like @PermitionsId");
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
        public QueryModel YpserPermitionsPermitionsIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id from Ypermtions ";
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
                      }; 
                      whereClauses.Add($" Id like @Id "); 
                 }
            }
            if (whereClauses.Any() && !string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {getBackEndFieldWitchWhere()} ({string.Join(" OR ", whereClauses)})"; 
            else if (whereClauses.Any() && string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {string.Join(" OR ", whereClauses)}"; 
            else if (!whereClauses.Any() && !string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {getBackEndFieldWitchWhere()}"; 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByPermitionsIdQuery(string value)
        {
            var sql = $"SELECT 1 FROM YpserPermitions WHERE {getBackEndFieldWitchWhere()} PermitionsId = @PermitionsId";
            var parameters = new { PermitionsId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YpserPermitions WHERE {getBackEndFieldWitchWhere()} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByPermitionsIdQuery(string value)
        {
            var sql = $"SELECT * FROM YpserPermitions WHERE {getBackEndFieldWitchWhere()} PermitionsId = @PermitionsId";
            var parameters = new { PermitionsId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM YpserPermitions WHERE {getBackEndFieldWitchWhere()} UserId = @UserId";
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