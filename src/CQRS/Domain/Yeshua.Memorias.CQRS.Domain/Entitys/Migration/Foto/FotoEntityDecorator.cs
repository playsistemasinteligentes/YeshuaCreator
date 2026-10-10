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
                    public static class FotoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong StorageKey = 1UL << 1;
            public const ulong NomeOriginal = 1UL << 2;
            public const ulong ContentType = 1UL << 3;
            public const ulong HashArquivo = 1UL << 4;
            public const ulong CapturadaEmUtc = 1UL << 5;
            public const ulong Largura = 1UL << 6;
            public const ulong Altura = 1UL << 7;
            public const ulong Status = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
            public const ulong TenantID = 1UL << 10;
            public const ulong Deleted = 1UL << 11;
            public const ulong Changed = 1UL << 12;
            public const ulong UserId = 1UL << 13;
        }

        public partial class FotoDecorator : IFotoEntity
{

                        private readonly IFotoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public FotoDecorator(IFotoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public FotoDecorator(
                            IFotoEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
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
                                                if ((_trackingMask & FotoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string StorageKey
                                    {
                                        get => _inner.StorageKey;
                                        set
                                        {
                                            if (_inner.StorageKey != value)
                                            {
                                                _inner.StorageKey = value;
                                                if ((_trackingMask & FotoTrackingFields.StorageKey) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "StorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string NomeOriginal
                                    {
                                        get => _inner.NomeOriginal;
                                        set
                                        {
                                            if (_inner.NomeOriginal != value)
                                            {
                                                _inner.NomeOriginal = value;
                                                if ((_trackingMask & FotoTrackingFields.NomeOriginal) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "NomeOriginal", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ContentType
                                    {
                                        get => _inner.ContentType;
                                        set
                                        {
                                            if (_inner.ContentType != value)
                                            {
                                                _inner.ContentType = value;
                                                if ((_trackingMask & FotoTrackingFields.ContentType) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "ContentType", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? HashArquivo
                                    {
                                        get => _inner.HashArquivo;
                                        set
                                        {
                                            if (_inner.HashArquivo != value)
                                            {
                                                _inner.HashArquivo = value;
                                                if ((_trackingMask & FotoTrackingFields.HashArquivo) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "HashArquivo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CapturadaEmUtc
                                    {
                                        get => _inner.CapturadaEmUtc;
                                        set
                                        {
                                            if (_inner.CapturadaEmUtc != value)
                                            {
                                                _inner.CapturadaEmUtc = value;
                                                if ((_trackingMask & FotoTrackingFields.CapturadaEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "CapturadaEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Largura
                                    {
                                        get => _inner.Largura;
                                        set
                                        {
                                            if (_inner.Largura != value)
                                            {
                                                _inner.Largura = value;
                                                if ((_trackingMask & FotoTrackingFields.Largura) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "Largura", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Altura
                                    {
                                        get => _inner.Altura;
                                        set
                                        {
                                            if (_inner.Altura != value)
                                            {
                                                _inner.Altura = value;
                                                if ((_trackingMask & FotoTrackingFields.Altura) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "Altura", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FotoTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & FotoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FotoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FotoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FotoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Foto", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration