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
                    public static class ItensPackedTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong IPA_ID = 1UL << 1;
            public const ulong CAR_ID = 1UL << 2;
            public const ulong PRO_ID = 1UL << 3;
            public const ulong ORD_ID = 1UL << 4;
            public const ulong IPA_COORDC = 1UL << 5;
            public const ulong IPA_COORDL = 1UL << 6;
            public const ulong IPA_COORDA = 1UL << 7;
            public const ulong IPA_DIMC = 1UL << 8;
            public const ulong IPA_DIML = 1UL << 9;
            public const ulong IPA_DIMA = 1UL << 10;
            public const ulong IPA_QTD_POR_PALETE = 1UL << 11;
            public const ulong TenantID = 1UL << 12;
            public const ulong Deleted = 1UL << 13;
            public const ulong Changed = 1UL << 14;
            public const ulong UserId = 1UL << 15;
        }

        public partial class ItensPackedDecorator : IItensPackedEntity
{

                        private readonly IItensPackedEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ItensPackedDecorator(IItensPackedEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ItensPackedDecorator(
                            IItensPackedEntity inner,
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
                                                if ((_trackingMask & ItensPackedTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int IPA_ID
                                    {
                                        get => _inner.IPA_ID;
                                        set
                                        {
                                            if (_inner.IPA_ID != value)
                                            {
                                                _inner.IPA_ID = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.IPA_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "IPA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensPackedTrackingFields.CAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "CAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID
                                    {
                                        get => _inner.PRO_ID;
                                        set
                                        {
                                            if (_inner.PRO_ID != value)
                                            {
                                                _inner.PRO_ID = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensPackedTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? IPA_COORDC
                                    {
                                        get => _inner.IPA_COORDC;
                                        set
                                        {
                                            if (_inner.IPA_COORDC != value)
                                            {
                                                _inner.IPA_COORDC = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.IPA_COORDC) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "IPA_COORDC", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? IPA_COORDL
                                    {
                                        get => _inner.IPA_COORDL;
                                        set
                                        {
                                            if (_inner.IPA_COORDL != value)
                                            {
                                                _inner.IPA_COORDL = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.IPA_COORDL) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "IPA_COORDL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? IPA_COORDA
                                    {
                                        get => _inner.IPA_COORDA;
                                        set
                                        {
                                            if (_inner.IPA_COORDA != value)
                                            {
                                                _inner.IPA_COORDA = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.IPA_COORDA) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "IPA_COORDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? IPA_DIMC
                                    {
                                        get => _inner.IPA_DIMC;
                                        set
                                        {
                                            if (_inner.IPA_DIMC != value)
                                            {
                                                _inner.IPA_DIMC = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.IPA_DIMC) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "IPA_DIMC", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? IPA_DIML
                                    {
                                        get => _inner.IPA_DIML;
                                        set
                                        {
                                            if (_inner.IPA_DIML != value)
                                            {
                                                _inner.IPA_DIML = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.IPA_DIML) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "IPA_DIML", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? IPA_DIMA
                                    {
                                        get => _inner.IPA_DIMA;
                                        set
                                        {
                                            if (_inner.IPA_DIMA != value)
                                            {
                                                _inner.IPA_DIMA = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.IPA_DIMA) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "IPA_DIMA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? IPA_QTD_POR_PALETE
                                    {
                                        get => _inner.IPA_QTD_POR_PALETE;
                                        set
                                        {
                                            if (_inner.IPA_QTD_POR_PALETE != value)
                                            {
                                                _inner.IPA_QTD_POR_PALETE = value;
                                                if ((_trackingMask & ItensPackedTrackingFields.IPA_QTD_POR_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "IPA_QTD_POR_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensPackedTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensPackedTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensPackedTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensPackedTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ItensPacked", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration