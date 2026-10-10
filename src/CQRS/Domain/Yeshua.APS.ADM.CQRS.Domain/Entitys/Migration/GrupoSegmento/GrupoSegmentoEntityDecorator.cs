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
                    public static class GrupoSegmentoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong GRS_ID = 1UL << 1;
            public const ulong GRS_DESCRICAO = 1UL << 2;
            public const ulong GRS_INTEGRACAO_ERP = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
            public const ulong OperationalEntityId = 1UL << 8;
        }

        public static class GrupoSegmentoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRS_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRS_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRS_INTEGRACAO_ERP = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class GrupoSegmentoDecorator : IGrupoSegmentoEntity
{

                        private readonly IGrupoSegmentoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public GrupoSegmentoDecorator(IGrupoSegmentoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public GrupoSegmentoDecorator(
                            IGrupoSegmentoEntity inner,
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
                                                if ((_trackingMask & GrupoSegmentoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("GrupoSegmento", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoSegmentoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string GRS_ID
                                    {
                                        get => _inner.GRS_ID;
                                        set
                                        {
                                            if (_inner.GRS_ID != value)
                                            {
                                                _inner.GRS_ID = value;
                                                if ((_trackingMask & GrupoSegmentoTrackingFields.GRS_ID) != 0UL)
                                                    _logger.DomainValueChanged("GrupoSegmento", "GRS_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoSegmentoOperationalFields.GRS_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GRS_DESCRICAO
                                    {
                                        get => _inner.GRS_DESCRICAO;
                                        set
                                        {
                                            if (_inner.GRS_DESCRICAO != value)
                                            {
                                                _inner.GRS_DESCRICAO = value;
                                                if ((_trackingMask & GrupoSegmentoTrackingFields.GRS_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoSegmento", "GRS_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoSegmentoOperationalFields.GRS_DESCRICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GRS_INTEGRACAO_ERP
                                    {
                                        get => _inner.GRS_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.GRS_INTEGRACAO_ERP != value)
                                            {
                                                _inner.GRS_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & GrupoSegmentoTrackingFields.GRS_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("GrupoSegmento", "GRS_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoSegmentoOperationalFields.GRS_INTEGRACAO_ERP, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & GrupoSegmentoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("GrupoSegmento", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoSegmentoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & GrupoSegmentoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("GrupoSegmento", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoSegmentoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & GrupoSegmentoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("GrupoSegmento", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoSegmentoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & GrupoSegmentoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("GrupoSegmento", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoSegmentoOperationalFields.UserId, _trackingExecutionIdentity);
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