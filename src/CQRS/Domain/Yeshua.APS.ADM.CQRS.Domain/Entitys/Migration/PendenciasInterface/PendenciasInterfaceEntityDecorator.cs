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
                    public static class PendenciasInterfaceTrackingFields
        {
            public const ulong PEN_STATUS_OUT = 1UL << 0;
            public const ulong PEN_PROTOCOLO_OUT = 1UL << 1;
            public const ulong PEN_ID_PROTOCOLO_OUT = 1UL << 2;
            public const ulong PEN_STATUS_IN = 1UL << 3;
            public const ulong PEN_PROTOCOLO_IN = 1UL << 4;
            public const ulong PEN_ID_PROTOCOLO_IN = 1UL << 5;
            public const ulong DATA_ENTRADA = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
            public const ulong PEN_ID = 1UL << 11;
        }

        public partial class PendenciasInterfaceDecorator : IPendenciasInterfaceEntity
{

                        private readonly IPendenciasInterfaceEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PendenciasInterfaceDecorator(IPendenciasInterfaceEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PendenciasInterfaceDecorator(
                            IPendenciasInterfaceEntity inner,
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
                                    public string PEN_STATUS_OUT
                                    {
                                        get => _inner.PEN_STATUS_OUT;
                                        set
                                        {
                                            if (_inner.PEN_STATUS_OUT != value)
                                            {
                                                _inner.PEN_STATUS_OUT = value;
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.PEN_STATUS_OUT) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "PEN_STATUS_OUT", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PEN_PROTOCOLO_OUT
                                    {
                                        get => _inner.PEN_PROTOCOLO_OUT;
                                        set
                                        {
                                            if (_inner.PEN_PROTOCOLO_OUT != value)
                                            {
                                                _inner.PEN_PROTOCOLO_OUT = value;
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.PEN_PROTOCOLO_OUT) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "PEN_PROTOCOLO_OUT", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PEN_ID_PROTOCOLO_OUT
                                    {
                                        get => _inner.PEN_ID_PROTOCOLO_OUT;
                                        set
                                        {
                                            if (_inner.PEN_ID_PROTOCOLO_OUT != value)
                                            {
                                                _inner.PEN_ID_PROTOCOLO_OUT = value;
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.PEN_ID_PROTOCOLO_OUT) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "PEN_ID_PROTOCOLO_OUT", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PEN_STATUS_IN
                                    {
                                        get => _inner.PEN_STATUS_IN;
                                        set
                                        {
                                            if (_inner.PEN_STATUS_IN != value)
                                            {
                                                _inner.PEN_STATUS_IN = value;
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.PEN_STATUS_IN) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "PEN_STATUS_IN", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PEN_PROTOCOLO_IN
                                    {
                                        get => _inner.PEN_PROTOCOLO_IN;
                                        set
                                        {
                                            if (_inner.PEN_PROTOCOLO_IN != value)
                                            {
                                                _inner.PEN_PROTOCOLO_IN = value;
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.PEN_PROTOCOLO_IN) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "PEN_PROTOCOLO_IN", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PEN_ID_PROTOCOLO_IN
                                    {
                                        get => _inner.PEN_ID_PROTOCOLO_IN;
                                        set
                                        {
                                            if (_inner.PEN_ID_PROTOCOLO_IN != value)
                                            {
                                                _inner.PEN_ID_PROTOCOLO_IN = value;
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.PEN_ID_PROTOCOLO_IN) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "PEN_ID_PROTOCOLO_IN", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DATA_ENTRADA
                                    {
                                        get => _inner.DATA_ENTRADA;
                                        set
                                        {
                                            if (_inner.DATA_ENTRADA != value)
                                            {
                                                _inner.DATA_ENTRADA = value;
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.DATA_ENTRADA) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "DATA_ENTRADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int PEN_ID
                                    {
                                        get => _inner.PEN_ID;
                                        set
                                        {
                                            if (_inner.PEN_ID != value)
                                            {
                                                _inner.PEN_ID = value;
                                                if ((_trackingMask & PendenciasInterfaceTrackingFields.PEN_ID) != 0UL)
                                                    _logger.DomainValueChanged("PendenciasInterface", "PEN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration