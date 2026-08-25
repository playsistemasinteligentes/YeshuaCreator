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
                        "Produto" => GetProdutoMask(policy, operation, recordId),
                        "Maquina" => GetMaquinaMask(policy, operation, recordId),
                        "GrupoMaquina" => GetGrupoMaquinaMask(policy, operation, recordId),
                        "TemplateDeTestes" => GetTemplateDeTestesMask(policy, operation, recordId),
                        "Roteiro" => GetRoteiroMask(policy, operation, recordId),
                        "ConsultaPedido" => GetConsultaPedidoMask(policy, operation, recordId),
                        "RoteiroPedido" => GetRoteiroPedidoMask(policy, operation, recordId),
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

                private ulong GetProdutoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Id"))
                        mask |= ProdutoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Descricao"))
                        mask |= ProdutoTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Status"))
                        mask |= ProdutoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "TenantID"))
                        mask |= ProdutoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Deleted"))
                        mask |= ProdutoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Changed"))
                        mask |= ProdutoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "UserId"))
                        mask |= ProdutoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMaquinaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Id"))
                        mask |= MaquinaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Descricao"))
                        mask |= MaquinaTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Status"))
                        mask |= MaquinaTrackingFields.Status;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "TenantID"))
                        mask |= MaquinaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Deleted"))
                        mask |= MaquinaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Changed"))
                        mask |= MaquinaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "UserId"))
                        mask |= MaquinaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetGrupoMaquinaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Id"))
                        mask |= GrupoMaquinaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Descricao"))
                        mask |= GrupoMaquinaTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Status"))
                        mask |= GrupoMaquinaTrackingFields.Status;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "TenantID"))
                        mask |= GrupoMaquinaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Deleted"))
                        mask |= GrupoMaquinaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Changed"))
                        mask |= GrupoMaquinaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "UserId"))
                        mask |= GrupoMaquinaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTemplateDeTestesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Id"))
                        mask |= TemplateDeTestesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Descricao"))
                        mask |= TemplateDeTestesTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "TenantID"))
                        mask |= TemplateDeTestesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Deleted"))
                        mask |= TemplateDeTestesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Changed"))
                        mask |= TemplateDeTestesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "UserId"))
                        mask |= TemplateDeTestesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRoteiroMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Id"))
                        mask |= RoteiroTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "MaquinaId"))
                        mask |= RoteiroTrackingFields.MaquinaId;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "ProdutoId"))
                        mask |= RoteiroTrackingFields.ProdutoId;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "SequenciaTransformacao"))
                        mask |= RoteiroTrackingFields.SequenciaTransformacao;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "GrupoMaquinaId"))
                        mask |= RoteiroTrackingFields.GrupoMaquinaId;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "PecasPorPulso"))
                        mask |= RoteiroTrackingFields.PecasPorPulso;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "PrioridadeInformada"))
                        mask |= RoteiroTrackingFields.PrioridadeInformada;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Acao"))
                        mask |= RoteiroTrackingFields.Acao;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Performance"))
                        mask |= RoteiroTrackingFields.Performance;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "TempoSetup"))
                        mask |= RoteiroTrackingFields.TempoSetup;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "TempoSetupAjuste"))
                        mask |= RoteiroTrackingFields.TempoSetupAjuste;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "ProximaSequenciaTransformacao"))
                        mask |= RoteiroTrackingFields.ProximaSequenciaTransformacao;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Status"))
                        mask |= RoteiroTrackingFields.Status;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "HierarquiaSequenciaTransformacao"))
                        mask |= RoteiroTrackingFields.HierarquiaSequenciaTransformacao;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "AvaliaCusto"))
                        mask |= RoteiroTrackingFields.AvaliaCusto;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Operacoes"))
                        mask |= RoteiroTrackingFields.Operacoes;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "ExcecaoOperacoes"))
                        mask |= RoteiroTrackingFields.ExcecaoOperacoes;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "PercentualInicioPassoAnterior"))
                        mask |= RoteiroTrackingFields.PercentualInicioPassoAnterior;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "LinhaDireta"))
                        mask |= RoteiroTrackingFields.LinhaDireta;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "TemplateDeTestesId"))
                        mask |= RoteiroTrackingFields.TemplateDeTestesId;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "TenantID"))
                        mask |= RoteiroTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Deleted"))
                        mask |= RoteiroTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Changed"))
                        mask |= RoteiroTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "UserId"))
                        mask |= RoteiroTrackingFields.UserId;
                    return mask;
                }

                private ulong GetConsultaPedidoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "PedidoId"))
                        mask |= ConsultaPedidoTrackingFields.PedidoId;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "ClienteId"))
                        mask |= ConsultaPedidoTrackingFields.ClienteId;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "ClienteNome"))
                        mask |= ConsultaPedidoTrackingFields.ClienteNome;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "RazaoSocial"))
                        mask |= ConsultaPedidoTrackingFields.RazaoSocial;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "ProdutoId"))
                        mask |= ConsultaPedidoTrackingFields.ProdutoId;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "ProdutoDescricao"))
                        mask |= ConsultaPedidoTrackingFields.ProdutoDescricao;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "Status"))
                        mask |= ConsultaPedidoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "Estagio"))
                        mask |= ConsultaPedidoTrackingFields.Estagio;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "DataEntregaDe"))
                        mask |= ConsultaPedidoTrackingFields.DataEntregaDe;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "DataEntregaAte"))
                        mask |= ConsultaPedidoTrackingFields.DataEntregaAte;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "EmbarqueAlvo"))
                        mask |= ConsultaPedidoTrackingFields.EmbarqueAlvo;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "Quantidade"))
                        mask |= ConsultaPedidoTrackingFields.Quantidade;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "SaldoAProduzir"))
                        mask |= ConsultaPedidoTrackingFields.SaldoAProduzir;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "SaldoAExpedir"))
                        mask |= ConsultaPedidoTrackingFields.SaldoAExpedir;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "CorFila"))
                        mask |= ConsultaPedidoTrackingFields.CorFila;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "PedidoCliente"))
                        mask |= ConsultaPedidoTrackingFields.PedidoCliente;
                    return mask;
                }

                private ulong GetRoteiroPedidoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "PedidoId"))
                        mask |= RoteiroPedidoTrackingFields.PedidoId;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "MaquinaId"))
                        mask |= RoteiroPedidoTrackingFields.MaquinaId;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "ProdutoId"))
                        mask |= RoteiroPedidoTrackingFields.ProdutoId;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "SequenciaTransformacao"))
                        mask |= RoteiroPedidoTrackingFields.SequenciaTransformacao;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "StatusCadastro"))
                        mask |= RoteiroPedidoTrackingFields.StatusCadastro;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "TipoPlanejamento"))
                        mask |= RoteiroPedidoTrackingFields.TipoPlanejamento;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "CalendarioId"))
                        mask |= RoteiroPedidoTrackingFields.CalendarioId;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "HierarquiaSequenciaTransformacao"))
                        mask |= RoteiroPedidoTrackingFields.HierarquiaSequenciaTransformacao;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "ProximaSequenciaTransformacao"))
                        mask |= RoteiroPedidoTrackingFields.ProximaSequenciaTransformacao;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "Performance"))
                        mask |= RoteiroPedidoTrackingFields.Performance;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "TempoSetup"))
                        mask |= RoteiroPedidoTrackingFields.TempoSetup;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "TempoSetupAjuste"))
                        mask |= RoteiroPedidoTrackingFields.TempoSetupAjuste;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "PecasPorPulso"))
                        mask |= RoteiroPedidoTrackingFields.PecasPorPulso;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "PrioridadeInformada"))
                        mask |= RoteiroPedidoTrackingFields.PrioridadeInformada;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "Status"))
                        mask |= RoteiroPedidoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "Operacoes"))
                        mask |= RoteiroPedidoTrackingFields.Operacoes;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "ExcecaoOperacoes"))
                        mask |= RoteiroPedidoTrackingFields.ExcecaoOperacoes;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "LinhaDireta"))
                        mask |= RoteiroPedidoTrackingFields.LinhaDireta;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "AvaliaCusto"))
                        mask |= RoteiroPedidoTrackingFields.AvaliaCusto;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "PercentualInicioPassoAnterior"))
                        mask |= RoteiroPedidoTrackingFields.PercentualInicioPassoAnterior;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "MaquinaLarguraUtil"))
                        mask |= RoteiroPedidoTrackingFields.MaquinaLarguraUtil;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "GrupoTipo"))
                        mask |= RoteiroPedidoTrackingFields.GrupoTipo;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "GrupoPerformanceMetroLinear"))
                        mask |= RoteiroPedidoTrackingFields.GrupoPerformanceMetroLinear;
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