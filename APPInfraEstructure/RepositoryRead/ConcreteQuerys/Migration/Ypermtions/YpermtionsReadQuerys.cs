using Dominio.Entitys.Ypermtions;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Ypermtions
{
    public class YpermtionsReadQuery : QueryBase
    {
        public QueryModel YpermtionsQuery(Command.Commands.Read.YpermtionsReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Description from Ypermtions ";
if (!string.IsNullOrEmpty(Command.Id)) parametersDict["Id"] = $"%{Command.Id}%";
if (!string.IsNullOrEmpty(Command.Id)) whereClauses.Add($"Id like @Id");
if (!string.IsNullOrEmpty(Command.Description)) parametersDict["Description"] = $"%{Command.Description}%";
if (!string.IsNullOrEmpty(Command.Description)) whereClauses.Add($"Description like @Description");
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" AND ", whereClauses); 
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
            var sql = "SELECT 1 FROM Ypermtions WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDescriptionQuery(string value)
        {
            var sql = "SELECT 1 FROM Ypermtions WHERE Description = @Description";
            var parameters = new { Description = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(string value)
        {
            var sql = "SELECT * FROM Ypermtions WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDescriptionQuery(string value)
        {
            var sql = "SELECT * FROM Ypermtions WHERE Description = @Description";
            var parameters = new { Description = value };
            return new QueryModel(sql, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration