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
                    public static class ItensCalendarioTrackingFields
        {
            public const ulong ICA_ID = 1UL << 0;
            public const ulong ICA_DATA_DE = 1UL << 1;
            public const ulong ICA_DATA_ATE = 1UL << 2;
            public const ulong ICA_OBSERVACAO = 1UL << 3;
            public const ulong ICA_TIPO = 1UL << 4;
            public const ulong URM_ID = 1UL << 5;
            public const ulong URN_ID = 1UL << 6;
            public const ulong CAL_ID = 1UL << 7;
            public const ulong MAQ_ID = 1UL << 8;
            public const ulong PRO_ID = 1UL << 9;
            public const ulong ICA_LIMPESA_MAQUINA = 1UL << 10;
            public const ulong OperationalEntityId = 1UL << 11;
            public const ulong TenantID = 1UL << 12;
            public const ulong Deleted = 1UL << 13;
            public const ulong Changed = 1UL << 14;
            public const ulong UserId = 1UL << 15;
        }

        public static class ItensCalendarioOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification ICA_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ICA_DATA_DE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ICA_DATA_ATE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ICA_OBSERVACAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ICA_TIPO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification URM_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification URN_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CAL_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MAQ_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PRO_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ICA_LIMPESA_MAQUINA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class ItensCalendarioDecorator : IItensCalendarioEntity
{

                        private readonly IItensCalendarioEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ItensCalendarioDecorator(IItensCalendarioEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ItensCalendarioDecorator(
                            IItensCalendarioEntity inner,
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
                                    public int ICA_ID
                                    {
                                        get => _inner.ICA_ID;
                                        set
                                        {
                                            if (_inner.ICA_ID != value)
                                            {
                                                _inner.ICA_ID = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.ICA_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "ICA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.ICA_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime ICA_DATA_DE
                                    {
                                        get => _inner.ICA_DATA_DE;
                                        set
                                        {
                                            if (_inner.ICA_DATA_DE != value)
                                            {
                                                _inner.ICA_DATA_DE = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.ICA_DATA_DE) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "ICA_DATA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.ICA_DATA_DE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime ICA_DATA_ATE
                                    {
                                        get => _inner.ICA_DATA_ATE;
                                        set
                                        {
                                            if (_inner.ICA_DATA_ATE != value)
                                            {
                                                _inner.ICA_DATA_ATE = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.ICA_DATA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "ICA_DATA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.ICA_DATA_ATE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ICA_OBSERVACAO
                                    {
                                        get => _inner.ICA_OBSERVACAO;
                                        set
                                        {
                                            if (_inner.ICA_OBSERVACAO != value)
                                            {
                                                _inner.ICA_OBSERVACAO = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.ICA_OBSERVACAO) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "ICA_OBSERVACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.ICA_OBSERVACAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int ICA_TIPO
                                    {
                                        get => _inner.ICA_TIPO;
                                        set
                                        {
                                            if (_inner.ICA_TIPO != value)
                                            {
                                                _inner.ICA_TIPO = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.ICA_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "ICA_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.ICA_TIPO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? URM_ID
                                    {
                                        get => _inner.URM_ID;
                                        set
                                        {
                                            if (_inner.URM_ID != value)
                                            {
                                                _inner.URM_ID = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.URM_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "URM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.URM_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? URN_ID
                                    {
                                        get => _inner.URN_ID;
                                        set
                                        {
                                            if (_inner.URN_ID != value)
                                            {
                                                _inner.URN_ID = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.URN_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "URN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.URN_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int CAL_ID
                                    {
                                        get => _inner.CAL_ID;
                                        set
                                        {
                                            if (_inner.CAL_ID != value)
                                            {
                                                _inner.CAL_ID = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.CAL_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "CAL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.CAL_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MAQ_ID
                                    {
                                        get => _inner.MAQ_ID;
                                        set
                                        {
                                            if (_inner.MAQ_ID != value)
                                            {
                                                _inner.MAQ_ID = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.MAQ_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PRO_ID
                                    {
                                        get => _inner.PRO_ID;
                                        set
                                        {
                                            if (_inner.PRO_ID != value)
                                            {
                                                _inner.PRO_ID = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.PRO_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ICA_LIMPESA_MAQUINA
                                    {
                                        get => _inner.ICA_LIMPESA_MAQUINA;
                                        set
                                        {
                                            if (_inner.ICA_LIMPESA_MAQUINA != value)
                                            {
                                                _inner.ICA_LIMPESA_MAQUINA = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.ICA_LIMPESA_MAQUINA) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "ICA_LIMPESA_MAQUINA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.ICA_LIMPESA_MAQUINA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & ItensCalendarioTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItensCalendarioTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItensCalendarioTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ItensCalendarioTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ItensCalendario", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ItensCalendarioOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration