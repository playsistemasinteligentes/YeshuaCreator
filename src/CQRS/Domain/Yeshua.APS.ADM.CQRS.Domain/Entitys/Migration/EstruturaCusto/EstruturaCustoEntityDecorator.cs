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
                    public static class EstruturaCustoTrackingFields
        {
            public const ulong EST_ID = 1UL << 0;
            public const ulong ITO_ID = 1UL << 1;
            public const ulong ORD_ID = 1UL << 2;
            public const ulong PRO_ID = 1UL << 3;
            public const ulong PRO_ID_PRODUTO = 1UL << 4;
            public const ulong PRO_ID_COMPONENTE = 1UL << 5;
            public const ulong PRO_TIPO_CUSTO = 1UL << 6;
            public const ulong PRO_GRUPO_CONTABIL = 1UL << 7;
            public const ulong EST_ORDEM = 1UL << 8;
            public const ulong EST_GRUPO = 1UL << 9;
            public const ulong EST_QUANT = 1UL << 10;
            public const ulong EST_VALOR_TOTAL = 1UL << 11;
            public const ulong EST_DATA_BASE = 1UL << 12;
            public const ulong EST_BASE_PRODUCAO = 1UL << 13;
            public const ulong EST_NIVEL = 1UL << 14;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 15;
            public const ulong TenantID = 1UL << 16;
            public const ulong Deleted = 1UL << 17;
            public const ulong Changed = 1UL << 18;
            public const ulong UserId = 1UL << 19;
        }

        public partial class EstruturaCustoDecorator : IEstruturaCustoEntity
{

                        private readonly IEstruturaCustoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public EstruturaCustoDecorator(IEstruturaCustoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public EstruturaCustoDecorator(
                            IEstruturaCustoEntity inner,
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
                                    public int EST_ID
                                    {
                                        get => _inner.EST_ID;
                                        set
                                        {
                                            if (_inner.EST_ID != value)
                                            {
                                                _inner.EST_ID = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.EST_ID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "EST_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ITO_ID
                                    {
                                        get => _inner.ITO_ID;
                                        set
                                        {
                                            if (_inner.ITO_ID != value)
                                            {
                                                _inner.ITO_ID = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.ITO_ID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "ITO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstruturaCustoTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstruturaCustoTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID_PRODUTO
                                    {
                                        get => _inner.PRO_ID_PRODUTO;
                                        set
                                        {
                                            if (_inner.PRO_ID_PRODUTO != value)
                                            {
                                                _inner.PRO_ID_PRODUTO = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.PRO_ID_PRODUTO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "PRO_ID_PRODUTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID_COMPONENTE
                                    {
                                        get => _inner.PRO_ID_COMPONENTE;
                                        set
                                        {
                                            if (_inner.PRO_ID_COMPONENTE != value)
                                            {
                                                _inner.PRO_ID_COMPONENTE = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.PRO_ID_COMPONENTE) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "PRO_ID_COMPONENTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_TIPO_CUSTO
                                    {
                                        get => _inner.PRO_TIPO_CUSTO;
                                        set
                                        {
                                            if (_inner.PRO_TIPO_CUSTO != value)
                                            {
                                                _inner.PRO_TIPO_CUSTO = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.PRO_TIPO_CUSTO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "PRO_TIPO_CUSTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_GRUPO_CONTABIL
                                    {
                                        get => _inner.PRO_GRUPO_CONTABIL;
                                        set
                                        {
                                            if (_inner.PRO_GRUPO_CONTABIL != value)
                                            {
                                                _inner.PRO_GRUPO_CONTABIL = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.PRO_GRUPO_CONTABIL) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "PRO_GRUPO_CONTABIL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int EST_ORDEM
                                    {
                                        get => _inner.EST_ORDEM;
                                        set
                                        {
                                            if (_inner.EST_ORDEM != value)
                                            {
                                                _inner.EST_ORDEM = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.EST_ORDEM) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "EST_ORDEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EST_GRUPO
                                    {
                                        get => _inner.EST_GRUPO;
                                        set
                                        {
                                            if (_inner.EST_GRUPO != value)
                                            {
                                                _inner.EST_GRUPO = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.EST_GRUPO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "EST_GRUPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal EST_QUANT
                                    {
                                        get => _inner.EST_QUANT;
                                        set
                                        {
                                            if (_inner.EST_QUANT != value)
                                            {
                                                _inner.EST_QUANT = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.EST_QUANT) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "EST_QUANT", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal EST_VALOR_TOTAL
                                    {
                                        get => _inner.EST_VALOR_TOTAL;
                                        set
                                        {
                                            if (_inner.EST_VALOR_TOTAL != value)
                                            {
                                                _inner.EST_VALOR_TOTAL = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.EST_VALOR_TOTAL) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "EST_VALOR_TOTAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EST_DATA_BASE
                                    {
                                        get => _inner.EST_DATA_BASE;
                                        set
                                        {
                                            if (_inner.EST_DATA_BASE != value)
                                            {
                                                _inner.EST_DATA_BASE = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.EST_DATA_BASE) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "EST_DATA_BASE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal EST_BASE_PRODUCAO
                                    {
                                        get => _inner.EST_BASE_PRODUCAO;
                                        set
                                        {
                                            if (_inner.EST_BASE_PRODUCAO != value)
                                            {
                                                _inner.EST_BASE_PRODUCAO = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.EST_BASE_PRODUCAO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "EST_BASE_PRODUCAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? EST_NIVEL
                                    {
                                        get => _inner.EST_NIVEL;
                                        set
                                        {
                                            if (_inner.EST_NIVEL != value)
                                            {
                                                _inner.EST_NIVEL = value;
                                                if ((_trackingMask & EstruturaCustoTrackingFields.EST_NIVEL) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "EST_NIVEL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstruturaCustoTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstruturaCustoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstruturaCustoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstruturaCustoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstruturaCustoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaCusto", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration