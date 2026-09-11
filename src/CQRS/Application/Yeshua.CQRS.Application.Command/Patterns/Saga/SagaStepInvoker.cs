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
        private const string AsyncExecutionMode = "Async";
        private const string SyncExecutionMode = "Sync";
        private readonly ISagaSyncRunner? _syncRunner;

        public SagaStepInvoker(IEnumerable<ISagaSyncRunner> syncRunners)
        {
            _syncRunner = syncRunners.FirstOrDefault();
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
            return Invoke(sagaName, stepName, AsyncExecutionMode, command, state, action, cancellationToken);
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

            if (!IsSync(executionMode))
                return result;

            if (result.Data is not ISagaStepStimulusOutput stimulus)
                return result;

            if (!stimulus.Accepted || stimulus.SagaId <= 0 || stimulus.InboxId <= 0)
                return result;

            if (_syncRunner == null)
                return result;

            await _syncRunner.RunUntilWaitAsync(stimulus, cancellationToken).ConfigureAwait(false);
            return result;
        }

        private static bool IsSync(string executionMode)
            => string.Equals(executionMode, SyncExecutionMode, StringComparison.OrdinalIgnoreCase);
    }
}
