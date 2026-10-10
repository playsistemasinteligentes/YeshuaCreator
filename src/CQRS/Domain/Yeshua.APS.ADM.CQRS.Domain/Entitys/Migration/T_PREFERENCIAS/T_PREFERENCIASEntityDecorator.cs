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
                    public static class T_PREFERENCIASTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong PRE_ID = 1UL << 1;
            public const ulong PRE_DESCRICAO = 1UL << 2;
            public const ulong PRE_NAMESPACE = 1UL << 3;
            public const ulong PRE_TIPO = 1UL << 4;
            public const ulong PRE_VALOR = 1UL << 5;
            public const ulong USE_ID = 1UL << 6;
            public const ulong PER_ID = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
            public const ulong OperationalEntityId = 1UL << 12;
        }

        public static class T_PREFERENCIASOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PRE_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PRE_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PRE_NAMESPACE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PRE_TIPO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PRE_VALOR = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification USE_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PER_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class T_PREFERENCIASDecorator : IT_PREFERENCIASEntity
{

                        private readonly IT_PREFERENCIASEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_PREFERENCIASDecorator(IT_PREFERENCIASEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_PREFERENCIASDecorator(
                            IT_PREFERENCIASEntity inner,
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
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int PRE_ID
                                    {
                                        get => _inner.PRE_ID;
                                        set
                                        {
                                            if (_inner.PRE_ID != value)
                                            {
                                                _inner.PRE_ID = value;
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.PRE_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "PRE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.PRE_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PRE_DESCRICAO
                                    {
                                        get => _inner.PRE_DESCRICAO;
                                        set
                                        {
                                            if (_inner.PRE_DESCRICAO != value)
                                            {
                                                _inner.PRE_DESCRICAO = value;
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.PRE_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "PRE_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.PRE_DESCRICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PRE_NAMESPACE
                                    {
                                        get => _inner.PRE_NAMESPACE;
                                        set
                                        {
                                            if (_inner.PRE_NAMESPACE != value)
                                            {
                                                _inner.PRE_NAMESPACE = value;
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.PRE_NAMESPACE) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "PRE_NAMESPACE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.PRE_NAMESPACE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PRE_TIPO
                                    {
                                        get => _inner.PRE_TIPO;
                                        set
                                        {
                                            if (_inner.PRE_TIPO != value)
                                            {
                                                _inner.PRE_TIPO = value;
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.PRE_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "PRE_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.PRE_TIPO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PRE_VALOR
                                    {
                                        get => _inner.PRE_VALOR;
                                        set
                                        {
                                            if (_inner.PRE_VALOR != value)
                                            {
                                                _inner.PRE_VALOR = value;
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.PRE_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "PRE_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.PRE_VALOR, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? USE_ID
                                    {
                                        get => _inner.USE_ID;
                                        set
                                        {
                                            if (_inner.USE_ID != value)
                                            {
                                                _inner.USE_ID = value;
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.USE_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? PER_ID
                                    {
                                        get => _inner.PER_ID;
                                        set
                                        {
                                            if (_inner.PER_ID != value)
                                            {
                                                _inner.PER_ID = value;
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.PER_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "PER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.PER_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & T_PREFERENCIASTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_PREFERENCIAS", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_PREFERENCIASOperationalFields.UserId, _trackingExecutionIdentity);
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