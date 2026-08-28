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
                    public static class LotesTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MOV_LOTE = 1UL << 1;
            public const ulong MOV_SUB_LOTE = 1UL << 2;
            public const ulong LOT_LARGURA = 1UL << 3;
            public const ulong LOT_COMPRIMENTO = 1UL << 4;
            public const ulong LOT_DIAMETRO = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class LotesDecorator : ILotesEntity
{

                        private readonly ILotesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public LotesDecorator(ILotesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public LotesDecorator(
                            ILotesEntity inner,
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
                                                if ((_trackingMask & LotesTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_LOTE
                                    {
                                        get => _inner.MOV_LOTE;
                                        set
                                        {
                                            if (_inner.MOV_LOTE != value)
                                            {
                                                _inner.MOV_LOTE = value;
                                                if ((_trackingMask & LotesTrackingFields.MOV_LOTE) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "MOV_LOTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_SUB_LOTE
                                    {
                                        get => _inner.MOV_SUB_LOTE;
                                        set
                                        {
                                            if (_inner.MOV_SUB_LOTE != value)
                                            {
                                                _inner.MOV_SUB_LOTE = value;
                                                if ((_trackingMask & LotesTrackingFields.MOV_SUB_LOTE) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "MOV_SUB_LOTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? LOT_LARGURA
                                    {
                                        get => _inner.LOT_LARGURA;
                                        set
                                        {
                                            if (_inner.LOT_LARGURA != value)
                                            {
                                                _inner.LOT_LARGURA = value;
                                                if ((_trackingMask & LotesTrackingFields.LOT_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "LOT_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? LOT_COMPRIMENTO
                                    {
                                        get => _inner.LOT_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.LOT_COMPRIMENTO != value)
                                            {
                                                _inner.LOT_COMPRIMENTO = value;
                                                if ((_trackingMask & LotesTrackingFields.LOT_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "LOT_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? LOT_DIAMETRO
                                    {
                                        get => _inner.LOT_DIAMETRO;
                                        set
                                        {
                                            if (_inner.LOT_DIAMETRO != value)
                                            {
                                                _inner.LOT_DIAMETRO = value;
                                                if ((_trackingMask & LotesTrackingFields.LOT_DIAMETRO) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "LOT_DIAMETRO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LotesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LotesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LotesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LotesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Lotes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration