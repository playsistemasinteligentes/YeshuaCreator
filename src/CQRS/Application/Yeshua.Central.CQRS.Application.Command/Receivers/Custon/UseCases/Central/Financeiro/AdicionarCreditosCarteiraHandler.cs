using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Receivers.UseCase;

public partial class AdicionarCreditosCarteiraHandler
{
    private readonly ExecutarFinanceiroHandler _financeiro;
    public AdicionarCreditosCarteiraHandler(ExecutarFinanceiroHandler financeiro, ILogger logger, IExecutionContext context) : this(logger, context)
        => _financeiro = financeiro;
    protected partial async Task<State<AdicionarCreditosCarteiraOutputCommand>> CustomActionHookAsync(
        State<AdicionarCreditosCarteiraOutputCommand> state, AdicionarCreditosCarteiraInputCommand command, CancellationToken cancellationToken)
    {
        var result = await _financeiro.ExecuteAsync(new ExecutarFinanceiroInputCommand
            { Operacao = "adicionar", RequestId = command.RequestId, Creditos = command.Creditos }, cancellationToken);
        return result.StatusCode is >= 200 and < 300
            ? Success(result.Message, FinanceiroResults.Copy<AdicionarCreditosCarteiraOutputCommand>(result.Data))
            : ValidationError(result.Message, new AdicionarCreditosCarteiraOutputCommand());
    }
}
