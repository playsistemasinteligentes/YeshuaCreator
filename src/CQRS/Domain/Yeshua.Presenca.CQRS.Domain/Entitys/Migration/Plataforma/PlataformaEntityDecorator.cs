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
                    public static class PlataformaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Codigo = 1UL << 1;
            public const ulong Capacidades = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
            public const ulong OperationalEntityId = 1UL << 7;
        }

        public static class PlataformaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Codigo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Capacidades = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class PlataformaDecorator : IPlataformaEntity
{

                        private readonly IPlataformaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PlataformaDecorator(IPlataformaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PlataformaDecorator(
                            IPlataformaEntity inner,
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
                                    public string? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & PlataformaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Plataforma", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlataformaOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Codigo
                                    {
                                        get => _inner.Codigo;
                                        set
                                        {
                                            if (_inner.Codigo != value)
                                            {
                                                _inner.Codigo = value;
                                                if ((_trackingMask & PlataformaTrackingFields.Codigo) != 0UL)
                                                    _logger.DomainValueChanged("Plataforma", "Codigo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlataformaOperationalFields.Codigo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Capacidades
                                    {
                                        get => _inner.Capacidades;
                                        set
                                        {
                                            if (_inner.Capacidades != value)
                                            {
                                                _inner.Capacidades = value;
                                                if ((_trackingMask & PlataformaTrackingFields.Capacidades) != 0UL)
                                                    _logger.DomainValueChanged("Plataforma", "Capacidades", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlataformaOperationalFields.Capacidades, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PlataformaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Plataforma", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlataformaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PlataformaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Plataforma", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlataformaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PlataformaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Plataforma", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlataformaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PlataformaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Plataforma", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlataformaOperationalFields.UserId, _trackingExecutionIdentity);
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