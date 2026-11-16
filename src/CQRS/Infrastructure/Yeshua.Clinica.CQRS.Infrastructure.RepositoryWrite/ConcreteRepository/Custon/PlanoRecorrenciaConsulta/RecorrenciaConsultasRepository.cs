using Clinica.Atendimentos;
using Clinica.Modelos;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Input.Repository.PlanoRecorrenciaConsulta;

public partial class PlanoRecorrenciaConsultaWriteRepository
{
    private int TravarProfissional(int tenant, int actor)
    {
        if (tenant <= 0 || actor <= 0) throw new AtendimentoException("Identidade indisponível.", 403);
        var ids = _UnitOfWork.Query<int>(@"SELECT Id FROM Profissional WITH(UPDLOCK,HOLDLOCK)
            WHERE TenantID=@Tenant AND UsuarioAcessoId=@Actor AND Deleted=0", new { Tenant=tenant, Actor=actor }).ToList();
        if (ids.Count != 1) throw new AtendimentoException("É necessário um único profissional vinculado ao usuário.", 403);
        return ids[0];
    }
    private void ValidarCatalogo(int tenant, PedidoRecorrencia pedido)
    {
        if (!ModelosConsulta.Suporta(pedido.ModeloConsulta, pedido.VersaoModeloConsulta))
            throw new AtendimentoException("Selecione um serviço e modelo disponíveis.");
        var count = _UnitOfWork.ExecuteScalar<int>(@"SELECT COUNT(*) FROM Paciente p WITH(HOLDLOCK), Servico v WITH(HOLDLOCK)
            WHERE p.Id=@Paciente AND p.TenantID=@Tenant AND p.Deleted=0
            AND v.Id=@Servico AND v.TenantID=@Tenant AND v.Deleted=0
            AND ISNULL(NULLIF(v.ModeloConsulta,0),1)=@Modelo", new { Tenant=tenant, Paciente=pedido.PacienteId, Servico=pedido.ServicoId, Modelo=pedido.ModeloConsulta });
        if (count != 1) throw new AtendimentoException("Paciente ou serviço indisponível. Atualize a prévia.", 409);
    }
    private const string Editavel = @" AND s.Deleted=0 AND s.StatusAgendamento IN(0,1) AND s.DataInicio>@Agora
        AND s.AtendimentoIniciadoEm IS NULL AND s.AtendimentoEncerradoEm IS NULL AND s.RegistroFinalizadoEm IS NULL AND ISNULL(s.StatusProntuario,2)<>3 ";
    private List<SessaoRecorrencia> CarregarOriginais(int tenant, int profissional, PedidoRecorrencia pedido, DateTime agora)
    {
        if (pedido.SessaoId == 0)
        {
            if (pedido.SerieFutura) throw new AtendimentoException("Selecione uma ocorrência da série.");
            return [];
        }
        var anchor = _UnitOfWork.Query<SessaoRecorrencia>(@"SELECT s.Id,s.PacienteId,s.VersaoAtendimento Versao,
            ISNULL(s.RecorrenciaId,'') RecorrenciaId,s.DataInicio,s.DataFim FROM Sesoes s WITH(UPDLOCK,HOLDLOCK)
            WHERE s.Id=@Id AND s.TenantID=@Tenant AND s.ProfissionalId=@Profissional" + Editavel,
            new { Id=pedido.SessaoId, Tenant=tenant, Profissional=profissional, Agora=agora }).SingleOrDefault()
            ?? throw new AtendimentoException("A consulta está indisponível, passada ou já iniciada. Atualize a prévia.", 409);
        if (anchor.PacienteId != pedido.PacienteId) throw new AtendimentoException("A edição preserva o paciente da consulta.", 409);
        if (!pedido.SerieFutura) return [anchor];
        if (anchor.RecorrenciaId.Length == 0) throw new AtendimentoException("A consulta não pertence a uma série.");
        var rows = _UnitOfWork.Query<SessaoRecorrencia>(@"SELECT TOP(261) s.Id,s.PacienteId,s.VersaoAtendimento Versao,
            ISNULL(s.RecorrenciaId,'') RecorrenciaId,s.DataInicio,s.DataFim FROM Sesoes s WITH(UPDLOCK,HOLDLOCK)
            WHERE s.TenantID=@Tenant AND s.ProfissionalId=@Profissional AND s.RecorrenciaId=@Serie AND s.DataInicio>=@Inicio" + Editavel + " ORDER BY s.DataInicio,s.Id",
            new { Tenant=tenant, Profissional=profissional, Serie=anchor.RecorrenciaId, Inicio=anchor.DataInicio, Agora=agora }).ToList();
        if (rows.Count > CalendarioConsultas.MaximoOcorrencias) throw new AtendimentoException("A série excede o limite da prévia.");
        return rows;
    }
    private List<SessaoRecorrencia> Agenda(int tenant, int profissional, DateTime inicio, DateTime fim) => _UnitOfWork.Query<SessaoRecorrencia>(@"SELECT Id,DataInicio,DataFim FROM Sesoes WITH(UPDLOCK,HOLDLOCK)
        WHERE TenantID=@Tenant AND ProfissionalId=@Profissional AND Deleted=0 AND StatusAgendamento IN(0,1) AND DataInicio<@Fim AND DataFim>@Inicio",
        new { Tenant=tenant, Profissional=profissional, Inicio=inicio, Fim=fim }).ToList();

    public ResultadoRecorrencia Prever(int tenant, int actor, PedidoRecorrencia pedido, DateTime agoraUtc)
    {
        var profissional = TravarProfissional(tenant, actor);
        ValidarCatalogo(tenant, pedido);
        var originais = CarregarOriginais(tenant, profissional, pedido, agoraUtc);
        var horarios = CalendarioConsultas.Expandir(pedido.DataInicio, pedido.DataFim,
            pedido.SessaoId > 0 && !pedido.SerieFutura ? 7 : pedido.IntervaloDias,
            pedido.SessaoId > 0 && !pedido.SerieFutura ? CalendarioConsultas.Local(pedido.DataInicio).ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : pedido.DataFinal);
        if (horarios.Any(h => h.Inicio <= agoraUtc)) throw new AtendimentoException("Agende somente consultas futuras.");
        var id = Guid.NewGuid().ToString("N");
        var plano = new PlanoConsultas { Id=id, SerieId=originais.FirstOrDefault()?.RecorrenciaId is { Length: >0 } serie ? serie : id,
            ProfissionalId=profissional, Pedido=pedido, Originais=originais };
        var ignorar = originais.Select(s => s.Id).ToHashSet();
        var agenda = Agenda(tenant, profissional, horarios.Min(x=>x.Inicio), horarios.Max(x=>x.Fim)).Where(s => !ignorar.Contains(s.Id)).ToList();
        for (var i = 0; i < Math.Max(horarios.Count, originais.Count); i++)
        {
            var incluir = i < horarios.Count;
            var inicio = incluir ? horarios[i].Inicio : originais[i].DataInicio;
            var fim = incluir ? horarios[i].Fim : originais[i].DataFim;
            plano.Ocorrencias.Add(new(i, i < originais.Count ? originais[i].Id : 0,
                CalendarioConsultas.TextoLocal(inicio), CalendarioConsultas.TextoLocal(fim), incluir,
                incluir && agenda.Any(s => CalendarioConsultas.Sobrepoe(inicio, fim, s.DataInicio, s.DataFim))));
        }
        _UnitOfWork.Execute(@"INSERT INTO PlanoRecorrenciaConsulta(Id,ProfissionalId,Plano,ExpiraEmUtc,TenantID,UserId,Deleted,Changed,OperationalEntityId)
            VALUES(@Id,@Profissional,@Plano,@Expira,@Tenant,@Actor,0,SYSUTCDATETIME(),@Id)",
            new { Id=id, Profissional=profissional, Plano=JsonSerializer.Serialize(plano, RecorrenciaJsonContext.Default.PlanoConsultas), Expira=agoraUtc.AddMinutes(30), Tenant=tenant, Actor=actor });
        return new(id, false, plano.Ocorrencias);
    }
    public ResultadoRecorrencia Confirmar(int tenant, int actor, string planoId, bool revisado, IReadOnlyList<EscolhaRecorrencia> escolhas, DateTime agoraUtc)
    {
        if (!revisado) throw new AtendimentoException("Revise as ocorrências e confirme explicitamente.");
        if (!Guid.TryParseExact(planoId, "N", out _) || escolhas is null || escolhas.Any(x => x is null) || escolhas.Count is <1 or >CalendarioConsultas.MaximoOcorrencias)
            throw new AtendimentoException("Confirmação inválida.");
        var profissional = TravarProfissional(tenant, actor);
        var row = _UnitOfWork.Query<PlanoRow>(@"SELECT Plano,ConfirmacaoHash,Resultado,ExpiraEmUtc FROM PlanoRecorrenciaConsulta WITH(UPDLOCK,HOLDLOCK)
            WHERE Id=@Id AND TenantID=@Tenant AND UserId=@Actor AND ProfissionalId=@Profissional AND Deleted=0",
            new { Id=planoId, Tenant=tenant, Actor=actor, Profissional=profissional }).SingleOrDefault()
            ?? throw new AtendimentoException("Prévia indisponível para este usuário.", 403);
        var ordenadas = escolhas.OrderBy(x => x.Ordem).ToList();
        var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(ordenadas, RecorrenciaJsonContext.Default.ListEscolhaRecorrencia))));
        if (!string.IsNullOrEmpty(row.ConfirmacaoHash))
        {
            if (row.ConfirmacaoHash != hash) throw new AtendimentoException("Esta prévia já foi confirmada com outras escolhas.", 409);
            return JsonSerializer.Deserialize(row.Resultado!, RecorrenciaJsonContext.Default.ResultadoRecorrencia)!;
        }
        if (row.ExpiraEmUtc <= agoraUtc) throw new AtendimentoException("A prévia expirou. Gere outra antes de confirmar.", 409);
        var plano = JsonSerializer.Deserialize(row.Plano, RecorrenciaJsonContext.Default.PlanoConsultas)!;
        ValidarCatalogo(tenant, plano.Pedido);
        var atuais = CarregarOriginais(tenant, profissional, plano.Pedido, agoraUtc);
        if (!atuais.Select(x => (x.Id,x.Versao)).SequenceEqual(plano.Originais.Select(x => (x.Id,x.Versao))))
            throw new AtendimentoException("A série mudou desde a prévia. Atualize antes de confirmar.", 409);
        if (ordenadas.Count != plano.Ocorrencias.Count || !ordenadas.Select(x => x.Ordem).SequenceEqual(Enumerable.Range(0, plano.Ocorrencias.Count)))
            throw new AtendimentoException("Escolha uma decisão para cada ocorrência, sem repetições.");
        var ignorar = plano.Originais.Select(x => x.Id).ToHashSet();
        var incluir = new List<(int Ordem, DateTime Inicio, DateTime Fim)>();
        foreach (var escolha in ordenadas.Where(x => x.Agendar))
        {
            var inicio = CalendarioConsultas.Utc(escolha.DataInicio); var fim = CalendarioConsultas.Utc(escolha.DataFim);
            if (inicio <= agoraUtc || fim <= inicio || fim-inicio > TimeSpan.FromHours(8)) throw new AtendimentoException("Informe horários futuros válidos de até oito horas.");
            if (incluir.Any(x => CalendarioConsultas.Sobrepoe(inicio,fim,x.Inicio,x.Fim)))
                throw new AtendimentoException($"Conflito na ocorrência {escolha.Ordem+1}. Altere o horário ou escolha não agendar.", 409);
            incluir.Add((escolha.Ordem,inicio,fim));
        }
        if (incluir.Count > 0)
        {
            var agenda = Agenda(tenant, profissional, incluir.Min(x=>x.Inicio), incluir.Max(x=>x.Fim)).Where(x => !ignorar.Contains(x.Id)).ToList();
            foreach (var horario in incluir)
                if (agenda.Any(x => CalendarioConsultas.Sobrepoe(horario.Inicio,horario.Fim,x.DataInicio,x.DataFim)))
                    throw new AtendimentoException($"Conflito na ocorrência {horario.Ordem+1}. Altere o horário ou escolha não agendar.", 409);
        }
        // Cancellation, all inserts/updates and the durable receipt share the receiver transaction.
        foreach (var original in plano.Originais)
        {
            var count = _UnitOfWork.Execute(@"UPDATE s SET StatusAgendamento=3,StatusProntuario=0,VersaoAtendimento=VersaoAtendimento+1,
                Changed=SYSUTCDATETIME(),UserId=@Actor FROM Sesoes s WHERE s.Id=@Id AND s.TenantID=@Tenant AND s.ProfissionalId=@Profissional
                AND s.VersaoAtendimento=@Versao" + Editavel,
                new { original.Id, original.Versao, Tenant=tenant, Actor=actor, Profissional=profissional, Agora=agoraUtc });
            if (count != 1) throw new AtendimentoException("Uma consulta mudou. Nenhuma alteração foi confirmada.", 409);
        }
        var resultado = new List<OcorrenciaRecorrencia>();
        foreach (var escolha in ordenadas)
        {
            var id = plano.Ocorrencias[escolha.Ordem].SessaoId;
            if (escolha.Agendar)
            {
                var horario = incluir.Single(x => x.Ordem == escolha.Ordem);
                var p = plano.Pedido;
                if (id > 0)
                {
                    var count = _UnitOfWork.Execute(@"UPDATE s SET DataInicio=@Inicio,DataFim=@Fim,ServicoId=v.Id,ServicoNome=v.Nome,
                        ModeloConsulta=@Modelo,VersaoModeloConsulta=@ModeloVersao,StatusAgendamento=1,StatusProntuario=2,
                        Changed=SYSUTCDATETIME(),UserId=@Actor FROM Sesoes s JOIN Servico v ON v.Id=@Servico AND v.TenantID=@Tenant AND v.Deleted=0
                        WHERE s.Id=@Id AND s.TenantID=@Tenant AND s.ProfissionalId=@Profissional",
                        new { Id=id, Inicio=horario.Inicio, Fim=horario.Fim, Servico=p.ServicoId, Modelo=p.ModeloConsulta, ModeloVersao=p.VersaoModeloConsulta, Tenant=tenant, Actor=actor, Profissional=profissional });
                    if (count != 1) throw new AtendimentoException("Serviço alterado. Atualize a prévia.", 409);
                }
                else
                    id = _UnitOfWork.Query<int>(@"INSERT INTO Sesoes(PacienteId,ProfissionalId,ServicoId,ServicoNome,ModeloConsulta,VersaoModeloConsulta,
                        DataInicio,DataFim,StatusAgendamento,StatusProntuario,VersaoAtendimento,RecorrenciaId,TenantID,Deleted,Changed,UserId,OperationalEntityId)
                        OUTPUT inserted.Id SELECT @Paciente,@Profissional,v.Id,v.Nome,@Modelo,@ModeloVersao,@Inicio,@Fim,1,2,0,@Serie,@Tenant,0,SYSUTCDATETIME(),@Actor,@OperationalId
                        FROM Servico v WHERE v.Id=@Servico AND v.TenantID=@Tenant AND v.Deleted=0",
                        new { Paciente=p.PacienteId, Profissional=profissional, Servico=p.ServicoId, Modelo=p.ModeloConsulta, ModeloVersao=p.VersaoModeloConsulta,
                            Inicio=horario.Inicio, Fim=horario.Fim, Serie=plano.SerieId, Tenant=tenant, Actor=actor, OperationalId=Guid.NewGuid().ToString("N") }).Single();
            }
            resultado.Add(new(escolha.Ordem,id,escolha.DataInicio,escolha.DataFim,escolha.Agendar,false));
        }
        var response = new ResultadoRecorrencia(planoId,true,resultado);
        if (_UnitOfWork.Execute(@"UPDATE PlanoRecorrenciaConsulta SET ConfirmacaoHash=@Hash,Resultado=@Resultado,Changed=SYSUTCDATETIME()
            WHERE Id=@Id AND TenantID=@Tenant AND UserId=@Actor AND ConfirmacaoHash IS NULL",
            new { Id=planoId, Tenant=tenant, Actor=actor, Hash=hash, Resultado=JsonSerializer.Serialize(response, RecorrenciaJsonContext.Default.ResultadoRecorrencia) }) != 1)
            throw new AtendimentoException("A prévia já foi confirmada. Atualize.", 409);
        return response;
    }
    public sealed class PlanoRow
    {
        public string Plano { get; set; } = "";
        public string? ConfirmacaoHash { get; set; }
        public string? Resultado { get; set; }
        public DateTime ExpiraEmUtc { get; set; }
    }
}
