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
                    public static class ItenCargaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CAR_ID = 1UL << 1;
            public const ulong ORD_ID = 1UL << 2;
            public const ulong ITC_ENTREGA_PLANEJADA = 1UL << 3;
            public const ulong ITC_ENTREGA_REALIZADA = 1UL << 4;
            public const ulong ITC_ORDEM_ENTREGA = 1UL << 5;
            public const ulong ITC_QTD_PLANEJADA = 1UL << 6;
            public const ulong ITC_QTD_REALIZADA = 1UL << 7;
            public const ulong ORD_HASH_KEY = 1UL << 8;
            public const ulong NOT_ID = 1UL << 9;
            public const ulong NOT_EMISSAO = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
            public const ulong OperationalEntityId = 1UL << 15;
        }

        public static class ItenCargaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CAR_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ORD_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ITC_ENTREGA_PLANEJADA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ITC_ENTREGA_REALIZADA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ITC_ORDEM_ENTREGA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ITC_QTD_PLANEJADA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ITC_QTD_REALIZADA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ORD_HASH_KEY = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification NOT_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification NOT_EMISSAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class ItenCargaDecorator : IItenCargaEntity
{

                        private readonly IItenCargaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ItenCargaDecorator(IItenCargaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ItenCargaDecorator(
                            IItenCargaEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingExecutionIdentity = context is null
                                ? default
                                : new Dominio.Operational.OperationalExecutionIdentity(
                                    context.RootOperationId,
                                    context.OperationId,
                                    context.ExecutionId,
                                    context.CausationId);
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
                                                if ((_trackingMask & ItenCargaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.Id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItenCargaTrackingFields.CAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "CAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.CAR_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItenCargaTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.ORD_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime ITC_ENTREGA_PLANEJADA
                                    {
                                        get => _inner.ITC_ENTREGA_PLANEJADA;
                                        set
                                        {
                                            if (_inner.ITC_ENTREGA_PLANEJADA != value)
                                            {
                                                _inner.ITC_ENTREGA_PLANEJADA = value;
                                                if ((_trackingMask & ItenCargaTrackingFields.ITC_ENTREGA_PLANEJADA) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "ITC_ENTREGA_PLANEJADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.ITC_ENTREGA_PLANEJADA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime ITC_ENTREGA_REALIZADA
                                    {
                                        get => _inner.ITC_ENTREGA_REALIZADA;
                                        set
                                        {
                                            if (_inner.ITC_ENTREGA_REALIZADA != value)
                                            {
                                                _inner.ITC_ENTREGA_REALIZADA = value;
                                                if ((_trackingMask & ItenCargaTrackingFields.ITC_ENTREGA_REALIZADA) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "ITC_ENTREGA_REALIZADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.ITC_ENTREGA_REALIZADA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int ITC_ORDEM_ENTREGA
                                    {
                                        get => _inner.ITC_ORDEM_ENTREGA;
                                        set
                                        {
                                            if (_inner.ITC_ORDEM_ENTREGA != value)
                                            {
                                                _inner.ITC_ORDEM_ENTREGA = value;
                                                if ((_trackingMask & ItenCargaTrackingFields.ITC_ORDEM_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "ITC_ORDEM_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.ITC_ORDEM_ENTREGA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal ITC_QTD_PLANEJADA
                                    {
                                        get => _inner.ITC_QTD_PLANEJADA;
                                        set
                                        {
                                            if (_inner.ITC_QTD_PLANEJADA != value)
                                            {
                                                _inner.ITC_QTD_PLANEJADA = value;
                                                if ((_trackingMask & ItenCargaTrackingFields.ITC_QTD_PLANEJADA) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "ITC_QTD_PLANEJADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.ITC_QTD_PLANEJADA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal ITC_QTD_REALIZADA
                                    {
                                        get => _inner.ITC_QTD_REALIZADA;
                                        set
                                        {
                                            if (_inner.ITC_QTD_REALIZADA != value)
                                            {
                                                _inner.ITC_QTD_REALIZADA = value;
                                                if ((_trackingMask & ItenCargaTrackingFields.ITC_QTD_REALIZADA) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "ITC_QTD_REALIZADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.ITC_QTD_REALIZADA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ORD_HASH_KEY
                                    {
                                        get => _inner.ORD_HASH_KEY;
                                        set
                                        {
                                            if (_inner.ORD_HASH_KEY != value)
                                            {
                                                _inner.ORD_HASH_KEY = value;
                                                if ((_trackingMask & ItenCargaTrackingFields.ORD_HASH_KEY) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "ORD_HASH_KEY", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.ORD_HASH_KEY, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? NOT_ID
                                    {
                                        get => _inner.NOT_ID;
                                        set
                                        {
                                            if (_inner.NOT_ID != value)
                                            {
                                                _inner.NOT_ID = value;
                                                if ((_trackingMask & ItenCargaTrackingFields.NOT_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "NOT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.NOT_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? NOT_EMISSAO
                                    {
                                        get => _inner.NOT_EMISSAO;
                                        set
                                        {
                                            if (_inner.NOT_EMISSAO != value)
                                            {
                                                _inner.NOT_EMISSAO = value;
                                                if ((_trackingMask & ItenCargaTrackingFields.NOT_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "NOT_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.NOT_EMISSAO, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItenCargaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItenCargaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItenCargaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItenCargaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ItenCarga", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItenCargaOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration