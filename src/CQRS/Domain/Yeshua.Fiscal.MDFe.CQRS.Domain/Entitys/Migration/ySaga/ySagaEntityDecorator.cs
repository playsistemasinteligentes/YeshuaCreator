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
            public const ulong TenantID = 1UL << 12;
            public const ulong Deleted = 1UL << 13;
            public const ulong Changed = 1UL << 14;
            public const ulong UserId = 1UL << 15;
        }

        public partial class ySagaDecorator : IySagaEntity
{

                        private readonly IySagaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
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
                                                    _logger.DomainValueChanged("ySaga", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "Type", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string KeyCurrentStep
                                    {
                                        get => _inner.KeyCurrentStep;
                                        set
                                        {
                                            if (_inner.KeyCurrentStep != value)
                                            {
                                                _inner.KeyCurrentStep = value;
                                                if ((_trackingMask & ySagaTrackingFields.KeyCurrentStep) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "KeyCurrentStep", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "CreatedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "CompletedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EntityType
                                    {
                                        get => _inner.EntityType;
                                        set
                                        {
                                            if (_inner.EntityType != value)
                                            {
                                                _inner.EntityType = value;
                                                if ((_trackingMask & ySagaTrackingFields.EntityType) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "EntityType", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EntityId
                                    {
                                        get => _inner.EntityId;
                                        set
                                        {
                                            if (_inner.EntityId != value)
                                            {
                                                _inner.EntityId = value;
                                                if ((_trackingMask & ySagaTrackingFields.EntityId) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "EntityId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "NextExecutionAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "LockedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string LockedBy
                                    {
                                        get => _inner.LockedBy;
                                        set
                                        {
                                            if (_inner.LockedBy != value)
                                            {
                                                _inner.LockedBy = value;
                                                if ((_trackingMask & ySagaTrackingFields.LockedBy) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "LockedBy", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ySagaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ySagaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ySaga", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("ySaga", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration