using System.Reflection;
using System.Text.Json;
using Aplication.Interfaces.Services;
using Clinica.Atendimentos;
using Command.Receivers.UseCase;
using Command.UseCase;
using Dominio.Interfaces;
using Input.Repository.PlanoRecorrenciaConsulta;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Atendimentos;

public class RecorrenciaConsultasTests
{
    private static readonly DateTime Now=new(2030,1,1,0,0,0,DateTimeKind.Utc);
    private static PedidoRecorrencia Pedido(int sessao=0,bool futuras=false,string final="2030-02-18") =>
        new(42,5,1,1,"2030-02-04T10:00","2030-02-04T10:50",7,final,sessao,futuras);
    private static List<EscolhaRecorrencia> Escolhas(ResultadoRecorrencia p) => p.Ocorrencias.Select(x=>new EscolhaRecorrencia(x.Ordem,x.DataInicio,x.DataFim,x.Agendar)).ToList();

    [Theory]
    [InlineData(7,"2030-02-18",3)]
    [InlineData(14,"2030-03-04",3)]
    [InlineData(14,"2030-02-17",1)]
    [InlineData(7,"2030-02-04",1)]
    public void Calendar_is_inclusive_and_preserves_Sao_Paulo_wall_time(int days,string end,int count)
    {
        var result=CalendarioConsultas.Expandir("2030-02-04T10:00","2030-02-04T10:50",days,end);
        Assert.Equal(count,result.Count);Assert.Equal(13,result[0].Inicio.Hour);
        Assert.All(result,x=>Assert.Equal("10:00",CalendarioConsultas.TextoLocal(x.Inicio)[11..]));
    }
    [Fact] public void Calendar_uses_zone_rules_across_historical_DST_changes()
    {
        var result=CalendarioConsultas.Expandir("2018-10-29T10:00","2018-10-29T10:50",7,"2018-11-12");
        Assert.Equal(13,result[0].Inicio.Hour);Assert.Equal(12,result[1].Inicio.Hour);
        Assert.All(result,x=>Assert.EndsWith("T10:00",CalendarioConsultas.TextoLocal(x.Inicio)));
    }
    [Theory]
    [InlineData("2030-02-04T10:00Z","2030-02-04T11:00",7,"2030-02-18")]
    [InlineData("2030-02-04T10:00","2030-02-04T09:00",7,"2030-02-18")]
    [InlineData("2030-02-04T10:00","2030-02-04T19:00",7,"2030-02-18")]
    [InlineData("2030-02-04T10:00","2030-02-04T11:00",15,"2030-02-18")]
    [InlineData("2030-02-04T10:00","2030-02-04T11:00",7,"2030-02-03")]
    [InlineData("2018-11-04T00:30","2018-11-04T01:30",7,"2018-11-18")]
    [InlineData("2030-02-04T10:00","2030-02-04T11:00",7,"2040-02-18")]
    public void Calendar_rejects_invalid_intervals_and_unbounded_series(string start,string end,int days,string final) =>
        Assert.Throws<ArgumentException>(()=>CalendarioConsultas.Expandir(start,end,days,final));

    [Fact] public void Preview_reports_conflicts_per_occurrence_without_booking()
    {
        var db=new Database();db.Agenda.Add(new(){Id=8,DataInicio=new(2030,2,11,13,0,0),DataFim=new(2030,2,11,14,0,0)});
        var result=db.Repository.Prever(7,13,Pedido(),Now);
        Assert.Equal(new[]{false,true,false},result.Ocorrencias.Select(x=>x.Conflito));
        Assert.False(result.Confirmado);Assert.Equal(0,db.Inserted);Assert.Equal(0,db.Canceled);
        Assert.DoesNotContain("Prontuario",db.Stored!.Plano);
    }
    [Fact] public void Human_can_move_a_conflict_and_skip_another_occurrence()
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);
        db.Agenda.Add(new(){Id=8,DataInicio=new(2030,2,11,13,0,0),DataFim=new(2030,2,11,14,0,0)});
        var choices=Escolhas(p);choices[1]=new(1,"2030-02-12T10:00","2030-02-12T10:50",true);choices[2]=choices[2] with { Agendar=false };
        var result=db.Repository.Confirmar(7,13,p.PlanoId,true,choices,Now);
        Assert.True(result.Confirmado);Assert.Equal(2,db.Inserted);Assert.False(result.Ocorrencias[2].Agendar);
    }
    [Fact] public void Conflict_that_appears_after_preview_aborts_before_any_session_write()
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);
        db.Agenda.Add(new(){Id=8,DataInicio=new(2030,2,11,13,0,0),DataFim=new(2030,2,11,14,0,0)});
        Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,true,Escolhas(p),Now)).Status);
        Assert.Equal(0,db.Inserted);Assert.Null(db.Stored!.ConfirmacaoHash);
    }
    [Fact] public void Confirmation_detects_conflicts_between_adjusted_occurrences()
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);var choices=Escolhas(p);
        choices[1]=choices[0] with { Ordem=1 };
        Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,true,choices,Now));Assert.Equal(0,db.Inserted);
    }
    [Fact] public void Adjacent_intervals_are_allowed()
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);var choices=Escolhas(p);
        choices[1]=new(1,"2030-02-04T10:50","2030-02-04T11:40",true);
        Assert.True(db.Repository.Confirmar(7,13,p.PlanoId,true,choices,Now).Confirmado);
    }
    [Fact] public void Confirmation_is_durable_and_repeated_payload_returns_same_session_ids()
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);var choices=Escolhas(p);
        var result=db.Repository.Confirmar(7,13,p.PlanoId,true,choices,Now);
        // Simulate another request/repository instance, after the preview expiry.
        var replay=new PlanoRecorrenciaConsultaWriteRepository(db.Work).Confirmar(7,13,p.PlanoId,true,choices.AsEnumerable().Reverse().ToList(),Now.AddHours(2));
        Assert.Equal(result.Ocorrencias,replay.Ocorrencias);Assert.Equal(3,db.Inserted);
        choices[0]=choices[0] with { Agendar=false };
        Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,true,choices,Now)).Status);
        Assert.Equal(3,db.Inserted);
    }
    [Theory]
    [InlineData(false,0)]
    [InlineData(true,31)]
    public void Human_review_and_preview_expiry_are_required(bool review,int minutes)
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);
        Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,review,Escolhas(p),Now.AddMinutes(minutes)));
        Assert.Equal(0,db.Inserted);
    }
    [Theory]
    [InlineData(8,13)]
    [InlineData(7,14)]
    public void Another_tenant_or_actor_cannot_confirm_a_plan(int tenant,int actor)
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);
        Assert.Equal(403,Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(tenant,actor,p.PlanoId,true,Escolhas(p),Now)).Status);
        Assert.Equal(0,db.Inserted);
    }
    [Fact] public void Revoked_professional_link_and_changed_catalog_are_revalidated()
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);db.Authorized=false;
        Assert.Equal(403,Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,true,Escolhas(p),Now)).Status);
        db.Authorized=true;db.CatalogValid=false;
        Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,true,Escolhas(p),Now)).Status);
        Assert.Equal(0,db.Inserted);
    }
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void Missing_or_duplicate_occurrence_decisions_are_rejected(int scenario)
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);var choices=Escolhas(p);
        if(scenario==0)choices.RemoveAt(0);else choices[1]=choices[0];
        Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,true,choices,Now));Assert.Equal(0,db.Inserted);
    }
    [Fact] public void Editing_one_occurrence_does_not_load_or_cancel_its_siblings()
    {
        var db=new Database();db.Originais.Add(Session(21));var p=db.Repository.Prever(7,13,Pedido(21),Now);
        Assert.Single(p.Ocorrencias);Assert.True(db.Repository.Confirmar(7,13,p.PlanoId,true,Escolhas(p),Now).Confirmado);
        Assert.Equal(new[]{21},db.CanceledIds);Assert.Equal(new[]{21},db.UpdatedIds);Assert.Equal(0,db.Inserted);
        Assert.DoesNotContain(db.Sql,x=>x.Contains("s.RecorrenciaId=@Serie"));
    }
    [Fact] public void Shortening_future_series_explicitly_previews_cancellations()
    {
        var db=new Database();db.Originais.AddRange(new[]{Session(21),Session(22),Session(23)});
        var p=db.Repository.Prever(7,13,Pedido(21,true,"2030-02-04"),Now);
        Assert.Equal(new[]{true,false,false},p.Ocorrencias.Select(x=>x.Agendar));
        db.Repository.Confirmar(7,13,p.PlanoId,true,Escolhas(p),Now);
        Assert.Equal(new[]{21,22,23},db.CanceledIds);Assert.Equal(new[]{21},db.UpdatedIds);Assert.Equal(0,db.Inserted);
        Assert.All(db.Sql.Where(x=>x.Contains("FROM Sesoes s WITH")),sql=> {
            Assert.Contains("s.DataInicio>@Agora",sql);Assert.Contains("s.AtendimentoIniciadoEm IS NULL",sql);
            Assert.Contains("s.TenantID=@Tenant",sql);Assert.Contains("s.ProfissionalId=@Profissional",sql);
        });
    }
    [Fact] public void Starting_or_changing_a_future_occurrence_invalidates_the_preview()
    {
        var db=new Database();db.Originais.AddRange(new[]{Session(21),Session(22)});
        var p=db.Repository.Prever(7,13,Pedido(21,true),Now);db.Originais.RemoveAt(1);
        Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,true,Escolhas(p),Now)).Status);
        Assert.Equal(0,db.Canceled);
    }
    [Fact] public void Version_change_invalidates_single_occurrence_preview()
    {
        var db=new Database();db.Originais.Add(Session(21));var p=db.Repository.Prever(7,13,Pedido(21),Now);db.Originais[0].Versao++;
        Assert.Equal(409,Assert.Throws<AtendimentoException>(()=>db.Repository.Confirmar(7,13,p.PlanoId,true,Escolhas(p),Now)).Status);
        Assert.Equal(0,db.Canceled);
    }
    [Fact] public async Task Receiver_rolls_back_all_writes_if_a_later_insert_fails()
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);db.FailInsert=2;
        var context=Fake<IExecutionContext>((m,_)=>m.Name switch { "get_TenantID"=>7,"get_UserId"=>13,_=>m.ReturnType.IsValueType?Activator.CreateInstance(m.ReturnType):null });
        var logger=Fake<ILogger>((m,_)=>m.ReturnType.IsValueType&&m.ReturnType!=typeof(void)?Activator.CreateInstance(m.ReturnType):null);
        var handler=new ExecutarRecorrenciaConsultasHandler(logger,context,db.Repository,db.Work);
        // Receiver uses the real clock; set only this synthetic plan's validity ahead.
        db.Stored!.ExpiraEmUtc=DateTime.UtcNow.AddHours(1);
        var result=await handler.ExecuteAsync(new ExecutarRecorrenciaConsultasInputCommand { Confirmar=true,
            Confirmacao=new(){PlanoId=p.PlanoId,Revisado=true,Ocorrencias=Escolhas(p).Select(x=>new EscolhaRecorrenciaInfo {
                Ordem=x.Ordem,DataInicio=x.DataInicio,DataFim=x.DataFim,Agendar=x.Agendar }).ToList()} });
        Assert.Equal(409,result.StatusCode);Assert.Equal(1,db.Rollbacks);Assert.Equal(0,db.Commits);
        Assert.Equal(0,db.Inserted);Assert.Null(db.Stored!.ConfirmacaoHash);
    }
    [Fact] public async Task Public_commands_use_the_internal_receiver_and_commit_preview_and_confirmation_separately()
    {
        var db=new Database();var context=Context();var logger=Logger();
        var inner=new ExecutarRecorrenciaConsultasHandler(logger,context,db.Repository,db.Work);
        var preview=await new PreverRecorrenciaConsultasHandler(logger,context,inner).ExecuteAsync(new() {
            PacienteId=42,ServicoId=5,ModeloConsulta=1,VersaoModeloConsulta=1,
            DataInicio="2030-02-04T10:00",DataFim="2030-02-04T10:50",IntervaloDias=7,DataFinal="2030-02-18" });
        Assert.Equal(200,preview.StatusCode);Assert.False(preview.Data.Confirmado);Assert.Equal(0,db.Inserted);Assert.Equal(1,db.Commits);
        var command=new ConfirmarRecorrenciaConsultasInputCommand { PlanoId=preview.Data.PlanoId,Revisado=true,
            Ocorrencias=preview.Data.Ocorrencias.Select(x=>new EscolhaRecorrenciaInfo { Ordem=x.Ordem,DataInicio=x.DataInicio,DataFim=x.DataFim,Agendar=x.Agendar }).ToList() };
        var confirm=new ConfirmarRecorrenciaConsultasHandler(logger,context,inner);
        var result=await confirm.ExecuteAsync(command);var replay=await confirm.ExecuteAsync(command);
        Assert.Equal(200,result.StatusCode);Assert.True(result.Data.Confirmado);
        Assert.Equal(result.Data.Ocorrencias.Select(x=>x.SessaoId),replay.Data.Ocorrencias.Select(x=>x.SessaoId));
        Assert.Equal(3,db.Commits);Assert.Equal(0,db.Rollbacks);Assert.Equal(3,db.Inserted);
    }
    [Fact] public async Task Public_command_propagates_authorization_failure_and_rolls_back()
    {
        var db=new Database { Authorized=false };var context=Context();var logger=Logger();
        var inner=new ExecutarRecorrenciaConsultasHandler(logger,context,db.Repository,db.Work);
        var result=await new ConfirmarRecorrenciaConsultasHandler(logger,context,inner).ExecuteAsync(new() {
            PlanoId=new string('a',32),Revisado=true,Ocorrencias=[new(){Ordem=0,Agendar=false}] });
        Assert.Equal(403,result.StatusCode);Assert.Equal(0,db.Commits);Assert.Equal(1,db.Rollbacks);Assert.Equal(0,db.Inserted);
    }
    [Fact] public void Explicitly_skipping_every_occurrence_records_a_replayable_confirmation_without_booking()
    {
        var db=new Database();var p=db.Repository.Prever(7,13,Pedido(),Now);
        var choices=Escolhas(p).Select(x=>x with { Agendar=false }).ToList();
        Assert.True(db.Repository.Confirmar(7,13,p.PlanoId,true,choices,Now).Confirmado);
        Assert.True(db.Repository.Confirmar(7,13,p.PlanoId,true,choices,Now).Confirmado);
        Assert.Equal(0,db.Inserted);Assert.NotNull(db.Stored!.ConfirmacaoHash);
    }
    private static IExecutionContext Context()=>Fake<IExecutionContext>((m,_)=>m.Name switch {
        "get_TenantID"=>7,"get_UserId"=>13,_=>m.ReturnType.IsValueType?Activator.CreateInstance(m.ReturnType):null });
    private static ILogger Logger()=>Fake<ILogger>((m,_)=>m.ReturnType.IsValueType&&m.ReturnType!=typeof(void)?Activator.CreateInstance(m.ReturnType):null);
    private static SessaoRecorrencia Session(int id)=>new(){Id=id,PacienteId=42,Versao=2,RecorrenciaId=new string('a',32),DataInicio=new(2030,2,4+(id-21)*7,13,0,0),DataFim=new(2030,2,4+(id-21)*7,13,50,0)};
    private static T Fake<T>(Func<MethodInfo,object?[]?,object?> call) where T:class
    { var proxy=DispatchProxy.Create<T,Proxy>();((Proxy)(object)proxy).Call=call;return proxy; }
    public class Proxy:DispatchProxy
    { public Func<MethodInfo,object?[]?,object?> Call=null!;protected override object? Invoke(MethodInfo? method,object?[]? args)=>Call(method!,args); }

    // A transactional test double exercises orchestration and failure behavior without SQL/network access.
    // SQL Server locking/isolation still requires a disposable-database integration run before release.
    private sealed class Database
    {
        public IUnitOfWork Work { get; }
        public PlanoRecorrenciaConsultaWriteRepository Repository { get; }
        public PlanoRecorrenciaConsultaWriteRepository.PlanoRow? Stored;
        public List<SessaoRecorrencia> Originais=[];
        public List<SessaoRecorrencia> Agenda=[];
        public List<string> Sql=[];
        public List<int> CanceledIds=[];
        public List<int> UpdatedIds=[];
        public bool Authorized=true,CatalogValid=true;
        public int Inserted,Canceled,FailInsert,Rollbacks,Commits;
        private int _before;
        public Database(){Work=Fake<IUnitOfWork>(Call);Repository=new(Work);}
        private static T Arg<T>(object? args,string name)=>(T)args!.GetType().GetProperty(name)!.GetValue(args)!;
        private object? Call(MethodInfo method,object?[]? args)
        {
            if(method.Name=="BeginTran"){_before=Inserted;return null;}
            if(method.Name=="Commit"){Commits++;return null;}
            if(method.Name=="Rollback"){Rollbacks++;Inserted=_before;return null;}
            var sql=(string)args![0]!;var values=args[1];Sql.Add(sql);
            if(method.Name=="ExecuteScalar")return CatalogValid?1:0;
            if(method.Name=="Query")
            {
                var type=method.GetGenericArguments()[0];
                if(type==typeof(int))
                {
                    if(sql.Contains("SELECT Id FROM Profissional"))return Authorized?new[]{9}:Array.Empty<int>();
                    Inserted++;if(FailInsert==Inserted)throw new AtendimentoException("Falha simulada no INSERT.",409);
                    return new[]{100+Inserted};
                }
                if(type==typeof(SessaoRecorrencia))
                {
                    if(sql.Contains("WHERE s.Id=@Id"))return Originais.Where(x=>x.Id==Arg<int>(values,"Id")).ToArray();
                    if(sql.Contains("s.RecorrenciaId=@Serie"))return Originais.ToArray();
                    return Agenda.ToArray();
                }
                if(type==typeof(PlanoRecorrenciaConsultaWriteRepository.PlanoRow))return
                    Stored is not null&&Arg<int>(values,"Tenant")==7&&Arg<int>(values,"Actor")==13?new[]{Stored}:Array.Empty<PlanoRecorrenciaConsultaWriteRepository.PlanoRow>();
            }
            if(method.Name=="Execute")
            {
                if(sql.Contains("INSERT INTO PlanoRecorrenciaConsulta"))Stored=new(){Plano=Arg<string>(values,"Plano"),ExpiraEmUtc=Arg<DateTime>(values,"Expira")};
                if(sql.Contains("StatusAgendamento=3")){Canceled++;CanceledIds.Add(Arg<int>(values,"Id"));}
                if(sql.Contains("UPDATE s SET DataInicio"))UpdatedIds.Add(Arg<int>(values,"Id"));
                if(sql.Contains("SET ConfirmacaoHash")){Stored!.ConfirmacaoHash=Arg<string>(values,"Hash");Stored.Resultado=Arg<string>(values,"Resultado");}
                return 1;
            }
            throw new InvalidOperationException("Unexpected database call "+method.Name);
        }
    }
}
