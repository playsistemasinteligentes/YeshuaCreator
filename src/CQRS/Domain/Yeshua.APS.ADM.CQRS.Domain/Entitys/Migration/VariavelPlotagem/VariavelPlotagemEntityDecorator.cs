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
                    public static class VariavelPlotagemTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong VAR_ID = 1UL << 1;
            public const ulong PLO_ID = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
            public const ulong OperationalEntityId = 1UL << 7;
        }

        public static class VariavelPlotagemOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VAR_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PLO_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class VariavelPlotagemDecorator : IVariavelPlotagemEntity
{

                        private readonly IVariavelPlotagemEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public VariavelPlotagemDecorator(IVariavelPlotagemEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public VariavelPlotagemDecorator(
                            IVariavelPlotagemEntity inner,
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
                                                if ((_trackingMask & VariavelPlotagemTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("VariavelPlotagem", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VariavelPlotagemOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int VAR_ID
                                    {
                                        get => _inner.VAR_ID;
                                        set
                                        {
                                            if (_inner.VAR_ID != value)
                                            {
                                                _inner.VAR_ID = value;
                                                if ((_trackingMask & VariavelPlotagemTrackingFields.VAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("VariavelPlotagem", "VAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VariavelPlotagemOperationalFields.VAR_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int PLO_ID
                                    {
                                        get => _inner.PLO_ID;
                                        set
                                        {
                                            if (_inner.PLO_ID != value)
                                            {
                                                _inner.PLO_ID = value;
                                                if ((_trackingMask & VariavelPlotagemTrackingFields.PLO_ID) != 0UL)
                                                    _logger.DomainValueChanged("VariavelPlotagem", "PLO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VariavelPlotagemOperationalFields.PLO_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VariavelPlotagemTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("VariavelPlotagem", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VariavelPlotagemOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VariavelPlotagemTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("VariavelPlotagem", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VariavelPlotagemOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VariavelPlotagemTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("VariavelPlotagem", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VariavelPlotagemOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VariavelPlotagemTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("VariavelPlotagem", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VariavelPlotagemOperationalFields.UserId, _trackingExecutionIdentity);
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