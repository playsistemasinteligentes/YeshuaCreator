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
            if (comand.TenantId <= 0
                || comand.UserId <= 0
                || string.IsNullOrWhiteSpace(comand.Email))
                throw new ReceiverException<OpenApplicationSessionOutputCommand>(
                    Error("Identidades da Central sao obrigatorias.", default));

            try
            {
                _unitOfWork.BeginTran();

                var tenantId = comand.TenantId;
                var tenant = _repReadYTenant.FirstById(tenantId, true);
                if (tenant is null)
                {
                    var tenantEntity = new yTenantFactory(_logger, _domainTrackingPolicy)
                        .Create(tenantId, comand.TenantDocument, comand.TenantName, null);
                    _repWriteYTenant.Insert(tenantEntity);
                }

                _executionContext.SetTenantId(tenantId);
                var userId = comand.UserId;
                var user = _repReadYUser.FirstById(userId, true);
                if (user is not null && user.tenantid != tenantId)
                    throw new ReceiverException<OpenApplicationSessionOutputCommand>(
                        Error("UserId global pertence a outro tenant.", default));
                if (user is null)
                {
                    var userEntity = new yUserFactory(_logger, _domainTrackingPolicy)
                        .Create(userId, comand.UserName, comand.Email, null);
                    _repWriteYUser.Insert(userEntity);
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
