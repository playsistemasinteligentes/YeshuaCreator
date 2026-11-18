using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Receivers.UseCase;

public partial class AtualizarAcessoHandler
{
    private readonly ExecutarFinanceiroHandler _financeiro;
    public AtualizarAcessoHandler(ExecutarFinanceiroHandler financeiro, ILogger logger, IExecutionContext context) : this(logger, context)
        => _financeiro = financeiro;
    protected partial async Task<State<AtualizarAcessoOutputCommand>> CustomActionHookAsync(
        State<AtualizarAcessoOutputCommand> state, AtualizarAcessoInputCommand command, CancellationToken cancellationToken)
    {
        var result = await _financeiro.ExecuteAsync(new ExecutarFinanceiroInputCommand { Operacao = "atualizar" }, cancellationToken);
        return result.StatusCode is >= 200 and < 300
            ? Success(result.Message, FinanceiroResults.Copy<AtualizarAcessoOutputCommand>(result.Data))
            : ValidationError(result.Message, new AtualizarAcessoOutputCommand());
    }
}
