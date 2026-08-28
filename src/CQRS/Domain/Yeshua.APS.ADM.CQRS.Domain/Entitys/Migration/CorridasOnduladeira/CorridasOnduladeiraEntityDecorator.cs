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
                    public static class CorridasOnduladeiraTrackingFields
        {
            public const ulong BOL_ID = 1UL << 0;
            public const ulong BOL_ID_ORIGEM = 1UL << 1;
            public const ulong PRO_LARGURA_PECA = 1UL << 2;
            public const ulong PRO_LARGURA_PECA_PROGRAMADO = 1UL << 3;
            public const ulong PRO_COMPRIMENTO_PECA = 1UL << 4;
            public const ulong PRO_COMPRIMENTO_PECA_PROGRAMADO = 1UL << 5;
            public const ulong PRO_UTILIZOU_REFILE_OBRIGATORIO = 1UL << 6;
            public const ulong PRO_VINCOS_RECALCULADOS = 1UL << 7;
            public const ulong COR_SOLVER = 1UL << 8;
            public const ulong COR_GRAMATURA_PAPEIS_PROGRAMADOS = 1UL << 9;
            public const ulong COR_CUSTO_PAPEIS_PROGRAMADOS = 1UL << 10;
            public const ulong COR_GRAMATURA_RESINA_PROGRAMADOS = 1UL << 11;
            public const ulong COR_CUSTO_RESINA_PROGRAMADOS = 1UL << 12;
            public const ulong COR_TOLERANCIA_MENOS = 1UL << 13;
            public const ulong COR_TOLERANCIA_MAIS = 1UL << 14;
            public const ulong COR_PILHAS_POR_PALETE = 1UL << 15;
            public const ulong COR_COR_FILA = 1UL << 16;
            public const ulong COR_M_LINEAR_REALIZADO = 1UL << 17;
            public const ulong PRO_ID_PALETE = 1UL << 18;
            public const ulong COR_STATUS_PALETE = 1UL << 19;
            public const ulong COR_GRUPO_PRODUTIVO = 1UL << 20;
            public const ulong TenantID = 1UL << 21;
            public const ulong Deleted = 1UL << 22;
            public const ulong Changed = 1UL << 23;
            public const ulong UserId = 1UL << 24;
            public const ulong COR_ID = 1UL << 25;
            public const ulong COR_STATUS = 1UL << 26;
            public const ulong COR_STATUS_INTERFACE = 1UL << 27;
            public const ulong MAQ_ID = 1UL << 28;
            public const ulong COR_ID_INTERFACE = 1UL << 29;
            public const ulong COR_SEQUENCIA = 1UL << 30;
            public const ulong COR_SEQUENCIA_ORIGEM = 1UL << 31;
            public const ulong ORD_ID = 1UL << 32;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 33;
            public const ulong ROT_SEQ_TRANFORMACAO = 1UL << 34;
            public const ulong COR_FACAO = 1UL << 35;
            public const ulong COR_FORMATO_BOBINA = 1UL << 36;
            public const ulong COR_INICIO_PREVISTO = 1UL << 37;
            public const ulong COR_FIM_PREVISTO = 1UL << 38;
            public const ulong PRO_ID = 1UL << 39;
            public const ulong COR_QTD_PLANEJADO = 1UL << 40;
            public const ulong PRO_QTD_PACAS = 1UL << 41;
            public const ulong COR_PECAS_LARGURA = 1UL << 42;
        }

        public partial class CorridasOnduladeiraDecorator : ICorridasOnduladeiraEntity
{

                        private readonly ICorridasOnduladeiraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CorridasOnduladeiraDecorator(ICorridasOnduladeiraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CorridasOnduladeiraDecorator(
                            ICorridasOnduladeiraEntity inner,
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
                                    public string BOL_ID
                                    {
                                        get => _inner.BOL_ID;
                                        set
                                        {
                                            if (_inner.BOL_ID != value)
                                            {
                                                _inner.BOL_ID = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.BOL_ID) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "BOL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string BOL_ID_ORIGEM
                                    {
                                        get => _inner.BOL_ID_ORIGEM;
                                        set
                                        {
                                            if (_inner.BOL_ID_ORIGEM != value)
                                            {
                                                _inner.BOL_ID_ORIGEM = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.BOL_ID_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "BOL_ID_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_LARGURA_PECA) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_LARGURA_PECA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_LARGURA_PECA_PROGRAMADO
                                    {
                                        get => _inner.PRO_LARGURA_PECA_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.PRO_LARGURA_PECA_PROGRAMADO != value)
                                            {
                                                _inner.PRO_LARGURA_PECA_PROGRAMADO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_LARGURA_PECA_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_LARGURA_PECA_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_COMPRIMENTO_PECA) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_COMPRIMENTO_PECA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_COMPRIMENTO_PECA_PROGRAMADO
                                    {
                                        get => _inner.PRO_COMPRIMENTO_PECA_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.PRO_COMPRIMENTO_PECA_PROGRAMADO != value)
                                            {
                                                _inner.PRO_COMPRIMENTO_PECA_PROGRAMADO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_COMPRIMENTO_PECA_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_COMPRIMENTO_PECA_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PRO_UTILIZOU_REFILE_OBRIGATORIO
                                    {
                                        get => _inner.PRO_UTILIZOU_REFILE_OBRIGATORIO;
                                        set
                                        {
                                            if (_inner.PRO_UTILIZOU_REFILE_OBRIGATORIO != value)
                                            {
                                                _inner.PRO_UTILIZOU_REFILE_OBRIGATORIO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_UTILIZOU_REFILE_OBRIGATORIO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_UTILIZOU_REFILE_OBRIGATORIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_VINCOS_RECALCULADOS
                                    {
                                        get => _inner.PRO_VINCOS_RECALCULADOS;
                                        set
                                        {
                                            if (_inner.PRO_VINCOS_RECALCULADOS != value)
                                            {
                                                _inner.PRO_VINCOS_RECALCULADOS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_VINCOS_RECALCULADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_VINCOS_RECALCULADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string COR_SOLVER
                                    {
                                        get => _inner.COR_SOLVER;
                                        set
                                        {
                                            if (_inner.COR_SOLVER != value)
                                            {
                                                _inner.COR_SOLVER = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_SOLVER) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_SOLVER", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COR_GRAMATURA_PAPEIS_PROGRAMADOS
                                    {
                                        get => _inner.COR_GRAMATURA_PAPEIS_PROGRAMADOS;
                                        set
                                        {
                                            if (_inner.COR_GRAMATURA_PAPEIS_PROGRAMADOS != value)
                                            {
                                                _inner.COR_GRAMATURA_PAPEIS_PROGRAMADOS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_GRAMATURA_PAPEIS_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_GRAMATURA_PAPEIS_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COR_CUSTO_PAPEIS_PROGRAMADOS
                                    {
                                        get => _inner.COR_CUSTO_PAPEIS_PROGRAMADOS;
                                        set
                                        {
                                            if (_inner.COR_CUSTO_PAPEIS_PROGRAMADOS != value)
                                            {
                                                _inner.COR_CUSTO_PAPEIS_PROGRAMADOS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_CUSTO_PAPEIS_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_CUSTO_PAPEIS_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COR_GRAMATURA_RESINA_PROGRAMADOS
                                    {
                                        get => _inner.COR_GRAMATURA_RESINA_PROGRAMADOS;
                                        set
                                        {
                                            if (_inner.COR_GRAMATURA_RESINA_PROGRAMADOS != value)
                                            {
                                                _inner.COR_GRAMATURA_RESINA_PROGRAMADOS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_GRAMATURA_RESINA_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_GRAMATURA_RESINA_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COR_CUSTO_RESINA_PROGRAMADOS
                                    {
                                        get => _inner.COR_CUSTO_RESINA_PROGRAMADOS;
                                        set
                                        {
                                            if (_inner.COR_CUSTO_RESINA_PROGRAMADOS != value)
                                            {
                                                _inner.COR_CUSTO_RESINA_PROGRAMADOS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_CUSTO_RESINA_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_CUSTO_RESINA_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COR_TOLERANCIA_MENOS
                                    {
                                        get => _inner.COR_TOLERANCIA_MENOS;
                                        set
                                        {
                                            if (_inner.COR_TOLERANCIA_MENOS != value)
                                            {
                                                _inner.COR_TOLERANCIA_MENOS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_TOLERANCIA_MENOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_TOLERANCIA_MENOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COR_TOLERANCIA_MAIS
                                    {
                                        get => _inner.COR_TOLERANCIA_MAIS;
                                        set
                                        {
                                            if (_inner.COR_TOLERANCIA_MAIS != value)
                                            {
                                                _inner.COR_TOLERANCIA_MAIS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_TOLERANCIA_MAIS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_TOLERANCIA_MAIS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_PILHAS_POR_PALETE
                                    {
                                        get => _inner.COR_PILHAS_POR_PALETE;
                                        set
                                        {
                                            if (_inner.COR_PILHAS_POR_PALETE != value)
                                            {
                                                _inner.COR_PILHAS_POR_PALETE = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_PILHAS_POR_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_PILHAS_POR_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string COR_COR_FILA
                                    {
                                        get => _inner.COR_COR_FILA;
                                        set
                                        {
                                            if (_inner.COR_COR_FILA != value)
                                            {
                                                _inner.COR_COR_FILA = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_COR_FILA) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_COR_FILA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COR_M_LINEAR_REALIZADO
                                    {
                                        get => _inner.COR_M_LINEAR_REALIZADO;
                                        set
                                        {
                                            if (_inner.COR_M_LINEAR_REALIZADO != value)
                                            {
                                                _inner.COR_M_LINEAR_REALIZADO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_M_LINEAR_REALIZADO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_M_LINEAR_REALIZADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_ID_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_ID_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string COR_STATUS_PALETE
                                    {
                                        get => _inner.COR_STATUS_PALETE;
                                        set
                                        {
                                            if (_inner.COR_STATUS_PALETE != value)
                                            {
                                                _inner.COR_STATUS_PALETE = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_STATUS_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_STATUS_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? COR_GRUPO_PRODUTIVO
                                    {
                                        get => _inner.COR_GRUPO_PRODUTIVO;
                                        set
                                        {
                                            if (_inner.COR_GRUPO_PRODUTIVO != value)
                                            {
                                                _inner.COR_GRUPO_PRODUTIVO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_GRUPO_PRODUTIVO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_GRUPO_PRODUTIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int COR_ID
                                    {
                                        get => _inner.COR_ID;
                                        set
                                        {
                                            if (_inner.COR_ID != value)
                                            {
                                                _inner.COR_ID = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_ID) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string COR_STATUS
                                    {
                                        get => _inner.COR_STATUS;
                                        set
                                        {
                                            if (_inner.COR_STATUS != value)
                                            {
                                                _inner.COR_STATUS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string COR_STATUS_INTERFACE
                                    {
                                        get => _inner.COR_STATUS_INTERFACE;
                                        set
                                        {
                                            if (_inner.COR_STATUS_INTERFACE != value)
                                            {
                                                _inner.COR_STATUS_INTERFACE = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_STATUS_INTERFACE) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_STATUS_INTERFACE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_ID_INTERFACE
                                    {
                                        get => _inner.COR_ID_INTERFACE;
                                        set
                                        {
                                            if (_inner.COR_ID_INTERFACE != value)
                                            {
                                                _inner.COR_ID_INTERFACE = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_ID_INTERFACE) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_ID_INTERFACE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_SEQUENCIA
                                    {
                                        get => _inner.COR_SEQUENCIA;
                                        set
                                        {
                                            if (_inner.COR_SEQUENCIA != value)
                                            {
                                                _inner.COR_SEQUENCIA = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_SEQUENCIA_ORIGEM
                                    {
                                        get => _inner.COR_SEQUENCIA_ORIGEM;
                                        set
                                        {
                                            if (_inner.COR_SEQUENCIA_ORIGEM != value)
                                            {
                                                _inner.COR_SEQUENCIA_ORIGEM = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_SEQUENCIA_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_SEQUENCIA_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.ROT_SEQ_TRANFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "ROT_SEQ_TRANFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_FACAO
                                    {
                                        get => _inner.COR_FACAO;
                                        set
                                        {
                                            if (_inner.COR_FACAO != value)
                                            {
                                                _inner.COR_FACAO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_FACAO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_FACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_FORMATO_BOBINA
                                    {
                                        get => _inner.COR_FORMATO_BOBINA;
                                        set
                                        {
                                            if (_inner.COR_FORMATO_BOBINA != value)
                                            {
                                                _inner.COR_FORMATO_BOBINA = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_FORMATO_BOBINA) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_FORMATO_BOBINA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? COR_INICIO_PREVISTO
                                    {
                                        get => _inner.COR_INICIO_PREVISTO;
                                        set
                                        {
                                            if (_inner.COR_INICIO_PREVISTO != value)
                                            {
                                                _inner.COR_INICIO_PREVISTO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_INICIO_PREVISTO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_INICIO_PREVISTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? COR_FIM_PREVISTO
                                    {
                                        get => _inner.COR_FIM_PREVISTO;
                                        set
                                        {
                                            if (_inner.COR_FIM_PREVISTO != value)
                                            {
                                                _inner.COR_FIM_PREVISTO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_FIM_PREVISTO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_FIM_PREVISTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_QTD_PLANEJADO
                                    {
                                        get => _inner.COR_QTD_PLANEJADO;
                                        set
                                        {
                                            if (_inner.COR_QTD_PLANEJADO != value)
                                            {
                                                _inner.COR_QTD_PLANEJADO = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_QTD_PLANEJADO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_QTD_PLANEJADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PRO_QTD_PACAS
                                    {
                                        get => _inner.PRO_QTD_PACAS;
                                        set
                                        {
                                            if (_inner.PRO_QTD_PACAS != value)
                                            {
                                                _inner.PRO_QTD_PACAS = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.PRO_QTD_PACAS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "PRO_QTD_PACAS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_PECAS_LARGURA
                                    {
                                        get => _inner.COR_PECAS_LARGURA;
                                        set
                                        {
                                            if (_inner.COR_PECAS_LARGURA != value)
                                            {
                                                _inner.COR_PECAS_LARGURA = value;
                                                if ((_trackingMask & CorridasOnduladeiraTrackingFields.COR_PECAS_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeira", "COR_PECAS_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration