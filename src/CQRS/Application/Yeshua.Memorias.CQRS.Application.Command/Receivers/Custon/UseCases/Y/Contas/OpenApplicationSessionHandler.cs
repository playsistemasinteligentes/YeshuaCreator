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
using Dominio.Entitys;

namespace Command.Receivers.UseCase
{
    public partial class OpenApplicationSessionHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyTenantReadRepository _repReadYTenant = default!;
        private readonly IyTenantWriteRepository _repWriteYTenant = default!;
        private readonly IyUserReadRepository _repReadYUser = default!;
        private readonly IyUserWriteRepository _repWriteYUser = default!;

        public OpenApplicationSessionHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            IyTenantReadRepository repReadYTenant,
            IyTenantWriteRepository repWriteYTenant,
            IyUserReadRepository repReadYUser,
            IyUserWriteRepository repWriteYUser)
            : base(logger, executionContext)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _executionContext = executionContext;
            _domainTrackingPolicy = domainTrackingPolicy;
            _repReadYTenant = repReadYTenant;
            _repWriteYTenant = repWriteYTenant;
            _repReadYUser = repReadYUser;
            _repWriteYUser = repWriteYUser;
        }

        protected partial Task<State<OpenApplicationSessionOutputCommand>> CustomActionHookAsync(
            State<OpenApplicationSessionOutputCommand> state,
            OpenApplicationSessionInputCommand comand,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(comand.TenantIdentity)
                || string.IsNullOrWhiteSpace(comand.UserIdentity)
                || string.IsNullOrWhiteSpace(comand.Email))
                throw new ReceiverException<OpenApplicationSessionOutputCommand>(
                    Error("Identidades da Central sao obrigatorias.", default));

            try
            {
                _unitOfWork.BeginTran();

                var tenant = _repReadYTenant.FirstByOperationalEntityId(comand.TenantIdentity, true);
                var tenantId = tenant?.id ?? 0;
                if (tenantId == 0)
                {
                    var tenantEntity = new yTenantFactory(_logger, _domainTrackingPolicy)
                        .Create(comand.TenantDocument, comand.TenantName, null);
                    _repWriteYTenant.Insert(tenantEntity);
                    if (!tenantEntity.Id.HasValue)
                        throw new ReceiverException<OpenApplicationSessionOutputCommand>(
                            Error("Tenant local nao foi criado.", default));

                    tenantId = tenantEntity.Id.Value;
                    _repWriteYTenant.UpdateOperationalEntityId(tenantId, comand.TenantIdentity);
                }

                _executionContext.SetTenantId(tenantId);
                var user = _repReadYUser.FirstByOperationalEntityId(comand.UserIdentity, true);
                var userId = user?.id ?? 0;
                if (userId == 0)
                {
                    var userEntity = new yUserFactory(_logger, _domainTrackingPolicy)
                        .Create(null, comand.UserName, comand.Email, null);
                    _repWriteYUser.Insert(userEntity);
                    if (!userEntity.Id.HasValue)
                        throw new ReceiverException<OpenApplicationSessionOutputCommand>(
                            Error("Usuario local nao foi criado.", default));

                    userId = userEntity.Id.Value;
                    _repWriteYUser.UpdateOperationalEntityId(userId, comand.UserIdentity);
                }

                _executionContext.SetUserId(userId);
                if (tenant is null || tenant.userid != userId)
                    _repWriteYTenant.UpdateUserId(tenantId, userId);

                _unitOfWork.Commit();
                state = Success("Sessao local aberta", new OpenApplicationSessionOutputCommand
                {
                    TenantId = tenantId,
                    UserId = userId,
                    Email = comand.Email
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