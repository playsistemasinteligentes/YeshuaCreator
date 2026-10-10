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
                    public static class CorConfiguracaoGraficoTrackingFields
        {
            public const ulong COR_ID = 1UL << 0;
            public const ulong COR_PERCENTUAL_INI = 1UL << 1;
            public const ulong COR_PERCENTUAL_FIM = 1UL << 2;
            public const ulong COR_DESCRICAO = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
            public const ulong OperationalEntityId = 1UL << 8;
        }

        public static class CorConfiguracaoGraficoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification COR_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification COR_PERCENTUAL_INI = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification COR_PERCENTUAL_FIM = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification COR_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class CorConfiguracaoGraficoDecorator : ICorConfiguracaoGraficoEntity
{

                        private readonly ICorConfiguracaoGraficoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CorConfiguracaoGraficoDecorator(ICorConfiguracaoGraficoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CorConfiguracaoGraficoDecorator(
                            ICorConfiguracaoGraficoEntity inner,
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
                                    public string COR_ID
                                    {
                                        get => _inner.COR_ID;
                                        set
                                        {
                                            if (_inner.COR_ID != value)
                                            {
                                                _inner.COR_ID = value;
                                                if ((_trackingMask & CorConfiguracaoGraficoTrackingFields.COR_ID) != 0UL)
                                                    _logger.DomainValueChanged("CorConfiguracaoGrafico", "COR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CorConfiguracaoGraficoOperationalFields.COR_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal COR_PERCENTUAL_INI
                                    {
                                        get => _inner.COR_PERCENTUAL_INI;
                                        set
                                        {
                                            if (_inner.COR_PERCENTUAL_INI != value)
                                            {
                                                _inner.COR_PERCENTUAL_INI = value;
                                                if ((_trackingMask & CorConfiguracaoGraficoTrackingFields.COR_PERCENTUAL_INI) != 0UL)
                                                    _logger.DomainValueChanged("CorConfiguracaoGrafico", "COR_PERCENTUAL_INI", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CorConfiguracaoGraficoOperationalFields.COR_PERCENTUAL_INI, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal COR_PERCENTUAL_FIM
                                    {
                                        get => _inner.COR_PERCENTUAL_FIM;
                                        set
                                        {
                                            if (_inner.COR_PERCENTUAL_FIM != value)
                                            {
                                                _inner.COR_PERCENTUAL_FIM = value;
                                                if ((_trackingMask & CorConfiguracaoGraficoTrackingFields.COR_PERCENTUAL_FIM) != 0UL)
                                                    _logger.DomainValueChanged("CorConfiguracaoGrafico", "COR_PERCENTUAL_FIM", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CorConfiguracaoGraficoOperationalFields.COR_PERCENTUAL_FIM, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string COR_DESCRICAO
                                    {
                                        get => _inner.COR_DESCRICAO;
                                        set
                                        {
                                            if (_inner.COR_DESCRICAO != value)
                                            {
                                                _inner.COR_DESCRICAO = value;
                                                if ((_trackingMask & CorConfiguracaoGraficoTrackingFields.COR_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("CorConfiguracaoGrafico", "COR_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CorConfiguracaoGraficoOperationalFields.COR_DESCRICAO, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CorConfiguracaoGraficoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CorConfiguracaoGrafico", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CorConfiguracaoGraficoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CorConfiguracaoGraficoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CorConfiguracaoGrafico", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CorConfiguracaoGraficoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CorConfiguracaoGraficoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CorConfiguracaoGrafico", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CorConfiguracaoGraficoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CorConfiguracaoGraficoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CorConfiguracaoGrafico", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CorConfiguracaoGraficoOperationalFields.UserId, _trackingExecutionIdentity);
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