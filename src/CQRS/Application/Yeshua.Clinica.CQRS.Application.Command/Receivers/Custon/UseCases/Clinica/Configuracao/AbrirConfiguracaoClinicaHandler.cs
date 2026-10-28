using Aplication.Interfaces.Services;
using Clinica.Atendimentos;
using Command.Interfaces;
using Command.Receivers.Migration.Saga;
using Command.UseCase;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
namespace Command.Receivers.UseCase;
public partial class AbrirConfiguracaoClinicaHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IClinicaWriteRepository _write;
    private readonly IClinicaReadRepository _read;
    private readonly IySagaWriteRepository _sagas;
    private readonly IySagaReadRepository _sagaRead;
    private readonly SagaResolverRegistry _registry;
    private readonly ISagaExecutor _executor;
    public AbrirConfiguracaoClinicaHandler(ILogger logger,IExecutionContext context,IUnitOfWork uow,IClinicaWriteRepository write,
        IClinicaReadRepository read,IySagaWriteRepository sagas,IySagaReadRepository sagaRead,SagaResolverRegistry registry,ISagaExecutor executor):base(logger,context)
    {_logger=logger;_executionContext=context;_uow=uow;_write=write;_read=read;_sagas=sagas;_sagaRead=sagaRead;_registry=registry;_executor=executor;}
    protected partial Task<State<AbrirConfiguracaoClinicaOutputCommand>> CustomActionHookAsync(State<AbrirConfiguracaoClinicaOutputCommand> state,AbrirConfiguracaoClinicaInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            _uow.BeginTran();
            var id=_write.ReservarConfiguracao();
            var saved=id>0?_sagaRead.GetByIdWithSteps(id):null;
            if(saved?.status==2&&!_read.ConfiguracaoEstaPronta())saved=null;
            SagaBase saga;
            if(saved!=null)saga=_registry.Map(saved);
            else
            {
                saga=new ConfiguracaoInicialClinicaSaga();
                saga.Start(_executionContext.UserId.ToString(),"yUser");
                if(_executionContext.TryGetOperationalIdentity(out var identity))
                    saga.SetOperationalIdentity(identity.RootOperationId,identity.OperationId,identity.ExecutionId,identity.CausationId);
                _executor.ExecuteUntilWait(saga,_registry.Resolve(saga),10);
                _sagas.Save(saga);
            }
            _uow.Commit();
            var options=_read.ConsultarOpcoesConfiguracao();
            var current=saga.GetCurrent();
            return Task.FromResult(Success("Configuração inicial da clínica.",new AbrirConfiguracaoClinicaOutputCommand {
                SagaId=saga.Id,SagaStepId=current?.Id??0,Etapa=current?.Order??4,Concluida=saga.Status==SagaStatus.Completed,
                Clinicas=options.Clinicas.Select(x=>new Command.UseCase.ClinicaInicialInfo{Id=x.Id,Nome=x.Nome,Endereco=x.Endereco,Telefone=x.Telefone,TipoEstrutura=x.TipoEstrutura}).ToList(),
                Profissionais=options.Profissionais.Select(x=>new Command.UseCase.ProfissionalInicialInfo{Id=x.Id,Nome=x.Nome,Telefone=x.Telefone,Vinculado=x.Vinculado}).ToList(),
                Servicos=options.Servicos.Select(x=>new Command.UseCase.ServicoInicialInfo{Id=x.Id,Nome=x.Nome,Valor=x.Valor,ModeloConsulta=x.ModeloConsulta}).ToList()
            }));
        }
        catch(AtendimentoException e){_uow.Rollback();return Task.FromResult(new State<AbrirConfiguracaoClinicaOutputCommand>(e.Status,e.Message,new()));}
        catch{_uow.Rollback();throw;}
    }
}
