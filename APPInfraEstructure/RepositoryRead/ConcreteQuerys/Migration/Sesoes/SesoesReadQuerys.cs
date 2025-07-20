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
    public class SesoesQueryRead : QueryBase, ISesoesQueryRead
    {
        protected readonly ICurrentUser _correntUser;
        public SesoesQueryRead(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel SesoesQuery(Command.Read.SesoesReadCommand Command)
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, PacienteId, ProfissionalId, ServicoId, DataInicio, DataFim, Status, MovimentacaoFinanceiraId, SinteseProntuario, QueixaPrincipal, MotivoConsultaAtual, SintomasRelatados, MudancasDesdeUltimaSessaao, ComportamentoObservado, EstadoEmocionalGeral, DiscursoPensamentos, TecnicasUtilizadas, QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo, ObjetivosLongoPrazo, FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico from Sesoes ";
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.PacienteId.HasValue) parametersDict["PacienteId"] = Command.PacienteId.Value;
if (Command.PacienteId.HasValue) whereClauses.Add($"PacienteId = @PacienteId");
if (Command.ProfissionalId.HasValue) parametersDict["ProfissionalId"] = Command.ProfissionalId.Value;
if (Command.ProfissionalId.HasValue) whereClauses.Add($"ProfissionalId = @ProfissionalId");
if (Command.ServicoId.HasValue) parametersDict["ServicoId"] = Command.ServicoId.Value;
if (Command.ServicoId.HasValue) whereClauses.Add($"ServicoId = @ServicoId");
if (Command.Status.HasValue) parametersDict["Status"] = Command.Status.Value;
if (Command.Status.HasValue) whereClauses.Add($"Status = @Status");
if (Command.MovimentacaoFinanceiraId.HasValue) parametersDict["MovimentacaoFinanceiraId"] = Command.MovimentacaoFinanceiraId.Value;
if (Command.MovimentacaoFinanceiraId.HasValue) whereClauses.Add($"MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId");
if (!string.IsNullOrEmpty(Command.SinteseProntuario)) parametersDict["SinteseProntuario"] = $"%{Command.SinteseProntuario}%";
if (!string.IsNullOrEmpty(Command.SinteseProntuario)) whereClauses.Add($"SinteseProntuario like @SinteseProntuario");
if (!string.IsNullOrEmpty(Command.QueixaPrincipal)) parametersDict["QueixaPrincipal"] = $"%{Command.QueixaPrincipal}%";
if (!string.IsNullOrEmpty(Command.QueixaPrincipal)) whereClauses.Add($"QueixaPrincipal like @QueixaPrincipal");
if (!string.IsNullOrEmpty(Command.MotivoConsultaAtual)) parametersDict["MotivoConsultaAtual"] = $"%{Command.MotivoConsultaAtual}%";
if (!string.IsNullOrEmpty(Command.MotivoConsultaAtual)) whereClauses.Add($"MotivoConsultaAtual like @MotivoConsultaAtual");
if (!string.IsNullOrEmpty(Command.SintomasRelatados)) parametersDict["SintomasRelatados"] = $"%{Command.SintomasRelatados}%";
if (!string.IsNullOrEmpty(Command.SintomasRelatados)) whereClauses.Add($"SintomasRelatados like @SintomasRelatados");
if (Command.MudancasDesdeUltimaSessaao.HasValue) parametersDict["MudancasDesdeUltimaSessaao"] = Command.MudancasDesdeUltimaSessaao.Value;
if (Command.MudancasDesdeUltimaSessaao.HasValue) whereClauses.Add($"MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao");
if (!string.IsNullOrEmpty(Command.ComportamentoObservado)) parametersDict["ComportamentoObservado"] = $"%{Command.ComportamentoObservado}%";
if (!string.IsNullOrEmpty(Command.ComportamentoObservado)) whereClauses.Add($"ComportamentoObservado like @ComportamentoObservado");
if (!string.IsNullOrEmpty(Command.EstadoEmocionalGeral)) parametersDict["EstadoEmocionalGeral"] = $"%{Command.EstadoEmocionalGeral}%";
if (!string.IsNullOrEmpty(Command.EstadoEmocionalGeral)) whereClauses.Add($"EstadoEmocionalGeral like @EstadoEmocionalGeral");
if (!string.IsNullOrEmpty(Command.DiscursoPensamentos)) parametersDict["DiscursoPensamentos"] = $"%{Command.DiscursoPensamentos}%";
if (!string.IsNullOrEmpty(Command.DiscursoPensamentos)) whereClauses.Add($"DiscursoPensamentos like @DiscursoPensamentos");
if (!string.IsNullOrEmpty(Command.TecnicasUtilizadas)) parametersDict["TecnicasUtilizadas"] = $"%{Command.TecnicasUtilizadas}%";
if (!string.IsNullOrEmpty(Command.TecnicasUtilizadas)) whereClauses.Add($"TecnicasUtilizadas like @TecnicasUtilizadas");
if (!string.IsNullOrEmpty(Command.QuestionamentosReflexoesAbordadas)) parametersDict["QuestionamentosReflexoesAbordadas"] = $"%{Command.QuestionamentosReflexoesAbordadas}%";
if (!string.IsNullOrEmpty(Command.QuestionamentosReflexoesAbordadas)) whereClauses.Add($"QuestionamentosReflexoesAbordadas like @QuestionamentosReflexoesAbordadas");
if (!string.IsNullOrEmpty(Command.ExerciciosTarefasSugeridas)) parametersDict["ExerciciosTarefasSugeridas"] = $"%{Command.ExerciciosTarefasSugeridas}%";
if (!string.IsNullOrEmpty(Command.ExerciciosTarefasSugeridas)) whereClauses.Add($"ExerciciosTarefasSugeridas like @ExerciciosTarefasSugeridas");
if (!string.IsNullOrEmpty(Command.DiagnoosticoHipoteseDiagnoostica)) parametersDict["DiagnoosticoHipoteseDiagnoostica"] = $"%{Command.DiagnoosticoHipoteseDiagnoostica}%";
if (!string.IsNullOrEmpty(Command.DiagnoosticoHipoteseDiagnoostica)) whereClauses.Add($"DiagnoosticoHipoteseDiagnoostica like @DiagnoosticoHipoteseDiagnoostica");
if (!string.IsNullOrEmpty(Command.ObjetivosCurtoPrazo)) parametersDict["ObjetivosCurtoPrazo"] = $"%{Command.ObjetivosCurtoPrazo}%";
if (!string.IsNullOrEmpty(Command.ObjetivosCurtoPrazo)) whereClauses.Add($"ObjetivosCurtoPrazo like @ObjetivosCurtoPrazo");
if (!string.IsNullOrEmpty(Command.ObjetivosLongoPrazo)) parametersDict["ObjetivosLongoPrazo"] = $"%{Command.ObjetivosLongoPrazo}%";
if (!string.IsNullOrEmpty(Command.ObjetivosLongoPrazo)) whereClauses.Add($"ObjetivosLongoPrazo like @ObjetivosLongoPrazo");
if (!string.IsNullOrEmpty(Command.FrequenciaSugeridaSessooes)) parametersDict["FrequenciaSugeridaSessooes"] = $"%{Command.FrequenciaSugeridaSessooes}%";
if (!string.IsNullOrEmpty(Command.FrequenciaSugeridaSessooes)) whereClauses.Add($"FrequenciaSugeridaSessooes like @FrequenciaSugeridaSessooes");
if (!string.IsNullOrEmpty(Command.EncaminhamentoOutrosProfissionais)) parametersDict["EncaminhamentoOutrosProfissionais"] = $"%{Command.EncaminhamentoOutrosProfissionais}%";
if (!string.IsNullOrEmpty(Command.EncaminhamentoOutrosProfissionais)) whereClauses.Add($"EncaminhamentoOutrosProfissionais like @EncaminhamentoOutrosProfissionais");
if (!string.IsNullOrEmpty(Command.InformacoesRelevantesFuturasConsultas)) parametersDict["InformacoesRelevantesFuturasConsultas"] = $"%{Command.InformacoesRelevantesFuturasConsultas}%";
if (!string.IsNullOrEmpty(Command.InformacoesRelevantesFuturasConsultas)) whereClauses.Add($"InformacoesRelevantesFuturasConsultas like @InformacoesRelevantesFuturasConsultas");
if (!string.IsNullOrEmpty(Command.FeedbackPacienteSobreProcessoTerapeeutico)) parametersDict["FeedbackPacienteSobreProcessoTerapeeutico"] = $"%{Command.FeedbackPacienteSobreProcessoTerapeeutico}%";
if (!string.IsNullOrEmpty(Command.FeedbackPacienteSobreProcessoTerapeeutico)) whereClauses.Add($"FeedbackPacienteSobreProcessoTerapeeutico like @FeedbackPacienteSobreProcessoTerapeeutico");
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
        public QueryModel SesoesPacienteIdQuery(Command.Patterns.Command.SearchFKCommand Command)
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
            if (whereClauses.Any() && !string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {getTenant()} ({string.Join(" OR ", whereClauses)})"; 
            else if (whereClauses.Any() && string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {string.Join(" OR ", whereClauses)}"; 
            else if (!whereClauses.Any() && !string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {getTenant()}"; 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel SesoesProfissionalIdQuery(Command.Patterns.Command.SearchFKCommand Command)
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
        public QueryModel SesoesServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command)
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
            if (whereClauses.Any() && !string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {getTenant()} ({string.Join(" OR ", whereClauses)})"; 
            else if (whereClauses.Any() && string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {string.Join(" OR ", whereClauses)}"; 
            else if (!whereClauses.Any() && !string.IsNullOrEmpty(getTenant())) 
            this.Query += $" WHERE {getTenant()}"; 
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel SesoesMovimentacaoFinanceiraIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id from MovimentacaoFinanceira ";
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
                      }; 
                      whereClauses.Add($" Id like @Id "); 
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
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByPacienteIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} PacienteId = @PacienteId";
            var parameters = new { PacienteId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByProfissionalIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} ProfissionalId = @ProfissionalId";
            var parameters = new { ProfissionalId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByServicoIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} ServicoId = @ServicoId";
            var parameters = new { ServicoId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDataInicioQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} DataInicio = @DataInicio";
            var parameters = new { DataInicio = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDataFimQuery(DateTime value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} DataFim = @DataFim";
            var parameters = new { DataFim = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByStatusQuery(int value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} Status = @Status";
            var parameters = new { Status = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByMovimentacaoFinanceiraIdQuery(int value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId";
            var parameters = new { MovimentacaoFinanceiraId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsBySinteseProntuarioQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} SinteseProntuario = @SinteseProntuario";
            var parameters = new { SinteseProntuario = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByQueixaPrincipalQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} QueixaPrincipal = @QueixaPrincipal";
            var parameters = new { QueixaPrincipal = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByMotivoConsultaAtualQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} MotivoConsultaAtual = @MotivoConsultaAtual";
            var parameters = new { MotivoConsultaAtual = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsBySintomasRelatadosQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} SintomasRelatados = @SintomasRelatados";
            var parameters = new { SintomasRelatados = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByMudancasDesdeUltimaSessaaoQuery(int value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao";
            var parameters = new { MudancasDesdeUltimaSessaao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByComportamentoObservadoQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} ComportamentoObservado = @ComportamentoObservado";
            var parameters = new { ComportamentoObservado = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEstadoEmocionalGeralQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} EstadoEmocionalGeral = @EstadoEmocionalGeral";
            var parameters = new { EstadoEmocionalGeral = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDiscursoPensamentosQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} DiscursoPensamentos = @DiscursoPensamentos";
            var parameters = new { DiscursoPensamentos = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByTecnicasUtilizadasQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} TecnicasUtilizadas = @TecnicasUtilizadas";
            var parameters = new { TecnicasUtilizadas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByQuestionamentosReflexoesAbordadasQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas";
            var parameters = new { QuestionamentosReflexoesAbordadas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByExerciciosTarefasSugeridasQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas";
            var parameters = new { ExerciciosTarefasSugeridas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByDiagnoosticoHipoteseDiagnoosticaQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica";
            var parameters = new { DiagnoosticoHipoteseDiagnoostica = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByObjetivosCurtoPrazoQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo";
            var parameters = new { ObjetivosCurtoPrazo = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByObjetivosLongoPrazoQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} ObjetivosLongoPrazo = @ObjetivosLongoPrazo";
            var parameters = new { ObjetivosLongoPrazo = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByFrequenciaSugeridaSessooesQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes";
            var parameters = new { FrequenciaSugeridaSessooes = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByEncaminhamentoOutrosProfissionaisQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais";
            var parameters = new { EncaminhamentoOutrosProfissionais = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByInformacoesRelevantesFuturasConsultasQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas";
            var parameters = new { InformacoesRelevantesFuturasConsultas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel ExistsByFeedbackPacienteSobreProcessoTerapeeuticoQuery(string value)
        {
            var sql = $"SELECT 1 FROM Sesoes WHERE {getTenant()} FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico";
            var parameters = new { FeedbackPacienteSobreProcessoTerapeeutico = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByIdQuery(int value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} Id = @Id";
            var parameters = new { Id = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByPacienteIdQuery(int value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} PacienteId = @PacienteId";
            var parameters = new { PacienteId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByProfissionalIdQuery(int value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} ProfissionalId = @ProfissionalId";
            var parameters = new { ProfissionalId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByServicoIdQuery(int value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} ServicoId = @ServicoId";
            var parameters = new { ServicoId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDataInicioQuery(DateTime value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} DataInicio = @DataInicio";
            var parameters = new { DataInicio = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDataFimQuery(DateTime value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} DataFim = @DataFim";
            var parameters = new { DataFim = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByStatusQuery(int value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} Status = @Status";
            var parameters = new { Status = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByMovimentacaoFinanceiraIdQuery(int value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId";
            var parameters = new { MovimentacaoFinanceiraId = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstBySinteseProntuarioQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} SinteseProntuario = @SinteseProntuario";
            var parameters = new { SinteseProntuario = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByQueixaPrincipalQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} QueixaPrincipal = @QueixaPrincipal";
            var parameters = new { QueixaPrincipal = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByMotivoConsultaAtualQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} MotivoConsultaAtual = @MotivoConsultaAtual";
            var parameters = new { MotivoConsultaAtual = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstBySintomasRelatadosQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} SintomasRelatados = @SintomasRelatados";
            var parameters = new { SintomasRelatados = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByMudancasDesdeUltimaSessaaoQuery(int value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao";
            var parameters = new { MudancasDesdeUltimaSessaao = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByComportamentoObservadoQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} ComportamentoObservado = @ComportamentoObservado";
            var parameters = new { ComportamentoObservado = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEstadoEmocionalGeralQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} EstadoEmocionalGeral = @EstadoEmocionalGeral";
            var parameters = new { EstadoEmocionalGeral = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDiscursoPensamentosQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} DiscursoPensamentos = @DiscursoPensamentos";
            var parameters = new { DiscursoPensamentos = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByTecnicasUtilizadasQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} TecnicasUtilizadas = @TecnicasUtilizadas";
            var parameters = new { TecnicasUtilizadas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByQuestionamentosReflexoesAbordadasQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas";
            var parameters = new { QuestionamentosReflexoesAbordadas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByExerciciosTarefasSugeridasQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas";
            var parameters = new { ExerciciosTarefasSugeridas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByDiagnoosticoHipoteseDiagnoosticaQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica";
            var parameters = new { DiagnoosticoHipoteseDiagnoostica = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByObjetivosCurtoPrazoQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo";
            var parameters = new { ObjetivosCurtoPrazo = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByObjetivosLongoPrazoQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} ObjetivosLongoPrazo = @ObjetivosLongoPrazo";
            var parameters = new { ObjetivosLongoPrazo = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByFrequenciaSugeridaSessooesQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes";
            var parameters = new { FrequenciaSugeridaSessooes = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByEncaminhamentoOutrosProfissionaisQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais";
            var parameters = new { EncaminhamentoOutrosProfissionais = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByInformacoesRelevantesFuturasConsultasQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas";
            var parameters = new { InformacoesRelevantesFuturasConsultas = value };
            return new QueryModel(sql, parameters);
        }
        public QueryModel FirstByFeedbackPacienteSobreProcessoTerapeeuticoQuery(string value)
        {
            var sql = $"SELECT * FROM Sesoes WHERE {getTenant()} FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico";
            var parameters = new { FeedbackPacienteSobreProcessoTerapeeutico = value };
            return new QueryModel(sql, parameters);
        }
        private string getTenant()
        {
 return "";
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration