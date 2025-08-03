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
    public class YtenantPermissionMudulesQueryRead : QueryBase, IYtenantPermissionMudulesQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public YtenantPermissionMudulesQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel YtenantPermissionMudulesQuery(Command.Read.YtenantPermissionMudulesReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, permissionModulesId, TenantID, ValidUntil, Deleted, Changed, UserId from YtenantPermissionMudules ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.permissionModulesId)) parametersDict["permissionModulesId"] = $"%{Command.permissionModulesId}%";
if (!string.IsNullOrEmpty(Command.permissionModulesId)) whereClauses.Add($"permissionModulesId like @permissionModulesId");
if (Command.TenantID.HasValue) parametersDict["TenantID"] = Command.TenantID.Value;
if (Command.TenantID.HasValue) whereClauses.Add($"TenantID = @TenantID");
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
        public QueryModel YtenantPermissionMudulespermissionModulesIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id from YpermissionModules ";
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
            this.Query += $" WHERE {getBackEndFieldWitchWhere()} AND ({string.Join(" OR ", whereClauses)})"; 
            else if (whereClauses.Any() && string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {string.Join(" OR ", whereClauses)}"; 
            else if (!whereClauses.Any() && !string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {getBackEndFieldWitchWhere()}"; 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel YtenantPermissionMudulesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command)
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
            var sql = $"SELECT 1 FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsBypermissionModulesIdQuery(string value)
        {
            var sql = $"SELECT 1 FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")} permissionModulesId = @permissionModulesId";
            var parameters = new { permissionModulesId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value)
        {
            var sql = $"SELECT 1 FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")} TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByValidUntilQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")} ValidUntil = @ValidUntil";
            var parameters = new { ValidUntil = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")} Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")}  Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstBypermissionModulesIdQuery(string value)
        {
            var sql = $"SELECT * FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")}  permissionModulesId = @permissionModulesId";
            var parameters = new { permissionModulesId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value)
        {
            var sql = $"SELECT * FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")}  TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByValidUntilQuery(DateTime value)
        {
            var sql = $"SELECT * FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")}  ValidUntil = @ValidUntil";
            var parameters = new { ValidUntil = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value)
        {
            var sql = $"SELECT * FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")}  Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM YtenantPermissionMudules WHERE {getBackEndFieldWitchWhere(" AND ")}  UserId = @UserId";
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