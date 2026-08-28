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
                    public static class CompensacaoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong COM_ID = 1UL << 1;
            public const ulong GRP_ID = 1UL << 2;
            public const ulong OND_ID = 1UL << 3;
            public const ulong COM_VINCO1_OND = 1UL << 4;
            public const ulong COM_VINCO2_OND = 1UL << 5;
            public const ulong COM_VINCO3_OND = 1UL << 6;
            public const ulong COM_VINCO4_OND = 1UL << 7;
            public const ulong COM_VINCO5_OND = 1UL << 8;
            public const ulong COM_VINCO6_OND = 1UL << 9;
            public const ulong COM_VINCO7_OND = 1UL << 10;
            public const ulong COM_VINCO8_OND = 1UL << 11;
            public const ulong COM_VINCO9_OND = 1UL << 12;
            public const ulong COM_VINCO10_OND = 1UL << 13;
            public const ulong COM_VINCO1_CONVERSAO = 1UL << 14;
            public const ulong COM_VINCO2_CONVERSAO = 1UL << 15;
            public const ulong COM_VINCO3_CONVERSAO = 1UL << 16;
            public const ulong COM_VINCO4_CONVERSAO = 1UL << 17;
            public const ulong COM_VINCO5_CONVERSAO = 1UL << 18;
            public const ulong COM_VINCO6_CONVERSAO = 1UL << 19;
            public const ulong COM_VINCO7_CONVERSAO = 1UL << 20;
            public const ulong COM_VINCO8_CONVERSAO = 1UL << 21;
            public const ulong COM_VINCO9_CONVERSAO = 1UL << 22;
            public const ulong COM_VINCO10_CONVERSAO = 1UL << 23;
            public const ulong TenantID = 1UL << 24;
            public const ulong Deleted = 1UL << 25;
            public const ulong Changed = 1UL << 26;
            public const ulong UserId = 1UL << 27;
        }

        public partial class CompensacaoDecorator : ICompensacaoEntity
{

                        private readonly ICompensacaoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CompensacaoDecorator(ICompensacaoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CompensacaoDecorator(
                            ICompensacaoEntity inner,
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
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int COM_ID
                                    {
                                        get => _inner.COM_ID;
                                        set
                                        {
                                            if (_inner.COM_ID != value)
                                            {
                                                _inner.COM_ID = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_ID) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_ID
                                    {
                                        get => _inner.GRP_ID;
                                        set
                                        {
                                            if (_inner.GRP_ID != value)
                                            {
                                                _inner.GRP_ID = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.GRP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "GRP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OND_ID
                                    {
                                        get => _inner.OND_ID;
                                        set
                                        {
                                            if (_inner.OND_ID != value)
                                            {
                                                _inner.OND_ID = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.OND_ID) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "OND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO1_OND
                                    {
                                        get => _inner.COM_VINCO1_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO1_OND != value)
                                            {
                                                _inner.COM_VINCO1_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO1_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO1_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO2_OND
                                    {
                                        get => _inner.COM_VINCO2_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO2_OND != value)
                                            {
                                                _inner.COM_VINCO2_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO2_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO2_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO3_OND
                                    {
                                        get => _inner.COM_VINCO3_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO3_OND != value)
                                            {
                                                _inner.COM_VINCO3_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO3_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO3_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO4_OND
                                    {
                                        get => _inner.COM_VINCO4_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO4_OND != value)
                                            {
                                                _inner.COM_VINCO4_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO4_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO4_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO5_OND
                                    {
                                        get => _inner.COM_VINCO5_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO5_OND != value)
                                            {
                                                _inner.COM_VINCO5_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO5_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO5_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO6_OND
                                    {
                                        get => _inner.COM_VINCO6_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO6_OND != value)
                                            {
                                                _inner.COM_VINCO6_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO6_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO6_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO7_OND
                                    {
                                        get => _inner.COM_VINCO7_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO7_OND != value)
                                            {
                                                _inner.COM_VINCO7_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO7_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO7_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO8_OND
                                    {
                                        get => _inner.COM_VINCO8_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO8_OND != value)
                                            {
                                                _inner.COM_VINCO8_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO8_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO8_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO9_OND
                                    {
                                        get => _inner.COM_VINCO9_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO9_OND != value)
                                            {
                                                _inner.COM_VINCO9_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO9_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO9_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO10_OND
                                    {
                                        get => _inner.COM_VINCO10_OND;
                                        set
                                        {
                                            if (_inner.COM_VINCO10_OND != value)
                                            {
                                                _inner.COM_VINCO10_OND = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO10_OND) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO10_OND", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO1_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO1_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO1_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO1_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO1_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO1_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO2_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO2_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO2_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO2_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO2_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO2_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO3_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO3_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO3_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO3_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO3_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO3_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO4_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO4_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO4_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO4_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO4_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO4_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO5_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO5_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO5_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO5_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO5_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO5_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO6_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO6_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO6_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO6_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO6_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO6_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO7_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO7_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO7_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO7_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO7_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO7_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO8_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO8_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO8_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO8_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO8_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO8_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO9_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO9_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO9_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO9_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO9_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO9_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COM_VINCO10_CONVERSAO
                                    {
                                        get => _inner.COM_VINCO10_CONVERSAO;
                                        set
                                        {
                                            if (_inner.COM_VINCO10_CONVERSAO != value)
                                            {
                                                _inner.COM_VINCO10_CONVERSAO = value;
                                                if ((_trackingMask & CompensacaoTrackingFields.COM_VINCO10_CONVERSAO) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "COM_VINCO10_CONVERSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CompensacaoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CompensacaoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CompensacaoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CompensacaoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Compensacao", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration