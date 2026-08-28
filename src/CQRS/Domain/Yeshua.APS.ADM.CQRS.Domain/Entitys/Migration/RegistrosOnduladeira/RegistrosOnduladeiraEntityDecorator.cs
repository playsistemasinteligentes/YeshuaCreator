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
                    public static class RegistrosOnduladeiraTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong REG_ID = 1UL << 1;
            public const ulong REG_RESPOSTA = 1UL << 2;
            public const ulong REG_STATUS = 1UL << 3;
            public const ulong REG_DATA_INICIO = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class RegistrosOnduladeiraDecorator : IRegistrosOnduladeiraEntity
{

                        private readonly IRegistrosOnduladeiraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RegistrosOnduladeiraDecorator(IRegistrosOnduladeiraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RegistrosOnduladeiraDecorator(
                            IRegistrosOnduladeiraEntity inner,
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
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int REG_ID
                                    {
                                        get => _inner.REG_ID;
                                        set
                                        {
                                            if (_inner.REG_ID != value)
                                            {
                                                _inner.REG_ID = value;
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.REG_ID) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "REG_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REG_RESPOSTA
                                    {
                                        get => _inner.REG_RESPOSTA;
                                        set
                                        {
                                            if (_inner.REG_RESPOSTA != value)
                                            {
                                                _inner.REG_RESPOSTA = value;
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.REG_RESPOSTA) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "REG_RESPOSTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REG_STATUS
                                    {
                                        get => _inner.REG_STATUS;
                                        set
                                        {
                                            if (_inner.REG_STATUS != value)
                                            {
                                                _inner.REG_STATUS = value;
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.REG_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "REG_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime REG_DATA_INICIO
                                    {
                                        get => _inner.REG_DATA_INICIO;
                                        set
                                        {
                                            if (_inner.REG_DATA_INICIO != value)
                                            {
                                                _inner.REG_DATA_INICIO = value;
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.REG_DATA_INICIO) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "REG_DATA_INICIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RegistrosOnduladeiraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("RegistrosOnduladeira", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration