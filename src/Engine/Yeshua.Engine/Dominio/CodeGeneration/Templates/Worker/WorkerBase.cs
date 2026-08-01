namespace Templates;

public abstract class WorkerBase : IWorker
{
    private readonly TimeSpan _delay;
    private readonly string _name;

    protected WorkerBase(string name, TimeSpan delay)
    {
        _name = name;
        _delay = delay;
    }

    public async Task RunAsync(CancellationToken ct)
    {
        Console.WriteLine($"[{_name}] iniciado");

        while (!ct.IsCancellationRequested)
        {
            try
            {
                await ExecuteAsync(ct);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_name}] erro: {ex.Message}");
            }

            await Task.Delay(_delay, ct);
        }

        Console.WriteLine($"[{_name}] finalizado");
    }

    protected abstract Task ExecuteAsync(CancellationToken ct);
}
