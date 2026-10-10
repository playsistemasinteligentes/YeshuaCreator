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
                    public static class LogsDatabaseTrackingFields
        {
            public const ulong LOGS_ID = 1UL << 0;
            public const ulong LOGS_TABLE = 1UL << 1;
            public const ulong LOGS_KEY = 1UL << 2;
            public const ulong LOGS_KEY1 = 1UL << 3;
            public const ulong LOGS_KEY2 = 1UL << 4;
            public const ulong LOGS_KEY3 = 1UL << 5;
            public const ulong LOGS_KEY4 = 1UL << 6;
            public const ulong LOGS_COLUMN = 1UL << 7;
            public const ulong LOGS_BEFORE = 1UL << 8;
            public const ulong LOGS_AFTER = 1UL << 9;
            public const ulong LOGS_ACTION = 1UL << 10;
            public const ulong LOGS_DATE = 1UL << 11;
            public const ulong USE_ID = 1UL << 12;
            public const ulong LOGS_ORIGEM = 1UL << 13;
            public const ulong OperationalEntityId = 1UL << 14;
            public const ulong TenantID = 1UL << 15;
            public const ulong Deleted = 1UL << 16;
            public const ulong Changed = 1UL << 17;
            public const ulong UserId = 1UL << 18;
        }

        public static class LogsDatabaseOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification LOGS_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_TABLE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_KEY = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_KEY1 = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_KEY2 = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_KEY3 = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_KEY4 = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_COLUMN = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_BEFORE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_AFTER = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_ACTION = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_DATE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification USE_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification LOGS_ORIGEM = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class LogsDatabaseDecorator : ILogsDatabaseEntity
{

                        private readonly ILogsDatabaseEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public LogsDatabaseDecorator(ILogsDatabaseEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public LogsDatabaseDecorator(
                            ILogsDatabaseEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingExecutionIdentity = context is null
                                ? default
                                : new Dominio.Operational.OperationalExecutionIdentity(
                                    context.RootOperationId,
                                    context.OperationId,
                                    context.ExecutionId,
                                    context.CausationId);
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public int LOGS_ID
                                    {
                                        get => _inner.LOGS_ID;
                                        set
                                        {
                                            if (_inner.LOGS_ID != value)
                                            {
                                                _inner.LOGS_ID = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_ID) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string LOGS_TABLE
                                    {
                                        get => _inner.LOGS_TABLE;
                                        set
                                        {
                                            if (_inner.LOGS_TABLE != value)
                                            {
                                                _inner.LOGS_TABLE = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_TABLE) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_TABLE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_TABLE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string LOGS_KEY
                                    {
                                        get => _inner.LOGS_KEY;
                                        set
                                        {
                                            if (_inner.LOGS_KEY != value)
                                            {
                                                _inner.LOGS_KEY = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_KEY) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_KEY", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_KEY, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string LOGS_KEY1
                                    {
                                        get => _inner.LOGS_KEY1;
                                        set
                                        {
                                            if (_inner.LOGS_KEY1 != value)
                                            {
                                                _inner.LOGS_KEY1 = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_KEY1) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_KEY1", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_KEY1, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? LOGS_KEY2
                                    {
                                        get => _inner.LOGS_KEY2;
                                        set
                                        {
                                            if (_inner.LOGS_KEY2 != value)
                                            {
                                                _inner.LOGS_KEY2 = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_KEY2) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_KEY2", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_KEY2, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? LOGS_KEY3
                                    {
                                        get => _inner.LOGS_KEY3;
                                        set
                                        {
                                            if (_inner.LOGS_KEY3 != value)
                                            {
                                                _inner.LOGS_KEY3 = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_KEY3) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_KEY3", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_KEY3, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? LOGS_KEY4
                                    {
                                        get => _inner.LOGS_KEY4;
                                        set
                                        {
                                            if (_inner.LOGS_KEY4 != value)
                                            {
                                                _inner.LOGS_KEY4 = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_KEY4) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_KEY4", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_KEY4, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? LOGS_COLUMN
                                    {
                                        get => _inner.LOGS_COLUMN;
                                        set
                                        {
                                            if (_inner.LOGS_COLUMN != value)
                                            {
                                                _inner.LOGS_COLUMN = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_COLUMN) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_COLUMN", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_COLUMN, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? LOGS_BEFORE
                                    {
                                        get => _inner.LOGS_BEFORE;
                                        set
                                        {
                                            if (_inner.LOGS_BEFORE != value)
                                            {
                                                _inner.LOGS_BEFORE = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_BEFORE) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_BEFORE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_BEFORE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? LOGS_AFTER
                                    {
                                        get => _inner.LOGS_AFTER;
                                        set
                                        {
                                            if (_inner.LOGS_AFTER != value)
                                            {
                                                _inner.LOGS_AFTER = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_AFTER) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_AFTER", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_AFTER, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string LOGS_ACTION
                                    {
                                        get => _inner.LOGS_ACTION;
                                        set
                                        {
                                            if (_inner.LOGS_ACTION != value)
                                            {
                                                _inner.LOGS_ACTION = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_ACTION) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_ACTION", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_ACTION, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime LOGS_DATE
                                    {
                                        get => _inner.LOGS_DATE;
                                        set
                                        {
                                            if (_inner.LOGS_DATE != value)
                                            {
                                                _inner.LOGS_DATE = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_DATE) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_DATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_DATE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int USE_ID
                                    {
                                        get => _inner.USE_ID;
                                        set
                                        {
                                            if (_inner.USE_ID != value)
                                            {
                                                _inner.USE_ID = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.USE_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? LOGS_ORIGEM
                                    {
                                        get => _inner.LOGS_ORIGEM;
                                        set
                                        {
                                            if (_inner.LOGS_ORIGEM != value)
                                            {
                                                _inner.LOGS_ORIGEM = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.LOGS_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "LOGS_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.LOGS_ORIGEM, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & LogsDatabaseTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & LogsDatabaseTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & LogsDatabaseTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & LogsDatabaseTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("LogsDatabase", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, LogsDatabaseOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration