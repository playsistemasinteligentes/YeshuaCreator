using Dominio.Entitys.Ytenant_Configuration;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Ytenant_Configuration
{
    public class Ytenant_ConfigurationReadQuery : QueryBase
    {
        public QueryModel Ytenant_ConfigurationQuery(Command.Commands.Read.Ytenant_ConfigurationReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, AuditTrackerActived, AuditCRUDActived, TenantID from Ytenant_Configuration ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.AuditTrackerActived.HasValue) parametersDict["AuditTrackerActived"] = Command.AuditTrackerActived.Value;
if (Command.AuditTrackerActived.HasValue) whereClauses.Add($"AuditTrackerActived = @AuditTrackerActived");
if (Command.AuditCRUDActived.HasValue) parametersDict["AuditCRUDActived"] = Command.AuditCRUDActived.Value;
if (Command.AuditCRUDActived.HasValue) whereClauses.Add($"AuditCRUDActived = @AuditCRUDActived");
if (Command.TenantID.HasValue) parametersDict["TenantID"] = Command.TenantID.Value;
if (Command.TenantID.HasValue) whereClauses.Add($"TenantID = @TenantID");
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
        public QueryModel Ytenant_ConfigurationTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command)
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = "SELECT 1 FROM Ytenant_Configuration WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByAuditTrackerActivedQuery(int value)
        {
            var sql = "SELECT 1 FROM Ytenant_Configuration WHERE AuditTrackerActived = @AuditTrackerActived";
            var parameters = new { AuditTrackerActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByAuditCRUDActivedQuery(int value)
        {
            var sql = "SELECT 1 FROM Ytenant_Configuration WHERE AuditCRUDActived = @AuditCRUDActived";
            var parameters = new { AuditCRUDActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value)
        {
            var sql = "SELECT 1 FROM Ytenant_Configuration WHERE TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = "SELECT * FROM Ytenant_Configuration WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByAuditTrackerActivedQuery(int value)
        {
            var sql = "SELECT * FROM Ytenant_Configuration WHERE AuditTrackerActived = @AuditTrackerActived";
            var parameters = new { AuditTrackerActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByAuditCRUDActivedQuery(int value)
        {
            var sql = "SELECT * FROM Ytenant_Configuration WHERE AuditCRUDActived = @AuditCRUDActived";
            var parameters = new { AuditCRUDActived = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value)
        {
            var sql = "SELECT * FROM Ytenant_Configuration WHERE TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration