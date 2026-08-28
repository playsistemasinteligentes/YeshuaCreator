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
                    public static class CotasTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong COT_ID = 1UL << 1;
            public const ulong COT_DATA_DE = 1UL << 2;
            public const ulong COT_DATA_ATE = 1UL << 3;
            public const ulong COT_VALOR = 1UL << 4;
            public const ulong COT_OCUPADO = 1UL << 5;
            public const ulong REP_ID = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
        }

        public partial class CotasDecorator : ICotasEntity
{

                        private readonly ICotasEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CotasDecorator(ICotasEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CotasDecorator(
                            ICotasEntity inner,
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
                                                if ((_trackingMask & CotasTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int COT_ID
                                    {
                                        get => _inner.COT_ID;
                                        set
                                        {
                                            if (_inner.COT_ID != value)
                                            {
                                                _inner.COT_ID = value;
                                                if ((_trackingMask & CotasTrackingFields.COT_ID) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "COT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? COT_DATA_DE
                                    {
                                        get => _inner.COT_DATA_DE;
                                        set
                                        {
                                            if (_inner.COT_DATA_DE != value)
                                            {
                                                _inner.COT_DATA_DE = value;
                                                if ((_trackingMask & CotasTrackingFields.COT_DATA_DE) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "COT_DATA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? COT_DATA_ATE
                                    {
                                        get => _inner.COT_DATA_ATE;
                                        set
                                        {
                                            if (_inner.COT_DATA_ATE != value)
                                            {
                                                _inner.COT_DATA_ATE = value;
                                                if ((_trackingMask & CotasTrackingFields.COT_DATA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "COT_DATA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COT_VALOR
                                    {
                                        get => _inner.COT_VALOR;
                                        set
                                        {
                                            if (_inner.COT_VALOR != value)
                                            {
                                                _inner.COT_VALOR = value;
                                                if ((_trackingMask & CotasTrackingFields.COT_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "COT_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COT_OCUPADO
                                    {
                                        get => _inner.COT_OCUPADO;
                                        set
                                        {
                                            if (_inner.COT_OCUPADO != value)
                                            {
                                                _inner.COT_OCUPADO = value;
                                                if ((_trackingMask & CotasTrackingFields.COT_OCUPADO) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "COT_OCUPADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int REP_ID
                                    {
                                        get => _inner.REP_ID;
                                        set
                                        {
                                            if (_inner.REP_ID != value)
                                            {
                                                _inner.REP_ID = value;
                                                if ((_trackingMask & CotasTrackingFields.REP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "REP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CotasTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CotasTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CotasTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CotasTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Cotas", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration