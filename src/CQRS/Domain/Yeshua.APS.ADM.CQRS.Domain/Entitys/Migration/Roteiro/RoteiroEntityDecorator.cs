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
            public const ulong MaquinaId = 1UL << 0;
            public const ulong ProdutoId = 1UL << 1;
            public const ulong SequenciaTransformacao = 1UL << 2;
            public const ulong GrupoMaquinaId = 1UL << 3;
            public const ulong PecasPorPulso = 1UL << 4;
            public const ulong PrioridadeInformada = 1UL << 5;
            public const ulong Acao = 1UL << 6;
            public const ulong Performance = 1UL << 7;
            public const ulong TempoSetup = 1UL << 8;
            public const ulong TempoSetupAjuste = 1UL << 9;
            public const ulong ProximaSequenciaTransformacao = 1UL << 10;
            public const ulong Status = 1UL << 11;
            public const ulong HierarquiaSequenciaTransformacao = 1UL << 12;
            public const ulong AvaliaCusto = 1UL << 13;
            public const ulong Operacoes = 1UL << 14;
            public const ulong ExcecaoOperacoes = 1UL << 15;
            public const ulong PercentualInicioPassoAnterior = 1UL << 16;
            public const ulong LinhaDireta = 1UL << 17;
            public const ulong TemplateDeTestesId = 1UL << 18;
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
                                    public string MaquinaId
                                    {
                                        get => _inner.MaquinaId;
                                        set
                                        {
                                            if (_inner.MaquinaId != value)
                                            {
                                                _inner.MaquinaId = value;
                                                if ((_trackingMask & RoteiroTrackingFields.MaquinaId) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "MaquinaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.ProdutoId) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ProdutoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.SequenciaTransformacao) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "SequenciaTransformacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GrupoMaquinaId
                                    {
                                        get => _inner.GrupoMaquinaId;
                                        set
                                        {
                                            if (_inner.GrupoMaquinaId != value)
                                            {
                                                _inner.GrupoMaquinaId = value;
                                                if ((_trackingMask & RoteiroTrackingFields.GrupoMaquinaId) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "GrupoMaquinaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.PecasPorPulso) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "PecasPorPulso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.PrioridadeInformada) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "PrioridadeInformada", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Acao
                                    {
                                        get => _inner.Acao;
                                        set
                                        {
                                            if (_inner.Acao != value)
                                            {
                                                _inner.Acao = value;
                                                if ((_trackingMask & RoteiroTrackingFields.Acao) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "Acao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal Performance
                                    {
                                        get => _inner.Performance;
                                        set
                                        {
                                            if (_inner.Performance != value)
                                            {
                                                _inner.Performance = value;
                                                if ((_trackingMask & RoteiroTrackingFields.Performance) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "Performance", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.TempoSetup) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "TempoSetup", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.TempoSetupAjuste) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "TempoSetupAjuste", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.ProximaSequenciaTransformacao) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ProximaSequenciaTransformacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.HierarquiaSequenciaTransformacao) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "HierarquiaSequenciaTransformacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.AvaliaCusto) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "AvaliaCusto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.Operacoes) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "Operacoes", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.ExcecaoOperacoes) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "ExcecaoOperacoes", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.PercentualInicioPassoAnterior) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "PercentualInicioPassoAnterior", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RoteiroTrackingFields.LinhaDireta) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "LinhaDireta", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TemplateDeTestesId
                                    {
                                        get => _inner.TemplateDeTestesId;
                                        set
                                        {
                                            if (_inner.TemplateDeTestesId != value)
                                            {
                                                _inner.TemplateDeTestesId = value;
                                                if ((_trackingMask & RoteiroTrackingFields.TemplateDeTestesId) != 0UL)
                                                    _logger.DomainValueChanged("Roteiro", "TemplateDeTestesId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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