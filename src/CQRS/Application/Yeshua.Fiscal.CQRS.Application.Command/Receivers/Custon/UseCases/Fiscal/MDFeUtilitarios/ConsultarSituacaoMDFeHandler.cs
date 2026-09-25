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
    public partial class ConsultarSituacaoMDFeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _repReadMDFeTentativaEmissao = default!;
        private readonly IMDFeTentativaEmissaoWriteRepository _repWriteMDFeTentativaEmissao = default!;
        public ConsultarSituacaoMDFeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IMDFeTentativaEmissaoReadRepository repReadMDFeTentativaEmissao, IMDFeTentativaEmissaoWriteRepository repWriteMDFeTentativaEmissao)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadMDFeTentativaEmissao = repReadMDFeTentativaEmissao;
            _repWriteMDFeTentativaEmissao = repWriteMDFeTentativaEmissao;
        }
protected partial async Task<State<ConsultarSituacaoMDFeOutputCommand>> CustomActionHookAsync(State<ConsultarSituacaoMDFeOutputCommand> state, ConsultarSituacaoMDFeInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var result = await MdfeConsultaHomologacaoClient
            .ConsultarAsync(comand.ChaveAcesso, salvarXml: false)
            .ConfigureAwait(false);

        var output = new ConsultarSituacaoMDFeOutputCommand
        {
            ChaveAcesso = result.Chave,
            Encontrado = result.Encontrado,
            Autorizado = result.Autorizado,
            CodigoRetorno = result.CodigoRetorno,
            Motivo = result.Motivo,
            Protocolo = result.Protocolo ?? string.Empty,
            HttpStatusCode = result.HttpStatusCode
        };

        return result.HttpStatusCode is >= 200 and < 300
            ? Success("Situacao do MDF-e consultada no SEFAZ.", output)
            : new State<ConsultarSituacaoMDFeOutputCommand>(
                502,
                $"Falha HTTP {result.HttpStatusCode} ao consultar o MDF-e no SEFAZ.",
                output,
                false);
    }
    catch (Exception exception) when (exception is ArgumentException or InvalidOperationException or IOException)
    {
        return ValidationError(exception.Message);
    }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
