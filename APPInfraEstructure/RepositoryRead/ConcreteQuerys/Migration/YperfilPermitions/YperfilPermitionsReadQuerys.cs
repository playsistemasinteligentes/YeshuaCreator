using Dominio.Entitys.YperfilPermitions;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.YperfilPermitions
{
    public class YperfilPermitionsReadQuery : QueryBase
    {
        public QueryModel YperfilPermitionsQuery(Command.Commands.Read.YperfilPermitionsReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select PerfilId, PermitionsId from YperfilPermitions ";
if (Command.PerfilId.HasValue) parametersDict["PerfilId"] = Command.PerfilId.Value;
if (Command.PerfilId.HasValue) whereClauses.Add($"PerfilId = @PerfilId");
if (!string.IsNullOrEmpty(Command.PermitionsId)) parametersDict["PermitionsId"] = $"%{Command.PermitionsId}%";
if (!string.IsNullOrEmpty(Command.PermitionsId)) whereClauses.Add($"PermitionsId like @PermitionsId");
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
        public QueryModel YperfilPermitionsPerfilIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id from Yperfil ";
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel YperfilPermitionsPermitionsIdQuery(Command.Patterns.Command.SearchFKCommand Command)
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByPerfilIdQuery(int value)
        {
            var sql = "SELECT 1 FROM YperfilPermitions WHERE PerfilId = @PerfilId";
            var parameters = new { PerfilId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByPermitionsIdQuery(string value)
        {
            var sql = "SELECT 1 FROM YperfilPermitions WHERE PermitionsId = @PermitionsId";
            var parameters = new { PermitionsId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByPerfilIdQuery(int value)
        {
            var sql = "SELECT * FROM YperfilPermitions WHERE PerfilId = @PerfilId";
            var parameters = new { PerfilId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByPermitionsIdQuery(string value)
        {
            var sql = "SELECT * FROM YperfilPermitions WHERE PermitionsId = @PermitionsId";
            var parameters = new { PermitionsId = value };
            return new QueryModel(sql, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration