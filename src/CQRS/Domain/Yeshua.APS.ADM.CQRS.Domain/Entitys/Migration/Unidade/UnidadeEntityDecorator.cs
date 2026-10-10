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
                    public static class UnidadeTrackingFields
        {
            public const ulong UNI_ID = 1UL << 0;
            public const ulong DEESCRICAO = 1UL << 1;
            public const ulong UN = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
            public const ulong OperationalEntityId = 1UL << 7;
        }

        public static class UnidadeOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification UNI_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DEESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UN = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class UnidadeDecorator : IUnidadeEntity
{

                        private readonly IUnidadeEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public UnidadeDecorator(IUnidadeEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public UnidadeDecorator(
                            IUnidadeEntity inner,
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
                                    public int UNI_ID
                                    {
                                        get => _inner.UNI_ID;
                                        set
                                        {
                                            if (_inner.UNI_ID != value)
                                            {
                                                _inner.UNI_ID = value;
                                                if ((_trackingMask & UnidadeTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Unidade", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, UnidadeOperationalFields.UNI_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string DEESCRICAO
                                    {
                                        get => _inner.DEESCRICAO;
                                        set
                                        {
                                            if (_inner.DEESCRICAO != value)
                                            {
                                                _inner.DEESCRICAO = value;
                                                if ((_trackingMask & UnidadeTrackingFields.DEESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Unidade", "DEESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, UnidadeOperationalFields.DEESCRICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string UN
                                    {
                                        get => _inner.UN;
                                        set
                                        {
                                            if (_inner.UN != value)
                                            {
                                                _inner.UN = value;
                                                if ((_trackingMask & UnidadeTrackingFields.UN) != 0UL)
                                                    _logger.DomainValueChanged("Unidade", "UN", _trackingTraceId, _trackingOperation, _trackingRecordId, value, UnidadeOperationalFields.UN, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & UnidadeTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Unidade", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, UnidadeOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & UnidadeTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Unidade", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, UnidadeOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & UnidadeTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Unidade", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, UnidadeOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & UnidadeTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Unidade", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, UnidadeOperationalFields.UserId, _trackingExecutionIdentity);
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