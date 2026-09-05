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
                    public static class DocumentoFiscalTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CorrelationId = 1UL << 1;
            public const ulong ProdutoFiscal = 1UL << 2;
            public const ulong ChaveAcesso = 1UL << 3;
            public const ulong Serie = 1UL << 4;
            public const ulong Numero = 1UL << 5;
            public const ulong Ambiente = 1UL << 6;
            public const ulong UFEmitente = 1UL << 7;
            public const ulong EmitenteDocumento = 1UL << 8;
            public const ulong DestinatarioDocumento = 1UL << 9;
            public const ulong XmlStorageKey = 1UL << 10;
            public const ulong XmlHash = 1UL << 11;
            public const ulong ProtocoloAutorizacao = 1UL << 12;
            public const ulong CodigoRetorno = 1UL << 13;
            public const ulong MensagemRetorno = 1UL << 14;
            public const ulong Status = 1UL << 15;
            public const ulong TenantID = 1UL << 16;
            public const ulong Deleted = 1UL << 17;
            public const ulong Changed = 1UL << 18;
            public const ulong UserId = 1UL << 19;
        }

        public partial class DocumentoFiscalDecorator : IDocumentoFiscalEntity
{

                        private readonly IDocumentoFiscalEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public DocumentoFiscalDecorator(IDocumentoFiscalEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public DocumentoFiscalDecorator(
                            IDocumentoFiscalEntity inner,
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.ProdutoFiscal) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "ProdutoFiscal", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Serie
                                    {
                                        get => _inner.Serie;
                                        set
                                        {
                                            if (_inner.Serie != value)
                                            {
                                                _inner.Serie = value;
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.Serie) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "Serie", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Numero
                                    {
                                        get => _inner.Numero;
                                        set
                                        {
                                            if (_inner.Numero != value)
                                            {
                                                _inner.Numero = value;
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.Numero) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "Numero", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.Ambiente) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "Ambiente", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UFEmitente
                                    {
                                        get => _inner.UFEmitente;
                                        set
                                        {
                                            if (_inner.UFEmitente != value)
                                            {
                                                _inner.UFEmitente = value;
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.UFEmitente) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "UFEmitente", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.EmitenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "EmitenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.DestinatarioDocumento) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "DestinatarioDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string XmlStorageKey
                                    {
                                        get => _inner.XmlStorageKey;
                                        set
                                        {
                                            if (_inner.XmlStorageKey != value)
                                            {
                                                _inner.XmlStorageKey = value;
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.XmlStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "XmlStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string XmlHash
                                    {
                                        get => _inner.XmlHash;
                                        set
                                        {
                                            if (_inner.XmlHash != value)
                                            {
                                                _inner.XmlHash = value;
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.XmlHash) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "XmlHash", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ProtocoloAutorizacao
                                    {
                                        get => _inner.ProtocoloAutorizacao;
                                        set
                                        {
                                            if (_inner.ProtocoloAutorizacao != value)
                                            {
                                                _inner.ProtocoloAutorizacao = value;
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.ProtocoloAutorizacao) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "ProtocoloAutorizacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CodigoRetorno
                                    {
                                        get => _inner.CodigoRetorno;
                                        set
                                        {
                                            if (_inner.CodigoRetorno != value)
                                            {
                                                _inner.CodigoRetorno = value;
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.CodigoRetorno) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "CodigoRetorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MensagemRetorno
                                    {
                                        get => _inner.MensagemRetorno;
                                        set
                                        {
                                            if (_inner.MensagemRetorno != value)
                                            {
                                                _inner.MensagemRetorno = value;
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.MensagemRetorno) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "MensagemRetorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & DocumentoFiscalTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("DocumentoFiscal", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration