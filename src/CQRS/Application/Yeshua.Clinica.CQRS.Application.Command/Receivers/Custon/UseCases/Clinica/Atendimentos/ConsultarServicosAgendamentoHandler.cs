// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class ConsultarServicosAgendamentoHandler
    {
        private readonly ISesoesReadRepository _read;
        public ConsultarServicosAgendamentoHandler(ILogger logger,IExecutionContext context,ISesoesReadRepository read):base(logger,context)
        { _read=read; }
protected partial Task<State<ConsultarServicosAgendamentoOutputCommand>> CustomActionHookAsync(State<ConsultarServicosAgendamentoOutputCommand> state, ConsultarServicosAgendamentoInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var services=_read.ConsultarServicosAgendamento();
        return Task.FromResult(Success("Serviços consultados.",new ConsultarServicosAgendamentoOutputCommand {
            Servicos=services.Select(s=>new ServicoAgendamentoInfo {Id=s.Id,Nome=s.Nome,ModeloConsulta=s.ModeloConsulta,VersaoModeloConsulta=s.VersaoModeloConsulta}).ToList()
        }));
    }
    catch(Clinica.Atendimentos.AtendimentoException e)
    { return Task.FromResult(new State<ConsultarServicosAgendamentoOutputCommand>(e.Status,e.Message,new())); }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
