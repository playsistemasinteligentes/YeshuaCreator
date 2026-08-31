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
                    public static class CargaPlanejavelTrackingFields
        {
            public const ulong CargaId = 1UL << 0;
            public const ulong Status = 1UL << 1;
            public const ulong TransportadoraId = 1UL << 2;
            public const ulong VeiculoId = 1UL << 3;
            public const ulong TipoVeiculoId = 1UL << 4;
            public const ulong PesoTeorico = 1UL << 5;
            public const ulong VolumeTeorico = 1UL << 6;
            public const ulong InicioJanelaEmbarque = 1UL << 7;
            public const ulong FimJanelaEmbarque = 1UL << 8;
            public const ulong EmbarqueAlvo = 1UL << 9;
            public const ulong QuantidadePedidos = 1UL << 10;
            public const ulong AlertasResumo = 1UL << 11;
        }

        public partial class CargaPlanejavelDecorator : ICargaPlanejavelEntity
{

                        private readonly ICargaPlanejavelEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CargaPlanejavelDecorator(ICargaPlanejavelEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CargaPlanejavelDecorator(
                            ICargaPlanejavelEntity inner,
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
                                    public string CargaId
                                    {
                                        get => _inner.CargaId;
                                        set
                                        {
                                            if (_inner.CargaId != value)
                                            {
                                                _inner.CargaId = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.CargaId) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "CargaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TransportadoraId
                                    {
                                        get => _inner.TransportadoraId;
                                        set
                                        {
                                            if (_inner.TransportadoraId != value)
                                            {
                                                _inner.TransportadoraId = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.TransportadoraId) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "TransportadoraId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VeiculoId
                                    {
                                        get => _inner.VeiculoId;
                                        set
                                        {
                                            if (_inner.VeiculoId != value)
                                            {
                                                _inner.VeiculoId = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.VeiculoId) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "VeiculoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TipoVeiculoId
                                    {
                                        get => _inner.TipoVeiculoId;
                                        set
                                        {
                                            if (_inner.TipoVeiculoId != value)
                                            {
                                                _inner.TipoVeiculoId = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.TipoVeiculoId) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "TipoVeiculoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PesoTeorico
                                    {
                                        get => _inner.PesoTeorico;
                                        set
                                        {
                                            if (_inner.PesoTeorico != value)
                                            {
                                                _inner.PesoTeorico = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.PesoTeorico) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "PesoTeorico", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? VolumeTeorico
                                    {
                                        get => _inner.VolumeTeorico;
                                        set
                                        {
                                            if (_inner.VolumeTeorico != value)
                                            {
                                                _inner.VolumeTeorico = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.VolumeTeorico) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "VolumeTeorico", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? InicioJanelaEmbarque
                                    {
                                        get => _inner.InicioJanelaEmbarque;
                                        set
                                        {
                                            if (_inner.InicioJanelaEmbarque != value)
                                            {
                                                _inner.InicioJanelaEmbarque = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.InicioJanelaEmbarque) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "InicioJanelaEmbarque", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? FimJanelaEmbarque
                                    {
                                        get => _inner.FimJanelaEmbarque;
                                        set
                                        {
                                            if (_inner.FimJanelaEmbarque != value)
                                            {
                                                _inner.FimJanelaEmbarque = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.FimJanelaEmbarque) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "FimJanelaEmbarque", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? EmbarqueAlvo
                                    {
                                        get => _inner.EmbarqueAlvo;
                                        set
                                        {
                                            if (_inner.EmbarqueAlvo != value)
                                            {
                                                _inner.EmbarqueAlvo = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.EmbarqueAlvo) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "EmbarqueAlvo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? QuantidadePedidos
                                    {
                                        get => _inner.QuantidadePedidos;
                                        set
                                        {
                                            if (_inner.QuantidadePedidos != value)
                                            {
                                                _inner.QuantidadePedidos = value;
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.QuantidadePedidos) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "QuantidadePedidos", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CargaPlanejavelTrackingFields.AlertasResumo) != 0UL)
                                                    _logger.DomainValueChanged("CargaPlanejavel", "AlertasResumo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration