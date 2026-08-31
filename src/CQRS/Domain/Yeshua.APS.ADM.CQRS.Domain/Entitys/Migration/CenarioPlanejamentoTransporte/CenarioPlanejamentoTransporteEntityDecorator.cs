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
                    public static class CenarioPlanejamentoTransporteTrackingFields
        {
            public const ulong CenarioId = 1UL << 0;
            public const ulong Descricao = 1UL << 1;
            public const ulong Objetivo = 1UL << 2;
            public const ulong QuantidadeCargas = 1UL << 3;
            public const ulong QuantidadePedidosNaoAtendidos = 1UL << 4;
            public const ulong CustoTotal = 1UL << 5;
            public const ulong AderenciaCubagem = 1UL << 6;
            public const ulong AtrasoPrevisto = 1UL << 7;
            public const ulong AlertasResumo = 1UL << 8;
        }

        public partial class CenarioPlanejamentoTransporteDecorator : ICenarioPlanejamentoTransporteEntity
{

                        private readonly ICenarioPlanejamentoTransporteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CenarioPlanejamentoTransporteDecorator(ICenarioPlanejamentoTransporteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CenarioPlanejamentoTransporteDecorator(
                            ICenarioPlanejamentoTransporteEntity inner,
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
                                    public string CenarioId
                                    {
                                        get => _inner.CenarioId;
                                        set
                                        {
                                            if (_inner.CenarioId != value)
                                            {
                                                _inner.CenarioId = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.CenarioId) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "CenarioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _inner.Descricao = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.Descricao) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "Descricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Objetivo
                                    {
                                        get => _inner.Objetivo;
                                        set
                                        {
                                            if (_inner.Objetivo != value)
                                            {
                                                _inner.Objetivo = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.Objetivo) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "Objetivo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? QuantidadeCargas
                                    {
                                        get => _inner.QuantidadeCargas;
                                        set
                                        {
                                            if (_inner.QuantidadeCargas != value)
                                            {
                                                _inner.QuantidadeCargas = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.QuantidadeCargas) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "QuantidadeCargas", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? QuantidadePedidosNaoAtendidos
                                    {
                                        get => _inner.QuantidadePedidosNaoAtendidos;
                                        set
                                        {
                                            if (_inner.QuantidadePedidosNaoAtendidos != value)
                                            {
                                                _inner.QuantidadePedidosNaoAtendidos = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.QuantidadePedidosNaoAtendidos) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "QuantidadePedidosNaoAtendidos", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CustoTotal
                                    {
                                        get => _inner.CustoTotal;
                                        set
                                        {
                                            if (_inner.CustoTotal != value)
                                            {
                                                _inner.CustoTotal = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.CustoTotal) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "CustoTotal", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? AderenciaCubagem
                                    {
                                        get => _inner.AderenciaCubagem;
                                        set
                                        {
                                            if (_inner.AderenciaCubagem != value)
                                            {
                                                _inner.AderenciaCubagem = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.AderenciaCubagem) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "AderenciaCubagem", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? AtrasoPrevisto
                                    {
                                        get => _inner.AtrasoPrevisto;
                                        set
                                        {
                                            if (_inner.AtrasoPrevisto != value)
                                            {
                                                _inner.AtrasoPrevisto = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.AtrasoPrevisto) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "AtrasoPrevisto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AlertasResumo
                                    {
                                        get => _inner.AlertasResumo;
                                        set
                                        {
                                            if (_inner.AlertasResumo != value)
                                            {
                                                _inner.AlertasResumo = value;
                                                if ((_trackingMask & CenarioPlanejamentoTransporteTrackingFields.AlertasResumo) != 0UL)
                                                    _logger.DomainValueChanged("CenarioPlanejamentoTransporte", "AlertasResumo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration