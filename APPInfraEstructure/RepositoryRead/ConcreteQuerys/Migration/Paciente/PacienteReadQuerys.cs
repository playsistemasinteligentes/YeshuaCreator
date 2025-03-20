using Dominio.Entitys.Paciente;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Paciente
{
    public class PacienteReadQuery : QueryBase
    {
        public QueryModel PacienteQuery(Command.Commands.Read.PacienteReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Nome, Telefone, DataNascimento, Genero, Escolaridade, Profissao, Endereco, NomeResponsavel, TelefoneResponsavel, PrincipaisQueixas, ObservacaoAdicional from Paciente ";
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
            this.Query += " WHERE " + string.Join(" AND ", whereClauses); 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration