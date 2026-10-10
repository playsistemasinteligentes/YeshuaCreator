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
                    public static class MaquinaGrupoMaquinaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong GMA_ID = 1UL << 1;
            public const ulong MAQ_ID = 1UL << 2;
            public const ulong OperationalEntityId = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public static class MaquinaGrupoMaquinaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GMA_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MAQ_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class MaquinaGrupoMaquinaDecorator : IMaquinaGrupoMaquinaEntity
{

                        private readonly IMaquinaGrupoMaquinaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MaquinaGrupoMaquinaDecorator(IMaquinaGrupoMaquinaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MaquinaGrupoMaquinaDecorator(
                            IMaquinaGrupoMaquinaEntity inner,
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
                                                if ((_trackingMask & MaquinaGrupoMaquinaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MaquinaGrupoMaquina", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MaquinaGrupoMaquinaOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string GMA_ID
                                    {
                                        get => _inner.GMA_ID;
                                        set
                                        {
                                            if (_inner.GMA_ID != value)
                                            {
                                                _inner.GMA_ID = value;
                                                if ((_trackingMask & MaquinaGrupoMaquinaTrackingFields.GMA_ID) != 0UL)
                                                    _logger.DomainValueChanged("MaquinaGrupoMaquina", "GMA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MaquinaGrupoMaquinaOperationalFields.GMA_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string MAQ_ID
                                    {
                                        get => _inner.MAQ_ID;
                                        set
                                        {
                                            if (_inner.MAQ_ID != value)
                                            {
                                                _inner.MAQ_ID = value;
                                                if ((_trackingMask & MaquinaGrupoMaquinaTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("MaquinaGrupoMaquina", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MaquinaGrupoMaquinaOperationalFields.MAQ_ID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MaquinaGrupoMaquinaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MaquinaGrupoMaquina", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MaquinaGrupoMaquinaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MaquinaGrupoMaquinaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MaquinaGrupoMaquina", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MaquinaGrupoMaquinaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MaquinaGrupoMaquinaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MaquinaGrupoMaquina", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MaquinaGrupoMaquinaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MaquinaGrupoMaquinaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MaquinaGrupoMaquina", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MaquinaGrupoMaquinaOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration