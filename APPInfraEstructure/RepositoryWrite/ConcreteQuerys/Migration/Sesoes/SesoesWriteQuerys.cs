using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class SesoesQueryWrite : QueryBase, ISesoesQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public SesoesQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirSesoesQuery(ISesoesEntity Sesoes)
        {
            this.Query = $@" INSERT INTO Sesoes (PacienteId, DataInicio, DataFim, StatusAgendamento, StatusProntuario, Prontuario, QueixaPrincipal, RegistroDocumental, SintomasRelatados, MudancasDesdeUltimaSessaao, ComportamentoObservado, EstadoEmocionalGeral, DiscursoPensamentos, UsoMedicacao, TecnicasUtilizadas, QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo, ObjetivosLongoPrazo, FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico, ServicoId, MovimentacaoFinanceiraId, ProfissionalId, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PacienteId, @DataInicio, @DataFim, @StatusAgendamento, @StatusProntuario, @Prontuario, @QueixaPrincipal, @RegistroDocumental, @SintomasRelatados, @MudancasDesdeUltimaSessaao, @ComportamentoObservado, @EstadoEmocionalGeral, @DiscursoPensamentos, @UsoMedicacao, @TecnicasUtilizadas, @QuestionamentosReflexoesAbordadas, @ExerciciosTarefasSugeridas, @DiagnoosticoHipoteseDiagnoostica, @ObjetivosCurtoPrazo, @ObjetivosLongoPrazo, @FrequenciaSugeridaSessooes, @EncaminhamentoOutrosProfissionais, @InformacoesRelevantesFuturasConsultas, @FeedbackPacienteSobreProcessoTerapeeutico, @ServicoId, @MovimentacaoFinanceiraId, @ProfissionalId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PacienteId = Sesoes.PacienteId,
                DataInicio = Sesoes.DataInicio,
                DataFim = Sesoes.DataFim,
                StatusAgendamento = Sesoes.StatusAgendamento,
                StatusProntuario = Sesoes.StatusProntuario,
                Prontuario = Sesoes.Prontuario,
                QueixaPrincipal = Sesoes.QueixaPrincipal,
                RegistroDocumental = Sesoes.RegistroDocumental,
                SintomasRelatados = Sesoes.SintomasRelatados,
                MudancasDesdeUltimaSessaao = Sesoes.MudancasDesdeUltimaSessaao,
                ComportamentoObservado = Sesoes.ComportamentoObservado,
                EstadoEmocionalGeral = Sesoes.EstadoEmocionalGeral,
                DiscursoPensamentos = Sesoes.DiscursoPensamentos,
                UsoMedicacao = Sesoes.UsoMedicacao,
                TecnicasUtilizadas = Sesoes.TecnicasUtilizadas,
                QuestionamentosReflexoesAbordadas = Sesoes.QuestionamentosReflexoesAbordadas,
                ExerciciosTarefasSugeridas = Sesoes.ExerciciosTarefasSugeridas,
                DiagnoosticoHipoteseDiagnoostica = Sesoes.DiagnoosticoHipoteseDiagnoostica,
                ObjetivosCurtoPrazo = Sesoes.ObjetivosCurtoPrazo,
                ObjetivosLongoPrazo = Sesoes.ObjetivosLongoPrazo,
                FrequenciaSugeridaSessooes = Sesoes.FrequenciaSugeridaSessooes,
                EncaminhamentoOutrosProfissionais = Sesoes.EncaminhamentoOutrosProfissionais,
                InformacoesRelevantesFuturasConsultas = Sesoes.InformacoesRelevantesFuturasConsultas,
                FeedbackPacienteSobreProcessoTerapeeutico = Sesoes.FeedbackPacienteSobreProcessoTerapeeutico,
                ServicoId = Sesoes.ServicoId,
                MovimentacaoFinanceiraId = Sesoes.MovimentacaoFinanceiraId,
                ProfissionalId = Sesoes.ProfissionalId,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSesoesQuery(ISesoesEntity Sesoes)
        {
            this.Query = $@" UPDATE Sesoes SET PacienteId = @PacienteId, DataInicio = @DataInicio, DataFim = @DataFim, StatusAgendamento = @StatusAgendamento, StatusProntuario = @StatusProntuario, Prontuario = @Prontuario, QueixaPrincipal = @QueixaPrincipal, RegistroDocumental = @RegistroDocumental, SintomasRelatados = @SintomasRelatados, MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao, ComportamentoObservado = @ComportamentoObservado, EstadoEmocionalGeral = @EstadoEmocionalGeral, DiscursoPensamentos = @DiscursoPensamentos, UsoMedicacao = @UsoMedicacao, TecnicasUtilizadas = @TecnicasUtilizadas, QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo, ObjetivosLongoPrazo = @ObjetivosLongoPrazo, FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico, ServicoId = @ServicoId, MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId, ProfissionalId = @ProfissionalId, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = Sesoes.PacienteId,
                DataInicio = Sesoes.DataInicio,
                DataFim = Sesoes.DataFim,
                StatusAgendamento = Sesoes.StatusAgendamento,
                StatusProntuario = Sesoes.StatusProntuario,
                Prontuario = Sesoes.Prontuario,
                QueixaPrincipal = Sesoes.QueixaPrincipal,
                RegistroDocumental = Sesoes.RegistroDocumental,
                SintomasRelatados = Sesoes.SintomasRelatados,
                MudancasDesdeUltimaSessaao = Sesoes.MudancasDesdeUltimaSessaao,
                ComportamentoObservado = Sesoes.ComportamentoObservado,
                EstadoEmocionalGeral = Sesoes.EstadoEmocionalGeral,
                DiscursoPensamentos = Sesoes.DiscursoPensamentos,
                UsoMedicacao = Sesoes.UsoMedicacao,
                TecnicasUtilizadas = Sesoes.TecnicasUtilizadas,
                QuestionamentosReflexoesAbordadas = Sesoes.QuestionamentosReflexoesAbordadas,
                ExerciciosTarefasSugeridas = Sesoes.ExerciciosTarefasSugeridas,
                DiagnoosticoHipoteseDiagnoostica = Sesoes.DiagnoosticoHipoteseDiagnoostica,
                ObjetivosCurtoPrazo = Sesoes.ObjetivosCurtoPrazo,
                ObjetivosLongoPrazo = Sesoes.ObjetivosLongoPrazo,
                FrequenciaSugeridaSessooes = Sesoes.FrequenciaSugeridaSessooes,
                EncaminhamentoOutrosProfissionais = Sesoes.EncaminhamentoOutrosProfissionais,
                InformacoesRelevantesFuturasConsultas = Sesoes.InformacoesRelevantesFuturasConsultas,
                FeedbackPacienteSobreProcessoTerapeeutico = Sesoes.FeedbackPacienteSobreProcessoTerapeeutico,
                ServicoId = Sesoes.ServicoId,
                MovimentacaoFinanceiraId = Sesoes.MovimentacaoFinanceiraId,
                ProfissionalId = Sesoes.ProfissionalId,
                Changed = Sesoes.Changed,
                UserId = _currentUser.UserId,
                Id = Sesoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePacienteId(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET PacienteId = @PacienteId WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataInicio(int id, DateTime value)
        {
            this.Query = $@" UPDATE Sesoes SET DataInicio = @DataInicio WHERE Id = @Id ";
            this.Parameters = new
            {
                DataInicio = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataFim(int id, DateTime value)
        {
            this.Query = $@" UPDATE Sesoes SET DataFim = @DataFim WHERE Id = @Id ";
            this.Parameters = new
            {
                DataFim = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatusAgendamento(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET StatusAgendamento = @StatusAgendamento WHERE Id = @Id ";
            this.Parameters = new
            {
                StatusAgendamento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatusProntuario(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET StatusProntuario = @StatusProntuario WHERE Id = @Id ";
            this.Parameters = new
            {
                StatusProntuario = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProntuario(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET Prontuario = @Prontuario WHERE Id = @Id ";
            this.Parameters = new
            {
                Prontuario = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQueixaPrincipal(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET QueixaPrincipal = @QueixaPrincipal WHERE Id = @Id ";
            this.Parameters = new
            {
                QueixaPrincipal = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRegistroDocumental(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET RegistroDocumental = @RegistroDocumental WHERE Id = @Id ";
            this.Parameters = new
            {
                RegistroDocumental = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSintomasRelatados(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET SintomasRelatados = @SintomasRelatados WHERE Id = @Id ";
            this.Parameters = new
            {
                SintomasRelatados = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMudancasDesdeUltimaSessaao(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao WHERE Id = @Id ";
            this.Parameters = new
            {
                MudancasDesdeUltimaSessaao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateComportamentoObservado(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET ComportamentoObservado = @ComportamentoObservado WHERE Id = @Id ";
            this.Parameters = new
            {
                ComportamentoObservado = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstadoEmocionalGeral(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET EstadoEmocionalGeral = @EstadoEmocionalGeral WHERE Id = @Id ";
            this.Parameters = new
            {
                EstadoEmocionalGeral = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDiscursoPensamentos(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET DiscursoPensamentos = @DiscursoPensamentos WHERE Id = @Id ";
            this.Parameters = new
            {
                DiscursoPensamentos = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUsoMedicacao(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET UsoMedicacao = @UsoMedicacao WHERE Id = @Id ";
            this.Parameters = new
            {
                UsoMedicacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTecnicasUtilizadas(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET TecnicasUtilizadas = @TecnicasUtilizadas WHERE Id = @Id ";
            this.Parameters = new
            {
                TecnicasUtilizadas = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuestionamentosReflexoesAbordadas(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas WHERE Id = @Id ";
            this.Parameters = new
            {
                QuestionamentosReflexoesAbordadas = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateExerciciosTarefasSugeridas(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas WHERE Id = @Id ";
            this.Parameters = new
            {
                ExerciciosTarefasSugeridas = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDiagnoosticoHipoteseDiagnoostica(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica WHERE Id = @Id ";
            this.Parameters = new
            {
                DiagnoosticoHipoteseDiagnoostica = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObjetivosCurtoPrazo(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo WHERE Id = @Id ";
            this.Parameters = new
            {
                ObjetivosCurtoPrazo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObjetivosLongoPrazo(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET ObjetivosLongoPrazo = @ObjetivosLongoPrazo WHERE Id = @Id ";
            this.Parameters = new
            {
                ObjetivosLongoPrazo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFrequenciaSugeridaSessooes(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes WHERE Id = @Id ";
            this.Parameters = new
            {
                FrequenciaSugeridaSessooes = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEncaminhamentoOutrosProfissionais(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais WHERE Id = @Id ";
            this.Parameters = new
            {
                EncaminhamentoOutrosProfissionais = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateInformacoesRelevantesFuturasConsultas(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas WHERE Id = @Id ";
            this.Parameters = new
            {
                InformacoesRelevantesFuturasConsultas = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFeedbackPacienteSobreProcessoTerapeeutico(int id, string value)
        {
            this.Query = $@" UPDATE Sesoes SET FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico WHERE Id = @Id ";
            this.Parameters = new
            {
                FeedbackPacienteSobreProcessoTerapeeutico = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateServicoId(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET ServicoId = @ServicoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ServicoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentacaoFinanceiraId(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId WHERE Id = @Id ";
            this.Parameters = new
            {
                MovimentacaoFinanceiraId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProfissionalId(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET ProfissionalId = @ProfissionalId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProfissionalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Sesoes SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Sesoes SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Sesoes SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteSesoesQuery(ISesoesEntity Sesoes)
        {
            this.Query = $@" DELETE FROM Sesoes WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Sesoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration