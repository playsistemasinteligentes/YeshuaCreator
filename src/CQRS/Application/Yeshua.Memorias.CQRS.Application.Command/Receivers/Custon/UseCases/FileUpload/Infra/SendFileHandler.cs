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
using Command.Interfaces.Patterns.FileStore;
using Dominio.Entitys;
using Dominio.Behaviors;
using Dominio.Patterns.Domain;
using System.Security.Cryptography;

namespace Command.Receivers.UseCase
{
    public partial class SendFileHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyFileUploadReadRepository _repReadyFileUpload = default!;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload = default!;
        private readonly IFileStorage _fileStorage = default!;
        private readonly IAlbumReadRepository _albumReadRepository = default!;
        private readonly IFotoWriteRepository _fotoWriteRepository = default!;
        private readonly IAlbumFotoReadRepository _albumFotoReadRepository = default!;
        private readonly IAlbumFotoWriteRepository _albumFotoWriteRepository = default!;

        private const long MaxPhotoSizeBytes = 25L * 1024L * 1024L;
        private static readonly TimeSpan UploadSessionLifetime = TimeSpan.FromHours(1);

        public SendFileHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            IyFileUploadReadRepository repReadyFileUpload,
            IyFileUploadWriteRepository repWriteyFileUpload,
            IFileStorage fileStorage,
            IAlbumReadRepository albumReadRepository,
            IFotoWriteRepository fotoWriteRepository,
            IAlbumFotoReadRepository albumFotoReadRepository,
            IAlbumFotoWriteRepository albumFotoWriteRepository)
            : base(logger, executionContext)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _executionContext = executionContext;
            _domainTrackingPolicy = domainTrackingPolicy;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
            _fileStorage = fileStorage;
            _albumReadRepository = albumReadRepository;
            _fotoWriteRepository = fotoWriteRepository;
            _albumFotoReadRepository = albumFotoReadRepository;
            _albumFotoWriteRepository = albumFotoWriteRepository;
        }
        protected partial async Task<State<SendFileOutputCommand>> CustomActionHookAsync(State<SendFileOutputCommand> state, SendFileInputCommand comand, CancellationToken cancellationToken)
        {
            StoragePath? storagePath = null;
            var fileSaved = false;
            var transactionStarted = false;

            try
            {
                ValidateCommand(comand);

                var upload = _repReadyFileUpload.FirstByOperationalEntityId(comand.token);
                if (upload is null
                    || upload.userid != _executionContext.UserId
                    || (upload.status != 0 && upload.status != 1)
                    || !string.Equals(upload.type, "memorias.photo", StringComparison.Ordinal)
                    || !string.Equals(upload.entitytype, "Album", StringComparison.Ordinal)
                    || DateTime.UtcNow - DateTime.SpecifyKind(upload.createdat, DateTimeKind.Utc) > UploadSessionLifetime
                    || !int.TryParse(upload.entityid, out var albumId)
                    || albumId <= 0)
                {
                    throw new ReceiverException<SendFileOutputCommand>(
                        ValidationError("Sessao de upload invalida ou expirada."));
                }

                var album = _albumReadRepository.FirstById(albumId);
                if (album is null || album.userid != _executionContext.UserId)
                {
                    throw new ReceiverException<SendFileOutputCommand>(
                        ValidationError("Album nao encontrado para o usuario atual."));
                }

                if (upload.status == 1)
                {
                    return Success("Foto ja adicionada ao album.", new SendFileOutputCommand
                    {
                        Success = true,
                        ChunkIndex = comand.ChunkIndex,
                        IsFinalized = true
                    });
                }

                _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                var context = DomainOperationContext.Create(
                    DomainOperation.Registro, DomainEntryPoint.UseCase, "AdicionarFotoAlbum",
                    _executionContext.TenantID, _executionContext.UserId,
                    traceId: _executionContext.TraceId,
                    receiverName: nameof(SendFileHandler),
                    commandName: "Command.UseCase.SendFileInputCommand",
                    rootOperationId: executionIdentity.RootOperationId,
                    operationId: executionIdentity.OperationId,
                    executionId: executionIdentity.ExecutionId,
                    causationId: executionIdentity.CausationId);

                var photoFormat = await DetectPhotoFormatAsync(comand.FileStream, cancellationToken);
                if (photoFormat is null)
                {
                    throw new ReceiverException<SendFileOutputCommand>(
                        ValidationError("Envie uma imagem JPEG, PNG ou WebP valida."));
                }

                var originalName = Path.GetFileName(
                    string.IsNullOrWhiteSpace(comand.FileName)
                        ? comand.FileStream.FileName
                        : comand.FileName);
                if (string.IsNullOrWhiteSpace(originalName))
                {
                    throw new ReceiverException<SendFileOutputCommand>(
                        ValidationError("Nome do arquivo e obrigatorio."));
                }

                originalName = originalName.Length <= 300
                    ? originalName
                    : originalName[..300];

                storagePath = StoragePathBuilder.Build(
                    Command.Media.MemoriasStorage.Photos,
                    _executionContext.TenantID.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    upload.id.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    $"{Guid.NewGuid():N}{photoFormat.Extension}");

                fileSaved = true;
                await _fileStorage.SaveAsync(
                    comand.FileStream,
                    storagePath,
                    cancellationToken);

                string hash;
                using (var stream = _fileStorage.OpenRead(storagePath))
                {
                    hash = Convert.ToHexString(
                        await SHA256.HashDataAsync(stream, cancellationToken));
                }

                var storageKey = storagePath.Value.Replace('\\', '/');
                var foto = new FotoFactory(_logger, _domainTrackingPolicy).Create(
                    context: context,
                    id: null,
                    storagekey: storageKey,
                    nomeoriginal: originalName,
                    contenttype: photoFormat.ContentType,
                    hasharquivo: hash,
                    capturadaemutc: null,
                    largura: null,
                    altura: null,
                    status: 2);

                var photoValidation = FotoDomainBehavior.Apply(foto, context);
                if (!photoValidation.IsValid)
                {
                    throw new ReceiverException<SendFileOutputCommand>(
                        ValidationError(string.Join("; ", photoValidation.Errors)));
                }

                _unitOfWork.BeginTran();
                transactionStarted = true;
                var completedAt = DateTime.UtcNow;
                if (!_repWriteyFileUpload.TryCompletePhotoUpload(
                    upload.id,
                    albumId,
                    _executionContext.TenantID,
                    _executionContext.UserId,
                    storageKey,
                    comand.FileStream.Length,
                    completedAt,
                    completedAt - UploadSessionLifetime))
                {
                    throw new ReceiverException<SendFileOutputCommand>(
                        ValidationError("Sessao de upload ja utilizada, expirada ou album indisponivel."));
                }

                _fotoWriteRepository.Insert(foto);

                var currentPhotos = _albumFotoReadRepository.GetAllByAlbumId(albumId);
                var nextOrder = currentPhotos.Any()
                    ? currentPhotos.Max(item => item.ordem) + 1
                    : 1;
                var albumFoto = new AlbumFotoFactory(_logger, _domainTrackingPolicy).Create(
                    context: context,
                    id: null,
                    albumid: albumId,
                    fotoid: foto.Id!.Value,
                    ordem: nextOrder,
                    legenda: null,
                    rotacao: comand.Rotacao);

                var linkValidation = AlbumFotoDomainBehavior.Apply(albumFoto, context);
                if (!linkValidation.IsValid)
                {
                    throw new ReceiverException<SendFileOutputCommand>(
                        ValidationError(string.Join("; ", linkValidation.Errors)));
                }

                _albumFotoWriteRepository.Insert(albumFoto);
                _unitOfWork.Commit();
                transactionStarted = false;

                return Success(
                    "Foto adicionada ao album.",
                    new SendFileOutputCommand
                    {
                        Success = true,
                        ChunkIndex = comand.ChunkIndex,
                        IsFinalized = true
                    });
            }
            catch
            {
                if (transactionStarted)
                {
                    try
                    {
                        _unitOfWork.Rollback();
                    }
                    catch
                    {
                        // Preservar a falha original e ainda tentar remover o arquivo.
                    }
                }
                if (fileSaved && storagePath is not null)
                {
                    try
                    {
                        await _fileStorage.DeleteAsync(storagePath, CancellationToken.None);
                    }
                    catch
                    {
                        // A falha principal deve ser preservada; limpeza pendente pode ser reconciliada depois.
                    }
                }

                throw;
            }
        }

        private void ValidateCommand(SendFileInputCommand command)
        {
            if (command.Rotacao is not (0 or 90 or 180 or 270))
                throw new ReceiverException<SendFileOutputCommand>(
                    ValidationError("A rotacao deve ser 0, 90, 180 ou 270 graus."));

            if (string.IsNullOrWhiteSpace(command.token))
            {
                throw new ReceiverException<SendFileOutputCommand>(
                    ValidationError("Token de upload e obrigatorio."));
            }

            if (command.FileStream is null || command.FileStream.Length <= 0)
            {
                throw new ReceiverException<SendFileOutputCommand>(
                    ValidationError("Arquivo da foto e obrigatorio."));
            }

            if (command.FileStream.Length > MaxPhotoSizeBytes)
            {
                throw new ReceiverException<SendFileOutputCommand>(
                    ValidationError("A foto deve ter no maximo 25 MB."));
            }

            if (command.ChunkIndex != 0 || !command.IsFinalChunk)
            {
                throw new ReceiverException<SendFileOutputCommand>(
                    ValidationError("Fotos devem ser enviadas em um unico arquivo."));
            }
        }

        private static async Task<PhotoFormat?> DetectPhotoFormatAsync(
            Microsoft.AspNetCore.Http.IFormFile file,
            CancellationToken cancellationToken)
        {
            var header = new byte[12];
            using var stream = file.OpenReadStream();
            var bytesRead = await stream.ReadAtLeastAsync(
                header.AsMemory(), header.Length, throwOnEndOfStream: false, cancellationToken);

            if (bytesRead >= 3 && header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF)
                return new PhotoFormat("image/jpeg", ".jpg");

            if (bytesRead >= 8
                && header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47
                && header[4] == 0x0D && header[5] == 0x0A && header[6] == 0x1A && header[7] == 0x0A)
            {
                return new PhotoFormat("image/png", ".png");
            }

            if (bytesRead >= 12
                && header[0] == (byte)'R' && header[1] == (byte)'I'
                && header[2] == (byte)'F' && header[3] == (byte)'F'
                && header[8] == (byte)'W' && header[9] == (byte)'E'
                && header[10] == (byte)'B' && header[11] == (byte)'P')
            {
                return new PhotoFormat("image/webp", ".webp");
            }

            return null;
        }

        private sealed record PhotoFormat(string ContentType, string Extension);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
