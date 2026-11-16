using Aplication.Interfaces.Services;
using Clinica.Atendimentos;
using Command.UseCase;
using Dominio.Interfaces;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase;
public partial class ExecutarRecorrenciaConsultasHandler
{
    private readonly IPlanoRecorrenciaConsultaWriteRepository _write;
    private readonly IUnitOfWork _uow;
    public ExecutarRecorrenciaConsultasHandler(ILogger logger, IExecutionContext context,
        IPlanoRecorrenciaConsultaWriteRepository write, IUnitOfWork uow) : base(logger, context)
    { _logger=logger; _executionContext=context; _write=write; _uow=uow; }
    protected partial Task<State<ExecutarRecorrenciaConsultasOutputCommand>> CustomActionHookAsync(
        State<ExecutarRecorrenciaConsultasOutputCommand> state, ExecutarRecorrenciaConsultasInputCommand comand, CancellationToken cancellationToken)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            _uow.BeginTran();
            ResultadoRecorrencia result;
            var now=DateTime.UtcNow;
            if (comand.Confirmar)
            {
                var c=comand.Confirmacao ?? throw new AtendimentoException("Confirmação ausente.");
                if (c.Ocorrencias is null || c.Ocorrencias.Count is <1 or >CalendarioConsultas.MaximoOcorrencias)
                    throw new AtendimentoException("Informe uma decisão válida para cada ocorrência.");
                foreach (var escolha in c.Ocorrencias)
                    if (escolha is null)
                        throw new AtendimentoException("Informe uma decisão válida para cada ocorrência.");
                result=_write.Confirmar(_executionContext.TenantID,_executionContext.UserId,c.PlanoId,c.Revisado,
                    c.Ocorrencias.Select(x=>new EscolhaRecorrencia(x.Ordem,x.DataInicio,x.DataFim,x.Agendar)).ToList(),now);
            }
            else
            {
                var p=comand.Pedido ?? throw new AtendimentoException("Pedido ausente.");
                result=_write.Prever(_executionContext.TenantID,_executionContext.UserId,
                    new(p.PacienteId,p.ServicoId,p.ModeloConsulta,p.VersaoModeloConsulta,p.DataInicio,p.DataFim,p.IntervaloDias,p.DataFinal,p.SessaoId,p.SerieFutura),now);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _uow.Commit();
            return Task.FromResult(Success("Prévia de consultas.",new ExecutarRecorrenciaConsultasOutputCommand {
                PlanoId=result.PlanoId,Confirmado=result.Confirmado,
                Ocorrencias=result.Ocorrencias.Select(x=>new OcorrenciaRecorrenciaInfo { Ordem=x.Ordem,SessaoId=x.SessaoId,
                    DataInicio=x.DataInicio,DataFim=x.DataFim,Agendar=x.Agendar,Conflito=x.Conflito }).ToList() }));
        }
        catch (AtendimentoException e) { _uow.Rollback(); return Task.FromResult(new State<ExecutarRecorrenciaConsultasOutputCommand>(e.Status,e.Message,new(),false)); }
        catch (ArgumentException e) { _uow.Rollback(); return Task.FromResult(new State<ExecutarRecorrenciaConsultasOutputCommand>(400,e.Message,new(),false)); }
        catch { _uow.Rollback(); throw; }
    }
}
