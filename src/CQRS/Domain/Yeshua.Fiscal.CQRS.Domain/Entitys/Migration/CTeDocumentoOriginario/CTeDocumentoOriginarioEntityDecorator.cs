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
                    public static class CTeDocumentoOriginarioTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CTeSolicitacaoFiscalId = 1UL << 1;
            public const ulong DocumentoFiscalOriginarioId = 1UL << 2;
            public const ulong TipoDocumento = 1UL << 3;
            public const ulong ChaveAcesso = 1UL << 4;
            public const ulong Numero = 1UL << 5;
            public const ulong Serie = 1UL << 6;
            public const ulong EmitenteDocumento = 1UL << 7;
            public const ulong DestinatarioDocumento = 1UL << 8;
            public const ulong ValorDocumento = 1UL << 9;
            public const ulong PesoBruto = 1UL << 10;
            public const ulong SnapshotJson = 1UL << 11;
            public const ulong OperationalEntityId = 1UL << 12;
            public const ulong TenantID = 1UL << 13;
            public const ulong Deleted = 1UL << 14;
            public const ulong Changed = 1UL << 15;
            public const ulong UserId = 1UL << 16;
        }

        public static class CTeDocumentoOriginarioOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CTeSolicitacaoFiscalId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DocumentoFiscalOriginarioId = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification TipoDocumento = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification ChaveAcesso = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Numero = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Serie = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EmitenteDocumento = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification DestinatarioDocumento = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification ValorDocumento = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification PesoBruto = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SnapshotJson = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class CTeDocumentoOriginarioDecorator : ICTeDocumentoOriginarioEntity
{

                        private readonly ICTeDocumentoOriginarioEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CTeDocumentoOriginarioDecorator(ICTeDocumentoOriginarioEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CTeDocumentoOriginarioDecorator(
                            ICTeDocumentoOriginarioEntity inner,
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int CTeSolicitacaoFiscalId
                                    {
                                        get => _inner.CTeSolicitacaoFiscalId;
                                        set
                                        {
                                            if (_inner.CTeSolicitacaoFiscalId != value)
                                            {
                                                _inner.CTeSolicitacaoFiscalId = value;
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.CTeSolicitacaoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "CTeSolicitacaoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.CTeSolicitacaoFiscalId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.DocumentoFiscalOriginarioId) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "DocumentoFiscalOriginarioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.DocumentoFiscalOriginarioId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.TipoDocumento) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "TipoDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.TipoDocumento, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.ChaveAcesso, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Numero
                                    {
                                        get => _inner.Numero;
                                        set
                                        {
                                            if (_inner.Numero != value)
                                            {
                                                _inner.Numero = value;
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.Numero) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Numero", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.Numero, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Serie
                                    {
                                        get => _inner.Serie;
                                        set
                                        {
                                            if (_inner.Serie != value)
                                            {
                                                _inner.Serie = value;
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.Serie) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Serie", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.Serie, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.EmitenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "EmitenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.EmitenteDocumento, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.DestinatarioDocumento) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "DestinatarioDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.DestinatarioDocumento, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.ValorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "ValorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.ValorDocumento, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.PesoBruto) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "PesoBruto", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.PesoBruto, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.SnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "SnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.SnapshotJson, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeDocumentoOriginarioOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration