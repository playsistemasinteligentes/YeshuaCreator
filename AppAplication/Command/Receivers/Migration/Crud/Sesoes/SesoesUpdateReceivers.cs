using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Sesoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateSesoesReceiver : ReciverBase <ISesoesEntity>
    {
        private readonly ISesoesWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateSesoesReceiver(ISesoesWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<ISesoesEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.SesoesCrudCommand c) 
             {    
                 var sesoes = new SesoesFactory(_logger).Create(c.Id, c.PacienteId, c.ProfissionalId, c.ServicoId, c.DataInicio, c.DataFim, c.Status, c.MovimentacaoFinanceiraId, c.SinteseProntuario, c.QueixaPrincipal, c.MotivoConsultaAtual, c.SintomasRelatados, c.MudancasDesdeUltimaSessaao, c.ComportamentoObservado, c.EstadoEmocionalGeral, c.DiscursoPensamentos, c.TecnicasUtilizadas, c.QuestionamentosReflexoesAbordadas, c.ExerciciosTarefasSugeridas, c.DiagnoosticoHipoteseDiagnoostica, c.ObjetivosCurtoPrazo, c.ObjetivosLongoPrazo, c.FrequenciaSugeridaSessooes, c.EncaminhamentoOutrosProfissionais, c.InformacoesRelevantesFuturasConsultas, c.FeedbackPacienteSobreProcessoTerapeeutico);
                 if (!sesoes.isValidUpdate())
                     return ValidationError(sesoes.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(sesoes);
                     return Success("OK", sesoes);
                 }
                 catch (Exception e)
                 {
                    return Error(e, sesoes);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration