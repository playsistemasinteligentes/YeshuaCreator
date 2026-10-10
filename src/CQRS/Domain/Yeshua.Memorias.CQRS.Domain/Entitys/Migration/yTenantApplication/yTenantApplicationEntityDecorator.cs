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
                    public static class yTenantApplicationTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ApplicationKey = 1UL << 1;
            public const ulong TenantID = 1UL << 2;
            public const ulong ValidUntil = 1UL << 3;
            public const ulong OperationalEntityId = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public partial class yTenantApplicationDecorator : IyTenantApplicationEntity
{

                        private readonly IyTenantApplicationEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yTenantApplicationDecorator(IyTenantApplicationEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yTenantApplicationDecorator(
                            IyTenantApplicationEntity inner,
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
                                                if ((_trackingMask & yTenantApplicationTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yTenantApplication", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ApplicationKey
                                    {
                                        get => _inner.ApplicationKey;
                                        set
                                        {
                                            if (_inner.ApplicationKey != value)
                                            {
                                                _inner.ApplicationKey = value;
                                                if ((_trackingMask & yTenantApplicationTrackingFields.ApplicationKey) != 0UL)
                                                    _logger.DomainValueChanged("yTenantApplication", "ApplicationKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yTenantApplicationTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yTenantApplication", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime ValidUntil
                                    {
                                        get => _inner.ValidUntil;
                                        set
                                        {
                                            if (_inner.ValidUntil != value)
                                            {
                                                _inner.ValidUntil = value;
                                                if ((_trackingMask & yTenantApplicationTrackingFields.ValidUntil) != 0UL)
                                                    _logger.DomainValueChanged("yTenantApplication", "ValidUntil", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public bool? Deleted
                                    {
                                        get => _inner.Deleted;
                                        set
                                        {
                                            if (_inner.Deleted != value)
                                            {
                                                _inner.Deleted = value;
                                                if ((_trackingMask & yTenantApplicationTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yTenantApplication", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yTenantApplicationTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yTenantApplication", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yTenantApplicationTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yTenantApplication", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration