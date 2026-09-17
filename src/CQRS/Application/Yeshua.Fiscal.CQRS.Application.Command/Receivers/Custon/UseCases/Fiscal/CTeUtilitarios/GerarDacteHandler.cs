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
    public partial class GerarDacteHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICTeTentativaEmissaoReadRepository _repReadCTeTentativaEmissao = default!;
        private readonly ICTeTentativaEmissaoWriteRepository _repWriteCTeTentativaEmissao = default!;
        private readonly IDocumentoFiscalReadRepository _repReadDocumentoFiscal = default!;
        public GerarDacteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICTeTentativaEmissaoReadRepository repReadCTeTentativaEmissao, ICTeTentativaEmissaoWriteRepository repWriteCTeTentativaEmissao, IDocumentoFiscalReadRepository repReadDocumentoFiscal)
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
protected partial Task<State<GerarDacteOutputCommand>> CustomActionHookAsync(State<GerarDacteOutputCommand> state, GerarDacteInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var arquivo = DocumentoFiscalUtilitarios.GerarDactes(
            comand.ChavesAcesso,
            _repReadCTeTentativaEmissao,
            _repReadDocumentoFiscal);

        var output = new GerarDacteOutputCommand
        {
            NomeArquivo = arquivo.NomeArquivo,
            ContentType = arquivo.ContentType,
            ArquivoBase64 = Convert.ToBase64String(arquivo.Conteudo),
            Quantidade = arquivo.Quantidade
        };

        return Task.FromResult(Success("DACTE gerado.", output));
    }
    catch (Exception exception) when (exception is ArgumentException or InvalidOperationException or IOException)
    {
        return Task.FromResult(ValidationError(exception.Message));
    }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
