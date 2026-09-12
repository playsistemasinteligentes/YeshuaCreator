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
                    public static class yFileUploadTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Type = 1UL << 1;
            public const ulong Status = 1UL << 2;
            public const ulong FilePath = 1UL << 3;
            public const ulong FileSize = 1UL << 4;
            public const ulong EntityType = 1UL << 5;
            public const ulong EntityId = 1UL << 6;
            public const ulong CreatedAt = 1UL << 7;
            public const ulong CompletedAt = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
        }

        public partial class yFileUploadDecorator : IyFileUploadEntity
{

                        private readonly IyFileUploadEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yFileUploadDecorator(IyFileUploadEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yFileUploadDecorator(
                            IyFileUploadEntity inner,
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
                                                if ((_trackingMask & yFileUploadTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Type
                                    {
                                        get => _inner.Type;
                                        set
                                        {
                                            if (_inner.Type != value)
                                            {
                                                _inner.Type = value;
                                                if ((_trackingMask & yFileUploadTrackingFields.Type) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "Type", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yFileUploadTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? FilePath
                                    {
                                        get => _inner.FilePath;
                                        set
                                        {
                                            if (_inner.FilePath != value)
                                            {
                                                _inner.FilePath = value;
                                                if ((_trackingMask & yFileUploadTrackingFields.FilePath) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "FilePath", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public long? FileSize
                                    {
                                        get => _inner.FileSize;
                                        set
                                        {
                                            if (_inner.FileSize != value)
                                            {
                                                _inner.FileSize = value;
                                                if ((_trackingMask & yFileUploadTrackingFields.FileSize) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "FileSize", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? EntityType
                                    {
                                        get => _inner.EntityType;
                                        set
                                        {
                                            if (_inner.EntityType != value)
                                            {
                                                _inner.EntityType = value;
                                                if ((_trackingMask & yFileUploadTrackingFields.EntityType) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "EntityType", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? EntityId
                                    {
                                        get => _inner.EntityId;
                                        set
                                        {
                                            if (_inner.EntityId != value)
                                            {
                                                _inner.EntityId = value;
                                                if ((_trackingMask & yFileUploadTrackingFields.EntityId) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "EntityId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime CreatedAt
                                    {
                                        get => _inner.CreatedAt;
                                        set
                                        {
                                            if (_inner.CreatedAt != value)
                                            {
                                                _inner.CreatedAt = value;
                                                if ((_trackingMask & yFileUploadTrackingFields.CreatedAt) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "CreatedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CompletedAt
                                    {
                                        get => _inner.CompletedAt;
                                        set
                                        {
                                            if (_inner.CompletedAt != value)
                                            {
                                                _inner.CompletedAt = value;
                                                if ((_trackingMask & yFileUploadTrackingFields.CompletedAt) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "CompletedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yFileUploadTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yFileUploadTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yFileUploadTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yFileUploadTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yFileUpload", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration