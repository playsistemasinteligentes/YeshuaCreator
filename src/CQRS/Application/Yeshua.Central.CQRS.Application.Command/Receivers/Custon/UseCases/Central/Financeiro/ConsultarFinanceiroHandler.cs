using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Receivers.UseCase;

public partial class ConsultarFinanceiroHandler
{
    private readonly ExecutarFinanceiroHandler _financeiro;
    public ConsultarFinanceiroHandler(ExecutarFinanceiroHandler financeiro, ILogger logger, IExecutionContext context) : base(logger, context)
        => _financeiro = financeiro;
    protected partial async Task<State<ConsultarFinanceiroOutputCommand>> CustomActionHookAsync(
        State<ConsultarFinanceiroOutputCommand> state, ConsultarFinanceiroInputCommand command, CancellationToken cancellationToken)
    {
        var result = await _financeiro.ExecuteAsync(new ExecutarFinanceiroInputCommand { Operacao = "consultar" }, cancellationToken);
        return result.StatusCode is >= 200 and < 300
            ? Success(result.Message, FinanceiroResults.Copy<ConsultarFinanceiroOutputCommand>(result.Data))
            : ValidationError(result.Message, new ConsultarFinanceiroOutputCommand());
    }
}
