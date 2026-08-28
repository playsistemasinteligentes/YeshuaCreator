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
                    public static class TesteFisicoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TES_ID = 1UL << 1;
            public const ulong ITE_ID = 1UL << 2;
            public const ulong USR_ID = 1UL << 3;
            public const ulong TES_NOME_TECNICO = 1UL << 4;
            public const ulong TES_AMOSTRA = 1UL << 5;
            public const ulong TES_OP = 1UL << 6;
            public const ulong TES_VALOR_NUMERICO = 1UL << 7;
            public const ulong TES_VALOR_DATA = 1UL << 8;
            public const ulong TES_VALOR_TEXTO = 1UL << 9;
            public const ulong TES_EMISSAO = 1UL << 10;
            public const ulong ORD_ID = 1UL << 11;
            public const ulong PRO_ID = 1UL << 12;
            public const ulong MAQ_ID = 1UL << 13;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 14;
            public const ulong FPR_SEQ_TRANFORMACAO = 1UL << 15;
            public const ulong TenantID = 1UL << 16;
            public const ulong Deleted = 1UL << 17;
            public const ulong Changed = 1UL << 18;
            public const ulong UserId = 1UL << 19;
        }

        public partial class TesteFisicoDecorator : ITesteFisicoEntity
{

                        private readonly ITesteFisicoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TesteFisicoDecorator(ITesteFisicoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TesteFisicoDecorator(
                            ITesteFisicoEntity inner,
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int TES_ID
                                    {
                                        get => _inner.TES_ID;
                                        set
                                        {
                                            if (_inner.TES_ID != value)
                                            {
                                                _inner.TES_ID = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.TES_ID) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TES_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ITE_ID
                                    {
                                        get => _inner.ITE_ID;
                                        set
                                        {
                                            if (_inner.ITE_ID != value)
                                            {
                                                _inner.ITE_ID = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.ITE_ID) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "ITE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? USR_ID
                                    {
                                        get => _inner.USR_ID;
                                        set
                                        {
                                            if (_inner.USR_ID != value)
                                            {
                                                _inner.USR_ID = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.USR_ID) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "USR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TES_NOME_TECNICO
                                    {
                                        get => _inner.TES_NOME_TECNICO;
                                        set
                                        {
                                            if (_inner.TES_NOME_TECNICO != value)
                                            {
                                                _inner.TES_NOME_TECNICO = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.TES_NOME_TECNICO) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TES_NOME_TECNICO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TES_AMOSTRA
                                    {
                                        get => _inner.TES_AMOSTRA;
                                        set
                                        {
                                            if (_inner.TES_AMOSTRA != value)
                                            {
                                                _inner.TES_AMOSTRA = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.TES_AMOSTRA) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TES_AMOSTRA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TES_OP
                                    {
                                        get => _inner.TES_OP;
                                        set
                                        {
                                            if (_inner.TES_OP != value)
                                            {
                                                _inner.TES_OP = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.TES_OP) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TES_OP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TES_VALOR_NUMERICO
                                    {
                                        get => _inner.TES_VALOR_NUMERICO;
                                        set
                                        {
                                            if (_inner.TES_VALOR_NUMERICO != value)
                                            {
                                                _inner.TES_VALOR_NUMERICO = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.TES_VALOR_NUMERICO) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TES_VALOR_NUMERICO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TES_VALOR_DATA
                                    {
                                        get => _inner.TES_VALOR_DATA;
                                        set
                                        {
                                            if (_inner.TES_VALOR_DATA != value)
                                            {
                                                _inner.TES_VALOR_DATA = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.TES_VALOR_DATA) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TES_VALOR_DATA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TES_VALOR_TEXTO
                                    {
                                        get => _inner.TES_VALOR_TEXTO;
                                        set
                                        {
                                            if (_inner.TES_VALOR_TEXTO != value)
                                            {
                                                _inner.TES_VALOR_TEXTO = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.TES_VALOR_TEXTO) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TES_VALOR_TEXTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TES_EMISSAO
                                    {
                                        get => _inner.TES_EMISSAO;
                                        set
                                        {
                                            if (_inner.TES_EMISSAO != value)
                                            {
                                                _inner.TES_EMISSAO = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.TES_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TES_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_SEQ_TRANFORMACAO
                                    {
                                        get => _inner.FPR_SEQ_TRANFORMACAO;
                                        set
                                        {
                                            if (_inner.FPR_SEQ_TRANFORMACAO != value)
                                            {
                                                _inner.FPR_SEQ_TRANFORMACAO = value;
                                                if ((_trackingMask & TesteFisicoTrackingFields.FPR_SEQ_TRANFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "FPR_SEQ_TRANFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TesteFisicoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TesteFisico", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration