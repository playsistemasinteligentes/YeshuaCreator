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
                    public static class CabvisaoTrackingFields
        {
            public const ulong CAB_ID = 1UL << 0;
            public const ulong CAB_DESC = 1UL << 1;
            public const ulong CAB_STATUS = 1UL << 2;
            public const ulong USE_ID = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public partial class CabvisaoDecorator : ICabvisaoEntity
{

                        private readonly ICabvisaoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CabvisaoDecorator(ICabvisaoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CabvisaoDecorator(
                            ICabvisaoEntity inner,
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
                                    public int CAB_ID
                                    {
                                        get => _inner.CAB_ID;
                                        set
                                        {
                                            if (_inner.CAB_ID != value)
                                            {
                                                _inner.CAB_ID = value;
                                                if ((_trackingMask & CabvisaoTrackingFields.CAB_ID) != 0UL)
                                                    _logger.DomainValueChanged("Cabvisao", "CAB_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAB_DESC
                                    {
                                        get => _inner.CAB_DESC;
                                        set
                                        {
                                            if (_inner.CAB_DESC != value)
                                            {
                                                _inner.CAB_DESC = value;
                                                if ((_trackingMask & CabvisaoTrackingFields.CAB_DESC) != 0UL)
                                                    _logger.DomainValueChanged("Cabvisao", "CAB_DESC", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int CAB_STATUS
                                    {
                                        get => _inner.CAB_STATUS;
                                        set
                                        {
                                            if (_inner.CAB_STATUS != value)
                                            {
                                                _inner.CAB_STATUS = value;
                                                if ((_trackingMask & CabvisaoTrackingFields.CAB_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("Cabvisao", "CAB_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int USE_ID
                                    {
                                        get => _inner.USE_ID;
                                        set
                                        {
                                            if (_inner.USE_ID != value)
                                            {
                                                _inner.USE_ID = value;
                                                if ((_trackingMask & CabvisaoTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("Cabvisao", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CabvisaoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Cabvisao", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CabvisaoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Cabvisao", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CabvisaoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Cabvisao", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CabvisaoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Cabvisao", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration