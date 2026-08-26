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
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class CreateContaHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IyTenantReadRepository _repReadyTenant;
        private readonly IyTenantWriteRepository _repWriteyTenant;
        private readonly IyUserReadRepository _repReadyUser;
        private readonly IyUserWriteRepository _repWriteyUser;

        public CreateContaHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            IyTenantReadRepository repReadyTenant,
            IyTenantWriteRepository repWriteyTenant,
            IyUserReadRepository repReadyUser,
            IyUserWriteRepository repWriteyUser)
            : base(logger, executionContext)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _executionContext = executionContext;
            _domainTrackingPolicy = domainTrackingPolicy;
            _repReadyTenant = repReadyTenant;
            _repWriteyTenant = repWriteyTenant;
            _repReadyUser = repReadyUser;
            _repWriteyUser = repWriteyUser;
        }

        partial void CustomActionHook(ref State<CreateContaOutputCommand> state, CreateContaInputCommand comand)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comand.CpfCnpj))
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Cpf / Cnpj e obrigatorio", default));

                if (string.IsNullOrWhiteSpace(comand.email))
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Email e obrigatorio", default));

                if (string.IsNullOrWhiteSpace(comand.nome))
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Nome e obrigatorio", default));

                if (comand.password != comand.confirmpassword)
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Senhas nao conferem", default));

                if (_repReadyTenant.ExistsByCnpjCpf(comand.CpfCnpj))
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Conta ja existente.", default));

                if (_repReadyUser.ExistsByEmail(comand.email))
                {
                    var existingUser = _repReadyUser.FirstByEmail(comand.email);
                    if (existingUser is not null && _repReadyTenant.ExistsByUserId(existingUser.id))
                        throw new ReceiverException<CreateContaOutputCommand>(Error("Conta existente.", default));
                }

                _unitOfWork.BeginTran();

                var tenant = new yTenantFactory(_logger, _domainTrackingPolicy).Create(
                    comand.CpfCnpj,
                    comand.nome,
                    null);

                _repWriteyTenant.Insert(tenant);

                if (!tenant.isValidInsert())
                    throw new ReceiverException<CreateContaOutputCommand>(Error(string.Join("; ", tenant.getErroMensagens()), default));

                if (!tenant.Id.HasValue)
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Erro ao criar Tenant, Id nao gerado", default));

                _executionContext.SetTenantId(tenant.Id.Value);

                var user = new yUserFactory(_logger, _domainTrackingPolicy).Create(
                    null,
                    comand.nome,
                    comand.email,
                    comand.password);

                if (!user.isValidInsert())
                    throw new ReceiverException<CreateContaOutputCommand>(Error(string.Join("; ", user.getErroMensagens()), default));

                _repWriteyUser.Insert(user);

                if (!user.Id.HasValue)
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Erro ao criar Usuario, Id nao gerado", default));

                _repWriteyTenant.UpdateUserId(tenant.Id.Value, user.Id.Value);

                _unitOfWork.Commit();

                state = Success("Conta criada com sucesso", new CreateContaOutputCommand
                {
                    TenantId = tenant.Id.Value,
                    UserId = user.Id.Value
                });
            }
            catch (ReceiverException<CreateContaOutputCommand>)
            {
                _unitOfWork.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ReceiverException<CreateContaOutputCommand>(Error(ex, default));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
