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
    public partial class ConsultarSituacaoCTeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICTeTentativaEmissaoReadRepository _repReadCTeTentativaEmissao = default!;
        private readonly ICTeTentativaEmissaoWriteRepository _repWriteCTeTentativaEmissao = default!;
        public ConsultarSituacaoCTeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICTeTentativaEmissaoReadRepository repReadCTeTentativaEmissao, ICTeTentativaEmissaoWriteRepository repWriteCTeTentativaEmissao)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCTeTentativaEmissao = repReadCTeTentativaEmissao;
            _repWriteCTeTentativaEmissao = repWriteCTeTentativaEmissao;
        }
protected partial async Task<State<ConsultarSituacaoCTeOutputCommand>> CustomActionHookAsync(State<ConsultarSituacaoCTeOutputCommand> state, ConsultarSituacaoCTeInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var result = await CteConsultaV4HomologacaoClient
            .ConsultarAsync(comand.ChaveAcesso, salvarXml: false)
            .ConfigureAwait(false);

        var output = new ConsultarSituacaoCTeOutputCommand
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
            ? Success("Situacao do CT-e consultada no SEFAZ.", output)
            : new State<ConsultarSituacaoCTeOutputCommand>(
                502,
                $"Falha HTTP {result.HttpStatusCode} ao consultar o CT-e no SEFAZ.",
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
