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
                    public static class OndaTrackingFields
        {
            public const ulong OND_ID = 1UL << 0;
            public const ulong OND_ESPESSURA = 1UL << 1;
            public const ulong OND_PESO_COLA = 1UL << 2;
            public const ulong OND_RENDIMENTO_ONDA_1 = 1UL << 3;
            public const ulong OND_RENDIMENTO_ONDA_2 = 1UL << 4;
            public const ulong OND_PROFUNDIDADE_VINCO = 1UL << 5;
            public const ulong OND_ID_INTEGRACAO = 1UL << 6;
            public const ulong VIN_ID = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class OndaDecorator : IOndaEntity
{

                        private readonly IOndaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OndaDecorator(IOndaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OndaDecorator(
                            IOndaEntity inner,
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
                                    public string OND_ID
                                    {
                                        get => _inner.OND_ID;
                                        set
                                        {
                                            if (_inner.OND_ID != value)
                                            {
                                                _inner.OND_ID = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_ID) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal OND_ESPESSURA
                                    {
                                        get => _inner.OND_ESPESSURA;
                                        set
                                        {
                                            if (_inner.OND_ESPESSURA != value)
                                            {
                                                _inner.OND_ESPESSURA = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_ESPESSURA) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_ESPESSURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? OND_PESO_COLA
                                    {
                                        get => _inner.OND_PESO_COLA;
                                        set
                                        {
                                            if (_inner.OND_PESO_COLA != value)
                                            {
                                                _inner.OND_PESO_COLA = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_PESO_COLA) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_PESO_COLA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? OND_RENDIMENTO_ONDA_1
                                    {
                                        get => _inner.OND_RENDIMENTO_ONDA_1;
                                        set
                                        {
                                            if (_inner.OND_RENDIMENTO_ONDA_1 != value)
                                            {
                                                _inner.OND_RENDIMENTO_ONDA_1 = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_RENDIMENTO_ONDA_1) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_RENDIMENTO_ONDA_1", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? OND_RENDIMENTO_ONDA_2
                                    {
                                        get => _inner.OND_RENDIMENTO_ONDA_2;
                                        set
                                        {
                                            if (_inner.OND_RENDIMENTO_ONDA_2 != value)
                                            {
                                                _inner.OND_RENDIMENTO_ONDA_2 = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_RENDIMENTO_ONDA_2) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_RENDIMENTO_ONDA_2", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? OND_PROFUNDIDADE_VINCO
                                    {
                                        get => _inner.OND_PROFUNDIDADE_VINCO;
                                        set
                                        {
                                            if (_inner.OND_PROFUNDIDADE_VINCO != value)
                                            {
                                                _inner.OND_PROFUNDIDADE_VINCO = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_PROFUNDIDADE_VINCO) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_PROFUNDIDADE_VINCO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OND_ID_INTEGRACAO
                                    {
                                        get => _inner.OND_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.OND_ID_INTEGRACAO != value)
                                            {
                                                _inner.OND_ID_INTEGRACAO = value;
                                                if ((_trackingMask & OndaTrackingFields.OND_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "OND_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int VIN_ID
                                    {
                                        get => _inner.VIN_ID;
                                        set
                                        {
                                            if (_inner.VIN_ID != value)
                                            {
                                                _inner.VIN_ID = value;
                                                if ((_trackingMask & OndaTrackingFields.VIN_ID) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "VIN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OndaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OndaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OndaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OndaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Onda", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration