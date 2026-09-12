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
                    public static class EmissaoFiscalTransporteTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CorrelationId = 1UL << 1;
            public const ulong OrigemFluxo = 1UL << 2;
            public const ulong CargaId = 1UL << 3;
            public const ulong RomaneioId = 1UL << 4;
            public const ulong Ambiente = 1UL << 5;
            public const ulong EmitenteDocumento = 1UL << 6;
            public const ulong TomadorDocumento = 1UL << 7;
            public const ulong TransportadorDocumento = 1UL << 8;
            public const ulong UFInicio = 1UL << 9;
            public const ulong UFFim = 1UL << 10;
            public const ulong MunicipioInicioCodigoIbge = 1UL << 11;
            public const ulong MunicipioFimCodigoIbge = 1UL << 12;
            public const ulong QuantidadeNFe = 1UL << 13;
            public const ulong QuantidadeCTe = 1UL << 14;
            public const ulong QuantidadeMDFe = 1UL << 15;
            public const ulong ValorCarga = 1UL << 16;
            public const ulong PesoBruto = 1UL << 17;
            public const ulong Volume = 1UL << 18;
            public const ulong UltimaMensagem = 1UL << 19;
            public const ulong CriadoEmUtc = 1UL << 20;
            public const ulong AtualizadoEmUtc = 1UL << 21;
            public const ulong ConcluidoEmUtc = 1UL << 22;
            public const ulong Status = 1UL << 23;
            public const ulong TenantID = 1UL << 24;
            public const ulong Deleted = 1UL << 25;
            public const ulong Changed = 1UL << 26;
            public const ulong UserId = 1UL << 27;
        }

        public partial class EmissaoFiscalTransporteDecorator : IEmissaoFiscalTransporteEntity
{

                        private readonly IEmissaoFiscalTransporteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public EmissaoFiscalTransporteDecorator(IEmissaoFiscalTransporteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public EmissaoFiscalTransporteDecorator(
                            IEmissaoFiscalTransporteEntity inner,
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
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CorrelationId
                                    {
                                        get => _inner.CorrelationId;
                                        set
                                        {
                                            if (_inner.CorrelationId != value)
                                            {
                                                _inner.CorrelationId = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int OrigemFluxo
                                    {
                                        get => _inner.OrigemFluxo;
                                        set
                                        {
                                            if (_inner.OrigemFluxo != value)
                                            {
                                                _inner.OrigemFluxo = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.OrigemFluxo) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "OrigemFluxo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? CargaId
                                    {
                                        get => _inner.CargaId;
                                        set
                                        {
                                            if (_inner.CargaId != value)
                                            {
                                                _inner.CargaId = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.CargaId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "CargaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? RomaneioId
                                    {
                                        get => _inner.RomaneioId;
                                        set
                                        {
                                            if (_inner.RomaneioId != value)
                                            {
                                                _inner.RomaneioId = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.RomaneioId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "RomaneioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Ambiente
                                    {
                                        get => _inner.Ambiente;
                                        set
                                        {
                                            if (_inner.Ambiente != value)
                                            {
                                                _inner.Ambiente = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.Ambiente) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "Ambiente", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? EmitenteDocumento
                                    {
                                        get => _inner.EmitenteDocumento;
                                        set
                                        {
                                            if (_inner.EmitenteDocumento != value)
                                            {
                                                _inner.EmitenteDocumento = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.EmitenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "EmitenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? TomadorDocumento
                                    {
                                        get => _inner.TomadorDocumento;
                                        set
                                        {
                                            if (_inner.TomadorDocumento != value)
                                            {
                                                _inner.TomadorDocumento = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.TomadorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "TomadorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? TransportadorDocumento
                                    {
                                        get => _inner.TransportadorDocumento;
                                        set
                                        {
                                            if (_inner.TransportadorDocumento != value)
                                            {
                                                _inner.TransportadorDocumento = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.TransportadorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "TransportadorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? UFInicio
                                    {
                                        get => _inner.UFInicio;
                                        set
                                        {
                                            if (_inner.UFInicio != value)
                                            {
                                                _inner.UFInicio = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.UFInicio) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "UFInicio", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? UFFim
                                    {
                                        get => _inner.UFFim;
                                        set
                                        {
                                            if (_inner.UFFim != value)
                                            {
                                                _inner.UFFim = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.UFFim) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "UFFim", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? MunicipioInicioCodigoIbge
                                    {
                                        get => _inner.MunicipioInicioCodigoIbge;
                                        set
                                        {
                                            if (_inner.MunicipioInicioCodigoIbge != value)
                                            {
                                                _inner.MunicipioInicioCodigoIbge = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.MunicipioInicioCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "MunicipioInicioCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? MunicipioFimCodigoIbge
                                    {
                                        get => _inner.MunicipioFimCodigoIbge;
                                        set
                                        {
                                            if (_inner.MunicipioFimCodigoIbge != value)
                                            {
                                                _inner.MunicipioFimCodigoIbge = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.MunicipioFimCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "MunicipioFimCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? QuantidadeNFe
                                    {
                                        get => _inner.QuantidadeNFe;
                                        set
                                        {
                                            if (_inner.QuantidadeNFe != value)
                                            {
                                                _inner.QuantidadeNFe = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.QuantidadeNFe) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "QuantidadeNFe", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? QuantidadeCTe
                                    {
                                        get => _inner.QuantidadeCTe;
                                        set
                                        {
                                            if (_inner.QuantidadeCTe != value)
                                            {
                                                _inner.QuantidadeCTe = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.QuantidadeCTe) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "QuantidadeCTe", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? QuantidadeMDFe
                                    {
                                        get => _inner.QuantidadeMDFe;
                                        set
                                        {
                                            if (_inner.QuantidadeMDFe != value)
                                            {
                                                _inner.QuantidadeMDFe = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.QuantidadeMDFe) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "QuantidadeMDFe", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ValorCarga
                                    {
                                        get => _inner.ValorCarga;
                                        set
                                        {
                                            if (_inner.ValorCarga != value)
                                            {
                                                _inner.ValorCarga = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.ValorCarga) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "ValorCarga", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PesoBruto
                                    {
                                        get => _inner.PesoBruto;
                                        set
                                        {
                                            if (_inner.PesoBruto != value)
                                            {
                                                _inner.PesoBruto = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.PesoBruto) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "PesoBruto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.Volume) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "Volume", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? UltimaMensagem
                                    {
                                        get => _inner.UltimaMensagem;
                                        set
                                        {
                                            if (_inner.UltimaMensagem != value)
                                            {
                                                _inner.UltimaMensagem = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.UltimaMensagem) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "UltimaMensagem", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime CriadoEmUtc
                                    {
                                        get => _inner.CriadoEmUtc;
                                        set
                                        {
                                            if (_inner.CriadoEmUtc != value)
                                            {
                                                _inner.CriadoEmUtc = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.CriadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "CriadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? AtualizadoEmUtc
                                    {
                                        get => _inner.AtualizadoEmUtc;
                                        set
                                        {
                                            if (_inner.AtualizadoEmUtc != value)
                                            {
                                                _inner.AtualizadoEmUtc = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.AtualizadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "AtualizadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ConcluidoEmUtc
                                    {
                                        get => _inner.ConcluidoEmUtc;
                                        set
                                        {
                                            if (_inner.ConcluidoEmUtc != value)
                                            {
                                                _inner.ConcluidoEmUtc = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.ConcluidoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "ConcluidoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporte", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration