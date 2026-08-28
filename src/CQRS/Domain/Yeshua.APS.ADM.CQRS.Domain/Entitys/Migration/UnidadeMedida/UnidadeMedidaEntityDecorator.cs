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
                    public static class UnidadeMedidaTrackingFields
        {
            public const ulong UNI_ID = 1UL << 0;
            public const ulong UNI_DESCRICAO = 1UL << 1;
            public const ulong UNI_ESCALA_TEMPO = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
        }

        public partial class UnidadeMedidaDecorator : IUnidadeMedidaEntity
{

                        private readonly IUnidadeMedidaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public UnidadeMedidaDecorator(IUnidadeMedidaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public UnidadeMedidaDecorator(
                            IUnidadeMedidaEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public string UNI_ID
                                    {
                                        get => _inner.UNI_ID;
                                        set
                                        {
                                            if (_inner.UNI_ID != value)
                                            {
                                                _inner.UNI_ID = value;
                                                if ((_trackingMask & UnidadeMedidaTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("UnidadeMedida", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UNI_DESCRICAO
                                    {
                                        get => _inner.UNI_DESCRICAO;
                                        set
                                        {
                                            if (_inner.UNI_DESCRICAO != value)
                                            {
                                                _inner.UNI_DESCRICAO = value;
                                                if ((_trackingMask & UnidadeMedidaTrackingFields.UNI_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("UnidadeMedida", "UNI_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UNI_ESCALA_TEMPO
                                    {
                                        get => _inner.UNI_ESCALA_TEMPO;
                                        set
                                        {
                                            if (_inner.UNI_ESCALA_TEMPO != value)
                                            {
                                                _inner.UNI_ESCALA_TEMPO = value;
                                                if ((_trackingMask & UnidadeMedidaTrackingFields.UNI_ESCALA_TEMPO) != 0UL)
                                                    _logger.DomainValueChanged("UnidadeMedida", "UNI_ESCALA_TEMPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & UnidadeMedidaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("UnidadeMedida", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & UnidadeMedidaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("UnidadeMedida", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & UnidadeMedidaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("UnidadeMedida", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & UnidadeMedidaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("UnidadeMedida", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration