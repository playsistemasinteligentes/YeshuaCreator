using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Command.UseCase;
using Clinica.Atendimentos;
using Clinica.Modelos;
namespace Command.Receivers.UseCase;
public partial class AgendarAtendimentoHandler
{
    private readonly ISesoesReadRepository _read;
    private readonly ISesoesWriteRepository _write;
    private readonly IUnitOfWork _uow;
    public AgendarAtendimentoHandler(ILogger logger,IExecutionContext context,ISesoesReadRepository read,ISesoesWriteRepository write,IUnitOfWork uow):base(logger,context)
    { _logger=logger;_executionContext=context;_read=read;_write=write;_uow=uow; }
    protected partial Task<State<AgendarAtendimentoOutputCommand>> CustomActionHookAsync(State<AgendarAtendimentoOutputCommand> state,AgendarAtendimentoInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            _uow.BeginTran();
            if(!DateTimeOffset.TryParse(comand.DataInicio,System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None,out var inicio)
                || !DateTimeOffset.TryParse(comand.DataFim,System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None,out var fim)
                || fim<=inicio || fim-inicio>TimeSpan.FromHours(8) || comand.PacienteId<=0)
                throw new AtendimentoException("Informe paciente e intervalo válido de até oito horas, com fuso horário.");
            if(comand.ServicoId<=0 || !ModelosConsulta.Suporta(comand.ModeloConsulta,comand.VersaoModeloConsulta))
                throw new AtendimentoException("Selecione um serviço com modelo de consulta disponível.");
            var id=_write.AgendarAtendimento(comand.PacienteId,inicio.UtcDateTime,fim.UtcDateTime,comand.ServicoId,comand.ModeloConsulta,comand.VersaoModeloConsulta);
            var result=new AgendarAtendimentoOutputCommand { SessaoId=id,Versao=0 };
            _uow.Commit();
            return Task.FromResult(Success("Operação concluída.",result));
        }
        catch(AtendimentoException e) { _uow.Rollback(); return Task.FromResult(new State<AgendarAtendimentoOutputCommand>(e.Status,e.Message,new())); }
        catch { _uow.Rollback();throw; }
    }
}
