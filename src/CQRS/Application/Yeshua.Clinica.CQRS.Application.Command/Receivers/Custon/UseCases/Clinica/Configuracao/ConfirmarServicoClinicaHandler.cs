using Aplication.Interfaces.Services;
using Clinica.Atendimentos;
using Command.Interfaces;
using Command.UseCase;
using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Domain;
using Dominio.Saga;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
namespace Command.Receivers.UseCase;
public partial class ConfirmarServicoClinicaHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IClinicaWriteRepository _write;
    private readonly IDomainTrackingPolicy _tracking;
    private readonly IServicoWriteRepository _servicos;
    private readonly ISesoesWriteRepository _atendimentos;
    public ConfirmarServicoClinicaHandler(ILogger logger,IExecutionContext context,ISagaStepInvoker invoker,IUnitOfWork uow,IClinicaWriteRepository write,IDomainTrackingPolicy tracking,IServicoWriteRepository servicos,ISesoesWriteRepository atendimentos):base(logger,context)
    {_logger=logger;_executionContext=context;_sagaStepInvoker=invoker;_uow=uow;_write=write;_tracking=tracking;_servicos=servicos;_atendimentos=atendimentos;}
    private DomainOperationContext CreateDomainContext()=>DomainOperationContext.Create(DomainOperation.Registro,DomainEntryPoint.UseCase,"ConfirmarServicoClinica",_executionContext.TenantID,_executionContext.UserId);
    protected partial Task<State<ConfirmarServicoClinicaOutputCommand>> CustomActionHookAsync(State<ConfirmarServicoClinicaOutputCommand> state,ConfirmarServicoClinicaInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            ConfiguracaoInput.ExigirId(comand.ServicoId);
            if(comand.ModeloConsulta is not (1 or 2))throw new AtendimentoException("Escolha um modelo de consulta disponível.");
            if(comand.Valor<0)throw new AtendimentoException("Informe um valor igual ou maior que zero.");
            var hash=ConfiguracaoInput.Hash(comand.ServicoId.ToString(),comand.Nome,comand.Valor.ToString(System.Globalization.CultureInfo.InvariantCulture),comand.ModeloConsulta.ToString());
            _uow.BeginTran();
            var step=_write.ExigirEtapaConfiguracao(comand.SagaId,comand.SagaStepId,ConfiguracaoInicialClinicaSaga.STEP_3,hash);
            var id=comand.ServicoId;
            if(step.InboxId==0)
            {
                if(id==0)
                {
                    var context=CreateDomainContext();
                    var entity=new ServicoFactory(_logger,_tracking).Create(context,null,null,comand.Nome.Trim(),comand.Valor,comand.ModeloConsulta);
                    var valid=ServicoDomainBehavior.Apply(entity,context);
                    if(!valid.IsValid)throw new AtendimentoException(string.Join(" ",valid.Errors));
                    _servicos.Insert(entity);id=entity.Id??0;
                }
                var service=_atendimentos.DefinirServicoHabitual(id);
                if(service.ModeloConsulta!=comand.ModeloConsulta)throw new AtendimentoException("O modelo do serviço mudou. Atualize antes de continuar.",409);
                _write.ExigirConfiguracaoPronta();
            }
            var r=_write.ConfirmarEtapaConfiguracao(step,id,hash);_uow.Commit();
            return Task.FromResult(Success("Etapa confirmada.",new ConfirmarServicoClinicaOutputCommand{Accepted=r.Accepted,SagaId=r.SagaId,SagaStepId=r.SagaStepId,InboxId=r.InboxId,CorrelationId=r.CorrelationId,StepKey=r.StepKey}));
        }
        catch(AtendimentoException e){_uow.Rollback();return Task.FromResult(new State<ConfirmarServicoClinicaOutputCommand>(e.Status,e.Message,new()));}
        catch{_uow.Rollback();throw;}
    }
}
