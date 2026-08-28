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
                    public static class FilaProducaoPrevistaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ORD_ID = 1UL << 1;
            public const ulong ROT_PRO_ID = 1UL << 2;
            public const ulong FPR_QUANTIDADE_PREVISTA = 1UL << 3;
            public const ulong ROT_MAQ_ID = 1UL << 4;
            public const ulong FPR_DATA_INICIO_PREVISTA = 1UL << 5;
            public const ulong FPR_DATA_FIM_PREVISTA = 1UL << 6;
            public const ulong FPR_DATA_FIM_MAXIMA = 1UL << 7;
            public const ulong ROT_SEQ_TRANFORMACAO = 1UL << 8;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 9;
            public const ulong FPR_OBS_PRODUCAO = 1UL << 10;
            public const ulong FPR_STATUS = 1UL << 11;
            public const ulong FPR_TEMPO_DECORRIDO_SETUP = 1UL << 12;
            public const ulong FPR_TEMPO_DECORRIDO_SETUPA = 1UL << 13;
            public const ulong FPR_TEMPO_DECORRIDO_PERFORMANC = 1UL << 14;
            public const ulong FPR_TEMPO_DECO_PEQUENA_PARADA = 1UL << 15;
            public const ulong FPR_QTD_PERFORMANCE = 1UL << 16;
            public const ulong FPR_QTD_SETUP = 1UL << 17;
            public const ulong FPR_QTD_PRODUZIDA = 1UL << 18;
            public const ulong FPR_TEMPO_TEORICO_PERFORMANCE = 1UL << 19;
            public const ulong FPR_TEMPO_RESTANTE_PERFORMANC = 1UL << 20;
            public const ulong FPR_VELOCIDADE_P_ATINGIR_META = 1UL << 21;
            public const ulong FPR_QTD_RESTANTE = 1UL << 22;
            public const ulong FPR_VELO_ATU_PC_SEGUNDO = 1UL << 23;
            public const ulong FPR_PERFORMANCE_PROJETADA = 1UL << 24;
            public const ulong FPR_TEMPO_RESTANTE_TOTAL = 1UL << 25;
            public const ulong FPR_FIM_PREVISTO_ATUAL = 1UL << 26;
            public const ulong FPR_PRODUZINDO = 1UL << 27;
            public const ulong FPR_ORDEM_NA_FILA = 1UL << 28;
            public const ulong FPR_ID_INTEGRACAO = 1UL << 29;
            public const ulong FPR_TRUNCADO = 1UL << 30;
            public const ulong FPR_DATA_TRUNC_INI = 1UL << 31;
            public const ulong FPR_DATA_TRUNC_FIM = 1UL << 32;
            public const ulong FPR_ID = 1UL << 33;
            public const ulong FPR_COR_FILA = 1UL << 34;
            public const ulong MAQ_ID_MANUAL = 1UL << 35;
            public const ulong MAQ_ID_RESTRINGIDA = 1UL << 36;
            public const ulong FPR_PREVISAO_MATERIA_PRIMA = 1UL << 37;
            public const ulong FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = 1UL << 38;
            public const ulong FPR_DATA_NECESSIDADE_FIM_PRODUCAO = 1UL << 39;
            public const ulong FPR_GRUPO_PRODUTIVO = 1UL << 40;
            public const ulong FPR_INICIO_GRUPO_PRODUTIVO = 1UL << 41;
            public const ulong FPR_FIM_GRUPO_PRODUTIVO = 1UL << 42;
            public const ulong FPR_COR_BICO1 = 1UL << 43;
            public const ulong FPR_COR_BICO2 = 1UL << 44;
            public const ulong FPR_COR_BICO3 = 1UL << 45;
            public const ulong FPR_COR_BICO4 = 1UL << 46;
            public const ulong FPR_COR_BICO5 = 1UL << 47;
            public const ulong FPR_META_SETUP = 1UL << 48;
            public const ulong FPR_ORD_ID_REPROGRAMADO = 1UL << 49;
            public const ulong FPR_PRIORIDADE = 1UL << 50;
            public const ulong FPR_SEQ_INCLUSAO_FILA = 1UL << 51;
            public const ulong FPR_HIERARQUIA_SEQ_TRANSFORMACAO = 1UL << 52;
            public const ulong FPR_ID_ORIGEM = 1UL << 53;
            public const ulong FPR_DATA_ENTREGA = 1UL << 54;
            public const ulong EQU_ID = 1UL << 55;
            public const ulong FPR_GRUPO_PRODUTIVO_MANUAL = 1UL << 56;
            public const ulong FPR_EMISSAO = 1UL << 57;
            public const ulong FPR_MOTIVO_PULA_FILA = 1UL << 58;
            public const ulong OCO_ID = 1UL << 59;
            public const ulong FPR_PESO_UNITARIO = 1UL << 60;
            public const ulong FPR_M2_UNITARIO = 1UL << 61;
            public const ulong TenantID = 1UL << 62;
            public const ulong Deleted = 1UL << 63;
        }

        public partial class FilaProducaoPrevistaDecorator : IFilaProducaoPrevistaEntity
{

                        private readonly IFilaProducaoPrevistaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public FilaProducaoPrevistaDecorator(IFilaProducaoPrevistaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public FilaProducaoPrevistaDecorator(
                            IFilaProducaoPrevistaEntity inner,
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
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.ROT_PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "ROT_PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal FPR_QUANTIDADE_PREVISTA
                                    {
                                        get => _inner.FPR_QUANTIDADE_PREVISTA;
                                        set
                                        {
                                            if (_inner.FPR_QUANTIDADE_PREVISTA != value)
                                            {
                                                _inner.FPR_QUANTIDADE_PREVISTA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_QUANTIDADE_PREVISTA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_QUANTIDADE_PREVISTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.ROT_MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "ROT_MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime FPR_DATA_INICIO_PREVISTA
                                    {
                                        get => _inner.FPR_DATA_INICIO_PREVISTA;
                                        set
                                        {
                                            if (_inner.FPR_DATA_INICIO_PREVISTA != value)
                                            {
                                                _inner.FPR_DATA_INICIO_PREVISTA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_DATA_INICIO_PREVISTA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_DATA_INICIO_PREVISTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime FPR_DATA_FIM_PREVISTA
                                    {
                                        get => _inner.FPR_DATA_FIM_PREVISTA;
                                        set
                                        {
                                            if (_inner.FPR_DATA_FIM_PREVISTA != value)
                                            {
                                                _inner.FPR_DATA_FIM_PREVISTA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_DATA_FIM_PREVISTA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_DATA_FIM_PREVISTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime FPR_DATA_FIM_MAXIMA
                                    {
                                        get => _inner.FPR_DATA_FIM_MAXIMA;
                                        set
                                        {
                                            if (_inner.FPR_DATA_FIM_MAXIMA != value)
                                            {
                                                _inner.FPR_DATA_FIM_MAXIMA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_DATA_FIM_MAXIMA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_DATA_FIM_MAXIMA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int ROT_SEQ_TRANFORMACAO
                                    {
                                        get => _inner.ROT_SEQ_TRANFORMACAO;
                                        set
                                        {
                                            if (_inner.ROT_SEQ_TRANFORMACAO != value)
                                            {
                                                _inner.ROT_SEQ_TRANFORMACAO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.ROT_SEQ_TRANFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "ROT_SEQ_TRANFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int FPR_SEQ_REPETICAO
                                    {
                                        get => _inner.FPR_SEQ_REPETICAO;
                                        set
                                        {
                                            if (_inner.FPR_SEQ_REPETICAO != value)
                                            {
                                                _inner.FPR_SEQ_REPETICAO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_OBS_PRODUCAO
                                    {
                                        get => _inner.FPR_OBS_PRODUCAO;
                                        set
                                        {
                                            if (_inner.FPR_OBS_PRODUCAO != value)
                                            {
                                                _inner.FPR_OBS_PRODUCAO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_OBS_PRODUCAO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_OBS_PRODUCAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_STATUS
                                    {
                                        get => _inner.FPR_STATUS;
                                        set
                                        {
                                            if (_inner.FPR_STATUS != value)
                                            {
                                                _inner.FPR_STATUS = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_TEMPO_DECORRIDO_SETUP
                                    {
                                        get => _inner.FPR_TEMPO_DECORRIDO_SETUP;
                                        set
                                        {
                                            if (_inner.FPR_TEMPO_DECORRIDO_SETUP != value)
                                            {
                                                _inner.FPR_TEMPO_DECORRIDO_SETUP = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_TEMPO_DECORRIDO_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_TEMPO_DECORRIDO_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_TEMPO_DECORRIDO_SETUPA
                                    {
                                        get => _inner.FPR_TEMPO_DECORRIDO_SETUPA;
                                        set
                                        {
                                            if (_inner.FPR_TEMPO_DECORRIDO_SETUPA != value)
                                            {
                                                _inner.FPR_TEMPO_DECORRIDO_SETUPA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_TEMPO_DECORRIDO_SETUPA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_TEMPO_DECORRIDO_SETUPA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_TEMPO_DECORRIDO_PERFORMANC
                                    {
                                        get => _inner.FPR_TEMPO_DECORRIDO_PERFORMANC;
                                        set
                                        {
                                            if (_inner.FPR_TEMPO_DECORRIDO_PERFORMANC != value)
                                            {
                                                _inner.FPR_TEMPO_DECORRIDO_PERFORMANC = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_TEMPO_DECORRIDO_PERFORMANC) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_TEMPO_DECORRIDO_PERFORMANC", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_TEMPO_DECO_PEQUENA_PARADA
                                    {
                                        get => _inner.FPR_TEMPO_DECO_PEQUENA_PARADA;
                                        set
                                        {
                                            if (_inner.FPR_TEMPO_DECO_PEQUENA_PARADA != value)
                                            {
                                                _inner.FPR_TEMPO_DECO_PEQUENA_PARADA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_TEMPO_DECO_PEQUENA_PARADA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_TEMPO_DECO_PEQUENA_PARADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_QTD_PERFORMANCE
                                    {
                                        get => _inner.FPR_QTD_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.FPR_QTD_PERFORMANCE != value)
                                            {
                                                _inner.FPR_QTD_PERFORMANCE = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_QTD_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_QTD_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_QTD_SETUP
                                    {
                                        get => _inner.FPR_QTD_SETUP;
                                        set
                                        {
                                            if (_inner.FPR_QTD_SETUP != value)
                                            {
                                                _inner.FPR_QTD_SETUP = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_QTD_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_QTD_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_QTD_PRODUZIDA
                                    {
                                        get => _inner.FPR_QTD_PRODUZIDA;
                                        set
                                        {
                                            if (_inner.FPR_QTD_PRODUZIDA != value)
                                            {
                                                _inner.FPR_QTD_PRODUZIDA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_QTD_PRODUZIDA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_QTD_PRODUZIDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_TEMPO_TEORICO_PERFORMANCE
                                    {
                                        get => _inner.FPR_TEMPO_TEORICO_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.FPR_TEMPO_TEORICO_PERFORMANCE != value)
                                            {
                                                _inner.FPR_TEMPO_TEORICO_PERFORMANCE = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_TEMPO_TEORICO_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_TEMPO_TEORICO_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_TEMPO_RESTANTE_PERFORMANC
                                    {
                                        get => _inner.FPR_TEMPO_RESTANTE_PERFORMANC;
                                        set
                                        {
                                            if (_inner.FPR_TEMPO_RESTANTE_PERFORMANC != value)
                                            {
                                                _inner.FPR_TEMPO_RESTANTE_PERFORMANC = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_TEMPO_RESTANTE_PERFORMANC) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_TEMPO_RESTANTE_PERFORMANC", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_VELOCIDADE_P_ATINGIR_META
                                    {
                                        get => _inner.FPR_VELOCIDADE_P_ATINGIR_META;
                                        set
                                        {
                                            if (_inner.FPR_VELOCIDADE_P_ATINGIR_META != value)
                                            {
                                                _inner.FPR_VELOCIDADE_P_ATINGIR_META = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_VELOCIDADE_P_ATINGIR_META) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_VELOCIDADE_P_ATINGIR_META", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_QTD_RESTANTE
                                    {
                                        get => _inner.FPR_QTD_RESTANTE;
                                        set
                                        {
                                            if (_inner.FPR_QTD_RESTANTE != value)
                                            {
                                                _inner.FPR_QTD_RESTANTE = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_QTD_RESTANTE) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_QTD_RESTANTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_VELO_ATU_PC_SEGUNDO
                                    {
                                        get => _inner.FPR_VELO_ATU_PC_SEGUNDO;
                                        set
                                        {
                                            if (_inner.FPR_VELO_ATU_PC_SEGUNDO != value)
                                            {
                                                _inner.FPR_VELO_ATU_PC_SEGUNDO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_VELO_ATU_PC_SEGUNDO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_VELO_ATU_PC_SEGUNDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_PERFORMANCE_PROJETADA
                                    {
                                        get => _inner.FPR_PERFORMANCE_PROJETADA;
                                        set
                                        {
                                            if (_inner.FPR_PERFORMANCE_PROJETADA != value)
                                            {
                                                _inner.FPR_PERFORMANCE_PROJETADA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_PERFORMANCE_PROJETADA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_PERFORMANCE_PROJETADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_TEMPO_RESTANTE_TOTAL
                                    {
                                        get => _inner.FPR_TEMPO_RESTANTE_TOTAL;
                                        set
                                        {
                                            if (_inner.FPR_TEMPO_RESTANTE_TOTAL != value)
                                            {
                                                _inner.FPR_TEMPO_RESTANTE_TOTAL = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_TEMPO_RESTANTE_TOTAL) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_TEMPO_RESTANTE_TOTAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_FIM_PREVISTO_ATUAL
                                    {
                                        get => _inner.FPR_FIM_PREVISTO_ATUAL;
                                        set
                                        {
                                            if (_inner.FPR_FIM_PREVISTO_ATUAL != value)
                                            {
                                                _inner.FPR_FIM_PREVISTO_ATUAL = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_FIM_PREVISTO_ATUAL) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_FIM_PREVISTO_ATUAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_PRODUZINDO
                                    {
                                        get => _inner.FPR_PRODUZINDO;
                                        set
                                        {
                                            if (_inner.FPR_PRODUZINDO != value)
                                            {
                                                _inner.FPR_PRODUZINDO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_PRODUZINDO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_PRODUZINDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_ORDEM_NA_FILA
                                    {
                                        get => _inner.FPR_ORDEM_NA_FILA;
                                        set
                                        {
                                            if (_inner.FPR_ORDEM_NA_FILA != value)
                                            {
                                                _inner.FPR_ORDEM_NA_FILA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_ORDEM_NA_FILA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_ORDEM_NA_FILA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_ID_INTEGRACAO
                                    {
                                        get => _inner.FPR_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.FPR_ID_INTEGRACAO != value)
                                            {
                                                _inner.FPR_ID_INTEGRACAO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_TRUNCADO
                                    {
                                        get => _inner.FPR_TRUNCADO;
                                        set
                                        {
                                            if (_inner.FPR_TRUNCADO != value)
                                            {
                                                _inner.FPR_TRUNCADO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_TRUNCADO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_TRUNCADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_DATA_TRUNC_INI
                                    {
                                        get => _inner.FPR_DATA_TRUNC_INI;
                                        set
                                        {
                                            if (_inner.FPR_DATA_TRUNC_INI != value)
                                            {
                                                _inner.FPR_DATA_TRUNC_INI = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_DATA_TRUNC_INI) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_DATA_TRUNC_INI", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_DATA_TRUNC_FIM
                                    {
                                        get => _inner.FPR_DATA_TRUNC_FIM;
                                        set
                                        {
                                            if (_inner.FPR_DATA_TRUNC_FIM != value)
                                            {
                                                _inner.FPR_DATA_TRUNC_FIM = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_DATA_TRUNC_FIM) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_DATA_TRUNC_FIM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int FPR_ID
                                    {
                                        get => _inner.FPR_ID;
                                        set
                                        {
                                            if (_inner.FPR_ID != value)
                                            {
                                                _inner.FPR_ID = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_ID) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_COR_FILA
                                    {
                                        get => _inner.FPR_COR_FILA;
                                        set
                                        {
                                            if (_inner.FPR_COR_FILA != value)
                                            {
                                                _inner.FPR_COR_FILA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_COR_FILA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_COR_FILA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID_MANUAL
                                    {
                                        get => _inner.MAQ_ID_MANUAL;
                                        set
                                        {
                                            if (_inner.MAQ_ID_MANUAL != value)
                                            {
                                                _inner.MAQ_ID_MANUAL = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.MAQ_ID_MANUAL) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "MAQ_ID_MANUAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID_RESTRINGIDA
                                    {
                                        get => _inner.MAQ_ID_RESTRINGIDA;
                                        set
                                        {
                                            if (_inner.MAQ_ID_RESTRINGIDA != value)
                                            {
                                                _inner.MAQ_ID_RESTRINGIDA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.MAQ_ID_RESTRINGIDA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "MAQ_ID_RESTRINGIDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime FPR_PREVISAO_MATERIA_PRIMA
                                    {
                                        get => _inner.FPR_PREVISAO_MATERIA_PRIMA;
                                        set
                                        {
                                            if (_inner.FPR_PREVISAO_MATERIA_PRIMA != value)
                                            {
                                                _inner.FPR_PREVISAO_MATERIA_PRIMA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_PREVISAO_MATERIA_PRIMA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_PREVISAO_MATERIA_PRIMA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_DATA_NECESSIDADE_INICIO_PRODUCAO
                                    {
                                        get => _inner.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO;
                                        set
                                        {
                                            if (_inner.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO != value)
                                            {
                                                _inner.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_DATA_NECESSIDADE_INICIO_PRODUCAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_DATA_NECESSIDADE_FIM_PRODUCAO
                                    {
                                        get => _inner.FPR_DATA_NECESSIDADE_FIM_PRODUCAO;
                                        set
                                        {
                                            if (_inner.FPR_DATA_NECESSIDADE_FIM_PRODUCAO != value)
                                            {
                                                _inner.FPR_DATA_NECESSIDADE_FIM_PRODUCAO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_DATA_NECESSIDADE_FIM_PRODUCAO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_DATA_NECESSIDADE_FIM_PRODUCAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_GRUPO_PRODUTIVO
                                    {
                                        get => _inner.FPR_GRUPO_PRODUTIVO;
                                        set
                                        {
                                            if (_inner.FPR_GRUPO_PRODUTIVO != value)
                                            {
                                                _inner.FPR_GRUPO_PRODUTIVO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_GRUPO_PRODUTIVO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_GRUPO_PRODUTIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_INICIO_GRUPO_PRODUTIVO
                                    {
                                        get => _inner.FPR_INICIO_GRUPO_PRODUTIVO;
                                        set
                                        {
                                            if (_inner.FPR_INICIO_GRUPO_PRODUTIVO != value)
                                            {
                                                _inner.FPR_INICIO_GRUPO_PRODUTIVO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_INICIO_GRUPO_PRODUTIVO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_INICIO_GRUPO_PRODUTIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_FIM_GRUPO_PRODUTIVO
                                    {
                                        get => _inner.FPR_FIM_GRUPO_PRODUTIVO;
                                        set
                                        {
                                            if (_inner.FPR_FIM_GRUPO_PRODUTIVO != value)
                                            {
                                                _inner.FPR_FIM_GRUPO_PRODUTIVO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_FIM_GRUPO_PRODUTIVO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_FIM_GRUPO_PRODUTIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_COR_BICO1
                                    {
                                        get => _inner.FPR_COR_BICO1;
                                        set
                                        {
                                            if (_inner.FPR_COR_BICO1 != value)
                                            {
                                                _inner.FPR_COR_BICO1 = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_COR_BICO1) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_COR_BICO1", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_COR_BICO2
                                    {
                                        get => _inner.FPR_COR_BICO2;
                                        set
                                        {
                                            if (_inner.FPR_COR_BICO2 != value)
                                            {
                                                _inner.FPR_COR_BICO2 = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_COR_BICO2) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_COR_BICO2", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_COR_BICO3
                                    {
                                        get => _inner.FPR_COR_BICO3;
                                        set
                                        {
                                            if (_inner.FPR_COR_BICO3 != value)
                                            {
                                                _inner.FPR_COR_BICO3 = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_COR_BICO3) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_COR_BICO3", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_COR_BICO4
                                    {
                                        get => _inner.FPR_COR_BICO4;
                                        set
                                        {
                                            if (_inner.FPR_COR_BICO4 != value)
                                            {
                                                _inner.FPR_COR_BICO4 = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_COR_BICO4) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_COR_BICO4", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_COR_BICO5
                                    {
                                        get => _inner.FPR_COR_BICO5;
                                        set
                                        {
                                            if (_inner.FPR_COR_BICO5 != value)
                                            {
                                                _inner.FPR_COR_BICO5 = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_COR_BICO5) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_COR_BICO5", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_META_SETUP
                                    {
                                        get => _inner.FPR_META_SETUP;
                                        set
                                        {
                                            if (_inner.FPR_META_SETUP != value)
                                            {
                                                _inner.FPR_META_SETUP = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_META_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_META_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_ORD_ID_REPROGRAMADO
                                    {
                                        get => _inner.FPR_ORD_ID_REPROGRAMADO;
                                        set
                                        {
                                            if (_inner.FPR_ORD_ID_REPROGRAMADO != value)
                                            {
                                                _inner.FPR_ORD_ID_REPROGRAMADO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_ORD_ID_REPROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_ORD_ID_REPROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_PRIORIDADE
                                    {
                                        get => _inner.FPR_PRIORIDADE;
                                        set
                                        {
                                            if (_inner.FPR_PRIORIDADE != value)
                                            {
                                                _inner.FPR_PRIORIDADE = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_PRIORIDADE) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_PRIORIDADE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_SEQ_INCLUSAO_FILA
                                    {
                                        get => _inner.FPR_SEQ_INCLUSAO_FILA;
                                        set
                                        {
                                            if (_inner.FPR_SEQ_INCLUSAO_FILA != value)
                                            {
                                                _inner.FPR_SEQ_INCLUSAO_FILA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_SEQ_INCLUSAO_FILA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_SEQ_INCLUSAO_FILA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_HIERARQUIA_SEQ_TRANSFORMACAO
                                    {
                                        get => _inner.FPR_HIERARQUIA_SEQ_TRANSFORMACAO;
                                        set
                                        {
                                            if (_inner.FPR_HIERARQUIA_SEQ_TRANSFORMACAO != value)
                                            {
                                                _inner.FPR_HIERARQUIA_SEQ_TRANSFORMACAO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_HIERARQUIA_SEQ_TRANSFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_HIERARQUIA_SEQ_TRANSFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_ID_ORIGEM
                                    {
                                        get => _inner.FPR_ID_ORIGEM;
                                        set
                                        {
                                            if (_inner.FPR_ID_ORIGEM != value)
                                            {
                                                _inner.FPR_ID_ORIGEM = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_ID_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_ID_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_DATA_ENTREGA
                                    {
                                        get => _inner.FPR_DATA_ENTREGA;
                                        set
                                        {
                                            if (_inner.FPR_DATA_ENTREGA != value)
                                            {
                                                _inner.FPR_DATA_ENTREGA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_DATA_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_DATA_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EQU_ID
                                    {
                                        get => _inner.EQU_ID;
                                        set
                                        {
                                            if (_inner.EQU_ID != value)
                                            {
                                                _inner.EQU_ID = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.EQU_ID) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "EQU_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FPR_GRUPO_PRODUTIVO_MANUAL
                                    {
                                        get => _inner.FPR_GRUPO_PRODUTIVO_MANUAL;
                                        set
                                        {
                                            if (_inner.FPR_GRUPO_PRODUTIVO_MANUAL != value)
                                            {
                                                _inner.FPR_GRUPO_PRODUTIVO_MANUAL = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_GRUPO_PRODUTIVO_MANUAL) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_GRUPO_PRODUTIVO_MANUAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FPR_EMISSAO
                                    {
                                        get => _inner.FPR_EMISSAO;
                                        set
                                        {
                                            if (_inner.FPR_EMISSAO != value)
                                            {
                                                _inner.FPR_EMISSAO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_MOTIVO_PULA_FILA
                                    {
                                        get => _inner.FPR_MOTIVO_PULA_FILA;
                                        set
                                        {
                                            if (_inner.FPR_MOTIVO_PULA_FILA != value)
                                            {
                                                _inner.FPR_MOTIVO_PULA_FILA = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_MOTIVO_PULA_FILA) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_MOTIVO_PULA_FILA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OCO_ID
                                    {
                                        get => _inner.OCO_ID;
                                        set
                                        {
                                            if (_inner.OCO_ID != value)
                                            {
                                                _inner.OCO_ID = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.OCO_ID) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "OCO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_PESO_UNITARIO
                                    {
                                        get => _inner.FPR_PESO_UNITARIO;
                                        set
                                        {
                                            if (_inner.FPR_PESO_UNITARIO != value)
                                            {
                                                _inner.FPR_PESO_UNITARIO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_PESO_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_PESO_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FPR_M2_UNITARIO
                                    {
                                        get => _inner.FPR_M2_UNITARIO;
                                        set
                                        {
                                            if (_inner.FPR_M2_UNITARIO != value)
                                            {
                                                _inner.FPR_M2_UNITARIO = value;
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.FPR_M2_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "FPR_M2_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FilaProducaoPrevistaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("FilaProducaoPrevista", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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

                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration