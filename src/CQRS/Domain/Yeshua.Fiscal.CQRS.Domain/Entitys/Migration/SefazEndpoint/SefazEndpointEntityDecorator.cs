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
                    public static class SefazEndpointTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ProdutoFiscal = 1UL << 1;
            public const ulong UF = 1UL << 2;
            public const ulong Ambiente = 1UL << 3;
            public const ulong Servico = 1UL << 4;
            public const ulong Versao = 1UL << 5;
            public const ulong Url = 1UL << 6;
            public const ulong Ativo = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class SefazEndpointDecorator : ISefazEndpointEntity
{

                        private readonly ISefazEndpointEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public SefazEndpointDecorator(ISefazEndpointEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public SefazEndpointDecorator(
                            ISefazEndpointEntity inner,
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
                                                if ((_trackingMask & SefazEndpointTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SefazEndpointTrackingFields.ProdutoFiscal) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "ProdutoFiscal", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UF
                                    {
                                        get => _inner.UF;
                                        set
                                        {
                                            if (_inner.UF != value)
                                            {
                                                _inner.UF = value;
                                                if ((_trackingMask & SefazEndpointTrackingFields.UF) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "UF", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SefazEndpointTrackingFields.Ambiente) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "Ambiente", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Servico
                                    {
                                        get => _inner.Servico;
                                        set
                                        {
                                            if (_inner.Servico != value)
                                            {
                                                _inner.Servico = value;
                                                if ((_trackingMask & SefazEndpointTrackingFields.Servico) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "Servico", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Versao
                                    {
                                        get => _inner.Versao;
                                        set
                                        {
                                            if (_inner.Versao != value)
                                            {
                                                _inner.Versao = value;
                                                if ((_trackingMask & SefazEndpointTrackingFields.Versao) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "Versao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Url
                                    {
                                        get => _inner.Url;
                                        set
                                        {
                                            if (_inner.Url != value)
                                            {
                                                _inner.Url = value;
                                                if ((_trackingMask & SefazEndpointTrackingFields.Url) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "Url", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SefazEndpointTrackingFields.Ativo) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "Ativo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SefazEndpointTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SefazEndpointTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SefazEndpointTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SefazEndpointTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("SefazEndpoint", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration