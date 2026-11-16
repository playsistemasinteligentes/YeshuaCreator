using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Receivers.UseCase;
public partial class ConfirmarRecorrenciaConsultasHandler
{
    private readonly ExecutarRecorrenciaConsultasHandler _executor;
    public ConfirmarRecorrenciaConsultasHandler(ILogger logger,IExecutionContext context,
        ExecutarRecorrenciaConsultasHandler executor):base(logger,context)
    { _logger=logger; _executionContext=context; _executor=executor; }
    protected partial async Task<State<ConfirmarRecorrenciaConsultasOutputCommand>> CustomActionHookAsync(
        State<ConfirmarRecorrenciaConsultasOutputCommand> state,ConfirmarRecorrenciaConsultasInputCommand comand,CancellationToken cancellationToken)
    {
        var result=await _executor.ExecuteAsync(new ExecutarRecorrenciaConsultasInputCommand { Confirmar=true,Confirmacao=new ConfirmacaoRecorrenciaInput { PlanoId=comand.PlanoId,Revisado=comand.Revisado,
                Ocorrencias=comand.Ocorrencias } },cancellationToken);
        if(result.StatusCode>=400)return new State<ConfirmarRecorrenciaConsultasOutputCommand>(result.StatusCode,result.Message,new(),false);
        return new State<ConfirmarRecorrenciaConsultasOutputCommand>(result.StatusCode,result.Message,new() {
            PlanoId=result.Data.PlanoId,Confirmado=result.Data.Confirmado,Ocorrencias=result.Data.Ocorrencias },false);
    }
}
