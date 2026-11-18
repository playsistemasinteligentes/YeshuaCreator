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
                    public static class ContratacaoUsoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Oferta = 1UL << 1;
            public const ulong Quantidade = 1UL << 2;
            public const ulong Creditos = 1UL << 3;
            public const ulong CriadaEmUtc = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
        }

        public static class ContratacaoUsoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Oferta = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Quantidade = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Creditos = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CriadaEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class ContratacaoUsoDecorator : IContratacaoUsoEntity
{

                        private readonly IContratacaoUsoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ContratacaoUsoDecorator(IContratacaoUsoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ContratacaoUsoDecorator(
                            IContratacaoUsoEntity inner,
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
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Oferta
                                    {
                                        get => _inner.Oferta;
                                        set
                                        {
                                            if (_inner.Oferta != value)
                                            {
                                                _inner.Oferta = value;
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.Oferta) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "Oferta", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.Oferta, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int Quantidade
                                    {
                                        get => _inner.Quantidade;
                                        set
                                        {
                                            if (_inner.Quantidade != value)
                                            {
                                                _inner.Quantidade = value;
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.Quantidade) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "Quantidade", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.Quantidade, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.Creditos) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "Creditos", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.Creditos, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.CriadaEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "CriadaEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.CriadaEmUtc, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ContratacaoUsoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ContratacaoUso", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ContratacaoUsoOperationalFields.UserId, _trackingExecutionIdentity);
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