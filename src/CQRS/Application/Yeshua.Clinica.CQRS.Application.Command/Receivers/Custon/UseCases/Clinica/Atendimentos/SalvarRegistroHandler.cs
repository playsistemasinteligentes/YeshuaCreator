using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Command.UseCase;
using Clinica.Atendimentos;
namespace Command.Receivers.UseCase;
public partial class SalvarRegistroHandler
{
    private readonly ISesoesReadRepository _read;
    private readonly ISesoesWriteRepository _write;
    private readonly IUnitOfWork _uow;
    public SalvarRegistroHandler(ILogger logger,IExecutionContext context,ISesoesReadRepository read,ISesoesWriteRepository write,IUnitOfWork uow):base(logger,context)
    { _logger=logger;_executionContext=context;_read=read;_write=write;_uow=uow; }
    protected partial Task<State<SalvarRegistroOutputCommand>> CustomActionHookAsync(State<SalvarRegistroOutputCommand> state,SalvarRegistroInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            _uow.BeginTran();
            var current=_read.ExigirAtendimento(comand.SessaoId);
            var registro=new RegistroInput(comand.SessaoId,comand.Versao,comand.Prontuario??"",comand.QueixaPrincipal??"",comand.RegistroDocumental??"",comand.ObjetivosCurtoPrazo??"",comand.ObjetivosLongoPrazo??"",comand.ExerciciosTarefasSugeridas??"",comand.EncaminhamentoOutrosProfissionais??"",comand.FrequenciaSugeridaSessooes??"",comand.InformacoesRelevantesFuturasConsultas??"",comand.Revisado,comand.Motivo??"",comand.IncorporarSagaId);
            AtendimentoRules.Validate(current,comand.Versao,"salvar",registro);
            _write.SalvarAtendimento(registro,false,false);
            var result=new SalvarRegistroOutputCommand { SessaoId=comand.SessaoId,Versao=comand.Versao+1 };
            _uow.Commit();
            return Task.FromResult(Success("Operação concluída.",result));
        }
        catch(AtendimentoException e) { _uow.Rollback(); return Task.FromResult(new State<SalvarRegistroOutputCommand>(e.Status,e.Message,new())); }
        catch { _uow.Rollback();throw; }
    }
}
