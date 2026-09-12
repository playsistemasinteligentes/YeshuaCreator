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
                    public static class ContingenciaFiscalTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong EmissaoFiscalTransporteId = 1UL << 1;
            public const ulong EntradaFiscalContingenciaId = 1UL << 2;
            public const ulong CorrelationId = 1UL << 3;
            public const ulong CargaId = 1UL << 4;
            public const ulong TipoSolicitante = 1UL << 5;
            public const ulong Ambiente = 1UL << 6;
            public const ulong EmitenteDocumento = 1UL << 7;
            public const ulong TomadorDocumento = 1UL << 8;
            public const ulong TransportadorDocumento = 1UL << 9;
            public const ulong QuantidadeDocumentos = 1UL << 10;
            public const ulong QuantidadeCTe = 1UL << 11;
            public const ulong QuantidadeMDFe = 1UL << 12;
            public const ulong ValorCarga = 1UL << 13;
            public const ulong PesoBruto = 1UL << 14;
            public const ulong UltimaMensagem = 1UL << 15;
            public const ulong CriadoEmUtc = 1UL << 16;
            public const ulong AtualizadoEmUtc = 1UL << 17;
            public const ulong ConcluidoEmUtc = 1UL << 18;
            public const ulong Status = 1UL << 19;
            public const ulong TenantID = 1UL << 20;
            public const ulong Deleted = 1UL << 21;
            public const ulong Changed = 1UL << 22;
            public const ulong UserId = 1UL << 23;
        }

        public partial class ContingenciaFiscalDecorator : IContingenciaFiscalEntity
{

                        private readonly IContingenciaFiscalEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ContingenciaFiscalDecorator(IContingenciaFiscalEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ContingenciaFiscalDecorator(
                            IContingenciaFiscalEntity inner,
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? EmissaoFiscalTransporteId
                                    {
                                        get => _inner.EmissaoFiscalTransporteId;
                                        set
                                        {
                                            if (_inner.EmissaoFiscalTransporteId != value)
                                            {
                                                _inner.EmissaoFiscalTransporteId = value;
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.EmissaoFiscalTransporteId) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "EmissaoFiscalTransporteId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? EntradaFiscalContingenciaId
                                    {
                                        get => _inner.EntradaFiscalContingenciaId;
                                        set
                                        {
                                            if (_inner.EntradaFiscalContingenciaId != value)
                                            {
                                                _inner.EntradaFiscalContingenciaId = value;
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.EntradaFiscalContingenciaId) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "EntradaFiscalContingenciaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CargaId
                                    {
                                        get => _inner.CargaId;
                                        set
                                        {
                                            if (_inner.CargaId != value)
                                            {
                                                _inner.CargaId = value;
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.CargaId) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "CargaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int TipoSolicitante
                                    {
                                        get => _inner.TipoSolicitante;
                                        set
                                        {
                                            if (_inner.TipoSolicitante != value)
                                            {
                                                _inner.TipoSolicitante = value;
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.TipoSolicitante) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "TipoSolicitante", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.Ambiente) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "Ambiente", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.EmitenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "EmitenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.TomadorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "TomadorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.TransportadorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "TransportadorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? QuantidadeDocumentos
                                    {
                                        get => _inner.QuantidadeDocumentos;
                                        set
                                        {
                                            if (_inner.QuantidadeDocumentos != value)
                                            {
                                                _inner.QuantidadeDocumentos = value;
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.QuantidadeDocumentos) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "QuantidadeDocumentos", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.QuantidadeCTe) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "QuantidadeCTe", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.QuantidadeMDFe) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "QuantidadeMDFe", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.ValorCarga) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "ValorCarga", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.PesoBruto) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "PesoBruto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.UltimaMensagem) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "UltimaMensagem", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.CriadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "CriadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.AtualizadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "AtualizadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.ConcluidoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "ConcluidoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ContingenciaFiscalTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ContingenciaFiscal", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration