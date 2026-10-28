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
public partial class ConfirmarEstabelecimentoClinicaHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IClinicaWriteRepository _write;
    private readonly IDomainTrackingPolicy _tracking;
    
    public ConfirmarEstabelecimentoClinicaHandler(ILogger logger,IExecutionContext context,ISagaStepInvoker invoker,IUnitOfWork uow,IClinicaWriteRepository write,IDomainTrackingPolicy tracking):base(logger,context)
    {_logger=logger;_executionContext=context;_sagaStepInvoker=invoker;_uow=uow;_write=write;_tracking=tracking;}
    private DomainOperationContext CreateDomainContext()=>DomainOperationContext.Create(DomainOperation.Registro,DomainEntryPoint.UseCase,"ConfirmarEstabelecimentoClinica",_executionContext.TenantID,_executionContext.UserId);
    protected partial Task<State<ConfirmarEstabelecimentoClinicaOutputCommand>> CustomActionHookAsync(State<ConfirmarEstabelecimentoClinicaOutputCommand> state,ConfirmarEstabelecimentoClinicaInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            ConfiguracaoInput.ExigirId(comand.ClinicaId);
            if(comand.TipoEstrutura is not (1 or 2))throw new AtendimentoException("Escolha atendimento individual ou clínica com equipe.");
            var hash=ConfiguracaoInput.Hash(comand.ClinicaId.ToString(),comand.Nome,comand.Endereco,comand.Telefone,comand.TipoEstrutura.ToString());
            _uow.BeginTran();
            var step=_write.ExigirEtapaConfiguracao(comand.SagaId,comand.SagaStepId,ConfiguracaoInicialClinicaSaga.STEP_1,hash);
            var id=comand.ClinicaId;
            if(step.InboxId==0)
            {
                if(id==0)
                {
                    var context=CreateDomainContext();
                    var entity=new ClinicaFactory(_logger,_tracking).Create(context,null,comand.Nome.Trim(),comand.Endereco.Trim(),comand.Telefone.Trim(),comand.TipoEstrutura);
                    var valid=ClinicaDomainBehavior.Apply(entity,context);
                    if(!valid.IsValid)throw new AtendimentoException(string.Join(" ",valid.Errors));
                    _write.Insert(entity);id=entity.Id??0;
                }
                _write.SelecionarClinicaInicial(id,comand.TipoEstrutura);
            }
            var r=_write.ConfirmarEtapaConfiguracao(step,id,hash);_uow.Commit();
            return Task.FromResult(Success("Etapa confirmada.",new ConfirmarEstabelecimentoClinicaOutputCommand{Accepted=r.Accepted,SagaId=r.SagaId,SagaStepId=r.SagaStepId,InboxId=r.InboxId,CorrelationId=r.CorrelationId,StepKey=r.StepKey}));
        }
        catch(AtendimentoException e){_uow.Rollback();return Task.FromResult(new State<ConfirmarEstabelecimentoClinicaOutputCommand>(e.Status,e.Message,new()));}
        catch{_uow.Rollback();throw;}
    }
}
