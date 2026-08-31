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
                    public static class CTeEntradaOficialTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CorrelationId = 1UL << 1;
            public const ulong SourceApplication = 1UL << 2;
            public const ulong SourceModule = 1UL << 3;
            public const ulong SourceMessageId = 1UL << 4;
            public const ulong MessageType = 1UL << 5;
            public const ulong MessageVersion = 1UL << 6;
            public const ulong ReceivedAtUtc = 1UL << 7;
            public const ulong PayloadHash = 1UL << 8;
            public const ulong PayloadStorageKey = 1UL << 9;
            public const ulong Status = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
        }

        public partial class CTeEntradaOficialDecorator : ICTeEntradaOficialEntity
{

                        private readonly ICTeEntradaOficialEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CTeEntradaOficialDecorator(ICTeEntradaOficialEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CTeEntradaOficialDecorator(
                            ICTeEntradaOficialEntity inner,
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
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CorrelationId
                                    {
                                        get => _inner.CorrelationId;
                                        set
                                        {
                                            if (_inner.CorrelationId != value)
                                            {
                                                _inner.CorrelationId = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SourceApplication
                                    {
                                        get => _inner.SourceApplication;
                                        set
                                        {
                                            if (_inner.SourceApplication != value)
                                            {
                                                _inner.SourceApplication = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.SourceApplication) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "SourceApplication", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SourceModule
                                    {
                                        get => _inner.SourceModule;
                                        set
                                        {
                                            if (_inner.SourceModule != value)
                                            {
                                                _inner.SourceModule = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.SourceModule) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "SourceModule", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SourceMessageId
                                    {
                                        get => _inner.SourceMessageId;
                                        set
                                        {
                                            if (_inner.SourceMessageId != value)
                                            {
                                                _inner.SourceMessageId = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.SourceMessageId) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "SourceMessageId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MessageType
                                    {
                                        get => _inner.MessageType;
                                        set
                                        {
                                            if (_inner.MessageType != value)
                                            {
                                                _inner.MessageType = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.MessageType) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "MessageType", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MessageVersion
                                    {
                                        get => _inner.MessageVersion;
                                        set
                                        {
                                            if (_inner.MessageVersion != value)
                                            {
                                                _inner.MessageVersion = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.MessageVersion) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "MessageVersion", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime ReceivedAtUtc
                                    {
                                        get => _inner.ReceivedAtUtc;
                                        set
                                        {
                                            if (_inner.ReceivedAtUtc != value)
                                            {
                                                _inner.ReceivedAtUtc = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.ReceivedAtUtc) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "ReceivedAtUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PayloadHash
                                    {
                                        get => _inner.PayloadHash;
                                        set
                                        {
                                            if (_inner.PayloadHash != value)
                                            {
                                                _inner.PayloadHash = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.PayloadHash) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "PayloadHash", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PayloadStorageKey
                                    {
                                        get => _inner.PayloadStorageKey;
                                        set
                                        {
                                            if (_inner.PayloadStorageKey != value)
                                            {
                                                _inner.PayloadStorageKey = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.PayloadStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "PayloadStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeEntradaOficialTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CTeEntradaOficial", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration