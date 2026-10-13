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
    public partial class ListarConexoesYouTubeHandler
    {
        private readonly IYouTubeConnectionService _connections;
        public ListarConexoesYouTubeHandler(ILogger logger, IExecutionContext context, IYouTubeConnectionService connections)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _connections = connections;
        }
protected partial async Task<State<ListarConexoesYouTubeOutputCommand>> CustomActionHookAsync(State<ListarConexoesYouTubeOutputCommand> state, ListarConexoesYouTubeInputCommand comand, CancellationToken cancellationToken)
{
    var list = await _connections.ListAsync(new YouTubeOwner(_executionContext.TenantID, _executionContext.UserId), cancellationToken);
    return Success("Conexoes consultadas.", new ListarConexoesYouTubeOutputCommand
    {
        Configurado = list.Configurado,
        Conexoes = list.Conexoes.Select(connection => new YouTubeConnectionInfo
        {
            ConexaoId = connection.ConexaoId, CanalId = connection.CanalId,
            CanalTitulo = connection.CanalTitulo, Conectado = connection.Conectado
        }).ToList()
    });
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
