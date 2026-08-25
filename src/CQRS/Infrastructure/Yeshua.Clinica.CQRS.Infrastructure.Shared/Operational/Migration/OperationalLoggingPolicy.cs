// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfrastructureOperationalControlStateMigration
// </yeshua>

using Dominio.Interfaces;
using Dominio.Entitys;

namespace Yeshua.Generated.OperationalControl;

public sealed record OperationalLoggingPolicy(
    string Application,
    string Environment,
    string Revision,
    string DefaultLevel,
    string DefaultDepth,
    IReadOnlyList<DiagnosticTarget> Targets,
    DateTimeOffset UpdatedAtUtc,
    string Source);

public sealed record DiagnosticTarget(
    string? Component,
    string? Operation,
    string? Entity,
    string? RecordId,
    string Level,
    string Depth,
    DateTimeOffset? ExpiresAtUtc)
{
    public string? Field { get; init; }
}

public readonly record struct OperationalLoggingContext(
    string? Component,
    string? Operation,
    string? Entity,
    string? RecordId)
{
    public string? Field { get; init; }
}

public readonly record struct OperationalLoggingDecision(
    bool Enabled,
    string Level,
    string Depth,
    DiagnosticTarget? MatchedTarget);

public interface IOperationalLoggingPolicyAccessor
{
    OperationalLoggingPolicy Current { get; }
    OperationalLoggingDecision Evaluate(OperationalLoggingContext context);
}

