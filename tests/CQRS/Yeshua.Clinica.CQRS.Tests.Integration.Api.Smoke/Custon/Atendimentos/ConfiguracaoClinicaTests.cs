using System.Reflection;
using Aplication.Interfaces.Services;
using Clinica.Atendimentos;
using Command.Patterns;
using Command.Receivers;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using Input.Repository.Clinica;
using IQuery.Write;
using IRepository.Write;
using RepositoryInterfaces.Patterns.UnitOfWork;
using static Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Saga.SessionInsightFlowTests;

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Atendimentos;
public class ConfiguracaoClinicaTests
{
    [Fact] public void Setup_waits_for_each_confirmation_and_finishes_only_after_the_third_fact()
    {
        var saga=new ConfiguracaoInicialClinicaSaga();saga.Start("13","yUser");
        var resolver=new ConfiguracaoInicialClinicaSagaHandlerResolver(new ConfigurarEstabelecimentoHandler(),new VincularProfissionalInicialHandler(),new DefinirServicoInicialHandler());
        var executor=new SagaExecutor(new Shered.Logger.Logger());
        for(var i=1;i<=3;i++)
        {
            executor.ExecuteUntilWait(saga,resolver);
            Assert.Equal(i,saga.GetCurrent().Order);
            Assert.Equal(SagaStepStatus.WaitingResponse,saga.GetCurrent().Status);
            Assert.All(saga.Steps.Where(x=>x.Order<i),x=>Assert.Equal(SagaStepStatus.Completed,x.Status));
            executor.ExecuteUntilWait(saga,resolver);
            Assert.Equal(i,saga.GetCurrent().Order);
            saga.GetCurrent().SetPayload("{\"contract\":\"clinica.configuracao.confirmada.v1\"}");
            saga.GetCurrent().SetPendingApply();executor.ExecuteUntilWait(saga,resolver);
        }
        Assert.Equal(SagaStatus.Completed,saga.Status);
    }
    private static IExecutionContext Context()=>Fake<IExecutionContext>((name,_)=>name switch{"get_TenantID"=>7,"get_UserId"=>13,"get_ProcessingScope"=>"setup-test",_=>null});
    private static object Property(object value,string name)=>value.GetType().GetProperty(name)!.GetValue(value)!;
    private static ClinicaWriteRepository Repository(IUnitOfWork work)=>new(work,Fake<IClinicaQueryWrite>((_,_)=>null),Context(),Fake<IyInboxWriteRepository>((_,_)=>null),new Shered.Logger.Logger());
    [Fact] public void Setup_lookup_is_scoped_to_actor_tenant_and_processing_scope()
    {
        var calls=0;
        var work=Fake<IUnitOfWork>((name,args)=>{
            Assert.Equal("Query",name);calls++;
            Assert.Equal(7,Property(args![1]!,"Tenant"));Assert.Equal(13,Property(args[1]!,"Actor"));Assert.Equal("setup-test",Property(args[1]!,"Scope"));
            return calls==1?new[]{13}:new[]{8};
        });
        Assert.Equal(8,Repository(work).ReservarConfiguracao());Assert.Equal(2,calls);
    }
    [Fact] public void An_unknown_user_cannot_start_a_configuration()
    {
        var work=Fake<IUnitOfWork>((name,_)=>name=="Query"?Array.Empty<int>():null);
        Assert.Equal(403,Assert.Throws<AtendimentoException>(()=>Repository(work).ReservarConfiguracao()).Status);
    }
    [Fact] public void A_step_from_another_actor_or_tenant_is_not_accepted()
    {
        var work=Fake<IUnitOfWork>((name,args)=>{
            Assert.Equal(7,Property(args![1]!,"Tenant"));Assert.Equal(13,Property(args[1]!,"Actor"));
            return Array.Empty<EtapaConfiguracao>();
        });
        Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>Repository(work).ExigirEtapaConfiguracao(88,99,ConfiguracaoInicialClinicaSaga.STEP_1,"hash")).Status);
    }
    [Theory][InlineData(1,3,"other",0,"",false)][InlineData(2,5,"",1,"different",false)][InlineData(2,5,"",1,"hash",true)][InlineData(1,3,"ConfigurarEstabelecimento",0,"",true)]
    public void Out_of_order_and_changed_replays_are_rejected(int sagaStatus,int status,string current,int inbox,string hash,bool accepted)
    {
        var step=new EtapaConfiguracao{SagaStatus=sagaStatus,Status=status,CurrentKey=current,InboxId=inbox,InputHash=hash};
        var work=Fake<IUnitOfWork>((_,_)=>new[]{step});
        if(accepted)Assert.Same(step,Repository(work).ExigirEtapaConfiguracao(8,9,ConfiguracaoInicialClinicaSaga.STEP_1,"hash"));
        else Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>Repository(work).ExigirEtapaConfiguracao(8,9,ConfiguracaoInicialClinicaSaga.STEP_1,"hash")).Status);
    }
    [Fact] public void A_completed_replay_does_not_insert_another_fact_or_invoke_continuation()
    {
        var work=Fake<IUnitOfWork>((_,_)=>throw new InvalidOperationException("Replay must not write"));
        var result=Repository(work).ConfirmarEtapaConfiguracao(new(){SagaId=8,SagaStepId=9,InboxId=10,Status=5},4,"hash");
        Assert.True(result.Accepted);Assert.Equal(0,result.InboxId);
    }
    [Fact] public void The_last_step_requires_exactly_one_professional_and_a_valid_habitual_service()
    {
        var work=Fake<IUnitOfWork>((_,_)=>Array.Empty<int>());
        Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>Repository(work).ExigirConfiguracaoPronta()).Status);
        work=Fake<IUnitOfWork>((_,_)=>new[]{1,2});
        Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>Repository(work).ExigirConfiguracaoPronta()).Status);
        Repository(Fake<IUnitOfWork>((_,_)=>new[]{1})).ExigirConfiguracaoPronta();
    }
}
