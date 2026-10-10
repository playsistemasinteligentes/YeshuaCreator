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
                    public static class yConfigNotificationTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TenantID = 1UL << 1;
            public const ulong EmailSmtpClient = 1UL << 2;
            public const ulong EmailPort = 1UL << 3;
            public const ulong EmailUserName = 1UL << 4;
            public const ulong EmailPassword = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
        }

        public static class yConfigNotificationOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EmailSmtpClient = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification EmailPort = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification EmailUserName = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification EmailPassword = Dominio.Operational.OperationalDataClassification.NeverCapture;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class yConfigNotificationDecorator : IyConfigNotificationEntity
{

                        private readonly IyConfigNotificationEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public yConfigNotificationDecorator(IyConfigNotificationEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public yConfigNotificationDecorator(
                            IyConfigNotificationEntity inner,
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
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & yConfigNotificationTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.Id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yConfigNotificationTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.TenantID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? EmailSmtpClient
                                    {
                                        get => _inner.EmailSmtpClient;
                                        set
                                        {
                                            if (_inner.EmailSmtpClient != value)
                                            {
                                                _inner.EmailSmtpClient = value;
                                                if ((_trackingMask & yConfigNotificationTrackingFields.EmailSmtpClient) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "EmailSmtpClient", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.EmailSmtpClient, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? EmailPort
                                    {
                                        get => _inner.EmailPort;
                                        set
                                        {
                                            if (_inner.EmailPort != value)
                                            {
                                                _inner.EmailPort = value;
                                                if ((_trackingMask & yConfigNotificationTrackingFields.EmailPort) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "EmailPort", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.EmailPort, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? EmailUserName
                                    {
                                        get => _inner.EmailUserName;
                                        set
                                        {
                                            if (_inner.EmailUserName != value)
                                            {
                                                _inner.EmailUserName = value;
                                                if ((_trackingMask & yConfigNotificationTrackingFields.EmailUserName) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "EmailUserName", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.EmailUserName, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? EmailPassword
                                    {
                                        get => _inner.EmailPassword;
                                        set
                                        {
                                            if (_inner.EmailPassword != value)
                                            {
                                                _inner.EmailPassword = value;
                                                if ((_trackingMask & yConfigNotificationTrackingFields.EmailPassword) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "EmailPassword", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.EmailPassword, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yConfigNotificationTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yConfigNotificationTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & yConfigNotificationTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("yConfigNotification", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, yConfigNotificationOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration