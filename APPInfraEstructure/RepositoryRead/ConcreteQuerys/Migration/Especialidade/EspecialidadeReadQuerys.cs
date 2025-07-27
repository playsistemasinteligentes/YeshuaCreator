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
    public class EspecialidadeQueryRead : QueryBase, IEspecialidadeQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public EspecialidadeQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel EspecialidadeQuery(Command.Read.EspecialidadeReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Descricao, TenantID, Deleted, Changed, UserId from Especialidade ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Descricao)) parametersDict["Descricao"] = $"%{Command.Descricao}%";
if (!string.IsNullOrEmpty(Command.Descricao)) whereClauses.Add($"Descricao like @Descricao");
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
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Especialidade WHERE {getBackEndFieldWitchWhere(" AND ")} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDescricaoQuery(string value)
        {
            var sql = $"SELECT 1 FROM Especialidade WHERE {getBackEndFieldWitchWhere(" AND ")} Descricao = @Descricao";
            var parameters = new { Descricao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM Especialidade WHERE {getBackEndFieldWitchWhere(" AND ")} Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Especialidade WHERE {getBackEndFieldWitchWhere(" AND ")} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM Especialidade WHERE {getBackEndFieldWitchWhere(" AND ")}  Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDescricaoQuery(string value)
        {
            var sql = $"SELECT * FROM Especialidade WHERE {getBackEndFieldWitchWhere(" AND ")}  Descricao = @Descricao";
            var parameters = new { Descricao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value)
        {
            var sql = $"SELECT * FROM Especialidade WHERE {getBackEndFieldWitchWhere(" AND ")}  Changed = @Changed";
            var parameters = new { Changed = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM Especialidade WHERE {getBackEndFieldWitchWhere(" AND ")}  UserId = @UserId";
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