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
using System.Text;

namespace Command.Receivers.UseCase
{
    public partial class ObterXmlCTeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICTeTentativaEmissaoReadRepository _repReadCTeTentativaEmissao = default!;
        private readonly ICTeTentativaEmissaoWriteRepository _repWriteCTeTentativaEmissao = default!;
        private readonly IDocumentoFiscalReadRepository _repReadDocumentoFiscal = default!;
        public ObterXmlCTeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICTeTentativaEmissaoReadRepository repReadCTeTentativaEmissao, ICTeTentativaEmissaoWriteRepository repWriteCTeTentativaEmissao, IDocumentoFiscalReadRepository repReadDocumentoFiscal)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCTeTentativaEmissao = repReadCTeTentativaEmissao;
            _repWriteCTeTentativaEmissao = repWriteCTeTentativaEmissao;
            _repReadDocumentoFiscal = repReadDocumentoFiscal;
        }
protected partial Task<State<ObterXmlCTeOutputCommand>> CustomActionHookAsync(State<ObterXmlCTeOutputCommand> state, ObterXmlCTeInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var documento = DocumentoFiscalUtilitarios.CarregarCTe(
            comand.ChaveAcesso,
            _repReadCTeTentativaEmissao,
            _repReadDocumentoFiscal);

        var output = new ObterXmlCTeOutputCommand
        {
            ChaveAcesso = documento.ChaveAcesso,
            NomeArquivo = documento.ChaveAcesso + "-procCTe.xml",
            ContentType = "application/xml",
            ArquivoBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(documento.Xml))
        };

        return Task.FromResult(Success("XML CT-e localizado.", output));
    }
    catch (Exception exception) when (exception is ArgumentException or InvalidOperationException or IOException)
    {
        return Task.FromResult(ValidationError(exception.Message));
    }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
