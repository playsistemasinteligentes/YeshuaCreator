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
    public partial class ObterXmlMDFeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _repReadMDFeTentativaEmissao = default!;
        private readonly IMDFeTentativaEmissaoWriteRepository _repWriteMDFeTentativaEmissao = default!;
        private readonly IDocumentoFiscalReadRepository _repReadDocumentoFiscal = default!;
        public ObterXmlMDFeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IMDFeTentativaEmissaoReadRepository repReadMDFeTentativaEmissao, IMDFeTentativaEmissaoWriteRepository repWriteMDFeTentativaEmissao, IDocumentoFiscalReadRepository repReadDocumentoFiscal)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadMDFeTentativaEmissao = repReadMDFeTentativaEmissao;
            _repWriteMDFeTentativaEmissao = repWriteMDFeTentativaEmissao;
            _repReadDocumentoFiscal = repReadDocumentoFiscal;
        }
protected partial Task<State<ObterXmlMDFeOutputCommand>> CustomActionHookAsync(State<ObterXmlMDFeOutputCommand> state, ObterXmlMDFeInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var documento = DocumentoFiscalUtilitarios.CarregarMDFe(
            comand.ChaveAcesso,
            _repReadMDFeTentativaEmissao,
            _repReadDocumentoFiscal);

        var output = new ObterXmlMDFeOutputCommand
        {
            ChaveAcesso = documento.ChaveAcesso,
            NomeArquivo = documento.ChaveAcesso + "-procMDFe.xml",
            ContentType = "application/xml",
            ArquivoBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(documento.Xml))
        };

        return Task.FromResult(Success("XML MDF-e localizado.", output));
    }
    catch (Exception exception) when (exception is ArgumentException or InvalidOperationException or IOException)
    {
        return Task.FromResult(ValidationError(exception.Message));
    }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
