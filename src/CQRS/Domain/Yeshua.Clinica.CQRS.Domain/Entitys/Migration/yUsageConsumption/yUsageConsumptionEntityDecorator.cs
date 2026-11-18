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
                    public static class yUsageConsumptionTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ResourceKey = 1UL << 1;
            public const ulong OperationId = 1UL << 2;
            public const ulong Units = 1UL << 3;
            public const ulong UsesPeriod = 1UL << 4;
            public const ulong Status = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
            public const ulong OperationalEntityId = 1UL << 10;
        }

        public static class yUsageConsumptionOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ResourceKey = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Units = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UsesPeriod = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class yUsageConsumptionDecorator : IyUsageConsumptionEntity
{

                        private readonly IyUsageConsumptionEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yUsageConsumptionDecorator(IyUsageConsumptionEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yUsageConsumptionDecorator(
                            IyUsageConsumptionEntity inner,
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
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.Id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.ResourceKey) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "ResourceKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.ResourceKey, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string OperationId
                                    {
                                        get => _inner.OperationId;
                                        set
                                        {
                                            if (_inner.OperationId != value)
                                            {
                                                _inner.OperationId = value;
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.OperationId) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "OperationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.OperationId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal Units
                                    {
                                        get => _inner.Units;
                                        set
                                        {
                                            if (_inner.Units != value)
                                            {
                                                _inner.Units = value;
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.Units) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "Units", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.Units, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public bool UsesPeriod
                                    {
                                        get => _inner.UsesPeriod;
                                        set
                                        {
                                            if (_inner.UsesPeriod != value)
                                            {
                                                _inner.UsesPeriod = value;
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.UsesPeriod) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "UsesPeriod", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.UsesPeriod, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.Status, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yUsageConsumptionTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yUsageConsumption", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yUsageConsumptionOperationalFields.UserId, _trackingExecutionIdentity);
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