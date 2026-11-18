using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Receivers.UseCase;

public partial class ConfirmarPagamentoTesteHandler
{
    private readonly ExecutarFinanceiroHandler _financeiro;
    public ConfirmarPagamentoTesteHandler(ExecutarFinanceiroHandler financeiro, ILogger logger, IExecutionContext context) : base(logger, context)
        => _financeiro = financeiro;
    protected partial async Task<State<ConfirmarPagamentoTesteOutputCommand>> CustomActionHookAsync(
        State<ConfirmarPagamentoTesteOutputCommand> state, ConfirmarPagamentoTesteInputCommand command, CancellationToken cancellationToken)
    {
        var result = await _financeiro.ExecuteAsync(new ExecutarFinanceiroInputCommand
            { Operacao = "confirmar", CobrancaId = command.CobrancaId }, cancellationToken);
        return result.StatusCode is >= 200 and < 300
            ? Success(result.Message, FinanceiroResults.Copy<ConfirmarPagamentoTesteOutputCommand>(result.Data))
            : ValidationError(result.Message, new ConfirmarPagamentoTesteOutputCommand());
    }
}