public sealed class OperationalLoggingPolicyState :
    IOperationalLoggingPolicyAccessor,
    IOperationalTelemetryPolicy,
    IDomainTrackingPolicy
{
    private OperationalLoggingPolicy _current;

    public OperationalLoggingPolicyState(string application, string environment)
    {
        _current = new OperationalLoggingPolicy(
            application,
            environment,
            "LOCAL-BASELINE",
            "Information",
            "D0",
            [],
            DateTimeOffset.UtcNow,
            "LocalBaseline");
    }

    public OperationalLoggingPolicy Current => Volatile.Read(ref _current);

    public void Replace(OperationalLoggingPolicy policy)
    {
        if (!string.Equals(
                policy.Application,
                Current.Application,
                StringComparison.OrdinalIgnoreCase) ||
            !string.Equals(
                policy.Environment,
                Current.Environment,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"Policy for '{policy.Application}/{policy.Environment}' cannot replace policy for '{Current.Application}/{Current.Environment}'.");
        }

        Interlocked.Exchange(ref _current, policy);
    }

public OperationalLoggingDecision Evaluate(OperationalLoggingContext context)
{
    return Evaluate(
        context.Component,
        context.Operation,
        context.Entity,
        context.RecordId,
        context.Field);
}

private OperationalLoggingDecision Evaluate(
    string? component,
    string? operation,
    string? entity,
    string? recordId,
    string? field = null)
{
    return Evaluate(Current, component, operation, entity, recordId, field, true);
}

private OperationalLoggingDecision Evaluate(
    OperationalLoggingPolicy policy,
    string? component,
    string? operation,
    string? entity,
    string? recordId,
    string? field,
    bool useDefault)
{
    DiagnosticTarget? target = null;
    if (policy.Targets.Count > 0)
    {
        var now = DateTimeOffset.UtcNow;
        var highestSpecificity = -1;
        foreach (var candidate in policy.Targets)
        {
            if ((candidate.ExpiresAtUtc is not null && candidate.ExpiresAtUtc <= now) ||
                !Matches(candidate.Component, component) ||
                !Matches(candidate.Operation, operation) ||
                !Matches(candidate.Entity, entity) ||
                !Matches(candidate.RecordId, recordId) ||
                !Matches(candidate.Field, field))
            {
                continue;
            }

            var specificity = Specificity(candidate);
            if (specificity <= highestSpecificity)
                continue;

            highestSpecificity = specificity;
            target = candidate;
        }
    }

        if (!useDefault && target is null)
        {
            return new OperationalLoggingDecision(
                false,
                "None",
                "D0",
                null);
        }

        var level = target?.Level ?? policy.DefaultLevel;
        var depth = target?.Depth ?? policy.DefaultDepth;
        return new OperationalLoggingDecision(
            !level.Equals("None", StringComparison.OrdinalIgnoreCase),
            level,
            depth,
            target);
    }

    OperationalTelemetryDecision IOperationalTelemetryPolicy.Evaluate(
        string component,
        string? operation,
        string? entity,
        string? recordId)
    {
    var decision = Evaluate(
        component,
        operation,
        entity,
        recordId);
        return new OperationalTelemetryDecision(
            decision.Enabled,
            decision.Level,
            decision.Depth);
    }

    OperationalTelemetryDecision IOperationalTelemetryPolicy.Evaluate(
        string component,
        string? operation,
        string? entity,
        string? recordId,
        string? field)
    {
    var decision = Evaluate(
        component,
        operation,
        entity,
        recordId,
        field);
        return new OperationalTelemetryDecision(
            decision.Enabled,
            decision.Level,
            decision.Depth);
    }

                public ulong GetMask(
                    string entity,
                    string? operation = null,
                    string? recordId = null)
                {
                    var policy = Current;
                    if (policy.Targets.Count == 0)
                        return 0UL;
                    if (!HasDomainTrackingTargets(policy))
                        return 0UL;

                    return entity switch
                    {
                        "Clinica" => GetClinicaMask(policy, operation, recordId),
                        "Especialidade" => GetEspecialidadeMask(policy, operation, recordId),
                        "Profissional" => GetProfissionalMask(policy, operation, recordId),
                        "DisponibilidadeAgenda" => GetDisponibilidadeAgendaMask(policy, operation, recordId),
                        "GrupoServico" => GetGrupoServicoMask(policy, operation, recordId),
                        "Servico" => GetServicoMask(policy, operation, recordId),
                        "Paciente" => GetPacienteMask(policy, operation, recordId),
                        "MovimentacaoFinanceira" => GetMovimentacaoFinanceiraMask(policy, operation, recordId),
                        "Sesoes" => GetSesoesMask(policy, operation, recordId),
                        "PlanoConta" => GetPlanoContaMask(policy, operation, recordId),
                        "MovimentoFinanceiro" => GetMovimentoFinanceiroMask(policy, operation, recordId),
                        "yFileUpload" => GetyFileUploadMask(policy, operation, recordId),
                        "ySaga" => GetySagaMask(policy, operation, recordId),
                        "ySagaStep" => GetySagaStepMask(policy, operation, recordId),
                        "yOutbox" => GetyOutboxMask(policy, operation, recordId),
                        "yInbox" => GetyInboxMask(policy, operation, recordId),
                        "yTenant" => GetyTenantMask(policy, operation, recordId),
                        "yUser" => GetyUserMask(policy, operation, recordId),
                        "yConfigArcteture" => GetyConfigArctetureMask(policy, operation, recordId),
                        "yConfigNotification" => GetyConfigNotificationMask(policy, operation, recordId),
                        "yPerfil" => GetyPerfilMask(policy, operation, recordId),
                        "yModule" => GetyModuleMask(policy, operation, recordId),
                        "yTenantModule" => GetyTenantModuleMask(policy, operation, recordId),
                        "yUserModule" => GetyUserModuleMask(policy, operation, recordId),
                        "yGrant" => GetyGrantMask(policy, operation, recordId),
                        "yPerfilGrant" => GetyPerfilGrantMask(policy, operation, recordId),
                        "yUserGrant" => GetyUserGrantMask(policy, operation, recordId),
                        _ => 0UL
                    };
                }

                private ulong GetClinicaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Clinica", operation, recordId, "Id"))
                        mask |= ClinicaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Clinica", operation, recordId, "Nome"))
                        mask |= ClinicaTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "Clinica", operation, recordId, "Endereco"))
                        mask |= ClinicaTrackingFields.Endereco;
                    if (DomainFieldTracked(policy, "Clinica", operation, recordId, "Telefone"))
                        mask |= ClinicaTrackingFields.Telefone;
                    if (DomainFieldTracked(policy, "Clinica", operation, recordId, "TenantID"))
                        mask |= ClinicaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Clinica", operation, recordId, "Deleted"))
                        mask |= ClinicaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Clinica", operation, recordId, "Changed"))
                        mask |= ClinicaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Clinica", operation, recordId, "UserId"))
                        mask |= ClinicaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetEspecialidadeMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Especialidade", operation, recordId, "Id"))
                        mask |= EspecialidadeTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Especialidade", operation, recordId, "Descricao"))
                        mask |= EspecialidadeTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "Especialidade", operation, recordId, "TenantID"))
                        mask |= EspecialidadeTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Especialidade", operation, recordId, "Deleted"))
                        mask |= EspecialidadeTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Especialidade", operation, recordId, "Changed"))
                        mask |= EspecialidadeTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Especialidade", operation, recordId, "UserId"))
                        mask |= EspecialidadeTrackingFields.UserId;
                    return mask;
                }

                private ulong GetProfissionalMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Profissional", operation, recordId, "Id"))
                        mask |= ProfissionalTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Profissional", operation, recordId, "Nome"))
                        mask |= ProfissionalTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "Profissional", operation, recordId, "EspecialidadeId"))
                        mask |= ProfissionalTrackingFields.EspecialidadeId;
                    if (DomainFieldTracked(policy, "Profissional", operation, recordId, "Telefone"))
                        mask |= ProfissionalTrackingFields.Telefone;
                    if (DomainFieldTracked(policy, "Profissional", operation, recordId, "TenantID"))
                        mask |= ProfissionalTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Profissional", operation, recordId, "Deleted"))
                        mask |= ProfissionalTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Profissional", operation, recordId, "Changed"))
                        mask |= ProfissionalTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Profissional", operation, recordId, "UserId"))
                        mask |= ProfissionalTrackingFields.UserId;
                    return mask;
                }

                private ulong GetDisponibilidadeAgendaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "DisponibilidadeAgenda", operation, recordId, "Id"))
                        mask |= DisponibilidadeAgendaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "DisponibilidadeAgenda", operation, recordId, "ProfissionalId"))
                        mask |= DisponibilidadeAgendaTrackingFields.ProfissionalId;
                    if (DomainFieldTracked(policy, "DisponibilidadeAgenda", operation, recordId, "DataHora"))
                        mask |= DisponibilidadeAgendaTrackingFields.DataHora;
                    if (DomainFieldTracked(policy, "DisponibilidadeAgenda", operation, recordId, "TenantID"))
                        mask |= DisponibilidadeAgendaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "DisponibilidadeAgenda", operation, recordId, "Deleted"))
                        mask |= DisponibilidadeAgendaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "DisponibilidadeAgenda", operation, recordId, "Changed"))
                        mask |= DisponibilidadeAgendaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "DisponibilidadeAgenda", operation, recordId, "UserId"))
                        mask |= DisponibilidadeAgendaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetGrupoServicoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "GrupoServico", operation, recordId, "Id"))
                        mask |= GrupoServicoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "GrupoServico", operation, recordId, "Descricao"))
                        mask |= GrupoServicoTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "GrupoServico", operation, recordId, "TenantID"))
                        mask |= GrupoServicoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "GrupoServico", operation, recordId, "Deleted"))
                        mask |= GrupoServicoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "GrupoServico", operation, recordId, "Changed"))
                        mask |= GrupoServicoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "GrupoServico", operation, recordId, "UserId"))
                        mask |= GrupoServicoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetServicoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Servico", operation, recordId, "Id"))
                        mask |= ServicoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Servico", operation, recordId, "GrupoServicoId"))
                        mask |= ServicoTrackingFields.GrupoServicoId;
                    if (DomainFieldTracked(policy, "Servico", operation, recordId, "Nome"))
                        mask |= ServicoTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "Servico", operation, recordId, "Valor"))
                        mask |= ServicoTrackingFields.Valor;
                    if (DomainFieldTracked(policy, "Servico", operation, recordId, "TenantID"))
                        mask |= ServicoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Servico", operation, recordId, "Deleted"))
                        mask |= ServicoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Servico", operation, recordId, "Changed"))
                        mask |= ServicoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Servico", operation, recordId, "UserId"))
                        mask |= ServicoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPacienteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Id"))
                        mask |= PacienteTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Nome"))
                        mask |= PacienteTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Telefone"))
                        mask |= PacienteTrackingFields.Telefone;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "DataNascimento"))
                        mask |= PacienteTrackingFields.DataNascimento;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Genero"))
                        mask |= PacienteTrackingFields.Genero;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Escolaridade"))
                        mask |= PacienteTrackingFields.Escolaridade;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Profissao"))
                        mask |= PacienteTrackingFields.Profissao;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Endereco"))
                        mask |= PacienteTrackingFields.Endereco;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "NomeResponsavel"))
                        mask |= PacienteTrackingFields.NomeResponsavel;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "TelefoneResponsavel"))
                        mask |= PacienteTrackingFields.TelefoneResponsavel;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Observacao"))
                        mask |= PacienteTrackingFields.Observacao;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "TenantID"))
                        mask |= PacienteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Deleted"))
                        mask |= PacienteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "Changed"))
                        mask |= PacienteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Paciente", operation, recordId, "UserId"))
                        mask |= PacienteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMovimentacaoFinanceiraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "Id"))
                        mask |= MovimentacaoFinanceiraTrackingFields.Id;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "PacienteId"))
                        mask |= MovimentacaoFinanceiraTrackingFields.PacienteId;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "ServicoId"))
                        mask |= MovimentacaoFinanceiraTrackingFields.ServicoId;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "Valor"))
                        mask |= MovimentacaoFinanceiraTrackingFields.Valor;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "TipoMovimentacao"))
                        mask |= MovimentacaoFinanceiraTrackingFields.TipoMovimentacao;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "DataMovimentacao"))
                        mask |= MovimentacaoFinanceiraTrackingFields.DataMovimentacao;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "SaldoAtual"))
                        mask |= MovimentacaoFinanceiraTrackingFields.SaldoAtual;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "TenantID"))
                        mask |= MovimentacaoFinanceiraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "Deleted"))
                        mask |= MovimentacaoFinanceiraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "Changed"))
                        mask |= MovimentacaoFinanceiraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "MovimentacaoFinanceira", operation, recordId, "UserId"))
                        mask |= MovimentacaoFinanceiraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetSesoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "PacienteId"))
                        mask |= SesoesTrackingFields.PacienteId;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "DataInicio"))
                        mask |= SesoesTrackingFields.DataInicio;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "DataFim"))
                        mask |= SesoesTrackingFields.DataFim;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "StatusAgendamento"))
                        mask |= SesoesTrackingFields.StatusAgendamento;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "StatusProntuario"))
                        mask |= SesoesTrackingFields.StatusProntuario;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "Prontuario"))
                        mask |= SesoesTrackingFields.Prontuario;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "QueixaPrincipal"))
                        mask |= SesoesTrackingFields.QueixaPrincipal;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "RegistroDocumental"))
                        mask |= SesoesTrackingFields.RegistroDocumental;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "SintomasRelatados"))
                        mask |= SesoesTrackingFields.SintomasRelatados;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "MudancasDesdeUltimaSessaao"))
                        mask |= SesoesTrackingFields.MudancasDesdeUltimaSessaao;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "ComportamentoObservado"))
                        mask |= SesoesTrackingFields.ComportamentoObservado;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "EstadoEmocionalGeral"))
                        mask |= SesoesTrackingFields.EstadoEmocionalGeral;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "DiscursoPensamentos"))
                        mask |= SesoesTrackingFields.DiscursoPensamentos;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "UsoMedicacao"))
                        mask |= SesoesTrackingFields.UsoMedicacao;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "TecnicasUtilizadas"))
                        mask |= SesoesTrackingFields.TecnicasUtilizadas;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "QuestionamentosReflexoesAbordadas"))
                        mask |= SesoesTrackingFields.QuestionamentosReflexoesAbordadas;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "ExerciciosTarefasSugeridas"))
                        mask |= SesoesTrackingFields.ExerciciosTarefasSugeridas;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "DiagnoosticoHipoteseDiagnoostica"))
                        mask |= SesoesTrackingFields.DiagnoosticoHipoteseDiagnoostica;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "ObjetivosCurtoPrazo"))
                        mask |= SesoesTrackingFields.ObjetivosCurtoPrazo;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "ObjetivosLongoPrazo"))
                        mask |= SesoesTrackingFields.ObjetivosLongoPrazo;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "FrequenciaSugeridaSessooes"))
                        mask |= SesoesTrackingFields.FrequenciaSugeridaSessooes;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "EncaminhamentoOutrosProfissionais"))
                        mask |= SesoesTrackingFields.EncaminhamentoOutrosProfissionais;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "InformacoesRelevantesFuturasConsultas"))
                        mask |= SesoesTrackingFields.InformacoesRelevantesFuturasConsultas;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "FeedbackPacienteSobreProcessoTerapeeutico"))
                        mask |= SesoesTrackingFields.FeedbackPacienteSobreProcessoTerapeeutico;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "Id"))
                        mask |= SesoesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "ServicoId"))
                        mask |= SesoesTrackingFields.ServicoId;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "MovimentacaoFinanceiraId"))
                        mask |= SesoesTrackingFields.MovimentacaoFinanceiraId;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "ProfissionalId"))
                        mask |= SesoesTrackingFields.ProfissionalId;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "TenantID"))
                        mask |= SesoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "Deleted"))
                        mask |= SesoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "Changed"))
                        mask |= SesoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Sesoes", operation, recordId, "UserId"))
                        mask |= SesoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPlanoContaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PlanoConta", operation, recordId, "Id"))
                        mask |= PlanoContaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "PlanoConta", operation, recordId, "Codigo"))
                        mask |= PlanoContaTrackingFields.Codigo;
                    if (DomainFieldTracked(policy, "PlanoConta", operation, recordId, "Nome"))
                        mask |= PlanoContaTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "PlanoConta", operation, recordId, "Tipo"))
                        mask |= PlanoContaTrackingFields.Tipo;
                    if (DomainFieldTracked(policy, "PlanoConta", operation, recordId, "TenantID"))
                        mask |= PlanoContaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "PlanoConta", operation, recordId, "Deleted"))
                        mask |= PlanoContaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "PlanoConta", operation, recordId, "Changed"))
                        mask |= PlanoContaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "PlanoConta", operation, recordId, "UserId"))
                        mask |= PlanoContaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMovimentoFinanceiroMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "Id"))
                        mask |= MovimentoFinanceiroTrackingFields.Id;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "IdOrigem"))
                        mask |= MovimentoFinanceiroTrackingFields.IdOrigem;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "ContaDebitoId"))
                        mask |= MovimentoFinanceiroTrackingFields.ContaDebitoId;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "Valor"))
                        mask |= MovimentoFinanceiroTrackingFields.Valor;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "DataMovimento"))
                        mask |= MovimentoFinanceiroTrackingFields.DataMovimento;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "DataVencimento"))
                        mask |= MovimentoFinanceiroTrackingFields.DataVencimento;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "Status"))
                        mask |= MovimentoFinanceiroTrackingFields.Status;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "TenantID"))
                        mask |= MovimentoFinanceiroTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "Deleted"))
                        mask |= MovimentoFinanceiroTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "Changed"))
                        mask |= MovimentoFinanceiroTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "MovimentoFinanceiro", operation, recordId, "UserId"))
                        mask |= MovimentoFinanceiroTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyFileUploadMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Id"))
                        mask |= yFileUploadTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Type"))
                        mask |= yFileUploadTrackingFields.Type;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Status"))
                        mask |= yFileUploadTrackingFields.Status;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "FilePath"))
                        mask |= yFileUploadTrackingFields.FilePath;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "FileSize"))
                        mask |= yFileUploadTrackingFields.FileSize;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "EntityType"))
                        mask |= yFileUploadTrackingFields.EntityType;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "EntityId"))
                        mask |= yFileUploadTrackingFields.EntityId;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "CreatedAt"))
                        mask |= yFileUploadTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "CompletedAt"))
                        mask |= yFileUploadTrackingFields.CompletedAt;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "TenantID"))
                        mask |= yFileUploadTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Deleted"))
                        mask |= yFileUploadTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Changed"))
                        mask |= yFileUploadTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "UserId"))
                        mask |= yFileUploadTrackingFields.UserId;
                    return mask;
                }

                private ulong GetySagaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Id"))
                        mask |= ySagaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "CorrelationId"))
                        mask |= ySagaTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Type"))
                        mask |= ySagaTrackingFields.Type;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Status"))
                        mask |= ySagaTrackingFields.Status;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "KeyCurrentStep"))
                        mask |= ySagaTrackingFields.KeyCurrentStep;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "CreatedAt"))
                        mask |= ySagaTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "CompletedAt"))
                        mask |= ySagaTrackingFields.CompletedAt;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "EntityType"))
                        mask |= ySagaTrackingFields.EntityType;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "EntityId"))
                        mask |= ySagaTrackingFields.EntityId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "NextExecutionAt"))
                        mask |= ySagaTrackingFields.NextExecutionAt;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "LockedAt"))
                        mask |= ySagaTrackingFields.LockedAt;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "LockedBy"))
                        mask |= ySagaTrackingFields.LockedBy;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "TenantID"))
                        mask |= ySagaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Deleted"))
                        mask |= ySagaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Changed"))
                        mask |= ySagaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "UserId"))
                        mask |= ySagaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetySagaStepMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Id"))
                        mask |= ySagaStepTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "SagaId"))
                        mask |= ySagaStepTrackingFields.SagaId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "StepKey"))
                        mask |= ySagaStepTrackingFields.StepKey;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "IndexOrder"))
                        mask |= ySagaStepTrackingFields.IndexOrder;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "CorrelationId"))
                        mask |= ySagaStepTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Status"))
                        mask |= ySagaStepTrackingFields.Status;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "ExecutionCount"))
                        mask |= ySagaStepTrackingFields.ExecutionCount;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "LastExecutionAt"))
                        mask |= ySagaStepTrackingFields.LastExecutionAt;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "CompletedAt"))
                        mask |= ySagaStepTrackingFields.CompletedAt;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "ErrorMessage"))
                        mask |= ySagaStepTrackingFields.ErrorMessage;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Payload"))
                        mask |= ySagaStepTrackingFields.Payload;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "RetryCount"))
                        mask |= ySagaStepTrackingFields.RetryCount;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "TenantID"))
                        mask |= ySagaStepTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Deleted"))
                        mask |= ySagaStepTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Changed"))
                        mask |= ySagaStepTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "UserId"))
                        mask |= ySagaStepTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyOutboxMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Id"))
                        mask |= yOutboxTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "MessageId"))
                        mask |= yOutboxTrackingFields.MessageId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Type"))
                        mask |= yOutboxTrackingFields.Type;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "EntityType"))
                        mask |= yOutboxTrackingFields.EntityType;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "EntityId"))
                        mask |= yOutboxTrackingFields.EntityId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "CorrelationId"))
                        mask |= yOutboxTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Payload"))
                        mask |= yOutboxTrackingFields.Payload;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Status"))
                        mask |= yOutboxTrackingFields.Status;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "TransportType"))
                        mask |= yOutboxTrackingFields.TransportType;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "TransportData"))
                        mask |= yOutboxTrackingFields.TransportData;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "CreatedAt"))
                        mask |= yOutboxTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "SentAt"))
                        mask |= yOutboxTrackingFields.SentAt;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "RetryCount"))
                        mask |= yOutboxTrackingFields.RetryCount;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "LastError"))
                        mask |= yOutboxTrackingFields.LastError;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "ProcessingAt"))
                        mask |= yOutboxTrackingFields.ProcessingAt;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "NextAttemptAt"))
                        mask |= yOutboxTrackingFields.NextAttemptAt;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "SagaId"))
                        mask |= yOutboxTrackingFields.SagaId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "SagaStepId"))
                        mask |= yOutboxTrackingFields.SagaStepId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "TenantID"))
                        mask |= yOutboxTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Deleted"))
                        mask |= yOutboxTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Changed"))
                        mask |= yOutboxTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "UserId"))
                        mask |= yOutboxTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyInboxMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Id"))
                        mask |= yInboxTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "MessageId"))
                        mask |= yInboxTrackingFields.MessageId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Type"))
                        mask |= yInboxTrackingFields.Type;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "EntityType"))
                        mask |= yInboxTrackingFields.EntityType;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "EntityId"))
                        mask |= yInboxTrackingFields.EntityId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "CorrelationId"))
                        mask |= yInboxTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Payload"))
                        mask |= yInboxTrackingFields.Payload;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Status"))
                        mask |= yInboxTrackingFields.Status;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "CreatedAt"))
                        mask |= yInboxTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "RetryCount"))
                        mask |= yInboxTrackingFields.RetryCount;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "LastError"))
                        mask |= yInboxTrackingFields.LastError;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "ProcessingAt"))
                        mask |= yInboxTrackingFields.ProcessingAt;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "NextAttemptAt"))
                        mask |= yInboxTrackingFields.NextAttemptAt;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "SagaId"))
                        mask |= yInboxTrackingFields.SagaId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "SagaStepId"))
                        mask |= yInboxTrackingFields.SagaStepId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "TenantID"))
                        mask |= yInboxTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Deleted"))
                        mask |= yInboxTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Changed"))
                        mask |= yInboxTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "UserId"))
                        mask |= yInboxTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyTenantMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "Id"))
                        mask |= yTenantTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "CnpjCpf"))
                        mask |= yTenantTrackingFields.CnpjCpf;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "Nome"))
                        mask |= yTenantTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "UserId"))
                        mask |= yTenantTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "Deleted"))
                        mask |= yTenantTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "Changed"))
                        mask |= yTenantTrackingFields.Changed;
                    return mask;
                }

                private ulong GetyUserMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Id"))
                        mask |= yUserTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Nome"))
                        mask |= yUserTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Email"))
                        mask |= yUserTrackingFields.Email;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Senha"))
                        mask |= yUserTrackingFields.Senha;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "TenantID"))
                        mask |= yUserTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Deleted"))
                        mask |= yUserTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Changed"))
                        mask |= yUserTrackingFields.Changed;
                    return mask;
                }

                private ulong GetyConfigArctetureMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "Id"))
                        mask |= yConfigArctetureTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "AuditTrackerActived"))
                        mask |= yConfigArctetureTrackingFields.AuditTrackerActived;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "AuditCRUDActived"))
                        mask |= yConfigArctetureTrackingFields.AuditCRUDActived;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "TenantID"))
                        mask |= yConfigArctetureTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "Deleted"))
                        mask |= yConfigArctetureTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "Changed"))
                        mask |= yConfigArctetureTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "UserId"))
                        mask |= yConfigArctetureTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyConfigNotificationMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "Id"))
                        mask |= yConfigNotificationTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "TenantID"))
                        mask |= yConfigNotificationTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "EmailSmtpClient"))
                        mask |= yConfigNotificationTrackingFields.EmailSmtpClient;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "EmailPort"))
                        mask |= yConfigNotificationTrackingFields.EmailPort;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "EmailUserName"))
                        mask |= yConfigNotificationTrackingFields.EmailUserName;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "EmailPassword"))
                        mask |= yConfigNotificationTrackingFields.EmailPassword;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "Deleted"))
                        mask |= yConfigNotificationTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "Changed"))
                        mask |= yConfigNotificationTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "UserId"))
                        mask |= yConfigNotificationTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyPerfilMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "Id"))
                        mask |= yPerfilTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "Description"))
                        mask |= yPerfilTrackingFields.Description;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "TenantID"))
                        mask |= yPerfilTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "Deleted"))
                        mask |= yPerfilTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "Changed"))
                        mask |= yPerfilTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "UserId"))
                        mask |= yPerfilTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyModuleMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yModule", operation, recordId, "Id"))
                        mask |= yModuleTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yModule", operation, recordId, "Description"))
                        mask |= yModuleTrackingFields.Description;
                    return mask;
                }

                private ulong GetyTenantModuleMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "Id"))
                        mask |= yTenantModuleTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "ModuleId"))
                        mask |= yTenantModuleTrackingFields.ModuleId;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "TenantID"))
                        mask |= yTenantModuleTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "ValidUntil"))
                        mask |= yTenantModuleTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "Deleted"))
                        mask |= yTenantModuleTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "Changed"))
                        mask |= yTenantModuleTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "UserId"))
                        mask |= yTenantModuleTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyUserModuleMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "Id"))
                        mask |= yUserModuleTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "ModuleId"))
                        mask |= yUserModuleTrackingFields.ModuleId;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "UserId"))
                        mask |= yUserModuleTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "ValidUntil"))
                        mask |= yUserModuleTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "TenantID"))
                        mask |= yUserModuleTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "Deleted"))
                        mask |= yUserModuleTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "Changed"))
                        mask |= yUserModuleTrackingFields.Changed;
                    return mask;
                }

                private ulong GetyGrantMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "Id"))
                        mask |= yGrantTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "Description"))
                        mask |= yGrantTrackingFields.Description;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "TenantID"))
                        mask |= yGrantTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "Deleted"))
                        mask |= yGrantTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "Changed"))
                        mask |= yGrantTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "UserId"))
                        mask |= yGrantTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyPerfilGrantMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "Id"))
                        mask |= yPerfilGrantTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "PerfilId"))
                        mask |= yPerfilGrantTrackingFields.PerfilId;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "GrantId"))
                        mask |= yPerfilGrantTrackingFields.GrantId;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanGrant"))
                        mask |= yPerfilGrantTrackingFields.CanGrant;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanCreate"))
                        mask |= yPerfilGrantTrackingFields.CanCreate;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanRead"))
                        mask |= yPerfilGrantTrackingFields.CanRead;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanUpdate"))
                        mask |= yPerfilGrantTrackingFields.CanUpdate;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanDelete"))
                        mask |= yPerfilGrantTrackingFields.CanDelete;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "ValidUntil"))
                        mask |= yPerfilGrantTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "TenantID"))
                        mask |= yPerfilGrantTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "Deleted"))
                        mask |= yPerfilGrantTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "Changed"))
                        mask |= yPerfilGrantTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "UserId"))
                        mask |= yPerfilGrantTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyUserGrantMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "Id"))
                        mask |= yUserGrantTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "PerfilId"))
                        mask |= yUserGrantTrackingFields.PerfilId;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "GrantId"))
                        mask |= yUserGrantTrackingFields.GrantId;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanGrant"))
                        mask |= yUserGrantTrackingFields.CanGrant;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanCreate"))
                        mask |= yUserGrantTrackingFields.CanCreate;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanRead"))
                        mask |= yUserGrantTrackingFields.CanRead;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanUpdate"))
                        mask |= yUserGrantTrackingFields.CanUpdate;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanDelete"))
                        mask |= yUserGrantTrackingFields.CanDelete;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "ValidUntil"))
                        mask |= yUserGrantTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "TenantID"))
                        mask |= yUserGrantTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "Deleted"))
                        mask |= yUserGrantTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "Changed"))
                        mask |= yUserGrantTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "UserId"))
                        mask |= yUserGrantTrackingFields.UserId;
                    return mask;
                }

                private bool DomainFieldTracked(
                    OperationalLoggingPolicy policy,
                    string entity,
                    string? operation,
                    string? recordId,
                    string field)
                {
                    var decision = Evaluate(
                        policy,
                        "DomainTracker",
                        operation,
                        entity,
                        recordId,
                        field,
                        false);

                    return decision.MatchedTarget is { } target &&
                           string.Equals(target.Component, "DomainTracker", StringComparison.OrdinalIgnoreCase) &&
                           decision.Enabled &&
                           !decision.Depth.Equals("D0", StringComparison.OrdinalIgnoreCase);
                }

                private static bool HasDomainTrackingTargets(OperationalLoggingPolicy policy)
                {
                    var now = DateTimeOffset.UtcNow;
                    foreach (var target in policy.Targets)
                    {
                        if (target.ExpiresAtUtc is not null && target.ExpiresAtUtc <= now)
                            continue;
                        if (!string.Equals(target.Component, "DomainTracker", StringComparison.OrdinalIgnoreCase))
                            continue;
                        if (string.Equals(target.Level, "None", StringComparison.OrdinalIgnoreCase))
                            continue;
                        if (string.Equals(target.Depth, "D0", StringComparison.OrdinalIgnoreCase))
                            continue;

                        return true;
                    }

                    return false;
                }


    private static bool Matches(string? expected, string? actual)
    {
        return string.IsNullOrWhiteSpace(expected) ||
               string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase);
    }

    private static int Specificity(DiagnosticTarget target)
    {
        var score = 0;
        if (!string.IsNullOrWhiteSpace(target.Component)) score++;
        if (!string.IsNullOrWhiteSpace(target.Operation)) score += 2;
        if (!string.IsNullOrWhiteSpace(target.Entity)) score += 4;
        if (!string.IsNullOrWhiteSpace(target.RecordId)) score += 8;
        if (!string.IsNullOrWhiteSpace(target.Field)) score += 16;
        return score;
    }
}//Dominio.Schemas.CQRS.SourceCodeInfrastructureOperationalControlStateMigration