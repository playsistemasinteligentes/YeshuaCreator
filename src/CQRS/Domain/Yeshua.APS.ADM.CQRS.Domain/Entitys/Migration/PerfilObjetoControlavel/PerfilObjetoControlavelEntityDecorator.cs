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
                    public static class PerfilObjetoControlavelTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong PER_ID = 1UL << 1;
            public const ulong OBJ_ID = 1UL << 2;
            public const ulong PEO_ACAO = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
            public const ulong OperationalEntityId = 1UL << 8;
        }

        public static class PerfilObjetoControlavelOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PER_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OBJ_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PEO_ACAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class PerfilObjetoControlavelDecorator : IPerfilObjetoControlavelEntity
{

                        private readonly IPerfilObjetoControlavelEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PerfilObjetoControlavelDecorator(IPerfilObjetoControlavelEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PerfilObjetoControlavelDecorator(
                            IPerfilObjetoControlavelEntity inner,
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
                                                if ((_trackingMask & PerfilObjetoControlavelTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("PerfilObjetoControlavel", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PerfilObjetoControlavelOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int PER_ID
                                    {
                                        get => _inner.PER_ID;
                                        set
                                        {
                                            if (_inner.PER_ID != value)
                                            {
                                                _inner.PER_ID = value;
                                                if ((_trackingMask & PerfilObjetoControlavelTrackingFields.PER_ID) != 0UL)
                                                    _logger.DomainValueChanged("PerfilObjetoControlavel", "PER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PerfilObjetoControlavelOperationalFields.PER_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string OBJ_ID
                                    {
                                        get => _inner.OBJ_ID;
                                        set
                                        {
                                            if (_inner.OBJ_ID != value)
                                            {
                                                _inner.OBJ_ID = value;
                                                if ((_trackingMask & PerfilObjetoControlavelTrackingFields.OBJ_ID) != 0UL)
                                                    _logger.DomainValueChanged("PerfilObjetoControlavel", "OBJ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PerfilObjetoControlavelOperationalFields.OBJ_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PEO_ACAO
                                    {
                                        get => _inner.PEO_ACAO;
                                        set
                                        {
                                            if (_inner.PEO_ACAO != value)
                                            {
                                                _inner.PEO_ACAO = value;
                                                if ((_trackingMask & PerfilObjetoControlavelTrackingFields.PEO_ACAO) != 0UL)
                                                    _logger.DomainValueChanged("PerfilObjetoControlavel", "PEO_ACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PerfilObjetoControlavelOperationalFields.PEO_ACAO, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PerfilObjetoControlavelTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PerfilObjetoControlavel", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PerfilObjetoControlavelOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PerfilObjetoControlavelTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PerfilObjetoControlavel", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PerfilObjetoControlavelOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PerfilObjetoControlavelTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PerfilObjetoControlavel", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PerfilObjetoControlavelOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PerfilObjetoControlavelTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PerfilObjetoControlavel", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PerfilObjetoControlavelOperationalFields.UserId, _trackingExecutionIdentity);
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