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
                    public static class TipoTesteTrackingFields
        {
            public const ulong TT_ESPECIFICACAO = 1UL << 0;
            public const ulong TT_ORIGEM_ESPECIFICACAO = 1UL << 1;
            public const ulong TT_IMPRIME_NO_LAUDO = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
            public const ulong TT_ID = 1UL << 7;
            public const ulong TT_NOME = 1UL << 8;
            public const ulong TT_DESC = 1UL << 9;
            public const ulong TT_TOL_MAIS = 1UL << 10;
            public const ulong TT_TOL_MENOS = 1UL << 11;
            public const ulong TT_NORMA = 1UL << 12;
            public const ulong TT_INICIO_PROCESSO = 1UL << 13;
            public const ulong TA_ID = 1UL << 14;
            public const ulong UNI_ID = 1UL << 15;
            public const ulong TT_N_AMOSTRAS_P_TESTE = 1UL << 16;
            public const ulong TT_MAX_DEF_CRITICO = 1UL << 17;
            public const ulong TT_MAX_DEF_GRAVE = 1UL << 18;
        }

        public partial class TipoTesteDecorator : ITipoTesteEntity
{

                        private readonly ITipoTesteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TipoTesteDecorator(ITipoTesteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TipoTesteDecorator(
                            ITipoTesteEntity inner,
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
                                    public Decimal? TT_ESPECIFICACAO
                                    {
                                        get => _inner.TT_ESPECIFICACAO;
                                        set
                                        {
                                            if (_inner.TT_ESPECIFICACAO != value)
                                            {
                                                _inner.TT_ESPECIFICACAO = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_ESPECIFICACAO) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_ESPECIFICACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TT_ORIGEM_ESPECIFICACAO
                                    {
                                        get => _inner.TT_ORIGEM_ESPECIFICACAO;
                                        set
                                        {
                                            if (_inner.TT_ORIGEM_ESPECIFICACAO != value)
                                            {
                                                _inner.TT_ORIGEM_ESPECIFICACAO = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_ORIGEM_ESPECIFICACAO) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_ORIGEM_ESPECIFICACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TT_IMPRIME_NO_LAUDO
                                    {
                                        get => _inner.TT_IMPRIME_NO_LAUDO;
                                        set
                                        {
                                            if (_inner.TT_IMPRIME_NO_LAUDO != value)
                                            {
                                                _inner.TT_IMPRIME_NO_LAUDO = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_IMPRIME_NO_LAUDO) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_IMPRIME_NO_LAUDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoTesteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoTesteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoTesteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoTesteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int TT_ID
                                    {
                                        get => _inner.TT_ID;
                                        set
                                        {
                                            if (_inner.TT_ID != value)
                                            {
                                                _inner.TT_ID = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TT_NOME
                                    {
                                        get => _inner.TT_NOME;
                                        set
                                        {
                                            if (_inner.TT_NOME != value)
                                            {
                                                _inner.TT_NOME = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_NOME) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TT_DESC
                                    {
                                        get => _inner.TT_DESC;
                                        set
                                        {
                                            if (_inner.TT_DESC != value)
                                            {
                                                _inner.TT_DESC = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_DESC) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_DESC", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TT_TOL_MAIS
                                    {
                                        get => _inner.TT_TOL_MAIS;
                                        set
                                        {
                                            if (_inner.TT_TOL_MAIS != value)
                                            {
                                                _inner.TT_TOL_MAIS = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_TOL_MAIS) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_TOL_MAIS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TT_TOL_MENOS
                                    {
                                        get => _inner.TT_TOL_MENOS;
                                        set
                                        {
                                            if (_inner.TT_TOL_MENOS != value)
                                            {
                                                _inner.TT_TOL_MENOS = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_TOL_MENOS) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_TOL_MENOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TT_NORMA
                                    {
                                        get => _inner.TT_NORMA;
                                        set
                                        {
                                            if (_inner.TT_NORMA != value)
                                            {
                                                _inner.TT_NORMA = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_NORMA) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_NORMA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TT_INICIO_PROCESSO
                                    {
                                        get => _inner.TT_INICIO_PROCESSO;
                                        set
                                        {
                                            if (_inner.TT_INICIO_PROCESSO != value)
                                            {
                                                _inner.TT_INICIO_PROCESSO = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_INICIO_PROCESSO) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_INICIO_PROCESSO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int TA_ID
                                    {
                                        get => _inner.TA_ID;
                                        set
                                        {
                                            if (_inner.TA_ID != value)
                                            {
                                                _inner.TA_ID = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TA_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoTesteTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TT_N_AMOSTRAS_P_TESTE
                                    {
                                        get => _inner.TT_N_AMOSTRAS_P_TESTE;
                                        set
                                        {
                                            if (_inner.TT_N_AMOSTRAS_P_TESTE != value)
                                            {
                                                _inner.TT_N_AMOSTRAS_P_TESTE = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_N_AMOSTRAS_P_TESTE) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_N_AMOSTRAS_P_TESTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TT_MAX_DEF_CRITICO
                                    {
                                        get => _inner.TT_MAX_DEF_CRITICO;
                                        set
                                        {
                                            if (_inner.TT_MAX_DEF_CRITICO != value)
                                            {
                                                _inner.TT_MAX_DEF_CRITICO = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_MAX_DEF_CRITICO) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_MAX_DEF_CRITICO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TT_MAX_DEF_GRAVE
                                    {
                                        get => _inner.TT_MAX_DEF_GRAVE;
                                        set
                                        {
                                            if (_inner.TT_MAX_DEF_GRAVE != value)
                                            {
                                                _inner.TT_MAX_DEF_GRAVE = value;
                                                if ((_trackingMask & TipoTesteTrackingFields.TT_MAX_DEF_GRAVE) != 0UL)
                                                    _logger.DomainValueChanged("TipoTeste", "TT_MAX_DEF_GRAVE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration