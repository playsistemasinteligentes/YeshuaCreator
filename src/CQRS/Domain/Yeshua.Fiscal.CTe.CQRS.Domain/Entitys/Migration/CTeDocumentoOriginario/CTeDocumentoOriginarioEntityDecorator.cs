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
            public const ulong TipoDocumento = 1UL << 2;
            public const ulong ChaveAcesso = 1UL << 3;
            public const ulong Numero = 1UL << 4;
            public const ulong Serie = 1UL << 5;
            public const ulong EmitenteDocumento = 1UL << 6;
            public const ulong DestinatarioDocumento = 1UL << 7;
            public const ulong ValorDocumento = 1UL << 8;
            public const ulong PesoBruto = 1UL << 9;
            public const ulong SnapshotJson = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
        }

        public partial class CTeDocumentoOriginarioDecorator : ICTeDocumentoOriginarioEntity
{

                        private readonly ICTeDocumentoOriginarioEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
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
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "CTeSolicitacaoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "TipoDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.Numero) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Numero", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.Serie) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Serie", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.EmitenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "EmitenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.DestinatarioDocumento) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "DestinatarioDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "ValorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "PesoBruto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.SnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "SnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeDocumentoOriginarioTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("CTeDocumentoOriginario", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration