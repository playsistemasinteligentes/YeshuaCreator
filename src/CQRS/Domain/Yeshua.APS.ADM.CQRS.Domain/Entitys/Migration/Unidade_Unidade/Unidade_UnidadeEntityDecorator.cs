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
                    public static class Unidade_UnidadeTrackingFields
        {
            public const ulong UNI_ID = 1UL << 0;
            public const ulong UNI_DESCRICAO = 1UL << 1;
            public const ulong TenantID = 1UL << 2;
            public const ulong Deleted = 1UL << 3;
            public const ulong Changed = 1UL << 4;
            public const ulong UserId = 1UL << 5;
            public const ulong OperationalEntityId = 1UL << 6;
        }

        public static class Unidade_UnidadeOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification UNI_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UNI_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class Unidade_UnidadeDecorator : IUnidade_UnidadeEntity
{

                        private readonly IUnidade_UnidadeEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public Unidade_UnidadeDecorator(IUnidade_UnidadeEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public Unidade_UnidadeDecorator(
                            IUnidade_UnidadeEntity inner,
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
                                                if ((_trackingMask & Unidade_UnidadeTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Unidade_Unidade", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, Unidade_UnidadeOperationalFields.UNI_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string UNI_DESCRICAO
                                    {
                                        get => _inner.UNI_DESCRICAO;
                                        set
                                        {
                                            if (_inner.UNI_DESCRICAO != value)
                                            {
                                                _inner.UNI_DESCRICAO = value;
                                                if ((_trackingMask & Unidade_UnidadeTrackingFields.UNI_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Unidade_Unidade", "UNI_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, Unidade_UnidadeOperationalFields.UNI_DESCRICAO, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & Unidade_UnidadeTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Unidade_Unidade", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, Unidade_UnidadeOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & Unidade_UnidadeTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Unidade_Unidade", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, Unidade_UnidadeOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & Unidade_UnidadeTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Unidade_Unidade", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, Unidade_UnidadeOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & Unidade_UnidadeTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Unidade_Unidade", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, Unidade_UnidadeOperationalFields.UserId, _trackingExecutionIdentity);
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