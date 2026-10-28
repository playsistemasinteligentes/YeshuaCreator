using System.Reflection;
using Aplication.Interfaces.Services;
using Clinica.Atendimentos;
using IQuery.Write;
using Input.Repository.Sesoes;
using RepositoryInterfaces.Patterns.UnitOfWork;
namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Atendimentos;
public class AtendimentoPersistenceTests
{
    private static IExecutionContext Context()=>Fake<IExecutionContext>((m,_)=>m.Name switch { "get_TenantID"=>7,"get_UserId"=>13,"get_ProcessingScope"=>"test",_=>null });
    private static object Property(object value,string name)=>value.GetType().GetProperty(name)!.GetValue(value)!;
    [Fact] public void Scheduling_uses_the_standard_persisted_identity_format_and_current_actor()
    {
        object? args=null;
        var work=Fake<IUnitOfWork>((m,a)=>{if(m.Name=="Query"){args=a![1];return new[]{123};}return null;});
        var repo=new SesoesWriteRepository(work,Fake<ISesoesQueryWrite>((_,_)=>null),Context());
        Assert.Equal(123,repo.AgendarAtendimento(42,DateTime.UtcNow,DateTime.UtcNow.AddHours(1)));
        Assert.True(Guid.TryParseExact((string)Property(args!,"OperationalId"),"N",out _));
        Assert.Equal(7,Property(args!,"Tenant"));Assert.Equal(13,Property(args!,"Actor"));
    }
    [Fact] public void Optimistic_conflict_never_inserts_a_revision_snapshot()
    {
        var writes=0;
        var work=Fake<IUnitOfWork>((m,a)=>{if(m.Name=="Execute"){writes++;return 0;}return null;});
        var repo=new SesoesWriteRepository(work,Fake<ISesoesQueryWrite>((_,_)=>null),Context());
        var error=Assert.Throws<AtendimentoException>(()=>repo.SalvarAtendimento(new(SessaoId:1,Versao:3,Prontuario:"Humano"),true,false));
        Assert.Equal(409,error.Status);Assert.Equal(1,writes);
    }
    [Fact] public void Revision_identity_fits_the_schema_and_contains_only_panel_fields()
    {
        var writes=new List<object>();
        var work=Fake<IUnitOfWork>((m,a)=>{if(m.Name=="Execute"){writes.Add(a![1]!);return 1;}return null;});
        var repo=new SesoesWriteRepository(work,Fake<ISesoesQueryWrite>((_,_)=>null),Context());
        repo.SalvarAtendimento(new(SessaoId:1,Versao:3,Prontuario:"Registro humano",RegistroDocumental:"Fatos",Revisado:true),true,false);
        Assert.Equal(2,writes.Count);var snapshot=writes[1];
        Assert.True(Guid.TryParseExact((string)Property(snapshot,"OperationalId"),"N",out _));
        Assert.Equal(4,Property(snapshot,"Versao"));Assert.Equal(13,Property(snapshot,"Actor"));
        Assert.Contains("Registro humano",(string)Property(snapshot,"Registro"));
        Assert.DoesNotContain("DiagnoosticoHipoteseDiagnoostica",(string)Property(snapshot,"Registro"));
    }
    private static T Fake<T>(Func<MethodInfo,object?[]?,object?> call) where T:class
    {var proxy=DispatchProxy.Create<T,Proxy>();((Proxy)(object)proxy).Call=call;return proxy;}
    public class Proxy:DispatchProxy
    {public Func<MethodInfo,object?[]?,object?> Call=null!;protected override object? Invoke(MethodInfo? method,object?[]? args)=>Call(method!,args);}
}
