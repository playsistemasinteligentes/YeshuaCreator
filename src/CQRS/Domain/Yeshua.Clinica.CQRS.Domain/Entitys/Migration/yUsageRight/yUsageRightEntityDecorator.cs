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
                    public static class yUsageRightTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ResourceKey = 1UL << 1;
            public const ulong PeriodUntilUtc = 1UL << 2;
            public const ulong GrantedUnits = 1UL << 3;
            public const ulong ReservedUnits = 1UL << 4;
            public const ulong ConsumedUnits = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
            public const ulong OperationalEntityId = 1UL << 10;
        }

        public static class yUsageRightOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ResourceKey = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PeriodUntilUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GrantedUnits = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ReservedUnits = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ConsumedUnits = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class yUsageRightDecorator : IyUsageRightEntity
{

                        private readonly IyUsageRightEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yUsageRightDecorator(IyUsageRightEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yUsageRightDecorator(
                            IyUsageRightEntity inner,
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
                                    public string? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & yUsageRightTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string ResourceKey
                                    {
                                        get => _inner.ResourceKey;
                                        set
                                        {
                                            if (_inner.ResourceKey != value)
                                            {
                                                _inner.ResourceKey = value;
                                                if ((_trackingMask & yUsageRightTrackingFields.ResourceKey) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "ResourceKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.ResourceKey, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? PeriodUntilUtc
                                    {
                                        get => _inner.PeriodUntilUtc;
                                        set
                                        {
                                            if (_inner.PeriodUntilUtc != value)
                                            {
                                                _inner.PeriodUntilUtc = value;
                                                if ((_trackingMask & yUsageRightTrackingFields.PeriodUntilUtc) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "PeriodUntilUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.PeriodUntilUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal GrantedUnits
                                    {
                                        get => _inner.GrantedUnits;
                                        set
                                        {
                                            if (_inner.GrantedUnits != value)
                                            {
                                                _inner.GrantedUnits = value;
                                                if ((_trackingMask & yUsageRightTrackingFields.GrantedUnits) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "GrantedUnits", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.GrantedUnits, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal ReservedUnits
                                    {
                                        get => _inner.ReservedUnits;
                                        set
                                        {
                                            if (_inner.ReservedUnits != value)
                                            {
                                                _inner.ReservedUnits = value;
                                                if ((_trackingMask & yUsageRightTrackingFields.ReservedUnits) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "ReservedUnits", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.ReservedUnits, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal ConsumedUnits
                                    {
                                        get => _inner.ConsumedUnits;
                                        set
                                        {
                                            if (_inner.ConsumedUnits != value)
                                            {
                                                _inner.ConsumedUnits = value;
                                                if ((_trackingMask & yUsageRightTrackingFields.ConsumedUnits) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "ConsumedUnits", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.ConsumedUnits, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageRightTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageRightTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageRightTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageRightTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yUsageRight", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageRightOperationalFields.UserId, _trackingExecutionIdentity);
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