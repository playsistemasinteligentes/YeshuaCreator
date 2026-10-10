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
                    public static class MemoriaDeCalculoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MEM_ID = 1UL << 1;
            public const ulong ORC_ID = 1UL << 2;
            public const ulong MEM_VALOR = 1UL << 3;
            public const ulong MEM_DESCRICAO = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
        }

        public static class MemoriaDeCalculoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MEM_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ORC_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MEM_VALOR = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MEM_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class MemoriaDeCalculoDecorator : IMemoriaDeCalculoEntity
{

                        private readonly IMemoriaDeCalculoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MemoriaDeCalculoDecorator(IMemoriaDeCalculoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MemoriaDeCalculoDecorator(
                            IMemoriaDeCalculoEntity inner,
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
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int MEM_ID
                                    {
                                        get => _inner.MEM_ID;
                                        set
                                        {
                                            if (_inner.MEM_ID != value)
                                            {
                                                _inner.MEM_ID = value;
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.MEM_ID) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "MEM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.MEM_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ORC_ID
                                    {
                                        get => _inner.ORC_ID;
                                        set
                                        {
                                            if (_inner.ORC_ID != value)
                                            {
                                                _inner.ORC_ID = value;
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.ORC_ID) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "ORC_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.ORC_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? MEM_VALOR
                                    {
                                        get => _inner.MEM_VALOR;
                                        set
                                        {
                                            if (_inner.MEM_VALOR != value)
                                            {
                                                _inner.MEM_VALOR = value;
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.MEM_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "MEM_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.MEM_VALOR, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MEM_DESCRICAO
                                    {
                                        get => _inner.MEM_DESCRICAO;
                                        set
                                        {
                                            if (_inner.MEM_DESCRICAO != value)
                                            {
                                                _inner.MEM_DESCRICAO = value;
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.MEM_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "MEM_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.MEM_DESCRICAO, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MemoriaDeCalculoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MemoriaDeCalculo", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MemoriaDeCalculoOperationalFields.UserId, _trackingExecutionIdentity);
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