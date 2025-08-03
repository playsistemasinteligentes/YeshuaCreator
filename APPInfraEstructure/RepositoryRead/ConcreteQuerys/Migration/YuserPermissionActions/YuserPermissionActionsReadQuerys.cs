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
    public class YuserPermissionActionsQueryRead : QueryBase, IYuserPermissionActionsQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public YuserPermissionActionsQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel YuserPermissionActionsQuery(Command.Read.YuserPermissionActionsReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select PerfilId, permissionActionsId, Grant, Create, Read, Update, Delete, ValidUntil, TenantID, Deleted, Changed, UserId from YuserPermissionActions ";
if (Command.PerfilId.HasValue) parametersDict["PerfilId"] = Command.PerfilId.Value;
if (Command.PerfilId.HasValue) whereClauses.Add($"PerfilId = @PerfilId");
if (!string.IsNullOrEmpty(Command.permissionActionsId)) parametersDict["permissionActionsId"] = $"%{Command.permissionActionsId}%";
if (!string.IsNullOrEmpty(Command.permissionActionsId)) whereClauses.Add($"permissionActionsId like @permissionActionsId");
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
        public QueryModel YuserPermissionActionsPerfilIdQuery(Command.Patterns.Command.SearchFKCommand Command)
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
            if (whereClauses.Any() && !string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {getBackEndFieldWitchWhere()} AND ({string.Join(" OR ", whereClauses)})"; 
            else if (whereClauses.Any() && string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {string.Join(" OR ", whereClauses)}"; 
            else if (!whereClauses.Any() && !string.IsNullOrEmpty(getBackEndFieldWitchWhere())) 
            this.Query += $" WHERE {getBackEndFieldWitchWhere()}"; 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel YuserPermissionActionspermissionActionsIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id from YpermissionActions ";
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
        public QueryModel ExistsByPerfilIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} PerfilId = @PerfilId";
            var parameters = new { PerfilId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsBypermissionActionsIdQuery(string value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} permissionActionsId = @permissionActionsId";
            var parameters = new { permissionActionsId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByGrantQuery(bool value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Grant = @Grant";
            var parameters = new { Grant = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByCreateQuery(bool value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Create = @Create";
            var parameters = new { Create = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByReadQuery(bool value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Read = @Read";
            var parameters = new { Read = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUpdateQuery(bool value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Update = @Update";
            var parameters = new { Update = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDeleteQuery(bool value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Delete = @Delete";
            var parameters = new { Delete = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByValidUntilQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} ValidUntil = @ValidUntil";
            var parameters = new { ValidUntil = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByPerfilIdQuery(int value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  PerfilId = @PerfilId";
            var parameters = new { PerfilId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstBypermissionActionsIdQuery(string value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  permissionActionsId = @permissionActionsId";
            var parameters = new { permissionActionsId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByGrantQuery(bool value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Grant = @Grant";
            var parameters = new { Grant = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByCreateQuery(bool value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Create = @Create";
            var parameters = new { Create = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByReadQuery(bool value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Read = @Read";
            var parameters = new { Read = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUpdateQuery(bool value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Update = @Update";
            var parameters = new { Update = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDeleteQuery(bool value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Delete = @Delete";
            var parameters = new { Delete = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByValidUntilQuery(DateTime value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  ValidUntil = @ValidUntil";
            var parameters = new { ValidUntil = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM YuserPermissionActions WHERE {getBackEndFieldWitchWhere(" AND ")}  UserId = @UserId";
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