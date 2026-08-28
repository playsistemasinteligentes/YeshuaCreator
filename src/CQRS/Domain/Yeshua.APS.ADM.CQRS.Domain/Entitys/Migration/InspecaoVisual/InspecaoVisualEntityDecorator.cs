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
                    public static class InspecaoVisualTrackingFields
        {
            public const ulong IPV_ID = 1UL << 0;
            public const ulong IPV_VALOR = 1UL << 1;
            public const ulong IPV_ID_OPERADOR = 1UL << 2;
            public const ulong IPV_ID_LIBERACAO = 1UL << 3;
            public const ulong IPV_OBS = 1UL << 4;
            public const ulong IPV_DATA_COLETA = 1UL << 5;
            public const ulong IPV_DATA_AVAL = 1UL << 6;
            public const ulong TIV_ID = 1UL << 7;
            public const ulong TURN_ID = 1UL << 8;
            public const ulong TURM_ID = 1UL << 9;
            public const ulong ORD_ID = 1UL << 10;
            public const ulong ROT_PRO_ID = 1UL << 11;
            public const ulong ROT_MAQ_ID = 1UL << 12;
            public const ulong ROT_SEQ_TRANSFORMACAO = 1UL << 13;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 14;
            public const ulong IPV_STATUS_LIBERACAO = 1UL << 15;
            public const ulong IPV_VALOR_MEDIDA = 1UL << 16;
            public const ulong TenantID = 1UL << 17;
            public const ulong Deleted = 1UL << 18;
            public const ulong Changed = 1UL << 19;
            public const ulong UserId = 1UL << 20;
        }

        public partial class InspecaoVisualDecorator : IInspecaoVisualEntity
{

                        private readonly IInspecaoVisualEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public InspecaoVisualDecorator(IInspecaoVisualEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public InspecaoVisualDecorator(
                            IInspecaoVisualEntity inner,
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
                                    public int IPV_ID
                                    {
                                        get => _inner.IPV_ID;
                                        set
                                        {
                                            if (_inner.IPV_ID != value)
                                            {
                                                _inner.IPV_ID = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_ID) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string IPV_VALOR
                                    {
                                        get => _inner.IPV_VALOR;
                                        set
                                        {
                                            if (_inner.IPV_VALOR != value)
                                            {
                                                _inner.IPV_VALOR = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? IPV_ID_OPERADOR
                                    {
                                        get => _inner.IPV_ID_OPERADOR;
                                        set
                                        {
                                            if (_inner.IPV_ID_OPERADOR != value)
                                            {
                                                _inner.IPV_ID_OPERADOR = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_ID_OPERADOR) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_ID_OPERADOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? IPV_ID_LIBERACAO
                                    {
                                        get => _inner.IPV_ID_LIBERACAO;
                                        set
                                        {
                                            if (_inner.IPV_ID_LIBERACAO != value)
                                            {
                                                _inner.IPV_ID_LIBERACAO = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_ID_LIBERACAO) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_ID_LIBERACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string IPV_OBS
                                    {
                                        get => _inner.IPV_OBS;
                                        set
                                        {
                                            if (_inner.IPV_OBS != value)
                                            {
                                                _inner.IPV_OBS = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_OBS) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_OBS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? IPV_DATA_COLETA
                                    {
                                        get => _inner.IPV_DATA_COLETA;
                                        set
                                        {
                                            if (_inner.IPV_DATA_COLETA != value)
                                            {
                                                _inner.IPV_DATA_COLETA = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_DATA_COLETA) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_DATA_COLETA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? IPV_DATA_AVAL
                                    {
                                        get => _inner.IPV_DATA_AVAL;
                                        set
                                        {
                                            if (_inner.IPV_DATA_AVAL != value)
                                            {
                                                _inner.IPV_DATA_AVAL = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_DATA_AVAL) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_DATA_AVAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TIV_ID
                                    {
                                        get => _inner.TIV_ID;
                                        set
                                        {
                                            if (_inner.TIV_ID != value)
                                            {
                                                _inner.TIV_ID = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.TIV_ID) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "TIV_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TURN_ID
                                    {
                                        get => _inner.TURN_ID;
                                        set
                                        {
                                            if (_inner.TURN_ID != value)
                                            {
                                                _inner.TURN_ID = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.TURN_ID) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "TURN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TURM_ID
                                    {
                                        get => _inner.TURM_ID;
                                        set
                                        {
                                            if (_inner.TURM_ID != value)
                                            {
                                                _inner.TURM_ID = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.TURM_ID) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "TURM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ID
                                    {
                                        get => _inner.ORD_ID;
                                        set
                                        {
                                            if (_inner.ORD_ID != value)
                                            {
                                                _inner.ORD_ID = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_PRO_ID
                                    {
                                        get => _inner.ROT_PRO_ID;
                                        set
                                        {
                                            if (_inner.ROT_PRO_ID != value)
                                            {
                                                _inner.ROT_PRO_ID = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.ROT_PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "ROT_PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_MAQ_ID
                                    {
                                        get => _inner.ROT_MAQ_ID;
                                        set
                                        {
                                            if (_inner.ROT_MAQ_ID != value)
                                            {
                                                _inner.ROT_MAQ_ID = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.ROT_MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "ROT_MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ROT_SEQ_TRANSFORMACAO
                                    {
                                        get => _inner.ROT_SEQ_TRANSFORMACAO;
                                        set
                                        {
                                            if (_inner.ROT_SEQ_TRANSFORMACAO != value)
                                            {
                                                _inner.ROT_SEQ_TRANSFORMACAO = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.ROT_SEQ_TRANSFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "ROT_SEQ_TRANSFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_SEQ_REPETICAO
                                    {
                                        get => _inner.FPR_SEQ_REPETICAO;
                                        set
                                        {
                                            if (_inner.FPR_SEQ_REPETICAO != value)
                                            {
                                                _inner.FPR_SEQ_REPETICAO = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string IPV_STATUS_LIBERACAO
                                    {
                                        get => _inner.IPV_STATUS_LIBERACAO;
                                        set
                                        {
                                            if (_inner.IPV_STATUS_LIBERACAO != value)
                                            {
                                                _inner.IPV_STATUS_LIBERACAO = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_STATUS_LIBERACAO) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_STATUS_LIBERACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? IPV_VALOR_MEDIDA
                                    {
                                        get => _inner.IPV_VALOR_MEDIDA;
                                        set
                                        {
                                            if (_inner.IPV_VALOR_MEDIDA != value)
                                            {
                                                _inner.IPV_VALOR_MEDIDA = value;
                                                if ((_trackingMask & InspecaoVisualTrackingFields.IPV_VALOR_MEDIDA) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "IPV_VALOR_MEDIDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & InspecaoVisualTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & InspecaoVisualTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & InspecaoVisualTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & InspecaoVisualTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("InspecaoVisual", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration