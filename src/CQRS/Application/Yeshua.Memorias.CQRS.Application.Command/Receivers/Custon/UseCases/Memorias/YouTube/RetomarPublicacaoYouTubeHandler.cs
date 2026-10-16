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
    public partial class RetomarPublicacaoYouTubeHandler
    {
        private readonly IYouTubeConnectionService _connections;
        private readonly IPublicacaoAlbumWriteRepository _publications;
        private readonly IPublicacaoAlbumReadRepository _publicationRead;
        private readonly IUnitOfWork _unitOfWork;
        public RetomarPublicacaoYouTubeHandler(ILogger logger, IExecutionContext context,
            IYouTubeConnectionService connections, IPublicacaoAlbumWriteRepository publications,
            IPublicacaoAlbumReadRepository publicationRead, IUnitOfWork unitOfWork)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _connections = connections;
            _publications = publications;
            _publicationRead = publicationRead;
            _unitOfWork = unitOfWork;
        }
protected partial async Task<State<RetomarPublicacaoYouTubeOutputCommand>> CustomActionHookAsync(State<RetomarPublicacaoYouTubeOutputCommand> state, RetomarPublicacaoYouTubeInputCommand comand, CancellationToken cancellationToken)
{
    if (comand.PublicacaoAlbumId <= 0)
        return ValidationError("Informe uma publicacao salva.", new RetomarPublicacaoYouTubeOutputCommand());
    var owner = new YouTubeOwner(_executionContext.TenantID, _executionContext.UserId);
    var publication = _publicationRead.FirstById(comand.PublicacaoAlbumId);
    if (publication == null || publication.deleted || publication.tenantid != owner.TenantId || publication.userid != owner.UserId)
        return ValidationError("Publicacao nao encontrada.", new RetomarPublicacaoYouTubeOutputCommand());
    var connectionId = publication.conexaoyoutubeid;
    if (!string.IsNullOrEmpty(comand.ConexaoYouTubeId) && comand.ConexaoYouTubeId != connectionId)
        return ValidationError("O canal de uma publicacao solicitada nao pode ser trocado.", new RetomarPublicacaoYouTubeOutputCommand());
    if (string.IsNullOrWhiteSpace(connectionId) || publication.youtubecredentialtenantid <= 0)
        return ValidationError("Publicacao sem destino valido. Solicite uma nova publicacao.", new RetomarPublicacaoYouTubeOutputCommand());
    var status = await _connections.StatusAsync(new YouTubeOwner(publication.youtubecredentialtenantid, owner.UserId), connectionId, cancellationToken);
    if (!status.Conectado || status.CanalId != publication.canalyoutubeid)
        return ValidationError("O canal desta publicacao precisa ser reconectado pelo responsavel. O destino nao sera trocado.", new RetomarPublicacaoYouTubeOutputCommand());
    _unitOfWork.BeginTran();
    try
    {
        var scheduled = _publications.ScheduleYouTubeResume(comand.PublicacaoAlbumId,
            owner.TenantId, owner.UserId, _executionContext.ProcessingScope, DateTime.UtcNow,
            status.ConexaoId, status.CanalId, publication.youtubecredentialtenantid);
        _unitOfWork.Commit();
        return scheduled
            ? Accepted("Envio agendado para o Worker.", new RetomarPublicacaoYouTubeOutputCommand { Agendada = true })
            : ValidationError("Publicacao nao encontrada ou nao esta aguardando conexao YouTube.", new RetomarPublicacaoYouTubeOutputCommand());
    }
    catch
    {
        _unitOfWork.Rollback();
        throw;
    }
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
