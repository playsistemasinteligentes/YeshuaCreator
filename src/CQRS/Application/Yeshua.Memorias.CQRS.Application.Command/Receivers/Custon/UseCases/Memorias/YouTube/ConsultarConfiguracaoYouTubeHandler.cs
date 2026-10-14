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
using Memorias.YouTube;

namespace Command.Receivers.UseCase
{
    public partial class ConsultarConfiguracaoYouTubeHandler
    {
        private readonly IYouTubeApplicationConfigurationService _configuration;
        public ConsultarConfiguracaoYouTubeHandler(ILogger logger, IExecutionContext context, IYouTubeApplicationConfigurationService configuration)
            : base(logger, context)
        {
            _logger = logger; _executionContext = context; _configuration = configuration;
        }
protected partial Task<State<ConsultarConfiguracaoYouTubeOutputCommand>> CustomActionHookAsync(State<ConsultarConfiguracaoYouTubeOutputCommand> state, ConsultarConfiguracaoYouTubeInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var result = _configuration.Read(new(_executionContext.TenantID, _executionContext.UserId));
        return Task.FromResult(Success("Configuracao consultada.", new ConsultarConfiguracaoYouTubeOutputCommand
        {
            PodeConfigurar = result.PodeConfigurar, Configurado = result.Configurado, ClientId = result.ClientId,
            RedirectUri = result.RedirectUri, SegredoSalvo = result.SegredoSalvo, AtualizadoEmUtc = result.AtualizadoEmUtc
        }));
    }
    catch (YouTubeConnectionException error)
    { return Task.FromResult(ValidationError(error.Message, new ConsultarConfiguracaoYouTubeOutputCommand())); }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
