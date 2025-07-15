using Dominio.Entitys.Y_Tenant;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Y_Tenant
{
    public class Y_TenantReadQuery : QueryBase
    {
        public QueryModel Y_TenantQuery(Command.Commands.Read.Y_TenantReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, CnpjCpf, Nome, UserIDAdmin from Y_Tenant ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.CnpjCpf.HasValue) parametersDict["CnpjCpf"] = Command.CnpjCpf.Value;
if (Command.CnpjCpf.HasValue) whereClauses.Add($"CnpjCpf = @CnpjCpf");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (Command.UserIDAdmin.HasValue) parametersDict["UserIDAdmin"] = Command.UserIDAdmin.Value;
if (Command.UserIDAdmin.HasValue) whereClauses.Add($"UserIDAdmin = @UserIDAdmin");
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
        public QueryModel Y_TenantUserIDAdminQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Y_User ";
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = "SELECT 1 FROM Y_Tenant WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByCnpjCpfQuery(int value)
        {
            var sql = "SELECT 1 FROM Y_Tenant WHERE CnpjCpf = @CnpjCpf";
            var parameters = new { CnpjCpf = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByNomeQuery(string value)
        {
            var sql = "SELECT 1 FROM Y_Tenant WHERE Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIDAdminQuery(int value)
        {
            var sql = "SELECT 1 FROM Y_Tenant WHERE UserIDAdmin = @UserIDAdmin";
            var parameters = new { UserIDAdmin = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = "SELECT * FROM Y_Tenant WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByCnpjCpfQuery(int value)
        {
            var sql = "SELECT * FROM Y_Tenant WHERE CnpjCpf = @CnpjCpf";
            var parameters = new { CnpjCpf = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByNomeQuery(string value)
        {
            var sql = "SELECT * FROM Y_Tenant WHERE Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIDAdminQuery(int value)
        {
            var sql = "SELECT * FROM Y_Tenant WHERE UserIDAdmin = @UserIDAdmin";
            var parameters = new { UserIDAdmin = value };
            return new QueryModel(sql, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration