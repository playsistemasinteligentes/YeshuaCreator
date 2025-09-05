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
            this.Query = $@" INSERT INTO Sesoes (PacienteId, DataInicio, DataFim, Status, MovimentacaoFinanceiraId, Prontuario, QueixaPrincipal, RegistroDocumental, SintomasRelatados, MudancasDesdeUltimaSessaao, ComportamentoObservado, EstadoEmocionalGeral, DiscursoPensamentos, UsoMedicacao, TecnicasUtilizadas, QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo, ObjetivosLongoPrazo, FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico, ServicoId, ProfissionalId, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PacienteId, @DataInicio, @DataFim, @Status, @MovimentacaoFinanceiraId, @Prontuario, @QueixaPrincipal, @RegistroDocumental, @SintomasRelatados, @MudancasDesdeUltimaSessaao, @ComportamentoObservado, @EstadoEmocionalGeral, @DiscursoPensamentos, @UsoMedicacao, @TecnicasUtilizadas, @QuestionamentosReflexoesAbordadas, @ExerciciosTarefasSugeridas, @DiagnoosticoHipoteseDiagnoostica, @ObjetivosCurtoPrazo, @ObjetivosLongoPrazo, @FrequenciaSugeridaSessooes, @EncaminhamentoOutrosProfissionais, @InformacoesRelevantesFuturasConsultas, @FeedbackPacienteSobreProcessoTerapeeutico, @ServicoId, @ProfissionalId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PacienteId = Sesoes.PacienteId,
                DataInicio = Sesoes.DataInicio,
                DataFim = Sesoes.DataFim,
                Status = Sesoes.Status,
                MovimentacaoFinanceiraId = Sesoes.MovimentacaoFinanceiraId,
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
            this.Query = $@" UPDATE Sesoes SET PacienteId = @PacienteId, DataInicio = @DataInicio, DataFim = @DataFim, Status = @Status, MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId, Prontuario = @Prontuario, QueixaPrincipal = @QueixaPrincipal, RegistroDocumental = @RegistroDocumental, SintomasRelatados = @SintomasRelatados, MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao, ComportamentoObservado = @ComportamentoObservado, EstadoEmocionalGeral = @EstadoEmocionalGeral, DiscursoPensamentos = @DiscursoPensamentos, UsoMedicacao = @UsoMedicacao, TecnicasUtilizadas = @TecnicasUtilizadas, QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo, ObjetivosLongoPrazo = @ObjetivosLongoPrazo, FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico, ServicoId = @ServicoId, ProfissionalId = @ProfissionalId, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = Sesoes.PacienteId,
                DataInicio = Sesoes.DataInicio,
                DataFim = Sesoes.DataFim,
                Status = Sesoes.Status,
                MovimentacaoFinanceiraId = Sesoes.MovimentacaoFinanceiraId,
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
                ProfissionalId = Sesoes.ProfissionalId,
                TenantID = Sesoes.TenantID,
                Deleted = Sesoes.Deleted,
                Changed = Sesoes.Changed,
                UserId = Sesoes.UserId,
                Id = Sesoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePacienteId(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET PacienteId = @PacienteId WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = entity.PacienteId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataInicio(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET DataInicio = @DataInicio WHERE Id = @Id ";
            this.Parameters = new
            {
                DataInicio = entity.DataInicio,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataFim(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET DataFim = @DataFim WHERE Id = @Id ";
            this.Parameters = new
            {
                DataFim = entity.DataFim,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = entity.Status,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentacaoFinanceiraId(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId WHERE Id = @Id ";
            this.Parameters = new
            {
                MovimentacaoFinanceiraId = entity.MovimentacaoFinanceiraId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProntuario(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET Prontuario = @Prontuario WHERE Id = @Id ";
            this.Parameters = new
            {
                Prontuario = entity.Prontuario,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQueixaPrincipal(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET QueixaPrincipal = @QueixaPrincipal WHERE Id = @Id ";
            this.Parameters = new
            {
                QueixaPrincipal = entity.QueixaPrincipal,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRegistroDocumental(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET RegistroDocumental = @RegistroDocumental WHERE Id = @Id ";
            this.Parameters = new
            {
                RegistroDocumental = entity.RegistroDocumental,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSintomasRelatados(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET SintomasRelatados = @SintomasRelatados WHERE Id = @Id ";
            this.Parameters = new
            {
                SintomasRelatados = entity.SintomasRelatados,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMudancasDesdeUltimaSessaao(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao WHERE Id = @Id ";
            this.Parameters = new
            {
                MudancasDesdeUltimaSessaao = entity.MudancasDesdeUltimaSessaao,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateComportamentoObservado(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET ComportamentoObservado = @ComportamentoObservado WHERE Id = @Id ";
            this.Parameters = new
            {
                ComportamentoObservado = entity.ComportamentoObservado,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstadoEmocionalGeral(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET EstadoEmocionalGeral = @EstadoEmocionalGeral WHERE Id = @Id ";
            this.Parameters = new
            {
                EstadoEmocionalGeral = entity.EstadoEmocionalGeral,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDiscursoPensamentos(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET DiscursoPensamentos = @DiscursoPensamentos WHERE Id = @Id ";
            this.Parameters = new
            {
                DiscursoPensamentos = entity.DiscursoPensamentos,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUsoMedicacao(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET UsoMedicacao = @UsoMedicacao WHERE Id = @Id ";
            this.Parameters = new
            {
                UsoMedicacao = entity.UsoMedicacao,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTecnicasUtilizadas(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET TecnicasUtilizadas = @TecnicasUtilizadas WHERE Id = @Id ";
            this.Parameters = new
            {
                TecnicasUtilizadas = entity.TecnicasUtilizadas,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuestionamentosReflexoesAbordadas(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas WHERE Id = @Id ";
            this.Parameters = new
            {
                QuestionamentosReflexoesAbordadas = entity.QuestionamentosReflexoesAbordadas,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateExerciciosTarefasSugeridas(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas WHERE Id = @Id ";
            this.Parameters = new
            {
                ExerciciosTarefasSugeridas = entity.ExerciciosTarefasSugeridas,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDiagnoosticoHipoteseDiagnoostica(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica WHERE Id = @Id ";
            this.Parameters = new
            {
                DiagnoosticoHipoteseDiagnoostica = entity.DiagnoosticoHipoteseDiagnoostica,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObjetivosCurtoPrazo(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo WHERE Id = @Id ";
            this.Parameters = new
            {
                ObjetivosCurtoPrazo = entity.ObjetivosCurtoPrazo,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObjetivosLongoPrazo(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET ObjetivosLongoPrazo = @ObjetivosLongoPrazo WHERE Id = @Id ";
            this.Parameters = new
            {
                ObjetivosLongoPrazo = entity.ObjetivosLongoPrazo,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFrequenciaSugeridaSessooes(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes WHERE Id = @Id ";
            this.Parameters = new
            {
                FrequenciaSugeridaSessooes = entity.FrequenciaSugeridaSessooes,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEncaminhamentoOutrosProfissionais(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais WHERE Id = @Id ";
            this.Parameters = new
            {
                EncaminhamentoOutrosProfissionais = entity.EncaminhamentoOutrosProfissionais,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateInformacoesRelevantesFuturasConsultas(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas WHERE Id = @Id ";
            this.Parameters = new
            {
                InformacoesRelevantesFuturasConsultas = entity.InformacoesRelevantesFuturasConsultas,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFeedbackPacienteSobreProcessoTerapeeutico(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico WHERE Id = @Id ";
            this.Parameters = new
            {
                FeedbackPacienteSobreProcessoTerapeeutico = entity.FeedbackPacienteSobreProcessoTerapeeutico,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateServicoId(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET ServicoId = @ServicoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ServicoId = entity.ServicoId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProfissionalId(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET ProfissionalId = @ProfissionalId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProfissionalId = entity.ProfissionalId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(ISesoesEntity entity)
        {
            this.Query = $@" UPDATE Sesoes SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
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