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
                    public static class CertificadoDigitalTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Apelido = 1UL << 1;
            public const ulong DocumentoTitular = 1UL << 2;
            public const ulong StorageKey = 1UL << 3;
            public const ulong Thumbprint = 1UL << 4;
            public const ulong ValidoDe = 1UL << 5;
            public const ulong ValidoAte = 1UL << 6;
            public const ulong Ativo = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class CertificadoDigitalDecorator : ICertificadoDigitalEntity
{

                        private readonly ICertificadoDigitalEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CertificadoDigitalDecorator(ICertificadoDigitalEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CertificadoDigitalDecorator(
                            ICertificadoDigitalEntity inner,
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
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Apelido
                                    {
                                        get => _inner.Apelido;
                                        set
                                        {
                                            if (_inner.Apelido != value)
                                            {
                                                _inner.Apelido = value;
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.Apelido) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "Apelido", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DocumentoTitular
                                    {
                                        get => _inner.DocumentoTitular;
                                        set
                                        {
                                            if (_inner.DocumentoTitular != value)
                                            {
                                                _inner.DocumentoTitular = value;
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.DocumentoTitular) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "DocumentoTitular", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string StorageKey
                                    {
                                        get => _inner.StorageKey;
                                        set
                                        {
                                            if (_inner.StorageKey != value)
                                            {
                                                _inner.StorageKey = value;
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.StorageKey) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "StorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Thumbprint
                                    {
                                        get => _inner.Thumbprint;
                                        set
                                        {
                                            if (_inner.Thumbprint != value)
                                            {
                                                _inner.Thumbprint = value;
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.Thumbprint) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "Thumbprint", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ValidoDe
                                    {
                                        get => _inner.ValidoDe;
                                        set
                                        {
                                            if (_inner.ValidoDe != value)
                                            {
                                                _inner.ValidoDe = value;
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.ValidoDe) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "ValidoDe", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ValidoAte
                                    {
                                        get => _inner.ValidoAte;
                                        set
                                        {
                                            if (_inner.ValidoAte != value)
                                            {
                                                _inner.ValidoAte = value;
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.ValidoAte) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "ValidoAte", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Ativo
                                    {
                                        get => _inner.Ativo;
                                        set
                                        {
                                            if (_inner.Ativo != value)
                                            {
                                                _inner.Ativo = value;
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.Ativo) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "Ativo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CertificadoDigitalTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CertificadoDigital", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration