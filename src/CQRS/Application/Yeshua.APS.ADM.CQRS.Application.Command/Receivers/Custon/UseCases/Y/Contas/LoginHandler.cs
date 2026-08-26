// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class LoginHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IyUserReadRepository _repReadyUser;
        private readonly IyUserWriteRepository _repWriteyUser;
        private readonly IyTenantModuleReadRepository _repReadyTenantModule;
        private readonly IyTenantModuleWriteRepository _repWriteyTenantModule;
        private readonly IyUserModuleReadRepository _repReadyUserModule;
        private readonly IyUserModuleWriteRepository _repWriteyUserModule;
        private readonly IyTenantReadRepository _repReadYtenantRepository;

        public LoginHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            IyUserReadRepository repReadyUser,
            IyUserWriteRepository repWriteyUser,
            IyTenantModuleReadRepository repReadyTenantModule,
            IyTenantModuleWriteRepository repWriteyTenantModule,
            IyUserModuleReadRepository repReadyUserModule,
            IyUserModuleWriteRepository repWriteyUserModule,
            IyTenantReadRepository repReadYtenantRepository)
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

        partial void CustomActionHook(ref State<LoginOutputCommand> state, LoginInputCommand comand)
        {
            try
            {
                var user = _repReadyUser.FirstByEmail(comand.email, true);
                if (user is null)
                    throw new ReceiverException<LoginOutputCommand>(Error("Erro login.", default));

                if (user.senha != comand.password)
                    throw new ReceiverException<LoginOutputCommand>(Error("Erro login.", default));

                _executionContext.SetTenantId(user.tenantid);

                var modulos = new List<string>();
                var modulosUsuario = _repReadyUserModule.GetAllByUserId(user.id);
                if (modulosUsuario is not null)
                    modulos.AddRange(modulosUsuario.Select(x => x.moduleid));

                var usuarioVinculadoAoTenant = _repReadYtenantRepository.ExistsByUserId(user.id);

                var retorno = new LoginOutputCommand
                {
                    modulos = modulos,
                    tenantId = user.tenantid,
                    email = user.email ?? comand.email,
                    UserId = user.id
                };

                if (usuarioVinculadoAoTenant)
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
                throw new ReceiverException<LoginOutputCommand>(Error(ex, default));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
