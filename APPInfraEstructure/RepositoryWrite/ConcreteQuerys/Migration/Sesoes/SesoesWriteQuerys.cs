using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Sesoes
{
    public class SesoesWriteQuery : QueryBase
    {
        public QueryModel InserirSesoesQuery(SesoesEntity Sesoes)
        {
            this.Query = $@" INSERT INTO Sesoes (PacienteId, ProfissionalId, ServicoId, DataInicio, DataFim, Status, MovimentacaoFinanceiraId, SinteseProntuario, QueixaPrincipal, MotivoConsultaAtual, SintomasRelatados, MudancasDesdeUltimaSessaao, ComportamentoObservado, EstadoEmocionalGeral, DiscursoPensamentos, TecnicasUtilizadas, QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo, ObjetivosLongoPrazo, FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico) OUTPUT INSERTED.Id VALUES(@PacienteId, @ProfissionalId, @ServicoId, @DataInicio, @DataFim, @Status, @MovimentacaoFinanceiraId, @SinteseProntuario, @QueixaPrincipal, @MotivoConsultaAtual, @SintomasRelatados, @MudancasDesdeUltimaSessaao, @ComportamentoObservado, @EstadoEmocionalGeral, @DiscursoPensamentos, @TecnicasUtilizadas, @QuestionamentosReflexoesAbordadas, @ExerciciosTarefasSugeridas, @DiagnoosticoHipoteseDiagnoostica, @ObjetivosCurtoPrazo, @ObjetivosLongoPrazo, @FrequenciaSugeridaSessooes, @EncaminhamentoOutrosProfissionais, @InformacoesRelevantesFuturasConsultas, @FeedbackPacienteSobreProcessoTerapeeutico) ";
            this.Parameters = new
            {
                PacienteId = Sesoes.PacienteId,
                ProfissionalId = Sesoes.ProfissionalId,
                ServicoId = Sesoes.ServicoId,
                DataInicio = Sesoes.DataInicio,
                DataFim = Sesoes.DataFim,
                Status = Sesoes.Status,
                MovimentacaoFinanceiraId = Sesoes.MovimentacaoFinanceiraId,
                SinteseProntuario = Sesoes.SinteseProntuario,
                QueixaPrincipal = Sesoes.QueixaPrincipal,
                MotivoConsultaAtual = Sesoes.MotivoConsultaAtual,
                SintomasRelatados = Sesoes.SintomasRelatados,
                MudancasDesdeUltimaSessaao = Sesoes.MudancasDesdeUltimaSessaao,
                ComportamentoObservado = Sesoes.ComportamentoObservado,
                EstadoEmocionalGeral = Sesoes.EstadoEmocionalGeral,
                DiscursoPensamentos = Sesoes.DiscursoPensamentos,
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
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSesoesQuery(SesoesEntity Sesoes)
        {
            this.Query = $@" UPDATE Sesoes SET PacienteId = @PacienteId, ProfissionalId = @ProfissionalId, ServicoId = @ServicoId, DataInicio = @DataInicio, DataFim = @DataFim, Status = @Status, MovimentacaoFinanceiraId = @MovimentacaoFinanceiraId, SinteseProntuario = @SinteseProntuario, QueixaPrincipal = @QueixaPrincipal, MotivoConsultaAtual = @MotivoConsultaAtual, SintomasRelatados = @SintomasRelatados, MudancasDesdeUltimaSessaao = @MudancasDesdeUltimaSessaao, ComportamentoObservado = @ComportamentoObservado, EstadoEmocionalGeral = @EstadoEmocionalGeral, DiscursoPensamentos = @DiscursoPensamentos, TecnicasUtilizadas = @TecnicasUtilizadas, QuestionamentosReflexoesAbordadas = @QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas = @ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica = @DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo = @ObjetivosCurtoPrazo, ObjetivosLongoPrazo = @ObjetivosLongoPrazo, FrequenciaSugeridaSessooes = @FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais = @EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas = @InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico = @FeedbackPacienteSobreProcessoTerapeeutico WHERE Id = @Id ";
            this.Parameters = new
            {
                PacienteId = Sesoes.PacienteId,
                ProfissionalId = Sesoes.ProfissionalId,
                ServicoId = Sesoes.ServicoId,
                DataInicio = Sesoes.DataInicio,
                DataFim = Sesoes.DataFim,
                Status = Sesoes.Status,
                MovimentacaoFinanceiraId = Sesoes.MovimentacaoFinanceiraId,
                SinteseProntuario = Sesoes.SinteseProntuario,
                QueixaPrincipal = Sesoes.QueixaPrincipal,
                MotivoConsultaAtual = Sesoes.MotivoConsultaAtual,
                SintomasRelatados = Sesoes.SintomasRelatados,
                MudancasDesdeUltimaSessaao = Sesoes.MudancasDesdeUltimaSessaao,
                ComportamentoObservado = Sesoes.ComportamentoObservado,
                EstadoEmocionalGeral = Sesoes.EstadoEmocionalGeral,
                DiscursoPensamentos = Sesoes.DiscursoPensamentos,
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
                Id = Sesoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteSesoesQuery(SesoesEntity Sesoes)
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
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration