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
        private readonly IyUserReadRepository _repReadYuser;
        private readonly IyUserWriteRepository _repWriteYuser;
        private readonly IyTenantModuleReadRepository _repReadyTenantModule;
        private readonly IyTenantModuleWriteRepository _repWriteyTenantModule;
        private readonly IyUserModuleReadRepository _repReadyUserModule;
        private readonly IyUserModuleWriteRepository _repWriteyUserModule;
        private readonly IyTenantReadRepository _repReadYtenantRepository;

        public LoginHandler(
    IUnitOfWork unitOfWork,
    IyUserReadRepository repReadYuser,
    IyUserWriteRepository repWriteYuser,
    IyTenantModuleReadRepository repReadyTenantModule,
    IyTenantModuleWriteRepository repWriteyTenantModule,
    IyUserModuleReadRepository repReadyUserModule,
    IyUserModuleWriteRepository repWriteyUserModule,
    IyTenantReadRepository repIYtenantReadRepository,
    Dominio.Interfaces.ILogger logger,
    Aplication.Interfaces.Services.IExecutionContext context)
    : base(logger, context)
        {
            _unitOfWork = unitOfWork;
            _repReadYuser = repReadYuser;
            _repWriteYuser = repWriteYuser;
            _repReadyTenantModule = repReadyTenantModule;
            _repWriteyTenantModule = repWriteyTenantModule;
            _repReadyUserModule = repReadyUserModule;
            _repWriteyUserModule = repWriteyUserModule;
            _repReadYtenantRepository = repIYtenantReadRepository;
            _logger = logger;
            _executionContext = context;
        }
        partial void CustomActionHook(ref State<LoginOutputCommand> state, LoginInputCommand comand)
{
            try
            {

                var user = _repReadYuser.FirstByEmail(comand.email, true);
                if (user == null)
                    throw new ReceiverException<LoginOutputCommand>(Error("Erro login.", default));

                if (user.senha != comand.password)
                    throw new ReceiverException<LoginOutputCommand>(Error("Erro login.", default));

                _executionContext.SetTenantId(user.tenantid);

                var ModulosUsuario = _repReadyUserModule.GetAllByUserId(user.id);
                bool usuarioVinculadoAoTenant = _repReadYtenantRepository.ExistsByUserId(user.id);

                LoginOutputCommand retorno = new LoginOutputCommand();
                retorno.modulos = ModulosUsuario.Select(x => x.moduleid).ToList();
                retorno.tenantId = user.tenantid;
                retorno.email = user.email;
                retorno.UserId = user.id;

                if (usuarioVinculadoAoTenant)
                    retorno.modulos.Add("ADM");

                state = Success("Login válido", retorno);
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
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase