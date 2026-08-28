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
                    public static class OrderTrackTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong OTK_ID = 1UL << 1;
            public const ulong OTK_SEQUENCIA = 1UL << 2;
            public const ulong OTK_VERSSAO = 1UL << 3;
            public const ulong ORD_ID = 1UL << 4;
            public const ulong OTK_EVENTO = 1UL << 5;
            public const ulong OTK_DATA_NECESSIDADE_DE = 1UL << 6;
            public const ulong OTK_DATA_NECESSIDADE_ATE = 1UL << 7;
            public const ulong OTK_DATA_PREVISTA = 1UL << 8;
            public const ulong OTK_DATA_REALIZADA = 1UL << 9;
            public const ulong FPR_ID = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
        }

        public partial class OrderTrackDecorator : IOrderTrackEntity
{

                        private readonly IOrderTrackEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OrderTrackDecorator(IOrderTrackEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OrderTrackDecorator(
                            IOrderTrackEntity inner,
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
                                                if ((_trackingMask & OrderTrackTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int OTK_ID
                                    {
                                        get => _inner.OTK_ID;
                                        set
                                        {
                                            if (_inner.OTK_ID != value)
                                            {
                                                _inner.OTK_ID = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.OTK_ID) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "OTK_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal OTK_SEQUENCIA
                                    {
                                        get => _inner.OTK_SEQUENCIA;
                                        set
                                        {
                                            if (_inner.OTK_SEQUENCIA != value)
                                            {
                                                _inner.OTK_SEQUENCIA = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.OTK_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "OTK_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int OTK_VERSSAO
                                    {
                                        get => _inner.OTK_VERSSAO;
                                        set
                                        {
                                            if (_inner.OTK_VERSSAO != value)
                                            {
                                                _inner.OTK_VERSSAO = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.OTK_VERSSAO) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "OTK_VERSSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OTK_EVENTO
                                    {
                                        get => _inner.OTK_EVENTO;
                                        set
                                        {
                                            if (_inner.OTK_EVENTO != value)
                                            {
                                                _inner.OTK_EVENTO = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.OTK_EVENTO) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "OTK_EVENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? OTK_DATA_NECESSIDADE_DE
                                    {
                                        get => _inner.OTK_DATA_NECESSIDADE_DE;
                                        set
                                        {
                                            if (_inner.OTK_DATA_NECESSIDADE_DE != value)
                                            {
                                                _inner.OTK_DATA_NECESSIDADE_DE = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.OTK_DATA_NECESSIDADE_DE) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "OTK_DATA_NECESSIDADE_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? OTK_DATA_NECESSIDADE_ATE
                                    {
                                        get => _inner.OTK_DATA_NECESSIDADE_ATE;
                                        set
                                        {
                                            if (_inner.OTK_DATA_NECESSIDADE_ATE != value)
                                            {
                                                _inner.OTK_DATA_NECESSIDADE_ATE = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.OTK_DATA_NECESSIDADE_ATE) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "OTK_DATA_NECESSIDADE_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? OTK_DATA_PREVISTA
                                    {
                                        get => _inner.OTK_DATA_PREVISTA;
                                        set
                                        {
                                            if (_inner.OTK_DATA_PREVISTA != value)
                                            {
                                                _inner.OTK_DATA_PREVISTA = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.OTK_DATA_PREVISTA) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "OTK_DATA_PREVISTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? OTK_DATA_REALIZADA
                                    {
                                        get => _inner.OTK_DATA_REALIZADA;
                                        set
                                        {
                                            if (_inner.OTK_DATA_REALIZADA != value)
                                            {
                                                _inner.OTK_DATA_REALIZADA = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.OTK_DATA_REALIZADA) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "OTK_DATA_REALIZADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_ID
                                    {
                                        get => _inner.FPR_ID;
                                        set
                                        {
                                            if (_inner.FPR_ID != value)
                                            {
                                                _inner.FPR_ID = value;
                                                if ((_trackingMask & OrderTrackTrackingFields.FPR_ID) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "FPR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("OrderTrack", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration