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
                    public static class FechamentoTesteTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong FEC_ID = 1UL << 1;
            public const ulong FEC_QTD = 1UL << 2;
            public const ulong GRP_ID = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
            public const ulong OperationalEntityId = 1UL << 8;
        }

        public static class FechamentoTesteOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification FEC_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification FEC_QTD = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRP_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class FechamentoTesteDecorator : IFechamentoTesteEntity
{

                        private readonly IFechamentoTesteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public FechamentoTesteDecorator(IFechamentoTesteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public FechamentoTesteDecorator(
                            IFechamentoTesteEntity inner,
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
                                                if ((_trackingMask & FechamentoTesteTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("FechamentoTeste", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, FechamentoTesteOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int FEC_ID
                                    {
                                        get => _inner.FEC_ID;
                                        set
                                        {
                                            if (_inner.FEC_ID != value)
                                            {
                                                _inner.FEC_ID = value;
                                                if ((_trackingMask & FechamentoTesteTrackingFields.FEC_ID) != 0UL)
                                                    _logger.DomainValueChanged("FechamentoTeste", "FEC_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, FechamentoTesteOperationalFields.FEC_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? FEC_QTD
                                    {
                                        get => _inner.FEC_QTD;
                                        set
                                        {
                                            if (_inner.FEC_QTD != value)
                                            {
                                                _inner.FEC_QTD = value;
                                                if ((_trackingMask & FechamentoTesteTrackingFields.FEC_QTD) != 0UL)
                                                    _logger.DomainValueChanged("FechamentoTeste", "FEC_QTD", _trackingTraceId, _trackingOperation, _trackingRecordId, value, FechamentoTesteOperationalFields.FEC_QTD, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GRP_ID
                                    {
                                        get => _inner.GRP_ID;
                                        set
                                        {
                                            if (_inner.GRP_ID != value)
                                            {
                                                _inner.GRP_ID = value;
                                                if ((_trackingMask & FechamentoTesteTrackingFields.GRP_ID) != 0UL)
                                                    _logger.DomainValueChanged("FechamentoTeste", "GRP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, FechamentoTesteOperationalFields.GRP_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & FechamentoTesteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("FechamentoTeste", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, FechamentoTesteOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & FechamentoTesteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("FechamentoTeste", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, FechamentoTesteOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & FechamentoTesteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("FechamentoTeste", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, FechamentoTesteOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & FechamentoTesteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("FechamentoTeste", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, FechamentoTesteOperationalFields.UserId, _trackingExecutionIdentity);
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