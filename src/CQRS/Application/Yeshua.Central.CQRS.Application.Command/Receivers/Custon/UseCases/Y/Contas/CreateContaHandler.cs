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
using Dominio.Entitys;

namespace Command.Receivers.UseCase
{
    public partial class CreateContaHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyTenantReadRepository _repReadyTenant = default!;
        private readonly IyTenantWriteRepository _repWriteyTenant = default!;
        private readonly IyUserReadRepository _repReadyUser = default!;
        private readonly IyUserWriteRepository _repWriteyUser = default!;
        public CreateContaHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IyTenantReadRepository repReadyTenant, IyTenantWriteRepository repWriteyTenant,IyUserReadRepository repReadyUser, IyUserWriteRepository repWriteyUser)
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
protected partial Task<State<CreateContaOutputCommand>> CustomActionHookAsync(State<CreateContaOutputCommand> state, CreateContaInputCommand comand, CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(comand.CpfCnpj))
        throw new ReceiverException<CreateContaOutputCommand>(Error("Cpf/Cnpj e obrigatorio.", default));
    if (string.IsNullOrWhiteSpace(comand.nome))
        throw new ReceiverException<CreateContaOutputCommand>(Error("Nome e obrigatorio.", default));
    if (string.IsNullOrWhiteSpace(comand.email))
        throw new ReceiverException<CreateContaOutputCommand>(Error("Email e obrigatorio.", default));
    if (comand.password != comand.confirmpassword)
        throw new ReceiverException<CreateContaOutputCommand>(Error("Senhas nao conferem.", default));
    if (_repReadyTenant.ExistsByCnpjCpf(comand.CpfCnpj))
        throw new ReceiverException<CreateContaOutputCommand>(Error("Conta ja existente.", default));
    if (_repReadyUser.ExistsByEmail(comand.email))
        throw new ReceiverException<CreateContaOutputCommand>(Error("Email ja cadastrado.", default));

    try
    {
        _unitOfWork.BeginTran();

        var tenant = new yTenantFactory(_logger, _domainTrackingPolicy)
            .Create(comand.CpfCnpj, comand.nome, null);
        _repWriteyTenant.Insert(tenant);
        if (!tenant.Id.HasValue)
            throw new ReceiverException<CreateContaOutputCommand>(Error("Tenant nao foi criado.", default));

        _executionContext.SetTenantId(tenant.Id.Value);
        var user = new yUserFactory(_logger, _domainTrackingPolicy)
            .Create(null, comand.nome, comand.email, comand.password);
        _repWriteyUser.Insert(user);
        if (!user.Id.HasValue)
            throw new ReceiverException<CreateContaOutputCommand>(Error("Usuario nao foi criado.", default));

        _repWriteyTenant.UpdateUserId(tenant.Id.Value, user.Id.Value);
        _unitOfWork.Commit();
        state = Success("Conta criada com sucesso", new CreateContaOutputCommand
        {
            TenantId = tenant.Id.Value,
            UserId = user.Id.Value
        });
        return Task.FromResult(state);
    }
    catch
    {
        _unitOfWork.Rollback();
        throw;
    }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
