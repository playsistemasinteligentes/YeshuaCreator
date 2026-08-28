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
                    public static class FeedbackTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong DataInicial = 1UL << 1;
            public const ulong Datafinal = 1UL << 2;
            public const ulong MaquinaId = 1UL << 3;
            public const ulong OcorrenciaId = 1UL << 4;
            public const ulong TurnoId = 1UL << 5;
            public const ulong TurmaId = 1UL << 6;
            public const ulong UsuarioId = 1UL << 7;
            public const ulong OrderId = 1UL << 8;
            public const ulong ProdutoId = 1UL << 9;
            public const ulong Observacoes = 1UL << 10;
            public const ulong Grupo = 1UL << 11;
            public const ulong DiaTurma = 1UL << 12;
            public const ulong SequenciaTransformacao = 1UL << 13;
            public const ulong SequenciaRepeticao = 1UL << 14;
            public const ulong QuantidadePulsos = 1UL << 15;
            public const ulong QuantidadePecasPorPulso = 1UL << 16;
            public const ulong FEE_QTD_TOTAL_PRODUCAO_AJUSTADA = 1UL << 17;
            public const ulong BOL_ID = 1UL << 18;
            public const ulong COR_SEQUENCIA = 1UL << 19;
            public const ulong TenantID = 1UL << 20;
            public const ulong Deleted = 1UL << 21;
            public const ulong Changed = 1UL << 22;
            public const ulong UserId = 1UL << 23;
        }

        public partial class FeedbackDecorator : IFeedbackEntity
{

                        private readonly IFeedbackEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public FeedbackDecorator(IFeedbackEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public FeedbackDecorator(
                            IFeedbackEntity inner,
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
                                    public int Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & FeedbackTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DataInicial
                                    {
                                        get => _inner.DataInicial;
                                        set
                                        {
                                            if (_inner.DataInicial != value)
                                            {
                                                _inner.DataInicial = value;
                                                if ((_trackingMask & FeedbackTrackingFields.DataInicial) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "DataInicial", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime Datafinal
                                    {
                                        get => _inner.Datafinal;
                                        set
                                        {
                                            if (_inner.Datafinal != value)
                                            {
                                                _inner.Datafinal = value;
                                                if ((_trackingMask & FeedbackTrackingFields.Datafinal) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "Datafinal", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MaquinaId
                                    {
                                        get => _inner.MaquinaId;
                                        set
                                        {
                                            if (_inner.MaquinaId != value)
                                            {
                                                _inner.MaquinaId = value;
                                                if ((_trackingMask & FeedbackTrackingFields.MaquinaId) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "MaquinaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OcorrenciaId
                                    {
                                        get => _inner.OcorrenciaId;
                                        set
                                        {
                                            if (_inner.OcorrenciaId != value)
                                            {
                                                _inner.OcorrenciaId = value;
                                                if ((_trackingMask & FeedbackTrackingFields.OcorrenciaId) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "OcorrenciaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TurnoId
                                    {
                                        get => _inner.TurnoId;
                                        set
                                        {
                                            if (_inner.TurnoId != value)
                                            {
                                                _inner.TurnoId = value;
                                                if ((_trackingMask & FeedbackTrackingFields.TurnoId) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "TurnoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TurmaId
                                    {
                                        get => _inner.TurmaId;
                                        set
                                        {
                                            if (_inner.TurmaId != value)
                                            {
                                                _inner.TurmaId = value;
                                                if ((_trackingMask & FeedbackTrackingFields.TurmaId) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "TurmaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int UsuarioId
                                    {
                                        get => _inner.UsuarioId;
                                        set
                                        {
                                            if (_inner.UsuarioId != value)
                                            {
                                                _inner.UsuarioId = value;
                                                if ((_trackingMask & FeedbackTrackingFields.UsuarioId) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "UsuarioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OrderId
                                    {
                                        get => _inner.OrderId;
                                        set
                                        {
                                            if (_inner.OrderId != value)
                                            {
                                                _inner.OrderId = value;
                                                if ((_trackingMask & FeedbackTrackingFields.OrderId) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "OrderId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ProdutoId
                                    {
                                        get => _inner.ProdutoId;
                                        set
                                        {
                                            if (_inner.ProdutoId != value)
                                            {
                                                _inner.ProdutoId = value;
                                                if ((_trackingMask & FeedbackTrackingFields.ProdutoId) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "ProdutoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Observacoes
                                    {
                                        get => _inner.Observacoes;
                                        set
                                        {
                                            if (_inner.Observacoes != value)
                                            {
                                                _inner.Observacoes = value;
                                                if ((_trackingMask & FeedbackTrackingFields.Observacoes) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "Observacoes", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal Grupo
                                    {
                                        get => _inner.Grupo;
                                        set
                                        {
                                            if (_inner.Grupo != value)
                                            {
                                                _inner.Grupo = value;
                                                if ((_trackingMask & FeedbackTrackingFields.Grupo) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "Grupo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DiaTurma
                                    {
                                        get => _inner.DiaTurma;
                                        set
                                        {
                                            if (_inner.DiaTurma != value)
                                            {
                                                _inner.DiaTurma = value;
                                                if ((_trackingMask & FeedbackTrackingFields.DiaTurma) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "DiaTurma", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? SequenciaTransformacao
                                    {
                                        get => _inner.SequenciaTransformacao;
                                        set
                                        {
                                            if (_inner.SequenciaTransformacao != value)
                                            {
                                                _inner.SequenciaTransformacao = value;
                                                if ((_trackingMask & FeedbackTrackingFields.SequenciaTransformacao) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "SequenciaTransformacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? SequenciaRepeticao
                                    {
                                        get => _inner.SequenciaRepeticao;
                                        set
                                        {
                                            if (_inner.SequenciaRepeticao != value)
                                            {
                                                _inner.SequenciaRepeticao = value;
                                                if ((_trackingMask & FeedbackTrackingFields.SequenciaRepeticao) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "SequenciaRepeticao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal QuantidadePulsos
                                    {
                                        get => _inner.QuantidadePulsos;
                                        set
                                        {
                                            if (_inner.QuantidadePulsos != value)
                                            {
                                                _inner.QuantidadePulsos = value;
                                                if ((_trackingMask & FeedbackTrackingFields.QuantidadePulsos) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "QuantidadePulsos", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? QuantidadePecasPorPulso
                                    {
                                        get => _inner.QuantidadePecasPorPulso;
                                        set
                                        {
                                            if (_inner.QuantidadePecasPorPulso != value)
                                            {
                                                _inner.QuantidadePecasPorPulso = value;
                                                if ((_trackingMask & FeedbackTrackingFields.QuantidadePecasPorPulso) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "QuantidadePecasPorPulso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? FEE_QTD_TOTAL_PRODUCAO_AJUSTADA
                                    {
                                        get => _inner.FEE_QTD_TOTAL_PRODUCAO_AJUSTADA;
                                        set
                                        {
                                            if (_inner.FEE_QTD_TOTAL_PRODUCAO_AJUSTADA != value)
                                            {
                                                _inner.FEE_QTD_TOTAL_PRODUCAO_AJUSTADA = value;
                                                if ((_trackingMask & FeedbackTrackingFields.FEE_QTD_TOTAL_PRODUCAO_AJUSTADA) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "FEE_QTD_TOTAL_PRODUCAO_AJUSTADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FeedbackTrackingFields.BOL_ID) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "BOL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FeedbackTrackingFields.COR_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "COR_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FeedbackTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FeedbackTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FeedbackTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & FeedbackTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Feedback", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration