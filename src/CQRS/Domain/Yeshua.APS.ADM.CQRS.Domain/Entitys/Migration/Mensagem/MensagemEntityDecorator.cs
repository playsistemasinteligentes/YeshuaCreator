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
                    public static class MensagemTrackingFields
        {
            public const ulong MEN_ID = 1UL << 0;
            public const ulong MEN_SEND = 1UL << 1;
            public const ulong MEN_EMISSION = 1UL << 2;
            public const ulong MEN_STATUS = 1UL << 3;
            public const ulong MEN_RECEIVE = 1UL << 4;
            public const ulong MEN_TYPE = 1UL << 5;
            public const ulong MEN_QTD_TRY_SEND = 1UL << 6;
            public const ulong MEN_DATE_TRY_SEND = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class MensagemDecorator : IMensagemEntity
{

                        private readonly IMensagemEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MensagemDecorator(IMensagemEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MensagemDecorator(
                            IMensagemEntity inner,
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
                                    public string MEN_ID
                                    {
                                        get => _inner.MEN_ID;
                                        set
                                        {
                                            if (_inner.MEN_ID != value)
                                            {
                                                _inner.MEN_ID = value;
                                                if ((_trackingMask & MensagemTrackingFields.MEN_ID) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "MEN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MEN_SEND
                                    {
                                        get => _inner.MEN_SEND;
                                        set
                                        {
                                            if (_inner.MEN_SEND != value)
                                            {
                                                _inner.MEN_SEND = value;
                                                if ((_trackingMask & MensagemTrackingFields.MEN_SEND) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "MEN_SEND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? MEN_EMISSION
                                    {
                                        get => _inner.MEN_EMISSION;
                                        set
                                        {
                                            if (_inner.MEN_EMISSION != value)
                                            {
                                                _inner.MEN_EMISSION = value;
                                                if ((_trackingMask & MensagemTrackingFields.MEN_EMISSION) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "MEN_EMISSION", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MEN_STATUS
                                    {
                                        get => _inner.MEN_STATUS;
                                        set
                                        {
                                            if (_inner.MEN_STATUS != value)
                                            {
                                                _inner.MEN_STATUS = value;
                                                if ((_trackingMask & MensagemTrackingFields.MEN_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "MEN_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MEN_RECEIVE
                                    {
                                        get => _inner.MEN_RECEIVE;
                                        set
                                        {
                                            if (_inner.MEN_RECEIVE != value)
                                            {
                                                _inner.MEN_RECEIVE = value;
                                                if ((_trackingMask & MensagemTrackingFields.MEN_RECEIVE) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "MEN_RECEIVE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MEN_TYPE
                                    {
                                        get => _inner.MEN_TYPE;
                                        set
                                        {
                                            if (_inner.MEN_TYPE != value)
                                            {
                                                _inner.MEN_TYPE = value;
                                                if ((_trackingMask & MensagemTrackingFields.MEN_TYPE) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "MEN_TYPE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MEN_QTD_TRY_SEND
                                    {
                                        get => _inner.MEN_QTD_TRY_SEND;
                                        set
                                        {
                                            if (_inner.MEN_QTD_TRY_SEND != value)
                                            {
                                                _inner.MEN_QTD_TRY_SEND = value;
                                                if ((_trackingMask & MensagemTrackingFields.MEN_QTD_TRY_SEND) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "MEN_QTD_TRY_SEND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? MEN_DATE_TRY_SEND
                                    {
                                        get => _inner.MEN_DATE_TRY_SEND;
                                        set
                                        {
                                            if (_inner.MEN_DATE_TRY_SEND != value)
                                            {
                                                _inner.MEN_DATE_TRY_SEND = value;
                                                if ((_trackingMask & MensagemTrackingFields.MEN_DATE_TRY_SEND) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "MEN_DATE_TRY_SEND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MensagemTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MensagemTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MensagemTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MensagemTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Mensagem", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration