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
        protected readonly ICurrentUser _currentUser;
        public SesoesQueryRead(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel SesoesQuery(Command.Read.SesoesReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $@" select PacienteId, DataInicio, DataFim, Status, MovimentacaoFinanceiraId, Prontuario, QueixaPrincipal, RegistroDocumental, SintomasRelatados, MudancasDesdeUltimaSessaao, ComportamentoObservado, EstadoEmocionalGeral, DiscursoPensamentos, UsoMedicacao, TecnicasUtilizadas, QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo, ObjetivosLongoPrazo, FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico, Id, ServicoId, ProfissionalId, TenantID, Deleted, Changed, UserId from Sesoes ";
if (Command.PacienteId.HasValue) parametersDict["PacienteId"] = Command.PacienteId.Value;
if (Command.PacienteId.HasValue) whereClauses.Add($"PacienteId = @PacienteId");
if (Command.Status.HasValue) parametersDict["Status"] = Command.Status.Value;
if (Command.Status.HasValue) whereClauses.Add($"Status = @Status");
if (Command.MovimentacaoFinanceiraId.HasValue) parametersDict["MovimentacaoFinanceiraId"] = Command.MovimentacaoFinanceiraId.Value;
if (Command.MovimentacaoFinanceiraId.HasValue) whereClauses.Add($"MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId");
if (!string.IsNullOrEmpty(Command.Prontuario)) parametersDict["Prontuario"] = $"%{Command.Prontuario}%";
if (!string.IsNullOrEmpty(Command.Prontuario)) whereClauses.Add($"Prontuario like @Prontuario");
if (!string.IsNullOrEmpty(Command.QueixaPrincipal)) parametersDict["QueixaPrincipal"] = $"%{Command.QueixaPrincipal}%";
if (!string.IsNullOrEmpty(Command.QueixaPrincipal)) whereClauses.Add($"QueixaPrincipal like @QueixaPrincipal");
if (!string.IsNullOrEmpty(Command.RegistroDocumental)) parametersDict["RegistroDocumental"] = $"%{Command.RegistroDocumental}%";
if (!string.IsNullOrEmpty(Command.RegistroDocumental)) whereClauses.Add($"RegistroDocumental like @RegistroDocumental");
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
if (!string.IsNullOrEmpty(Command.UsoMedicacao)) parametersDict["UsoMedicacao"] = $"%{Command.UsoMedicacao}%";
if (!string.IsNullOrEmpty(Command.UsoMedicacao)) whereClauses.Add($"UsoMedicacao like @UsoMedicacao");
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
if (Command.Id.HasValue) parametersDict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.ServicoId.HasValue) parametersDict["ServicoId"] = Command.ServicoId.Value;
if (Command.ServicoId.HasValue) whereClauses.Add($"ServicoId = @ServicoId");
if (Command.ProfissionalId.HasValue) parametersDict["ProfissionalId"] = Command.ProfissionalId.Value;
if (Command.ProfissionalId.HasValue) whereClauses.Add($"ProfissionalId = @ProfissionalId");
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
if (Command.UserId.HasValue) parametersDict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"UserId = @UserId");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            parametersDict["Offset"] = offset;
            parametersDict["PageSize"] = pageSize;
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel SesoesPacienteIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from Paciente ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      parametersDict["Id"] = numero; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      parametersDict["Id"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Id like @Id ");
                      parametersDict["Nome"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Nome like @Nome ");
                 }
           }
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel SesoesMovimentacaoFinanceiraIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id from MovimentacaoFinanceira ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      parametersDict["Id"] = numero; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      parametersDict["Id"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Id like @Id ");
                 }
           }
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel SesoesServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from Servico ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      parametersDict["Id"] = numero; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      parametersDict["Id"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Id like @Id ");
                      parametersDict["Nome"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Nome like @Nome ");
                 }
           }
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel SesoesProfissionalIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from Profissional ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      parametersDict["Id"] = numero; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      parametersDict["Id"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Id like @Id ");
                      parametersDict["Nome"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Nome like @Nome ");
                 }
           }
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel SesoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yTenant ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      parametersDict["Id"] = numero; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      parametersDict["Id"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Id like @Id ");
                      parametersDict["Nome"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Nome like @Nome ");
                 }
           }
 parametersDict["Id"] = _currentUser.TenantID;
 whereClauses.Add($"Id = @Id");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel SesoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yUser ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      parametersDict["Id"] = numero; 
                      whereClauses.Add($" Id = @Id"); 
                 }
                 else 
                 {
                      parametersDict["Id"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Id like @Id ");
                      parametersDict["Nome"] = $"%{Command.searchFK}%"; 
                      whereClauses.Add($" Nome like @Nome ");
                 }
           }
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByPacienteIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["PacienteId"] = value; 
                      whereClauses.Add($" PacienteId = @PacienteId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataInicioQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["DataInicio"] = value; 
                      whereClauses.Add($" DataInicio = @DataInicio ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataFimQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["DataFim"] = value; 
                      whereClauses.Add($" DataFim = @DataFim ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Status"] = value; 
                      whereClauses.Add($" Status = @Status ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMovimentacaoFinanceiraIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["MovimentacaoFinanceiraId"] = value; 
                      whereClauses.Add($" MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProntuarioQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Prontuario"] = value; 
                      whereClauses.Add($" Prontuario = @Prontuario ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQueixaPrincipalQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["QueixaPrincipal"] = value; 
                      whereClauses.Add($" QueixaPrincipal = @QueixaPrincipal ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRegistroDocumentalQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["RegistroDocumental"] = value; 
                      whereClauses.Add($" RegistroDocumental = @RegistroDocumental ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySintomasRelatadosQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["SintomasRelatados"] = value; 
                      whereClauses.Add($" SintomasRelatados = @SintomasRelatados ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMudancasDesdeUltimaSessaaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["MudancasDesdeUltimaSessaao"] = value; 
                      whereClauses.Add($" MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByComportamentoObservadoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ComportamentoObservado"] = value; 
                      whereClauses.Add($" ComportamentoObservado = @ComportamentoObservado ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEstadoEmocionalGeralQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["EstadoEmocionalGeral"] = value; 
                      whereClauses.Add($" EstadoEmocionalGeral = @EstadoEmocionalGeral ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDiscursoPensamentosQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["DiscursoPensamentos"] = value; 
                      whereClauses.Add($" DiscursoPensamentos = @DiscursoPensamentos ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUsoMedicacaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["UsoMedicacao"] = value; 
                      whereClauses.Add($" UsoMedicacao = @UsoMedicacao ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTecnicasUtilizadasQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["TecnicasUtilizadas"] = value; 
                      whereClauses.Add($" TecnicasUtilizadas = @TecnicasUtilizadas ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuestionamentosReflexoesAbordadasQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["QuestionamentosReflexoesAbordadas"] = value; 
                      whereClauses.Add($" QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByExerciciosTarefasSugeridasQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ExerciciosTarefasSugeridas"] = value; 
                      whereClauses.Add($" ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDiagnoosticoHipoteseDiagnoosticaQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["DiagnoosticoHipoteseDiagnoostica"] = value; 
                      whereClauses.Add($" DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByObjetivosCurtoPrazoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ObjetivosCurtoPrazo"] = value; 
                      whereClauses.Add($" ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByObjetivosLongoPrazoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ObjetivosLongoPrazo"] = value; 
                      whereClauses.Add($" ObjetivosLongoPrazo = @ObjetivosLongoPrazo ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFrequenciaSugeridaSessooesQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["FrequenciaSugeridaSessooes"] = value; 
                      whereClauses.Add($" FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEncaminhamentoOutrosProfissionaisQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["EncaminhamentoOutrosProfissionais"] = value; 
                      whereClauses.Add($" EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByInformacoesRelevantesFuturasConsultasQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["InformacoesRelevantesFuturasConsultas"] = value; 
                      whereClauses.Add($" InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFeedbackPacienteSobreProcessoTerapeeuticoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["FeedbackPacienteSobreProcessoTerapeeutico"] = value; 
                      whereClauses.Add($" FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Id"] = value; 
                      whereClauses.Add($" Id = @Id ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByServicoIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ServicoId"] = value; 
                      whereClauses.Add($" ServicoId = @ServicoId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProfissionalIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ProfissionalId"] = value; 
                      whereClauses.Add($" ProfissionalId = @ProfissionalId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["TenantID"] = value; 
                      whereClauses.Add($" TenantID = @TenantID ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Deleted"] = value; 
                      whereClauses.Add($" Deleted = @Deleted ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Changed"] = value; 
                      whereClauses.Add($" Changed = @Changed ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["UserId"] = value; 
                      whereClauses.Add($" UserId = @UserId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPacienteIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["PacienteId"] = value; 
                      whereClauses.Add($" PacienteId = @PacienteId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataInicioQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["DataInicio"] = value; 
                      whereClauses.Add($" DataInicio = @DataInicio ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataFimQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["DataFim"] = value; 
                      whereClauses.Add($" DataFim = @DataFim ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Status"] = value; 
                      whereClauses.Add($" Status = @Status ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMovimentacaoFinanceiraIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["MovimentacaoFinanceiraId"] = value; 
                      whereClauses.Add($" MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProntuarioQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Prontuario"] = value; 
                      whereClauses.Add($" Prontuario = @Prontuario ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQueixaPrincipalQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["QueixaPrincipal"] = value; 
                      whereClauses.Add($" QueixaPrincipal = @QueixaPrincipal ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRegistroDocumentalQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["RegistroDocumental"] = value; 
                      whereClauses.Add($" RegistroDocumental = @RegistroDocumental ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySintomasRelatadosQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["SintomasRelatados"] = value; 
                      whereClauses.Add($" SintomasRelatados = @SintomasRelatados ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMudancasDesdeUltimaSessaaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["MudancasDesdeUltimaSessaao"] = value; 
                      whereClauses.Add($" MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByComportamentoObservadoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ComportamentoObservado"] = value; 
                      whereClauses.Add($" ComportamentoObservado = @ComportamentoObservado ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEstadoEmocionalGeralQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["EstadoEmocionalGeral"] = value; 
                      whereClauses.Add($" EstadoEmocionalGeral = @EstadoEmocionalGeral ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDiscursoPensamentosQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["DiscursoPensamentos"] = value; 
                      whereClauses.Add($" DiscursoPensamentos = @DiscursoPensamentos ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUsoMedicacaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["UsoMedicacao"] = value; 
                      whereClauses.Add($" UsoMedicacao = @UsoMedicacao ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTecnicasUtilizadasQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["TecnicasUtilizadas"] = value; 
                      whereClauses.Add($" TecnicasUtilizadas = @TecnicasUtilizadas ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuestionamentosReflexoesAbordadasQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["QuestionamentosReflexoesAbordadas"] = value; 
                      whereClauses.Add($" QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByExerciciosTarefasSugeridasQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ExerciciosTarefasSugeridas"] = value; 
                      whereClauses.Add($" ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDiagnoosticoHipoteseDiagnoosticaQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["DiagnoosticoHipoteseDiagnoostica"] = value; 
                      whereClauses.Add($" DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByObjetivosCurtoPrazoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ObjetivosCurtoPrazo"] = value; 
                      whereClauses.Add($" ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByObjetivosLongoPrazoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ObjetivosLongoPrazo"] = value; 
                      whereClauses.Add($" ObjetivosLongoPrazo = @ObjetivosLongoPrazo ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFrequenciaSugeridaSessooesQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["FrequenciaSugeridaSessooes"] = value; 
                      whereClauses.Add($" FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEncaminhamentoOutrosProfissionaisQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["EncaminhamentoOutrosProfissionais"] = value; 
                      whereClauses.Add($" EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByInformacoesRelevantesFuturasConsultasQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["InformacoesRelevantesFuturasConsultas"] = value; 
                      whereClauses.Add($" InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFeedbackPacienteSobreProcessoTerapeeuticoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["FeedbackPacienteSobreProcessoTerapeeutico"] = value; 
                      whereClauses.Add($" FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Id"] = value; 
                      whereClauses.Add($" Id = @Id ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByServicoIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ServicoId"] = value; 
                      whereClauses.Add($" ServicoId = @ServicoId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProfissionalIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["ProfissionalId"] = value; 
                      whereClauses.Add($" ProfissionalId = @ProfissionalId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["TenantID"] = value; 
                      whereClauses.Add($" TenantID = @TenantID ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Deleted"] = value; 
                      whereClauses.Add($" Deleted = @Deleted ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["Changed"] = value; 
                      whereClauses.Add($" Changed = @Changed ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var parametersDict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT * FROM Sesoes ";
 parametersDict["TenantID"] = _currentUser.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 parametersDict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      parametersDict["UserId"] = value; 
                      whereClauses.Add($" UserId = @UserId ");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel SesoesHojeQuery()
        {
            this.Query = "SELECT t0.Id, t0.DataInicio, t1.Nome FROM Sesoes t0 INNER JOIN Paciente t1 ON t1.Id = t0.PacienteId";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;

                dict["Nome"] = $"{"Angelo"}";
                whereClauses.Add("t1.Nome = @Nome");

            dict["Deleted"] = 0;
            dict["TenantID"] = _currentUser.TenantID;

            whereClauses.Add("t0.TenantID = @TenantID");
            whereClauses.Add("t0.Deleted = @Deleted");

            whereClauses.Add("t1.TenantID = @TenantID");
            whereClauses.Add("t1.Deleted = @Deleted");

            if (whereClauses.Any()) this.Query += $" WHERE {string.Join(" AND ", whereClauses)}";
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel SesoesSemanaQuery()
        {
            this.Query = "SELECT t0.Id, t0.DataInicio, t1.Nome FROM Sesoes t0 INNER JOIN Paciente t1 ON t1.Id = t0.PacienteId";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;

                dict["DataInicio"] = DateTime.Today;
                whereClauses.Add("t0.DataInicio >= @DataInicio");

                dict["Id"] = 1;
                whereClauses.Add("t1.Id = @Id");

                dict["Nome"] = $"{""}";
                whereClauses.Add("t1.Nome = @Nome");

            dict["Deleted"] = 0;
            dict["TenantID"] = _currentUser.TenantID;

            whereClauses.Add("t0.TenantID = @TenantID");
            whereClauses.Add("t0.Deleted = @Deleted");

            whereClauses.Add("t1.TenantID = @TenantID");
            whereClauses.Add("t1.Deleted = @Deleted");

            if (whereClauses.Any()) this.Query += $" WHERE {string.Join(" AND ", whereClauses)}";
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel SesoesMesQuery()
        {
            this.Query = "SELECT t0.Id, t0.DataInicio, t1.Nome FROM Sesoes t0 INNER JOIN Paciente t1 ON t1.Id = t0.PacienteId";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;

                dict["DataInicio"] = DateTime.Today;
                whereClauses.Add("t0.DataInicio >= @DataInicio");

            dict["Deleted"] = 0;
            dict["TenantID"] = _currentUser.TenantID;

            whereClauses.Add("t0.TenantID = @TenantID");
            whereClauses.Add("t0.Deleted = @Deleted");

            whereClauses.Add("t1.TenantID = @TenantID");
            whereClauses.Add("t1.Deleted = @Deleted");

            if (whereClauses.Any()) this.Query += $" WHERE {string.Join(" AND ", whereClauses)}";
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel SesoesGeralQuery(Command.Read.SesoesGeralCommand Command)
        {
            this.Query = "SELECT t0.Id, t0.DataInicio, t1.Nome FROM Sesoes t0 INNER JOIN Paciente t1 ON t1.Id = t0.PacienteId";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;

            if (Command.DataInicio != null)
            {
                dict["DataInicio"] = Command.DataInicio;
                whereClauses.Add("t0.DataInicio >= @DataInicio");
            }

            dict["Deleted"] = 0;
            dict["TenantID"] = _currentUser.TenantID;

            whereClauses.Add("t0.TenantID = @TenantID");
            whereClauses.Add("t0.Deleted = @Deleted");

            whereClauses.Add("t1.TenantID = @TenantID");
            whereClauses.Add("t1.Deleted = @Deleted");
            if (whereClauses.Any()) this.Query += $" WHERE {string.Join(" AND ", whereClauses)}";
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration