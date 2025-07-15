using Dominio.Entitys.Profissional;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Profissional
{
    public class ProfissionalReadQuery : QueryBase
    {
        public QueryModel ProfissionalQuery(Command.Commands.Read.ProfissionalReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Nome, EspecialidadeId, Telefone from Profissional ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (Command.EspecialidadeId.HasValue) parametersDict["EspecialidadeId"] = Command.EspecialidadeId.Value;
if (Command.EspecialidadeId.HasValue) whereClauses.Add($"EspecialidadeId = @EspecialidadeId");
if (!string.IsNullOrEmpty(Command.Telefone)) parametersDict["Telefone"] = $"%{Command.Telefone}%";
if (!string.IsNullOrEmpty(Command.Telefone)) whereClauses.Add($"Telefone like @Telefone");
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
        public QueryModel ProfissionalEspecialidadeIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Descricao from Especialidade ";
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = "SELECT 1 FROM Profissional WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByNomeQuery(string value)
        {
            var sql = "SELECT 1 FROM Profissional WHERE Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEspecialidadeIdQuery(int value)
        {
            var sql = "SELECT 1 FROM Profissional WHERE EspecialidadeId = @EspecialidadeId";
            var parameters = new { EspecialidadeId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTelefoneQuery(string value)
        {
            var sql = "SELECT 1 FROM Profissional WHERE Telefone = @Telefone";
            var parameters = new { Telefone = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = "SELECT * FROM Profissional WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByNomeQuery(string value)
        {
            var sql = "SELECT * FROM Profissional WHERE Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEspecialidadeIdQuery(int value)
        {
            var sql = "SELECT * FROM Profissional WHERE EspecialidadeId = @EspecialidadeId";
            var parameters = new { EspecialidadeId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTelefoneQuery(string value)
        {
            var sql = "SELECT * FROM Profissional WHERE Telefone = @Telefone";
            var parameters = new { Telefone = value };
            return new QueryModel(sql, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration