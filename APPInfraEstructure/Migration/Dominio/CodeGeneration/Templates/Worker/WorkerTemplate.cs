namespace Templates;
public sealed class WorkerTemplate : WorkerBase
{
    private readonly WorkerTemplateReceiver _receiver;

    public WorkerTemplate(WorkerTemplateReceiver receiver)
        : base("InboxWorker", TimeSpan.FromSeconds(5))
    {
        _receiver = receiver;
    }

    protected override Task ExecuteAsync(CancellationToken ct)
    {
        var command = new WorkerTemplateCommand();
        _receiver.Execute(command);
        return Task.CompletedTask;
    }
}
