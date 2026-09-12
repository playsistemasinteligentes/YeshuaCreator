// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class LoginHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyUserReadRepository _repReadyUser = default!;
        private readonly IyUserWriteRepository _repWriteyUser = default!;
        private readonly IyTenantModuleReadRepository _repReadyTenantModule = default!;
        private readonly IyTenantModuleWriteRepository _repWriteyTenantModule = default!;
        private readonly IyUserModuleReadRepository _repReadyUserModule = default!;
        private readonly IyUserModuleWriteRepository _repWriteyUserModule = default!;
        private readonly IyTenantReadRepository _repReadYtenantRepository = default!;
        public LoginHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IyUserReadRepository repReadyUser, IyUserWriteRepository repWriteyUser,IyTenantModuleReadRepository repReadyTenantModule, IyTenantModuleWriteRepository repWriteyTenantModule,IyUserModuleReadRepository repReadyUserModule, IyUserModuleWriteRepository repWriteyUserModule,IyTenantReadRepository repReadYtenantRepository)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadyUser = repReadyUser;
            _repWriteyUser = repWriteyUser;
            _repReadyTenantModule = repReadyTenantModule;
            _repWriteyTenantModule = repWriteyTenantModule;
            _repReadyUserModule = repReadyUserModule;
            _repWriteyUserModule = repWriteyUserModule;
            _repReadYtenantRepository = repReadYtenantRepository;
        }
protected partial async Task<State<LoginOutputCommand>> CustomActionHookAsync(State<LoginOutputCommand> state, LoginInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var user = _repReadyUser.FirstByEmail(comand.email, true);
        if (user is null)
            throw new ReceiverException<LoginOutputCommand>(Error("Erro login.", default!));

        if (user.senha != comand.password)
            throw new ReceiverException<LoginOutputCommand>(Error("Erro login.", default!));

        _executionContext.SetTenantId(user.tenantid);

        var modulos = new List<string>();
        var modulosUsuario = _repReadyUserModule.GetAllByUserId(user.id);
        if (modulosUsuario is not null)
            modulos.AddRange(modulosUsuario.Select(x => x.moduleid));

        var retorno = new LoginOutputCommand
        {
            modulos = modulos,
            tenantId = user.tenantid,
            email = user.email ?? comand.email,
            UserId = user.id
        };

        if (_repReadYtenantRepository.ExistsByUserId(user.id))
            retorno.modulos.Add("ADM");

        state = Success("Login valido", retorno);
    }
    catch (ReceiverException<LoginOutputCommand> ex)
    {
        state = ex.State;
        throw;
    }
    catch (Exception ex)
    {
        throw new ReceiverException<LoginOutputCommand>(Error(ex, default!));
    }

    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
