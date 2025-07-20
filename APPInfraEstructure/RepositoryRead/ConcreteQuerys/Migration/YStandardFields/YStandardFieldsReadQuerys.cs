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
    public class YStandardFieldsQueryRead : QueryBase, IYStandardFieldsQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public YStandardFieldsQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel YStandardFieldsQuery(Command.Read.YStandardFieldsReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Deleted from YStandardFields ";
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
        public QueryModel ExistsByDeletedQuery(bool value)
        {
            var sql = $"SELECT 1 FROM YStandardFields WHERE {getTenant()} Deleted = @Deleted";
            var parameters = new { Deleted = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value)
        {
            var sql = $"SELECT * FROM YStandardFields WHERE {getTenant()} Deleted = @Deleted";
            var parameters = new { Deleted = value };
            return new QueryModel(sql, parameters);
        }
        private string getTenant()
        {
 return "";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration