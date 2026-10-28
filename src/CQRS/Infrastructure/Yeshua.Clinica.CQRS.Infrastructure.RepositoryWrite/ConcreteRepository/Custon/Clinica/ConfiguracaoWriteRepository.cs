using Aplication.Interfaces.Services;
using Clinica.Atendimentos;
using Dominio.Entitys;
using Dominio.Interfaces;
using IQuery.Write;
using IRepository.Write;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Text.Json;

namespace Input.Repository.Clinica;
public partial class ClinicaWriteRepository
{
    private readonly IExecutionContext _configContext;
    private readonly IyInboxWriteRepository _configInbox;
    private readonly ILogger _configLogger;
    public ClinicaWriteRepository(IUnitOfWork uow,IClinicaQueryWrite query,IExecutionContext context,IyInboxWriteRepository inbox,ILogger logger)
    { _UnitOfWork=uow;_query=query;_configContext=context;_configInbox=inbox;_configLogger=logger; }
    public int ReservarConfiguracao()
    {
        var actor=_UnitOfWork.Query<int>(@"SELECT Id FROM yUser WITH(UPDLOCK,HOLDLOCK)
            WHERE Id=@Actor AND TenantID=@Tenant AND Deleted=0",ConfigArgs()).SingleOrDefault();
        if(actor<=0)throw new AtendimentoException("Entre novamente para configurar sua clínica.",403);
        return _UnitOfWork.Query<int>(@"SELECT TOP(1) Id FROM ySaga WITH(UPDLOCK,HOLDLOCK)
            WHERE TenantID=@Tenant AND EntityType='yUser' AND EntityId=CONVERT(varchar(20),@Actor)
            AND Type='ConfiguracaoInicialClinicaSaga' AND ProcessingScope=@Scope AND Deleted=0 AND Status IN(1,2) ORDER BY Id DESC",ConfigArgs()).SingleOrDefault();
    }
    private object ConfigArgs()=>new{Tenant=_configContext.TenantID,Actor=_configContext.UserId,Scope=_configContext.ProcessingScope};
    public EtapaConfiguracao ExigirEtapaConfiguracao(int sagaId,int sagaStepId,string stepKey,string inputHash)
    {
        var args=new{SagaId=sagaId,StepId=sagaStepId,Key=stepKey,Tenant=_configContext.TenantID,Actor=_configContext.UserId,Scope=_configContext.ProcessingScope};
        var state=_UnitOfWork.Query<EtapaConfiguracao>(@"SELECT g.Id SagaId,s.Id SagaStepId,g.CorrelationId,s.CorrelationId StepCorrelationId,s.StepKey,
            s.Status,g.Status SagaStatus,ISNULL(g.KeyCurrentStep,'') CurrentKey,ISNULL(i.Id,0) InboxId,ISNULL(JSON_VALUE(i.Payload,'$.inputHash'),'') InputHash
            FROM ySaga g WITH(UPDLOCK,HOLDLOCK) JOIN ySagaStep s WITH(UPDLOCK,HOLDLOCK) ON s.SagaId=g.Id AND s.TenantID=g.TenantID AND s.Deleted=0
            OUTER APPLY(SELECT TOP(1) Id,Payload FROM yInbox WHERE SagaId=g.Id AND SagaStepId=s.Id AND TenantID=g.TenantID
                AND ProcessingScope=@Scope AND Deleted=0 AND Type='clinica.configuracao.confirmada.v1' ORDER BY Id) i
            WHERE g.Id=@SagaId AND s.Id=@StepId AND s.StepKey=@Key AND g.TenantID=@Tenant AND g.Deleted=0
                AND g.Type='ConfiguracaoInicialClinicaSaga' AND g.EntityType='yUser' AND g.EntityId=CONVERT(varchar(20),@Actor)
                AND g.ProcessingScope=@Scope AND (g.LockedBy IS NULL OR g.LockedAt<DATEADD(minute,-5,SYSUTCDATETIME()))",args).SingleOrDefault()
            ??throw new AtendimentoException("Configuração indisponível ou em processamento. Use Atualizar para retomar.",409);
        if(state.InboxId>0)
        {
            if(state.InputHash!=inputHash)throw new AtendimentoException("Esta etapa já foi confirmada com outros dados. Atualize para retomar.",409);
            return state;
        }
        if(state.SagaStatus!=1||state.CurrentKey!=stepKey||state.Status!=(int)Dominio.Patterns.Saga.SagaStepStatus.WaitingResponse)
            throw new AtendimentoException("Confirme a etapa atual antes de continuar. Use Atualizar para retomar.",409);
        return state;
    }
    public void SelecionarClinicaInicial(int id,int tipoEstrutura)
    {
        var changed=_UnitOfWork.Execute(@"UPDATE Clinica SET TipoEstrutura=@Estrutura,Changed=SYSUTCDATETIME(),UserId=@Actor
            WHERE Id=@Id AND TenantID=@Tenant AND Deleted=0",new{Id=id,Estrutura=tipoEstrutura,Tenant=_configContext.TenantID,Actor=_configContext.UserId});
        if(changed!=1)throw new AtendimentoException("A clínica escolhida não está disponível neste tenant.",409);
    }
    public void ExigirConfiguracaoPronta()
    {
        var ok=_UnitOfWork.Query<int>(@"SELECT f.Id FROM Profissional f WITH(UPDLOCK,HOLDLOCK)
            JOIN Servico v WITH(HOLDLOCK) ON v.Id=f.ServicoHabitualId AND v.TenantID=f.TenantID AND v.Deleted=0
            WHERE f.TenantID=@Tenant AND f.UsuarioAcessoId=@Actor AND f.Deleted=0 AND ISNULL(NULLIF(v.ModeloConsulta,0),1) IN(1,2)
            AND EXISTS(SELECT 1 FROM Clinica WHERE TenantID=@Tenant AND Deleted=0)",ConfigArgs()).ToList();
        if(ok.Count!=1)throw new AtendimentoException("Confira a clínica, o vínculo do profissional e o serviço habitual antes de concluir.",409);
    }
    public ConfiguracaoAceita ConfirmarEtapaConfiguracao(EtapaConfiguracao etapa,int cadastroId,string inputHash)
    {
        if(etapa.InboxId>0)return new(true,etapa.SagaId,etapa.SagaStepId,etapa.Status==5?0:etapa.InboxId,etapa.CorrelationId,etapa.StepKey);
        var payload=JsonSerializer.Serialize(new{contract="clinica.configuracao.confirmada.v1",stepKey=etapa.StepKey,cadastroId,inputHash});
        var inbox=new yInboxFactory(_configLogger).Create(null,$"clinica-config:{etapa.SagaStepId}","clinica.configuracao.confirmada.v1",
            "yUser",_configContext.UserId.ToString(),etapa.StepCorrelationId,payload,0,DateTime.UtcNow,0,null,null,DateTime.UtcNow,etapa.SagaId,etapa.SagaStepId);
        if(_configContext.TryGetOperationalIdentity(out var identity))
        {inbox.RootOperationId=identity.RootOperationId;inbox.OperationId=identity.OperationId;inbox.ExecutionId=identity.ExecutionId;inbox.CausationId=identity.CausationId;}
        _configInbox.Insert(inbox);
        return new(true,etapa.SagaId,etapa.SagaStepId,inbox.Id??0,etapa.CorrelationId,etapa.StepKey);
    }
}
