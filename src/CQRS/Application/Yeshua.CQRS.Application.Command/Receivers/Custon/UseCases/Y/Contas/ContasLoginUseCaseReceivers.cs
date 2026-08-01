//using Dominio.Interfaces;
//using RepositoryInterfaces.Patterns.Command;
//using RepositoryInterfaces.Patterns.UnitOfWork;
//using IRepository.Read;
//using IRepository.Write;
//using Command.UseCase;
//using Repositorio.Outputs;
//using RepositoryInterfaces.Patterns.Repository;
//using System.Text.Encodings.Web;
//using Aplication.Interfaces.Services;

//namespace Command.Receivers.UseCase
//{
//    public partial class ContasLoginUseCaseReceiver
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly ILogger _logger;
//        private readonly IyUserReadRepository _repReadYuser;
//        private readonly IyUserWriteRepository _repWriteYuser;
//        private readonly IyTenantModuleReadRepository _repReadyTenantModule;
//        private readonly IyTenantModuleWriteRepository _repWriteyTenantModule;
//        private readonly IyUserModuleReadRepository _repReadyUserModule;
//        private readonly IyUserModuleWriteRepository _repWriteyUserModule;
//        private readonly IyTenantReadRepository _repReadYtenantRepository;
//        private readonly IExecutionContext _executionContext;

//        public ContasLoginUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyUserReadRepository repReadYuser, IyUserWriteRepository repWriteYuser, IyTenantModuleReadRepository repReadyTenantModule, IyTenantModuleWriteRepository repWriteyTenantModule, IyUserModuleReadRepository repReadyUserModule, IyUserModuleWriteRepository repWriteyUserModule, IyTenantReadRepository repIYtenantReadRepository, IExecutionContext executionContext)
//        {
//            _unitOfWork = unitOfWork;
//            _logger = logger;
//            _repReadYuser = repReadYuser;
//            _repWriteYuser = repWriteYuser;
//            _repReadyTenantModule = repReadyTenantModule;
//            _repWriteyTenantModule = repWriteyTenantModule;
//            _repReadyUserModule = repReadyUserModule;
//            _repWriteyUserModule = repWriteyUserModule;
//            _repReadYtenantRepository = repIYtenantReadRepository;
//            _executionContext = executionContext;
//        }
//        partial void CustomActionHook(ref State<ContasLoginUseCaseOutputCommand> state, ContasLoginUseCaseInputCommand comand)
//        {
//            try
//            {

//                var user = _repReadYuser.FirstByEmail(comand.email, true);
//                if (user == null)
//                    throw new ReceiverException<ContasLoginUseCaseOutputCommand>(Error("Erro login.", default));

//                if (user.senha != comand.password)
//                    throw new ReceiverException<ContasLoginUseCaseOutputCommand>(Error("Erro login.", default));

//                _executionContext.SetTenantId(user.tenantid);

//                var ModulosUsuario = _repReadyUserModule.GetAllByUserId(user.id);
//                bool usuarioVinculadoAoTenant = _repReadYtenantRepository.ExistsByUserId(user.id);

//                ContasLoginUseCaseOutputCommand retorno = new ContasLoginUseCaseOutputCommand();
//                retorno.modulos = ModulosUsuario.Select(x => x.moduleid).ToList();
//                retorno.tenantId = user.tenantid;
//                retorno.email = user.email;
//                retorno.UserId = user.id;

//                if (usuarioVinculadoAoTenant)
//                    retorno.modulos.Add("ADM");

//                state = Success("Login válido", retorno);
//            }

//            catch (ReceiverException<ContasLoginUseCaseOutputCommand> ex)
//            {
//                state = ex.State;
//                throw;
//            }
//            catch (Exception ex)
//            {
//                throw new ReceiverException<ContasLoginUseCaseOutputCommand>(Error(ex, default));
//            }
//        }
//    }
//}
////Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase