// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration
// </yeshua>

using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateSesoesReceiver : ReciverBase<ICommand, ISesoesEntity>
    {
        private readonly ISesoesWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateSesoesReceiver(
            ISesoesWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<ISesoesEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.SesoesCrudCommand c) 
             {    
                 var sesoes = new SesoesFactory(_logger).Create(c.PacienteId, c.DataInicio, c.DataFim, c.StatusAgendamento, c.StatusProntuario, c.Prontuario, c.QueixaPrincipal, c.RegistroDocumental, c.SintomasRelatados, c.MudancasDesdeUltimaSessaao, c.ComportamentoObservado, c.EstadoEmocionalGeral, c.DiscursoPensamentos, c.UsoMedicacao, c.TecnicasUtilizadas, c.QuestionamentosReflexoesAbordadas, c.ExerciciosTarefasSugeridas, c.DiagnoosticoHipoteseDiagnoostica, c.ObjetivosCurtoPrazo, c.ObjetivosLongoPrazo, c.FrequenciaSugeridaSessooes, c.EncaminhamentoOutrosProfissionais, c.InformacoesRelevantesFuturasConsultas, c.FeedbackPacienteSobreProcessoTerapeeutico, c.Id, c.ServicoId, c.MovimentacaoFinanceiraId, c.ProfissionalId);
                 if (!sesoes.isValidUpdate())
                     return ValidationError(sesoes.getErroMensagens(), null);

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