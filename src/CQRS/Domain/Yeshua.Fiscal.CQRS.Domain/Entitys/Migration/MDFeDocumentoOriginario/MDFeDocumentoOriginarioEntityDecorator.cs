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
                    public static class MDFeDocumentoOriginarioTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MDFeSolicitacaoFiscalId = 1UL << 1;
            public const ulong DocumentoFiscalOriginarioId = 1UL << 2;
            public const ulong TipoDocumento = 1UL << 3;
            public const ulong ChaveAcesso = 1UL << 4;
            public const ulong SnapshotJson = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class MDFeDocumentoOriginarioDecorator : IMDFeDocumentoOriginarioEntity
{

                        private readonly IMDFeDocumentoOriginarioEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MDFeDocumentoOriginarioDecorator(IMDFeDocumentoOriginarioEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MDFeDocumentoOriginarioDecorator(
                            IMDFeDocumentoOriginarioEntity inner,
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MDFeSolicitacaoFiscalId
                                    {
                                        get => _inner.MDFeSolicitacaoFiscalId;
                                        set
                                        {
                                            if (_inner.MDFeSolicitacaoFiscalId != value)
                                            {
                                                _inner.MDFeSolicitacaoFiscalId = value;
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.MDFeSolicitacaoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "MDFeSolicitacaoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.DocumentoFiscalOriginarioId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "DocumentoFiscalOriginarioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.TipoDocumento) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "TipoDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.SnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "SnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeDocumentoOriginarioTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeDocumentoOriginario", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration