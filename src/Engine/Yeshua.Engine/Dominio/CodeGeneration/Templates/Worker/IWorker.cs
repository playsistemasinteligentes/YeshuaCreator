

namespace Templates
{
    public interface IWorker
    {
        Task RunAsync(CancellationToken ct);
    }
}
