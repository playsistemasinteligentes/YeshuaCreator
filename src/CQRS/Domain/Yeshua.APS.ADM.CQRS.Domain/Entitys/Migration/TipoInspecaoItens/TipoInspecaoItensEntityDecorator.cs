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
        }

        public partial class TipoInspecaoItensDecorator : ITipoInspecaoItensEntity
{

                        private readonly ITipoInspecaoItensEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
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
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "TII_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "TIV_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "ITI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("TipoInspecaoItens", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration