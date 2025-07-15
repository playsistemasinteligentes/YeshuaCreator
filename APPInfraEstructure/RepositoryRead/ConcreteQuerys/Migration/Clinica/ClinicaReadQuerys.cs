using Dominio.Entitys.Clinica;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Clinica
{
    public class ClinicaReadQuery : QueryBase
    {
        public QueryModel ClinicaQuery(Command.Commands.Read.ClinicaReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Nome, Endereco, Telefone from Clinica ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (!string.IsNullOrEmpty(Command.Endereco)) parametersDict["Endereco"] = $"%{Command.Endereco}%";
if (!string.IsNullOrEmpty(Command.Endereco)) whereClauses.Add($"Endereco like @Endereco");
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
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = "SELECT 1 FROM Clinica WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByNomeQuery(string value)
        {
            var sql = "SELECT 1 FROM Clinica WHERE Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEnderecoQuery(string value)
        {
            var sql = "SELECT 1 FROM Clinica WHERE Endereco = @Endereco";
            var parameters = new { Endereco = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTelefoneQuery(string value)
        {
            var sql = "SELECT 1 FROM Clinica WHERE Telefone = @Telefone";
            var parameters = new { Telefone = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = "SELECT * FROM Clinica WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByNomeQuery(string value)
        {
            var sql = "SELECT * FROM Clinica WHERE Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEnderecoQuery(string value)
        {
            var sql = "SELECT * FROM Clinica WHERE Endereco = @Endereco";
            var parameters = new { Endereco = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTelefoneQuery(string value)
        {
            var sql = "SELECT * FROM Clinica WHERE Telefone = @Telefone";
            var parameters = new { Telefone = value };
            return new QueryModel(sql, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration