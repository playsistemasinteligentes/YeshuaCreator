using Command.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Patterns
{
    public class SagaStepInvoker : ISagaStepInvoker
    {
        private const string DeferredExecutionMode = "Deferred";
        private const string ImmediateExecutionMode = "Immediate";
        private readonly ISagaStepContinuation? _continuation;

        public SagaStepInvoker(IEnumerable<ISagaStepContinuation> continuations)
        {
            _continuation = continuations.FirstOrDefault();
        }

        public Task<State<TOutput>> Invoke<TInput, TOutput>(
            string sagaName,
            string stepName,
            TInput command,
            State<TOutput> state,
            Func<State<TOutput>, TInput, CancellationToken, Task<State<TOutput>>> action,
            CancellationToken cancellationToken = default)
            where TInput : ICommand
            where TOutput : ICommand
        {
            return Invoke(sagaName, stepName, DeferredExecutionMode, command, state, action, cancellationToken);
        }

        public async Task<State<TOutput>> Invoke<TInput, TOutput>(
            string sagaName,
            string stepName,
            string executionMode,
            TInput command,
            State<TOutput> state,
            Func<State<TOutput>, TInput, CancellationToken, Task<State<TOutput>>> action,
            CancellationToken cancellationToken = default)
            where TInput : ICommand
            where TOutput : ICommand
        {
            var result = await action(state, command, cancellationToken).ConfigureAwait(false);

            if (!IsImmediate(executionMode))
                return result;

            if (result.Data is not ISagaStepStimulusOutput stimulus)
                return result;

            if (!stimulus.Accepted || stimulus.SagaId <= 0 || stimulus.InboxId <= 0)
                return result;

            if (_continuation == null)
                return result;

            await _continuation.ContinueUntilWaitAsync(stimulus, cancellationToken).ConfigureAwait(false);
            return result;
        }

        private static bool IsImmediate(string executionMode)
            => string.Equals(executionMode, ImmediateExecutionMode, StringComparison.OrdinalIgnoreCase);
    }
}
