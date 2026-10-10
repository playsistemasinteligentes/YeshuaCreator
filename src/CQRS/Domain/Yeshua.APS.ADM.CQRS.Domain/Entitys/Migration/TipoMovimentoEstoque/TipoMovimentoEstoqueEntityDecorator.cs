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
                    public static class TipoMovimentoEstoqueTrackingFields
        {
            public const ulong TIP_ID = 1UL << 0;
            public const ulong TIP_DESCRICAO = 1UL << 1;
            public const ulong TIP_TYPE = 1UL << 2;
            public const ulong SPR = 1UL << 3;
            public const ulong OperationalEntityId = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public static class TipoMovimentoEstoqueOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification TIP_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_TYPE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SPR = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class TipoMovimentoEstoqueDecorator : ITipoMovimentoEstoqueEntity
{

                        private readonly ITipoMovimentoEstoqueEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TipoMovimentoEstoqueDecorator(ITipoMovimentoEstoqueEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TipoMovimentoEstoqueDecorator(
                            ITipoMovimentoEstoqueEntity inner,
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
                                    public string TIP_ID
                                    {
                                        get => _inner.TIP_ID;
                                        set
                                        {
                                            if (_inner.TIP_ID != value)
                                            {
                                                _inner.TIP_ID = value;
                                                if ((_trackingMask & TipoMovimentoEstoqueTrackingFields.TIP_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoMovimentoEstoque", "TIP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoMovimentoEstoqueOperationalFields.TIP_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string TIP_DESCRICAO
                                    {
                                        get => _inner.TIP_DESCRICAO;
                                        set
                                        {
                                            if (_inner.TIP_DESCRICAO != value)
                                            {
                                                _inner.TIP_DESCRICAO = value;
                                                if ((_trackingMask & TipoMovimentoEstoqueTrackingFields.TIP_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("TipoMovimentoEstoque", "TIP_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoMovimentoEstoqueOperationalFields.TIP_DESCRICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int TIP_TYPE
                                    {
                                        get => _inner.TIP_TYPE;
                                        set
                                        {
                                            if (_inner.TIP_TYPE != value)
                                            {
                                                _inner.TIP_TYPE = value;
                                                if ((_trackingMask & TipoMovimentoEstoqueTrackingFields.TIP_TYPE) != 0UL)
                                                    _logger.DomainValueChanged("TipoMovimentoEstoque", "TIP_TYPE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoMovimentoEstoqueOperationalFields.TIP_TYPE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int SPR
                                    {
                                        get => _inner.SPR;
                                        set
                                        {
                                            if (_inner.SPR != value)
                                            {
                                                _inner.SPR = value;
                                                if ((_trackingMask & TipoMovimentoEstoqueTrackingFields.SPR) != 0UL)
                                                    _logger.DomainValueChanged("TipoMovimentoEstoque", "SPR", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoMovimentoEstoqueOperationalFields.SPR, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoMovimentoEstoqueTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TipoMovimentoEstoque", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoMovimentoEstoqueOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoMovimentoEstoqueTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TipoMovimentoEstoque", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoMovimentoEstoqueOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoMovimentoEstoqueTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TipoMovimentoEstoque", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoMovimentoEstoqueOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoMovimentoEstoqueTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TipoMovimentoEstoque", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoMovimentoEstoqueOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration