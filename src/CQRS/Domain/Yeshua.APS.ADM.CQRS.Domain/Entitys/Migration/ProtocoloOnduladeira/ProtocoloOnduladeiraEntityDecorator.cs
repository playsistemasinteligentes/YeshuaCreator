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
                    public static class ProtocoloOnduladeiraTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong PTO_ID = 1UL << 1;
            public const ulong PTO_CHAVE = 1UL << 2;
            public const ulong MAQ_ID = 1UL << 3;
            public const ulong PTO_COMANDO = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class ProtocoloOnduladeiraDecorator : IProtocoloOnduladeiraEntity
{

                        private readonly IProtocoloOnduladeiraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ProtocoloOnduladeiraDecorator(IProtocoloOnduladeiraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ProtocoloOnduladeiraDecorator(
                            IProtocoloOnduladeiraEntity inner,
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
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PTO_ID
                                    {
                                        get => _inner.PTO_ID;
                                        set
                                        {
                                            if (_inner.PTO_ID != value)
                                            {
                                                _inner.PTO_ID = value;
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.PTO_ID) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "PTO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PTO_CHAVE
                                    {
                                        get => _inner.PTO_CHAVE;
                                        set
                                        {
                                            if (_inner.PTO_CHAVE != value)
                                            {
                                                _inner.PTO_CHAVE = value;
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.PTO_CHAVE) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "PTO_CHAVE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID
                                    {
                                        get => _inner.MAQ_ID;
                                        set
                                        {
                                            if (_inner.MAQ_ID != value)
                                            {
                                                _inner.MAQ_ID = value;
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PTO_COMANDO
                                    {
                                        get => _inner.PTO_COMANDO;
                                        set
                                        {
                                            if (_inner.PTO_COMANDO != value)
                                            {
                                                _inner.PTO_COMANDO = value;
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.PTO_COMANDO) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "PTO_COMANDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProtocoloOnduladeiraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ProtocoloOnduladeira", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration