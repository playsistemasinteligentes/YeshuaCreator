using Clinica.Atendimentos;
using Command.Receivers.UseCase;
namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Atendimentos;
public class AtendimentoRulesTests
{
    private static RegistroAtendimentoInfo Session() => new(Id:12,Versao:3,StatusAgendamento:1,StatusProntuario:2,AtendimentoIniciadoEm:"2026-10-27T12:00:00Z");
    [Fact] public void Stale_draft_cannot_replace_another_revision()
    { var e=Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(Session(),2,"salvar",new()));Assert.Equal(409,e.Status); }
    [Fact] public void Starting_is_explicit_and_cannot_repeat()
    { Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(Session(),3,"iniciar"));AtendimentoRules.Validate(new(StatusAgendamento:1,StatusProntuario:2),0,"iniciar"); }
    [Fact] public void End_does_not_require_ai_or_clinical_finalization()
    { AtendimentoRules.Validate(Session(),3,"encerrar"); }
    [Fact] public void Finalization_requires_end_review_and_clinical_text()
    {
        var r=new RegistroInput(Prontuario:"Registro humano",RegistroDocumental:"Fatos revisados",Revisado:true);
        Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(Session(),3,"finalizar",r));
        var ended=Session() with { AtendimentoEncerradoEm="2026-10-27T13:00:00Z",StatusAgendamento=2 };
        Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(ended,3,"finalizar",r with { Revisado=false }));
        Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(ended,3,"finalizar",r with { RegistroDocumental="" }));
        AtendimentoRules.Validate(ended,3,"finalizar",r);
    }
    [Fact] public void Finalized_records_reject_save_and_require_explained_reviewed_correction()
    {
        var s=Session() with { AtendimentoEncerradoEm="2026-10-27T13:00:00Z",RegistroFinalizadoEm="2026-10-27T14:00:00Z",StatusProntuario=3 };
        var r=new RegistroInput(Prontuario:"Registro",RegistroDocumental:"Fatos",Revisado:true);
        Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(s,3,"salvar",r));
        Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(s,3,"corrigir",r));
        AtendimentoRules.Validate(s,3,"corrigir",r with { Motivo="Retificação do horário relatado" });
    }
    [Fact] public void Canceled_or_absent_consultations_cannot_start_or_receive_notes()
    { var s=new RegistroAtendimentoInfo(StatusAgendamento:3,StatusProntuario:1);Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(s,0,"iniciar"));Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(s,0,"salvar",new())); }
    [Fact] public void Oversized_notes_are_rejected_before_persistence()
    { Assert.Throws<AtendimentoException>(()=>AtendimentoRules.Validate(Session(),3,"salvar",new(Prontuario:new string('x',8001)))); }
}
