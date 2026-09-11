using System.Threading;
using System.Threading.Tasks;

namespace Command.Interfaces
{
    public interface ISagaSyncRunner
    {
        Task RunUntilWaitAsync(ISagaStepStimulusOutput stimulus, CancellationToken cancellationToken = default);
        Task RunSagaAsync(int sagaId, string? correlationId = null, CancellationToken cancellationToken = default);
    }
}
