using Dominio.Entitys.Especialidade;
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
            this.Query = $@" select Id, Descricao from Especialidade ";
            if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
            if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
            if (!string.IsNullOrEmpty(Command.Descricao)) parametersDict["Descricao"] = $"%{Command.Descricao}%";
            if (!string.IsNullOrEmpty(Command.Descricao)) whereClauses.Add($"Descricao like @Descricao");
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
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Especialidade WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDescricaoQuery(string value)
        {
            var sql = $"SELECT 1 FROM Especialidade WHERE {getTenant()} Descricao = @Descricao";
            var parameters = new { Descricao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM Especialidade WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDescricaoQuery(string value)
        {
            var sql = $"SELECT * FROM Especialidade WHERE {getTenant()} Descricao = @Descricao";
            var parameters = new { Descricao = value };
            return new QueryModel(sql, parameters);
        }
        private string getTenant()
        {
            return "";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration