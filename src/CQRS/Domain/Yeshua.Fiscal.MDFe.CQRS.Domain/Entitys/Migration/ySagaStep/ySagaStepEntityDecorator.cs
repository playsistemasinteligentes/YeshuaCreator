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
            public const ulong Deleted = 1UL << 13;
            public const ulong Changed = 1UL << 14;
            public const ulong UserId = 1UL << 15;
        }

        public partial class ySagaStepDecorator : IySagaStepEntity
{

                        private readonly IySagaStepEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
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
                                                    _logger.DomainValueChanged("ySagaStep", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "SagaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "StepKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "IndexOrder", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "ExecutionCount", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "LastExecutionAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "CompletedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ErrorMessage
                                    {
                                        get => _inner.ErrorMessage;
                                        set
                                        {
                                            if (_inner.ErrorMessage != value)
                                            {
                                                _inner.ErrorMessage = value;
                                                if ((_trackingMask & ySagaStepTrackingFields.ErrorMessage) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "ErrorMessage", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.Payload) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "Payload", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "RetryCount", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ySagaStepTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ySagaStep", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySagaStep", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration