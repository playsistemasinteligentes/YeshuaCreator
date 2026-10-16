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
                    public static class AlbumTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Titulo = 1UL << 1;
            public const ulong Descricao = 1UL << 2;
            public const ulong Privacidade = 1UL << 3;
            public const ulong SegundosPorFoto = 1UL << 4;
            public const ulong QualidadeVideo = 1UL << 5;
            public const ulong ModeloVideo = 1UL << 6;
            public const ulong MusicaId = 1UL << 7;
            public const ulong VolumeMusica = 1UL << 8;
            public const ulong Status = 1UL << 9;
            public const ulong TenantID = 1UL << 10;
            public const ulong Deleted = 1UL << 11;
            public const ulong Changed = 1UL << 12;
            public const ulong UserId = 1UL << 13;
            public const ulong OperationalEntityId = 1UL << 14;
        }

        public static class AlbumOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Titulo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Descricao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Privacidade = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SegundosPorFoto = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification QualidadeVideo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ModeloVideo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MusicaId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VolumeMusica = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class AlbumDecorator : IAlbumEntity
{

                        private readonly IAlbumEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public AlbumDecorator(IAlbumEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public AlbumDecorator(
                            IAlbumEntity inner,
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
                                                if ((_trackingMask & AlbumTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Album", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Titulo
                                    {
                                        get => _inner.Titulo;
                                        set
                                        {
                                            if (_inner.Titulo != value)
                                            {
                                                _inner.Titulo = value;
                                                if ((_trackingMask & AlbumTrackingFields.Titulo) != 0UL)
                                                    _logger.DomainValueChanged("Album", "Titulo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.Titulo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _inner.Descricao = value;
                                                if ((_trackingMask & AlbumTrackingFields.Descricao) != 0UL)
                                                    _logger.DomainValueChanged("Album", "Descricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.Descricao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int Privacidade
                                    {
                                        get => _inner.Privacidade;
                                        set
                                        {
                                            if (_inner.Privacidade != value)
                                            {
                                                _inner.Privacidade = value;
                                                if ((_trackingMask & AlbumTrackingFields.Privacidade) != 0UL)
                                                    _logger.DomainValueChanged("Album", "Privacidade", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.Privacidade, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int SegundosPorFoto
                                    {
                                        get => _inner.SegundosPorFoto;
                                        set
                                        {
                                            if (_inner.SegundosPorFoto != value)
                                            {
                                                _inner.SegundosPorFoto = value;
                                                if ((_trackingMask & AlbumTrackingFields.SegundosPorFoto) != 0UL)
                                                    _logger.DomainValueChanged("Album", "SegundosPorFoto", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.SegundosPorFoto, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? QualidadeVideo
                                    {
                                        get => _inner.QualidadeVideo;
                                        set
                                        {
                                            if (_inner.QualidadeVideo != value)
                                            {
                                                _inner.QualidadeVideo = value;
                                                if ((_trackingMask & AlbumTrackingFields.QualidadeVideo) != 0UL)
                                                    _logger.DomainValueChanged("Album", "QualidadeVideo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.QualidadeVideo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ModeloVideo
                                    {
                                        get => _inner.ModeloVideo;
                                        set
                                        {
                                            if (_inner.ModeloVideo != value)
                                            {
                                                _inner.ModeloVideo = value;
                                                if ((_trackingMask & AlbumTrackingFields.ModeloVideo) != 0UL)
                                                    _logger.DomainValueChanged("Album", "ModeloVideo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.ModeloVideo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? MusicaId
                                    {
                                        get => _inner.MusicaId;
                                        set
                                        {
                                            if (_inner.MusicaId != value)
                                            {
                                                _inner.MusicaId = value;
                                                if ((_trackingMask & AlbumTrackingFields.MusicaId) != 0UL)
                                                    _logger.DomainValueChanged("Album", "MusicaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.MusicaId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? VolumeMusica
                                    {
                                        get => _inner.VolumeMusica;
                                        set
                                        {
                                            if (_inner.VolumeMusica != value)
                                            {
                                                _inner.VolumeMusica = value;
                                                if ((_trackingMask & AlbumTrackingFields.VolumeMusica) != 0UL)
                                                    _logger.DomainValueChanged("Album", "VolumeMusica", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.VolumeMusica, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AlbumTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("Album", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.Status, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AlbumTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Album", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AlbumTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Album", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AlbumTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Album", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AlbumTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Album", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AlbumOperationalFields.UserId, _trackingExecutionIdentity);
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