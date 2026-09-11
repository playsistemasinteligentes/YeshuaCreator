using Command.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Patterns
{
    public class SagaStepInvoker : ISagaStepInvoker
    {
        private const string AsyncExecutionMode = "Async";

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

        public Task<State<TOutput>> Invoke<TInput, TOutput>(
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
            // pendencia: quando executionMode for Sync, aplicar o estimulo e executar a saga
            // ate o proximo StepWait/falha/fim, sem depender do ciclo do worker.
            return action(state, command, cancellationToken);
        }
    }
}
