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
public partial class ConfirmarProfissionalClinicaHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IClinicaWriteRepository _write;
    private readonly IDomainTrackingPolicy _tracking;
    private readonly IProfissionalWriteRepository _profissionais;
    private readonly ISesoesWriteRepository _atendimentos;
    public ConfirmarProfissionalClinicaHandler(ILogger logger,IExecutionContext context,ISagaStepInvoker invoker,IUnitOfWork uow,IClinicaWriteRepository write,IDomainTrackingPolicy tracking,IProfissionalWriteRepository profissionais,ISesoesWriteRepository atendimentos):base(logger,context)
    {_logger=logger;_executionContext=context;_sagaStepInvoker=invoker;_uow=uow;_write=write;_tracking=tracking;_profissionais=profissionais;_atendimentos=atendimentos;}
    private DomainOperationContext CreateDomainContext()=>DomainOperationContext.Create(DomainOperation.Registro,DomainEntryPoint.UseCase,"ConfirmarProfissionalClinica",_executionContext.TenantID,_executionContext.UserId);
    protected partial Task<State<ConfirmarProfissionalClinicaOutputCommand>> CustomActionHookAsync(State<ConfirmarProfissionalClinicaOutputCommand> state,ConfirmarProfissionalClinicaInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            ConfiguracaoInput.ExigirId(comand.ProfissionalId);
            var hash=ConfiguracaoInput.Hash(comand.ProfissionalId.ToString(),comand.Nome,comand.Telefone);
            _uow.BeginTran();
            var step=_write.ExigirEtapaConfiguracao(comand.SagaId,comand.SagaStepId,ConfiguracaoInicialClinicaSaga.STEP_2,hash);
            var id=comand.ProfissionalId;
            if(step.InboxId==0)
            {
                if(id==0)
                {
                    var context=CreateDomainContext();
                    var entity=new ProfissionalFactory(_logger,_tracking).Create(context,null,comand.Nome.Trim(),null,comand.Telefone.Trim(),null,null);
                    var valid=ProfissionalDomainBehavior.Apply(entity,context);
                    if(!valid.IsValid)throw new AtendimentoException(string.Join(" ",valid.Errors));
                    _profissionais.Insert(entity);id=entity.Id??0;
                }
                _atendimentos.VincularProfissional(id,_executionContext.UserId);
            }
            var r=_write.ConfirmarEtapaConfiguracao(step,id,hash);_uow.Commit();
            return Task.FromResult(Success("Etapa confirmada.",new ConfirmarProfissionalClinicaOutputCommand{Accepted=r.Accepted,SagaId=r.SagaId,SagaStepId=r.SagaStepId,InboxId=r.InboxId,CorrelationId=r.CorrelationId,StepKey=r.StepKey}));
        }
        catch(AtendimentoException e){_uow.Rollback();return Task.FromResult(new State<ConfirmarProfissionalClinicaOutputCommand>(e.Status,e.Message,new()));}
        catch{_uow.Rollback();throw;}
    }
}
