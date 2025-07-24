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
            this.Query = $@" select Id, Nome, Email, Senha, TenantID, Deleted from Yuser ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (!string.IsNullOrEmpty(Command.Email)) parametersDict["Email"] = $"%{Command.Email}%";
if (!string.IsNullOrEmpty(Command.Email)) whereClauses.Add($"Email like @Email");
if (!string.IsNullOrEmpty(Command.Senha)) parametersDict["Senha"] = $"%{Command.Senha}%";
if (!string.IsNullOrEmpty(Command.Senha)) whereClauses.Add($"Senha like @Senha");
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
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getBackEndFieldWitchWhere()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByNomeQuery(string value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getBackEndFieldWitchWhere()} Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEmailQuery(string value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getBackEndFieldWitchWhere()} Email = @Email";
            var parameters = new { Email = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsBySenhaQuery(string value)
        {
            var sql = $"SELECT 1 FROM Yuser WHERE {getBackEndFieldWitchWhere()} Senha = @Senha";
            var parameters = new { Senha = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getBackEndFieldWitchWhere()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByNomeQuery(string value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getBackEndFieldWitchWhere()} Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEmailQuery(string value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getBackEndFieldWitchWhere()} Email = @Email";
            var parameters = new { Email = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstBySenhaQuery(string value)
        {
            var sql = $"SELECT * FROM Yuser WHERE {getBackEndFieldWitchWhere()} Senha = @Senha";
            var parameters = new { Senha = value };
            return new QueryModel(sql, parameters);
        }
        private string getBackEndFieldWitchWhere()
        {
     if (_correntUser.TenantID == 0 && _correntUser.UserId == 0)
         return string.Empty;
         return $" (TenantID = {_correntUser.TenantID} AND Deleted = '') AND ";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration