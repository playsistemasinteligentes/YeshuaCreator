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
                    public static class ySagaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CorrelationId = 1UL << 1;
            public const ulong Type = 1UL << 2;
            public const ulong Status = 1UL << 3;
            public const ulong KeyCurrentStep = 1UL << 4;
            public const ulong CreatedAt = 1UL << 5;
            public const ulong CompletedAt = 1UL << 6;
            public const ulong EntityType = 1UL << 7;
            public const ulong EntityId = 1UL << 8;
            public const ulong NextExecutionAt = 1UL << 9;
            public const ulong LockedAt = 1UL << 10;
            public const ulong LockedBy = 1UL << 11;
            public const ulong ProcessingScope = 1UL << 12;
            public const ulong TenantID = 1UL << 13;
            public const ulong OperationalEntityId = 1UL << 14;
            public const ulong Deleted = 1UL << 15;
            public const ulong Changed = 1UL << 16;
            public const ulong UserId = 1UL << 17;
            public const ulong RootOperationId = 1UL << 18;
            public const ulong OperationId = 1UL << 19;
            public const ulong ExecutionId = 1UL << 20;
            public const ulong CausationId = 1UL << 21;
        }

        public static class ySagaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CorrelationId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Type = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification KeyCurrentStep = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CreatedAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CompletedAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EntityType = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification NextExecutionAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LockedAt = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LockedBy = Dominio.Operational.OperationalDataClassification.Internal;
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

        public partial class ySagaDecorator : IySagaEntity
{

                        private readonly IySagaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ySagaDecorator(IySagaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ySagaDecorator(
                            IySagaEntity inner,
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
                                                if ((_trackingMask & ySagaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.Id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.CorrelationId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.Type) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "Type", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.Type, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.Status, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? KeyCurrentStep
                                    {
                                        get => _inner.KeyCurrentStep;
                                        set
                                        {
                                            if (_inner.KeyCurrentStep != value)
                                            {
                                                _inner.KeyCurrentStep = value;
                                                if ((_trackingMask & ySagaTrackingFields.KeyCurrentStep) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "KeyCurrentStep", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.KeyCurrentStep, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.CreatedAt) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "CreatedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.CreatedAt, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.CompletedAt) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "CompletedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.CompletedAt, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.EntityType) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "EntityType", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.EntityType, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.EntityId) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "EntityId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.EntityId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? NextExecutionAt
                                    {
                                        get => _inner.NextExecutionAt;
                                        set
                                        {
                                            if (_inner.NextExecutionAt != value)
                                            {
                                                _inner.NextExecutionAt = value;
                                                if ((_trackingMask & ySagaTrackingFields.NextExecutionAt) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "NextExecutionAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.NextExecutionAt, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? LockedAt
                                    {
                                        get => _inner.LockedAt;
                                        set
                                        {
                                            if (_inner.LockedAt != value)
                                            {
                                                _inner.LockedAt = value;
                                                if ((_trackingMask & ySagaTrackingFields.LockedAt) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "LockedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.LockedAt, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? LockedBy
                                    {
                                        get => _inner.LockedBy;
                                        set
                                        {
                                            if (_inner.LockedBy != value)
                                            {
                                                _inner.LockedBy = value;
                                                if ((_trackingMask & ySagaTrackingFields.LockedBy) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "LockedBy", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.LockedBy, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.UserId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.RootOperationId) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "RootOperationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.RootOperationId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.OperationId) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "OperationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.OperationId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.ExecutionId) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "ExecutionId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.ExecutionId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ySagaTrackingFields.CausationId) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "CausationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ySagaOperationalFields.CausationId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration