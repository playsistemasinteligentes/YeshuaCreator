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
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using Dominio.Behaviors;
using Dominio.Media;
using Dominio.Patterns.Domain;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Command.Receivers;
using Memorias.YouTube;
using Command.Interfaces.Patterns.FileStore;

namespace Command.Receivers.UseCase
{
    public partial class SolicitarPublicacaoAlbumHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IAlbumReadRepository _repReadAlbum = default!;
        private readonly IAlbumWriteRepository _repWriteAlbum = default!;
        private readonly IPublicacaoAlbumWriteRepository _repWritePublicacaoAlbum = default!;
        private readonly IySagaWriteRepository _sagaWriteRepository = default!;
        private readonly IYouTubeConnectionService _connections;
        private readonly ReservarCanalStandardHandler _standard;
        private readonly IFileStorage _music;
        public SolicitarPublicacaoAlbumHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IAlbumReadRepository repReadAlbum, IAlbumWriteRepository repWriteAlbum, IPublicacaoAlbumWriteRepository repWritePublicacaoAlbum, IySagaWriteRepository sagaWriteRepository, IYouTubeConnectionService connections, IFileStorage music, ReservarCanalStandardHandler standard)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadAlbum = repReadAlbum;
            _repWriteAlbum = repWriteAlbum;
            _repWritePublicacaoAlbum = repWritePublicacaoAlbum;
            _sagaWriteRepository = sagaWriteRepository;
            _connections = connections;
            _standard = standard;
            _music = music;
        }
protected partial async Task<State<SolicitarPublicacaoAlbumOutputCommand>> CustomActionHookAsync(State<SolicitarPublicacaoAlbumOutputCommand> state, SolicitarPublicacaoAlbumInputCommand comand, CancellationToken cancellationToken)
{
    if (comand.AlbumId <= 0)
        return ValidationError("AlbumId deve ser informado.", new SolicitarPublicacaoAlbumOutputCommand());

    var album = _repReadAlbum.FirstById(comand.AlbumId);
    if (album == null || album.deleted || album.tenantid != _executionContext.TenantID || album.userid != _executionContext.UserId)
        return ValidationError("Album nao encontrado.", new SolicitarPublicacaoAlbumOutputCommand());
    if (album.privacidade is < 1 or > 3)
        return ValidationError("Selecione uma visibilidade valida para o video.", new SolicitarPublicacaoAlbumOutputCommand());

    if (!VideoQualityProfiles.TryResolve(album.qualidadevideo, out var quality))
        return ValidationError("Selecione uma qualidade de video valida.", new SolicitarPublicacaoAlbumOutputCommand());
    if (!VideoPresentation.TryModel(album.modelovideo, out var model) || !VideoPresentation.ValidMusic(album.musicaid) || !VideoPresentation.ValidVolume(album.volumemusica))
        return ValidationError("Selecione um modelo, musica e volume validos.", new SolicitarPublicacaoAlbumOutputCommand());
    var track = VideoPresentation.FindMusic(album.musicaid);
    if (track != null && !await _music.ExistsAsync(new StoragePath(track.StorageKey), cancellationToken))
        return ValidationError("A musica selecionada nao esta disponivel no servidor.", new SolicitarPublicacaoAlbumOutputCommand());

    YouTubeConnectionStatus? destination = null;
    var credentialTenantId = _executionContext.TenantID;
    var standardId = 0;
    try
    {
        var own = await _connections.ListAsync(new YouTubeOwner(_executionContext.TenantID, _executionContext.UserId), cancellationToken);
        if (own.Conexoes.Count > 0)
        {
            destination = own.Conexoes.FirstOrDefault(c => c.ConexaoId == comand.ConexaoYouTubeId);
            if (destination is null && string.IsNullOrWhiteSpace(comand.ConexaoYouTubeId) && own.Conexoes.Count == 1)
                destination = own.Conexoes[0];
            if (destination?.Conectado != true)
                return ValidationError("Selecione um canal proprio conectado deste tenant.", new SolicitarPublicacaoAlbumOutputCommand());
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(comand.ConexaoYouTubeId))
                return ValidationError("Canal nao encontrado neste tenant.", new SolicitarPublicacaoAlbumOutputCommand());
            if (album.privacidade == 1)
                return ValidationError("Para publicacao automatica, escolha Nao listado ou Publico. Privado exige um canal proprio.", new SolicitarPublicacaoAlbumOutputCommand());
        }
    }
    catch (YouTubeConnectionException exception)
    {
        return ValidationError(exception.Message, new SolicitarPublicacaoAlbumOutputCommand());
    }

    var requestedAtUtc = DateTime.UtcNow;
    var correlationId = Guid.NewGuid().ToString("D");
    var domainContext = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.UseCase,
        "SolicitarPublicacaoAlbum", _executionContext.TenantID, _executionContext.UserId,
        traceId: _executionContext.TraceId);
    IPublicacaoAlbumEntity publicacao;

    var saga = new PublicarAlbumYouTubeSaga();
    saga.CreatedAt = DateTime.UtcNow;
    saga.NextExecutionAt = DateTime.UtcNow;
    saga.SetCorrelationId(correlationId);

    if (_executionContext.TryGetOperationalIdentity(out var identity))
    {
        saga.SetOperationalIdentity(
            identity.RootOperationId,
            identity.OperationId,
            identity.ExecutionId,
            identity.CausationId);
        saga.GetCurrent()?.SetOperationalIdentity(
            identity.RootOperationId,
            identity.OperationId,
            identity.ExecutionId,
            identity.CausationId);
    }

    _unitOfWork.BeginTran();
    try
    {
        if (!_repWritePublicacaoAlbum.CanRequestPublication(comand.AlbumId, _executionContext.TenantID,
                _executionContext.UserId, requestedAtUtc.AddMinutes(-5)))
        {
            return ValidationError("Aguarde cinco minutos entre pedidos de publicacao deste album.",
                new SolicitarPublicacaoAlbumOutputCommand());
        }

        if (destination is null)
        {
            var reservation = await _standard.ExecuteAsync(new ReservarCanalStandardInputCommand(), cancellationToken);
            if (reservation.StatusCode != 200 || !reservation.Data.Disponivel)
                return ValidationError("Nenhum canal disponivel para publicacao automatica. Tente novamente mais tarde.", new SolicitarPublicacaoAlbumOutputCommand());
            var channel = reservation.Data;
            standardId = channel.CanalStandardId;
            credentialTenantId = channel.CredencialTenantId;
            destination = new YouTubeConnectionStatus(true, true, channel.CanalId, ConexaoId: channel.ConexaoYouTubeId);
        }
        publicacao = new PublicacaoAlbumFactory(_logger, _domainTrackingPolicy).Create(
            context: domainContext, id: null, albumid: comand.AlbumId, correlationid: correlationId,
            manifeststoragekey: null, videostoragekey: null, youtubevideoid: null, youtubeurl: null,
            mensagem: "Publicacao solicitada.", solicitadaemutc: requestedAtUtc, publicadaemutc: null,
            status: MemoriasPublicationStatus.Solicitada, conexaoyoutubeid: destination.ConexaoId,
            canalyoutubeid: destination.CanalId, youtubecredentialtenantid: credentialTenantId,
            canalstandardid: standardId, privacidadeyoutube: album.privacidade,
            qualidadevideo: (int)quality.Quality, modelovideo: model.Id, musicaid: album.musicaid, volumemusica: album.volumemusica);
        var validation = PublicacaoAlbumDomainBehavior.Apply(publicacao, domainContext);
        if (!validation.IsValid)
            return ValidationError(validation.Errors, new SolicitarPublicacaoAlbumOutputCommand());

        _repWritePublicacaoAlbum.Insert(publicacao);
        saga.Start(publicacao.Id.GetValueOrDefault().ToString(), nameof(PublicacaoAlbumEntity));
        _sagaWriteRepository.Save(saga);
        _unitOfWork.Commit();
    }
    catch
    {
        _unitOfWork.Rollback();
        throw;
    }

    return Success("Publicacao solicitada.", new SolicitarPublicacaoAlbumOutputCommand
    {
        PublicacaoAlbumId = publicacao.Id.GetValueOrDefault(),
        CorrelationId = correlationId,
        Status = "Solicitada"
    });
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
