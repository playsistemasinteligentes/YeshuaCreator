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
                    public static class TipoInspecaoVisualTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TIV_ID = 1UL << 1;
            public const ulong TenantID = 1UL << 2;
            public const ulong Deleted = 1UL << 3;
            public const ulong Changed = 1UL << 4;
            public const ulong UserId = 1UL << 5;
            public const ulong TIV_NOME = 1UL << 6;
            public const ulong TIV_DESCRICAO = 1UL << 7;
            public const ulong TIV_FECHAMENTO = 1UL << 8;
            public const ulong TIV_AMOSTRA_ALEATORIA = 1UL << 9;
            public const ulong TIV_N_AMOSTRAS = 1UL << 10;
            public const ulong TIV_MEDIDA = 1UL << 11;
            public const ulong TIV_ESPECIFICACAO = 1UL << 12;
            public const ulong TIV_TOL_MAIS = 1UL << 13;
            public const ulong TIV_TOL_MENOS = 1UL << 14;
        }

        public partial class TipoInspecaoVisualDecorator : ITipoInspecaoVisualEntity
{

                        private readonly ITipoInspecaoVisualEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TipoInspecaoVisualDecorator(ITipoInspecaoVisualEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TipoInspecaoVisualDecorator(
                            ITipoInspecaoVisualEntity inner,
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
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int TIV_ID
                                    {
                                        get => _inner.TIV_ID;
                                        set
                                        {
                                            if (_inner.TIV_ID != value)
                                            {
                                                _inner.TIV_ID = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TIV_NOME
                                    {
                                        get => _inner.TIV_NOME;
                                        set
                                        {
                                            if (_inner.TIV_NOME != value)
                                            {
                                                _inner.TIV_NOME = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_NOME) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TIV_DESCRICAO
                                    {
                                        get => _inner.TIV_DESCRICAO;
                                        set
                                        {
                                            if (_inner.TIV_DESCRICAO != value)
                                            {
                                                _inner.TIV_DESCRICAO = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TIV_FECHAMENTO
                                    {
                                        get => _inner.TIV_FECHAMENTO;
                                        set
                                        {
                                            if (_inner.TIV_FECHAMENTO != value)
                                            {
                                                _inner.TIV_FECHAMENTO = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_FECHAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_FECHAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TIV_AMOSTRA_ALEATORIA
                                    {
                                        get => _inner.TIV_AMOSTRA_ALEATORIA;
                                        set
                                        {
                                            if (_inner.TIV_AMOSTRA_ALEATORIA != value)
                                            {
                                                _inner.TIV_AMOSTRA_ALEATORIA = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_AMOSTRA_ALEATORIA) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_AMOSTRA_ALEATORIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TIV_N_AMOSTRAS
                                    {
                                        get => _inner.TIV_N_AMOSTRAS;
                                        set
                                        {
                                            if (_inner.TIV_N_AMOSTRAS != value)
                                            {
                                                _inner.TIV_N_AMOSTRAS = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_N_AMOSTRAS) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_N_AMOSTRAS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TIV_MEDIDA
                                    {
                                        get => _inner.TIV_MEDIDA;
                                        set
                                        {
                                            if (_inner.TIV_MEDIDA != value)
                                            {
                                                _inner.TIV_MEDIDA = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_MEDIDA) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_MEDIDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TIV_ESPECIFICACAO
                                    {
                                        get => _inner.TIV_ESPECIFICACAO;
                                        set
                                        {
                                            if (_inner.TIV_ESPECIFICACAO != value)
                                            {
                                                _inner.TIV_ESPECIFICACAO = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_ESPECIFICACAO) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_ESPECIFICACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TIV_TOL_MAIS
                                    {
                                        get => _inner.TIV_TOL_MAIS;
                                        set
                                        {
                                            if (_inner.TIV_TOL_MAIS != value)
                                            {
                                                _inner.TIV_TOL_MAIS = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_TOL_MAIS) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_TOL_MAIS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TIV_TOL_MENOS
                                    {
                                        get => _inner.TIV_TOL_MENOS;
                                        set
                                        {
                                            if (_inner.TIV_TOL_MENOS != value)
                                            {
                                                _inner.TIV_TOL_MENOS = value;
                                                if ((_trackingMask & TipoInspecaoVisualTrackingFields.TIV_TOL_MENOS) != 0UL)
                                                    _logger.DomainValueChanged("TipoInspecaoVisual", "TIV_TOL_MENOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration