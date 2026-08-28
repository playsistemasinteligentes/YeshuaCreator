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
                    public static class ProdutoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Descricao = 1UL << 1;
            public const ulong Status = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
            public const ulong PRO_ESTOQUE_ATUAL = 1UL << 7;
            public const ulong UNI_ID = 1UL << 8;
            public const ulong PRO_FARDOS_POR_CAMADA = 1UL << 9;
            public const ulong PRO_CAMADAS_POR_PALETE = 1UL << 10;
            public const ulong PRO_TIPO_IDENTIFICACAO = 1UL << 11;
            public const ulong PRO_GRUPO_PALETIZACAO = 1UL << 12;
            public const ulong PRO_PECAS_POR_FARDO = 1UL << 13;
            public const ulong PRO_ID_INTEGRACAO = 1UL << 14;
            public const ulong PRO_ID_INTEGRACAO_ERP = 1UL << 15;
            public const ulong GRP_ID = 1UL << 16;
            public const ulong TEM_ID = 1UL << 17;
            public const ulong PRO_LARGURA_PECA = 1UL << 18;
            public const ulong PRO_COMPRIMENTO_PECA = 1UL << 19;
            public const ulong PRO_ALTURA_PECA = 1UL << 20;
            public const ulong PRO_LARGURA_EMBALADA = 1UL << 21;
            public const ulong PRO_COMPRIMENTO_EMBALADA = 1UL << 22;
            public const ulong PRO_ALTURA_EMBALADA = 1UL << 23;
            public const ulong PRO_FRENTE = 1UL << 24;
            public const ulong PRO_ROTACIONA_COMPRIMENTO = 1UL << 25;
            public const ulong PRO_ROTACIONA_LARGURA = 1UL << 26;
            public const ulong PRO_ROTACIONA_ALTURA = 1UL << 27;
            public const ulong PRO_ESCALA_COR = 1UL << 28;
            public const ulong PRO_SUB_ESCALA_COR = 1UL << 29;
            public const ulong PRO_CUSTO_SUBIDA_ESCALA_COR = 1UL << 30;
            public const ulong PRO_CUSTO_DECIDA_ESCALA_COR = 1UL << 31;
            public const ulong TMP_TIPO_CARGA = 1UL << 32;
            public const ulong PRO_TEMPO_CARREGAMENTO_UNITARIO = 1UL << 33;
            public const ulong PRO_TEMPO_DESCARREGAMENTO_UNITARIO = 1UL << 34;
            public const ulong PRO_PERCENTUAL_JANELA_EMBARQUE = 1UL << 35;
            public const ulong PRO_TEMPO_PRODUCAO_CONJUNTO = 1UL << 36;
            public const ulong PRO_PECAS_DA_PECA = 1UL << 37;
            public const ulong PRO_TYPE = 1UL << 38;
            public const ulong PRO_COLOR_HEXA = 1UL << 39;
            public const ulong PRO_VINCOS_LARGURA = 1UL << 40;
            public const ulong PRO_VINCOS_COMPRIMENTO = 1UL << 41;
            public const ulong PRO_LARGURA_INTERNA = 1UL << 42;
            public const ulong PRO_COMPRIMENTO_INTERNA = 1UL << 43;
            public const ulong PRO_ALTURA_INTERNA = 1UL << 44;
            public const ulong PRO_COD_DESENHO = 1UL << 45;
            public const ulong PRO_FECHAMENTO = 1UL << 46;
            public const ulong PRO_TIPO_LAP = 1UL << 47;
            public const ulong PRO_TAMANHO_LAP = 1UL << 48;
            public const ulong PRO_LAP_PROLONGADO = 1UL << 49;
            public const ulong PRO_TAMANHO_LAP_PROLONG = 1UL << 50;
            public const ulong PRO_ARRANJO_LARGURA = 1UL << 51;
            public const ulong PRO_ARRANJO_COMPRIMENTO = 1UL << 52;
            public const ulong PRO_FITILHOS_FARDO_LARG = 1UL << 53;
            public const ulong PRO_FITILHOS_FARDO_COMP = 1UL << 54;
            public const ulong PRO_FITILHOS_PALETE_LARG = 1UL << 55;
            public const ulong PRO_FITILHOS_PALETE_COMP = 1UL << 56;
            public const ulong PRO_FILME_PALETE = 1UL << 57;
            public const ulong PRO_QTD_ESPELHO = 1UL << 58;
            public const ulong PRO_CUSTO = 1UL << 59;
            public const ulong PRO_AREA_LIQUIDA = 1UL << 60;
            public const ulong PRO_PESO = 1UL << 61;
            public const ulong PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = 1UL << 62;
            public const ulong PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = 1UL << 63;
        }

        public partial class ProdutoDecorator : IProdutoEntity
{

                        private readonly IProdutoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ProdutoDecorator(IProdutoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ProdutoDecorator(
                            IProdutoEntity inner,
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
                                    public string Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & ProdutoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _inner.Descricao = value;
                                                if ((_trackingMask & ProdutoTrackingFields.Descricao) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "Descricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & ProdutoTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProdutoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProdutoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProdutoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProdutoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_ESTOQUE_ATUAL
                                    {
                                        get => _inner.PRO_ESTOQUE_ATUAL;
                                        set
                                        {
                                            if (_inner.PRO_ESTOQUE_ATUAL != value)
                                            {
                                                _inner.PRO_ESTOQUE_ATUAL = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ESTOQUE_ATUAL) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ESTOQUE_ATUAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProdutoTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_FARDOS_POR_CAMADA
                                    {
                                        get => _inner.PRO_FARDOS_POR_CAMADA;
                                        set
                                        {
                                            if (_inner.PRO_FARDOS_POR_CAMADA != value)
                                            {
                                                _inner.PRO_FARDOS_POR_CAMADA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_FARDOS_POR_CAMADA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_FARDOS_POR_CAMADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_CAMADAS_POR_PALETE
                                    {
                                        get => _inner.PRO_CAMADAS_POR_PALETE;
                                        set
                                        {
                                            if (_inner.PRO_CAMADAS_POR_PALETE != value)
                                            {
                                                _inner.PRO_CAMADAS_POR_PALETE = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_CAMADAS_POR_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_CAMADAS_POR_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_TIPO_IDENTIFICACAO
                                    {
                                        get => _inner.PRO_TIPO_IDENTIFICACAO;
                                        set
                                        {
                                            if (_inner.PRO_TIPO_IDENTIFICACAO != value)
                                            {
                                                _inner.PRO_TIPO_IDENTIFICACAO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TIPO_IDENTIFICACAO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TIPO_IDENTIFICACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_GRUPO_PALETIZACAO
                                    {
                                        get => _inner.PRO_GRUPO_PALETIZACAO;
                                        set
                                        {
                                            if (_inner.PRO_GRUPO_PALETIZACAO != value)
                                            {
                                                _inner.PRO_GRUPO_PALETIZACAO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_GRUPO_PALETIZACAO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_GRUPO_PALETIZACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_PECAS_POR_FARDO
                                    {
                                        get => _inner.PRO_PECAS_POR_FARDO;
                                        set
                                        {
                                            if (_inner.PRO_PECAS_POR_FARDO != value)
                                            {
                                                _inner.PRO_PECAS_POR_FARDO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_PECAS_POR_FARDO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_PECAS_POR_FARDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID_INTEGRACAO
                                    {
                                        get => _inner.PRO_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.PRO_ID_INTEGRACAO != value)
                                            {
                                                _inner.PRO_ID_INTEGRACAO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID_INTEGRACAO_ERP
                                    {
                                        get => _inner.PRO_ID_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.PRO_ID_INTEGRACAO_ERP != value)
                                            {
                                                _inner.PRO_ID_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ID_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ID_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProdutoTrackingFields.GRP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "GRP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TEM_ID
                                    {
                                        get => _inner.TEM_ID;
                                        set
                                        {
                                            if (_inner.TEM_ID != value)
                                            {
                                                _inner.TEM_ID = value;
                                                if ((_trackingMask & ProdutoTrackingFields.TEM_ID) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "TEM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_LARGURA_PECA
                                    {
                                        get => _inner.PRO_LARGURA_PECA;
                                        set
                                        {
                                            if (_inner.PRO_LARGURA_PECA != value)
                                            {
                                                _inner.PRO_LARGURA_PECA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_LARGURA_PECA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_LARGURA_PECA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_COMPRIMENTO_PECA
                                    {
                                        get => _inner.PRO_COMPRIMENTO_PECA;
                                        set
                                        {
                                            if (_inner.PRO_COMPRIMENTO_PECA != value)
                                            {
                                                _inner.PRO_COMPRIMENTO_PECA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_COMPRIMENTO_PECA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_COMPRIMENTO_PECA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_ALTURA_PECA
                                    {
                                        get => _inner.PRO_ALTURA_PECA;
                                        set
                                        {
                                            if (_inner.PRO_ALTURA_PECA != value)
                                            {
                                                _inner.PRO_ALTURA_PECA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ALTURA_PECA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ALTURA_PECA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_LARGURA_EMBALADA
                                    {
                                        get => _inner.PRO_LARGURA_EMBALADA;
                                        set
                                        {
                                            if (_inner.PRO_LARGURA_EMBALADA != value)
                                            {
                                                _inner.PRO_LARGURA_EMBALADA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_LARGURA_EMBALADA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_LARGURA_EMBALADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_COMPRIMENTO_EMBALADA
                                    {
                                        get => _inner.PRO_COMPRIMENTO_EMBALADA;
                                        set
                                        {
                                            if (_inner.PRO_COMPRIMENTO_EMBALADA != value)
                                            {
                                                _inner.PRO_COMPRIMENTO_EMBALADA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_COMPRIMENTO_EMBALADA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_COMPRIMENTO_EMBALADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_ALTURA_EMBALADA
                                    {
                                        get => _inner.PRO_ALTURA_EMBALADA;
                                        set
                                        {
                                            if (_inner.PRO_ALTURA_EMBALADA != value)
                                            {
                                                _inner.PRO_ALTURA_EMBALADA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ALTURA_EMBALADA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ALTURA_EMBALADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_FRENTE
                                    {
                                        get => _inner.PRO_FRENTE;
                                        set
                                        {
                                            if (_inner.PRO_FRENTE != value)
                                            {
                                                _inner.PRO_FRENTE = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_FRENTE) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_FRENTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ROTACIONA_COMPRIMENTO
                                    {
                                        get => _inner.PRO_ROTACIONA_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.PRO_ROTACIONA_COMPRIMENTO != value)
                                            {
                                                _inner.PRO_ROTACIONA_COMPRIMENTO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ROTACIONA_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ROTACIONA_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ROTACIONA_LARGURA
                                    {
                                        get => _inner.PRO_ROTACIONA_LARGURA;
                                        set
                                        {
                                            if (_inner.PRO_ROTACIONA_LARGURA != value)
                                            {
                                                _inner.PRO_ROTACIONA_LARGURA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ROTACIONA_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ROTACIONA_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ROTACIONA_ALTURA
                                    {
                                        get => _inner.PRO_ROTACIONA_ALTURA;
                                        set
                                        {
                                            if (_inner.PRO_ROTACIONA_ALTURA != value)
                                            {
                                                _inner.PRO_ROTACIONA_ALTURA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ROTACIONA_ALTURA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ROTACIONA_ALTURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ESCALA_COR
                                    {
                                        get => _inner.PRO_ESCALA_COR;
                                        set
                                        {
                                            if (_inner.PRO_ESCALA_COR != value)
                                            {
                                                _inner.PRO_ESCALA_COR = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ESCALA_COR) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ESCALA_COR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_SUB_ESCALA_COR
                                    {
                                        get => _inner.PRO_SUB_ESCALA_COR;
                                        set
                                        {
                                            if (_inner.PRO_SUB_ESCALA_COR != value)
                                            {
                                                _inner.PRO_SUB_ESCALA_COR = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_SUB_ESCALA_COR) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_SUB_ESCALA_COR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_CUSTO_SUBIDA_ESCALA_COR
                                    {
                                        get => _inner.PRO_CUSTO_SUBIDA_ESCALA_COR;
                                        set
                                        {
                                            if (_inner.PRO_CUSTO_SUBIDA_ESCALA_COR != value)
                                            {
                                                _inner.PRO_CUSTO_SUBIDA_ESCALA_COR = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_CUSTO_SUBIDA_ESCALA_COR) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_CUSTO_SUBIDA_ESCALA_COR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_CUSTO_DECIDA_ESCALA_COR
                                    {
                                        get => _inner.PRO_CUSTO_DECIDA_ESCALA_COR;
                                        set
                                        {
                                            if (_inner.PRO_CUSTO_DECIDA_ESCALA_COR != value)
                                            {
                                                _inner.PRO_CUSTO_DECIDA_ESCALA_COR = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_CUSTO_DECIDA_ESCALA_COR) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_CUSTO_DECIDA_ESCALA_COR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TMP_TIPO_CARGA
                                    {
                                        get => _inner.TMP_TIPO_CARGA;
                                        set
                                        {
                                            if (_inner.TMP_TIPO_CARGA != value)
                                            {
                                                _inner.TMP_TIPO_CARGA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.TMP_TIPO_CARGA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "TMP_TIPO_CARGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_TEMPO_CARREGAMENTO_UNITARIO
                                    {
                                        get => _inner.PRO_TEMPO_CARREGAMENTO_UNITARIO;
                                        set
                                        {
                                            if (_inner.PRO_TEMPO_CARREGAMENTO_UNITARIO != value)
                                            {
                                                _inner.PRO_TEMPO_CARREGAMENTO_UNITARIO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TEMPO_CARREGAMENTO_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TEMPO_CARREGAMENTO_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_TEMPO_DESCARREGAMENTO_UNITARIO
                                    {
                                        get => _inner.PRO_TEMPO_DESCARREGAMENTO_UNITARIO;
                                        set
                                        {
                                            if (_inner.PRO_TEMPO_DESCARREGAMENTO_UNITARIO != value)
                                            {
                                                _inner.PRO_TEMPO_DESCARREGAMENTO_UNITARIO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TEMPO_DESCARREGAMENTO_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TEMPO_DESCARREGAMENTO_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_PERCENTUAL_JANELA_EMBARQUE
                                    {
                                        get => _inner.PRO_PERCENTUAL_JANELA_EMBARQUE;
                                        set
                                        {
                                            if (_inner.PRO_PERCENTUAL_JANELA_EMBARQUE != value)
                                            {
                                                _inner.PRO_PERCENTUAL_JANELA_EMBARQUE = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_PERCENTUAL_JANELA_EMBARQUE) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_PERCENTUAL_JANELA_EMBARQUE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_TEMPO_PRODUCAO_CONJUNTO
                                    {
                                        get => _inner.PRO_TEMPO_PRODUCAO_CONJUNTO;
                                        set
                                        {
                                            if (_inner.PRO_TEMPO_PRODUCAO_CONJUNTO != value)
                                            {
                                                _inner.PRO_TEMPO_PRODUCAO_CONJUNTO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TEMPO_PRODUCAO_CONJUNTO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TEMPO_PRODUCAO_CONJUNTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_PECAS_DA_PECA
                                    {
                                        get => _inner.PRO_PECAS_DA_PECA;
                                        set
                                        {
                                            if (_inner.PRO_PECAS_DA_PECA != value)
                                            {
                                                _inner.PRO_PECAS_DA_PECA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_PECAS_DA_PECA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_PECAS_DA_PECA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_TYPE
                                    {
                                        get => _inner.PRO_TYPE;
                                        set
                                        {
                                            if (_inner.PRO_TYPE != value)
                                            {
                                                _inner.PRO_TYPE = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TYPE) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TYPE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_COLOR_HEXA
                                    {
                                        get => _inner.PRO_COLOR_HEXA;
                                        set
                                        {
                                            if (_inner.PRO_COLOR_HEXA != value)
                                            {
                                                _inner.PRO_COLOR_HEXA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_COLOR_HEXA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_COLOR_HEXA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_VINCOS_LARGURA
                                    {
                                        get => _inner.PRO_VINCOS_LARGURA;
                                        set
                                        {
                                            if (_inner.PRO_VINCOS_LARGURA != value)
                                            {
                                                _inner.PRO_VINCOS_LARGURA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_VINCOS_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_VINCOS_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_VINCOS_COMPRIMENTO
                                    {
                                        get => _inner.PRO_VINCOS_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.PRO_VINCOS_COMPRIMENTO != value)
                                            {
                                                _inner.PRO_VINCOS_COMPRIMENTO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_VINCOS_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_VINCOS_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_LARGURA_INTERNA
                                    {
                                        get => _inner.PRO_LARGURA_INTERNA;
                                        set
                                        {
                                            if (_inner.PRO_LARGURA_INTERNA != value)
                                            {
                                                _inner.PRO_LARGURA_INTERNA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_LARGURA_INTERNA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_LARGURA_INTERNA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_COMPRIMENTO_INTERNA
                                    {
                                        get => _inner.PRO_COMPRIMENTO_INTERNA;
                                        set
                                        {
                                            if (_inner.PRO_COMPRIMENTO_INTERNA != value)
                                            {
                                                _inner.PRO_COMPRIMENTO_INTERNA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_COMPRIMENTO_INTERNA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_COMPRIMENTO_INTERNA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_ALTURA_INTERNA
                                    {
                                        get => _inner.PRO_ALTURA_INTERNA;
                                        set
                                        {
                                            if (_inner.PRO_ALTURA_INTERNA != value)
                                            {
                                                _inner.PRO_ALTURA_INTERNA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ALTURA_INTERNA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ALTURA_INTERNA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_COD_DESENHO
                                    {
                                        get => _inner.PRO_COD_DESENHO;
                                        set
                                        {
                                            if (_inner.PRO_COD_DESENHO != value)
                                            {
                                                _inner.PRO_COD_DESENHO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_COD_DESENHO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_COD_DESENHO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_FECHAMENTO
                                    {
                                        get => _inner.PRO_FECHAMENTO;
                                        set
                                        {
                                            if (_inner.PRO_FECHAMENTO != value)
                                            {
                                                _inner.PRO_FECHAMENTO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_FECHAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_FECHAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_TIPO_LAP
                                    {
                                        get => _inner.PRO_TIPO_LAP;
                                        set
                                        {
                                            if (_inner.PRO_TIPO_LAP != value)
                                            {
                                                _inner.PRO_TIPO_LAP = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TIPO_LAP) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TIPO_LAP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_TAMANHO_LAP
                                    {
                                        get => _inner.PRO_TAMANHO_LAP;
                                        set
                                        {
                                            if (_inner.PRO_TAMANHO_LAP != value)
                                            {
                                                _inner.PRO_TAMANHO_LAP = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TAMANHO_LAP) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TAMANHO_LAP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_LAP_PROLONGADO
                                    {
                                        get => _inner.PRO_LAP_PROLONGADO;
                                        set
                                        {
                                            if (_inner.PRO_LAP_PROLONGADO != value)
                                            {
                                                _inner.PRO_LAP_PROLONGADO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_LAP_PROLONGADO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_LAP_PROLONGADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_TAMANHO_LAP_PROLONG
                                    {
                                        get => _inner.PRO_TAMANHO_LAP_PROLONG;
                                        set
                                        {
                                            if (_inner.PRO_TAMANHO_LAP_PROLONG != value)
                                            {
                                                _inner.PRO_TAMANHO_LAP_PROLONG = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TAMANHO_LAP_PROLONG) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TAMANHO_LAP_PROLONG", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_ARRANJO_LARGURA
                                    {
                                        get => _inner.PRO_ARRANJO_LARGURA;
                                        set
                                        {
                                            if (_inner.PRO_ARRANJO_LARGURA != value)
                                            {
                                                _inner.PRO_ARRANJO_LARGURA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ARRANJO_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ARRANJO_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_ARRANJO_COMPRIMENTO
                                    {
                                        get => _inner.PRO_ARRANJO_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.PRO_ARRANJO_COMPRIMENTO != value)
                                            {
                                                _inner.PRO_ARRANJO_COMPRIMENTO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_ARRANJO_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_ARRANJO_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_FITILHOS_FARDO_LARG
                                    {
                                        get => _inner.PRO_FITILHOS_FARDO_LARG;
                                        set
                                        {
                                            if (_inner.PRO_FITILHOS_FARDO_LARG != value)
                                            {
                                                _inner.PRO_FITILHOS_FARDO_LARG = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_FITILHOS_FARDO_LARG) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_FITILHOS_FARDO_LARG", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_FITILHOS_FARDO_COMP
                                    {
                                        get => _inner.PRO_FITILHOS_FARDO_COMP;
                                        set
                                        {
                                            if (_inner.PRO_FITILHOS_FARDO_COMP != value)
                                            {
                                                _inner.PRO_FITILHOS_FARDO_COMP = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_FITILHOS_FARDO_COMP) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_FITILHOS_FARDO_COMP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_FITILHOS_PALETE_LARG
                                    {
                                        get => _inner.PRO_FITILHOS_PALETE_LARG;
                                        set
                                        {
                                            if (_inner.PRO_FITILHOS_PALETE_LARG != value)
                                            {
                                                _inner.PRO_FITILHOS_PALETE_LARG = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_FITILHOS_PALETE_LARG) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_FITILHOS_PALETE_LARG", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_FITILHOS_PALETE_COMP
                                    {
                                        get => _inner.PRO_FITILHOS_PALETE_COMP;
                                        set
                                        {
                                            if (_inner.PRO_FITILHOS_PALETE_COMP != value)
                                            {
                                                _inner.PRO_FITILHOS_PALETE_COMP = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_FITILHOS_PALETE_COMP) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_FITILHOS_PALETE_COMP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_FILME_PALETE
                                    {
                                        get => _inner.PRO_FILME_PALETE;
                                        set
                                        {
                                            if (_inner.PRO_FILME_PALETE != value)
                                            {
                                                _inner.PRO_FILME_PALETE = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_FILME_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_FILME_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_QTD_ESPELHO
                                    {
                                        get => _inner.PRO_QTD_ESPELHO;
                                        set
                                        {
                                            if (_inner.PRO_QTD_ESPELHO != value)
                                            {
                                                _inner.PRO_QTD_ESPELHO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_QTD_ESPELHO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_QTD_ESPELHO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_CUSTO
                                    {
                                        get => _inner.PRO_CUSTO;
                                        set
                                        {
                                            if (_inner.PRO_CUSTO != value)
                                            {
                                                _inner.PRO_CUSTO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_CUSTO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_CUSTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_AREA_LIQUIDA
                                    {
                                        get => _inner.PRO_AREA_LIQUIDA;
                                        set
                                        {
                                            if (_inner.PRO_AREA_LIQUIDA != value)
                                            {
                                                _inner.PRO_AREA_LIQUIDA = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_AREA_LIQUIDA) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_AREA_LIQUIDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_PESO
                                    {
                                        get => _inner.PRO_PESO;
                                        set
                                        {
                                            if (_inner.PRO_PESO != value)
                                            {
                                                _inner.PRO_PESO = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_PESO) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_PESO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_TOLERANCIA_DIMENSAO_CHAPA_DE
                                    {
                                        get => _inner.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE;
                                        set
                                        {
                                            if (_inner.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE != value)
                                            {
                                                _inner.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TOLERANCIA_DIMENSAO_CHAPA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE
                                    {
                                        get => _inner.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE;
                                        set
                                        {
                                            if (_inner.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE != value)
                                            {
                                                _inner.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = value;
                                                if ((_trackingMask & ProdutoTrackingFields.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Produto", "PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_IMG_LASTRO
                                    {
                                        get => _inner.PRO_IMG_LASTRO;
                                        set
                                        {
                                            if (_inner.PRO_IMG_LASTRO != value)
                                            {
                                                _inner.PRO_IMG_LASTRO = value;

                                            }
                                        }
                                    }

                                    public string ABN_ID
                                    {
                                        get => _inner.ABN_ID;
                                        set
                                        {
                                            if (_inner.ABN_ID != value)
                                            {
                                                _inner.ABN_ID = value;

                                            }
                                        }
                                    }

                                    public int? SEG_ID
                                    {
                                        get => _inner.SEG_ID;
                                        set
                                        {
                                            if (_inner.SEG_ID != value)
                                            {
                                                _inner.SEG_ID = value;

                                            }
                                        }
                                    }

                                    public string PRO_RESINA
                                    {
                                        get => _inner.PRO_RESINA;
                                        set
                                        {
                                            if (_inner.PRO_RESINA != value)
                                            {
                                                _inner.PRO_RESINA = value;

                                            }
                                        }
                                    }

                                    public string PRO_ENDURECEDOR_MIOLO
                                    {
                                        get => _inner.PRO_ENDURECEDOR_MIOLO;
                                        set
                                        {
                                            if (_inner.PRO_ENDURECEDOR_MIOLO != value)
                                            {
                                                _inner.PRO_ENDURECEDOR_MIOLO = value;

                                            }
                                        }
                                    }

                                    public string PRO_VINCOS_ONDULADEIRA
                                    {
                                        get => _inner.PRO_VINCOS_ONDULADEIRA;
                                        set
                                        {
                                            if (_inner.PRO_VINCOS_ONDULADEIRA != value)
                                            {
                                                _inner.PRO_VINCOS_ONDULADEIRA = value;

                                            }
                                        }
                                    }

                                    public int? PRO_ADICIONAL_ABA_SUPERIOR
                                    {
                                        get => _inner.PRO_ADICIONAL_ABA_SUPERIOR;
                                        set
                                        {
                                            if (_inner.PRO_ADICIONAL_ABA_SUPERIOR != value)
                                            {
                                                _inner.PRO_ADICIONAL_ABA_SUPERIOR = value;

                                            }
                                        }
                                    }

                                    public int? PRO_ADICIONAL_ABA_INFERIOR
                                    {
                                        get => _inner.PRO_ADICIONAL_ABA_INFERIOR;
                                        set
                                        {
                                            if (_inner.PRO_ADICIONAL_ABA_INFERIOR != value)
                                            {
                                                _inner.PRO_ADICIONAL_ABA_INFERIOR = value;

                                            }
                                        }
                                    }

                                    public string PRO_PROMOVE_RESINA
                                    {
                                        get => _inner.PRO_PROMOVE_RESINA;
                                        set
                                        {
                                            if (_inner.PRO_PROMOVE_RESINA != value)
                                            {
                                                _inner.PRO_PROMOVE_RESINA = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_PROMOVE_DE
                                    {
                                        get => _inner.PRO_PROMOVE_DE;
                                        set
                                        {
                                            if (_inner.PRO_PROMOVE_DE != value)
                                            {
                                                _inner.PRO_PROMOVE_DE = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_PROMOVE_ATE
                                    {
                                        get => _inner.PRO_PROMOVE_ATE;
                                        set
                                        {
                                            if (_inner.PRO_PROMOVE_ATE != value)
                                            {
                                                _inner.PRO_PROMOVE_ATE = value;

                                            }
                                        }
                                    }

                                    public int? PRO_PROFUNDIDADE_VINCO
                                    {
                                        get => _inner.PRO_PROFUNDIDADE_VINCO;
                                        set
                                        {
                                            if (_inner.PRO_PROFUNDIDADE_VINCO != value)
                                            {
                                                _inner.PRO_PROFUNDIDADE_VINCO = value;

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

                                            }
                                        }
                                    }

                                    public string PRO_PROMOVE_PRODUTO
                                    {
                                        get => _inner.PRO_PROMOVE_PRODUTO;
                                        set
                                        {
                                            if (_inner.PRO_PROMOVE_PRODUTO != value)
                                            {
                                                _inner.PRO_PROMOVE_PRODUTO = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_TARA
                                    {
                                        get => _inner.PRO_TARA;
                                        set
                                        {
                                            if (_inner.PRO_TARA != value)
                                            {
                                                _inner.PRO_TARA = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_COMPRESSAO
                                    {
                                        get => _inner.PRO_COMPRESSAO;
                                        set
                                        {
                                            if (_inner.PRO_COMPRESSAO != value)
                                            {
                                                _inner.PRO_COMPRESSAO = value;

                                            }
                                        }
                                    }

                                    public string PRO_COD_BARRAS_CAIXA
                                    {
                                        get => _inner.PRO_COD_BARRAS_CAIXA;
                                        set
                                        {
                                            if (_inner.PRO_COD_BARRAS_CAIXA != value)
                                            {
                                                _inner.PRO_COD_BARRAS_CAIXA = value;

                                            }
                                        }
                                    }

                                    public string CJN_ID
                                    {
                                        get => _inner.CJN_ID;
                                        set
                                        {
                                            if (_inner.CJN_ID != value)
                                            {
                                                _inner.CJN_ID = value;

                                            }
                                        }
                                    }

                                    public string PRJ_ID
                                    {
                                        get => _inner.PRJ_ID;
                                        set
                                        {
                                            if (_inner.PRJ_ID != value)
                                            {
                                                _inner.PRJ_ID = value;

                                            }
                                        }
                                    }

                                    public int? PRO_REFILE_LARGURA
                                    {
                                        get => _inner.PRO_REFILE_LARGURA;
                                        set
                                        {
                                            if (_inner.PRO_REFILE_LARGURA != value)
                                            {
                                                _inner.PRO_REFILE_LARGURA = value;

                                            }
                                        }
                                    }

                                    public int? PRO_REFILE_COMPRIMENTO
                                    {
                                        get => _inner.PRO_REFILE_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.PRO_REFILE_COMPRIMENTO != value)
                                            {
                                                _inner.PRO_REFILE_COMPRIMENTO = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_M2_PONTA
                                    {
                                        get => _inner.PRO_M2_PONTA;
                                        set
                                        {
                                            if (_inner.PRO_M2_PONTA != value)
                                            {
                                                _inner.PRO_M2_PONTA = value;

                                            }
                                        }
                                    }

                                    public int? PRO_QTD_CORTES_PECA1
                                    {
                                        get => _inner.PRO_QTD_CORTES_PECA1;
                                        set
                                        {
                                            if (_inner.PRO_QTD_CORTES_PECA1 != value)
                                            {
                                                _inner.PRO_QTD_CORTES_PECA1 = value;

                                            }
                                        }
                                    }

                                    public int? PRO_QTD_CORTES_PECA2
                                    {
                                        get => _inner.PRO_QTD_CORTES_PECA2;
                                        set
                                        {
                                            if (_inner.PRO_QTD_CORTES_PECA2 != value)
                                            {
                                                _inner.PRO_QTD_CORTES_PECA2 = value;

                                            }
                                        }
                                    }

                                    public string PRO_DIVISAO_MONTADA
                                    {
                                        get => _inner.PRO_DIVISAO_MONTADA;
                                        set
                                        {
                                            if (_inner.PRO_DIVISAO_MONTADA != value)
                                            {
                                                _inner.PRO_DIVISAO_MONTADA = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_A
                                    {
                                        get => _inner.PRO_SEGMENTO_A;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_A != value)
                                            {
                                                _inner.PRO_SEGMENTO_A = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_B
                                    {
                                        get => _inner.PRO_SEGMENTO_B;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_B != value)
                                            {
                                                _inner.PRO_SEGMENTO_B = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_C
                                    {
                                        get => _inner.PRO_SEGMENTO_C;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_C != value)
                                            {
                                                _inner.PRO_SEGMENTO_C = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_D
                                    {
                                        get => _inner.PRO_SEGMENTO_D;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_D != value)
                                            {
                                                _inner.PRO_SEGMENTO_D = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_E
                                    {
                                        get => _inner.PRO_SEGMENTO_E;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_E != value)
                                            {
                                                _inner.PRO_SEGMENTO_E = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_F
                                    {
                                        get => _inner.PRO_SEGMENTO_F;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_F != value)
                                            {
                                                _inner.PRO_SEGMENTO_F = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_G
                                    {
                                        get => _inner.PRO_SEGMENTO_G;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_G != value)
                                            {
                                                _inner.PRO_SEGMENTO_G = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_H
                                    {
                                        get => _inner.PRO_SEGMENTO_H;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_H != value)
                                            {
                                                _inner.PRO_SEGMENTO_H = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_SEGMENTO_I
                                    {
                                        get => _inner.PRO_SEGMENTO_I;
                                        set
                                        {
                                            if (_inner.PRO_SEGMENTO_I != value)
                                            {
                                                _inner.PRO_SEGMENTO_I = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_QTD_GRAMPOS
                                    {
                                        get => _inner.PRO_QTD_GRAMPOS;
                                        set
                                        {
                                            if (_inner.PRO_QTD_GRAMPOS != value)
                                            {
                                                _inner.PRO_QTD_GRAMPOS = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_AREA_REFILE_INTERNO
                                    {
                                        get => _inner.PRO_AREA_REFILE_INTERNO;
                                        set
                                        {
                                            if (_inner.PRO_AREA_REFILE_INTERNO != value)
                                            {
                                                _inner.PRO_AREA_REFILE_INTERNO = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_AREA_REFILE_EXTERNO
                                    {
                                        get => _inner.PRO_AREA_REFILE_EXTERNO;
                                        set
                                        {
                                            if (_inner.PRO_AREA_REFILE_EXTERNO != value)
                                            {
                                                _inner.PRO_AREA_REFILE_EXTERNO = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_PESO_REFILE
                                    {
                                        get => _inner.PRO_PESO_REFILE;
                                        set
                                        {
                                            if (_inner.PRO_PESO_REFILE != value)
                                            {
                                                _inner.PRO_PESO_REFILE = value;

                                            }
                                        }
                                    }

                                    public string PRO_ORELHA_INVERTIDA
                                    {
                                        get => _inner.PRO_ORELHA_INVERTIDA;
                                        set
                                        {
                                            if (_inner.PRO_ORELHA_INVERTIDA != value)
                                            {
                                                _inner.PRO_ORELHA_INVERTIDA = value;

                                            }
                                        }
                                    }

                                    public string PRO_ENDERECO
                                    {
                                        get => _inner.PRO_ENDERECO;
                                        set
                                        {
                                            if (_inner.PRO_ENDERECO != value)
                                            {
                                                _inner.PRO_ENDERECO = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_VINCULADO
                                    {
                                        get => _inner.PRO_ID_VINCULADO;
                                        set
                                        {
                                            if (_inner.PRO_ID_VINCULADO != value)
                                            {
                                                _inner.PRO_ID_VINCULADO = value;

                                            }
                                        }
                                    }

                                    public int? PRO_BATIDAS_PROXIMA_MANUTENCAO
                                    {
                                        get => _inner.PRO_BATIDAS_PROXIMA_MANUTENCAO;
                                        set
                                        {
                                            if (_inner.PRO_BATIDAS_PROXIMA_MANUTENCAO != value)
                                            {
                                                _inner.PRO_BATIDAS_PROXIMA_MANUTENCAO = value;

                                            }
                                        }
                                    }

                                    public string PRO_ENTRADA_NA_MAQUINA
                                    {
                                        get => _inner.PRO_ENTRADA_NA_MAQUINA;
                                        set
                                        {
                                            if (_inner.PRO_ENTRADA_NA_MAQUINA != value)
                                            {
                                                _inner.PRO_ENTRADA_NA_MAQUINA = value;

                                            }
                                        }
                                    }

                                    public string TDI_ID
                                    {
                                        get => _inner.TDI_ID;
                                        set
                                        {
                                            if (_inner.TDI_ID != value)
                                            {
                                                _inner.TDI_ID = value;

                                            }
                                        }
                                    }

                                    public int? PRO_QUEBRA_VINCO
                                    {
                                        get => _inner.PRO_QUEBRA_VINCO;
                                        set
                                        {
                                            if (_inner.PRO_QUEBRA_VINCO != value)
                                            {
                                                _inner.PRO_QUEBRA_VINCO = value;

                                            }
                                        }
                                    }

                                    public int? PRO_LARGURA_FARDO
                                    {
                                        get => _inner.PRO_LARGURA_FARDO;
                                        set
                                        {
                                            if (_inner.PRO_LARGURA_FARDO != value)
                                            {
                                                _inner.PRO_LARGURA_FARDO = value;

                                            }
                                        }
                                    }

                                    public int? PRO_COMPRIMENTO_FARDO
                                    {
                                        get => _inner.PRO_COMPRIMENTO_FARDO;
                                        set
                                        {
                                            if (_inner.PRO_COMPRIMENTO_FARDO != value)
                                            {
                                                _inner.PRO_COMPRIMENTO_FARDO = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_ALTURA_FARDO
                                    {
                                        get => _inner.PRO_ALTURA_FARDO;
                                        set
                                        {
                                            if (_inner.PRO_ALTURA_FARDO != value)
                                            {
                                                _inner.PRO_ALTURA_FARDO = value;

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

                                            }
                                        }
                                    }

                                    public string PRO_CLASSE_CUSTO_01
                                    {
                                        get => _inner.PRO_CLASSE_CUSTO_01;
                                        set
                                        {
                                            if (_inner.PRO_CLASSE_CUSTO_01 != value)
                                            {
                                                _inner.PRO_CLASSE_CUSTO_01 = value;

                                            }
                                        }
                                    }

                                    public string PRO_OBS_ALTERACAO
                                    {
                                        get => _inner.PRO_OBS_ALTERACAO;
                                        set
                                        {
                                            if (_inner.PRO_OBS_ALTERACAO != value)
                                            {
                                                _inner.PRO_OBS_ALTERACAO = value;

                                            }
                                        }
                                    }

                                    public int? TIP_ID
                                    {
                                        get => _inner.TIP_ID;
                                        set
                                        {
                                            if (_inner.TIP_ID != value)
                                            {
                                                _inner.TIP_ID = value;

                                            }
                                        }
                                    }

                                    public Decimal? PRO_PECAS_POR_VEICULO
                                    {
                                        get => _inner.PRO_PECAS_POR_VEICULO;
                                        set
                                        {
                                            if (_inner.PRO_PECAS_POR_VEICULO != value)
                                            {
                                                _inner.PRO_PECAS_POR_VEICULO = value;

                                            }
                                        }
                                    }

                                    public int? PRO_DISTANCIA_ENTRE_VINCOS
                                    {
                                        get => _inner.PRO_DISTANCIA_ENTRE_VINCOS;
                                        set
                                        {
                                            if (_inner.PRO_DISTANCIA_ENTRE_VINCOS != value)
                                            {
                                                _inner.PRO_DISTANCIA_ENTRE_VINCOS = value;

                                            }
                                        }
                                    }

                                    public int? PRO_DISTANCIA_ENTRE_VINCOS2
                                    {
                                        get => _inner.PRO_DISTANCIA_ENTRE_VINCOS2;
                                        set
                                        {
                                            if (_inner.PRO_DISTANCIA_ENTRE_VINCOS2 != value)
                                            {
                                                _inner.PRO_DISTANCIA_ENTRE_VINCOS2 = value;

                                            }
                                        }
                                    }

                                    public int? PRO_DISTANCIA_ENTRE_VINCOS3
                                    {
                                        get => _inner.PRO_DISTANCIA_ENTRE_VINCOS3;
                                        set
                                        {
                                            if (_inner.PRO_DISTANCIA_ENTRE_VINCOS3 != value)
                                            {
                                                _inner.PRO_DISTANCIA_ENTRE_VINCOS3 = value;

                                            }
                                        }
                                    }

                                    public int? PRO_OUT
                                    {
                                        get => _inner.PRO_OUT;
                                        set
                                        {
                                            if (_inner.PRO_OUT != value)
                                            {
                                                _inner.PRO_OUT = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_FACA
                                    {
                                        get => _inner.PRO_ID_FACA;
                                        set
                                        {
                                            if (_inner.PRO_ID_FACA != value)
                                            {
                                                _inner.PRO_ID_FACA = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_CLICHE
                                    {
                                        get => _inner.PRO_ID_CLICHE;
                                        set
                                        {
                                            if (_inner.PRO_ID_CLICHE != value)
                                            {
                                                _inner.PRO_ID_CLICHE = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_TINTA_01
                                    {
                                        get => _inner.PRO_ID_TINTA_01;
                                        set
                                        {
                                            if (_inner.PRO_ID_TINTA_01 != value)
                                            {
                                                _inner.PRO_ID_TINTA_01 = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_TINTA_02
                                    {
                                        get => _inner.PRO_ID_TINTA_02;
                                        set
                                        {
                                            if (_inner.PRO_ID_TINTA_02 != value)
                                            {
                                                _inner.PRO_ID_TINTA_02 = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_TINTA_03
                                    {
                                        get => _inner.PRO_ID_TINTA_03;
                                        set
                                        {
                                            if (_inner.PRO_ID_TINTA_03 != value)
                                            {
                                                _inner.PRO_ID_TINTA_03 = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_TINTA_04
                                    {
                                        get => _inner.PRO_ID_TINTA_04;
                                        set
                                        {
                                            if (_inner.PRO_ID_TINTA_04 != value)
                                            {
                                                _inner.PRO_ID_TINTA_04 = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_TINTA_05
                                    {
                                        get => _inner.PRO_ID_TINTA_05;
                                        set
                                        {
                                            if (_inner.PRO_ID_TINTA_05 != value)
                                            {
                                                _inner.PRO_ID_TINTA_05 = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_FORROSUP
                                    {
                                        get => _inner.PRO_ID_FORROSUP;
                                        set
                                        {
                                            if (_inner.PRO_ID_FORROSUP != value)
                                            {
                                                _inner.PRO_ID_FORROSUP = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_CANTONEIRA
                                    {
                                        get => _inner.PRO_ID_CANTONEIRA;
                                        set
                                        {
                                            if (_inner.PRO_ID_CANTONEIRA != value)
                                            {
                                                _inner.PRO_ID_CANTONEIRA = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_PALETE
                                    {
                                        get => _inner.PRO_ID_PALETE;
                                        set
                                        {
                                            if (_inner.PRO_ID_PALETE != value)
                                            {
                                                _inner.PRO_ID_PALETE = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_TAMPO
                                    {
                                        get => _inner.PRO_ID_TAMPO;
                                        set
                                        {
                                            if (_inner.PRO_ID_TAMPO != value)
                                            {
                                                _inner.PRO_ID_TAMPO = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_FORROINF
                                    {
                                        get => _inner.PRO_ID_FORROINF;
                                        set
                                        {
                                            if (_inner.PRO_ID_FORROINF != value)
                                            {
                                                _inner.PRO_ID_FORROINF = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_CHAPA
                                    {
                                        get => _inner.PRO_ID_CHAPA;
                                        set
                                        {
                                            if (_inner.PRO_ID_CHAPA != value)
                                            {
                                                _inner.PRO_ID_CHAPA = value;

                                            }
                                        }
                                    }

                                    public string PRO_ID_COMPOSICAO
                                    {
                                        get => _inner.PRO_ID_COMPOSICAO;
                                        set
                                        {
                                            if (_inner.PRO_ID_COMPOSICAO != value)
                                            {
                                                _inner.PRO_ID_COMPOSICAO = value;

                                            }
                                        }
                                    }

                                    public int? PRO_QUEBRA_VINCO_MAIOR
                                    {
                                        get => _inner.PRO_QUEBRA_VINCO_MAIOR;
                                        set
                                        {
                                            if (_inner.PRO_QUEBRA_VINCO_MAIOR != value)
                                            {
                                                _inner.PRO_QUEBRA_VINCO_MAIOR = value;

                                            }
                                        }
                                    }

                                    public int? PRO_QUEBRA_VINCO_MENOR
                                    {
                                        get => _inner.PRO_QUEBRA_VINCO_MENOR;
                                        set
                                        {
                                            if (_inner.PRO_QUEBRA_VINCO_MENOR != value)
                                            {
                                                _inner.PRO_QUEBRA_VINCO_MENOR = value;

                                            }
                                        }
                                    }

                                    public string CLI_ID
                                    {
                                        get => _inner.CLI_ID;
                                        set
                                        {
                                            if (_inner.CLI_ID != value)
                                            {
                                                _inner.CLI_ID = value;

                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration