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
                    public static class yTokenTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TokenHash = 1UL << 1;
            public const ulong Description = 1UL << 2;
            public const ulong ConnectorKey = 1UL << 3;
            public const ulong Active = 1UL << 4;
            public const ulong ValidUntil = 1UL << 5;
            public const ulong CreatedAt = 1UL << 6;
            public const ulong LastUsedAt = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong UserId = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
        }

        public partial class yTokenDecorator : IyTokenEntity
{

                        private readonly IyTokenEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yTokenDecorator(IyTokenEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yTokenDecorator(
                            IyTokenEntity inner,
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
                                                if ((_trackingMask & yTokenTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TokenHash
                                    {
                                        get => _inner.TokenHash;
                                        set
                                        {
                                            if (_inner.TokenHash != value)
                                            {
                                                _inner.TokenHash = value;
                                                if ((_trackingMask & yTokenTrackingFields.TokenHash) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "TokenHash", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? Description
                                    {
                                        get => _inner.Description;
                                        set
                                        {
                                            if (_inner.Description != value)
                                            {
                                                _inner.Description = value;
                                                if ((_trackingMask & yTokenTrackingFields.Description) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "Description", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ConnectorKey
                                    {
                                        get => _inner.ConnectorKey;
                                        set
                                        {
                                            if (_inner.ConnectorKey != value)
                                            {
                                                _inner.ConnectorKey = value;
                                                if ((_trackingMask & yTokenTrackingFields.ConnectorKey) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "ConnectorKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public bool Active
                                    {
                                        get => _inner.Active;
                                        set
                                        {
                                            if (_inner.Active != value)
                                            {
                                                _inner.Active = value;
                                                if ((_trackingMask & yTokenTrackingFields.Active) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "Active", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yTokenTrackingFields.ValidUntil) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "ValidUntil", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime CreatedAt
                                    {
                                        get => _inner.CreatedAt;
                                        set
                                        {
                                            if (_inner.CreatedAt != value)
                                            {
                                                _inner.CreatedAt = value;
                                                if ((_trackingMask & yTokenTrackingFields.CreatedAt) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "CreatedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? LastUsedAt
                                    {
                                        get => _inner.LastUsedAt;
                                        set
                                        {
                                            if (_inner.LastUsedAt != value)
                                            {
                                                _inner.LastUsedAt = value;
                                                if ((_trackingMask & yTokenTrackingFields.LastUsedAt) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "LastUsedAt", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yTokenTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yTokenTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yTokenTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & yTokenTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yToken", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration