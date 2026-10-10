using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Dominio.Operational;
using IRepository.Read;
using IRepository.Write;
using Microsoft.Extensions.Configuration;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Patterns.Worker;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Worker.Custon;

public sealed class YeshuaModuleHttpOutboxTransportWorker
    : ReciverBase<YeshuaModuleHttpOutboxTransportInputCommand, YeshuaModuleHttpOutboxTransportOutputCommand>
{
    private const int Pending = 0;
    private const int Processing = 1;
    private const int Delivered = 2;
    private const int Retry = 3;
    private const int DeadLetter = 9;
    private const int TransportYeshuaApi = 2;

    private readonly IyOutboxReadRepository _outboxReadRepository;
    private readonly IyOutboxWriteRepository _outboxWriteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IExecutionContext _executionContext;
    private readonly Dominio.Interfaces.ILogger _logger;

    public YeshuaModuleHttpOutboxTransportWorker(
        IyOutboxReadRepository outboxReadRepository,
        IyOutboxWriteRepository outboxWriteRepository,
        IUnitOfWork unitOfWork,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        Dominio.Interfaces.ILogger logger,
        IExecutionContext context)
        : base(logger, context)
    {
        _outboxReadRepository = outboxReadRepository;
        _outboxWriteRepository = outboxWriteRepository;
        _unitOfWork = unitOfWork;
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _executionContext = context;
        _logger = logger;
    }

    protected override async Task<State<YeshuaModuleHttpOutboxTransportOutputCommand>> ActionAsync(
        YeshuaModuleHttpOutboxTransportInputCommand command,
        CancellationToken cancellationToken = default)
    {
        var processed = 0;
        var failed = 0;

        var pending = _outboxReadRepository
            .GetAllByStatus(Pending, true)
            .Where(x => x.transporttype == TransportYeshuaApi)
            .Take(command.Limit <= 0 ? 10 : command.Limit)
            .ToList();

        foreach (var item in pending)
        {
            var parentIdentity = ReadIdentity(item);
            var telemetry = _logger.Evaluate(
                "Worker",
                "Outbox.YeshuaApi.Deliver",
                "yOutbox",
                item.operationalentityid);
            using var executionScope = !telemetry.Enabled ||
                string.IsNullOrWhiteSpace(parentIdentity.RootOperationId)
                ? null
                : _executionContext.BeginOperationalExecution(
                    parentIdentity,
                    "Outbox.YeshuaApi.Deliver");
            var deliveryIdentity = executionScope is null
                ? parentIdentity
                : _executionContext.OperationalIdentity;

            try
            {
                if (executionScope is not null)
                    PersistDeliveryIdentity(item, deliveryIdentity);
                MarkProcessing(item.id);
                await DeliverAsync(item, deliveryIdentity, cancellationToken);
                MarkDelivered(item.id);
                processed++;
            }
            catch (Exception ex)
            {
                failed++;
                MarkRetryOrDead(item, ex.Message);
            }
        }

        return Success("OK", new YeshuaModuleHttpOutboxTransportOutputCommand
        {
            Claimed = pending.Count,
            Processed = processed,
            Failed = failed
        });
    }

    private async Task DeliverAsync(
        yOutboxDTO item,
        OperationalExecutionIdentity identity,
        CancellationToken cancellationToken)
    {
        var transport = YeshuaModuleApiTransportData.Parse(item.transportdata);
        var baseUrl = ResolveBaseUrl(transport);
        var endpoint = string.IsNullOrWhiteSpace(transport.Endpoint)
            ? "/yapi/" + transport.TargetModule + "/Inbox/YeshuaModuleEvent"
            : transport.Endpoint;

        var uri = new Uri(new Uri(baseUrl.TrimEnd('/') + "/"), endpoint.TrimStart('/'));
        var envelope = JsonSerializer.Serialize(new
        {
            tenantId = item.tenantid,
            messageId = item.messageid,
            type = item.type,
            entityType = item.entitytype,
            entityId = item.entityid,
            correlationId = item.correlationid,
            payload = item.payload,
            source = "yOutbox",
            transport = "YeshuaApi",
            rootOperationId = identity.RootOperationId,
            operationId = identity.OperationId,
            executionId = identity.ExecutionId,
            causationId = identity.CausationId
        });

        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = new StringContent(envelope, Encoding.UTF8, "application/json");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.TryAddWithoutValidation(
            Shared.ModuleTransport.YeshuaModuleAuthenticationHeaders.MessageId,
            item.messageid);
        AddOperationalHeader(request, OperationalExecutionHeaders.RootOperationId, identity.RootOperationId);
        AddOperationalHeader(request, OperationalExecutionHeaders.OperationId, identity.OperationId);
        AddOperationalHeader(request, OperationalExecutionHeaders.ExecutionId, identity.ExecutionId);
        AddOperationalHeader(request, OperationalExecutionHeaders.CausationId, identity.CausationId);

        var response = await _httpClientFactory.CreateClient("YeshuaModuleApiTransport")
            .SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new InvalidOperationException("HTTP " + (int)response.StatusCode + " ao entregar outbox " + item.id + ": " + body);
        }
    }

    private void PersistDeliveryIdentity(
        yOutboxDTO item,
        OperationalExecutionIdentity identity)
    {
        if (string.IsNullOrWhiteSpace(identity.RootOperationId))
            return;

        _outboxWriteRepository.UpdateRootOperationId(item.id, identity.RootOperationId);
        _outboxWriteRepository.UpdateOperationId(item.id, identity.OperationId!);
        _outboxWriteRepository.UpdateExecutionId(item.id, identity.ExecutionId!);
        if (!string.IsNullOrWhiteSpace(identity.CausationId))
            _outboxWriteRepository.UpdateCausationId(item.id, identity.CausationId);

        item.rootoperationid = identity.RootOperationId;
        item.operationid = identity.OperationId ?? string.Empty;
        item.executionid = identity.ExecutionId ?? string.Empty;
        item.causationid = identity.CausationId ?? string.Empty;
    }

    private static OperationalExecutionIdentity ReadIdentity(yOutboxDTO item) =>
        new(
            EmptyToNull(item.rootoperationid),
            EmptyToNull(item.operationid),
            EmptyToNull(item.executionid),
            EmptyToNull(item.causationid));

    private static void AddOperationalHeader(
        HttpRequestMessage request,
        string name,
        string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            request.Headers.TryAddWithoutValidation(name, value);
    }

    private static string? EmptyToNull(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value;

    private string ResolveBaseUrl(YeshuaModuleApiTransportData transport)
    {
        if (!string.IsNullOrWhiteSpace(transport.BaseUrl))
            return transport.BaseUrl;

        if (!string.IsNullOrWhiteSpace(transport.BaseUrlConfigurationKey))
        {
            var configured = _configuration[transport.BaseUrlConfigurationKey];
            if (!string.IsNullOrWhiteSpace(configured))
                return configured;
        }

        throw new InvalidOperationException("BaseUrl do transporte YeshuaApi nao configurada para " + transport.TargetModule + ".");
    }

    private void MarkProcessing(int id)
    {
        _outboxWriteRepository.UpdateStatus(id, Processing);
        _outboxWriteRepository.UpdateProcessingAt(id, DateTime.UtcNow);
        _unitOfWork.Commit();
    }

    private void MarkDelivered(int id)
    {
        _outboxWriteRepository.UpdateStatus(id, Delivered);
        _outboxWriteRepository.UpdateSentAt(id, DateTime.UtcNow);
        _unitOfWork.Commit();
    }

    private void MarkRetryOrDead(yOutboxDTO item, string error)
    {
        var retry = item.retrycount + 1;
        _outboxWriteRepository.UpdateRetryCount(item.id, retry);
        _outboxWriteRepository.UpdateLastError(item.id, error);

        if (retry >= 5)
        {
            _outboxWriteRepository.UpdateStatus(item.id, DeadLetter);
        }
        else
        {
            _outboxWriteRepository.UpdateStatus(item.id, Retry);
            _outboxWriteRepository.UpdateNextAttemptAt(item.id, DateTime.UtcNow.AddSeconds(Math.Pow(2, retry)));
        }

        _unitOfWork.Commit();
    }

    private sealed class YeshuaModuleApiTransportData
    {
        public string TargetModule { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;
        public string BaseUrlConfigurationKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;

        public static YeshuaModuleApiTransportData Parse(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return new YeshuaModuleApiTransportData();

            return JsonSerializer.Deserialize<YeshuaModuleApiTransportData>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new YeshuaModuleApiTransportData();
        }
    }
}

public sealed record YeshuaModuleHttpOutboxTransportInputCommand : ICommand
{
    public int Limit { get; init; } = 10;
}

public sealed record YeshuaModuleHttpOutboxTransportOutputCommand : ICommand, IWorkerCycleResult
{
    public int BatchLimit => 10;
    public int Claimed { get; init; }
    public int Processed { get; init; }
    public int Failed { get; init; }
}
