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
    public class PacienteQueryRead : QueryBase, IPacienteQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public PacienteQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel PacienteQuery(Command.Read.PacienteReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Nome, Telefone, DataNascimento, Genero, Escolaridade, Profissao, Endereco, NomeResponsavel, TelefoneResponsavel, PrincipaisQueixas, ObservacaoAdicional, TenantID, Deleted, UserId from Paciente ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.Nome)) parametersDict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"Nome like @Nome");
if (!string.IsNullOrEmpty(Command.Telefone)) parametersDict["Telefone"] = $"%{Command.Telefone}%";
if (!string.IsNullOrEmpty(Command.Telefone)) whereClauses.Add($"Telefone like @Telefone");
if (Command.Genero.HasValue) parametersDict["Genero"] = Command.Genero.Value;
if (Command.Genero.HasValue) whereClauses.Add($"Genero = @Genero");
if (!string.IsNullOrEmpty(Command.Escolaridade)) parametersDict["Escolaridade"] = $"%{Command.Escolaridade}%";
if (!string.IsNullOrEmpty(Command.Escolaridade)) whereClauses.Add($"Escolaridade like @Escolaridade");
if (!string.IsNullOrEmpty(Command.Profissao)) parametersDict["Profissao"] = $"%{Command.Profissao}%";
if (!string.IsNullOrEmpty(Command.Profissao)) whereClauses.Add($"Profissao like @Profissao");
if (!string.IsNullOrEmpty(Command.Endereco)) parametersDict["Endereco"] = $"%{Command.Endereco}%";
if (!string.IsNullOrEmpty(Command.Endereco)) whereClauses.Add($"Endereco like @Endereco");
if (!string.IsNullOrEmpty(Command.NomeResponsavel)) parametersDict["NomeResponsavel"] = $"%{Command.NomeResponsavel}%";
if (!string.IsNullOrEmpty(Command.NomeResponsavel)) whereClauses.Add($"NomeResponsavel like @NomeResponsavel");
if (!string.IsNullOrEmpty(Command.TelefoneResponsavel)) parametersDict["TelefoneResponsavel"] = $"%{Command.TelefoneResponsavel}%";
if (!string.IsNullOrEmpty(Command.TelefoneResponsavel)) whereClauses.Add($"TelefoneResponsavel like @TelefoneResponsavel");
if (!string.IsNullOrEmpty(Command.PrincipaisQueixas)) parametersDict["PrincipaisQueixas"] = $"%{Command.PrincipaisQueixas}%";
if (!string.IsNullOrEmpty(Command.PrincipaisQueixas)) whereClauses.Add($"PrincipaisQueixas like @PrincipaisQueixas");
if (!string.IsNullOrEmpty(Command.ObservacaoAdicional)) parametersDict["ObservacaoAdicional"] = $"%{Command.ObservacaoAdicional}%";
if (!string.IsNullOrEmpty(Command.ObservacaoAdicional)) whereClauses.Add($"ObservacaoAdicional like @ObservacaoAdicional");
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
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByNomeQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTelefoneQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} Telefone = @Telefone";
            var parameters = new { Telefone = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDataNascimentoQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} DataNascimento = @DataNascimento";
            var parameters = new { DataNascimento = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByGeneroQuery(int value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} Genero = @Genero";
            var parameters = new { Genero = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEscolaridadeQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} Escolaridade = @Escolaridade";
            var parameters = new { Escolaridade = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByProfissaoQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} Profissao = @Profissao";
            var parameters = new { Profissao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEnderecoQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} Endereco = @Endereco";
            var parameters = new { Endereco = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByNomeResponsavelQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} NomeResponsavel = @NomeResponsavel";
            var parameters = new { NomeResponsavel = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTelefoneResponsavelQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} TelefoneResponsavel = @TelefoneResponsavel";
            var parameters = new { TelefoneResponsavel = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByPrincipaisQueixasQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} PrincipaisQueixas = @PrincipaisQueixas";
            var parameters = new { PrincipaisQueixas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByObservacaoAdicionalQuery(string value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} ObservacaoAdicional = @ObservacaoAdicional";
            var parameters = new { ObservacaoAdicional = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Paciente WHERE {getBackEndFieldWitchWhere()} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByNomeQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} Nome = @Nome";
            var parameters = new { Nome = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTelefoneQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} Telefone = @Telefone";
            var parameters = new { Telefone = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDataNascimentoQuery(DateTime value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} DataNascimento = @DataNascimento";
            var parameters = new { DataNascimento = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByGeneroQuery(int value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} Genero = @Genero";
            var parameters = new { Genero = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEscolaridadeQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} Escolaridade = @Escolaridade";
            var parameters = new { Escolaridade = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByProfissaoQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} Profissao = @Profissao";
            var parameters = new { Profissao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEnderecoQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} Endereco = @Endereco";
            var parameters = new { Endereco = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByNomeResponsavelQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} NomeResponsavel = @NomeResponsavel";
            var parameters = new { NomeResponsavel = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTelefoneResponsavelQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} TelefoneResponsavel = @TelefoneResponsavel";
            var parameters = new { TelefoneResponsavel = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByPrincipaisQueixasQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} PrincipaisQueixas = @PrincipaisQueixas";
            var parameters = new { PrincipaisQueixas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByObservacaoAdicionalQuery(string value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} ObservacaoAdicional = @ObservacaoAdicional";
            var parameters = new { ObservacaoAdicional = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value)
        {
            var sql = $"SELECT * FROM Paciente WHERE {getBackEndFieldWitchWhere()} UserId = @UserId";
            var parameters = new { UserId = value };
            return new QueryModel(sql, parameters);
        }
        private string getBackEndFieldWitchWhere()
        {
         return $" (TenantID = {_correntUser.TenantID} AND Deleted = '') AND ";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration