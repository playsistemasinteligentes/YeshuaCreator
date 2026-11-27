using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Json.Schema;
using Aplication.Interfaces.Services;

namespace Central.BusinessMcp;

public sealed class BusinessMcpReceiver(TrustedBusinessCatalog catalog, DelegatedAccess access,
    IBusinessPermissionReader permissions, IApplicationDelegationSender sender, IBusinessAuditWriter audit)
{
    public async Task<IReadOnlyList<BusinessApplication>> ApplicationsAsync(ClaimsPrincipal user, CancellationToken ct)
    {
        var operations = await OperationsAsync(user, null, ct);
        return operations.Select(o => o.Application).Distinct(StringComparer.Ordinal).Order()
            .Select(app => new BusinessApplication(app)).ToArray();
    }
    public async Task<IReadOnlyList<BusinessOperation>> OperationsAsync(ClaimsPrincipal user, string? application, CancellationToken ct)
    {
        var identity = await access.RequireAsync(user, ct);
        if (!identity.Scopes.Contains("business:discover")) throw new BusinessAccessException("insufficient_scope");
        var result = new List<BusinessOperation>();
        foreach (var entry in catalog.Entries.Where(e => application is null || e.Contract.Application == application))
            if (await Allowed(identity, entry, ct)) result.Add(entry.Contract);
        return result.OrderBy(c => c.Application).ThenBy(c => c.Id).ToArray();
    }
    private Task<bool> Allowed(DelegatedIdentity identity, TrustedBusinessCatalog.Entry entry, CancellationToken ct) =>
        identity.Scopes.Contains(entry.Scope)
            ? permissions.AllowsAsync(identity, entry.Contract.Application, entry.Grant, ct)
            : Task.FromResult(false);

    public async Task<BusinessResult> ExecuteAsync(ClaimsPrincipal user, ExecuteBusinessOperation command, CancellationToken ct)
    {
        var correlation = Activity.Current?.TraceId.ToString() ?? ActivityTraceId.CreateRandom().ToString();
        var identity = await access.RequireAsync(user, ct);
        var entry = catalog.Find(command.Application, command.Operation);
        var outcome = "outcome_unknown";
        int? status = null;
        // Write intent before sending. An unavailable audit sink must prevent a side effect.
        // No request/response payload, token, email, name, or exception message is audited.
        await Audit("requested", ct);
        try
        {
            if (entry is null || !await Allowed(identity, entry, ct))
            {
                outcome = "operation_not_allowed";
                return new(outcome, correlation);
            }
            if (command.Parameters.ValueKind != JsonValueKind.Object
                || Encoding.UTF8.GetByteCount(command.Parameters.GetRawText()) > 65536
                || !entry.Validator.Evaluate(JsonNode.Parse(command.Parameters.GetRawText()),
                    new EvaluationOptions { RequireFormatValidation = true }).IsValid)
            {
                outcome = "invalid_parameters";
                return new(outcome, correlation);
            }
            using var request = new HttpRequestMessage(HttpMethod.Post, entry.Target)
            {
                Content = new StringContent(command.Parameters.GetRawText(), Encoding.UTF8, "application/json")
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.TryAddWithoutValidation("traceparent", $"00-{correlation}-{ActivitySpanId.CreateRandom()}-01");
            var executionState = new OperationalExecutionIdentityState(rootOperationId: correlation);
            using var executionScope = executionState.Begin(entry.Contract.Id);
            var execution = executionState.Current;
            request.Headers.TryAddWithoutValidation(OperationalExecutionHeaders.RootOperationId, execution.RootOperationId);
            request.Headers.TryAddWithoutValidation(OperationalExecutionHeaders.OperationId, execution.OperationId);
            request.Headers.TryAddWithoutValidation(OperationalExecutionHeaders.ExecutionId, execution.ExecutionId);
            // Sender must disable redirects/retries and authorize at the destination;
            // this module never reads or forwards the incoming Authorization header.
            using var deadline = CancellationTokenSource.CreateLinkedTokenSource(ct);
            deadline.CancelAfter(TimeSpan.FromSeconds(30));
            using var response = await sender.SendAsync(identity, entry.Contract.Application, entry.Grant, request, deadline.Token);
            status = (int)response.StatusCode;
            if (status == 202)
            {
                // Accepted is not completion. No follow-up URL is executed or trusted.
                outcome = "accepted";
                return new(outcome, correlation, status);
            }
            if (status != 200)
            {
                outcome = status switch
                {
                    401 or 403 => "destination_denied",
                    409 => "conflict",
                    400 or 422 => "destination_rejected",
                    429 => "rate_limited",
                    _ => "destination_failed"
                };
                return new(outcome, correlation, status);
            }
            if (response.Content.Headers.ContentType?.MediaType != "application/json")
            {
                outcome = "invalid_destination_response";
                return new(outcome, correlation, status);
            }
            await using var body = await response.Content.ReadAsStreamAsync(deadline.Token);
            using var buffer = new MemoryStream();
            var chunk = new byte[8192];
            int count;
            while ((count = await body.ReadAsync(chunk, deadline.Token)) > 0)
            {
                if (buffer.Length + count > 1048576) throw new JsonException();
                buffer.Write(chunk, 0, count);
            }
            using var data = JsonDocument.Parse(buffer.ToArray());
            if (!JsonSchema.FromText(entry.Contract.OutputSchema.GetRawText()).Evaluate(
                    JsonNode.Parse(data.RootElement.GetRawText()), new EvaluationOptions { RequireFormatValidation = true }).IsValid)
            {
                outcome = "invalid_destination_response";
                return new(outcome, correlation, status);
            }
            outcome = "completed";
            return new(outcome, correlation, status, data.RootElement.Clone());
        }
        catch (JsonException) { outcome = "invalid_destination_response"; return new(outcome, correlation, status); }
        catch (HttpRequestException) { outcome = "destination_unavailable"; return new(outcome, correlation); }
        catch (OperationCanceledException)
        {
            // A timeout does not prove that the command failed. Never retry mutations here.
            outcome = "outcome_unknown";
            return new(outcome, correlation);
        }
        catch (Exception)
        {
            // Adapter exceptions can contain private URLs or provider diagnostics.
            // Do not expose them or infer that a mutation is safe to retry.
            outcome = "outcome_unknown";
            return new(outcome, correlation, status);
        }
        finally { await Audit(outcome, CancellationToken.None); }

        Task Audit(string value, CancellationToken token) => audit.WriteAsync(new(identity.Subject, identity.TenantId,
            identity.ClientId, entry?.Contract.Application ?? "unknown", entry?.Contract.Id ?? "unknown", correlation, value, status), token);
    }
}
