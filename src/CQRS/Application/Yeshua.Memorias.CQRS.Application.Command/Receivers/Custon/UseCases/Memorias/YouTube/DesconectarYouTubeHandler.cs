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
using Memorias.YouTube;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class DesconectarYouTubeHandler
    {
        private readonly IYouTubeConnectionService _connections;
        public DesconectarYouTubeHandler(ILogger logger, IExecutionContext context, IYouTubeConnectionService connections)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _connections = connections;
        }
protected partial async Task<State<DesconectarYouTubeOutputCommand>> CustomActionHookAsync(State<DesconectarYouTubeOutputCommand> state, DesconectarYouTubeInputCommand comand, CancellationToken cancellationToken)
{
    try
    {
        var owner = new YouTubeOwner(_executionContext.TenantID, _executionContext.UserId);
        var status = await _connections.DisconnectAsync(owner, comand.ConexaoId, cancellationToken);
        return Success(status.Mensagem, new DesconectarYouTubeOutputCommand
        {
            Configurado = status.Configurado, Conectado = status.Conectado,
            CanalId = status.CanalId, CanalTitulo = status.CanalTitulo,
            AuthorizationUrl = status.AuthorizationUrl, Mensagem = status.Mensagem, ConexaoId = status.ConexaoId
        });
    }
    catch (YouTubeConnectionException exception)
    {
        return ValidationError(exception.Message, new DesconectarYouTubeOutputCommand());
    }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
