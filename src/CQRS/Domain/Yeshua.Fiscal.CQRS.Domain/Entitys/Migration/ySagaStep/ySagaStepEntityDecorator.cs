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
                    public static class ySagaStepTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong SagaId = 1UL << 1;
            public const ulong StepKey = 1UL << 2;
            public const ulong IndexOrder = 1UL << 3;
            public const ulong CorrelationId = 1UL << 4;
            public const ulong Status = 1UL << 5;
            public const ulong ExecutionCount = 1UL << 6;
            public const ulong LastExecutionAt = 1UL << 7;
            public const ulong CompletedAt = 1UL << 8;
            public const ulong ErrorMessage = 1UL << 9;
            public const ulong Payload = 1UL << 10;
            public const ulong RetryCount = 1UL << 11;
            public const ulong TenantID = 1UL << 12;
            public const ulong OperationalEntityId = 1UL << 13;
            public const ulong Deleted = 1UL << 14;
            public const ulong Changed = 1UL << 15;
            public const ulong UserId = 1UL << 16;
            public const ulong RootOperationId = 1UL << 17;
            public const ulong OperationId = 1UL << 18;
            public const ulong ExecutionId = 1UL << 19;
            public const ulong CausationId = 1UL << 20;
        }

        public static class ySagaStepOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SagaId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification StepKey = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IndexOrder = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CorrelationId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ExecutionCount = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LastExecutionAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CompletedAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ErrorMessage = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Payload = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RetryCount = Dominio.Operational.OperationalDataClassification.Internal;
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

        public partial class ySagaStepDecorator : IySagaStepEntity
{

                        private readonly IySagaStepEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ySagaStepDecorator(IySagaStepEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ySagaStepDecorator(
                            IySagaStepEntity inner,
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
                                                if ((_trackingMask & ySagaStepTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int SagaId
                                    {
                                        get => _inner.SagaId;
                                        set
                                        {
                                            if (_inner.SagaId != value)
                                            {
                                                _inner.SagaId = value;
                                                if ((_trackingMask & ySagaStepTrackingFields.SagaId) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "SagaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.SagaId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string StepKey
                                    {
                                        get => _inner.StepKey;
                                        set
                                        {
                                            if (_inner.StepKey != value)
                                            {
                                                _inner.StepKey = value;
                                                if ((_trackingMask & ySagaStepTrackingFields.StepKey) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "StepKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.StepKey, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int IndexOrder
                                    {
                                        get => _inner.IndexOrder;
                                        set
                                        {
                                            if (_inner.IndexOrder != value)
                                            {
                                                _inner.IndexOrder = value;
                                                if ((_trackingMask & ySagaStepTrackingFields.IndexOrder) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "IndexOrder", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.IndexOrder, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.CorrelationId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.Status, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int ExecutionCount
                                    {
                                        get => _inner.ExecutionCount;
                                        set
                                        {
                                            if (_inner.ExecutionCount != value)
                                            {
                                                _inner.ExecutionCount = value;
                                                if ((_trackingMask & ySagaStepTrackingFields.ExecutionCount) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "ExecutionCount", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.ExecutionCount, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? LastExecutionAt
                                    {
                                        get => _inner.LastExecutionAt;
                                        set
                                        {
                                            if (_inner.LastExecutionAt != value)
                                            {
                                                _inner.LastExecutionAt = value;
                                                if ((_trackingMask & ySagaStepTrackingFields.LastExecutionAt) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "LastExecutionAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.LastExecutionAt, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.CompletedAt) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "CompletedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.CompletedAt, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ErrorMessage
                                    {
                                        get => _inner.ErrorMessage;
                                        set
                                        {
                                            if (_inner.ErrorMessage != value)
                                            {
                                                _inner.ErrorMessage = value;
                                                if ((_trackingMask & ySagaStepTrackingFields.ErrorMessage) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "ErrorMessage", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.ErrorMessage, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Payload
                                    {
                                        get => _inner.Payload;
                                        set
                                        {
                                            if (_inner.Payload != value)
                                            {
                                                _inner.Payload = value;
                                                if ((_trackingMask & ySagaStepTrackingFields.Payload) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "Payload", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.Payload, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.RetryCount) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "RetryCount", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.RetryCount, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.UserId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.RootOperationId) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "RootOperationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.RootOperationId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.OperationId) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "OperationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.OperationId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.ExecutionId) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "ExecutionId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.ExecutionId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.CausationId) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "CausationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaStepOperationalFields.CausationId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration