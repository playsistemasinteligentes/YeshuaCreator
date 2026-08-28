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
                    public static class CorridasOnduladeiraEstudoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong BOL_ID = 1UL << 1;
            public const ulong BOL_ID_ORIGEM = 1UL << 2;
            public const ulong PRO_LARGURA_PECA = 1UL << 3;
            public const ulong PRO_LARGURA_PECA_PROGRAMADO = 1UL << 4;
            public const ulong PRO_COMPRIMENTO_PECA = 1UL << 5;
            public const ulong PRO_COMPRIMENTO_PECA_PROGRAMADO = 1UL << 6;
            public const ulong PRO_UTILIZOU_REFILE_OBRIGATORIO = 1UL << 7;
            public const ulong PRO_VINCOS_RECALCULADOS = 1UL << 8;
            public const ulong COR_SOLVER = 1UL << 9;
            public const ulong COR_GRAMATURA_PAPEIS_PROGRAMADOS = 1UL << 10;
            public const ulong COR_CUSTO_PAPEIS_PROGRAMADOS = 1UL << 11;
            public const ulong COR_GRAMATURA_RESINA_PROGRAMADOS = 1UL << 12;
            public const ulong COR_CUSTO_RESINA_PROGRAMADOS = 1UL << 13;
            public const ulong COR_TOLERANCIA_MENOS = 1UL << 14;
            public const ulong COR_TOLERANCIA_MAIS = 1UL << 15;
            public const ulong COR_PILHAS_POR_PALETE = 1UL << 16;
            public const ulong COR_M_LINEAR_REALIZADO = 1UL << 17;
            public const ulong PRO_ID_PALETE = 1UL << 18;
            public const ulong COR_STATUS_PALETE = 1UL << 19;
            public const ulong COR_GRUPO_PRODUTIVO = 1UL << 20;
            public const ulong TenantID = 1UL << 21;
            public const ulong Deleted = 1UL << 22;
            public const ulong Changed = 1UL << 23;
            public const ulong UserId = 1UL << 24;
        }

        public partial class CorridasOnduladeiraEstudoDecorator : ICorridasOnduladeiraEstudoEntity
{

                        private readonly ICorridasOnduladeiraEstudoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CorridasOnduladeiraEstudoDecorator(ICorridasOnduladeiraEstudoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CorridasOnduladeiraEstudoDecorator(
                            ICorridasOnduladeiraEstudoEntity inner,
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string BOL_ID
                                    {
                                        get => _inner.BOL_ID;
                                        set
                                        {
                                            if (_inner.BOL_ID != value)
                                            {
                                                _inner.BOL_ID = value;
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.BOL_ID) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "BOL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.BOL_ID_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "BOL_ID_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.PRO_LARGURA_PECA) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "PRO_LARGURA_PECA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.PRO_LARGURA_PECA_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "PRO_LARGURA_PECA_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.PRO_COMPRIMENTO_PECA) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "PRO_COMPRIMENTO_PECA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.PRO_COMPRIMENTO_PECA_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "PRO_COMPRIMENTO_PECA_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.PRO_UTILIZOU_REFILE_OBRIGATORIO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "PRO_UTILIZOU_REFILE_OBRIGATORIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.PRO_VINCOS_RECALCULADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "PRO_VINCOS_RECALCULADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_SOLVER) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_SOLVER", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_GRAMATURA_PAPEIS_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_GRAMATURA_PAPEIS_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_CUSTO_PAPEIS_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_CUSTO_PAPEIS_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_GRAMATURA_RESINA_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_GRAMATURA_RESINA_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_CUSTO_RESINA_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_CUSTO_RESINA_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_TOLERANCIA_MENOS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_TOLERANCIA_MENOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_TOLERANCIA_MAIS) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_TOLERANCIA_MAIS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_PILHAS_POR_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_PILHAS_POR_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_M_LINEAR_REALIZADO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_M_LINEAR_REALIZADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.PRO_ID_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "PRO_ID_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_STATUS_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_STATUS_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.COR_GRUPO_PRODUTIVO) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "COR_GRUPO_PRODUTIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CorridasOnduladeiraEstudoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CorridasOnduladeiraEstudo", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration