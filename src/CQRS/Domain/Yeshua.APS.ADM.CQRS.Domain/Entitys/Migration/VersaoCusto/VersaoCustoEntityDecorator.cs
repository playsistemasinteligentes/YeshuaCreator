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
                    public static class VersaoCustoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong VER_ID = 1UL << 1;
            public const ulong VER_STATUS = 1UL << 2;
            public const ulong VER_OBS = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public partial class VersaoCustoDecorator : IVersaoCustoEntity
{

                        private readonly IVersaoCustoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public VersaoCustoDecorator(IVersaoCustoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public VersaoCustoDecorator(
                            IVersaoCustoEntity inner,
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
                                                if ((_trackingMask & VersaoCustoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("VersaoCusto", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int VER_ID
                                    {
                                        get => _inner.VER_ID;
                                        set
                                        {
                                            if (_inner.VER_ID != value)
                                            {
                                                _inner.VER_ID = value;
                                                if ((_trackingMask & VersaoCustoTrackingFields.VER_ID) != 0UL)
                                                    _logger.DomainValueChanged("VersaoCusto", "VER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VER_STATUS
                                    {
                                        get => _inner.VER_STATUS;
                                        set
                                        {
                                            if (_inner.VER_STATUS != value)
                                            {
                                                _inner.VER_STATUS = value;
                                                if ((_trackingMask & VersaoCustoTrackingFields.VER_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("VersaoCusto", "VER_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VER_OBS
                                    {
                                        get => _inner.VER_OBS;
                                        set
                                        {
                                            if (_inner.VER_OBS != value)
                                            {
                                                _inner.VER_OBS = value;
                                                if ((_trackingMask & VersaoCustoTrackingFields.VER_OBS) != 0UL)
                                                    _logger.DomainValueChanged("VersaoCusto", "VER_OBS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VersaoCustoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("VersaoCusto", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VersaoCustoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("VersaoCusto", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VersaoCustoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("VersaoCusto", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VersaoCustoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("VersaoCusto", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration