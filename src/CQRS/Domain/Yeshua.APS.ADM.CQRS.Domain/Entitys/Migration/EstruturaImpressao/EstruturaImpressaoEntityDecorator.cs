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
                    public static class EstruturaImpressaoTrackingFields
        {
            public const ulong EST_ID = 1UL << 0;
            public const ulong HTML_ESTRUTURA = 1UL << 1;
            public const ulong CLI_ID = 1UL << 2;
            public const ulong EST_DESCRICAO = 1UL << 3;
            public const ulong OperationalEntityId = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public static class EstruturaImpressaoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification EST_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification HTML_ESTRUTURA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CLI_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EST_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class EstruturaImpressaoDecorator : IEstruturaImpressaoEntity
{

                        private readonly IEstruturaImpressaoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public EstruturaImpressaoDecorator(IEstruturaImpressaoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public EstruturaImpressaoDecorator(
                            IEstruturaImpressaoEntity inner,
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
                                    public int EST_ID
                                    {
                                        get => _inner.EST_ID;
                                        set
                                        {
                                            if (_inner.EST_ID != value)
                                            {
                                                _inner.EST_ID = value;
                                                if ((_trackingMask & EstruturaImpressaoTrackingFields.EST_ID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaImpressao", "EST_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaImpressaoOperationalFields.EST_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? HTML_ESTRUTURA
                                    {
                                        get => _inner.HTML_ESTRUTURA;
                                        set
                                        {
                                            if (_inner.HTML_ESTRUTURA != value)
                                            {
                                                _inner.HTML_ESTRUTURA = value;
                                                if ((_trackingMask & EstruturaImpressaoTrackingFields.HTML_ESTRUTURA) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaImpressao", "HTML_ESTRUTURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaImpressaoOperationalFields.HTML_ESTRUTURA, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaImpressaoTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaImpressao", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaImpressaoOperationalFields.CLI_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? EST_DESCRICAO
                                    {
                                        get => _inner.EST_DESCRICAO;
                                        set
                                        {
                                            if (_inner.EST_DESCRICAO != value)
                                            {
                                                _inner.EST_DESCRICAO = value;
                                                if ((_trackingMask & EstruturaImpressaoTrackingFields.EST_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaImpressao", "EST_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaImpressaoOperationalFields.EST_DESCRICAO, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaImpressaoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaImpressao", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaImpressaoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaImpressaoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaImpressao", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaImpressaoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaImpressaoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaImpressao", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaImpressaoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaImpressaoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaImpressao", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaImpressaoOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration