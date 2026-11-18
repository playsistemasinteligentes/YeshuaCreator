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
                    public static class CarteiraCreditoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Saldo = 1UL << 1;
            public const ulong TenantID = 1UL << 2;
            public const ulong Deleted = 1UL << 3;
            public const ulong Changed = 1UL << 4;
            public const ulong UserId = 1UL << 5;
            public const ulong OperationalEntityId = 1UL << 6;
        }

        public static class CarteiraCreditoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Saldo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class CarteiraCreditoDecorator : ICarteiraCreditoEntity
{

                        private readonly ICarteiraCreditoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CarteiraCreditoDecorator(ICarteiraCreditoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CarteiraCreditoDecorator(
                            ICarteiraCreditoEntity inner,
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
                                    public string? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & CarteiraCreditoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CarteiraCredito", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CarteiraCreditoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal Saldo
                                    {
                                        get => _inner.Saldo;
                                        set
                                        {
                                            if (_inner.Saldo != value)
                                            {
                                                _inner.Saldo = value;
                                                if ((_trackingMask & CarteiraCreditoTrackingFields.Saldo) != 0UL)
                                                    _logger.DomainValueChanged("CarteiraCredito", "Saldo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CarteiraCreditoOperationalFields.Saldo, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CarteiraCreditoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CarteiraCredito", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CarteiraCreditoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CarteiraCreditoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CarteiraCredito", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CarteiraCreditoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CarteiraCreditoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CarteiraCredito", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CarteiraCreditoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CarteiraCreditoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CarteiraCredito", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CarteiraCreditoOperationalFields.UserId, _trackingExecutionIdentity);
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