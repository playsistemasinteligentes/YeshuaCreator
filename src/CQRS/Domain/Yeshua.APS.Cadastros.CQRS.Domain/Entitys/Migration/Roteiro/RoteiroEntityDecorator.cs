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
                    public static class RoteiroTrackingFields
        {
            public const ulong MAQ_ID = 1UL << 0;
            public const ulong PRO_ID = 1UL << 1;
            public const ulong ROT_SEQ_TRANFORMACAO = 1UL << 2;
            public const ulong GMA_ID = 1UL << 3;
            public const ulong ROT_PECAS_POR_PULSO = 1UL << 4;
            public const ulong ROT_PRIORIDADE_INFORMADA = 1UL << 5;
            public const ulong ROT_ACAO = 1UL << 6;
            public const ulong ROT_PERFORMANCE = 1UL << 7;
            public const ulong ROT_TEMPO_SETUP = 1UL << 8;
            public const ulong ROT_TEMPO_SETUP_AJUSTE = 1UL << 9;
            public const ulong ROT_VA_PARA_SEQ_TRANSFORMACAO = 1UL << 10;
            public const ulong ROT_STATUS = 1UL << 11;
            public const ulong ROT_HIERARQUIA_SEQ_TRANSFORMACAO = 1UL << 12;
            public const ulong ROT_AVALIA_CUSTO = 1UL << 13;
            public const ulong ROT_OPERACOES = 1UL << 14;
            public const ulong ROT_EXCECAO_OPERACOES = 1UL << 15;
            public const ulong ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR = 1UL << 16;
            public const ulong ROT_LINHA_DIRETA = 1UL << 17;
            public const ulong TEM_ID = 1UL << 18;
            public const ulong TenantID = 1UL << 19;
            public const ulong Deleted = 1UL << 20;
            public const ulong Changed = 1UL << 21;
            public const ulong UserId = 1UL << 22;
        }

        public partial class RoteiroDecorator : IRoteiroEntity
{

                        private readonly IRoteiroEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RoteiroDecorator(IRoteiroEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RoteiroDecorator(
                            IRoteiroEntity inner,
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
                                    public string MAQ_ID
                                    {
                                        get => _inner.MAQ_ID;
                                        set
                                        {
                                            if (_inner.MAQ_ID != value)
                                            {
                                                _inner.MAQ_ID = value;
                                                if ((_trackingMask & RoteiroTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_SEQ_TRANFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_SEQ_TRANFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GMA_ID
                                    {
                                        get => _inner.GMA_ID;
                                        set
                                        {
                                            if (_inner.GMA_ID != value)
                                            {
                                                _inner.GMA_ID = value;
                                                if ((_trackingMask & RoteiroTrackingFields.GMA_ID) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "GMA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_PECAS_POR_PULSO
                                    {
                                        get => _inner.ROT_PECAS_POR_PULSO;
                                        set
                                        {
                                            if (_inner.ROT_PECAS_POR_PULSO != value)
                                            {
                                                _inner.ROT_PECAS_POR_PULSO = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_PECAS_POR_PULSO) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_PECAS_POR_PULSO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_PRIORIDADE_INFORMADA
                                    {
                                        get => _inner.ROT_PRIORIDADE_INFORMADA;
                                        set
                                        {
                                            if (_inner.ROT_PRIORIDADE_INFORMADA != value)
                                            {
                                                _inner.ROT_PRIORIDADE_INFORMADA = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_PRIORIDADE_INFORMADA) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_PRIORIDADE_INFORMADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_ACAO
                                    {
                                        get => _inner.ROT_ACAO;
                                        set
                                        {
                                            if (_inner.ROT_ACAO != value)
                                            {
                                                _inner.ROT_ACAO = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_ACAO) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_ACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal ROT_PERFORMANCE
                                    {
                                        get => _inner.ROT_PERFORMANCE;
                                        set
                                        {
                                            if (_inner.ROT_PERFORMANCE != value)
                                            {
                                                _inner.ROT_PERFORMANCE = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_PERFORMANCE) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_PERFORMANCE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_TEMPO_SETUP
                                    {
                                        get => _inner.ROT_TEMPO_SETUP;
                                        set
                                        {
                                            if (_inner.ROT_TEMPO_SETUP != value)
                                            {
                                                _inner.ROT_TEMPO_SETUP = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_TEMPO_SETUP) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_TEMPO_SETUP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_TEMPO_SETUP_AJUSTE
                                    {
                                        get => _inner.ROT_TEMPO_SETUP_AJUSTE;
                                        set
                                        {
                                            if (_inner.ROT_TEMPO_SETUP_AJUSTE != value)
                                            {
                                                _inner.ROT_TEMPO_SETUP_AJUSTE = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_TEMPO_SETUP_AJUSTE) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_TEMPO_SETUP_AJUSTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ROT_VA_PARA_SEQ_TRANSFORMACAO
                                    {
                                        get => _inner.ROT_VA_PARA_SEQ_TRANSFORMACAO;
                                        set
                                        {
                                            if (_inner.ROT_VA_PARA_SEQ_TRANSFORMACAO != value)
                                            {
                                                _inner.ROT_VA_PARA_SEQ_TRANSFORMACAO = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_VA_PARA_SEQ_TRANSFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_VA_PARA_SEQ_TRANSFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_STATUS
                                    {
                                        get => _inner.ROT_STATUS;
                                        set
                                        {
                                            if (_inner.ROT_STATUS != value)
                                            {
                                                _inner.ROT_STATUS = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_HIERARQUIA_SEQ_TRANSFORMACAO
                                    {
                                        get => _inner.ROT_HIERARQUIA_SEQ_TRANSFORMACAO;
                                        set
                                        {
                                            if (_inner.ROT_HIERARQUIA_SEQ_TRANSFORMACAO != value)
                                            {
                                                _inner.ROT_HIERARQUIA_SEQ_TRANSFORMACAO = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_HIERARQUIA_SEQ_TRANSFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_HIERARQUIA_SEQ_TRANSFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ROT_AVALIA_CUSTO
                                    {
                                        get => _inner.ROT_AVALIA_CUSTO;
                                        set
                                        {
                                            if (_inner.ROT_AVALIA_CUSTO != value)
                                            {
                                                _inner.ROT_AVALIA_CUSTO = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_AVALIA_CUSTO) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_AVALIA_CUSTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_OPERACOES
                                    {
                                        get => _inner.ROT_OPERACOES;
                                        set
                                        {
                                            if (_inner.ROT_OPERACOES != value)
                                            {
                                                _inner.ROT_OPERACOES = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_OPERACOES) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_OPERACOES", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_EXCECAO_OPERACOES
                                    {
                                        get => _inner.ROT_EXCECAO_OPERACOES;
                                        set
                                        {
                                            if (_inner.ROT_EXCECAO_OPERACOES != value)
                                            {
                                                _inner.ROT_EXCECAO_OPERACOES = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_EXCECAO_OPERACOES) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_EXCECAO_OPERACOES", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR
                                    {
                                        get => _inner.ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR;
                                        set
                                        {
                                            if (_inner.ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR != value)
                                            {
                                                _inner.ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_LINHA_DIRETA
                                    {
                                        get => _inner.ROT_LINHA_DIRETA;
                                        set
                                        {
                                            if (_inner.ROT_LINHA_DIRETA != value)
                                            {
                                                _inner.ROT_LINHA_DIRETA = value;
                                                if ((_trackingMask & RoteiroTrackingFields.ROT_LINHA_DIRETA) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ROT_LINHA_DIRETA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.TEM_ID) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "TEM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration