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
                    public static class TipoOcorrenciaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Descricao = 1UL << 1;
            public const ulong Spr = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
            public const ulong OperationalEntityId = 1UL << 7;
        }

        public static class TipoOcorrenciaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Descricao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Spr = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class TipoOcorrenciaDecorator : ITipoOcorrenciaEntity
{

                        private readonly ITipoOcorrenciaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TipoOcorrenciaDecorator(ITipoOcorrenciaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TipoOcorrenciaDecorator(
                            ITipoOcorrenciaEntity inner,
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
                                    public int Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & TipoOcorrenciaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("TipoOcorrencia", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoOcorrenciaOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _inner.Descricao = value;
                                                if ((_trackingMask & TipoOcorrenciaTrackingFields.Descricao) != 0UL)
                                                    _logger.DomainValueChanged("TipoOcorrencia", "Descricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoOcorrenciaOperationalFields.Descricao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? Spr
                                    {
                                        get => _inner.Spr;
                                        set
                                        {
                                            if (_inner.Spr != value)
                                            {
                                                _inner.Spr = value;
                                                if ((_trackingMask & TipoOcorrenciaTrackingFields.Spr) != 0UL)
                                                    _logger.DomainValueChanged("TipoOcorrencia", "Spr", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoOcorrenciaOperationalFields.Spr, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoOcorrenciaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TipoOcorrencia", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoOcorrenciaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoOcorrenciaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TipoOcorrencia", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoOcorrenciaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoOcorrenciaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TipoOcorrencia", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoOcorrenciaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoOcorrenciaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TipoOcorrencia", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoOcorrenciaOperationalFields.UserId, _trackingExecutionIdentity);
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