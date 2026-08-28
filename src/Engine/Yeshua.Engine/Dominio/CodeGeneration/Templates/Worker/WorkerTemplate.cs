namespace Templates;
public sealed class WorkerTemplate : WorkerBase
{
    private readonly WorkerTemplateReceiver _receiver;

    public WorkerTemplate(WorkerTemplateReceiver receiver)
        : base("InboxWorker", TimeSpan.FromSeconds(5))
    {
        _receiver = receiver;
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        var command = new WorkerTemplateCommand();
        await _receiver.ExecuteAsync(command, ct);
    }
}
