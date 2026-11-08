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
                    public static class CTeComplementoIcmsFiscalTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CTeSolicitacaoFiscalId = 1UL << 1;
            public const ulong ValorPrestacaoComplementar = 1UL << 2;
            public const ulong CST = 1UL << 3;
            public const ulong ValorBaseCalculo = 1UL << 4;
            public const ulong AliquotaICMS = 1UL << 5;
            public const ulong ValorICMS = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
            public const ulong OperationalEntityId = 1UL << 11;
        }

        public static class CTeComplementoIcmsFiscalOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CTeSolicitacaoFiscalId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ValorPrestacaoComplementar = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CST = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ValorBaseCalculo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AliquotaICMS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ValorICMS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class CTeComplementoIcmsFiscalDecorator : ICTeComplementoIcmsFiscalEntity
{

                        private readonly ICTeComplementoIcmsFiscalEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CTeComplementoIcmsFiscalDecorator(ICTeComplementoIcmsFiscalEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CTeComplementoIcmsFiscalDecorator(
                            ICTeComplementoIcmsFiscalEntity inner,
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
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int CTeSolicitacaoFiscalId
                                    {
                                        get => _inner.CTeSolicitacaoFiscalId;
                                        set
                                        {
                                            if (_inner.CTeSolicitacaoFiscalId != value)
                                            {
                                                _inner.CTeSolicitacaoFiscalId = value;
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.CTeSolicitacaoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "CTeSolicitacaoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.CTeSolicitacaoFiscalId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal ValorPrestacaoComplementar
                                    {
                                        get => _inner.ValorPrestacaoComplementar;
                                        set
                                        {
                                            if (_inner.ValorPrestacaoComplementar != value)
                                            {
                                                _inner.ValorPrestacaoComplementar = value;
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.ValorPrestacaoComplementar) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "ValorPrestacaoComplementar", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.ValorPrestacaoComplementar, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string CST
                                    {
                                        get => _inner.CST;
                                        set
                                        {
                                            if (_inner.CST != value)
                                            {
                                                _inner.CST = value;
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.CST) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "CST", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.CST, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal ValorBaseCalculo
                                    {
                                        get => _inner.ValorBaseCalculo;
                                        set
                                        {
                                            if (_inner.ValorBaseCalculo != value)
                                            {
                                                _inner.ValorBaseCalculo = value;
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.ValorBaseCalculo) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "ValorBaseCalculo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.ValorBaseCalculo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal AliquotaICMS
                                    {
                                        get => _inner.AliquotaICMS;
                                        set
                                        {
                                            if (_inner.AliquotaICMS != value)
                                            {
                                                _inner.AliquotaICMS = value;
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.AliquotaICMS) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "AliquotaICMS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.AliquotaICMS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal ValorICMS
                                    {
                                        get => _inner.ValorICMS;
                                        set
                                        {
                                            if (_inner.ValorICMS != value)
                                            {
                                                _inner.ValorICMS = value;
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.ValorICMS) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "ValorICMS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.ValorICMS, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeComplementoIcmsFiscalTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CTeComplementoIcmsFiscal", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeComplementoIcmsFiscalOperationalFields.UserId, _trackingExecutionIdentity);
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