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
                    public static class MedidasTesteTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MDT_ID = 1UL << 1;
            public const ulong MDT_DESC = 1UL << 2;
            public const ulong MDT_VALOR_ESPERADO = 1UL << 3;
            public const ulong MDT_ENCONTRADO = 1UL << 4;
            public const ulong UNI_ID = 1UL << 5;
            public const ulong OperationalEntityId = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
        }

        public static class MedidasTesteOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MDT_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MDT_DESC = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MDT_VALOR_ESPERADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MDT_ENCONTRADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UNI_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class MedidasTesteDecorator : IMedidasTesteEntity
{

                        private readonly IMedidasTesteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MedidasTesteDecorator(IMedidasTesteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MedidasTesteDecorator(
                            IMedidasTesteEntity inner,
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
                                                if ((_trackingMask & MedidasTesteTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int MDT_ID
                                    {
                                        get => _inner.MDT_ID;
                                        set
                                        {
                                            if (_inner.MDT_ID != value)
                                            {
                                                _inner.MDT_ID = value;
                                                if ((_trackingMask & MedidasTesteTrackingFields.MDT_ID) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "MDT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.MDT_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MDT_DESC
                                    {
                                        get => _inner.MDT_DESC;
                                        set
                                        {
                                            if (_inner.MDT_DESC != value)
                                            {
                                                _inner.MDT_DESC = value;
                                                if ((_trackingMask & MedidasTesteTrackingFields.MDT_DESC) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "MDT_DESC", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.MDT_DESC, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? MDT_VALOR_ESPERADO
                                    {
                                        get => _inner.MDT_VALOR_ESPERADO;
                                        set
                                        {
                                            if (_inner.MDT_VALOR_ESPERADO != value)
                                            {
                                                _inner.MDT_VALOR_ESPERADO = value;
                                                if ((_trackingMask & MedidasTesteTrackingFields.MDT_VALOR_ESPERADO) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "MDT_VALOR_ESPERADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.MDT_VALOR_ESPERADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? MDT_ENCONTRADO
                                    {
                                        get => _inner.MDT_ENCONTRADO;
                                        set
                                        {
                                            if (_inner.MDT_ENCONTRADO != value)
                                            {
                                                _inner.MDT_ENCONTRADO = value;
                                                if ((_trackingMask & MedidasTesteTrackingFields.MDT_ENCONTRADO) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "MDT_ENCONTRADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.MDT_ENCONTRADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? UNI_ID
                                    {
                                        get => _inner.UNI_ID;
                                        set
                                        {
                                            if (_inner.UNI_ID != value)
                                            {
                                                _inner.UNI_ID = value;
                                                if ((_trackingMask & MedidasTesteTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.UNI_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MedidasTesteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MedidasTesteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MedidasTesteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MedidasTesteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MedidasTeste", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MedidasTesteOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration