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
                    public static class ResultMedidaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong RSM_ID = 1UL << 1;
            public const ulong RL_ID = 1UL << 2;
            public const ulong MDT_ID = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public partial class ResultMedidaDecorator : IResultMedidaEntity
{

                        private readonly IResultMedidaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ResultMedidaDecorator(IResultMedidaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ResultMedidaDecorator(
                            IResultMedidaEntity inner,
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
                                                if ((_trackingMask & ResultMedidaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ResultMedida", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int RSM_ID
                                    {
                                        get => _inner.RSM_ID;
                                        set
                                        {
                                            if (_inner.RSM_ID != value)
                                            {
                                                _inner.RSM_ID = value;
                                                if ((_trackingMask & ResultMedidaTrackingFields.RSM_ID) != 0UL)
                                                    _logger.DomainValueChanged("ResultMedida", "RSM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? RL_ID
                                    {
                                        get => _inner.RL_ID;
                                        set
                                        {
                                            if (_inner.RL_ID != value)
                                            {
                                                _inner.RL_ID = value;
                                                if ((_trackingMask & ResultMedidaTrackingFields.RL_ID) != 0UL)
                                                    _logger.DomainValueChanged("ResultMedida", "RL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MDT_ID
                                    {
                                        get => _inner.MDT_ID;
                                        set
                                        {
                                            if (_inner.MDT_ID != value)
                                            {
                                                _inner.MDT_ID = value;
                                                if ((_trackingMask & ResultMedidaTrackingFields.MDT_ID) != 0UL)
                                                    _logger.DomainValueChanged("ResultMedida", "MDT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ResultMedidaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ResultMedida", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ResultMedidaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ResultMedida", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ResultMedidaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ResultMedida", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ResultMedidaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ResultMedida", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration