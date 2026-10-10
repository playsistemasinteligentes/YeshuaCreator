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
                    public static class OrcamentoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ORC_ID = 1UL << 1;
            public const ulong REP_ID = 1UL << 2;
            public const ulong CON_ID = 1UL << 3;
            public const ulong ORC_TIPO_FRETE = 1UL << 4;
            public const ulong ORC_EMISSAO = 1UL << 5;
            public const ulong CLI_ID = 1UL << 6;
            public const ulong VER_ID = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
            public const ulong OperationalEntityId = 1UL << 12;
        }

        public static class OrcamentoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ORC_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification REP_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CON_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ORC_TIPO_FRETE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ORC_EMISSAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CLI_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VER_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class OrcamentoDecorator : IOrcamentoEntity
{

                        private readonly IOrcamentoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OrcamentoDecorator(IOrcamentoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OrcamentoDecorator(
                            IOrcamentoEntity inner,
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
                                                if ((_trackingMask & OrcamentoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int ORC_ID
                                    {
                                        get => _inner.ORC_ID;
                                        set
                                        {
                                            if (_inner.ORC_ID != value)
                                            {
                                                _inner.ORC_ID = value;
                                                if ((_trackingMask & OrcamentoTrackingFields.ORC_ID) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "ORC_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.ORC_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? REP_ID
                                    {
                                        get => _inner.REP_ID;
                                        set
                                        {
                                            if (_inner.REP_ID != value)
                                            {
                                                _inner.REP_ID = value;
                                                if ((_trackingMask & OrcamentoTrackingFields.REP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "REP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.REP_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CON_ID
                                    {
                                        get => _inner.CON_ID;
                                        set
                                        {
                                            if (_inner.CON_ID != value)
                                            {
                                                _inner.CON_ID = value;
                                                if ((_trackingMask & OrcamentoTrackingFields.CON_ID) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "CON_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.CON_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ORC_TIPO_FRETE
                                    {
                                        get => _inner.ORC_TIPO_FRETE;
                                        set
                                        {
                                            if (_inner.ORC_TIPO_FRETE != value)
                                            {
                                                _inner.ORC_TIPO_FRETE = value;
                                                if ((_trackingMask & OrcamentoTrackingFields.ORC_TIPO_FRETE) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "ORC_TIPO_FRETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.ORC_TIPO_FRETE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? ORC_EMISSAO
                                    {
                                        get => _inner.ORC_EMISSAO;
                                        set
                                        {
                                            if (_inner.ORC_EMISSAO != value)
                                            {
                                                _inner.ORC_EMISSAO = value;
                                                if ((_trackingMask & OrcamentoTrackingFields.ORC_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "ORC_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.ORC_EMISSAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CLI_ID
                                    {
                                        get => _inner.CLI_ID;
                                        set
                                        {
                                            if (_inner.CLI_ID != value)
                                            {
                                                _inner.CLI_ID = value;
                                                if ((_trackingMask & OrcamentoTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.CLI_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int VER_ID
                                    {
                                        get => _inner.VER_ID;
                                        set
                                        {
                                            if (_inner.VER_ID != value)
                                            {
                                                _inner.VER_ID = value;
                                                if ((_trackingMask & OrcamentoTrackingFields.VER_ID) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "VER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.VER_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrcamentoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrcamentoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrcamentoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrcamentoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Orcamento", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrcamentoOperationalFields.UserId, _trackingExecutionIdentity);
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