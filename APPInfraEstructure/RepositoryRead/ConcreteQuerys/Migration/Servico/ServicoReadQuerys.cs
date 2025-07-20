using Dominio.Entitys.Servico;
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
    public class ServicoQueryRead : QueryBase, IServicoQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public ServicoQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel ServicoQuery(Command.Read.ServicoReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, GrupoServicoId, Nome, Valor from Servico ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.GrupoServicoId.HasValue) parametersDict["GrupoServicoId"] = Command.GrupoServicoId.Value;
if (Command.GrupoServicoId.HasValue) whereClauses.Add($"GrupoServicoId = @GrupoServicoId");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
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
        public QueryModel ServicoGrupoServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Descricao from GrupoServico ";
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
                       Descricao = $"%{Command.searchFK}%", 
                      }; 
                      whereClauses.Add($" Id like @Id "); 
                      whereClauses.Add($" Descricao like @Descricao "); 
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
            var sql = $"SELECT 1 FROM Servico WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByGrupoServicoIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Servico WHERE {getTenant()} GrupoServicoId = @GrupoServicoId";
            var parameters = new { GrupoServicoId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByNomeQuery(string value)
        {
            var sql = $"SELECT 1 FROM Servico WHERE {getTenant()} Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByValorQuery(Decimal value)
        {
            var sql = $"SELECT 1 FROM Servico WHERE {getTenant()} Valor = @Valor";
            var parameters = new { Valor = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM Servico WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByGrupoServicoIdQuery(int value)
        {
            var sql = $"SELECT * FROM Servico WHERE {getTenant()} GrupoServicoId = @GrupoServicoId";
            var parameters = new { GrupoServicoId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByNomeQuery(string value)
        {
            var sql = $"SELECT * FROM Servico WHERE {getTenant()} Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByValorQuery(Decimal value)
        {
            var sql = $"SELECT * FROM Servico WHERE {getTenant()} Valor = @Valor";
            var parameters = new { Valor = value };
            return new QueryModel(sql, parameters);
        }
        private string getTenant()
        {
 return "";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration