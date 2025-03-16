using Dominio.Entitys.Sesoes;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Sesoes
{
    public class SesoesReadQuery : QueryBase
    {
        public QueryModel SesoesQuery(Command.Commands.Read.SesoesReadCommand Command)
        {
            this.Query = $@" select Id, PacienteId, ProfissionalId, ServicoId, DataInicio, DataFim, Status, MovimentacaoFinanceiraId, SinteseProntuario, QueixaPrincipal, MotivoConsultaAtual, SintomasRelatados, MudancasDesdeUltimaSessaao, ComportamentoObservado, EstadoEmocionalGeral, DiscursoPensamentos, TecnicasUtilizadas, QuestionamentosReflexoesAbordadas, ExerciciosTarefasSugeridas, DiagnoosticoHipoteseDiagnoostica, ObjetivosCurtoPrazo, ObjetivosLongoPrazo, FrequenciaSugeridaSessooes, EncaminhamentoOutrosProfissionais, InformacoesRelevantesFuturasConsultas, FeedbackPacienteSobreProcessoTerapeeutico from Sesoes ";
            return new QueryModel(this.Query, null);
        }
        public QueryModel SesoesPacienteIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Paciente ";
            return new QueryModel(this.Query, null);
        }
        public QueryModel SesoesProfissionalIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Profissional ";
            return new QueryModel(this.Query, null);
        }
        public QueryModel SesoesServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Servico ";
            return new QueryModel(this.Query, null);
        }
        public QueryModel SesoesMovimentacaoFinanceiraIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id from MovimentacaoFinanceira ";
            return new QueryModel(this.Query, null);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration