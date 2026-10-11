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
using System.Collections.Concurrent;

namespace Yeshua.Generated.OperationalControl;

public sealed record OperationalLoggingPolicy(
    string Application,
    string Environment,
    string Revision,
    string DefaultLevel,
    string DefaultDepth,
    IReadOnlyList<DiagnosticTarget> Targets,
    DateTimeOffset UpdatedAtUtc,
    string Source)
{
    public IReadOnlyList<DiagnosticPolicyAuditEntry> DiagnosticAudit { get; init; } = [];
}

public sealed record DiagnosticPolicyAuditEntry(
    string DiagnosticSessionId,
    string Action,
    DateTimeOffset OccurredAtUtc,
    string RequestedBy,
    string ApprovedBy,
    string Justification);

public sealed record OperationalLoggingPolicyUpdate(
    string DefaultLevel,
    string DefaultDepth,
    IReadOnlyList<DiagnosticTarget>? Targets);

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
    public string? OperationId { get; init; }
    public string? DiagnosticSessionId { get; init; }
    public string? RequestedBy { get; init; }
    public string? ApprovedBy { get; init; }
    public string? Justification { get; init; }
    public DateTimeOffset? StartsAtUtc { get; init; }
    public int? MaximumCaptures { get; init; }
    public IReadOnlyList<string>? AuthorizedFields { get; init; }
}

public readonly record struct OperationalLoggingContext(
    string? Component,
    string? Operation,
    string? Entity,
    string? RecordId)
{
    public string? Field { get; init; }
    public string? OperationId { get; init; }
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
    private readonly ConcurrentDictionary<string, int> _diagnosticCaptureCounts =
        new(StringComparer.OrdinalIgnoreCase);

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

    public OperationalLoggingPolicy Current => RefreshExpiredTargets();

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
        RemoveInactiveCaptureCounters(policy);
    }

    public OperationalLoggingPolicy ApplyLocal(OperationalLoggingPolicyUpdate update)
    {
        var current = Current;
        var now = DateTimeOffset.UtcNow;
        var defaultLevel = string.IsNullOrWhiteSpace(update.DefaultLevel)
            ? current.DefaultLevel
            : update.DefaultLevel.Trim();
        var defaultDepth = string.IsNullOrWhiteSpace(update.DefaultDepth)
            ? current.DefaultDepth
            : update.DefaultDepth.Trim();
        var targets = NormalizeAndValidateTargets(
            defaultLevel,
            defaultDepth,
            update.Targets ?? [],
            now);
        var policy = current with
        {
            Revision = Guid.NewGuid().ToString("N"),
            DefaultLevel = defaultLevel,
            DefaultDepth = defaultDepth,
            Targets = targets,
            UpdatedAtUtc = now,
            Source = "LocalRuntime",
            DiagnosticAudit = BuildDiagnosticAudit(current, targets, now)
        };

        Replace(policy);
        return policy;
    }

public OperationalLoggingDecision Evaluate(OperationalLoggingContext context)
{
    return Evaluate(
        context.Component,
        context.Operation,
        context.Entity,
        context.RecordId,
        context.Field,
        context.OperationId);
}

private OperationalLoggingDecision Evaluate(
    string? component,
    string? operation,
    string? entity,
    string? recordId,
    string? field = null,
    string? operationId = null)
{
    return Evaluate(
        Current,
        component,
        operation,
        entity,
        recordId,
        field,
        operationId,
        true,
        true);
}

private OperationalLoggingDecision Evaluate(
    OperationalLoggingPolicy policy,
    string? component,
    string? operation,
    string? entity,
    string? recordId,
    string? field,
    string? operationId,
    bool useDefault,
    bool consumeDiagnosticCapture)
{
    DiagnosticTarget? target = null;
    if (policy.Targets.Count > 0)
    {
        var now = DateTimeOffset.UtcNow;
        var highestSpecificity = -1;
        foreach (var candidate in policy.Targets)
        {
            if ((candidate.ExpiresAtUtc is not null && candidate.ExpiresAtUtc <= now) ||
                (candidate.StartsAtUtc is not null && candidate.StartsAtUtc > now) ||
                !Matches(candidate.Component, component) ||
                !Matches(candidate.Operation, operation) ||
                !Matches(candidate.OperationId, operationId) ||
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

        if (target is not null &&
            consumeDiagnosticCapture &&
            !TryConsumeDiagnosticCapture(target))
        {
            target = null;
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
            decision.Depth,
            decision.MatchedTarget?.DiagnosticSessionId,
            decision.MatchedTarget?.AuthorizedFields);
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
            decision.Depth,
            decision.MatchedTarget?.DiagnosticSessionId,
            decision.MatchedTarget?.AuthorizedFields);
    }

    OperationalTelemetryDecision IOperationalTelemetryPolicy.Evaluate(
        string component,
        string? operation,
        string? entity,
        string? recordId,
        string? field,
        string? operationId)
    {
        var decision = Evaluate(
            component,
            operation,
            entity,
            recordId,
            field,
            operationId);
        return new OperationalTelemetryDecision(
            decision.Enabled,
            decision.Level,
            decision.Depth,
            decision.MatchedTarget?.DiagnosticSessionId,
            decision.MatchedTarget?.AuthorizedFields);
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
                        "Foto" => GetFotoMask(policy, operation, recordId),
                        "Album" => GetAlbumMask(policy, operation, recordId),
                        "AlbumFoto" => GetAlbumFotoMask(policy, operation, recordId),
                        "PublicacaoAlbum" => GetPublicacaoAlbumMask(policy, operation, recordId),
                        "yFileUpload" => GetyFileUploadMask(policy, operation, recordId),
                        "ySaga" => GetySagaMask(policy, operation, recordId),
                        "ySagaStep" => GetySagaStepMask(policy, operation, recordId),
                        "yOutbox" => GetyOutboxMask(policy, operation, recordId),
                        "yInbox" => GetyInboxMask(policy, operation, recordId),
                        "yToken" => GetyTokenMask(policy, operation, recordId),
                        "yTenantApplication" => GetyTenantApplicationMask(policy, operation, recordId),
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

                private ulong GetFotoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "Id"))
                        mask |= FotoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "StorageKey"))
                        mask |= FotoTrackingFields.StorageKey;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "NomeOriginal"))
                        mask |= FotoTrackingFields.NomeOriginal;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "ContentType"))
                        mask |= FotoTrackingFields.ContentType;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "HashArquivo"))
                        mask |= FotoTrackingFields.HashArquivo;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "CapturadaEmUtc"))
                        mask |= FotoTrackingFields.CapturadaEmUtc;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "Largura"))
                        mask |= FotoTrackingFields.Largura;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "Altura"))
                        mask |= FotoTrackingFields.Altura;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "Status"))
                        mask |= FotoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "TenantID"))
                        mask |= FotoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "Deleted"))
                        mask |= FotoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "Changed"))
                        mask |= FotoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "UserId"))
                        mask |= FotoTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "Foto", operation, recordId, "OperationalEntityId"))
                        mask |= FotoTrackingFields.OperationalEntityId;
                    return mask;
                }

                private ulong GetAlbumMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "Id"))
                        mask |= AlbumTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "Titulo"))
                        mask |= AlbumTrackingFields.Titulo;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "Descricao"))
                        mask |= AlbumTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "Privacidade"))
                        mask |= AlbumTrackingFields.Privacidade;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "SegundosPorFoto"))
                        mask |= AlbumTrackingFields.SegundosPorFoto;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "Status"))
                        mask |= AlbumTrackingFields.Status;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "TenantID"))
                        mask |= AlbumTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "Deleted"))
                        mask |= AlbumTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "Changed"))
                        mask |= AlbumTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "UserId"))
                        mask |= AlbumTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "Album", operation, recordId, "OperationalEntityId"))
                        mask |= AlbumTrackingFields.OperationalEntityId;
                    return mask;
                }

                private ulong GetAlbumFotoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "Id"))
                        mask |= AlbumFotoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "AlbumId"))
                        mask |= AlbumFotoTrackingFields.AlbumId;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "FotoId"))
                        mask |= AlbumFotoTrackingFields.FotoId;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "Ordem"))
                        mask |= AlbumFotoTrackingFields.Ordem;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "Legenda"))
                        mask |= AlbumFotoTrackingFields.Legenda;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "TenantID"))
                        mask |= AlbumFotoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "Deleted"))
                        mask |= AlbumFotoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "Changed"))
                        mask |= AlbumFotoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "UserId"))
                        mask |= AlbumFotoTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "AlbumFoto", operation, recordId, "OperationalEntityId"))
                        mask |= AlbumFotoTrackingFields.OperationalEntityId;
                    return mask;
                }

                private ulong GetPublicacaoAlbumMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "Id"))
                        mask |= PublicacaoAlbumTrackingFields.Id;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "AlbumId"))
                        mask |= PublicacaoAlbumTrackingFields.AlbumId;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "CorrelationId"))
                        mask |= PublicacaoAlbumTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "ManifestStorageKey"))
                        mask |= PublicacaoAlbumTrackingFields.ManifestStorageKey;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "VideoStorageKey"))
                        mask |= PublicacaoAlbumTrackingFields.VideoStorageKey;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "YouTubeVideoId"))
                        mask |= PublicacaoAlbumTrackingFields.YouTubeVideoId;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "YouTubeUrl"))
                        mask |= PublicacaoAlbumTrackingFields.YouTubeUrl;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "Mensagem"))
                        mask |= PublicacaoAlbumTrackingFields.Mensagem;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "SolicitadaEmUtc"))
                        mask |= PublicacaoAlbumTrackingFields.SolicitadaEmUtc;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "PublicadaEmUtc"))
                        mask |= PublicacaoAlbumTrackingFields.PublicadaEmUtc;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "Status"))
                        mask |= PublicacaoAlbumTrackingFields.Status;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "TenantID"))
                        mask |= PublicacaoAlbumTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "Deleted"))
                        mask |= PublicacaoAlbumTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "Changed"))
                        mask |= PublicacaoAlbumTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "UserId"))
                        mask |= PublicacaoAlbumTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "PublicacaoAlbum", operation, recordId, "OperationalEntityId"))
                        mask |= PublicacaoAlbumTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "OperationalEntityId"))
                        mask |= yFileUploadTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "RootOperationId"))
                        mask |= ySagaTrackingFields.RootOperationId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "OperationId"))
                        mask |= ySagaTrackingFields.OperationId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "ExecutionId"))
                        mask |= ySagaTrackingFields.ExecutionId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "CausationId"))
                        mask |= ySagaTrackingFields.CausationId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "ProcessingScope"))
                        mask |= ySagaTrackingFields.ProcessingScope;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "TenantID"))
                        mask |= ySagaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Deleted"))
                        mask |= ySagaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Changed"))
                        mask |= ySagaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "UserId"))
                        mask |= ySagaTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "OperationalEntityId"))
                        mask |= ySagaTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "RootOperationId"))
                        mask |= ySagaStepTrackingFields.RootOperationId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "OperationId"))
                        mask |= ySagaStepTrackingFields.OperationId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "ExecutionId"))
                        mask |= ySagaStepTrackingFields.ExecutionId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "CausationId"))
                        mask |= ySagaStepTrackingFields.CausationId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "TenantID"))
                        mask |= ySagaStepTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Deleted"))
                        mask |= ySagaStepTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Changed"))
                        mask |= ySagaStepTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "UserId"))
                        mask |= ySagaStepTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "OperationalEntityId"))
                        mask |= ySagaStepTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "RootOperationId"))
                        mask |= yOutboxTrackingFields.RootOperationId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "OperationId"))
                        mask |= yOutboxTrackingFields.OperationId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "ExecutionId"))
                        mask |= yOutboxTrackingFields.ExecutionId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "CausationId"))
                        mask |= yOutboxTrackingFields.CausationId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "SagaId"))
                        mask |= yOutboxTrackingFields.SagaId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "SagaStepId"))
                        mask |= yOutboxTrackingFields.SagaStepId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "ProcessingScope"))
                        mask |= yOutboxTrackingFields.ProcessingScope;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "TenantID"))
                        mask |= yOutboxTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Deleted"))
                        mask |= yOutboxTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Changed"))
                        mask |= yOutboxTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "UserId"))
                        mask |= yOutboxTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "OperationalEntityId"))
                        mask |= yOutboxTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "RootOperationId"))
                        mask |= yInboxTrackingFields.RootOperationId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "OperationId"))
                        mask |= yInboxTrackingFields.OperationId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "ExecutionId"))
                        mask |= yInboxTrackingFields.ExecutionId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "CausationId"))
                        mask |= yInboxTrackingFields.CausationId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "SagaId"))
                        mask |= yInboxTrackingFields.SagaId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "SagaStepId"))
                        mask |= yInboxTrackingFields.SagaStepId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "ProcessingScope"))
                        mask |= yInboxTrackingFields.ProcessingScope;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "TenantID"))
                        mask |= yInboxTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Deleted"))
                        mask |= yInboxTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Changed"))
                        mask |= yInboxTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "UserId"))
                        mask |= yInboxTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "OperationalEntityId"))
                        mask |= yInboxTrackingFields.OperationalEntityId;
                    return mask;
                }

                private ulong GetyTokenMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Id"))
                        mask |= yTokenTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "TokenHash"))
                        mask |= yTokenTrackingFields.TokenHash;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Description"))
                        mask |= yTokenTrackingFields.Description;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "ConnectorKey"))
                        mask |= yTokenTrackingFields.ConnectorKey;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Active"))
                        mask |= yTokenTrackingFields.Active;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "ValidUntil"))
                        mask |= yTokenTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "CreatedAt"))
                        mask |= yTokenTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "LastUsedAt"))
                        mask |= yTokenTrackingFields.LastUsedAt;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "TenantID"))
                        mask |= yTokenTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "UserId"))
                        mask |= yTokenTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Deleted"))
                        mask |= yTokenTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Changed"))
                        mask |= yTokenTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "OperationalEntityId"))
                        mask |= yTokenTrackingFields.OperationalEntityId;
                    return mask;
                }

                private ulong GetyTenantApplicationMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yTenantApplication", operation, recordId, "Id"))
                        mask |= yTenantApplicationTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yTenantApplication", operation, recordId, "ApplicationKey"))
                        mask |= yTenantApplicationTrackingFields.ApplicationKey;
                    if (DomainFieldTracked(policy, "yTenantApplication", operation, recordId, "TenantID"))
                        mask |= yTenantApplicationTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yTenantApplication", operation, recordId, "ValidUntil"))
                        mask |= yTenantApplicationTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yTenantApplication", operation, recordId, "Deleted"))
                        mask |= yTenantApplicationTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yTenantApplication", operation, recordId, "Changed"))
                        mask |= yTenantApplicationTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yTenantApplication", operation, recordId, "UserId"))
                        mask |= yTenantApplicationTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yTenantApplication", operation, recordId, "OperationalEntityId"))
                        mask |= yTenantApplicationTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "OperationalEntityId"))
                        mask |= yTenantTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "OperationalEntityId"))
                        mask |= yUserTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "OperationalEntityId"))
                        mask |= yConfigArctetureTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "OperationalEntityId"))
                        mask |= yConfigNotificationTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "OperationalEntityId"))
                        mask |= yPerfilTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "OperationalEntityId"))
                        mask |= yTenantModuleTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "OperationalEntityId"))
                        mask |= yUserModuleTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "OperationalEntityId"))
                        mask |= yGrantTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "OperationalEntityId"))
                        mask |= yPerfilGrantTrackingFields.OperationalEntityId;
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
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "OperationalEntityId"))
                        mask |= yUserGrantTrackingFields.OperationalEntityId;
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
                        null,
                        false,
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
                        if (target.StartsAtUtc is not null && target.StartsAtUtc > now)
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
        if (!string.IsNullOrWhiteSpace(target.OperationId)) score += 4;
        if (!string.IsNullOrWhiteSpace(target.Entity)) score += 8;
        if (!string.IsNullOrWhiteSpace(target.RecordId)) score += 16;
        if (!string.IsNullOrWhiteSpace(target.Field)) score += 32;
        return score;
    }

    private bool TryConsumeDiagnosticCapture(DiagnosticTarget target)
    {
        if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase))
            return true;
        if (string.IsNullOrWhiteSpace(target.DiagnosticSessionId) ||
            target.MaximumCaptures is not > 0)
        {
            return false;
        }

        var sessionId = target.DiagnosticSessionId;
        var maximum = target.MaximumCaptures.Value;
        while (true)
        {
            var current = _diagnosticCaptureCounts.GetOrAdd(sessionId, 0);
            if (current >= maximum)
                return false;
            if (_diagnosticCaptureCounts.TryUpdate(sessionId, current + 1, current))
                return true;
        }
    }

    private void RemoveInactiveCaptureCounters(OperationalLoggingPolicy policy)
    {
        foreach (var sessionId in _diagnosticCaptureCounts.Keys)
        {
            var active = false;
            foreach (var target in policy.Targets)
            {
                if (string.Equals(
                        target.DiagnosticSessionId,
                        sessionId,
                        StringComparison.OrdinalIgnoreCase))
                {
                    active = true;
                    break;
                }
            }

            if (!active)
                _diagnosticCaptureCounts.TryRemove(sessionId, out _);
        }
    }

    private static IReadOnlyList<DiagnosticTarget> NormalizeAndValidateTargets(
        string defaultLevel,
        string defaultDepth,
        IReadOnlyList<DiagnosticTarget> targets,
        DateTimeOffset now)
    {
        if (!IsLevel(defaultLevel))
            throw new ArgumentException($"Invalid log level '{defaultLevel}'.");
        if (!IsBaselineDepth(defaultDepth))
            throw new ArgumentException("Default depth must be D0 or D1. D2 requires a directed diagnostic session.");

        var normalized = new DiagnosticTarget[targets.Count];
        for (var index = 0; index < targets.Count; index++)
        {
            var target = targets[index];
            if (!IsLevel(target.Level))
                throw new ArgumentException($"Invalid log level '{target.Level}'.");
            if (!IsTargetDepth(target.Depth))
                throw new ArgumentException("Target depth must be D0, D1 or D2.");
            if (target.Level.Equals("Debug", StringComparison.OrdinalIgnoreCase) &&
                target.ExpiresAtUtc is null)
            {
                throw new ArgumentException("Debug targets require expiration.");
            }

            if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase))
            {
                normalized[index] = target;
                continue;
            }

            var authorizedFields = (target.AuthorizedFields ?? [])
                .Where(field => !string.IsNullOrWhiteSpace(field))
                .Select(field => field.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
            if (!string.IsNullOrWhiteSpace(target.Field) &&
                !authorizedFields.Contains(target.Field, StringComparer.OrdinalIgnoreCase))
            {
                authorizedFields = [.. authorizedFields, target.Field.Trim()];
            }

            var normalizedTarget = target with
            {
                DiagnosticSessionId = string.IsNullOrWhiteSpace(target.DiagnosticSessionId)
                    ? Guid.NewGuid().ToString("N")
                    : target.DiagnosticSessionId.Trim(),
                StartsAtUtc = target.StartsAtUtc ?? now,
                RequestedBy = target.RequestedBy?.Trim(),
                ApprovedBy = target.ApprovedBy?.Trim(),
                Justification = target.Justification?.Trim(),
                AuthorizedFields = authorizedFields
            };
            ValidateDiagnosticTarget(normalizedTarget, now);
            normalized[index] = normalizedTarget;
        }

        return normalized;
    }

    private static void ValidateDiagnosticTarget(
        DiagnosticTarget target,
        DateTimeOffset now)
    {
        if (string.IsNullOrWhiteSpace(target.Component) &&
            string.IsNullOrWhiteSpace(target.Operation) &&
            string.IsNullOrWhiteSpace(target.OperationId) &&
            string.IsNullOrWhiteSpace(target.Entity) &&
            string.IsNullOrWhiteSpace(target.RecordId) &&
            string.IsNullOrWhiteSpace(target.Field))
        {
            throw new ArgumentException("D2 requires at least one explicit target selector.");
        }
        if (string.IsNullOrWhiteSpace(target.RequestedBy) ||
            string.IsNullOrWhiteSpace(target.ApprovedBy) ||
            string.IsNullOrWhiteSpace(target.Justification))
        {
            throw new ArgumentException("D2 requires requester, approver and justification.");
        }
        if (target.StartsAtUtc is null ||
            target.ExpiresAtUtc is null ||
            target.ExpiresAtUtc <= target.StartsAtUtc ||
            target.ExpiresAtUtc <= now)
        {
            throw new ArgumentException("D2 requires a valid start and future expiration.");
        }
        if (target.MaximumCaptures is not > 0)
            throw new ArgumentException("D2 requires a positive capture limit.");
        if (target.AuthorizedFields is not { Count: > 0 })
            throw new ArgumentException("D2 requires at least one explicitly authorized field.");
    }

    private static IReadOnlyList<DiagnosticPolicyAuditEntry> BuildDiagnosticAudit(
        OperationalLoggingPolicy current,
        IReadOnlyList<DiagnosticTarget> targets,
        DateTimeOffset now)
    {
        var audit = current.DiagnosticAudit.ToList();
        foreach (var target in targets)
        {
            if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase) ||
                current.Targets.Any(candidate => string.Equals(
                    candidate.DiagnosticSessionId,
                    target.DiagnosticSessionId,
                    StringComparison.OrdinalIgnoreCase)))
            {
                continue;
            }

            audit.Add(new DiagnosticPolicyAuditEntry(
                target.DiagnosticSessionId!,
                "Activated",
                now,
                target.RequestedBy!,
                target.ApprovedBy!,
                target.Justification!));
        }

        foreach (var target in current.Targets)
        {
            if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase) ||
                targets.Any(candidate => string.Equals(
                    candidate.DiagnosticSessionId,
                    target.DiagnosticSessionId,
                    StringComparison.OrdinalIgnoreCase)))
            {
                continue;
            }

            audit.Add(new DiagnosticPolicyAuditEntry(
                target.DiagnosticSessionId!,
                "Ended",
                now,
                target.RequestedBy ?? "unknown",
                target.ApprovedBy ?? "unknown",
                target.Justification ?? "not informed"));
        }

        if (audit.Count > 200)
            audit.RemoveRange(0, audit.Count - 200);
        return audit.ToArray();
    }

    private OperationalLoggingPolicy RefreshExpiredTargets()
    {
        while (true)
        {
            var current = Volatile.Read(ref _current);
            var now = DateTimeOffset.UtcNow;
            var expired = current.Targets
                .Where(target => target.ExpiresAtUtc is not null && target.ExpiresAtUtc <= now)
                .ToArray();
            if (expired.Length == 0)
                return current;

            var active = current.Targets
                .Where(target => target.ExpiresAtUtc is null || target.ExpiresAtUtc > now)
                .ToArray();
            var audit = current.DiagnosticAudit.ToList();
            foreach (var target in expired)
            {
                if (!target.Depth.Equals("D2", StringComparison.OrdinalIgnoreCase) ||
                    audit.Any(entry =>
                        entry.DiagnosticSessionId.Equals(
                            target.DiagnosticSessionId,
                            StringComparison.OrdinalIgnoreCase) &&
                        entry.Action.Equals("Expired", StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                audit.Add(new DiagnosticPolicyAuditEntry(
                    target.DiagnosticSessionId!,
                    "Expired",
                    now,
                    target.RequestedBy ?? "unknown",
                    target.ApprovedBy ?? "unknown",
                    target.Justification ?? "not informed"));
            }

            if (audit.Count > 200)
                audit.RemoveRange(0, audit.Count - 200);
            var updated = current with
            {
                Targets = active,
                DiagnosticAudit = audit.ToArray()
            };
            if (ReferenceEquals(
                    Interlocked.CompareExchange(ref _current, updated, current),
                    current))
            {
                RemoveInactiveCaptureCounters(updated);
                return updated;
            }
        }
    }

    private static bool IsLevel(string value) =>
        value.Equals("Trace", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("Debug", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("Information", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("Warning", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("Error", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("Critical", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("None", StringComparison.OrdinalIgnoreCase);

    private static bool IsBaselineDepth(string value) =>
        value.Equals("D0", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("D1", StringComparison.OrdinalIgnoreCase);

    private static bool IsTargetDepth(string value) =>
        IsBaselineDepth(value) || value.Equals("D2", StringComparison.OrdinalIgnoreCase);

}//Dominio.Schemas.CQRS.SourceCodeInfrastructureOperationalControlStateMigration