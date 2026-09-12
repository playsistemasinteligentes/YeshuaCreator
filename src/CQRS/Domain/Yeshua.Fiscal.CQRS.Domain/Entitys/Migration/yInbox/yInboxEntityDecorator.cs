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
                    public static class yInboxTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MessageId = 1UL << 1;
            public const ulong Type = 1UL << 2;
            public const ulong EntityType = 1UL << 3;
            public const ulong EntityId = 1UL << 4;
            public const ulong CorrelationId = 1UL << 5;
            public const ulong Payload = 1UL << 6;
            public const ulong Status = 1UL << 7;
            public const ulong CreatedAt = 1UL << 8;
            public const ulong RetryCount = 1UL << 9;
            public const ulong LastError = 1UL << 10;
            public const ulong ProcessingAt = 1UL << 11;
            public const ulong NextAttemptAt = 1UL << 12;
            public const ulong SagaId = 1UL << 13;
            public const ulong SagaStepId = 1UL << 14;
            public const ulong TenantID = 1UL << 15;
            public const ulong Deleted = 1UL << 16;
            public const ulong Changed = 1UL << 17;
            public const ulong UserId = 1UL << 18;
        }

        public partial class yInboxDecorator : IyInboxEntity
{

                        private readonly IyInboxEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yInboxDecorator(IyInboxEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yInboxDecorator(
                            IyInboxEntity inner,
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
                                                if ((_trackingMask & yInboxTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? MessageId
                                    {
                                        get => _inner.MessageId;
                                        set
                                        {
                                            if (_inner.MessageId != value)
                                            {
                                                _inner.MessageId = value;
                                                if ((_trackingMask & yInboxTrackingFields.MessageId) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "MessageId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.Type) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "Type", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.EntityType) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "EntityType", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.EntityId) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "EntityId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? CorrelationId
                                    {
                                        get => _inner.CorrelationId;
                                        set
                                        {
                                            if (_inner.CorrelationId != value)
                                            {
                                                _inner.CorrelationId = value;
                                                if ((_trackingMask & yInboxTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Payload
                                    {
                                        get => _inner.Payload;
                                        set
                                        {
                                            if (_inner.Payload != value)
                                            {
                                                _inner.Payload = value;
                                                if ((_trackingMask & yInboxTrackingFields.Payload) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "Payload", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.CreatedAt) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "CreatedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int RetryCount
                                    {
                                        get => _inner.RetryCount;
                                        set
                                        {
                                            if (_inner.RetryCount != value)
                                            {
                                                _inner.RetryCount = value;
                                                if ((_trackingMask & yInboxTrackingFields.RetryCount) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "RetryCount", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? LastError
                                    {
                                        get => _inner.LastError;
                                        set
                                        {
                                            if (_inner.LastError != value)
                                            {
                                                _inner.LastError = value;
                                                if ((_trackingMask & yInboxTrackingFields.LastError) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "LastError", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ProcessingAt
                                    {
                                        get => _inner.ProcessingAt;
                                        set
                                        {
                                            if (_inner.ProcessingAt != value)
                                            {
                                                _inner.ProcessingAt = value;
                                                if ((_trackingMask & yInboxTrackingFields.ProcessingAt) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "ProcessingAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? NextAttemptAt
                                    {
                                        get => _inner.NextAttemptAt;
                                        set
                                        {
                                            if (_inner.NextAttemptAt != value)
                                            {
                                                _inner.NextAttemptAt = value;
                                                if ((_trackingMask & yInboxTrackingFields.NextAttemptAt) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "NextAttemptAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? SagaId
                                    {
                                        get => _inner.SagaId;
                                        set
                                        {
                                            if (_inner.SagaId != value)
                                            {
                                                _inner.SagaId = value;
                                                if ((_trackingMask & yInboxTrackingFields.SagaId) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "SagaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? SagaStepId
                                    {
                                        get => _inner.SagaStepId;
                                        set
                                        {
                                            if (_inner.SagaStepId != value)
                                            {
                                                _inner.SagaStepId = value;
                                                if ((_trackingMask & yInboxTrackingFields.SagaStepId) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "SagaStepId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yInboxTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yInbox", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration