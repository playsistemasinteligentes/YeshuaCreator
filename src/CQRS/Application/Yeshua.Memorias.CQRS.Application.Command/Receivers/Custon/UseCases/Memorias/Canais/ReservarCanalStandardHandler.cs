// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

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
    public partial class ReservarCanalStandardHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICanalStandardReadRepository _repReadCanalStandard = default!;
        private readonly ICanalStandardWriteRepository _repWriteCanalStandard = default!;
        private readonly IYouTubeConnectionService _connections;
        public ReservarCanalStandardHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICanalStandardReadRepository repReadCanalStandard, ICanalStandardWriteRepository repWriteCanalStandard, IYouTubeConnectionService connections)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCanalStandard = repReadCanalStandard;
            _repWriteCanalStandard = repWriteCanalStandard;
            _connections = connections;
        }
protected partial async Task<State<ReservarCanalStandardOutputCommand>> CustomActionHookAsync(State<ReservarCanalStandardOutputCommand> state, ReservarCanalStandardInputCommand comand, CancellationToken cancellationToken)
{
    cancellationToken.ThrowIfCancellationRequested();
    if (_executionContext.TenantID <= 0 || _executionContext.UserId <= 0)
    {
        return ValidationError("A reserva exige contexto autenticado do aplicativo.", new ReservarCanalStandardOutputCommand());
    }

    var eligible = new List<Repositorio.Outputs.CanalStandardDTO>();
    foreach (var group in _repReadCanalStandard.ListarDisponiveis().GroupBy(c => c.credencialtenantid))
    {
        var channels = await _connections.ListAsync(new YouTubeOwner(group.Key, _executionContext.UserId), cancellationToken);
        foreach (var candidate in group)
            if (channels.Conexoes.Any(c => c.Conectado && c.ConexaoId == candidate.conexaoyoutubeid && c.CanalId == candidate.canalid))
                eligible.Add(candidate);
    }
    // Linhas duplicadas no cadastro nao multiplicam a capacidade do mesmo canal.
    eligible = eligible.GroupBy(c => c.canalid, StringComparer.Ordinal)
        .Select(group => group.MinBy(c => c.id)!).ToList();
    if (comand.SomenteConsultar)
        return Success("Disponibilidade consultada.", new ReservarCanalStandardOutputCommand { Disponivel = eligible.Count > 0 });
    if (eligible.Count == 0)
        return Success("Nenhum canal disponivel.", new ReservarCanalStandardOutputCommand());

    cancellationToken.ThrowIfCancellationRequested();
    var canal = _repWriteCanalStandard.ReservarDisponivel(eligible.Select(c => c.id).ToArray());
    if (canal is not null && !eligible.Any(c => c.id == canal.id && c.credencialtenantid == canal.credencialtenantid
        && c.conexaoyoutubeid == canal.conexaoyoutubeid && c.canalid == canal.canalid))
        return ValidationError("O cadastro do canal foi alterado. Consulte novamente.", new ReservarCanalStandardOutputCommand());
    state.Data = canal is null
        ? new ReservarCanalStandardOutputCommand()
        : new ReservarCanalStandardOutputCommand
        {
            Disponivel = true,
            CanalStandardId = canal.id,
            CanalId = canal.canalid,
            ConexaoYouTubeId = canal.conexaoyoutubeid,
            CredencialTenantId = canal.credencialtenantid
        };
    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
