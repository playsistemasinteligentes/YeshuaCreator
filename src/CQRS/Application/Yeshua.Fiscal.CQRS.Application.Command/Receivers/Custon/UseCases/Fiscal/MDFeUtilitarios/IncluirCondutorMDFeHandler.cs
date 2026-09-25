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
    public partial class IncluirCondutorMDFeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _repReadMDFeTentativaEmissao = default!;
        private readonly IMDFeTentativaEmissaoWriteRepository _repWriteMDFeTentativaEmissao = default!;
        private readonly IDocumentoFiscalReadRepository _documentos;
        private readonly ICertificadoDigitalReadRepository _certificados;
        public IncluirCondutorMDFeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IMDFeTentativaEmissaoReadRepository repReadMDFeTentativaEmissao, IMDFeTentativaEmissaoWriteRepository repWriteMDFeTentativaEmissao, IDocumentoFiscalReadRepository documentos, ICertificadoDigitalReadRepository certificados)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadMDFeTentativaEmissao = repReadMDFeTentativaEmissao;
            _repWriteMDFeTentativaEmissao = repWriteMDFeTentativaEmissao;
            _documentos = documentos;
            _certificados = certificados;
        }
protected partial async Task<State<IncluirCondutorMDFeOutputCommand>> CustomActionHookAsync(State<IncluirCondutorMDFeOutputCommand> state, IncluirCondutorMDFeInputCommand comand, CancellationToken cancellationToken)
{
    var cpf = SefazFiscalEventContextResolver.Digits(comand.CpfCondutor);
    if (string.IsNullOrWhiteSpace(comand.NomeCondutor) || cpf.Length != 11)
        return ValidationError("Nome e CPF valido do condutor devem ser informados.");
    var context = SefazFiscalEventContextResolver.ResolveMDFe(comand.ChaveAcesso, _repReadMDFeTentativaEmissao, _documentos, _certificados);
    var result = await MdfeEventoFiscalClient.IncluirCondutorAsync(context, comand.NomeCondutor, cpf, comand.SequenciaEvento, cancellationToken);
    var output = new IncluirCondutorMDFeOutputCommand { ChaveAcesso = result.ChaveAcesso, Registrado = result.Registrado, CodigoRetorno = result.CodigoRetorno, Motivo = result.Motivo, ProtocoloEvento = result.ProtocoloEvento ?? string.Empty, HttpStatusCode = result.HttpStatusCode };
    return result.Registrado ? Success("Inclusao de condutor registrada no MDF-e.", output) : new State<IncluirCondutorMDFeOutputCommand>(400, result.Motivo, output, false);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
