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
                    public static class yUserGrantTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong PerfilId = 1UL << 1;
            public const ulong GrantId = 1UL << 2;
            public const ulong CanGrant = 1UL << 3;
            public const ulong CanCreate = 1UL << 4;
            public const ulong CanRead = 1UL << 5;
            public const ulong CanUpdate = 1UL << 6;
            public const ulong CanDelete = 1UL << 7;
            public const ulong ValidUntil = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
        }

        public partial class yUserGrantDecorator : IyUserGrantEntity
{

                        private readonly IyUserGrantEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yUserGrantDecorator(IyUserGrantEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yUserGrantDecorator(
                            IyUserGrantEntity inner,
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
                                                if ((_trackingMask & yUserGrantTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PerfilId
                                    {
                                        get => _inner.PerfilId;
                                        set
                                        {
                                            if (_inner.PerfilId != value)
                                            {
                                                _inner.PerfilId = value;
                                                if ((_trackingMask & yUserGrantTrackingFields.PerfilId) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "PerfilId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GrantId
                                    {
                                        get => _inner.GrantId;
                                        set
                                        {
                                            if (_inner.GrantId != value)
                                            {
                                                _inner.GrantId = value;
                                                if ((_trackingMask & yUserGrantTrackingFields.GrantId) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "GrantId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public bool? CanGrant
                                    {
                                        get => _inner.CanGrant;
                                        set
                                        {
                                            if (_inner.CanGrant != value)
                                            {
                                                _inner.CanGrant = value;
                                                if ((_trackingMask & yUserGrantTrackingFields.CanGrant) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "CanGrant", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public bool? CanCreate
                                    {
                                        get => _inner.CanCreate;
                                        set
                                        {
                                            if (_inner.CanCreate != value)
                                            {
                                                _inner.CanCreate = value;
                                                if ((_trackingMask & yUserGrantTrackingFields.CanCreate) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "CanCreate", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public bool? CanRead
                                    {
                                        get => _inner.CanRead;
                                        set
                                        {
                                            if (_inner.CanRead != value)
                                            {
                                                _inner.CanRead = value;
                                                if ((_trackingMask & yUserGrantTrackingFields.CanRead) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "CanRead", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public bool? CanUpdate
                                    {
                                        get => _inner.CanUpdate;
                                        set
                                        {
                                            if (_inner.CanUpdate != value)
                                            {
                                                _inner.CanUpdate = value;
                                                if ((_trackingMask & yUserGrantTrackingFields.CanUpdate) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "CanUpdate", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public bool? CanDelete
                                    {
                                        get => _inner.CanDelete;
                                        set
                                        {
                                            if (_inner.CanDelete != value)
                                            {
                                                _inner.CanDelete = value;
                                                if ((_trackingMask & yUserGrantTrackingFields.CanDelete) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "CanDelete", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ValidUntil
                                    {
                                        get => _inner.ValidUntil;
                                        set
                                        {
                                            if (_inner.ValidUntil != value)
                                            {
                                                _inner.ValidUntil = value;
                                                if ((_trackingMask & yUserGrantTrackingFields.ValidUntil) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "ValidUntil", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yUserGrantTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yUserGrantTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yUserGrantTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yUserGrantTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yUserGrant", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration