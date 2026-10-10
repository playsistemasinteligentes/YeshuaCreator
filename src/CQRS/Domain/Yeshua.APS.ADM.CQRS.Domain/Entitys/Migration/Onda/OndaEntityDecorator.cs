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
                    public static class OndaTrackingFields
        {
            public const ulong OND_ID = 1UL << 0;
            public const ulong OND_ESPESSURA = 1UL << 1;
            public const ulong OND_PESO_COLA = 1UL << 2;
            public const ulong OND_RENDIMENTO_ONDA_1 = 1UL << 3;
            public const ulong OND_RENDIMENTO_ONDA_2 = 1UL << 4;
            public const ulong OND_PROFUNDIDADE_VINCO = 1UL << 5;
            public const ulong OND_ID_INTEGRACAO = 1UL << 6;
            public const ulong VIN_ID = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
            public const ulong OperationalEntityId = 1UL << 12;
        }

        public static class OndaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification OND_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OND_ESPESSURA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OND_PESO_COLA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OND_RENDIMENTO_ONDA_1 = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OND_RENDIMENTO_ONDA_2 = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OND_PROFUNDIDADE_VINCO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OND_ID_INTEGRACAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VIN_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class OndaDecorator : IOndaEntity
{

                        private readonly IOndaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OndaDecorator(IOndaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OndaDecorator(
                            IOndaEntity inner,
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
                                    public string OND_ID
                                    {
                                        get => _inner.OND_ID;
                                        set
                                        {
                                            if (_inner.OND_ID != value)
                                            {
                                                _inner.OND_ID = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_ID) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.OND_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal OND_ESPESSURA
                                    {
                                        get => _inner.OND_ESPESSURA;
                                        set
                                        {
                                            if (_inner.OND_ESPESSURA != value)
                                            {
                                                _inner.OND_ESPESSURA = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_ESPESSURA) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_ESPESSURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.OND_ESPESSURA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? OND_PESO_COLA
                                    {
                                        get => _inner.OND_PESO_COLA;
                                        set
                                        {
                                            if (_inner.OND_PESO_COLA != value)
                                            {
                                                _inner.OND_PESO_COLA = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_PESO_COLA) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_PESO_COLA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.OND_PESO_COLA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? OND_RENDIMENTO_ONDA_1
                                    {
                                        get => _inner.OND_RENDIMENTO_ONDA_1;
                                        set
                                        {
                                            if (_inner.OND_RENDIMENTO_ONDA_1 != value)
                                            {
                                                _inner.OND_RENDIMENTO_ONDA_1 = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_RENDIMENTO_ONDA_1) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_RENDIMENTO_ONDA_1", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.OND_RENDIMENTO_ONDA_1, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? OND_RENDIMENTO_ONDA_2
                                    {
                                        get => _inner.OND_RENDIMENTO_ONDA_2;
                                        set
                                        {
                                            if (_inner.OND_RENDIMENTO_ONDA_2 != value)
                                            {
                                                _inner.OND_RENDIMENTO_ONDA_2 = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_RENDIMENTO_ONDA_2) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_RENDIMENTO_ONDA_2", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.OND_RENDIMENTO_ONDA_2, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? OND_PROFUNDIDADE_VINCO
                                    {
                                        get => _inner.OND_PROFUNDIDADE_VINCO;
                                        set
                                        {
                                            if (_inner.OND_PROFUNDIDADE_VINCO != value)
                                            {
                                                _inner.OND_PROFUNDIDADE_VINCO = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_PROFUNDIDADE_VINCO) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_PROFUNDIDADE_VINCO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.OND_PROFUNDIDADE_VINCO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string OND_ID_INTEGRACAO
                                    {
                                        get => _inner.OND_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.OND_ID_INTEGRACAO != value)
                                            {
                                                _inner.OND_ID_INTEGRACAO = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.OND_ID_INTEGRACAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int VIN_ID
                                    {
                                        get => _inner.VIN_ID;
                                        set
                                        {
                                            if (_inner.VIN_ID != value)
                                            {
                                                _inner.VIN_ID = value;
                                                if ((_trackingMask & OndaTrackingFields.VIN_ID) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "VIN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.VIN_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OndaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OndaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OndaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OndaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OndaOperationalFields.UserId, _trackingExecutionIdentity);
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