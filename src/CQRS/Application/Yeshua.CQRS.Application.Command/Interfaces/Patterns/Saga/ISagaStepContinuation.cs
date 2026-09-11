using System.Threading;
using System.Threading.Tasks;

namespace Command.Interfaces
{
    public interface ISagaStepContinuation
    {
        Task ContinueUntilWaitAsync(ISagaStepStimulusOutput stimulus, CancellationToken cancellationToken = default);
    }
}
