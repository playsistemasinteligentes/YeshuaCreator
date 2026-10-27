using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Command.UseCase;
using Clinica.Atendimentos;
namespace Command.Receivers.UseCase;
public partial class CancelarAtendimentoHandler
{
    private readonly ISesoesReadRepository _read;
    private readonly ISesoesWriteRepository _write;
    private readonly IUnitOfWork _uow;
    public CancelarAtendimentoHandler(ILogger logger,IExecutionContext context,ISesoesReadRepository read,ISesoesWriteRepository write,IUnitOfWork uow):base(logger,context)
    { _logger=logger;_executionContext=context;_read=read;_write=write;_uow=uow; }
    protected partial Task<State<CancelarAtendimentoOutputCommand>> CustomActionHookAsync(State<CancelarAtendimentoOutputCommand> state,CancelarAtendimentoInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            _uow.BeginTran();
            var current=_read.ExigirAtendimento(comand.SessaoId);
            AtendimentoRules.Validate(current,comand.Versao,"cancelar");
            _write.TransicionarAtendimento(comand.SessaoId,comand.Versao,"cancelar");
            var result=new CancelarAtendimentoOutputCommand { SessaoId=comand.SessaoId,Versao=comand.Versao+1 };
            _uow.Commit();
            return Task.FromResult(Success("Operação concluída.",result));
        }
        catch(AtendimentoException e) { _uow.Rollback(); return Task.FromResult(new State<CancelarAtendimentoOutputCommand>(e.Status,e.Message,new())); }
        catch { _uow.Rollback();throw; }
    }
}
