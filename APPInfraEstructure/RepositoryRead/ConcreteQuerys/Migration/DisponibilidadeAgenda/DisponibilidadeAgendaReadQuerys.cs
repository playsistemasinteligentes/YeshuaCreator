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
    public class DisponibilidadeAgendaQueryRead : QueryBase, IDisponibilidadeAgendaQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public DisponibilidadeAgendaQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel DisponibilidadeAgendaQuery(Command.Read.DisponibilidadeAgendaReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, ProfissionalId, DataHora from DisponibilidadeAgenda ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.ProfissionalId.HasValue) parametersDict["ProfissionalId"] = Command.ProfissionalId.Value;
if (Command.ProfissionalId.HasValue) whereClauses.Add($"ProfissionalId = @ProfissionalId");
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
        public QueryModel DisponibilidadeAgendaProfissionalIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Profissional ";
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
            var sql = $"SELECT 1 FROM DisponibilidadeAgenda WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByProfissionalIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM DisponibilidadeAgenda WHERE {getTenant()} ProfissionalId = @ProfissionalId";
            var parameters = new { ProfissionalId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDataHoraQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM DisponibilidadeAgenda WHERE {getTenant()} DataHora = @DataHora";
            var parameters = new { DataHora = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM DisponibilidadeAgenda WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByProfissionalIdQuery(int value)
        {
            var sql = $"SELECT * FROM DisponibilidadeAgenda WHERE {getTenant()} ProfissionalId = @ProfissionalId";
            var parameters = new { ProfissionalId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDataHoraQuery(DateTime value)
        {
            var sql = $"SELECT * FROM DisponibilidadeAgenda WHERE {getTenant()} DataHora = @DataHora";
            var parameters = new { DataHora = value };
            return new QueryModel(sql, parameters);
        }
        private string getTenant()
        {
 return "";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration