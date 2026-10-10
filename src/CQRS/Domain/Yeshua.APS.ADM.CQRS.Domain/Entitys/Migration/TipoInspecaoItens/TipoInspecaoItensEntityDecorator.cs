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
                    public static class TipoInspecaoItensTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TII_ID = 1UL << 1;
            public const ulong TIV_ID = 1UL << 2;
            public const ulong ITI_ID = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
            public const ulong OperationalEntityId = 1UL << 8;
        }

        public static class TipoInspecaoItensOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TII_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIV_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ITI_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class TipoInspecaoItensDecorator : ITipoInspecaoItensEntity
{

                        private readonly ITipoInspecaoItensEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TipoInspecaoItensDecorator(ITipoInspecaoItensEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TipoInspecaoItensDecorator(
                            ITipoInspecaoItensEntity inner,
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
                                                if ((_trackingMask & TipoInspecaoItensTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoInspecaoItensOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int TII_ID
                                    {
                                        get => _inner.TII_ID;
                                        set
                                        {
                                            if (_inner.TII_ID != value)
                                            {
                                                _inner.TII_ID = value;
                                                if ((_trackingMask & TipoInspecaoItensTrackingFields.TII_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "TII_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoInspecaoItensOperationalFields.TII_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? TIV_ID
                                    {
                                        get => _inner.TIV_ID;
                                        set
                                        {
                                            if (_inner.TIV_ID != value)
                                            {
                                                _inner.TIV_ID = value;
                                                if ((_trackingMask & TipoInspecaoItensTrackingFields.TIV_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "TIV_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoInspecaoItensOperationalFields.TIV_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ITI_ID
                                    {
                                        get => _inner.ITI_ID;
                                        set
                                        {
                                            if (_inner.ITI_ID != value)
                                            {
                                                _inner.ITI_ID = value;
                                                if ((_trackingMask & TipoInspecaoItensTrackingFields.ITI_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "ITI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoInspecaoItensOperationalFields.ITI_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoInspecaoItensTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoInspecaoItensOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoInspecaoItensTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoInspecaoItensOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoInspecaoItensTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoInspecaoItensOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoInspecaoItensTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoInspecaoItensOperationalFields.UserId, _trackingExecutionIdentity);
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