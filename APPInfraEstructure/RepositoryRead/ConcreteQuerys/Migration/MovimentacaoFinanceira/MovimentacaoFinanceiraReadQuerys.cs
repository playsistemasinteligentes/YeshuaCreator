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
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            parametersDict["Offset"] = offset;
            parametersDict["PageSize"] = pageSize;
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
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
        public QueryModel ExistsByIdQuery(int value)
        {
            var sql = "SELECT 1 FROM MovimentacaoFinanceira WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByPacienteIdQuery(int value)
        {
            var sql = "SELECT 1 FROM MovimentacaoFinanceira WHERE PacienteId = @PacienteId";
            var parameters = new { PacienteId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByServicoIdQuery(int value)
        {
            var sql = "SELECT 1 FROM MovimentacaoFinanceira WHERE ServicoId = @ServicoId";
            var parameters = new { ServicoId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByValorQuery(Decimal value)
        {
            var sql = "SELECT 1 FROM MovimentacaoFinanceira WHERE Valor = @Valor";
            var parameters = new { Valor = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTipoMovimentacaoQuery(int value)
        {
            var sql = "SELECT 1 FROM MovimentacaoFinanceira WHERE TipoMovimentacao = @TipoMovimentacao";
            var parameters = new { TipoMovimentacao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDataMovimentacaoQuery(DateTime value)
        {
            var sql = "SELECT 1 FROM MovimentacaoFinanceira WHERE DataMovimentacao = @DataMovimentacao";
            var parameters = new { DataMovimentacao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsBySaldoAtualQuery(Decimal value)
        {
            var sql = "SELECT 1 FROM MovimentacaoFinanceira WHERE SaldoAtual = @SaldoAtual";
            var parameters = new { SaldoAtual = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = "SELECT * FROM MovimentacaoFinanceira WHERE Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByPacienteIdQuery(int value)
        {
            var sql = "SELECT * FROM MovimentacaoFinanceira WHERE PacienteId = @PacienteId";
            var parameters = new { PacienteId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByServicoIdQuery(int value)
        {
            var sql = "SELECT * FROM MovimentacaoFinanceira WHERE ServicoId = @ServicoId";
            var parameters = new { ServicoId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByValorQuery(Decimal value)
        {
            var sql = "SELECT * FROM MovimentacaoFinanceira WHERE Valor = @Valor";
            var parameters = new { Valor = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTipoMovimentacaoQuery(int value)
        {
            var sql = "SELECT * FROM MovimentacaoFinanceira WHERE TipoMovimentacao = @TipoMovimentacao";
            var parameters = new { TipoMovimentacao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDataMovimentacaoQuery(DateTime value)
        {
            var sql = "SELECT * FROM MovimentacaoFinanceira WHERE DataMovimentacao = @DataMovimentacao";
            var parameters = new { DataMovimentacao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstBySaldoAtualQuery(Decimal value)
        {
            var sql = "SELECT * FROM MovimentacaoFinanceira WHERE SaldoAtual = @SaldoAtual";
            var parameters = new { SaldoAtual = value };
            return new QueryModel(sql, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration