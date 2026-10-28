// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class DefinirServicoHabitualHandler
    {
        private readonly ISesoesWriteRepository _write;
        private readonly IUnitOfWork _uow;
        public DefinirServicoHabitualHandler(ILogger logger,IExecutionContext context,ISesoesWriteRepository write,IUnitOfWork uow):base(logger,context)
        { _write=write;_uow=uow; }
protected partial Task<State<DefinirServicoHabitualOutputCommand>> CustomActionHookAsync(State<DefinirServicoHabitualOutputCommand> state, DefinirServicoHabitualInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        _uow.BeginTran();
        if(comand.ServicoId<0)throw new Clinica.Atendimentos.AtendimentoException("Escolha um serviço válido.");
        var s=_write.DefinirServicoHabitual(comand.ServicoId);
        _uow.Commit();
        return Task.FromResult(Success("Serviço habitual definido para sua agenda.",new DefinirServicoHabitualOutputCommand {
            Id=s.Id,Nome=s.Nome,ModeloConsulta=s.ModeloConsulta,VersaoModeloConsulta=s.VersaoModeloConsulta
        }));
    }
    catch(Clinica.Atendimentos.AtendimentoException e)
    { _uow.Rollback();return Task.FromResult(new State<DefinirServicoHabitualOutputCommand>(e.Status,e.Message,new())); }
    catch { _uow.Rollback();throw; }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
