using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Receivers.UseCase;

public partial class CriarRecargaHandler
{
    private readonly ExecutarFinanceiroHandler _financeiro;
    public CriarRecargaHandler(ExecutarFinanceiroHandler financeiro, ILogger logger, IExecutionContext context) : base(logger, context)
        => _financeiro = financeiro;
    protected partial async Task<State<CriarRecargaOutputCommand>> CustomActionHookAsync(
        State<CriarRecargaOutputCommand> state, CriarRecargaInputCommand command, CancellationToken cancellationToken)
    {
        var result = await _financeiro.ExecuteAsync(new ExecutarFinanceiroInputCommand
            { Operacao = "recarga", RequestId = command.RequestId, Creditos = command.Creditos }, cancellationToken);
        return result.StatusCode is >= 200 and < 300
            ? Success(result.Message, FinanceiroResults.Copy<CriarRecargaOutputCommand>(result.Data))
            : ValidationError(result.Message, new CriarRecargaOutputCommand());
    }
}
