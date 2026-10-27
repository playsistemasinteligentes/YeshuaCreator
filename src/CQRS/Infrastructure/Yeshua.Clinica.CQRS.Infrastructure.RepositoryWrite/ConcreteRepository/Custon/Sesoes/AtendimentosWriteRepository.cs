using Clinica.Atendimentos;
using System.Text.Json;
namespace Input.Repository.Sesoes;
public partial class SesoesWriteRepository
{
    private object ActorArgs(int id=0,int versao=0) => new{Id=id,Versao=versao,Tenant=_insightContext.TenantID,Actor=_insightContext.UserId};
    private const string Own = @" s.TenantID=@Tenant AND s.Deleted=0 AND EXISTS(SELECT 1 FROM Profissional f
        WHERE f.Id=s.ProfissionalId AND f.TenantID=@Tenant AND f.Deleted=0 AND f.UsuarioAcessoId=@Actor) ";
    public int AgendarAtendimento(int pacienteId,DateTime inicio,DateTime fim)
    {
        return _UnitOfWork.Query<int>(@"INSERT INTO Sesoes(PacienteId,ProfissionalId,DataInicio,DataFim,StatusAgendamento,StatusProntuario,VersaoAtendimento,TenantID,Deleted,Changed,UserId,OperationalEntityId)
            OUTPUT inserted.Id SELECT p.Id,f.Id,@Inicio,@Fim,1,2,0,@Tenant,0,SYSUTCDATETIME(),@Actor,@OperationalId
            FROM Paciente p,Profissional f WITH(UPDLOCK,HOLDLOCK) WHERE p.Id=@Paciente AND p.TenantID=@Tenant AND p.Deleted=0
            AND f.TenantID=@Tenant AND f.Deleted=0 AND f.UsuarioAcessoId=@Actor
            AND NOT EXISTS(SELECT 1 FROM Sesoes s WITH(UPDLOCK,HOLDLOCK) WHERE s.ProfissionalId=f.Id AND s.TenantID=@Tenant
                AND s.Deleted=0 AND s.StatusAgendamento IN(0,1) AND s.DataInicio<@Fim AND s.DataFim>@Inicio)",
            new{Paciente=pacienteId,Inicio=inicio,Fim=fim,Tenant=_insightContext.TenantID,Actor=_insightContext.UserId,OperationalId=Guid.NewGuid().ToString("D")}).SingleOrDefault()
            is var id && id>0?id:throw new AtendimentoException("Não foi possível agendar. Verifique o paciente, vínculo e conflito de horário.",409);
    }
    public void TransicionarAtendimento(int sessaoId,int versao,string acao)
    {
        var change=acao switch {
            "iniciar"=>"AtendimentoIniciadoEm=SYSUTCDATETIME(),StatusAgendamento=1,StatusProntuario=2",
            "encerrar"=>"AtendimentoEncerradoEm=SYSUTCDATETIME(),StatusAgendamento=2,StatusProntuario=2",
            "cancelar"=>"StatusAgendamento=3,StatusProntuario=0",
            "falta"=>"StatusAgendamento=4,StatusProntuario=1",
            _=>throw new ArgumentOutOfRangeException(nameof(acao)) };
        var count=_UnitOfWork.Execute("UPDATE s SET "+change+",VersaoAtendimento=VersaoAtendimento+1,Changed=SYSUTCDATETIME(),UserId=@Actor FROM Sesoes s WHERE "+Own+" AND s.Id=@Id AND s.VersaoAtendimento=@Versao",ActorArgs(sessaoId,versao));
        if(count!=1) throw new AtendimentoException("O atendimento mudou em outra tela. Atualize antes de continuar.",409);
    }
    public void SalvarAtendimento(RegistroInput r,bool finalizar,bool corrigir)
    {
        var metadata="";
        if(r.IncorporarSagaId>0)
        {
            var valid=_UnitOfWork.ExecuteScalar<int>(@"SELECT COUNT(*) FROM ySaga WHERE Id=@SagaId AND TenantID=@Tenant AND Deleted=0
                AND EntityType='Sesoes' AND EntityId=CONVERT(varchar(20),@Id) AND ProcessingScope=@Scope AND Status=2",
                new{SagaId=r.IncorporarSagaId,Id=r.SessaoId,Tenant=_insightContext.TenantID,Scope=_insightContext.ProcessingScope});
            if(valid!=1)throw new AtendimentoException("Sugestão indisponível para este atendimento.",403);
            metadata=$"saga:{r.IncorporarSagaId};autor:{_insightContext.UserId};utc:{DateTime.UtcNow:O}";
        }
        var count=_UnitOfWork.Execute(@"UPDATE s SET Prontuario=@Prontuario,QueixaPrincipal=@QueixaPrincipal,RegistroDocumental=@RegistroDocumental,
            ObjetivosCurtoPrazo=@ObjetivosCurtoPrazo,ObjetivosLongoPrazo=@ObjetivosLongoPrazo,ExerciciosTarefasSugeridas=@ExerciciosTarefasSugeridas,
            EncaminhamentoOutrosProfissionais=@EncaminhamentoOutrosProfissionais,FrequenciaSugeridaSessooes=@FrequenciaSugeridaSessooes,
            InformacoesRelevantesFuturasConsultas=@InformacoesRelevantesFuturasConsultas,
            SugestoesIncorporadas=CASE WHEN @Origem='' THEN SugestoesIncorporadas ELSE CONCAT(ISNULL(SugestoesIncorporadas,''),CHAR(10),@Origem) END,
            StatusProntuario=CASE WHEN @Finalizar=1 THEN 3 ELSE 2 END,
            RegistroFinalizadoEm=CASE WHEN @Finalizar=1 THEN SYSUTCDATETIME() ELSE RegistroFinalizadoEm END,
            RegistroFinalizadoPorUserId=CASE WHEN @Finalizar=1 THEN @Actor ELSE RegistroFinalizadoPorUserId END,
            VersaoAtendimento=VersaoAtendimento+1,Changed=SYSUTCDATETIME(),UserId=@Actor
            FROM Sesoes s WHERE "+Own+" AND s.Id=@Id AND s.VersaoAtendimento=@Versao",
            new{Id=r.SessaoId,r.Versao,r.Prontuario,r.QueixaPrincipal,r.RegistroDocumental,r.ObjetivosCurtoPrazo,r.ObjetivosLongoPrazo,
                r.ExerciciosTarefasSugeridas,r.EncaminhamentoOutrosProfissionais,r.FrequenciaSugeridaSessooes,r.InformacoesRelevantesFuturasConsultas,
                Finalizar=finalizar,Origem=metadata,Tenant=_insightContext.TenantID,Actor=_insightContext.UserId});
        if(count!=1)throw new AtendimentoException("O registro mudou em outra tela. Copie seu texto e atualize antes de continuar.",409);
        if(finalizar) _UnitOfWork.Execute(@"INSERT INTO RevisaoRegistroSessao(SessaoId,Versao,AutorUserId,RevisadoEm,Motivo,Registro,TenantID,Deleted,Changed,UserId,OperationalEntityId)
            VALUES(@Id,@Versao,@Actor,SYSUTCDATETIME(),@Motivo,@Registro,@Tenant,0,SYSUTCDATETIME(),@Actor,@OperationalId)",
            new{Id=r.SessaoId,Versao=r.Versao+1,Actor=_insightContext.UserId,Tenant=_insightContext.TenantID,Motivo=corrigir?r.Motivo:"Finalização inicial",
                Registro=JsonSerializer.Serialize(r),OperationalId=Guid.NewGuid().ToString("D")});
    }
    public void VincularProfissional(int profissionalId,int usuarioId)
    {
        var count=_UnitOfWork.Execute(@"UPDATE f SET UsuarioAcessoId=@Usuario,Changed=SYSUTCDATETIME(),UserId=@Actor FROM Profissional f WITH(UPDLOCK,HOLDLOCK)
            WHERE f.Id=@Id AND f.TenantID=@Tenant AND f.Deleted=0 AND (f.UsuarioAcessoId IS NULL OR f.UsuarioAcessoId=@Usuario)
            AND EXISTS(SELECT 1 FROM yUser WHERE Id=@Usuario AND TenantID=@Tenant AND Deleted=0)
            AND NOT EXISTS(SELECT 1 FROM Profissional x WITH(UPDLOCK,HOLDLOCK) WHERE x.UsuarioAcessoId=@Usuario AND x.Id<>@Id AND x.TenantID=@Tenant AND x.Deleted=0)",
            new{Id=profissionalId,Usuario=usuarioId,Tenant=_insightContext.TenantID,Actor=_insightContext.UserId});
        if(count!=1)throw new AtendimentoException("Vínculo recusado. Verifique usuário, profissional e vínculos existentes.",409);
    }
}
