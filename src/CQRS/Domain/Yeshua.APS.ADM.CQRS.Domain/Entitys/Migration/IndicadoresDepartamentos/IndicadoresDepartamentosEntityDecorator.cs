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
                    public static class IndicadoresDepartamentosTrackingFields
        {
            public const ulong INDDEP_ID = 1UL << 0;
            public const ulong DEP_ID = 1UL << 1;
            public const ulong IND_ID = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
        }

        public partial class IndicadoresDepartamentosDecorator : IIndicadoresDepartamentosEntity
{

                        private readonly IIndicadoresDepartamentosEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public IndicadoresDepartamentosDecorator(IIndicadoresDepartamentosEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public IndicadoresDepartamentosDecorator(
                            IIndicadoresDepartamentosEntity inner,
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
                                    public int INDDEP_ID
                                    {
                                        get => _inner.INDDEP_ID;
                                        set
                                        {
                                            if (_inner.INDDEP_ID != value)
                                            {
                                                _inner.INDDEP_ID = value;
                                                if ((_trackingMask & IndicadoresDepartamentosTrackingFields.INDDEP_ID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDepartamentos", "INDDEP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int DEP_ID
                                    {
                                        get => _inner.DEP_ID;
                                        set
                                        {
                                            if (_inner.DEP_ID != value)
                                            {
                                                _inner.DEP_ID = value;
                                                if ((_trackingMask & IndicadoresDepartamentosTrackingFields.DEP_ID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDepartamentos", "DEP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int IND_ID
                                    {
                                        get => _inner.IND_ID;
                                        set
                                        {
                                            if (_inner.IND_ID != value)
                                            {
                                                _inner.IND_ID = value;
                                                if ((_trackingMask & IndicadoresDepartamentosTrackingFields.IND_ID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDepartamentos", "IND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresDepartamentosTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDepartamentos", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresDepartamentosTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDepartamentos", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresDepartamentosTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDepartamentos", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresDepartamentosTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDepartamentos", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration