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
                    public static class GrupoProdutoAbstratoTrackingFields
        {
            public const ulong GRP_ID = 1UL << 0;
            public const ulong GRP_DESCRICAO = 1UL << 1;
            public const ulong TEM_ID = 1UL << 2;
            public const ulong GRP_TIPO = 1UL << 3;
            public const ulong GRP_PAP_ONDA = 1UL << 4;
            public const ulong GRP_PAP_GRAMATURA = 1UL << 5;
            public const ulong GRP_PAP_ALTURA = 1UL << 6;
            public const ulong GRP_PAP_NOME_COMERCIAL = 1UL << 7;
            public const ulong GRP_ATIVO = 1UL << 8;
            public const ulong GRP_DT_CRIACAO = 1UL << 9;
            public const ulong GRP_PAPEL1 = 1UL << 10;
            public const ulong GRP_PAPEL2 = 1UL << 11;
            public const ulong GRP_PAPEL3 = 1UL << 12;
            public const ulong GRP_PAPEL4 = 1UL << 13;
            public const ulong GRP_PAPEL5 = 1UL << 14;
            public const ulong GRP_ID_INTEGRACAO = 1UL << 15;
            public const ulong GRP_ID_INTEGRACAO_ERP = 1UL << 16;
            public const ulong GRP_TYPE = 1UL << 17;
            public const ulong GRP_PERFORMANCE = 1UL << 18;
            public const ulong GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = 1UL << 19;
            public const ulong GRP_RESINA = 1UL << 20;
            public const ulong GRP_ENDURECEDOR_MIOLO = 1UL << 21;
            public const ulong VIN_ID = 1UL << 22;
            public const ulong GRP_COLUNA_DE = 1UL << 23;
            public const ulong GRP_COLUNA_ATE = 1UL << 24;
            public const ulong GRP_CRUSH = 1UL << 25;
            public const ulong GRP_ID_FAMILIA = 1UL << 26;
            public const ulong GRP_REFILE_LARGURA = 1UL << 27;
            public const ulong GRP_REFILE_COMPRIMENTO = 1UL << 28;
            public const ulong GRP_TIPO_LAP = 1UL << 29;
            public const ulong GRP_LAP_PROLONGADO = 1UL << 30;
            public const ulong GRP_TAMANHO_LAP_OND_SIMPLES = 1UL << 31;
            public const ulong GRP_TAMANHO_LAP_OND_DUPLA = 1UL << 32;
            public const ulong GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = 1UL << 33;
            public const ulong GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = 1UL << 34;
            public const ulong GRP_FEFCO = 1UL << 35;
            public const ulong GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = 1UL << 36;
            public const ulong GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = 1UL << 37;
            public const ulong GRP_PREFIXO_ID_PRODUTO = 1UL << 38;
            public const ulong GRP_COLUNA_CAIXA = 1UL << 39;
            public const ulong GRP_COLUNA_CHAPA = 1UL << 40;
            public const ulong GRP_MULLEN = 1UL << 41;
            public const ulong GRP_TENDENCIA_TOLERANCIA_PEDIDO = 1UL << 42;
            public const ulong GRP_PERCENTUAL_PERDA_MEDIA = 1UL << 43;
            public const ulong GRP_FILTRA_SEQ_TRANS = 1UL << 44;
            public const ulong GRP_IMG_CAIXA = 1UL << 45;
            public const ulong TenantID = 1UL << 46;
            public const ulong Deleted = 1UL << 47;
            public const ulong Changed = 1UL << 48;
            public const ulong UserId = 1UL << 49;
        }

        public partial class GrupoProdutoAbstratoDecorator : IGrupoProdutoAbstratoEntity
{

                        private readonly IGrupoProdutoAbstratoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public GrupoProdutoAbstratoDecorator(IGrupoProdutoAbstratoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public GrupoProdutoAbstratoDecorator(
                            IGrupoProdutoAbstratoEntity inner,
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
                                    public string GRP_ID
                                    {
                                        get => _inner.GRP_ID;
                                        set
                                        {
                                            if (_inner.GRP_ID != value)
                                            {
                                                _inner.GRP_ID = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_ID) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_DESCRICAO
                                    {
                                        get => _inner.GRP_DESCRICAO;
                                        set
                                        {
                                            if (_inner.GRP_DESCRICAO != value)
                                            {
                                                _inner.GRP_DESCRICAO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.TEM_ID) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "TEM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_TIPO
                                    {
                                        get => _inner.GRP_TIPO;
                                        set
                                        {
                                            if (_inner.GRP_TIPO != value)
                                            {
                                                _inner.GRP_TIPO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_PAP_ONDA
                                    {
                                        get => _inner.GRP_PAP_ONDA;
                                        set
                                        {
                                            if (_inner.GRP_PAP_ONDA != value)
                                            {
                                                _inner.GRP_PAP_ONDA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAP_ONDA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAP_ONDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_PAP_GRAMATURA
                                    {
                                        get => _inner.GRP_PAP_GRAMATURA;
                                        set
                                        {
                                            if (_inner.GRP_PAP_GRAMATURA != value)
                                            {
                                                _inner.GRP_PAP_GRAMATURA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAP_GRAMATURA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAP_GRAMATURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_PAP_ALTURA
                                    {
                                        get => _inner.GRP_PAP_ALTURA;
                                        set
                                        {
                                            if (_inner.GRP_PAP_ALTURA != value)
                                            {
                                                _inner.GRP_PAP_ALTURA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAP_ALTURA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAP_ALTURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_PAP_NOME_COMERCIAL
                                    {
                                        get => _inner.GRP_PAP_NOME_COMERCIAL;
                                        set
                                        {
                                            if (_inner.GRP_PAP_NOME_COMERCIAL != value)
                                            {
                                                _inner.GRP_PAP_NOME_COMERCIAL = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAP_NOME_COMERCIAL) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAP_NOME_COMERCIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_ATIVO
                                    {
                                        get => _inner.GRP_ATIVO;
                                        set
                                        {
                                            if (_inner.GRP_ATIVO != value)
                                            {
                                                _inner.GRP_ATIVO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_ATIVO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_ATIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? GRP_DT_CRIACAO
                                    {
                                        get => _inner.GRP_DT_CRIACAO;
                                        set
                                        {
                                            if (_inner.GRP_DT_CRIACAO != value)
                                            {
                                                _inner.GRP_DT_CRIACAO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_DT_CRIACAO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_DT_CRIACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_PAPEL1
                                    {
                                        get => _inner.GRP_PAPEL1;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL1 != value)
                                            {
                                                _inner.GRP_PAPEL1 = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAPEL1) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAPEL1", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_PAPEL2
                                    {
                                        get => _inner.GRP_PAPEL2;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL2 != value)
                                            {
                                                _inner.GRP_PAPEL2 = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAPEL2) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAPEL2", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_PAPEL3
                                    {
                                        get => _inner.GRP_PAPEL3;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL3 != value)
                                            {
                                                _inner.GRP_PAPEL3 = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAPEL3) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAPEL3", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_PAPEL4
                                    {
                                        get => _inner.GRP_PAPEL4;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL4 != value)
                                            {
                                                _inner.GRP_PAPEL4 = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAPEL4) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAPEL4", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_PAPEL5
                                    {
                                        get => _inner.GRP_PAPEL5;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL5 != value)
                                            {
                                                _inner.GRP_PAPEL5 = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PAPEL5) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PAPEL5", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_ID_INTEGRACAO
                                    {
                                        get => _inner.GRP_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.GRP_ID_INTEGRACAO != value)
                                            {
                                                _inner.GRP_ID_INTEGRACAO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_ID_INTEGRACAO_ERP
                                    {
                                        get => _inner.GRP_ID_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.GRP_ID_INTEGRACAO_ERP != value)
                                            {
                                                _inner.GRP_ID_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_ID_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_ID_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? GRP_TYPE
                                    {
                                        get => _inner.GRP_TYPE;
                                        set
                                        {
                                            if (_inner.GRP_TYPE != value)
                                            {
                                                _inner.GRP_TYPE = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TYPE) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TYPE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_PERFORMANCE
                                    {
                                        get => _inner.GRP_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.GRP_PERFORMANCE != value)
                                            {
                                                _inner.GRP_PERFORMANCE = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO
                                    {
                                        get => _inner.GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO;
                                        set
                                        {
                                            if (_inner.GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO != value)
                                            {
                                                _inner.GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_RESINA
                                    {
                                        get => _inner.GRP_RESINA;
                                        set
                                        {
                                            if (_inner.GRP_RESINA != value)
                                            {
                                                _inner.GRP_RESINA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_RESINA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_RESINA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_ENDURECEDOR_MIOLO
                                    {
                                        get => _inner.GRP_ENDURECEDOR_MIOLO;
                                        set
                                        {
                                            if (_inner.GRP_ENDURECEDOR_MIOLO != value)
                                            {
                                                _inner.GRP_ENDURECEDOR_MIOLO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_ENDURECEDOR_MIOLO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_ENDURECEDOR_MIOLO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.VIN_ID) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "VIN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_COLUNA_DE
                                    {
                                        get => _inner.GRP_COLUNA_DE;
                                        set
                                        {
                                            if (_inner.GRP_COLUNA_DE != value)
                                            {
                                                _inner.GRP_COLUNA_DE = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_COLUNA_DE) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_COLUNA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_COLUNA_ATE
                                    {
                                        get => _inner.GRP_COLUNA_ATE;
                                        set
                                        {
                                            if (_inner.GRP_COLUNA_ATE != value)
                                            {
                                                _inner.GRP_COLUNA_ATE = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_COLUNA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_COLUNA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_CRUSH
                                    {
                                        get => _inner.GRP_CRUSH;
                                        set
                                        {
                                            if (_inner.GRP_CRUSH != value)
                                            {
                                                _inner.GRP_CRUSH = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_CRUSH) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_CRUSH", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_ID_FAMILIA
                                    {
                                        get => _inner.GRP_ID_FAMILIA;
                                        set
                                        {
                                            if (_inner.GRP_ID_FAMILIA != value)
                                            {
                                                _inner.GRP_ID_FAMILIA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_ID_FAMILIA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_ID_FAMILIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_REFILE_LARGURA
                                    {
                                        get => _inner.GRP_REFILE_LARGURA;
                                        set
                                        {
                                            if (_inner.GRP_REFILE_LARGURA != value)
                                            {
                                                _inner.GRP_REFILE_LARGURA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_REFILE_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_REFILE_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_REFILE_COMPRIMENTO
                                    {
                                        get => _inner.GRP_REFILE_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.GRP_REFILE_COMPRIMENTO != value)
                                            {
                                                _inner.GRP_REFILE_COMPRIMENTO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_REFILE_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_REFILE_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_TIPO_LAP
                                    {
                                        get => _inner.GRP_TIPO_LAP;
                                        set
                                        {
                                            if (_inner.GRP_TIPO_LAP != value)
                                            {
                                                _inner.GRP_TIPO_LAP = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TIPO_LAP) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TIPO_LAP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_LAP_PROLONGADO
                                    {
                                        get => _inner.GRP_LAP_PROLONGADO;
                                        set
                                        {
                                            if (_inner.GRP_LAP_PROLONGADO != value)
                                            {
                                                _inner.GRP_LAP_PROLONGADO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_LAP_PROLONGADO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_LAP_PROLONGADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_TAMANHO_LAP_OND_SIMPLES
                                    {
                                        get => _inner.GRP_TAMANHO_LAP_OND_SIMPLES;
                                        set
                                        {
                                            if (_inner.GRP_TAMANHO_LAP_OND_SIMPLES != value)
                                            {
                                                _inner.GRP_TAMANHO_LAP_OND_SIMPLES = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TAMANHO_LAP_OND_SIMPLES) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TAMANHO_LAP_OND_SIMPLES", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_TAMANHO_LAP_OND_DUPLA
                                    {
                                        get => _inner.GRP_TAMANHO_LAP_OND_DUPLA;
                                        set
                                        {
                                            if (_inner.GRP_TAMANHO_LAP_OND_DUPLA != value)
                                            {
                                                _inner.GRP_TAMANHO_LAP_OND_DUPLA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TAMANHO_LAP_OND_DUPLA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TAMANHO_LAP_OND_DUPLA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES
                                    {
                                        get => _inner.GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES;
                                        set
                                        {
                                            if (_inner.GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES != value)
                                            {
                                                _inner.GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA
                                    {
                                        get => _inner.GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA;
                                        set
                                        {
                                            if (_inner.GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA != value)
                                            {
                                                _inner.GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_FEFCO
                                    {
                                        get => _inner.GRP_FEFCO;
                                        set
                                        {
                                            if (_inner.GRP_FEFCO != value)
                                            {
                                                _inner.GRP_FEFCO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_FEFCO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_FEFCO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? GRP_TOLERANCIA_DIMENCAO_CHAPA_DE
                                    {
                                        get => _inner.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE;
                                        set
                                        {
                                            if (_inner.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE != value)
                                            {
                                                _inner.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TOLERANCIA_DIMENCAO_CHAPA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE
                                    {
                                        get => _inner.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE;
                                        set
                                        {
                                            if (_inner.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE != value)
                                            {
                                                _inner.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_PREFIXO_ID_PRODUTO
                                    {
                                        get => _inner.GRP_PREFIXO_ID_PRODUTO;
                                        set
                                        {
                                            if (_inner.GRP_PREFIXO_ID_PRODUTO != value)
                                            {
                                                _inner.GRP_PREFIXO_ID_PRODUTO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PREFIXO_ID_PRODUTO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PREFIXO_ID_PRODUTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_COLUNA_CAIXA
                                    {
                                        get => _inner.GRP_COLUNA_CAIXA;
                                        set
                                        {
                                            if (_inner.GRP_COLUNA_CAIXA != value)
                                            {
                                                _inner.GRP_COLUNA_CAIXA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_COLUNA_CAIXA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_COLUNA_CAIXA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_COLUNA_CHAPA
                                    {
                                        get => _inner.GRP_COLUNA_CHAPA;
                                        set
                                        {
                                            if (_inner.GRP_COLUNA_CHAPA != value)
                                            {
                                                _inner.GRP_COLUNA_CHAPA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_COLUNA_CHAPA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_COLUNA_CHAPA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_MULLEN
                                    {
                                        get => _inner.GRP_MULLEN;
                                        set
                                        {
                                            if (_inner.GRP_MULLEN != value)
                                            {
                                                _inner.GRP_MULLEN = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_MULLEN) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_MULLEN", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? GRP_TENDENCIA_TOLERANCIA_PEDIDO
                                    {
                                        get => _inner.GRP_TENDENCIA_TOLERANCIA_PEDIDO;
                                        set
                                        {
                                            if (_inner.GRP_TENDENCIA_TOLERANCIA_PEDIDO != value)
                                            {
                                                _inner.GRP_TENDENCIA_TOLERANCIA_PEDIDO = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_TENDENCIA_TOLERANCIA_PEDIDO) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_TENDENCIA_TOLERANCIA_PEDIDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRP_PERCENTUAL_PERDA_MEDIA
                                    {
                                        get => _inner.GRP_PERCENTUAL_PERDA_MEDIA;
                                        set
                                        {
                                            if (_inner.GRP_PERCENTUAL_PERDA_MEDIA != value)
                                            {
                                                _inner.GRP_PERCENTUAL_PERDA_MEDIA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_PERCENTUAL_PERDA_MEDIA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_PERCENTUAL_PERDA_MEDIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? GRP_FILTRA_SEQ_TRANS
                                    {
                                        get => _inner.GRP_FILTRA_SEQ_TRANS;
                                        set
                                        {
                                            if (_inner.GRP_FILTRA_SEQ_TRANS != value)
                                            {
                                                _inner.GRP_FILTRA_SEQ_TRANS = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_FILTRA_SEQ_TRANS) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_FILTRA_SEQ_TRANS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_IMG_CAIXA
                                    {
                                        get => _inner.GRP_IMG_CAIXA;
                                        set
                                        {
                                            if (_inner.GRP_IMG_CAIXA != value)
                                            {
                                                _inner.GRP_IMG_CAIXA = value;
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.GRP_IMG_CAIXA) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "GRP_IMG_CAIXA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & GrupoProdutoAbstratoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("GrupoProdutoAbstrato", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration