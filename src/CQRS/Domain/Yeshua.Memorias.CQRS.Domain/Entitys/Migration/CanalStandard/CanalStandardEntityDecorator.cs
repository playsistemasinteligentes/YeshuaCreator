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
                    public static class CanalStandardTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CanalId = 1UL << 1;
            public const ulong ConexaoYouTubeId = 1UL << 2;
            public const ulong CredencialTenantId = 1UL << 3;
            public const ulong Ativo = 1UL << 4;
            public const ulong TotalReservas = 1UL << 5;
            public const ulong UltimaReservaEmUtc = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
            public const ulong OperationalEntityId = 1UL << 10;
        }

        public static class CanalStandardOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CanalId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ConexaoYouTubeId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CredencialTenantId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Ativo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TotalReservas = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UltimaReservaEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class CanalStandardDecorator : ICanalStandardEntity
{

                        private readonly ICanalStandardEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CanalStandardDecorator(ICanalStandardEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CanalStandardDecorator(
                            ICanalStandardEntity inner,
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
                                                if ((_trackingMask & CanalStandardTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string CanalId
                                    {
                                        get => _inner.CanalId;
                                        set
                                        {
                                            if (_inner.CanalId != value)
                                            {
                                                _inner.CanalId = value;
                                                if ((_trackingMask & CanalStandardTrackingFields.CanalId) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "CanalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.CanalId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string ConexaoYouTubeId
                                    {
                                        get => _inner.ConexaoYouTubeId;
                                        set
                                        {
                                            if (_inner.ConexaoYouTubeId != value)
                                            {
                                                _inner.ConexaoYouTubeId = value;
                                                if ((_trackingMask & CanalStandardTrackingFields.ConexaoYouTubeId) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "ConexaoYouTubeId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.ConexaoYouTubeId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int CredencialTenantId
                                    {
                                        get => _inner.CredencialTenantId;
                                        set
                                        {
                                            if (_inner.CredencialTenantId != value)
                                            {
                                                _inner.CredencialTenantId = value;
                                                if ((_trackingMask & CanalStandardTrackingFields.CredencialTenantId) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "CredencialTenantId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.CredencialTenantId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public bool Ativo
                                    {
                                        get => _inner.Ativo;
                                        set
                                        {
                                            if (_inner.Ativo != value)
                                            {
                                                _inner.Ativo = value;
                                                if ((_trackingMask & CanalStandardTrackingFields.Ativo) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "Ativo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.Ativo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public long TotalReservas
                                    {
                                        get => _inner.TotalReservas;
                                        set
                                        {
                                            if (_inner.TotalReservas != value)
                                            {
                                                _inner.TotalReservas = value;
                                                if ((_trackingMask & CanalStandardTrackingFields.TotalReservas) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "TotalReservas", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.TotalReservas, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? UltimaReservaEmUtc
                                    {
                                        get => _inner.UltimaReservaEmUtc;
                                        set
                                        {
                                            if (_inner.UltimaReservaEmUtc != value)
                                            {
                                                _inner.UltimaReservaEmUtc = value;
                                                if ((_trackingMask & CanalStandardTrackingFields.UltimaReservaEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "UltimaReservaEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.UltimaReservaEmUtc, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CanalStandardTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CanalStandardTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CanalStandardTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CanalStandard", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CanalStandardOperationalFields.UserId, _trackingExecutionIdentity);
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