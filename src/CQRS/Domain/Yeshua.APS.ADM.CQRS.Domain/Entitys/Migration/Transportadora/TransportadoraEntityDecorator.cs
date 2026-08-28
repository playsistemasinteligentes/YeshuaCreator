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
                    public static class TransportadoraTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TRA_ID = 1UL << 1;
            public const ulong TRA_NOME = 1UL << 2;
            public const ulong TRA_EMAIL = 1UL << 3;
            public const ulong TRA_RESPONSAVEL = 1UL << 4;
            public const ulong TRA_FONE = 1UL << 5;
            public const ulong TRA_ID_INTEGRACAO = 1UL << 6;
            public const ulong TRA_ID_INTEGRACAO_ERP = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class TransportadoraDecorator : ITransportadoraEntity
{

                        private readonly ITransportadoraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TransportadoraDecorator(ITransportadoraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TransportadoraDecorator(
                            ITransportadoraEntity inner,
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
                                                if ((_trackingMask & TransportadoraTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TRA_ID
                                    {
                                        get => _inner.TRA_ID;
                                        set
                                        {
                                            if (_inner.TRA_ID != value)
                                            {
                                                _inner.TRA_ID = value;
                                                if ((_trackingMask & TransportadoraTrackingFields.TRA_ID) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "TRA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TRA_NOME
                                    {
                                        get => _inner.TRA_NOME;
                                        set
                                        {
                                            if (_inner.TRA_NOME != value)
                                            {
                                                _inner.TRA_NOME = value;
                                                if ((_trackingMask & TransportadoraTrackingFields.TRA_NOME) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "TRA_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TRA_EMAIL
                                    {
                                        get => _inner.TRA_EMAIL;
                                        set
                                        {
                                            if (_inner.TRA_EMAIL != value)
                                            {
                                                _inner.TRA_EMAIL = value;
                                                if ((_trackingMask & TransportadoraTrackingFields.TRA_EMAIL) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "TRA_EMAIL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TRA_RESPONSAVEL
                                    {
                                        get => _inner.TRA_RESPONSAVEL;
                                        set
                                        {
                                            if (_inner.TRA_RESPONSAVEL != value)
                                            {
                                                _inner.TRA_RESPONSAVEL = value;
                                                if ((_trackingMask & TransportadoraTrackingFields.TRA_RESPONSAVEL) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "TRA_RESPONSAVEL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TRA_FONE
                                    {
                                        get => _inner.TRA_FONE;
                                        set
                                        {
                                            if (_inner.TRA_FONE != value)
                                            {
                                                _inner.TRA_FONE = value;
                                                if ((_trackingMask & TransportadoraTrackingFields.TRA_FONE) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "TRA_FONE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TRA_ID_INTEGRACAO
                                    {
                                        get => _inner.TRA_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.TRA_ID_INTEGRACAO != value)
                                            {
                                                _inner.TRA_ID_INTEGRACAO = value;
                                                if ((_trackingMask & TransportadoraTrackingFields.TRA_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "TRA_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TRA_ID_INTEGRACAO_ERP
                                    {
                                        get => _inner.TRA_ID_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.TRA_ID_INTEGRACAO_ERP != value)
                                            {
                                                _inner.TRA_ID_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & TransportadoraTrackingFields.TRA_ID_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "TRA_ID_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TransportadoraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TransportadoraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TransportadoraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TransportadoraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Transportadora", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration