using Dominio.Entitys.MovimentacaoFinanceira;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.MovimentacaoFinanceira
{
    public class MovimentacaoFinanceiraReadQuery : QueryBase
    {
        public QueryModel MovimentacaoFinanceiraQuery(Command.Commands.Read.MovimentacaoFinanceiraReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, PacienteId, ServicoId, Valor, TipoMovimentacao, DataMovimentacao, SaldoAtual from MovimentacaoFinanceira ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.PacienteId.HasValue) parametersDict["PacienteId"] = Command.PacienteId.Value;
if (Command.PacienteId.HasValue) whereClauses.Add($"PacienteId = @PacienteId");
if (Command.ServicoId.HasValue) parametersDict["ServicoId"] = Command.ServicoId.Value;
if (Command.ServicoId.HasValue) whereClauses.Add($"ServicoId = @ServicoId");
if (Command.TipoMovimentacao.HasValue) parametersDict["TipoMovimentacao"] = Command.TipoMovimentacao.Value;
if (Command.TipoMovimentacao.HasValue) whereClauses.Add($"TipoMovimentacao = @TipoMovimentacao");
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" AND ", whereClauses); 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel MovimentacaoFinanceiraPacienteIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Paciente ";
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel MovimentacaoFinanceiraServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Servico ";
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration