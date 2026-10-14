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
    public partial class SalvarConfiguracaoYouTubeHandler
    {
        private readonly IYouTubeApplicationConfigurationService _configuration;
        public SalvarConfiguracaoYouTubeHandler(ILogger logger, IExecutionContext context, IYouTubeApplicationConfigurationService configuration)
            : base(logger, context)
        {
            _logger = logger; _executionContext = context; _configuration = configuration;
        }
protected partial async Task<State<SalvarConfiguracaoYouTubeOutputCommand>> CustomActionHookAsync(State<SalvarConfiguracaoYouTubeOutputCommand> state, SalvarConfiguracaoYouTubeInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var result = await _configuration.SaveAsync(new(_executionContext.TenantID, _executionContext.UserId), comand.ClientId, comand.ClientSecret, cancellationToken);
        return Success("Configuracao salva.", new SalvarConfiguracaoYouTubeOutputCommand
        {
            PodeConfigurar = result.PodeConfigurar, Configurado = result.Configurado, ClientId = result.ClientId,
            RedirectUri = result.RedirectUri, SegredoSalvo = result.SegredoSalvo, AtualizadoEmUtc = result.AtualizadoEmUtc
        });
    }
    catch (YouTubeConfigurationAccessException error)
    { return new State<SalvarConfiguracaoYouTubeOutputCommand>(403, error.Message, new()); }
    catch (YouTubeConnectionException error)
    { return ValidationError(error.Message, new SalvarConfiguracaoYouTubeOutputCommand()); }
    finally { comand.ClientSecret = ""; }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
