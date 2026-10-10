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
                    public static class GrupoMaquinaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Descricao = 1UL << 1;
            public const ulong Status = 1UL << 2;
            public const ulong OperationalEntityId = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
            public const ulong GMA_TIPO_PLANEJAMENTO = 1UL << 8;
        }

        public static class GrupoMaquinaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Descricao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GMA_TIPO_PLANEJAMENTO = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class GrupoMaquinaDecorator : IGrupoMaquinaEntity
{

                        private readonly IGrupoMaquinaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public GrupoMaquinaDecorator(IGrupoMaquinaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public GrupoMaquinaDecorator(
                            IGrupoMaquinaEntity inner,
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
                                    public string? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & GrupoMaquinaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("GrupoMaquina", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoMaquinaOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _inner.Descricao = value;
                                                if ((_trackingMask & GrupoMaquinaTrackingFields.Descricao) != 0UL)
                                                    _logger.DomainValueChanged("GrupoMaquina", "Descricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoMaquinaOperationalFields.Descricao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & GrupoMaquinaTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("GrupoMaquina", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoMaquinaOperationalFields.Status, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & GrupoMaquinaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("GrupoMaquina", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoMaquinaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & GrupoMaquinaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("GrupoMaquina", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoMaquinaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & GrupoMaquinaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("GrupoMaquina", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoMaquinaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & GrupoMaquinaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("GrupoMaquina", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoMaquinaOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GMA_TIPO_PLANEJAMENTO
                                    {
                                        get => _inner.GMA_TIPO_PLANEJAMENTO;
                                        set
                                        {
                                            if (_inner.GMA_TIPO_PLANEJAMENTO != value)
                                            {
                                                _inner.GMA_TIPO_PLANEJAMENTO = value;
                                                if ((_trackingMask & GrupoMaquinaTrackingFields.GMA_TIPO_PLANEJAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoMaquina", "GMA_TIPO_PLANEJAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, GrupoMaquinaOperationalFields.GMA_TIPO_PLANEJAMENTO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration