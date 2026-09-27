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
    public partial class AdicionarAplicativoAoTenantHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyTenantReadRepository _repReadyTenant = default!;
        private readonly IyTenantApplicationReadRepository _repReadTenantApplication = default!;
        private readonly IyTenantApplicationWriteRepository _repWriteTenantApplication = default!;
        public AdicionarAplicativoAoTenantHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IyTenantReadRepository repReadyTenant,IyTenantApplicationReadRepository repReadTenantApplication,IyTenantApplicationWriteRepository repWriteTenantApplication)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
            _domainTrackingPolicy = domainTrackingPolicy;
            _repReadyTenant = repReadyTenant;
            _repReadTenantApplication = repReadTenantApplication;
            _repWriteTenantApplication = repWriteTenantApplication;
        }
protected partial Task<State<AdicionarAplicativoAoTenantOutputCommand>> CustomActionHookAsync(State<AdicionarAplicativoAoTenantOutputCommand> state, AdicionarAplicativoAoTenantInputCommand comand, CancellationToken cancellationToken)
{
    var application = comand.Aplicativo?.Trim() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(application) || application.Length > 100 ||
        application.Equals("Central", StringComparison.OrdinalIgnoreCase))
        throw new ReceiverException<AdicionarAplicativoAoTenantOutputCommand>(
            Error("Catalogo invalido.", default));

    var tenant = _repReadyTenant.FirstById(_executionContext.TenantID);
    if (tenant is null || tenant.userid != _executionContext.UserId)
        throw new ReceiverException<AdicionarAplicativoAoTenantOutputCommand>(
            Error("Somente o proprietario do tenant pode adicionar aplicativos.", default));

    var tenantApplications = _repReadTenantApplication.GetAllByTenantID(_executionContext.TenantID)
        .Where(item => item.validuntil >= DateTime.UtcNow)
        .Select(item => item.applicationkey)
        .Where(item => !string.IsNullOrWhiteSpace(item))
        .ToHashSet(StringComparer.OrdinalIgnoreCase);

    if (!tenantApplications.Contains(application))
    {
        try
        {
            _unitOfWork.BeginTran();
            var tenantApplication = new yTenantApplicationFactory(_logger, _domainTrackingPolicy)
                .Create(null, application, DateTime.UtcNow.AddYears(100));
            tenantApplication.TenantID = _executionContext.TenantID;
            tenantApplication.UserId = _executionContext.UserId;
            _repWriteTenantApplication.Insert(tenantApplication);
            _unitOfWork.Commit();
            tenantApplications.Add(application);
        }
        catch
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    state = Success("Aplicativo adicionado ao tenant.", new AdicionarAplicativoAoTenantOutputCommand
    {
        Adicionado = true,
        Aplicativo = application,
        Catalogos = new[] { "Central" }
            .Concat(tenantApplications)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList()
    });
    return Task.FromResult(state);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
