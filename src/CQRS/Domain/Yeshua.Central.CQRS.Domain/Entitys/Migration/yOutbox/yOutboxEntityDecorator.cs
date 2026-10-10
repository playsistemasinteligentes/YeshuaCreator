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
                    public static class yOutboxTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MessageId = 1UL << 1;
            public const ulong Type = 1UL << 2;
            public const ulong EntityType = 1UL << 3;
            public const ulong EntityId = 1UL << 4;
            public const ulong CorrelationId = 1UL << 5;
            public const ulong Payload = 1UL << 6;
            public const ulong Status = 1UL << 7;
            public const ulong TransportType = 1UL << 8;
            public const ulong TransportData = 1UL << 9;
            public const ulong CreatedAt = 1UL << 10;
            public const ulong SentAt = 1UL << 11;
            public const ulong RetryCount = 1UL << 12;
            public const ulong LastError = 1UL << 13;
            public const ulong ProcessingAt = 1UL << 14;
            public const ulong NextAttemptAt = 1UL << 15;
            public const ulong SagaId = 1UL << 16;
            public const ulong SagaStepId = 1UL << 17;
            public const ulong ProcessingScope = 1UL << 18;
            public const ulong TenantID = 1UL << 19;
            public const ulong OperationalEntityId = 1UL << 20;
            public const ulong Deleted = 1UL << 21;
            public const ulong Changed = 1UL << 22;
            public const ulong UserId = 1UL << 23;
            public const ulong RootOperationId = 1UL << 24;
            public const ulong OperationId = 1UL << 25;
            public const ulong ExecutionId = 1UL << 26;
            public const ulong CausationId = 1UL << 27;
        }

        public static class yOutboxOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MessageId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Type = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EntityType = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CorrelationId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Payload = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TransportType = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TransportData = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CreatedAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SentAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RetryCount = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LastError = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProcessingAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification NextAttemptAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SagaId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SagaStepId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProcessingScope = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RootOperationId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ExecutionId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CausationId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class yOutboxDecorator : IyOutboxEntity
{

                        private readonly IyOutboxEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yOutboxDecorator(IyOutboxEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yOutboxDecorator(
                            IyOutboxEntity inner,
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
                                                if ((_trackingMask & yOutboxTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.Id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.MessageId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "MessageId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.MessageId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.Type) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "Type", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.Type, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.EntityType) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "EntityType", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.EntityType, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.EntityId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "EntityId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.EntityId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.CorrelationId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.Payload) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "Payload", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.Payload, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.Status, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int TransportType
                                    {
                                        get => _inner.TransportType;
                                        set
                                        {
                                            if (_inner.TransportType != value)
                                            {
                                                _inner.TransportType = value;
                                                if ((_trackingMask & yOutboxTrackingFields.TransportType) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "TransportType", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.TransportType, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? TransportData
                                    {
                                        get => _inner.TransportData;
                                        set
                                        {
                                            if (_inner.TransportData != value)
                                            {
                                                _inner.TransportData = value;
                                                if ((_trackingMask & yOutboxTrackingFields.TransportData) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "TransportData", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.TransportData, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.CreatedAt) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "CreatedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.CreatedAt, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? SentAt
                                    {
                                        get => _inner.SentAt;
                                        set
                                        {
                                            if (_inner.SentAt != value)
                                            {
                                                _inner.SentAt = value;
                                                if ((_trackingMask & yOutboxTrackingFields.SentAt) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "SentAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.SentAt, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.RetryCount) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "RetryCount", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.RetryCount, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.LastError) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "LastError", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.LastError, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.ProcessingAt) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "ProcessingAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.ProcessingAt, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.NextAttemptAt) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "NextAttemptAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.NextAttemptAt, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.SagaId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "SagaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.SagaId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.SagaStepId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "SagaStepId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.SagaStepId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string ProcessingScope => _inner.ProcessingScope;

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & yOutboxTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.TenantID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public bool? Deleted
                                    {
                                        get => _inner.Deleted;
                                        set
                                        {
                                            if (_inner.Deleted != value)
                                            {
                                                _inner.Deleted = value;
                                                if ((_trackingMask & yOutboxTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yOutboxTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? RootOperationId
                                    {
                                        get => _inner.RootOperationId;
                                        set
                                        {
                                            if (_inner.RootOperationId != value)
                                            {
                                                _inner.RootOperationId = value;
                                                if ((_trackingMask & yOutboxTrackingFields.RootOperationId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "RootOperationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.RootOperationId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? OperationId
                                    {
                                        get => _inner.OperationId;
                                        set
                                        {
                                            if (_inner.OperationId != value)
                                            {
                                                _inner.OperationId = value;
                                                if ((_trackingMask & yOutboxTrackingFields.OperationId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "OperationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.OperationId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ExecutionId
                                    {
                                        get => _inner.ExecutionId;
                                        set
                                        {
                                            if (_inner.ExecutionId != value)
                                            {
                                                _inner.ExecutionId = value;
                                                if ((_trackingMask & yOutboxTrackingFields.ExecutionId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "ExecutionId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.ExecutionId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CausationId
                                    {
                                        get => _inner.CausationId;
                                        set
                                        {
                                            if (_inner.CausationId != value)
                                            {
                                                _inner.CausationId = value;
                                                if ((_trackingMask & yOutboxTrackingFields.CausationId) != 0UL)
                                                    _logger.DomainValueChanged("yOutbox", "CausationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yOutboxOperationalFields.CausationId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration