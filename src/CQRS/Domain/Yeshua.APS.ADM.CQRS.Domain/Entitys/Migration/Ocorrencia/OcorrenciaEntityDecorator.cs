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
                    public static class OcorrenciaTrackingFields
        {
            public const ulong OCO_ID = 1UL << 0;
            public const ulong OCO_DESCRICAO = 1UL << 1;
            public const ulong TIP_ID = 1UL << 2;
            public const ulong GMA_ID = 1UL << 3;
            public const ulong MAQ_ID = 1UL << 4;
            public const ulong SPR = 1UL << 5;
            public const ulong OCO_SUB_TIPO = 1UL << 6;
            public const ulong SUB_ID = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
            public const ulong OperationalEntityId = 1UL << 12;
        }

        public static class OcorrenciaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification OCO_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OCO_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GMA_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MAQ_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SPR = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OCO_SUB_TIPO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SUB_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class OcorrenciaDecorator : IOcorrenciaEntity
{

                        private readonly IOcorrenciaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OcorrenciaDecorator(IOcorrenciaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OcorrenciaDecorator(
                            IOcorrenciaEntity inner,
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
                                    public string OCO_ID
                                    {
                                        get => _inner.OCO_ID;
                                        set
                                        {
                                            if (_inner.OCO_ID != value)
                                            {
                                                _inner.OCO_ID = value;
                                                if ((_trackingMask & OcorrenciaTrackingFields.OCO_ID) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "OCO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.OCO_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string OCO_DESCRICAO
                                    {
                                        get => _inner.OCO_DESCRICAO;
                                        set
                                        {
                                            if (_inner.OCO_DESCRICAO != value)
                                            {
                                                _inner.OCO_DESCRICAO = value;
                                                if ((_trackingMask & OcorrenciaTrackingFields.OCO_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "OCO_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.OCO_DESCRICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int TIP_ID
                                    {
                                        get => _inner.TIP_ID;
                                        set
                                        {
                                            if (_inner.TIP_ID != value)
                                            {
                                                _inner.TIP_ID = value;
                                                if ((_trackingMask & OcorrenciaTrackingFields.TIP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "TIP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.TIP_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GMA_ID
                                    {
                                        get => _inner.GMA_ID;
                                        set
                                        {
                                            if (_inner.GMA_ID != value)
                                            {
                                                _inner.GMA_ID = value;
                                                if ((_trackingMask & OcorrenciaTrackingFields.GMA_ID) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "GMA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.GMA_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OcorrenciaTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.MAQ_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? SPR
                                    {
                                        get => _inner.SPR;
                                        set
                                        {
                                            if (_inner.SPR != value)
                                            {
                                                _inner.SPR = value;
                                                if ((_trackingMask & OcorrenciaTrackingFields.SPR) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "SPR", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.SPR, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? OCO_SUB_TIPO
                                    {
                                        get => _inner.OCO_SUB_TIPO;
                                        set
                                        {
                                            if (_inner.OCO_SUB_TIPO != value)
                                            {
                                                _inner.OCO_SUB_TIPO = value;
                                                if ((_trackingMask & OcorrenciaTrackingFields.OCO_SUB_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "OCO_SUB_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.OCO_SUB_TIPO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? SUB_ID
                                    {
                                        get => _inner.SUB_ID;
                                        set
                                        {
                                            if (_inner.SUB_ID != value)
                                            {
                                                _inner.SUB_ID = value;
                                                if ((_trackingMask & OcorrenciaTrackingFields.SUB_ID) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "SUB_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.SUB_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OcorrenciaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OcorrenciaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OcorrenciaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OcorrenciaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Ocorrencia", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OcorrenciaOperationalFields.UserId, _trackingExecutionIdentity);
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