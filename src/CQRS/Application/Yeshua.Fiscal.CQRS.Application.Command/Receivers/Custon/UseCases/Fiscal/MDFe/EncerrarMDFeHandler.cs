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
    public partial class EncerrarMDFeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IMDFeReadRepository _repReadMDFe = default!;
        private readonly IMDFeWriteRepository _repWriteMDFe = default!;
        public EncerrarMDFeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IMDFeReadRepository repReadMDFe, IMDFeWriteRepository repWriteMDFe)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadMDFe = repReadMDFe;
            _repWriteMDFe = repWriteMDFe;
        }
protected partial async Task<State<EncerrarMDFeOutputCommand>> CustomActionHookAsync(State<EncerrarMDFeOutputCommand> state, EncerrarMDFeInputCommand comand, CancellationToken cancellationToken)
{
    var options = MdfeEncerramentoSefazOptions.FromEnvironment();
    var chaveInformada = OnlyDigits(comand.ChaveAcesso ?? string.Empty);

    if (!string.IsNullOrWhiteSpace(chaveInformada))
    {
        options = options with
        {
            ChaveAcesso = chaveInformada,
            CodigoOrgao = chaveInformada.Length >= 2 ? int.Parse(chaveInformada.Substring(0, 2)) : options.CodigoOrgao,
            Cnpj = chaveInformada.Length >= 20 ? chaveInformada.Substring(6, 14) : options.Cnpj
        };
    }

    var result = await MdfeRecepcaoEventoClient.EncerrarAsync(options, cancellationToken);
    var output = new EncerrarMDFeOutputCommand
    {
        ChaveAcesso = result.ChaveAcesso,
        Encerrado = result.Encerrado,
        Protocolo = result.Protocolo ?? string.Empty,
        Mensagem = $"{result.CodigoRetorno} - {result.Motivo}",
        EncerradoEm = result.Encerrado ? DateTime.UtcNow : null
    };

    return result.Encerrado
        ? Success("MDF-e encerrado no SEFAZ.", output)
        : new State<EncerrarMDFeOutputCommand>(400, output.Mensagem, output, false);
}

        private static string OnlyDigits(string value)
        {
            var buffer = new System.Text.StringBuilder(value.Length);
            foreach (var character in value)
            {
                if (character is >= '0' and <= '9')
                    buffer.Append(character);
            }

            return buffer.ToString();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
