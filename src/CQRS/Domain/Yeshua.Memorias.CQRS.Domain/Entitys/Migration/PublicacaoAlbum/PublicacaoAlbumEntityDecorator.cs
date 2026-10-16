// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public static class PublicacaoAlbumTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong AlbumId = 1UL << 1;
            public const ulong CorrelationId = 1UL << 2;
            public const ulong ManifestStorageKey = 1UL << 3;
            public const ulong VideoStorageKey = 1UL << 4;
            public const ulong YouTubeVideoId = 1UL << 5;
            public const ulong YouTubeUrl = 1UL << 6;
            public const ulong ConexaoYouTubeId = 1UL << 7;
            public const ulong CanalYouTubeId = 1UL << 8;
            public const ulong YouTubeCredentialTenantId = 1UL << 9;
            public const ulong CanalStandardId = 1UL << 10;
            public const ulong PrivacidadeYouTube = 1UL << 11;
            public const ulong QualidadeVideo = 1UL << 12;
            public const ulong ModeloVideo = 1UL << 13;
            public const ulong MusicaId = 1UL << 14;
            public const ulong VolumeMusica = 1UL << 15;
            public const ulong Mensagem = 1UL << 16;
            public const ulong SolicitadaEmUtc = 1UL << 17;
            public const ulong PublicadaEmUtc = 1UL << 18;
            public const ulong Status = 1UL << 19;
            public const ulong TenantID = 1UL << 20;
            public const ulong Deleted = 1UL << 21;
            public const ulong Changed = 1UL << 22;
            public const ulong UserId = 1UL << 23;
            public const ulong OperationalEntityId = 1UL << 24;
        }

        public static class PublicacaoAlbumOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AlbumId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CorrelationId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ManifestStorageKey = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VideoStorageKey = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification YouTubeVideoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification YouTubeUrl = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ConexaoYouTubeId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CanalYouTubeId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification YouTubeCredentialTenantId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CanalStandardId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PrivacidadeYouTube = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification QualidadeVideo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ModeloVideo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MusicaId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VolumeMusica = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Mensagem = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SolicitadaEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PublicadaEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class PublicacaoAlbumDecorator : IPublicacaoAlbumEntity
{

                        private readonly IPublicacaoAlbumEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PublicacaoAlbumDecorator(IPublicacaoAlbumEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PublicacaoAlbumDecorator(
                            IPublicacaoAlbumEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingExecutionIdentity = context is null
                                ? default
                                : new Dominio.Operational.OperationalExecutionIdentity(
                                    context.RootOperationId,
                                    context.OperationId,
                                    context.ExecutionId,
                                    context.CausationId);
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int AlbumId
                                    {
                                        get => _inner.AlbumId;
                                        set
                                        {
                                            if (_inner.AlbumId != value)
                                            {
                                                _inner.AlbumId = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.AlbumId) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "AlbumId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.AlbumId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string CorrelationId
                                    {
                                        get => _inner.CorrelationId;
                                        set
                                        {
                                            if (_inner.CorrelationId != value)
                                            {
                                                _inner.CorrelationId = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.CorrelationId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ManifestStorageKey
                                    {
                                        get => _inner.ManifestStorageKey;
                                        set
                                        {
                                            if (_inner.ManifestStorageKey != value)
                                            {
                                                _inner.ManifestStorageKey = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.ManifestStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "ManifestStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.ManifestStorageKey, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? VideoStorageKey
                                    {
                                        get => _inner.VideoStorageKey;
                                        set
                                        {
                                            if (_inner.VideoStorageKey != value)
                                            {
                                                _inner.VideoStorageKey = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.VideoStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "VideoStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.VideoStorageKey, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? YouTubeVideoId
                                    {
                                        get => _inner.YouTubeVideoId;
                                        set
                                        {
                                            if (_inner.YouTubeVideoId != value)
                                            {
                                                _inner.YouTubeVideoId = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.YouTubeVideoId) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "YouTubeVideoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.YouTubeVideoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? YouTubeUrl
                                    {
                                        get => _inner.YouTubeUrl;
                                        set
                                        {
                                            if (_inner.YouTubeUrl != value)
                                            {
                                                _inner.YouTubeUrl = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.YouTubeUrl) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "YouTubeUrl", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.YouTubeUrl, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string? ConexaoYouTubeId => _inner.ConexaoYouTubeId;
    public string? CanalYouTubeId => _inner.CanalYouTubeId;
    public int? YouTubeCredentialTenantId => _inner.YouTubeCredentialTenantId;
    public int? CanalStandardId => _inner.CanalStandardId;
    public int? PrivacidadeYouTube => _inner.PrivacidadeYouTube;
    public int? QualidadeVideo => _inner.QualidadeVideo;
    public int? ModeloVideo => _inner.ModeloVideo;
    public int? MusicaId => _inner.MusicaId;
    public int? VolumeMusica => _inner.VolumeMusica;

                                    public string? Mensagem
                                    {
                                        get => _inner.Mensagem;
                                        set
                                        {
                                            if (_inner.Mensagem != value)
                                            {
                                                _inner.Mensagem = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.Mensagem) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "Mensagem", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.Mensagem, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime SolicitadaEmUtc
                                    {
                                        get => _inner.SolicitadaEmUtc;
                                        set
                                        {
                                            if (_inner.SolicitadaEmUtc != value)
                                            {
                                                _inner.SolicitadaEmUtc = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.SolicitadaEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "SolicitadaEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.SolicitadaEmUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? PublicadaEmUtc
                                    {
                                        get => _inner.PublicadaEmUtc;
                                        set
                                        {
                                            if (_inner.PublicadaEmUtc != value)
                                            {
                                                _inner.PublicadaEmUtc = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.PublicadaEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "PublicadaEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.PublicadaEmUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.Status, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.TenantID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public bool? Deleted
                                    {
                                        get => _inner.Deleted;
                                        set
                                        {
                                            if (_inner.Deleted != value)
                                            {
                                                _inner.Deleted = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.Deleted, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? Changed
                                    {
                                        get => _inner.Changed;
                                        set
                                        {
                                            if (_inner.Changed != value)
                                            {
                                                _inner.Changed = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.Changed, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? UserId
                                    {
                                        get => _inner.UserId;
                                        set
                                        {
                                            if (_inner.UserId != value)
                                            {
                                                _inner.UserId = value;
                                                if ((_trackingMask & PublicacaoAlbumTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoAlbum", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoAlbumOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration