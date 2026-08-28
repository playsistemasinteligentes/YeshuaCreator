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
                    public static class RotaRealizadaTrackingFields
        {
            public const ulong ROT_ID = 1UL << 0;
            public const ulong CAR_ID = 1UL << 1;
            public const ulong ROT_DATA_HORA = 1UL << 2;
            public const ulong ROT_LAT = 1UL << 3;
            public const ulong ROT_LONG = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class RotaRealizadaDecorator : IRotaRealizadaEntity
{

                        private readonly IRotaRealizadaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RotaRealizadaDecorator(IRotaRealizadaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RotaRealizadaDecorator(
                            IRotaRealizadaEntity inner,
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
                                    public int ROT_ID
                                    {
                                        get => _inner.ROT_ID;
                                        set
                                        {
                                            if (_inner.ROT_ID != value)
                                            {
                                                _inner.ROT_ID = value;
                                                if ((_trackingMask & RotaRealizadaTrackingFields.ROT_ID) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "ROT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaRealizadaTrackingFields.CAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "CAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ROT_DATA_HORA
                                    {
                                        get => _inner.ROT_DATA_HORA;
                                        set
                                        {
                                            if (_inner.ROT_DATA_HORA != value)
                                            {
                                                _inner.ROT_DATA_HORA = value;
                                                if ((_trackingMask & RotaRealizadaTrackingFields.ROT_DATA_HORA) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "ROT_DATA_HORA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_LAT
                                    {
                                        get => _inner.ROT_LAT;
                                        set
                                        {
                                            if (_inner.ROT_LAT != value)
                                            {
                                                _inner.ROT_LAT = value;
                                                if ((_trackingMask & RotaRealizadaTrackingFields.ROT_LAT) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "ROT_LAT", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_LONG
                                    {
                                        get => _inner.ROT_LONG;
                                        set
                                        {
                                            if (_inner.ROT_LONG != value)
                                            {
                                                _inner.ROT_LONG = value;
                                                if ((_trackingMask & RotaRealizadaTrackingFields.ROT_LONG) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "ROT_LONG", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaRealizadaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaRealizadaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaRealizadaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaRealizadaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("RotaRealizada", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration