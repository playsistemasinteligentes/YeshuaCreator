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
                    public static class EntradaFiscalContingenciaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CorrelationId = 1UL << 1;
            public const ulong CargaId = 1UL << 2;
            public const ulong TipoSolicitante = 1UL << 3;
            public const ulong Ambiente = 1UL << 4;
            public const ulong SourceApplication = 1UL << 5;
            public const ulong SourceModule = 1UL << 6;
            public const ulong SourceMessageId = 1UL << 7;
            public const ulong EmitenteFiscalDocumento = 1UL << 8;
            public const ulong TomadorDocumento = 1UL << 9;
            public const ulong TransportadorDocumento = 1UL << 10;
            public const ulong RemetenteDocumento = 1UL << 11;
            public const ulong DestinatarioDocumento = 1UL << 12;
            public const ulong UFInicio = 1UL << 13;
            public const ulong UFFim = 1UL << 14;
            public const ulong MunicipioInicioCodigoIbge = 1UL << 15;
            public const ulong MunicipioFimCodigoIbge = 1UL << 16;
            public const ulong RNTRC = 1UL << 17;
            public const ulong PlacaVeiculo = 1UL << 18;
            public const ulong UFVeiculo = 1UL << 19;
            public const ulong CondutorDocumento = 1UL << 20;
            public const ulong CondutorNome = 1UL << 21;
            public const ulong QuantidadeDocumentos = 1UL << 22;
            public const ulong ValorCarga = 1UL << 23;
            public const ulong PesoBruto = 1UL << 24;
            public const ulong Volume = 1UL << 25;
            public const ulong PendenciasJson = 1UL << 26;
            public const ulong SnapshotJson = 1UL << 27;
            public const ulong EmissaoFiscalCorrelationId = 1UL << 28;
            public const ulong EmissaoFiscalSagaId = 1UL << 29;
            public const ulong CriadoEmUtc = 1UL << 30;
            public const ulong AtualizadoEmUtc = 1UL << 31;
            public const ulong Status = 1UL << 32;
            public const ulong TenantID = 1UL << 33;
            public const ulong Deleted = 1UL << 34;
            public const ulong Changed = 1UL << 35;
            public const ulong UserId = 1UL << 36;
        }

        public partial class EntradaFiscalContingenciaDecorator : IEntradaFiscalContingenciaEntity
{

                        private readonly IEntradaFiscalContingenciaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public EntradaFiscalContingenciaDecorator(IEntradaFiscalContingenciaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public EntradaFiscalContingenciaDecorator(
                            IEntradaFiscalContingenciaEntity inner,
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.CargaId) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "CargaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.TipoSolicitante) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "TipoSolicitante", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.Ambiente) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "Ambiente", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SourceApplication
                                    {
                                        get => _inner.SourceApplication;
                                        set
                                        {
                                            if (_inner.SourceApplication != value)
                                            {
                                                _inner.SourceApplication = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.SourceApplication) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "SourceApplication", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? SourceModule
                                    {
                                        get => _inner.SourceModule;
                                        set
                                        {
                                            if (_inner.SourceModule != value)
                                            {
                                                _inner.SourceModule = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.SourceModule) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "SourceModule", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SourceMessageId
                                    {
                                        get => _inner.SourceMessageId;
                                        set
                                        {
                                            if (_inner.SourceMessageId != value)
                                            {
                                                _inner.SourceMessageId = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.SourceMessageId) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "SourceMessageId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? EmitenteFiscalDocumento
                                    {
                                        get => _inner.EmitenteFiscalDocumento;
                                        set
                                        {
                                            if (_inner.EmitenteFiscalDocumento != value)
                                            {
                                                _inner.EmitenteFiscalDocumento = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.EmitenteFiscalDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "EmitenteFiscalDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.TomadorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "TomadorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.TransportadorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "TransportadorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? RemetenteDocumento
                                    {
                                        get => _inner.RemetenteDocumento;
                                        set
                                        {
                                            if (_inner.RemetenteDocumento != value)
                                            {
                                                _inner.RemetenteDocumento = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.RemetenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "RemetenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? DestinatarioDocumento
                                    {
                                        get => _inner.DestinatarioDocumento;
                                        set
                                        {
                                            if (_inner.DestinatarioDocumento != value)
                                            {
                                                _inner.DestinatarioDocumento = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.DestinatarioDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "DestinatarioDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.UFInicio) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "UFInicio", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.UFFim) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "UFFim", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.MunicipioInicioCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "MunicipioInicioCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.MunicipioFimCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "MunicipioFimCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? RNTRC
                                    {
                                        get => _inner.RNTRC;
                                        set
                                        {
                                            if (_inner.RNTRC != value)
                                            {
                                                _inner.RNTRC = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.RNTRC) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "RNTRC", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? PlacaVeiculo
                                    {
                                        get => _inner.PlacaVeiculo;
                                        set
                                        {
                                            if (_inner.PlacaVeiculo != value)
                                            {
                                                _inner.PlacaVeiculo = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.PlacaVeiculo) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "PlacaVeiculo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? UFVeiculo
                                    {
                                        get => _inner.UFVeiculo;
                                        set
                                        {
                                            if (_inner.UFVeiculo != value)
                                            {
                                                _inner.UFVeiculo = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.UFVeiculo) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "UFVeiculo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? CondutorDocumento
                                    {
                                        get => _inner.CondutorDocumento;
                                        set
                                        {
                                            if (_inner.CondutorDocumento != value)
                                            {
                                                _inner.CondutorDocumento = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.CondutorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "CondutorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? CondutorNome
                                    {
                                        get => _inner.CondutorNome;
                                        set
                                        {
                                            if (_inner.CondutorNome != value)
                                            {
                                                _inner.CondutorNome = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.CondutorNome) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "CondutorNome", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.QuantidadeDocumentos) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "QuantidadeDocumentos", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.ValorCarga) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "ValorCarga", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.PesoBruto) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "PesoBruto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.Volume) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "Volume", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? PendenciasJson
                                    {
                                        get => _inner.PendenciasJson;
                                        set
                                        {
                                            if (_inner.PendenciasJson != value)
                                            {
                                                _inner.PendenciasJson = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.PendenciasJson) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "PendenciasJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? SnapshotJson
                                    {
                                        get => _inner.SnapshotJson;
                                        set
                                        {
                                            if (_inner.SnapshotJson != value)
                                            {
                                                _inner.SnapshotJson = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.SnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "SnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? EmissaoFiscalCorrelationId
                                    {
                                        get => _inner.EmissaoFiscalCorrelationId;
                                        set
                                        {
                                            if (_inner.EmissaoFiscalCorrelationId != value)
                                            {
                                                _inner.EmissaoFiscalCorrelationId = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.EmissaoFiscalCorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "EmissaoFiscalCorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? EmissaoFiscalSagaId
                                    {
                                        get => _inner.EmissaoFiscalSagaId;
                                        set
                                        {
                                            if (_inner.EmissaoFiscalSagaId != value)
                                            {
                                                _inner.EmissaoFiscalSagaId = value;
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.EmissaoFiscalSagaId) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "EmissaoFiscalSagaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.CriadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "CriadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.AtualizadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "AtualizadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EntradaFiscalContingenciaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("EntradaFiscalContingencia", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration