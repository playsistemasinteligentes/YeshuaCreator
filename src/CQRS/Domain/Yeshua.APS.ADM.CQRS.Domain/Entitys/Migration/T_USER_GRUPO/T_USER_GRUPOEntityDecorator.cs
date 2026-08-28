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
                    public static class T_USER_GRUPOTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong GRU_ID = 1UL << 1;
            public const ulong ID_USUARIO = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
        }

        public partial class T_USER_GRUPODecorator : IT_USER_GRUPOEntity
{

                        private readonly IT_USER_GRUPOEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_USER_GRUPODecorator(IT_USER_GRUPOEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_USER_GRUPODecorator(
                            IT_USER_GRUPOEntity inner,
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
                                                if ((_trackingMask & T_USER_GRUPOTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("T_USER_GRUPO", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int GRU_ID
                                    {
                                        get => _inner.GRU_ID;
                                        set
                                        {
                                            if (_inner.GRU_ID != value)
                                            {
                                                _inner.GRU_ID = value;
                                                if ((_trackingMask & T_USER_GRUPOTrackingFields.GRU_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_USER_GRUPO", "GRU_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int ID_USUARIO
                                    {
                                        get => _inner.ID_USUARIO;
                                        set
                                        {
                                            if (_inner.ID_USUARIO != value)
                                            {
                                                _inner.ID_USUARIO = value;
                                                if ((_trackingMask & T_USER_GRUPOTrackingFields.ID_USUARIO) != 0UL)
                                                    _logger.DomainValueChanged("T_USER_GRUPO", "ID_USUARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_USER_GRUPOTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_USER_GRUPO", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_USER_GRUPOTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_USER_GRUPO", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_USER_GRUPOTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_USER_GRUPO", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_USER_GRUPOTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_USER_GRUPO", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration