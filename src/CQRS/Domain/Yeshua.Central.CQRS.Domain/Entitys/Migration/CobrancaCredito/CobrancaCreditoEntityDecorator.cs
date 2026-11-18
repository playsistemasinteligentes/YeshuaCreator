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
                    public static class CobrancaCreditoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Creditos = 1UL << 1;
            public const ulong Valor = 1UL << 2;
            public const ulong Status = 1UL << 3;
            public const ulong CriadaEmUtc = 1UL << 4;
            public const ulong VenceEmUtc = 1UL << 5;
            public const ulong Moeda = 1UL << 6;
            public const ulong Provedor = 1UL << 7;
            public const ulong PagaEmUtc = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
            public const ulong OperationalEntityId = 1UL << 13;
        }

        public static class CobrancaCreditoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Creditos = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Valor = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CriadaEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VenceEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Moeda = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Provedor = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PagaEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class CobrancaCreditoDecorator : ICobrancaCreditoEntity
{

                        private readonly ICobrancaCreditoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CobrancaCreditoDecorator(ICobrancaCreditoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CobrancaCreditoDecorator(
                            ICobrancaCreditoEntity inner,
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
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal Creditos
                                    {
                                        get => _inner.Creditos;
                                        set
                                        {
                                            if (_inner.Creditos != value)
                                            {
                                                _inner.Creditos = value;
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.Creditos) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "Creditos", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.Creditos, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal Valor
                                    {
                                        get => _inner.Valor;
                                        set
                                        {
                                            if (_inner.Valor != value)
                                            {
                                                _inner.Valor = value;
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.Valor) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "Valor", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.Valor, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.Status, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime CriadaEmUtc
                                    {
                                        get => _inner.CriadaEmUtc;
                                        set
                                        {
                                            if (_inner.CriadaEmUtc != value)
                                            {
                                                _inner.CriadaEmUtc = value;
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.CriadaEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "CriadaEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.CriadaEmUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime VenceEmUtc
                                    {
                                        get => _inner.VenceEmUtc;
                                        set
                                        {
                                            if (_inner.VenceEmUtc != value)
                                            {
                                                _inner.VenceEmUtc = value;
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.VenceEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "VenceEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.VenceEmUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Moeda
                                    {
                                        get => _inner.Moeda;
                                        set
                                        {
                                            if (_inner.Moeda != value)
                                            {
                                                _inner.Moeda = value;
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.Moeda) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "Moeda", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.Moeda, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Provedor
                                    {
                                        get => _inner.Provedor;
                                        set
                                        {
                                            if (_inner.Provedor != value)
                                            {
                                                _inner.Provedor = value;
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.Provedor) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "Provedor", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.Provedor, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? PagaEmUtc
                                    {
                                        get => _inner.PagaEmUtc;
                                        set
                                        {
                                            if (_inner.PagaEmUtc != value)
                                            {
                                                _inner.PagaEmUtc = value;
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.PagaEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "PagaEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.PagaEmUtc, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CobrancaCreditoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CobrancaCredito", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CobrancaCreditoOperationalFields.UserId, _trackingExecutionIdentity);
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