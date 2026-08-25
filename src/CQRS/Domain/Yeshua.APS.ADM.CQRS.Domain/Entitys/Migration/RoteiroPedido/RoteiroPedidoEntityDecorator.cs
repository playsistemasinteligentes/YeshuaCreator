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
                    public static class RoteiroPedidoTrackingFields
        {
            public const ulong PedidoId = 1UL << 0;
            public const ulong MaquinaId = 1UL << 1;
            public const ulong ProdutoId = 1UL << 2;
            public const ulong SequenciaTransformacao = 1UL << 3;
            public const ulong StatusCadastro = 1UL << 4;
            public const ulong TipoPlanejamento = 1UL << 5;
            public const ulong CalendarioId = 1UL << 6;
            public const ulong HierarquiaSequenciaTransformacao = 1UL << 7;
            public const ulong ProximaSequenciaTransformacao = 1UL << 8;
            public const ulong Performance = 1UL << 9;
            public const ulong TempoSetup = 1UL << 10;
            public const ulong TempoSetupAjuste = 1UL << 11;
            public const ulong PecasPorPulso = 1UL << 12;
            public const ulong PrioridadeInformada = 1UL << 13;
            public const ulong Status = 1UL << 14;
            public const ulong Operacoes = 1UL << 15;
            public const ulong ExcecaoOperacoes = 1UL << 16;
            public const ulong LinhaDireta = 1UL << 17;
            public const ulong AvaliaCusto = 1UL << 18;
            public const ulong PercentualInicioPassoAnterior = 1UL << 19;
            public const ulong MaquinaLarguraUtil = 1UL << 20;
            public const ulong GrupoTipo = 1UL << 21;
            public const ulong GrupoPerformanceMetroLinear = 1UL << 22;
        }

        public partial class RoteiroPedidoDecorator : IRoteiroPedidoEntity
{

                        private readonly IRoteiroPedidoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RoteiroPedidoDecorator(IRoteiroPedidoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RoteiroPedidoDecorator(
                            IRoteiroPedidoEntity inner,
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
                                    public string PedidoId
                                    {
                                        get => _inner.PedidoId;
                                        set
                                        {
                                            if (_inner.PedidoId != value)
                                            {
                                                _inner.PedidoId = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.PedidoId) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "PedidoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.MaquinaId) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "MaquinaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.ProdutoId) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "ProdutoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int SequenciaTransformacao
                                    {
                                        get => _inner.SequenciaTransformacao;
                                        set
                                        {
                                            if (_inner.SequenciaTransformacao != value)
                                            {
                                                _inner.SequenciaTransformacao = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.SequenciaTransformacao) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "SequenciaTransformacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string StatusCadastro
                                    {
                                        get => _inner.StatusCadastro;
                                        set
                                        {
                                            if (_inner.StatusCadastro != value)
                                            {
                                                _inner.StatusCadastro = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.StatusCadastro) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "StatusCadastro", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TipoPlanejamento
                                    {
                                        get => _inner.TipoPlanejamento;
                                        set
                                        {
                                            if (_inner.TipoPlanejamento != value)
                                            {
                                                _inner.TipoPlanejamento = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.TipoPlanejamento) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "TipoPlanejamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int CalendarioId
                                    {
                                        get => _inner.CalendarioId;
                                        set
                                        {
                                            if (_inner.CalendarioId != value)
                                            {
                                                _inner.CalendarioId = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.CalendarioId) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "CalendarioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? HierarquiaSequenciaTransformacao
                                    {
                                        get => _inner.HierarquiaSequenciaTransformacao;
                                        set
                                        {
                                            if (_inner.HierarquiaSequenciaTransformacao != value)
                                            {
                                                _inner.HierarquiaSequenciaTransformacao = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.HierarquiaSequenciaTransformacao) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "HierarquiaSequenciaTransformacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ProximaSequenciaTransformacao
                                    {
                                        get => _inner.ProximaSequenciaTransformacao;
                                        set
                                        {
                                            if (_inner.ProximaSequenciaTransformacao != value)
                                            {
                                                _inner.ProximaSequenciaTransformacao = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.ProximaSequenciaTransformacao) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "ProximaSequenciaTransformacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? Performance
                                    {
                                        get => _inner.Performance;
                                        set
                                        {
                                            if (_inner.Performance != value)
                                            {
                                                _inner.Performance = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.Performance) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "Performance", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TempoSetup
                                    {
                                        get => _inner.TempoSetup;
                                        set
                                        {
                                            if (_inner.TempoSetup != value)
                                            {
                                                _inner.TempoSetup = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.TempoSetup) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "TempoSetup", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? TempoSetupAjuste
                                    {
                                        get => _inner.TempoSetupAjuste;
                                        set
                                        {
                                            if (_inner.TempoSetupAjuste != value)
                                            {
                                                _inner.TempoSetupAjuste = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.TempoSetupAjuste) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "TempoSetupAjuste", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PecasPorPulso
                                    {
                                        get => _inner.PecasPorPulso;
                                        set
                                        {
                                            if (_inner.PecasPorPulso != value)
                                            {
                                                _inner.PecasPorPulso = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.PecasPorPulso) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "PecasPorPulso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PrioridadeInformada
                                    {
                                        get => _inner.PrioridadeInformada;
                                        set
                                        {
                                            if (_inner.PrioridadeInformada != value)
                                            {
                                                _inner.PrioridadeInformada = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.PrioridadeInformada) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "PrioridadeInformada", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Operacoes
                                    {
                                        get => _inner.Operacoes;
                                        set
                                        {
                                            if (_inner.Operacoes != value)
                                            {
                                                _inner.Operacoes = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.Operacoes) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "Operacoes", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ExcecaoOperacoes
                                    {
                                        get => _inner.ExcecaoOperacoes;
                                        set
                                        {
                                            if (_inner.ExcecaoOperacoes != value)
                                            {
                                                _inner.ExcecaoOperacoes = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.ExcecaoOperacoes) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "ExcecaoOperacoes", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string LinhaDireta
                                    {
                                        get => _inner.LinhaDireta;
                                        set
                                        {
                                            if (_inner.LinhaDireta != value)
                                            {
                                                _inner.LinhaDireta = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.LinhaDireta) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "LinhaDireta", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? AvaliaCusto
                                    {
                                        get => _inner.AvaliaCusto;
                                        set
                                        {
                                            if (_inner.AvaliaCusto != value)
                                            {
                                                _inner.AvaliaCusto = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.AvaliaCusto) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "AvaliaCusto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PercentualInicioPassoAnterior
                                    {
                                        get => _inner.PercentualInicioPassoAnterior;
                                        set
                                        {
                                            if (_inner.PercentualInicioPassoAnterior != value)
                                            {
                                                _inner.PercentualInicioPassoAnterior = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.PercentualInicioPassoAnterior) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "PercentualInicioPassoAnterior", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MaquinaLarguraUtil
                                    {
                                        get => _inner.MaquinaLarguraUtil;
                                        set
                                        {
                                            if (_inner.MaquinaLarguraUtil != value)
                                            {
                                                _inner.MaquinaLarguraUtil = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.MaquinaLarguraUtil) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "MaquinaLarguraUtil", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GrupoTipo
                                    {
                                        get => _inner.GrupoTipo;
                                        set
                                        {
                                            if (_inner.GrupoTipo != value)
                                            {
                                                _inner.GrupoTipo = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.GrupoTipo) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "GrupoTipo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal GrupoPerformanceMetroLinear
                                    {
                                        get => _inner.GrupoPerformanceMetroLinear;
                                        set
                                        {
                                            if (_inner.GrupoPerformanceMetroLinear != value)
                                            {
                                                _inner.GrupoPerformanceMetroLinear = value;
                                                if ((_trackingMask & RoteiroPedidoTrackingFields.GrupoPerformanceMetroLinear) != 0UL)
                                                    _logger.DomainValueChanged("RoteiroPedido", "GrupoPerformanceMetroLinear", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration