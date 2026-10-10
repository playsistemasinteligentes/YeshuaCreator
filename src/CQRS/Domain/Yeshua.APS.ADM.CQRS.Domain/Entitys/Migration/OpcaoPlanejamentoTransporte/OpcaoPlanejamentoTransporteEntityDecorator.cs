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
                    public static class OpcaoPlanejamentoTransporteTrackingFields
        {
            public const ulong OpcaoId = 1UL << 0;
            public const ulong GrupoDecisaoId = 1UL << 1;
            public const ulong Peso = 1UL << 2;
            public const ulong Volume = 1UL << 3;
            public const ulong CustoEstimado = 1UL << 4;
            public const ulong AderenciaCubagem = 1UL << 5;
            public const ulong AderenciaJanelaEntrega = 1UL << 6;
            public const ulong RiscoResumo = 1UL << 7;
            public const ulong PedidosResumo = 1UL << 8;
            public const ulong OpcoesConflitantesResumo = 1UL << 9;
        }

        public static class OpcaoPlanejamentoTransporteOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification OpcaoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GrupoDecisaoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Peso = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Volume = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CustoEstimado = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AderenciaCubagem = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AderenciaJanelaEntrega = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RiscoResumo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PedidosResumo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OpcoesConflitantesResumo = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class OpcaoPlanejamentoTransporteDecorator : IOpcaoPlanejamentoTransporteEntity
{

                        private readonly IOpcaoPlanejamentoTransporteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OpcaoPlanejamentoTransporteDecorator(IOpcaoPlanejamentoTransporteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OpcaoPlanejamentoTransporteDecorator(
                            IOpcaoPlanejamentoTransporteEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingExecutionIdentity = context is null
                                ? default
                                : new Dominio.Operational.OperationalExecutionIdentity(
                                    context.RootOperationId,
                                    context.OperationId,
                                    context.ExecutionId,
                                    context.CausationId);
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public string OpcaoId
                                    {
                                        get => _inner.OpcaoId;
                                        set
                                        {
                                            if (_inner.OpcaoId != value)
                                            {
                                                _inner.OpcaoId = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.OpcaoId) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "OpcaoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.OpcaoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string GrupoDecisaoId
                                    {
                                        get => _inner.GrupoDecisaoId;
                                        set
                                        {
                                            if (_inner.GrupoDecisaoId != value)
                                            {
                                                _inner.GrupoDecisaoId = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.GrupoDecisaoId) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "GrupoDecisaoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.GrupoDecisaoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? Peso
                                    {
                                        get => _inner.Peso;
                                        set
                                        {
                                            if (_inner.Peso != value)
                                            {
                                                _inner.Peso = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.Peso) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "Peso", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.Peso, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? Volume
                                    {
                                        get => _inner.Volume;
                                        set
                                        {
                                            if (_inner.Volume != value)
                                            {
                                                _inner.Volume = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.Volume) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "Volume", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.Volume, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? CustoEstimado
                                    {
                                        get => _inner.CustoEstimado;
                                        set
                                        {
                                            if (_inner.CustoEstimado != value)
                                            {
                                                _inner.CustoEstimado = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.CustoEstimado) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "CustoEstimado", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.CustoEstimado, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.AderenciaCubagem) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "AderenciaCubagem", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.AderenciaCubagem, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? AderenciaJanelaEntrega
                                    {
                                        get => _inner.AderenciaJanelaEntrega;
                                        set
                                        {
                                            if (_inner.AderenciaJanelaEntrega != value)
                                            {
                                                _inner.AderenciaJanelaEntrega = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.AderenciaJanelaEntrega) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "AderenciaJanelaEntrega", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.AderenciaJanelaEntrega, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? RiscoResumo
                                    {
                                        get => _inner.RiscoResumo;
                                        set
                                        {
                                            if (_inner.RiscoResumo != value)
                                            {
                                                _inner.RiscoResumo = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.RiscoResumo) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "RiscoResumo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.RiscoResumo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PedidosResumo
                                    {
                                        get => _inner.PedidosResumo;
                                        set
                                        {
                                            if (_inner.PedidosResumo != value)
                                            {
                                                _inner.PedidosResumo = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.PedidosResumo) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "PedidosResumo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.PedidosResumo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? OpcoesConflitantesResumo
                                    {
                                        get => _inner.OpcoesConflitantesResumo;
                                        set
                                        {
                                            if (_inner.OpcoesConflitantesResumo != value)
                                            {
                                                _inner.OpcoesConflitantesResumo = value;
                                                if ((_trackingMask & OpcaoPlanejamentoTransporteTrackingFields.OpcoesConflitantesResumo) != 0UL)
                                                    _logger.DomainValueChanged("OpcaoPlanejamentoTransporte", "OpcoesConflitantesResumo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, OpcaoPlanejamentoTransporteOperationalFields.OpcoesConflitantesResumo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration