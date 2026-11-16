using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Receivers.UseCase;
public partial class PreverRecorrenciaConsultasHandler
{
    private readonly ExecutarRecorrenciaConsultasHandler _executor;
    public PreverRecorrenciaConsultasHandler(ILogger logger,IExecutionContext context,
        ExecutarRecorrenciaConsultasHandler executor):base(logger,context)
    { _logger=logger; _executionContext=context; _executor=executor; }
    protected partial async Task<State<PreverRecorrenciaConsultasOutputCommand>> CustomActionHookAsync(
        State<PreverRecorrenciaConsultasOutputCommand> state,PreverRecorrenciaConsultasInputCommand comand,CancellationToken cancellationToken)
    {
        var result=await _executor.ExecuteAsync(new ExecutarRecorrenciaConsultasInputCommand { Pedido=new RecorrenciaInput { PacienteId=comand.PacienteId,ServicoId=comand.ServicoId,
                ModeloConsulta=comand.ModeloConsulta,VersaoModeloConsulta=comand.VersaoModeloConsulta,
                DataInicio=comand.DataInicio,DataFim=comand.DataFim,IntervaloDias=comand.IntervaloDias,
                DataFinal=comand.DataFinal,SessaoId=comand.SessaoId,SerieFutura=comand.SerieFutura } },cancellationToken);
        if(result.StatusCode>=400)return new State<PreverRecorrenciaConsultasOutputCommand>(result.StatusCode,result.Message,new(),false);
        return new State<PreverRecorrenciaConsultasOutputCommand>(result.StatusCode,result.Message,new() {
            PlanoId=result.Data.PlanoId,Confirmado=result.Data.Confirmado,Ocorrencias=result.Data.Ocorrencias },false);
    }
}
