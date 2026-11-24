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
                    public static class OrigemPautaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong IdentidadeId = 1UL << 1;
            public const ulong PautaId = 1UL << 2;
            public const ulong Produtor = 1UL << 3;
            public const ulong MovimentoId = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
        }

        public static class OrigemPautaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IdentidadeId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PautaId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Produtor = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MovimentoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class OrigemPautaDecorator : IOrigemPautaEntity
{

                        private readonly IOrigemPautaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OrigemPautaDecorator(IOrigemPautaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OrigemPautaDecorator(
                            IOrigemPautaEntity inner,
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
                                                if ((_trackingMask & OrigemPautaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.Id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrigemPautaTrackingFields.IdentidadeId) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "IdentidadeId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.IdentidadeId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PautaId
                                    {
                                        get => _inner.PautaId;
                                        set
                                        {
                                            if (_inner.PautaId != value)
                                            {
                                                _inner.PautaId = value;
                                                if ((_trackingMask & OrigemPautaTrackingFields.PautaId) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "PautaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.PautaId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Produtor
                                    {
                                        get => _inner.Produtor;
                                        set
                                        {
                                            if (_inner.Produtor != value)
                                            {
                                                _inner.Produtor = value;
                                                if ((_trackingMask & OrigemPautaTrackingFields.Produtor) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "Produtor", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.Produtor, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MovimentoId
                                    {
                                        get => _inner.MovimentoId;
                                        set
                                        {
                                            if (_inner.MovimentoId != value)
                                            {
                                                _inner.MovimentoId = value;
                                                if ((_trackingMask & OrigemPautaTrackingFields.MovimentoId) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "MovimentoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.MovimentoId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrigemPautaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrigemPautaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrigemPautaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OrigemPautaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("OrigemPauta", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OrigemPautaOperationalFields.UserId, _trackingExecutionIdentity);
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