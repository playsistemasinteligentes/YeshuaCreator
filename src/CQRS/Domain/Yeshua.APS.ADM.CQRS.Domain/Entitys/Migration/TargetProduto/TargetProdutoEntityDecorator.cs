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
                    public static class TargetProdutoTrackingFields
        {
            public const ulong TAR_ID = 1UL << 0;
            public const ulong MOV_ID = 1UL << 1;
            public const ulong ORD_ID = 1UL << 2;
            public const ulong PRO_ID = 1UL << 3;
            public const ulong MAQ_ID = 1UL << 4;
            public const ulong UNI_ID = 1UL << 5;
            public const ulong TURM_ID = 1UL << 6;
            public const ulong TURN_ID = 1UL << 7;
            public const ulong USE_ID = 1UL << 8;
            public const ulong TAR_DIA_TURMA = 1UL << 9;
            public const ulong TAR_META_PERFORMANCE = 1UL << 10;
            public const ulong TAR_REALIZADO_PERFORMANCE = 1UL << 11;
            public const ulong TAR_PERCENTUAL_REALIZADO_PERFORMANCE = 1UL << 12;
            public const ulong TAR_PROXIMA_META_PERFORMANCE = 1UL << 13;
            public const ulong TAR_META_TEMPO_SETUP = 1UL << 14;
            public const ulong TAR_REALIZADO_TEMPO_SETUP = 1UL << 15;
            public const ulong TAR_PROXIMA_META_TEMPO_SETUP = 1UL << 16;
            public const ulong TAR_META_TEMPO_SETUP_AJUSTE = 1UL << 17;
            public const ulong TAR_REALIZADO_TEMPO_SETUP_AJUSTE = 1UL << 18;
            public const ulong TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE = 1UL << 19;
            public const ulong OCO_ID_PERFORMANCE = 1UL << 20;
            public const ulong TAR_OBS_PERFORMANCE = 1UL << 21;
            public const ulong OCO_ID_SETUP = 1UL << 22;
            public const ulong TAR_OBS_SETUP = 1UL << 23;
            public const ulong OCO_ID_SETUPA = 1UL << 24;
            public const ulong TAR_OBS_SETUPA = 1UL << 25;
            public const ulong TAR_TIPO_FEEDBACK_PERFORMANCE = 1UL << 26;
            public const ulong TAR_TIPO_FEEDBACK_SETUP = 1UL << 27;
            public const ulong TAR_TIPO_FEEDBACK_SETUP_AJUSTE = 1UL << 28;
            public const ulong TAR_QTD_SETUP_AJUSTE = 1UL << 29;
            public const ulong TAR_QTD = 1UL << 30;
            public const ulong TAR_PARAMETRO_TIME_WORK_STOP_MACHINE = 1UL << 31;
            public const ulong TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE = 1UL << 32;
            public const ulong ROT_SEQ_TRANFORMACAO = 1UL << 33;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 34;
            public const ulong TAR_PERFORMANCE_MAX_VERDE = 1UL << 35;
            public const ulong TAR_PERFORMANCE_MIN_VERDE = 1UL << 36;
            public const ulong TAR_SETUP_MAX_VERDE = 1UL << 37;
            public const ulong TAR_SETUP_MIN_VERDE = 1UL << 38;
            public const ulong TAR_SETUPA_MAX_VERDE = 1UL << 39;
            public const ulong TAR_SETUPA_MIN_VERDE = 1UL << 40;
            public const ulong TAR_PERFORMANCE_MIN_AMARELO = 1UL << 41;
            public const ulong TAR_SETUP_MAX_AMARELO = 1UL << 42;
            public const ulong TAR_SETUPA_MAX_AMARELO = 1UL << 43;
            public const ulong TAR_OBS_OP_PARCIAL = 1UL << 44;
            public const ulong TAR_OCO_ID_OP_PARCIAL = 1UL << 45;
            public const ulong TAR_COR_PERFORMANCE = 1UL << 46;
            public const ulong TAR_COR_SETUP_GERAL = 1UL << 47;
            public const ulong TAR_COR_SETUP = 1UL << 48;
            public const ulong TAR_COR_SETUPA = 1UL << 49;
            public const ulong TAR_DIA_TURMA_D = 1UL << 50;
            public const ulong FEE_QTD_PECAS_POR_PULSO = 1UL << 51;
            public const ulong TAR_QTD_PERDAS = 1UL << 52;
            public const ulong TAR_DATA_INICIAL = 1UL << 53;
            public const ulong TAR_DATA_FINAL = 1UL << 54;
            public const ulong TAR_APROVADO = 1UL << 55;
            public const ulong TAR_TEMPO_PRODUZINDO = 1UL << 56;
            public const ulong TenantID = 1UL << 57;
            public const ulong Deleted = 1UL << 58;
            public const ulong Changed = 1UL << 59;
            public const ulong UserId = 1UL << 60;
        }

        public partial class TargetProdutoDecorator : ITargetProdutoEntity
{

                        private readonly ITargetProdutoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TargetProdutoDecorator(ITargetProdutoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TargetProdutoDecorator(
                            ITargetProdutoEntity inner,
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
                                    public int TAR_ID
                                    {
                                        get => _inner.TAR_ID;
                                        set
                                        {
                                            if (_inner.TAR_ID != value)
                                            {
                                                _inner.TAR_ID = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MOV_ID
                                    {
                                        get => _inner.MOV_ID;
                                        set
                                        {
                                            if (_inner.MOV_ID != value)
                                            {
                                                _inner.MOV_ID = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.MOV_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "MOV_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TargetProdutoTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID
                                    {
                                        get => _inner.PRO_ID;
                                        set
                                        {
                                            if (_inner.PRO_ID != value)
                                            {
                                                _inner.PRO_ID = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID
                                    {
                                        get => _inner.MAQ_ID;
                                        set
                                        {
                                            if (_inner.MAQ_ID != value)
                                            {
                                                _inner.MAQ_ID = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UNI_ID
                                    {
                                        get => _inner.UNI_ID;
                                        set
                                        {
                                            if (_inner.UNI_ID != value)
                                            {
                                                _inner.UNI_ID = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TargetProdutoTrackingFields.TURM_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TURM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TargetProdutoTrackingFields.TURN_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TURN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? USE_ID
                                    {
                                        get => _inner.USE_ID;
                                        set
                                        {
                                            if (_inner.USE_ID != value)
                                            {
                                                _inner.USE_ID = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_DIA_TURMA
                                    {
                                        get => _inner.TAR_DIA_TURMA;
                                        set
                                        {
                                            if (_inner.TAR_DIA_TURMA != value)
                                            {
                                                _inner.TAR_DIA_TURMA = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_DIA_TURMA) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_DIA_TURMA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal TAR_META_PERFORMANCE
                                    {
                                        get => _inner.TAR_META_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.TAR_META_PERFORMANCE != value)
                                            {
                                                _inner.TAR_META_PERFORMANCE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_META_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_META_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_REALIZADO_PERFORMANCE
                                    {
                                        get => _inner.TAR_REALIZADO_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.TAR_REALIZADO_PERFORMANCE != value)
                                            {
                                                _inner.TAR_REALIZADO_PERFORMANCE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_REALIZADO_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_REALIZADO_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_PERCENTUAL_REALIZADO_PERFORMANCE
                                    {
                                        get => _inner.TAR_PERCENTUAL_REALIZADO_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.TAR_PERCENTUAL_REALIZADO_PERFORMANCE != value)
                                            {
                                                _inner.TAR_PERCENTUAL_REALIZADO_PERFORMANCE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PERCENTUAL_REALIZADO_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PERCENTUAL_REALIZADO_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_PROXIMA_META_PERFORMANCE
                                    {
                                        get => _inner.TAR_PROXIMA_META_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.TAR_PROXIMA_META_PERFORMANCE != value)
                                            {
                                                _inner.TAR_PROXIMA_META_PERFORMANCE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PROXIMA_META_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PROXIMA_META_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal TAR_META_TEMPO_SETUP
                                    {
                                        get => _inner.TAR_META_TEMPO_SETUP;
                                        set
                                        {
                                            if (_inner.TAR_META_TEMPO_SETUP != value)
                                            {
                                                _inner.TAR_META_TEMPO_SETUP = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_META_TEMPO_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_META_TEMPO_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_REALIZADO_TEMPO_SETUP
                                    {
                                        get => _inner.TAR_REALIZADO_TEMPO_SETUP;
                                        set
                                        {
                                            if (_inner.TAR_REALIZADO_TEMPO_SETUP != value)
                                            {
                                                _inner.TAR_REALIZADO_TEMPO_SETUP = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_REALIZADO_TEMPO_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_REALIZADO_TEMPO_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_PROXIMA_META_TEMPO_SETUP
                                    {
                                        get => _inner.TAR_PROXIMA_META_TEMPO_SETUP;
                                        set
                                        {
                                            if (_inner.TAR_PROXIMA_META_TEMPO_SETUP != value)
                                            {
                                                _inner.TAR_PROXIMA_META_TEMPO_SETUP = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PROXIMA_META_TEMPO_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PROXIMA_META_TEMPO_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal TAR_META_TEMPO_SETUP_AJUSTE
                                    {
                                        get => _inner.TAR_META_TEMPO_SETUP_AJUSTE;
                                        set
                                        {
                                            if (_inner.TAR_META_TEMPO_SETUP_AJUSTE != value)
                                            {
                                                _inner.TAR_META_TEMPO_SETUP_AJUSTE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_META_TEMPO_SETUP_AJUSTE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_META_TEMPO_SETUP_AJUSTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_REALIZADO_TEMPO_SETUP_AJUSTE
                                    {
                                        get => _inner.TAR_REALIZADO_TEMPO_SETUP_AJUSTE;
                                        set
                                        {
                                            if (_inner.TAR_REALIZADO_TEMPO_SETUP_AJUSTE != value)
                                            {
                                                _inner.TAR_REALIZADO_TEMPO_SETUP_AJUSTE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_REALIZADO_TEMPO_SETUP_AJUSTE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_REALIZADO_TEMPO_SETUP_AJUSTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE
                                    {
                                        get => _inner.TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE;
                                        set
                                        {
                                            if (_inner.TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE != value)
                                            {
                                                _inner.TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OCO_ID_PERFORMANCE
                                    {
                                        get => _inner.OCO_ID_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.OCO_ID_PERFORMANCE != value)
                                            {
                                                _inner.OCO_ID_PERFORMANCE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.OCO_ID_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "OCO_ID_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_OBS_PERFORMANCE
                                    {
                                        get => _inner.TAR_OBS_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.TAR_OBS_PERFORMANCE != value)
                                            {
                                                _inner.TAR_OBS_PERFORMANCE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_OBS_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_OBS_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OCO_ID_SETUP
                                    {
                                        get => _inner.OCO_ID_SETUP;
                                        set
                                        {
                                            if (_inner.OCO_ID_SETUP != value)
                                            {
                                                _inner.OCO_ID_SETUP = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.OCO_ID_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "OCO_ID_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_OBS_SETUP
                                    {
                                        get => _inner.TAR_OBS_SETUP;
                                        set
                                        {
                                            if (_inner.TAR_OBS_SETUP != value)
                                            {
                                                _inner.TAR_OBS_SETUP = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_OBS_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_OBS_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OCO_ID_SETUPA
                                    {
                                        get => _inner.OCO_ID_SETUPA;
                                        set
                                        {
                                            if (_inner.OCO_ID_SETUPA != value)
                                            {
                                                _inner.OCO_ID_SETUPA = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.OCO_ID_SETUPA) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "OCO_ID_SETUPA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_OBS_SETUPA
                                    {
                                        get => _inner.TAR_OBS_SETUPA;
                                        set
                                        {
                                            if (_inner.TAR_OBS_SETUPA != value)
                                            {
                                                _inner.TAR_OBS_SETUPA = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_OBS_SETUPA) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_OBS_SETUPA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_TIPO_FEEDBACK_PERFORMANCE
                                    {
                                        get => _inner.TAR_TIPO_FEEDBACK_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.TAR_TIPO_FEEDBACK_PERFORMANCE != value)
                                            {
                                                _inner.TAR_TIPO_FEEDBACK_PERFORMANCE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_TIPO_FEEDBACK_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_TIPO_FEEDBACK_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_TIPO_FEEDBACK_SETUP
                                    {
                                        get => _inner.TAR_TIPO_FEEDBACK_SETUP;
                                        set
                                        {
                                            if (_inner.TAR_TIPO_FEEDBACK_SETUP != value)
                                            {
                                                _inner.TAR_TIPO_FEEDBACK_SETUP = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_TIPO_FEEDBACK_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_TIPO_FEEDBACK_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_TIPO_FEEDBACK_SETUP_AJUSTE
                                    {
                                        get => _inner.TAR_TIPO_FEEDBACK_SETUP_AJUSTE;
                                        set
                                        {
                                            if (_inner.TAR_TIPO_FEEDBACK_SETUP_AJUSTE != value)
                                            {
                                                _inner.TAR_TIPO_FEEDBACK_SETUP_AJUSTE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_TIPO_FEEDBACK_SETUP_AJUSTE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_TIPO_FEEDBACK_SETUP_AJUSTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_QTD_SETUP_AJUSTE
                                    {
                                        get => _inner.TAR_QTD_SETUP_AJUSTE;
                                        set
                                        {
                                            if (_inner.TAR_QTD_SETUP_AJUSTE != value)
                                            {
                                                _inner.TAR_QTD_SETUP_AJUSTE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_QTD_SETUP_AJUSTE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_QTD_SETUP_AJUSTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_QTD
                                    {
                                        get => _inner.TAR_QTD;
                                        set
                                        {
                                            if (_inner.TAR_QTD != value)
                                            {
                                                _inner.TAR_QTD = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_QTD) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_QTD", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TAR_PARAMETRO_TIME_WORK_STOP_MACHINE
                                    {
                                        get => _inner.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE;
                                        set
                                        {
                                            if (_inner.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE != value)
                                            {
                                                _inner.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PARAMETRO_TIME_WORK_STOP_MACHINE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE
                                    {
                                        get => _inner.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE;
                                        set
                                        {
                                            if (_inner.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE != value)
                                            {
                                                _inner.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ROT_SEQ_TRANFORMACAO
                                    {
                                        get => _inner.ROT_SEQ_TRANFORMACAO;
                                        set
                                        {
                                            if (_inner.ROT_SEQ_TRANFORMACAO != value)
                                            {
                                                _inner.ROT_SEQ_TRANFORMACAO = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.ROT_SEQ_TRANFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "ROT_SEQ_TRANFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TargetProdutoTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_PERFORMANCE_MAX_VERDE
                                    {
                                        get => _inner.TAR_PERFORMANCE_MAX_VERDE;
                                        set
                                        {
                                            if (_inner.TAR_PERFORMANCE_MAX_VERDE != value)
                                            {
                                                _inner.TAR_PERFORMANCE_MAX_VERDE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PERFORMANCE_MAX_VERDE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PERFORMANCE_MAX_VERDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_PERFORMANCE_MIN_VERDE
                                    {
                                        get => _inner.TAR_PERFORMANCE_MIN_VERDE;
                                        set
                                        {
                                            if (_inner.TAR_PERFORMANCE_MIN_VERDE != value)
                                            {
                                                _inner.TAR_PERFORMANCE_MIN_VERDE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PERFORMANCE_MIN_VERDE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PERFORMANCE_MIN_VERDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_SETUP_MAX_VERDE
                                    {
                                        get => _inner.TAR_SETUP_MAX_VERDE;
                                        set
                                        {
                                            if (_inner.TAR_SETUP_MAX_VERDE != value)
                                            {
                                                _inner.TAR_SETUP_MAX_VERDE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_SETUP_MAX_VERDE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_SETUP_MAX_VERDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_SETUP_MIN_VERDE
                                    {
                                        get => _inner.TAR_SETUP_MIN_VERDE;
                                        set
                                        {
                                            if (_inner.TAR_SETUP_MIN_VERDE != value)
                                            {
                                                _inner.TAR_SETUP_MIN_VERDE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_SETUP_MIN_VERDE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_SETUP_MIN_VERDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_SETUPA_MAX_VERDE
                                    {
                                        get => _inner.TAR_SETUPA_MAX_VERDE;
                                        set
                                        {
                                            if (_inner.TAR_SETUPA_MAX_VERDE != value)
                                            {
                                                _inner.TAR_SETUPA_MAX_VERDE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_SETUPA_MAX_VERDE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_SETUPA_MAX_VERDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_SETUPA_MIN_VERDE
                                    {
                                        get => _inner.TAR_SETUPA_MIN_VERDE;
                                        set
                                        {
                                            if (_inner.TAR_SETUPA_MIN_VERDE != value)
                                            {
                                                _inner.TAR_SETUPA_MIN_VERDE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_SETUPA_MIN_VERDE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_SETUPA_MIN_VERDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_PERFORMANCE_MIN_AMARELO
                                    {
                                        get => _inner.TAR_PERFORMANCE_MIN_AMARELO;
                                        set
                                        {
                                            if (_inner.TAR_PERFORMANCE_MIN_AMARELO != value)
                                            {
                                                _inner.TAR_PERFORMANCE_MIN_AMARELO = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_PERFORMANCE_MIN_AMARELO) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_PERFORMANCE_MIN_AMARELO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_SETUP_MAX_AMARELO
                                    {
                                        get => _inner.TAR_SETUP_MAX_AMARELO;
                                        set
                                        {
                                            if (_inner.TAR_SETUP_MAX_AMARELO != value)
                                            {
                                                _inner.TAR_SETUP_MAX_AMARELO = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_SETUP_MAX_AMARELO) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_SETUP_MAX_AMARELO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_SETUPA_MAX_AMARELO
                                    {
                                        get => _inner.TAR_SETUPA_MAX_AMARELO;
                                        set
                                        {
                                            if (_inner.TAR_SETUPA_MAX_AMARELO != value)
                                            {
                                                _inner.TAR_SETUPA_MAX_AMARELO = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_SETUPA_MAX_AMARELO) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_SETUPA_MAX_AMARELO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_OBS_OP_PARCIAL
                                    {
                                        get => _inner.TAR_OBS_OP_PARCIAL;
                                        set
                                        {
                                            if (_inner.TAR_OBS_OP_PARCIAL != value)
                                            {
                                                _inner.TAR_OBS_OP_PARCIAL = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_OBS_OP_PARCIAL) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_OBS_OP_PARCIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_OCO_ID_OP_PARCIAL
                                    {
                                        get => _inner.TAR_OCO_ID_OP_PARCIAL;
                                        set
                                        {
                                            if (_inner.TAR_OCO_ID_OP_PARCIAL != value)
                                            {
                                                _inner.TAR_OCO_ID_OP_PARCIAL = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_OCO_ID_OP_PARCIAL) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_OCO_ID_OP_PARCIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_COR_PERFORMANCE
                                    {
                                        get => _inner.TAR_COR_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.TAR_COR_PERFORMANCE != value)
                                            {
                                                _inner.TAR_COR_PERFORMANCE = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_COR_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_COR_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_COR_SETUP_GERAL
                                    {
                                        get => _inner.TAR_COR_SETUP_GERAL;
                                        set
                                        {
                                            if (_inner.TAR_COR_SETUP_GERAL != value)
                                            {
                                                _inner.TAR_COR_SETUP_GERAL = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_COR_SETUP_GERAL) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_COR_SETUP_GERAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_COR_SETUP
                                    {
                                        get => _inner.TAR_COR_SETUP;
                                        set
                                        {
                                            if (_inner.TAR_COR_SETUP != value)
                                            {
                                                _inner.TAR_COR_SETUP = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_COR_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_COR_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_COR_SETUPA
                                    {
                                        get => _inner.TAR_COR_SETUPA;
                                        set
                                        {
                                            if (_inner.TAR_COR_SETUPA != value)
                                            {
                                                _inner.TAR_COR_SETUPA = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_COR_SETUPA) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_COR_SETUPA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TAR_DIA_TURMA_D
                                    {
                                        get => _inner.TAR_DIA_TURMA_D;
                                        set
                                        {
                                            if (_inner.TAR_DIA_TURMA_D != value)
                                            {
                                                _inner.TAR_DIA_TURMA_D = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_DIA_TURMA_D) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_DIA_TURMA_D", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FEE_QTD_PECAS_POR_PULSO
                                    {
                                        get => _inner.FEE_QTD_PECAS_POR_PULSO;
                                        set
                                        {
                                            if (_inner.FEE_QTD_PECAS_POR_PULSO != value)
                                            {
                                                _inner.FEE_QTD_PECAS_POR_PULSO = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.FEE_QTD_PECAS_POR_PULSO) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "FEE_QTD_PECAS_POR_PULSO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TAR_QTD_PERDAS
                                    {
                                        get => _inner.TAR_QTD_PERDAS;
                                        set
                                        {
                                            if (_inner.TAR_QTD_PERDAS != value)
                                            {
                                                _inner.TAR_QTD_PERDAS = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_QTD_PERDAS) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_QTD_PERDAS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TAR_DATA_INICIAL
                                    {
                                        get => _inner.TAR_DATA_INICIAL;
                                        set
                                        {
                                            if (_inner.TAR_DATA_INICIAL != value)
                                            {
                                                _inner.TAR_DATA_INICIAL = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_DATA_INICIAL) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_DATA_INICIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TAR_DATA_FINAL
                                    {
                                        get => _inner.TAR_DATA_FINAL;
                                        set
                                        {
                                            if (_inner.TAR_DATA_FINAL != value)
                                            {
                                                _inner.TAR_DATA_FINAL = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_DATA_FINAL) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_DATA_FINAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TAR_APROVADO
                                    {
                                        get => _inner.TAR_APROVADO;
                                        set
                                        {
                                            if (_inner.TAR_APROVADO != value)
                                            {
                                                _inner.TAR_APROVADO = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_APROVADO) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_APROVADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TAR_TEMPO_PRODUZINDO
                                    {
                                        get => _inner.TAR_TEMPO_PRODUZINDO;
                                        set
                                        {
                                            if (_inner.TAR_TEMPO_PRODUZINDO != value)
                                            {
                                                _inner.TAR_TEMPO_PRODUZINDO = value;
                                                if ((_trackingMask & TargetProdutoTrackingFields.TAR_TEMPO_PRODUZINDO) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TAR_TEMPO_PRODUZINDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TargetProdutoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TargetProdutoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TargetProdutoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TargetProdutoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TargetProduto", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration