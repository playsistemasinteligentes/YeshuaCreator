using Dominio.Entitys.Sesoes;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Output.Querys.Sesoes
{
    public class SesoesReadQuery : QueryBase
    {
        public QueryModel SesoesQuery(Command.Commands.Read.SesoesReadCommand Command)
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
            this.Query += " WHERE " + string.Join(" AND ", whereClauses); 
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
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
            if (whereClauses.Any()) 
            this.Query += " WHERE " + string.Join(" OR ", whereClauses); 
            return new QueryModel(this.Query, this.Parameters); 
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration