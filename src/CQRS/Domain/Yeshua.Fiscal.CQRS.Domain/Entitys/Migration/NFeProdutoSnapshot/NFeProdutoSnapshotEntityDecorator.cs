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
                    public static class NFeProdutoSnapshotTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong DocumentoFiscalOriginarioId = 1UL << 1;
            public const ulong CorrelationId = 1UL << 2;
            public const ulong CargaId = 1UL << 3;
            public const ulong PedidoId = 1UL << 4;
            public const ulong ChaveAcesso = 1UL << 5;
            public const ulong EmitenteDocumento = 1UL << 6;
            public const ulong DestinatarioDocumento = 1UL << 7;
            public const ulong UFOrigem = 1UL << 8;
            public const ulong UFDestino = 1UL << 9;
            public const ulong MunicipioOrigemCodigoIbge = 1UL << 10;
            public const ulong MunicipioDestinoCodigoIbge = 1UL << 11;
            public const ulong ValorDocumento = 1UL << 12;
            public const ulong PesoBruto = 1UL << 13;
            public const ulong Volume = 1UL << 14;
            public const ulong XmlStorageKey = 1UL << 15;
            public const ulong SnapshotJson = 1UL << 16;
            public const ulong Status = 1UL << 17;
            public const ulong TenantID = 1UL << 18;
            public const ulong Deleted = 1UL << 19;
            public const ulong Changed = 1UL << 20;
            public const ulong UserId = 1UL << 21;
        }

        public partial class NFeProdutoSnapshotDecorator : INFeProdutoSnapshotEntity
{

                        private readonly INFeProdutoSnapshotEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public NFeProdutoSnapshotDecorator(INFeProdutoSnapshotEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public NFeProdutoSnapshotDecorator(
                            INFeProdutoSnapshotEntity inner,
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.DocumentoFiscalOriginarioId) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "DocumentoFiscalOriginarioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.CargaId) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "CargaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PedidoId
                                    {
                                        get => _inner.PedidoId;
                                        set
                                        {
                                            if (_inner.PedidoId != value)
                                            {
                                                _inner.PedidoId = value;
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.PedidoId) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "PedidoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.EmitenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "EmitenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.DestinatarioDocumento) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "DestinatarioDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UFOrigem
                                    {
                                        get => _inner.UFOrigem;
                                        set
                                        {
                                            if (_inner.UFOrigem != value)
                                            {
                                                _inner.UFOrigem = value;
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.UFOrigem) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "UFOrigem", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UFDestino
                                    {
                                        get => _inner.UFDestino;
                                        set
                                        {
                                            if (_inner.UFDestino != value)
                                            {
                                                _inner.UFDestino = value;
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.UFDestino) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "UFDestino", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MunicipioOrigemCodigoIbge
                                    {
                                        get => _inner.MunicipioOrigemCodigoIbge;
                                        set
                                        {
                                            if (_inner.MunicipioOrigemCodigoIbge != value)
                                            {
                                                _inner.MunicipioOrigemCodigoIbge = value;
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.MunicipioOrigemCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "MunicipioOrigemCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MunicipioDestinoCodigoIbge
                                    {
                                        get => _inner.MunicipioDestinoCodigoIbge;
                                        set
                                        {
                                            if (_inner.MunicipioDestinoCodigoIbge != value)
                                            {
                                                _inner.MunicipioDestinoCodigoIbge = value;
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.MunicipioDestinoCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "MunicipioDestinoCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.ValorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "ValorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.PesoBruto) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "PesoBruto", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.Volume) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "Volume", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.XmlStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "XmlStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.SnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "SnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & NFeProdutoSnapshotTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("NFeProdutoSnapshot", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration