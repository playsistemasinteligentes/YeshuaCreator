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
                    public static class CanhotosTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CAR_ID = 1UL << 1;
            public const ulong ORD_ID = 1UL << 2;
            public const ulong NOT_ID = 1UL << 3;
            public const ulong CAN_DATA_ENTREGA = 1UL << 4;
            public const ulong CAN_IMG = 1UL << 5;
            public const ulong CAN_LAT_ENTREGA = 1UL << 6;
            public const ulong CAN_LONG_ENTREGA = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class CanhotosDecorator : ICanhotosEntity
{

                        private readonly ICanhotosEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CanhotosDecorator(ICanhotosEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CanhotosDecorator(
                            ICanhotosEntity inner,
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
                                                if ((_trackingMask & CanhotosTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_ID
                                    {
                                        get => _inner.CAR_ID;
                                        set
                                        {
                                            if (_inner.CAR_ID != value)
                                            {
                                                _inner.CAR_ID = value;
                                                if ((_trackingMask & CanhotosTrackingFields.CAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "CAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ID
                                    {
                                        get => _inner.ORD_ID;
                                        set
                                        {
                                            if (_inner.ORD_ID != value)
                                            {
                                                _inner.ORD_ID = value;
                                                if ((_trackingMask & CanhotosTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string NOT_ID
                                    {
                                        get => _inner.NOT_ID;
                                        set
                                        {
                                            if (_inner.NOT_ID != value)
                                            {
                                                _inner.NOT_ID = value;
                                                if ((_trackingMask & CanhotosTrackingFields.NOT_ID) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "NOT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAN_DATA_ENTREGA
                                    {
                                        get => _inner.CAN_DATA_ENTREGA;
                                        set
                                        {
                                            if (_inner.CAN_DATA_ENTREGA != value)
                                            {
                                                _inner.CAN_DATA_ENTREGA = value;
                                                if ((_trackingMask & CanhotosTrackingFields.CAN_DATA_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "CAN_DATA_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAN_IMG
                                    {
                                        get => _inner.CAN_IMG;
                                        set
                                        {
                                            if (_inner.CAN_IMG != value)
                                            {
                                                _inner.CAN_IMG = value;
                                                if ((_trackingMask & CanhotosTrackingFields.CAN_IMG) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "CAN_IMG", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAN_LAT_ENTREGA
                                    {
                                        get => _inner.CAN_LAT_ENTREGA;
                                        set
                                        {
                                            if (_inner.CAN_LAT_ENTREGA != value)
                                            {
                                                _inner.CAN_LAT_ENTREGA = value;
                                                if ((_trackingMask & CanhotosTrackingFields.CAN_LAT_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "CAN_LAT_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAN_LONG_ENTREGA
                                    {
                                        get => _inner.CAN_LONG_ENTREGA;
                                        set
                                        {
                                            if (_inner.CAN_LONG_ENTREGA != value)
                                            {
                                                _inner.CAN_LONG_ENTREGA = value;
                                                if ((_trackingMask & CanhotosTrackingFields.CAN_LONG_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "CAN_LONG_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CanhotosTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CanhotosTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CanhotosTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CanhotosTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Canhotos", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration