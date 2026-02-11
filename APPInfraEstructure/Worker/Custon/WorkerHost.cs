public class WorkerHost
{
    private readonly List<Func<CancellationToken, Task>> _workers = new();

    public void Register(Func<CancellationToken, Task> worker)
    {
        _workers.Add(worker);
    }

    public Task RunAsync(CancellationToken token)
    {
        var tasks = _workers
            .Select(w => Task.Run(() => w(token), token));

        return Task.WhenAll(tasks);
    }
}
