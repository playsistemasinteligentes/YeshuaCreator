using Dominio.Entitys.Yuser;
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
    public class YuserQueryRead : QueryBase, IYuserQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public YuserQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel YuserQuery(Command.Read.YuserReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Nome, Email, Senha, TenantID from Yuser ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (!string.IsNullOrEmpty(Command.Email)) parametersDict["Email"] = $"%{Command.Email}%";
if (!string.IsNullOrEmpty(Command.Email)) whereClauses.Add($"Email like @Email");
if (!string.IsNullOrEmpty(Command.Senha)) parametersDict["Senha"] = $"%{Command.Senha}%";
if (!string.IsNullOrEmpty(Command.Senha)) whereClauses.Add($"Senha like @Senha");
if (Command.TenantID.HasValue) parametersDict["TenantID"] = Command.TenantID.Value;
if (Command.TenantID.HasValue) whereClauses.Add($"TenantID = @TenantID");
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
        public QueryModel YuserTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command)
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
            if (whereClauses.Any() && !string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {getTenant()} ({string.Join(" OR ", whereClauses)})"; 
            else if (whereClauses.Any() && string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {string.Join(" OR ", whereClauses)}"; 
            else if (!whereClauses.Any() && !string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {getTenant()}"; 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByNomeQuery(string value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getTenant()} Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailQuery(string value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getTenant()} Email = @Email";
            var parameters = new { Email = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsBySenhaQuery(string value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getTenant()} Senha = @Senha";
            var parameters = new { Senha = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getTenant()} TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByNomeQuery(string value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getTenant()} Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailQuery(string value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getTenant()} Email = @Email";
            var parameters = new { Email = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstBySenhaQuery(string value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getTenant()} Senha = @Senha";
            var parameters = new { Senha = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getTenant()} TenantID = @TenantID";
            var parameters = new { TenantID = value };
            return new QueryModel(sql, parameters);
        }
        private string getTenant()
        {
     if (_correntUser.TenentID == 0 && _correntUser.UserId == 0)
         return string.Empty;
         return $" TenantID = {_correntUser.TenentID} AND ";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration