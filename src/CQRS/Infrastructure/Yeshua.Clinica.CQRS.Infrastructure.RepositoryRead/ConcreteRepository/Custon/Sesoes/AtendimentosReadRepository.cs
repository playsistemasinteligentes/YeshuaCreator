using Clinica.Atendimentos;
using System.Text.Json;
namespace Read.Repository;
public partial class SesoesReadRepository
{
    private object PainelParameters(int id = 0) => new { Id = id, Tenant = _executionContext.TenantID, Actor = _executionContext.UserId, Scope = _executionContext.ProcessingScope };
    private const string OwnedSession = @" FROM Sesoes s JOIN Profissional f ON f.Id=s.ProfissionalId AND f.TenantID=s.TenantID AND f.Deleted=0
        JOIN Paciente p ON p.Id=s.PacienteId AND p.TenantID=s.TenantID AND p.Deleted=0
        WHERE s.TenantID=@Tenant AND s.Deleted=0 AND f.UsuarioAcessoId=@Actor ";
    private const string SessionFields = @"SELECT s.Id,s.PacienteId,p.Nome Paciente,
        ISNULL(CONVERT(varchar(33),p.DataNascimento,126),'') DataNascimento,
        CONVERT(varchar(33),s.DataInicio,126)+'Z' DataInicio,CONVERT(varchar(33),s.DataFim,126)+'Z' DataFim,
        ISNULL(s.StatusAgendamento,0) StatusAgendamento,ISNULL(s.StatusProntuario,2) StatusProntuario,
        s.VersaoAtendimento Versao,ISNULL(CONVERT(varchar(33),s.AtendimentoIniciadoEm,126)+'Z','') AtendimentoIniciadoEm,
        ISNULL(CONVERT(varchar(33),s.AtendimentoEncerradoEm,126)+'Z','') AtendimentoEncerradoEm,
        ISNULL(CONVERT(varchar(33),s.RegistroFinalizadoEm,126)+'Z','') RegistroFinalizadoEm,
        ISNULL(s.Prontuario,'') Prontuario,ISNULL(s.QueixaPrincipal,'') QueixaPrincipal,ISNULL(s.RegistroDocumental,'') RegistroDocumental,
        ISNULL(s.ObjetivosCurtoPrazo,'') ObjetivosCurtoPrazo,ISNULL(s.ObjetivosLongoPrazo,'') ObjetivosLongoPrazo,
        ISNULL(s.ExerciciosTarefasSugeridas,'') ExerciciosTarefasSugeridas,ISNULL(s.EncaminhamentoOutrosProfissionais,'') EncaminhamentoOutrosProfissionais,
        ISNULL(s.FrequenciaSugeridaSessooes,'') FrequenciaSugeridaSessooes,
        ISNULL(s.InformacoesRelevantesFuturasConsultas,'') InformacoesRelevantesFuturasConsultas,ISNULL(s.SugestoesIncorporadas,'') SugestoesIncorporadas,
        ISNULL(s.ServicoId,0) ServicoId,ISNULL(s.ServicoNome,'') ServicoNome,
        ISNULL(NULLIF(s.ModeloConsulta,0),1) ModeloConsulta,ISNULL(NULLIF(s.VersaoModeloConsulta,0),1) VersaoModeloConsulta ";
    public RegistroAtendimentoInfo ExigirAtendimento(int sessaoId) =>
        _unitOfWork.Query<RegistroAtendimentoInfo>(SessionFields+OwnedSession+" AND s.Id=@Id",PainelParameters(sessaoId)).SingleOrDefault()
        ?? throw new AtendimentoException("Atendimento indisponível para este profissional.",403);
    public bool PodeGravarAtendimento(int sessaoId)
    {
        var s=ExigirAtendimento(sessaoId);
        return s.AtendimentoIniciadoEm.Length>0 && s.AtendimentoEncerradoEm.Length==0 && s.RegistroFinalizadoEm.Length==0 && s.StatusProntuario!=3;
    }
    public PainelOutput ConsultarPainel(DateTime dia, int sessaoId)
    {
        var profile=_unitOfWork.Query<PerfilAgenda>(@"SELECT f.Id,f.Nome,ISNULL(v.Id,0) ServicoHabitualId,ISNULL(v.Nome,'') ServicoHabitualNome,
            ISNULL(NULLIF(v.ModeloConsulta,0),1) ModeloConsultaHabitual,1 VersaoModeloConsultaHabitual
            FROM Profissional f LEFT JOIN Servico v ON v.Id=f.ServicoHabitualId AND v.TenantID=f.TenantID AND v.Deleted=0
                AND ISNULL(NULLIF(v.ModeloConsulta,0),1) IN(1,2)
            WHERE f.TenantID=@Tenant AND f.UsuarioAcessoId=@Actor AND f.Deleted=0",PainelParameters()).ToList();
        if(profile.Count!=1) throw new AtendimentoException("Seu usuário precisa estar vinculado a um único profissional. Solicite o vínculo ao administrador.",403);
        var args=new { Tenant=_executionContext.TenantID,Actor=_executionContext.UserId,Start=dia,End=dia.AddDays(1) };
        var result=new PainelOutput { ProfissionalId=profile[0].Id,ProfissionalNome=profile[0].Nome,
            ServicoHabitualId=profile[0].ServicoHabitualId,ServicoHabitualNome=profile[0].ServicoHabitualNome,
            ModeloConsultaHabitual=profile[0].ModeloConsultaHabitual,VersaoModeloConsultaHabitual=profile[0].VersaoModeloConsultaHabitual,
            Agenda=_unitOfWork.Query<AgendaAtendimentoInfo>(@"SELECT TOP(200) s.Id,p.Nome Paciente,
            CONVERT(varchar(33),s.DataInicio,126)+'Z' DataInicio,CONVERT(varchar(33),s.DataFim,126)+'Z' DataFim,
            ISNULL(s.StatusAgendamento,0) StatusAgendamento,ISNULL(s.StatusProntuario,2) StatusProntuario,
            CAST(CASE WHEN s.StatusAgendamento=2 AND s.RegistroFinalizadoEm IS NULL AND s.StatusProntuario=2 THEN 1 ELSE 0 END AS bit) Pendente"
            +OwnedSession+@" AND ((s.DataInicio>=@Start AND s.DataInicio<@End) OR
            (s.StatusAgendamento=2 AND s.RegistroFinalizadoEm IS NULL AND s.StatusProntuario=2)) ORDER BY s.DataInicio",args).ToList(),
            Pacientes=_unitOfWork.Query<PacienteAtendimentoInfo>("SELECT TOP(500) Id,Nome FROM Paciente WHERE TenantID=@Tenant AND Deleted=0 ORDER BY Nome",PainelParameters()).ToList() };
        if(sessaoId==0) return result;
        var current=ExigirAtendimento(sessaoId);result.Atual.Add(current);
        result.Historico=_unitOfWork.Query<RegistroAtendimentoInfo>(SessionFields+OwnedSession+@" AND s.PacienteId=@Patient AND s.Id<>@Id
            AND s.DataInicio<@Before AND s.StatusAgendamento=2 ORDER BY s.DataInicio DESC,s.Id DESC OFFSET 0 ROWS FETCH NEXT 50 ROWS ONLY",
            new { Id=sessaoId,Patient=current.PacienteId,Before=DateTime.Parse(current.DataInicio,System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.AdjustToUniversal),Tenant=_executionContext.TenantID,Actor=_executionContext.UserId }).ToList();
        var rows=_unitOfWork.Query<AudioRow>(@"SELECT g.Id SagaId,g.Status,CONVERT(varchar(33),u.CreatedAt,126)+'Z' Data,
            CASE WHEN t.Status=5 THEN t.Payload ELSE NULL END Transcricao,CASE WHEN r.Status=5 THEN r.Payload ELSE NULL END Resumo,
            CASE WHEN t.Status=6 THEN t.Id WHEN r.Status=6 THEN r.Id ELSE 0 END StepFalhouId
            FROM ySaga g JOIN yFileUpload u ON u.OperationalEntityId=REPLACE(g.CorrelationId,'-','') AND u.TenantID=g.TenantID AND u.Deleted=0
            LEFT JOIN ySagaStep t ON t.SagaId=g.Id AND t.StepKey='AudioTranscriptRequested' AND t.TenantID=g.TenantID AND t.Deleted=0
            LEFT JOIN ySagaStep r ON r.SagaId=g.Id AND r.StepKey='ReportEndProntuaryRequested' AND r.TenantID=g.TenantID AND r.Deleted=0
            WHERE g.TenantID=@Tenant AND g.Deleted=0 AND g.EntityType='Sesoes' AND g.EntityId=CONVERT(varchar(20),@Id)
              AND g.ProcessingScope=@Scope ORDER BY g.Id DESC",PainelParameters(sessaoId));
        foreach(var row in rows)
        {
            string text="",pront="",queixa="",registro="";
            try { if(!string.IsNullOrWhiteSpace(row.Transcricao)) { using var d=JsonDocument.Parse(row.Transcricao);var e=Result(d.RootElement);if(e.TryGetProperty("text",out var v))text=v.GetString()??""; } } catch(JsonException) { }
            try { if(!string.IsNullOrWhiteSpace(row.Resumo)) { using var d=JsonDocument.Parse(row.Resumo);var e=Result(d.RootElement);if(e.TryGetProperty("fields",out var fields))foreach(var f in fields.EnumerateArray()) { var v=f.GetProperty("value").GetString()??"";switch(f.GetProperty("key").GetString()){case "Prontuario":pront=v;break;case "QueixaPrincipal":queixa=v;break;case "RegistroDocumental":registro=v;break;} } } } catch(JsonException) { }
            result.Audios.Add(new(row.SagaId,row.Data,row.Status==2?"Concluído":row.Status==3?"Falha":"Processando",text,pront,queixa,registro,row.StepFalhouId));
        }
        return result;
    }
    public IReadOnlyList<ServicoAgendamentoInfo> ConsultarServicosAgendamento()
    {
        var result=_unitOfWork.Query<ServicoAgendamentoInfo>(@"SELECT TOP(501) v.Id,v.Nome,
            ISNULL(NULLIF(v.ModeloConsulta,0),1) ModeloConsulta,1 VersaoModeloConsulta
            FROM Servico v WHERE v.TenantID=@Tenant AND v.Deleted=0 AND ISNULL(NULLIF(v.ModeloConsulta,0),1) IN(1,2)
            AND EXISTS(SELECT 1 FROM Profissional f WHERE f.TenantID=@Tenant AND f.UsuarioAcessoId=@Actor AND f.Deleted=0)
            ORDER BY v.Nome,v.Id",PainelParameters()).ToList();
        if(result.Count>500)throw new AtendimentoException("O catálogo de serviços excedeu o limite desta agenda.",409);
        return result;
    }
    private sealed class PerfilAgenda
    {
        public int Id {get;set;} public string Nome {get;set;}="";
        public int ServicoHabitualId {get;set;} public string ServicoHabitualNome {get;set;}="";
        public int ModeloConsultaHabitual {get;set;} public int VersaoModeloConsultaHabitual {get;set;}
    }
    private static JsonElement Result(JsonElement root) => root.TryGetProperty("result",out var result)?result:root;
    private sealed class AudioRow { public int SagaId {get;set;} public int Status {get;set;} public string Data {get;set;}="";public string? Transcricao {get;set;}public string? Resumo {get;set;} public int StepFalhouId {get;set;} }
    // O CRUD legado continua consultável, mas somente pelo profissional vinculado.
    partial void TryGetSesoesCustom(Command.Read.SesoesReadCommand command, ref RepositoryInterfaces.Patterns.Repository.DataPagination<Repositorio.Outputs.SesoesDTO> result, ref bool handled)
    {
        var page=Math.Max(1,command.Paginacao?.Page??1);var size=Math.Clamp(command.Paginacao?.PageSize??20,1,100);
        var args=new{Tenant=_executionContext.TenantID,Actor=_executionContext.UserId,Id=command.Id,Patient=command.PacienteId,Professional=command.ProfissionalId,
            Appointment=command.StatusAgendamento,Chart=command.StatusProntuario,Offset=(page-1)*size,Size=size};
        var filter=OwnedSession+" AND (@Id IS NULL OR s.Id=@Id) AND (@Patient IS NULL OR s.PacienteId=@Patient) AND (@Professional IS NULL OR s.ProfissionalId=@Professional)"
            +" AND (@Appointment IS NULL OR s.StatusAgendamento=@Appointment) AND (@Chart IS NULL OR s.StatusProntuario=@Chart)";
        var rows=_unitOfWork.Query<Repositorio.Outputs.SesoesDTO>("SELECT s.*"+filter+" ORDER BY s.Id OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY",args).ToList();
        int? total=command.Paginacao?.PageWhithCount==true?_unitOfWork.ExecuteScalar<int>("SELECT COUNT(*)"+filter,args):null;
        result=new(rows,page,size,total);handled=true;
    }
}
