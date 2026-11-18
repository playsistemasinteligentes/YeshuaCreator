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
                    public static class MovimentoCreditoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Tipo = 1UL << 1;
            public const ulong Referencia = 1UL << 2;
            public const ulong Quantidade = 1UL << 3;
            public const ulong SaldoApos = 1UL << 4;
            public const ulong CriadoEmUtc = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
            public const ulong OperationalEntityId = 1UL << 10;
        }

        public static class MovimentoCreditoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Tipo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Referencia = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Quantidade = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SaldoApos = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CriadoEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class MovimentoCreditoDecorator : IMovimentoCreditoEntity
{

                        private readonly IMovimentoCreditoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MovimentoCreditoDecorator(IMovimentoCreditoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MovimentoCreditoDecorator(
                            IMovimentoCreditoEntity inner,
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
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Tipo
                                    {
                                        get => _inner.Tipo;
                                        set
                                        {
                                            if (_inner.Tipo != value)
                                            {
                                                _inner.Tipo = value;
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.Tipo) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "Tipo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.Tipo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Referencia
                                    {
                                        get => _inner.Referencia;
                                        set
                                        {
                                            if (_inner.Referencia != value)
                                            {
                                                _inner.Referencia = value;
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.Referencia) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "Referencia", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.Referencia, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal Quantidade
                                    {
                                        get => _inner.Quantidade;
                                        set
                                        {
                                            if (_inner.Quantidade != value)
                                            {
                                                _inner.Quantidade = value;
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.Quantidade) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "Quantidade", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.Quantidade, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal SaldoApos
                                    {
                                        get => _inner.SaldoApos;
                                        set
                                        {
                                            if (_inner.SaldoApos != value)
                                            {
                                                _inner.SaldoApos = value;
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.SaldoApos) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "SaldoApos", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.SaldoApos, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime CriadoEmUtc
                                    {
                                        get => _inner.CriadoEmUtc;
                                        set
                                        {
                                            if (_inner.CriadoEmUtc != value)
                                            {
                                                _inner.CriadoEmUtc = value;
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.CriadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "CriadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.CriadoEmUtc, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MovimentoCreditoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoCredito", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentoCreditoOperationalFields.UserId, _trackingExecutionIdentity);
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