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
                    public static class EmissaoFiscalTransporteDocumentoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong EmissaoFiscalTransporteId = 1UL << 1;
            public const ulong DocumentoFiscalId = 1UL << 2;
            public const ulong DocumentoFiscalOriginarioId = 1UL << 3;
            public const ulong NFeProdutoSnapshotId = 1UL << 4;
            public const ulong ProdutoFiscal = 1UL << 5;
            public const ulong Papel = 1UL << 6;
            public const ulong TipoEvento = 1UL << 7;
            public const ulong ChaveAcesso = 1UL << 8;
            public const ulong XmlStorageKey = 1UL << 9;
            public const ulong PdfStorageKey = 1UL << 10;
            public const ulong Protocolo = 1UL << 11;
            public const ulong CodigoRetorno = 1UL << 12;
            public const ulong MensagemRetorno = 1UL << 13;
            public const ulong CriadoEmUtc = 1UL << 14;
            public const ulong Status = 1UL << 15;
            public const ulong TenantID = 1UL << 16;
            public const ulong Deleted = 1UL << 17;
            public const ulong Changed = 1UL << 18;
            public const ulong UserId = 1UL << 19;
            public const ulong OperationalEntityId = 1UL << 20;
        }

        public static class EmissaoFiscalTransporteDocumentoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EmissaoFiscalTransporteId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DocumentoFiscalId = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification DocumentoFiscalOriginarioId = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification NFeProdutoSnapshotId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProdutoFiscal = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Papel = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TipoEvento = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ChaveAcesso = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification XmlStorageKey = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PdfStorageKey = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Protocolo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CodigoRetorno = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MensagemRetorno = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CriadoEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class EmissaoFiscalTransporteDocumentoDecorator : IEmissaoFiscalTransporteDocumentoEntity
{

                        private readonly IEmissaoFiscalTransporteDocumentoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public EmissaoFiscalTransporteDocumentoDecorator(IEmissaoFiscalTransporteDocumentoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public EmissaoFiscalTransporteDocumentoDecorator(
                            IEmissaoFiscalTransporteDocumentoEntity inner,
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
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int EmissaoFiscalTransporteId
                                    {
                                        get => _inner.EmissaoFiscalTransporteId;
                                        set
                                        {
                                            if (_inner.EmissaoFiscalTransporteId != value)
                                            {
                                                _inner.EmissaoFiscalTransporteId = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.EmissaoFiscalTransporteId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "EmissaoFiscalTransporteId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.EmissaoFiscalTransporteId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.DocumentoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "DocumentoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.DocumentoFiscalId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? DocumentoFiscalOriginarioId
                                    {
                                        get => _inner.DocumentoFiscalOriginarioId;
                                        set
                                        {
                                            if (_inner.DocumentoFiscalOriginarioId != value)
                                            {
                                                _inner.DocumentoFiscalOriginarioId = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.DocumentoFiscalOriginarioId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "DocumentoFiscalOriginarioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.DocumentoFiscalOriginarioId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? NFeProdutoSnapshotId
                                    {
                                        get => _inner.NFeProdutoSnapshotId;
                                        set
                                        {
                                            if (_inner.NFeProdutoSnapshotId != value)
                                            {
                                                _inner.NFeProdutoSnapshotId = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.NFeProdutoSnapshotId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "NFeProdutoSnapshotId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.NFeProdutoSnapshotId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int ProdutoFiscal
                                    {
                                        get => _inner.ProdutoFiscal;
                                        set
                                        {
                                            if (_inner.ProdutoFiscal != value)
                                            {
                                                _inner.ProdutoFiscal = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.ProdutoFiscal) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "ProdutoFiscal", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.ProdutoFiscal, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int Papel
                                    {
                                        get => _inner.Papel;
                                        set
                                        {
                                            if (_inner.Papel != value)
                                            {
                                                _inner.Papel = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.Papel) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "Papel", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.Papel, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? TipoEvento
                                    {
                                        get => _inner.TipoEvento;
                                        set
                                        {
                                            if (_inner.TipoEvento != value)
                                            {
                                                _inner.TipoEvento = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.TipoEvento) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "TipoEvento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.TipoEvento, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ChaveAcesso
                                    {
                                        get => _inner.ChaveAcesso;
                                        set
                                        {
                                            if (_inner.ChaveAcesso != value)
                                            {
                                                _inner.ChaveAcesso = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.ChaveAcesso, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? XmlStorageKey
                                    {
                                        get => _inner.XmlStorageKey;
                                        set
                                        {
                                            if (_inner.XmlStorageKey != value)
                                            {
                                                _inner.XmlStorageKey = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.XmlStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "XmlStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.XmlStorageKey, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PdfStorageKey
                                    {
                                        get => _inner.PdfStorageKey;
                                        set
                                        {
                                            if (_inner.PdfStorageKey != value)
                                            {
                                                _inner.PdfStorageKey = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.PdfStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "PdfStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.PdfStorageKey, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Protocolo
                                    {
                                        get => _inner.Protocolo;
                                        set
                                        {
                                            if (_inner.Protocolo != value)
                                            {
                                                _inner.Protocolo = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.Protocolo) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "Protocolo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.Protocolo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CodigoRetorno
                                    {
                                        get => _inner.CodigoRetorno;
                                        set
                                        {
                                            if (_inner.CodigoRetorno != value)
                                            {
                                                _inner.CodigoRetorno = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.CodigoRetorno) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "CodigoRetorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.CodigoRetorno, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MensagemRetorno
                                    {
                                        get => _inner.MensagemRetorno;
                                        set
                                        {
                                            if (_inner.MensagemRetorno != value)
                                            {
                                                _inner.MensagemRetorno = value;
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.MensagemRetorno) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "MensagemRetorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.MensagemRetorno, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.CriadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "CriadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.CriadoEmUtc, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.Status, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EmissaoFiscalTransporteDocumentoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("EmissaoFiscalTransporteDocumento", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EmissaoFiscalTransporteDocumentoOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration