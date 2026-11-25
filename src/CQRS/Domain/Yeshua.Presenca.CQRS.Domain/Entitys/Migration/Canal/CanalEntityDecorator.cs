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
                    public static class CanalTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong IdentidadeId = 1UL << 1;
            public const ulong Plataforma = 1UL << 2;
            public const ulong Destino = 1UL << 3;
            public const ulong Conexao = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
        }

        public static class CanalOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IdentidadeId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Plataforma = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Destino = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Conexao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class CanalDecorator : ICanalEntity
{

                        private readonly ICanalEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CanalDecorator(ICanalEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CanalDecorator(
                            ICanalEntity inner,
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
                                                if ((_trackingMask & CanalTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? IdentidadeId
                                    {
                                        get => _inner.IdentidadeId;
                                        set
                                        {
                                            if (_inner.IdentidadeId != value)
                                            {
                                                _inner.IdentidadeId = value;
                                                if ((_trackingMask & CanalTrackingFields.IdentidadeId) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "IdentidadeId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.IdentidadeId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Plataforma
                                    {
                                        get => _inner.Plataforma;
                                        set
                                        {
                                            if (_inner.Plataforma != value)
                                            {
                                                _inner.Plataforma = value;
                                                if ((_trackingMask & CanalTrackingFields.Plataforma) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "Plataforma", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.Plataforma, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Destino
                                    {
                                        get => _inner.Destino;
                                        set
                                        {
                                            if (_inner.Destino != value)
                                            {
                                                _inner.Destino = value;
                                                if ((_trackingMask & CanalTrackingFields.Destino) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "Destino", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.Destino, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Conexao
                                    {
                                        get => _inner.Conexao;
                                        set
                                        {
                                            if (_inner.Conexao != value)
                                            {
                                                _inner.Conexao = value;
                                                if ((_trackingMask & CanalTrackingFields.Conexao) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "Conexao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.Conexao, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CanalTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CanalTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CanalTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CanalTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Canal", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalOperationalFields.UserId, _trackingExecutionIdentity);
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