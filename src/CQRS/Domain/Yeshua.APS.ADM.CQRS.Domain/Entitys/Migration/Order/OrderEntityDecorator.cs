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
                    public static class OrderTrackingFields
        {
            public const ulong ORD_ID = 1UL << 0;
            public const ulong ORD_ID_RESERVA = 1UL << 1;
            public const ulong ORD_ID_CONJUNTO = 1UL << 2;
            public const ulong PRO_ID = 1UL << 3;
            public const ulong PRO_ID_CONJUNTO = 1UL << 4;
            public const ulong CLI_ID = 1UL << 5;
            public const ulong ORD_PRECO_UNITARIO = 1UL << 6;
            public const ulong ORD_QUANTIDADE = 1UL << 7;
            public const ulong ORD_DATA_ENTREGA_DE = 1UL << 8;
            public const ulong ORD_DATA_ENTREGA_ATE = 1UL << 9;
            public const ulong ORD_TIPO = 1UL << 10;
            public const ulong ORD_TOLERANCIA_MAIS = 1UL << 11;
            public const ulong ORD_TOLERANCIA_MENOS = 1UL << 12;
            public const ulong HASH_KEY = 1UL << 13;
            public const ulong ORD_INICIO_JANELA_EMBARQUE = 1UL << 14;
            public const ulong ORD_FIM_JANELA_EMBARQUE = 1UL << 15;
            public const ulong ORD_EMBARQUE_ALVO = 1UL << 16;
            public const ulong ORD_INICIO_GRUPO_PRODUTIVO = 1UL << 17;
            public const ulong ORD_FIM_GRUPO_PRODUTIVO = 1UL << 18;
            public const ulong ORD_PESO_UNITARIO = 1UL << 19;
            public const ulong ORD_PESO_UNITARIO_BRUTO = 1UL << 20;
            public const ulong ORD_M2_UNITARIO = 1UL << 21;
            public const ulong ORD_MIT = 1UL << 22;
            public const ulong CAR_TIPO_CARREGAMENTO = 1UL << 23;
            public const ulong ORD_STATUS = 1UL << 24;
            public const ulong ORD_TIPO_FRETE = 1UL << 25;
            public const ulong ORD_ENDERECO_ENTREGA = 1UL << 26;
            public const ulong ORD_BAIRRO_ENTREGA = 1UL << 27;
            public const ulong UF_ID_ENTREGA = 1UL << 28;
            public const ulong ORD_CEP_ENTREGA = 1UL << 29;
            public const ulong MUN_ID_ENTREGA = 1UL << 30;
            public const ulong ORD_REGIAO_ENTREGA = 1UL << 31;
            public const ulong ORD_LARGURA = 1UL << 32;
            public const ulong ORD_COMPRIMENTO = 1UL << 33;
            public const ulong ORD_GRAMATURA = 1UL << 34;
            public const ulong GRP_ID = 1UL << 35;
            public const ulong ORD_ID_INTEGRACAO = 1UL << 36;
            public const ulong ORD_OBSERVACAO_OTIMIZADOR = 1UL << 37;
            public const ulong ORD_COR_FILA = 1UL << 38;
            public const ulong ORD_PED_CLI = 1UL << 39;
            public const ulong ORD_OP_INTEGRACAO = 1UL << 40;
            public const ulong ORD_LOTE_PILOTO = 1UL << 41;
            public const ulong ORD_PRIORIDADE = 1UL << 42;
            public const ulong ORD_EMISSAO = 1UL << 43;
            public const ulong REP_ID = 1UL << 44;
            public const ulong ORD_RESINA = 1UL << 45;
            public const ulong ORD_ENDURECEDOR_MIOLO = 1UL << 46;
            public const ulong PRO_ID_INTEGRACAO_ERP = 1UL << 47;
            public const ulong ORD_VINCOS_ONDULADEIRA = 1UL << 48;
            public const ulong ORD_ERP_CUSTOS_FIXOS = 1UL << 49;
            public const ulong ORD_ERP_CUSTOS_VARIAVEIS = 1UL << 50;
            public const ulong ORD_ERP_DESPESAS_VAR_VENDA = 1UL << 51;
            public const ulong ORD_ERP_IMPOSTOS = 1UL << 52;
            public const ulong ORD_STATUS_PLANEJAMENTO = 1UL << 53;
            public const ulong ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = 1UL << 54;
            public const ulong ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = 1UL << 55;
            public const ulong ORD_PROMOVE_DE = 1UL << 56;
            public const ulong ORD_PROMOVE_ATE = 1UL << 57;
            public const ulong ORD_TRAVA_COMPOSICAO = 1UL << 58;
            public const ulong ORD_TRAVA_RESINA = 1UL << 59;
            public const ulong ORD_PROMOVE_RESINA = 1UL << 60;
            public const ulong ORD_LATITUDE_ENTREGA = 1UL << 61;
            public const ulong ORD_LONGITUDE_ENTREGA = 1UL << 62;
            public const ulong OCO_ID_CANCELAMENTO = 1UL << 63;
        }

        public partial class OrderDecorator : IOrderEntity
{

                        private readonly IOrderEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OrderDecorator(IOrderEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OrderDecorator(
                            IOrderEntity inner,
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
                                    public string ORD_ID
                                    {
                                        get => _inner.ORD_ID;
                                        set
                                        {
                                            if (_inner.ORD_ID != value)
                                            {
                                                _inner.ORD_ID = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ID_RESERVA
                                    {
                                        get => _inner.ORD_ID_RESERVA;
                                        set
                                        {
                                            if (_inner.ORD_ID_RESERVA != value)
                                            {
                                                _inner.ORD_ID_RESERVA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ID_RESERVA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ID_RESERVA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ID_CONJUNTO
                                    {
                                        get => _inner.ORD_ID_CONJUNTO;
                                        set
                                        {
                                            if (_inner.ORD_ID_CONJUNTO != value)
                                            {
                                                _inner.ORD_ID_CONJUNTO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ID_CONJUNTO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ID_CONJUNTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("Order", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID_CONJUNTO
                                    {
                                        get => _inner.PRO_ID_CONJUNTO;
                                        set
                                        {
                                            if (_inner.PRO_ID_CONJUNTO != value)
                                            {
                                                _inner.PRO_ID_CONJUNTO = value;
                                                if ((_trackingMask & OrderTrackingFields.PRO_ID_CONJUNTO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "PRO_ID_CONJUNTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Order", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_PRECO_UNITARIO
                                    {
                                        get => _inner.ORD_PRECO_UNITARIO;
                                        set
                                        {
                                            if (_inner.ORD_PRECO_UNITARIO != value)
                                            {
                                                _inner.ORD_PRECO_UNITARIO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_PRECO_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_PRECO_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal ORD_QUANTIDADE
                                    {
                                        get => _inner.ORD_QUANTIDADE;
                                        set
                                        {
                                            if (_inner.ORD_QUANTIDADE != value)
                                            {
                                                _inner.ORD_QUANTIDADE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_QUANTIDADE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_QUANTIDADE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime ORD_DATA_ENTREGA_DE
                                    {
                                        get => _inner.ORD_DATA_ENTREGA_DE;
                                        set
                                        {
                                            if (_inner.ORD_DATA_ENTREGA_DE != value)
                                            {
                                                _inner.ORD_DATA_ENTREGA_DE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_DATA_ENTREGA_DE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_DATA_ENTREGA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime ORD_DATA_ENTREGA_ATE
                                    {
                                        get => _inner.ORD_DATA_ENTREGA_ATE;
                                        set
                                        {
                                            if (_inner.ORD_DATA_ENTREGA_ATE != value)
                                            {
                                                _inner.ORD_DATA_ENTREGA_ATE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_DATA_ENTREGA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_DATA_ENTREGA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ORD_TIPO
                                    {
                                        get => _inner.ORD_TIPO;
                                        set
                                        {
                                            if (_inner.ORD_TIPO != value)
                                            {
                                                _inner.ORD_TIPO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_TOLERANCIA_MAIS
                                    {
                                        get => _inner.ORD_TOLERANCIA_MAIS;
                                        set
                                        {
                                            if (_inner.ORD_TOLERANCIA_MAIS != value)
                                            {
                                                _inner.ORD_TOLERANCIA_MAIS = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_TOLERANCIA_MAIS) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_TOLERANCIA_MAIS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_TOLERANCIA_MENOS
                                    {
                                        get => _inner.ORD_TOLERANCIA_MENOS;
                                        set
                                        {
                                            if (_inner.ORD_TOLERANCIA_MENOS != value)
                                            {
                                                _inner.ORD_TOLERANCIA_MENOS = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_TOLERANCIA_MENOS) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_TOLERANCIA_MENOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string HASH_KEY
                                    {
                                        get => _inner.HASH_KEY;
                                        set
                                        {
                                            if (_inner.HASH_KEY != value)
                                            {
                                                _inner.HASH_KEY = value;
                                                if ((_trackingMask & OrderTrackingFields.HASH_KEY) != 0UL)
                                                    _logger.DomainValueChanged("Order", "HASH_KEY", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ORD_INICIO_JANELA_EMBARQUE
                                    {
                                        get => _inner.ORD_INICIO_JANELA_EMBARQUE;
                                        set
                                        {
                                            if (_inner.ORD_INICIO_JANELA_EMBARQUE != value)
                                            {
                                                _inner.ORD_INICIO_JANELA_EMBARQUE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_INICIO_JANELA_EMBARQUE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_INICIO_JANELA_EMBARQUE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ORD_FIM_JANELA_EMBARQUE
                                    {
                                        get => _inner.ORD_FIM_JANELA_EMBARQUE;
                                        set
                                        {
                                            if (_inner.ORD_FIM_JANELA_EMBARQUE != value)
                                            {
                                                _inner.ORD_FIM_JANELA_EMBARQUE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_FIM_JANELA_EMBARQUE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_FIM_JANELA_EMBARQUE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ORD_EMBARQUE_ALVO
                                    {
                                        get => _inner.ORD_EMBARQUE_ALVO;
                                        set
                                        {
                                            if (_inner.ORD_EMBARQUE_ALVO != value)
                                            {
                                                _inner.ORD_EMBARQUE_ALVO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_EMBARQUE_ALVO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_EMBARQUE_ALVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ORD_INICIO_GRUPO_PRODUTIVO
                                    {
                                        get => _inner.ORD_INICIO_GRUPO_PRODUTIVO;
                                        set
                                        {
                                            if (_inner.ORD_INICIO_GRUPO_PRODUTIVO != value)
                                            {
                                                _inner.ORD_INICIO_GRUPO_PRODUTIVO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_INICIO_GRUPO_PRODUTIVO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_INICIO_GRUPO_PRODUTIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ORD_FIM_GRUPO_PRODUTIVO
                                    {
                                        get => _inner.ORD_FIM_GRUPO_PRODUTIVO;
                                        set
                                        {
                                            if (_inner.ORD_FIM_GRUPO_PRODUTIVO != value)
                                            {
                                                _inner.ORD_FIM_GRUPO_PRODUTIVO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_FIM_GRUPO_PRODUTIVO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_FIM_GRUPO_PRODUTIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_PESO_UNITARIO
                                    {
                                        get => _inner.ORD_PESO_UNITARIO;
                                        set
                                        {
                                            if (_inner.ORD_PESO_UNITARIO != value)
                                            {
                                                _inner.ORD_PESO_UNITARIO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_PESO_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_PESO_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_PESO_UNITARIO_BRUTO
                                    {
                                        get => _inner.ORD_PESO_UNITARIO_BRUTO;
                                        set
                                        {
                                            if (_inner.ORD_PESO_UNITARIO_BRUTO != value)
                                            {
                                                _inner.ORD_PESO_UNITARIO_BRUTO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_PESO_UNITARIO_BRUTO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_PESO_UNITARIO_BRUTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_M2_UNITARIO
                                    {
                                        get => _inner.ORD_M2_UNITARIO;
                                        set
                                        {
                                            if (_inner.ORD_M2_UNITARIO != value)
                                            {
                                                _inner.ORD_M2_UNITARIO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_M2_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_M2_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_MIT
                                    {
                                        get => _inner.ORD_MIT;
                                        set
                                        {
                                            if (_inner.ORD_MIT != value)
                                            {
                                                _inner.ORD_MIT = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_MIT) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_MIT", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_TIPO_CARREGAMENTO
                                    {
                                        get => _inner.CAR_TIPO_CARREGAMENTO;
                                        set
                                        {
                                            if (_inner.CAR_TIPO_CARREGAMENTO != value)
                                            {
                                                _inner.CAR_TIPO_CARREGAMENTO = value;
                                                if ((_trackingMask & OrderTrackingFields.CAR_TIPO_CARREGAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "CAR_TIPO_CARREGAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_STATUS
                                    {
                                        get => _inner.ORD_STATUS;
                                        set
                                        {
                                            if (_inner.ORD_STATUS != value)
                                            {
                                                _inner.ORD_STATUS = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_TIPO_FRETE
                                    {
                                        get => _inner.ORD_TIPO_FRETE;
                                        set
                                        {
                                            if (_inner.ORD_TIPO_FRETE != value)
                                            {
                                                _inner.ORD_TIPO_FRETE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_TIPO_FRETE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_TIPO_FRETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ENDERECO_ENTREGA
                                    {
                                        get => _inner.ORD_ENDERECO_ENTREGA;
                                        set
                                        {
                                            if (_inner.ORD_ENDERECO_ENTREGA != value)
                                            {
                                                _inner.ORD_ENDERECO_ENTREGA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ENDERECO_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ENDERECO_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_BAIRRO_ENTREGA
                                    {
                                        get => _inner.ORD_BAIRRO_ENTREGA;
                                        set
                                        {
                                            if (_inner.ORD_BAIRRO_ENTREGA != value)
                                            {
                                                _inner.ORD_BAIRRO_ENTREGA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_BAIRRO_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_BAIRRO_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UF_ID_ENTREGA
                                    {
                                        get => _inner.UF_ID_ENTREGA;
                                        set
                                        {
                                            if (_inner.UF_ID_ENTREGA != value)
                                            {
                                                _inner.UF_ID_ENTREGA = value;
                                                if ((_trackingMask & OrderTrackingFields.UF_ID_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "UF_ID_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_CEP_ENTREGA
                                    {
                                        get => _inner.ORD_CEP_ENTREGA;
                                        set
                                        {
                                            if (_inner.ORD_CEP_ENTREGA != value)
                                            {
                                                _inner.ORD_CEP_ENTREGA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_CEP_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_CEP_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MUN_ID_ENTREGA
                                    {
                                        get => _inner.MUN_ID_ENTREGA;
                                        set
                                        {
                                            if (_inner.MUN_ID_ENTREGA != value)
                                            {
                                                _inner.MUN_ID_ENTREGA = value;
                                                if ((_trackingMask & OrderTrackingFields.MUN_ID_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "MUN_ID_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_REGIAO_ENTREGA
                                    {
                                        get => _inner.ORD_REGIAO_ENTREGA;
                                        set
                                        {
                                            if (_inner.ORD_REGIAO_ENTREGA != value)
                                            {
                                                _inner.ORD_REGIAO_ENTREGA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_REGIAO_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_REGIAO_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_LARGURA
                                    {
                                        get => _inner.ORD_LARGURA;
                                        set
                                        {
                                            if (_inner.ORD_LARGURA != value)
                                            {
                                                _inner.ORD_LARGURA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_COMPRIMENTO
                                    {
                                        get => _inner.ORD_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.ORD_COMPRIMENTO != value)
                                            {
                                                _inner.ORD_COMPRIMENTO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_GRAMATURA
                                    {
                                        get => _inner.ORD_GRAMATURA;
                                        set
                                        {
                                            if (_inner.ORD_GRAMATURA != value)
                                            {
                                                _inner.ORD_GRAMATURA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_GRAMATURA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_GRAMATURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackingFields.GRP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Order", "GRP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ID_INTEGRACAO
                                    {
                                        get => _inner.ORD_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.ORD_ID_INTEGRACAO != value)
                                            {
                                                _inner.ORD_ID_INTEGRACAO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_OBSERVACAO_OTIMIZADOR
                                    {
                                        get => _inner.ORD_OBSERVACAO_OTIMIZADOR;
                                        set
                                        {
                                            if (_inner.ORD_OBSERVACAO_OTIMIZADOR != value)
                                            {
                                                _inner.ORD_OBSERVACAO_OTIMIZADOR = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_OBSERVACAO_OTIMIZADOR) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_OBSERVACAO_OTIMIZADOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_COR_FILA
                                    {
                                        get => _inner.ORD_COR_FILA;
                                        set
                                        {
                                            if (_inner.ORD_COR_FILA != value)
                                            {
                                                _inner.ORD_COR_FILA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_COR_FILA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_COR_FILA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_PED_CLI
                                    {
                                        get => _inner.ORD_PED_CLI;
                                        set
                                        {
                                            if (_inner.ORD_PED_CLI != value)
                                            {
                                                _inner.ORD_PED_CLI = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_PED_CLI) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_PED_CLI", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_OP_INTEGRACAO
                                    {
                                        get => _inner.ORD_OP_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.ORD_OP_INTEGRACAO != value)
                                            {
                                                _inner.ORD_OP_INTEGRACAO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_OP_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_OP_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_LOTE_PILOTO
                                    {
                                        get => _inner.ORD_LOTE_PILOTO;
                                        set
                                        {
                                            if (_inner.ORD_LOTE_PILOTO != value)
                                            {
                                                _inner.ORD_LOTE_PILOTO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_LOTE_PILOTO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_LOTE_PILOTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ORD_PRIORIDADE
                                    {
                                        get => _inner.ORD_PRIORIDADE;
                                        set
                                        {
                                            if (_inner.ORD_PRIORIDADE != value)
                                            {
                                                _inner.ORD_PRIORIDADE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_PRIORIDADE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_PRIORIDADE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ORD_EMISSAO
                                    {
                                        get => _inner.ORD_EMISSAO;
                                        set
                                        {
                                            if (_inner.ORD_EMISSAO != value)
                                            {
                                                _inner.ORD_EMISSAO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REP_ID
                                    {
                                        get => _inner.REP_ID;
                                        set
                                        {
                                            if (_inner.REP_ID != value)
                                            {
                                                _inner.REP_ID = value;
                                                if ((_trackingMask & OrderTrackingFields.REP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Order", "REP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_RESINA
                                    {
                                        get => _inner.ORD_RESINA;
                                        set
                                        {
                                            if (_inner.ORD_RESINA != value)
                                            {
                                                _inner.ORD_RESINA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_RESINA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_RESINA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ENDURECEDOR_MIOLO
                                    {
                                        get => _inner.ORD_ENDURECEDOR_MIOLO;
                                        set
                                        {
                                            if (_inner.ORD_ENDURECEDOR_MIOLO != value)
                                            {
                                                _inner.ORD_ENDURECEDOR_MIOLO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ENDURECEDOR_MIOLO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ENDURECEDOR_MIOLO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OrderTrackingFields.PRO_ID_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("Order", "PRO_ID_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_VINCOS_ONDULADEIRA
                                    {
                                        get => _inner.ORD_VINCOS_ONDULADEIRA;
                                        set
                                        {
                                            if (_inner.ORD_VINCOS_ONDULADEIRA != value)
                                            {
                                                _inner.ORD_VINCOS_ONDULADEIRA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_VINCOS_ONDULADEIRA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_VINCOS_ONDULADEIRA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_ERP_CUSTOS_FIXOS
                                    {
                                        get => _inner.ORD_ERP_CUSTOS_FIXOS;
                                        set
                                        {
                                            if (_inner.ORD_ERP_CUSTOS_FIXOS != value)
                                            {
                                                _inner.ORD_ERP_CUSTOS_FIXOS = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ERP_CUSTOS_FIXOS) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ERP_CUSTOS_FIXOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_ERP_CUSTOS_VARIAVEIS
                                    {
                                        get => _inner.ORD_ERP_CUSTOS_VARIAVEIS;
                                        set
                                        {
                                            if (_inner.ORD_ERP_CUSTOS_VARIAVEIS != value)
                                            {
                                                _inner.ORD_ERP_CUSTOS_VARIAVEIS = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ERP_CUSTOS_VARIAVEIS) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ERP_CUSTOS_VARIAVEIS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_ERP_DESPESAS_VAR_VENDA
                                    {
                                        get => _inner.ORD_ERP_DESPESAS_VAR_VENDA;
                                        set
                                        {
                                            if (_inner.ORD_ERP_DESPESAS_VAR_VENDA != value)
                                            {
                                                _inner.ORD_ERP_DESPESAS_VAR_VENDA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ERP_DESPESAS_VAR_VENDA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ERP_DESPESAS_VAR_VENDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_ERP_IMPOSTOS
                                    {
                                        get => _inner.ORD_ERP_IMPOSTOS;
                                        set
                                        {
                                            if (_inner.ORD_ERP_IMPOSTOS != value)
                                            {
                                                _inner.ORD_ERP_IMPOSTOS = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_ERP_IMPOSTOS) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_ERP_IMPOSTOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_STATUS_PLANEJAMENTO
                                    {
                                        get => _inner.ORD_STATUS_PLANEJAMENTO;
                                        set
                                        {
                                            if (_inner.ORD_STATUS_PLANEJAMENTO != value)
                                            {
                                                _inner.ORD_STATUS_PLANEJAMENTO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_STATUS_PLANEJAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_STATUS_PLANEJAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ORD_TOLERANCIA_DIMENSAO_CHAPA_DE
                                    {
                                        get => _inner.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE;
                                        set
                                        {
                                            if (_inner.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE != value)
                                            {
                                                _inner.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_TOLERANCIA_DIMENSAO_CHAPA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE
                                    {
                                        get => _inner.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE;
                                        set
                                        {
                                            if (_inner.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE != value)
                                            {
                                                _inner.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_PROMOVE_DE
                                    {
                                        get => _inner.ORD_PROMOVE_DE;
                                        set
                                        {
                                            if (_inner.ORD_PROMOVE_DE != value)
                                            {
                                                _inner.ORD_PROMOVE_DE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_PROMOVE_DE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_PROMOVE_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_PROMOVE_ATE
                                    {
                                        get => _inner.ORD_PROMOVE_ATE;
                                        set
                                        {
                                            if (_inner.ORD_PROMOVE_ATE != value)
                                            {
                                                _inner.ORD_PROMOVE_ATE = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_PROMOVE_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_PROMOVE_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_TRAVA_COMPOSICAO
                                    {
                                        get => _inner.ORD_TRAVA_COMPOSICAO;
                                        set
                                        {
                                            if (_inner.ORD_TRAVA_COMPOSICAO != value)
                                            {
                                                _inner.ORD_TRAVA_COMPOSICAO = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_TRAVA_COMPOSICAO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_TRAVA_COMPOSICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_TRAVA_RESINA
                                    {
                                        get => _inner.ORD_TRAVA_RESINA;
                                        set
                                        {
                                            if (_inner.ORD_TRAVA_RESINA != value)
                                            {
                                                _inner.ORD_TRAVA_RESINA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_TRAVA_RESINA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_TRAVA_RESINA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_PROMOVE_RESINA
                                    {
                                        get => _inner.ORD_PROMOVE_RESINA;
                                        set
                                        {
                                            if (_inner.ORD_PROMOVE_RESINA != value)
                                            {
                                                _inner.ORD_PROMOVE_RESINA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_PROMOVE_RESINA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_PROMOVE_RESINA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_LATITUDE_ENTREGA
                                    {
                                        get => _inner.ORD_LATITUDE_ENTREGA;
                                        set
                                        {
                                            if (_inner.ORD_LATITUDE_ENTREGA != value)
                                            {
                                                _inner.ORD_LATITUDE_ENTREGA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_LATITUDE_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_LATITUDE_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ORD_LONGITUDE_ENTREGA
                                    {
                                        get => _inner.ORD_LONGITUDE_ENTREGA;
                                        set
                                        {
                                            if (_inner.ORD_LONGITUDE_ENTREGA != value)
                                            {
                                                _inner.ORD_LONGITUDE_ENTREGA = value;
                                                if ((_trackingMask & OrderTrackingFields.ORD_LONGITUDE_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Order", "ORD_LONGITUDE_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OCO_ID_CANCELAMENTO
                                    {
                                        get => _inner.OCO_ID_CANCELAMENTO;
                                        set
                                        {
                                            if (_inner.OCO_ID_CANCELAMENTO != value)
                                            {
                                                _inner.OCO_ID_CANCELAMENTO = value;
                                                if ((_trackingMask & OrderTrackingFields.OCO_ID_CANCELAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Order", "OCO_ID_CANCELAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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

                                    public int? ORD_PILHAS_POR_PALETE
                                    {
                                        get => _inner.ORD_PILHAS_POR_PALETE;
                                        set
                                        {
                                            if (_inner.ORD_PILHAS_POR_PALETE != value)
                                            {
                                                _inner.ORD_PILHAS_POR_PALETE = value;

                                            }
                                        }
                                    }

                                    public int? ORD_CHAPAS_POR_PILHA
                                    {
                                        get => _inner.ORD_CHAPAS_POR_PILHA;
                                        set
                                        {
                                            if (_inner.ORD_CHAPAS_POR_PILHA != value)
                                            {
                                                _inner.ORD_CHAPAS_POR_PILHA = value;

                                            }
                                        }
                                    }

                                    public DateTime? ORD_DATA_CANCELAMENTO
                                    {
                                        get => _inner.ORD_DATA_CANCELAMENTO;
                                        set
                                        {
                                            if (_inner.ORD_DATA_CANCELAMENTO != value)
                                            {
                                                _inner.ORD_DATA_CANCELAMENTO = value;

                                            }
                                        }
                                    }

                                    public string ORD_STATUS_ESTATISTICA
                                    {
                                        get => _inner.ORD_STATUS_ESTATISTICA;
                                        set
                                        {
                                            if (_inner.ORD_STATUS_ESTATISTICA != value)
                                            {
                                                _inner.ORD_STATUS_ESTATISTICA = value;

                                            }
                                        }
                                    }

                                    public DateTime? ORD_DATA_ESTATISTICA
                                    {
                                        get => _inner.ORD_DATA_ESTATISTICA;
                                        set
                                        {
                                            if (_inner.ORD_DATA_ESTATISTICA != value)
                                            {
                                                _inner.ORD_DATA_ESTATISTICA = value;

                                            }
                                        }
                                    }

                                    public string OCO_ID_MOTIVO_ATRASO
                                    {
                                        get => _inner.OCO_ID_MOTIVO_ATRASO;
                                        set
                                        {
                                            if (_inner.OCO_ID_MOTIVO_ATRASO != value)
                                            {
                                                _inner.OCO_ID_MOTIVO_ATRASO = value;

                                            }
                                        }
                                    }

                                    public int? OTK_VERSSAO
                                    {
                                        get => _inner.OTK_VERSSAO;
                                        set
                                        {
                                            if (_inner.OTK_VERSSAO != value)
                                            {
                                                _inner.OTK_VERSSAO = value;

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