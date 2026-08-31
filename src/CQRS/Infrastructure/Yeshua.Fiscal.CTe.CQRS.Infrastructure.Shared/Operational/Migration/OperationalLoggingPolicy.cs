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
                        "CTeEntradaOficial" => GetCTeEntradaOficialMask(policy, operation, recordId),
                        "CTeRomaneioConsolidado" => GetCTeRomaneioConsolidadoMask(policy, operation, recordId),
                        "CTeSolicitacaoFiscal" => GetCTeSolicitacaoFiscalMask(policy, operation, recordId),
                        "CTeDocumentoOriginario" => GetCTeDocumentoOriginarioMask(policy, operation, recordId),
                        "CTeParticipanteSnapshot" => GetCTeParticipanteSnapshotMask(policy, operation, recordId),
                        "CTeTentativaEmissao" => GetCTeTentativaEmissaoMask(policy, operation, recordId),
                        "CTeSaidaMDFe" => GetCTeSaidaMDFeMask(policy, operation, recordId),
                        "yFileUpload" => GetyFileUploadMask(policy, operation, recordId),
                        "ySaga" => GetySagaMask(policy, operation, recordId),
                        "ySagaStep" => GetySagaStepMask(policy, operation, recordId),
                        "yOutbox" => GetyOutboxMask(policy, operation, recordId),
                        "yInbox" => GetyInboxMask(policy, operation, recordId),
                        "yToken" => GetyTokenMask(policy, operation, recordId),
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

                private ulong GetCTeEntradaOficialMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "Id"))
                        mask |= CTeEntradaOficialTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "CorrelationId"))
                        mask |= CTeEntradaOficialTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "SourceApplication"))
                        mask |= CTeEntradaOficialTrackingFields.SourceApplication;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "SourceModule"))
                        mask |= CTeEntradaOficialTrackingFields.SourceModule;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "SourceMessageId"))
                        mask |= CTeEntradaOficialTrackingFields.SourceMessageId;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "MessageType"))
                        mask |= CTeEntradaOficialTrackingFields.MessageType;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "MessageVersion"))
                        mask |= CTeEntradaOficialTrackingFields.MessageVersion;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "ReceivedAtUtc"))
                        mask |= CTeEntradaOficialTrackingFields.ReceivedAtUtc;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "PayloadHash"))
                        mask |= CTeEntradaOficialTrackingFields.PayloadHash;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "PayloadStorageKey"))
                        mask |= CTeEntradaOficialTrackingFields.PayloadStorageKey;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "Status"))
                        mask |= CTeEntradaOficialTrackingFields.Status;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "TenantID"))
                        mask |= CTeEntradaOficialTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "Deleted"))
                        mask |= CTeEntradaOficialTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "Changed"))
                        mask |= CTeEntradaOficialTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CTeEntradaOficial", operation, recordId, "UserId"))
                        mask |= CTeEntradaOficialTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCTeRomaneioConsolidadoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "Id"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "EntradaOficialId"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.EntradaOficialId;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "CorrelationId"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "RomaneioId"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.RomaneioId;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "CargaId"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.CargaId;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "ConsolidadoEmUtc"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.ConsolidadoEmUtc;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "UFInicio"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.UFInicio;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "UFFim"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.UFFim;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "MunicipioInicioCodigoIbge"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.MunicipioInicioCodigoIbge;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "MunicipioFimCodigoIbge"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.MunicipioFimCodigoIbge;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "EmitenteDocumento"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.EmitenteDocumento;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "TomadorDocumento"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.TomadorDocumento;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "RotaSnapshotJson"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.RotaSnapshotJson;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "CargaSnapshotJson"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.CargaSnapshotJson;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "PreferenciasFiscaisJson"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.PreferenciasFiscaisJson;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "Status"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "TenantID"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "Deleted"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "Changed"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CTeRomaneioConsolidado", operation, recordId, "UserId"))
                        mask |= CTeRomaneioConsolidadoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCTeSolicitacaoFiscalMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "Id"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "EntradaOficialId"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.EntradaOficialId;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "RomaneioConsolidadoId"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.RomaneioConsolidadoId;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "CorrelationId"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "Ambiente"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.Ambiente;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "UFEmitente"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.UFEmitente;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "EmitenteDocumento"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.EmitenteDocumento;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "ProdutoFiscal"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.ProdutoFiscal;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "TipoCTe"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.TipoCTe;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "TipoServico"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.TipoServico;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "Modal"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.Modal;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "Globalizado"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.Globalizado;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "UFInicio"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.UFInicio;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "UFFim"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.UFFim;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "MunicipioInicioCodigoIbge"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.MunicipioInicioCodigoIbge;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "MunicipioFimCodigoIbge"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.MunicipioFimCodigoIbge;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "ValorServico"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.ValorServico;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "ValorCarga"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.ValorCarga;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "PreferenciasManifestoJson"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.PreferenciasManifestoJson;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "Status"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.Status;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "TenantID"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "Deleted"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "Changed"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CTeSolicitacaoFiscal", operation, recordId, "UserId"))
                        mask |= CTeSolicitacaoFiscalTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCTeDocumentoOriginarioMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "Id"))
                        mask |= CTeDocumentoOriginarioTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "CTeSolicitacaoFiscalId"))
                        mask |= CTeDocumentoOriginarioTrackingFields.CTeSolicitacaoFiscalId;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "TipoDocumento"))
                        mask |= CTeDocumentoOriginarioTrackingFields.TipoDocumento;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "ChaveAcesso"))
                        mask |= CTeDocumentoOriginarioTrackingFields.ChaveAcesso;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "Numero"))
                        mask |= CTeDocumentoOriginarioTrackingFields.Numero;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "Serie"))
                        mask |= CTeDocumentoOriginarioTrackingFields.Serie;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "EmitenteDocumento"))
                        mask |= CTeDocumentoOriginarioTrackingFields.EmitenteDocumento;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "DestinatarioDocumento"))
                        mask |= CTeDocumentoOriginarioTrackingFields.DestinatarioDocumento;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "ValorDocumento"))
                        mask |= CTeDocumentoOriginarioTrackingFields.ValorDocumento;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "PesoBruto"))
                        mask |= CTeDocumentoOriginarioTrackingFields.PesoBruto;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "SnapshotJson"))
                        mask |= CTeDocumentoOriginarioTrackingFields.SnapshotJson;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "TenantID"))
                        mask |= CTeDocumentoOriginarioTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "Deleted"))
                        mask |= CTeDocumentoOriginarioTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "Changed"))
                        mask |= CTeDocumentoOriginarioTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CTeDocumentoOriginario", operation, recordId, "UserId"))
                        mask |= CTeDocumentoOriginarioTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCTeParticipanteSnapshotMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "Id"))
                        mask |= CTeParticipanteSnapshotTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "CTeSolicitacaoFiscalId"))
                        mask |= CTeParticipanteSnapshotTrackingFields.CTeSolicitacaoFiscalId;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "Papel"))
                        mask |= CTeParticipanteSnapshotTrackingFields.Papel;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "Documento"))
                        mask |= CTeParticipanteSnapshotTrackingFields.Documento;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "Nome"))
                        mask |= CTeParticipanteSnapshotTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "InscricaoEstadual"))
                        mask |= CTeParticipanteSnapshotTrackingFields.InscricaoEstadual;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "UF"))
                        mask |= CTeParticipanteSnapshotTrackingFields.UF;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "MunicipioCodigoIbge"))
                        mask |= CTeParticipanteSnapshotTrackingFields.MunicipioCodigoIbge;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "EnderecoJson"))
                        mask |= CTeParticipanteSnapshotTrackingFields.EnderecoJson;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "TenantID"))
                        mask |= CTeParticipanteSnapshotTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "Deleted"))
                        mask |= CTeParticipanteSnapshotTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "Changed"))
                        mask |= CTeParticipanteSnapshotTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CTeParticipanteSnapshot", operation, recordId, "UserId"))
                        mask |= CTeParticipanteSnapshotTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCTeTentativaEmissaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "Id"))
                        mask |= CTeTentativaEmissaoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "CTeSolicitacaoFiscalId"))
                        mask |= CTeTentativaEmissaoTrackingFields.CTeSolicitacaoFiscalId;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "ChaveAcesso"))
                        mask |= CTeTentativaEmissaoTrackingFields.ChaveAcesso;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "Numero"))
                        mask |= CTeTentativaEmissaoTrackingFields.Numero;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "Serie"))
                        mask |= CTeTentativaEmissaoTrackingFields.Serie;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "Tentativa"))
                        mask |= CTeTentativaEmissaoTrackingFields.Tentativa;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "XmlAssinadoStorageKey"))
                        mask |= CTeTentativaEmissaoTrackingFields.XmlAssinadoStorageKey;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "XmlProcStorageKey"))
                        mask |= CTeTentativaEmissaoTrackingFields.XmlProcStorageKey;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "XmlHash"))
                        mask |= CTeTentativaEmissaoTrackingFields.XmlHash;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "CodigoRetorno"))
                        mask |= CTeTentativaEmissaoTrackingFields.CodigoRetorno;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "MensagemRetorno"))
                        mask |= CTeTentativaEmissaoTrackingFields.MensagemRetorno;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "ProtocoloAutorizacao"))
                        mask |= CTeTentativaEmissaoTrackingFields.ProtocoloAutorizacao;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "EnviadoEmUtc"))
                        mask |= CTeTentativaEmissaoTrackingFields.EnviadoEmUtc;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "AutorizadoEmUtc"))
                        mask |= CTeTentativaEmissaoTrackingFields.AutorizadoEmUtc;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "Status"))
                        mask |= CTeTentativaEmissaoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "TenantID"))
                        mask |= CTeTentativaEmissaoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "Deleted"))
                        mask |= CTeTentativaEmissaoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "Changed"))
                        mask |= CTeTentativaEmissaoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CTeTentativaEmissao", operation, recordId, "UserId"))
                        mask |= CTeTentativaEmissaoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCTeSaidaMDFeMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "Id"))
                        mask |= CTeSaidaMDFeTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "CTeTentativaEmissaoId"))
                        mask |= CTeSaidaMDFeTrackingFields.CTeTentativaEmissaoId;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "CorrelationId"))
                        mask |= CTeSaidaMDFeTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "ChaveAcessoCTe"))
                        mask |= CTeSaidaMDFeTrackingFields.ChaveAcessoCTe;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "SnapshotHash"))
                        mask |= CTeSaidaMDFeTrackingFields.SnapshotHash;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "OutboxMessageId"))
                        mask |= CTeSaidaMDFeTrackingFields.OutboxMessageId;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "PublicadoEmUtc"))
                        mask |= CTeSaidaMDFeTrackingFields.PublicadoEmUtc;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "UltimoErro"))
                        mask |= CTeSaidaMDFeTrackingFields.UltimoErro;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "Status"))
                        mask |= CTeSaidaMDFeTrackingFields.Status;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "TenantID"))
                        mask |= CTeSaidaMDFeTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "Deleted"))
                        mask |= CTeSaidaMDFeTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "Changed"))
                        mask |= CTeSaidaMDFeTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CTeSaidaMDFe", operation, recordId, "UserId"))
                        mask |= CTeSaidaMDFeTrackingFields.UserId;
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