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
                    public static class AprovacaoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong IdentidadeId = 1UL << 1;
            public const ulong VersaoId = 1UL << 2;
            public const ulong Hash = 1UL << 3;
            public const ulong Destinos = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
        }

        public static class AprovacaoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IdentidadeId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VersaoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Hash = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Destinos = Dominio.Operational.OperationalDataClassification.NeverCapture;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class AprovacaoDecorator : IAprovacaoEntity
{

                        private readonly IAprovacaoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public AprovacaoDecorator(IAprovacaoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public AprovacaoDecorator(
                            IAprovacaoEntity inner,
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
                                                if ((_trackingMask & AprovacaoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.Id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AprovacaoTrackingFields.IdentidadeId) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "IdentidadeId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.IdentidadeId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? VersaoId
                                    {
                                        get => _inner.VersaoId;
                                        set
                                        {
                                            if (_inner.VersaoId != value)
                                            {
                                                _inner.VersaoId = value;
                                                if ((_trackingMask & AprovacaoTrackingFields.VersaoId) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "VersaoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.VersaoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Hash
                                    {
                                        get => _inner.Hash;
                                        set
                                        {
                                            if (_inner.Hash != value)
                                            {
                                                _inner.Hash = value;
                                                if ((_trackingMask & AprovacaoTrackingFields.Hash) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "Hash", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.Hash, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Destinos
                                    {
                                        get => _inner.Destinos;
                                        set
                                        {
                                            if (_inner.Destinos != value)
                                            {
                                                _inner.Destinos = value;
                                                if ((_trackingMask & AprovacaoTrackingFields.Destinos) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "Destinos", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.Destinos, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AprovacaoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AprovacaoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AprovacaoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & AprovacaoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Aprovacao", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, AprovacaoOperationalFields.UserId, _trackingExecutionIdentity);
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