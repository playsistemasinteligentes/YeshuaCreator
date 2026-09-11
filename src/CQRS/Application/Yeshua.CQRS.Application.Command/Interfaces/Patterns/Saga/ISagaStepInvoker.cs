using RepositoryInterfaces.Patterns.Command;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Interfaces
{
    public interface ISagaStepInvoker
    {
        Task<State<TOutput>> Invoke<TInput, TOutput>(
            string sagaName,
            string stepName,
            TInput command,
            State<TOutput> state,
            Func<State<TOutput>, TInput, CancellationToken, Task<State<TOutput>>> action,
            CancellationToken cancellationToken = default)
            where TInput : ICommand
            where TOutput : ICommand;

        Task<State<TOutput>> Invoke<TInput, TOutput>(
            string sagaName,
            string stepName,
            string executionMode,
            TInput command,
            State<TOutput> state,
            Func<State<TOutput>, TInput, CancellationToken, Task<State<TOutput>>> action,
            CancellationToken cancellationToken = default)
            where TInput : ICommand
            where TOutput : ICommand;
    }
}
