using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Receivers.UseCase;

public partial class ContratarUsoHandler
{
    private readonly ExecutarFinanceiroHandler _financeiro;
    public ContratarUsoHandler(ExecutarFinanceiroHandler financeiro, ILogger logger, IExecutionContext context) : this(logger, context)
        => _financeiro = financeiro;
    protected partial async Task<State<ContratarUsoOutputCommand>> CustomActionHookAsync(
        State<ContratarUsoOutputCommand> state, ContratarUsoInputCommand command, CancellationToken cancellationToken)
    {
        var result = await _financeiro.ExecuteAsync(new ExecutarFinanceiroInputCommand
            { Operacao = "alocar", RequestId = command.RequestId, Oferta = command.Oferta, Quantidade = command.Quantidade }, cancellationToken);
        return result.StatusCode is >= 200 and < 300
            ? Success(result.Message, FinanceiroResults.Copy<ContratarUsoOutputCommand>(result.Data))
            : ValidationError(result.Message, new ContratarUsoOutputCommand());
    }
}
