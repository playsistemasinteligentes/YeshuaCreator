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
    public partial class GerarDamdfeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _repReadMDFeTentativaEmissao = default!;
        private readonly IMDFeTentativaEmissaoWriteRepository _repWriteMDFeTentativaEmissao = default!;
        private readonly IDocumentoFiscalReadRepository _repReadDocumentoFiscal = default!;
        public GerarDamdfeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IMDFeTentativaEmissaoReadRepository repReadMDFeTentativaEmissao, IMDFeTentativaEmissaoWriteRepository repWriteMDFeTentativaEmissao, IDocumentoFiscalReadRepository repReadDocumentoFiscal)
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
protected partial Task<State<GerarDamdfeOutputCommand>> CustomActionHookAsync(State<GerarDamdfeOutputCommand> state, GerarDamdfeInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var arquivo = DocumentoFiscalUtilitarios.GerarDamdfe(
            comand.ChavesAcesso,
            _repReadMDFeTentativaEmissao,
            _repReadDocumentoFiscal);

        var output = new GerarDamdfeOutputCommand
        {
            NomeArquivo = arquivo.NomeArquivo,
            ContentType = arquivo.ContentType,
            ArquivoBase64 = Convert.ToBase64String(arquivo.Conteudo),
            Quantidade = arquivo.Quantidade
        };

        return Task.FromResult(Success("DAMDFE gerado.", output));
    }
    catch (Exception exception) when (exception is ArgumentException or InvalidOperationException or IOException)
    {
        return Task.FromResult(ValidationError(exception.Message));
    }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
