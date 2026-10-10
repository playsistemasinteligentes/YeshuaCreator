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
                    public static class ConfiguracoesTrackingFields
        {
            public const ulong CON_ID = 1UL << 0;
            public const ulong TenantID = 1UL << 1;
            public const ulong Deleted = 1UL << 2;
            public const ulong Changed = 1UL << 3;
            public const ulong UserId = 1UL << 4;
            public const ulong OperationalEntityId = 1UL << 5;
        }

        public static class ConfiguracoesOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification CON_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class ConfiguracoesDecorator : IConfiguracoesEntity
{

                        private readonly IConfiguracoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ConfiguracoesDecorator(IConfiguracoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ConfiguracoesDecorator(
                            IConfiguracoesEntity inner,
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
                                    public int CON_ID
                                    {
                                        get => _inner.CON_ID;
                                        set
                                        {
                                            if (_inner.CON_ID != value)
                                            {
                                                _inner.CON_ID = value;
                                                if ((_trackingMask & ConfiguracoesTrackingFields.CON_ID) != 0UL)
                                                    _logger.DomainValueChanged("Configuracoes", "CON_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConfiguracoesOperationalFields.CON_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ConfiguracoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Configuracoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConfiguracoesOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ConfiguracoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Configuracoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConfiguracoesOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ConfiguracoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Configuracoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConfiguracoesOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ConfiguracoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Configuracoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConfiguracoesOperationalFields.UserId, _trackingExecutionIdentity);
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