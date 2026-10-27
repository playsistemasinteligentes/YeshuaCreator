using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Command.UseCase;
using Clinica.Atendimentos;
namespace Command.Receivers.UseCase;
public partial class VincularProfissionalHandler
{
    private readonly ISesoesReadRepository _read;
    private readonly ISesoesWriteRepository _write;
    private readonly IUnitOfWork _uow;
    public VincularProfissionalHandler(ILogger logger,IExecutionContext context,ISesoesReadRepository read,ISesoesWriteRepository write,IUnitOfWork uow):base(logger,context)
    { _logger=logger;_executionContext=context;_read=read;_write=write;_uow=uow; }
    protected partial Task<State<VincularProfissionalOutputCommand>> CustomActionHookAsync(State<VincularProfissionalOutputCommand> state,VincularProfissionalInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            _uow.BeginTran();
            if(!_executionContext.Claims.Any(c=>(c.Type==System.Security.Claims.ClaimTypes.Role || c.Type=="role") &&
                (c.Value.Equals("Admin",StringComparison.OrdinalIgnoreCase) || c.Value.Equals("Administrator",StringComparison.OrdinalIgnoreCase))))
                throw new AtendimentoException("Somente um administrador pode vincular usuários a profissionais.",403);
            if(comand.ProfissionalId<=0 || comand.UsuarioId<=0)throw new AtendimentoException("Informe profissional e usuário.");
            _write.VincularProfissional(comand.ProfissionalId,comand.UsuarioId);
            var result=new VincularProfissionalOutputCommand();
            _uow.Commit();
            return Task.FromResult(Success("Operação concluída.",result));
        }
        catch(AtendimentoException e) { _uow.Rollback(); return Task.FromResult(new State<VincularProfissionalOutputCommand>(e.Status,e.Message,new())); }
        catch { _uow.Rollback();throw; }
    }
}
