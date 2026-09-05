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
                    public static class DocumentoFiscalOriginarioTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong DocumentoFiscalId = 1UL << 1;
            public const ulong CorrelationId = 1UL << 2;
            public const ulong SourceApplication = 1UL << 3;
            public const ulong SourceModule = 1UL << 4;
            public const ulong SourceMessageId = 1UL << 5;
            public const ulong TipoDocumento = 1UL << 6;
            public const ulong ChaveAcesso = 1UL << 7;
            public const ulong Numero = 1UL << 8;
            public const ulong Serie = 1UL << 9;
            public const ulong EmitenteDocumento = 1UL << 10;
            public const ulong DestinatarioDocumento = 1UL << 11;
            public const ulong ValorDocumento = 1UL << 12;
            public const ulong PesoBruto = 1UL << 13;
            public const ulong Volume = 1UL << 14;
            public const ulong SnapshotJson = 1UL << 15;
            public const ulong Status = 1UL << 16;
            public const ulong TenantID = 1UL << 17;
            public const ulong Deleted = 1UL << 18;
            public const ulong Changed = 1UL << 19;
            public const ulong UserId = 1UL << 20;
        }

        public partial class DocumentoFiscalOriginarioDecorator : IDocumentoFiscalOriginarioEntity
{

                        private readonly IDocumentoFiscalOriginarioEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public DocumentoFiscalOriginarioDecorator(IDocumentoFiscalOriginarioEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public DocumentoFiscalOriginarioDecorator(
                            IDocumentoFiscalOriginarioEntity inner,
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? DocumentoFiscalId
                                    {
                                        get => _inner.DocumentoFiscalId;
                                        set
                                        {
                                            if (_inner.DocumentoFiscalId != value)
                                            {
                                                _inner.DocumentoFiscalId = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.DocumentoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "DocumentoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.SourceApplication) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "SourceApplication", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SourceModule
                                    {
                                        get => _inner.SourceModule;
                                        set
                                        {
                                            if (_inner.SourceModule != value)
                                            {
                                                _inner.SourceModule = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.SourceModule) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "SourceModule", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.SourceMessageId) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "SourceMessageId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TipoDocumento
                                    {
                                        get => _inner.TipoDocumento;
                                        set
                                        {
                                            if (_inner.TipoDocumento != value)
                                            {
                                                _inner.TipoDocumento = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.TipoDocumento) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "TipoDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ChaveAcesso
                                    {
                                        get => _inner.ChaveAcesso;
                                        set
                                        {
                                            if (_inner.ChaveAcesso != value)
                                            {
                                                _inner.ChaveAcesso = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Numero
                                    {
                                        get => _inner.Numero;
                                        set
                                        {
                                            if (_inner.Numero != value)
                                            {
                                                _inner.Numero = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.Numero) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "Numero", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Serie
                                    {
                                        get => _inner.Serie;
                                        set
                                        {
                                            if (_inner.Serie != value)
                                            {
                                                _inner.Serie = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.Serie) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "Serie", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EmitenteDocumento
                                    {
                                        get => _inner.EmitenteDocumento;
                                        set
                                        {
                                            if (_inner.EmitenteDocumento != value)
                                            {
                                                _inner.EmitenteDocumento = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.EmitenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "EmitenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DestinatarioDocumento
                                    {
                                        get => _inner.DestinatarioDocumento;
                                        set
                                        {
                                            if (_inner.DestinatarioDocumento != value)
                                            {
                                                _inner.DestinatarioDocumento = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.DestinatarioDocumento) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "DestinatarioDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ValorDocumento
                                    {
                                        get => _inner.ValorDocumento;
                                        set
                                        {
                                            if (_inner.ValorDocumento != value)
                                            {
                                                _inner.ValorDocumento = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.ValorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "ValorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.PesoBruto) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "PesoBruto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.Volume) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "Volume", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SnapshotJson
                                    {
                                        get => _inner.SnapshotJson;
                                        set
                                        {
                                            if (_inner.SnapshotJson != value)
                                            {
                                                _inner.SnapshotJson = value;
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.SnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "SnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalOriginarioTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscalOriginario", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration