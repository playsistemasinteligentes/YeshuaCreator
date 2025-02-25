using Comandos.Pateners.Command;
using Dominio.Entitys.Sesoes;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Sesoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateSesoesReceiver : ReciverBase
    {
        private readonly ISesoesWriteRepository _repository;

        public UpdateSesoesReceiver(ISesoesWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Command.Commands.SesoesCrudCommand)comand;

            var sesoes = new SesoesEntity(c.Id, c.PacienteId, c.ProfissionalId, c.ServicoId, c.DataInicio, c.DataFim, c.Status, c.MovimentacaoFinanceiraId, c.SinteseProntuario, c.QueixaPrincipal, c.MotivoConsultaAtual, c.SintomasRelatados, c.MudancasDesdeUltimaSessaao, c.ComportamentoObservado, c.EstadoEmocionalGeral, c.DiscursoPensamentos, c.TecnicasUtilizadas, c.QuestionamentosReflexoesAbordadas, c.ExerciciosTarefasSugeridas, c.DiagnoosticoHipoteseDiagnoostica, c.ObjetivosCurtoPrazo, c.ObjetivosLongoPrazo, c.FrequenciaSugeridaSessooes, c.EncaminhamentoOutrosProfissionais, c.InformacoesRelevantesFuturasConsultas, c.FeedbackPacienteSobreProcessoTerapeeutico);
            if (!sesoes.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Update(sesoes);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
