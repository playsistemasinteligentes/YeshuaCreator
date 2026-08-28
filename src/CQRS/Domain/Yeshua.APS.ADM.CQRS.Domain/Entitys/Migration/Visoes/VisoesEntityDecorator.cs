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
                    public static class VisoesTrackingFields
        {
            public const ulong VIS_ID = 1UL << 0;
            public const ulong VIS_PLANID = 1UL << 1;
            public const ulong VIS_FORMULA = 1UL << 2;
            public const ulong CAB_ID = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public partial class VisoesDecorator : IVisoesEntity
{

                        private readonly IVisoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public VisoesDecorator(IVisoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public VisoesDecorator(
                            IVisoesEntity inner,
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
                                    public int VIS_ID
                                    {
                                        get => _inner.VIS_ID;
                                        set
                                        {
                                            if (_inner.VIS_ID != value)
                                            {
                                                _inner.VIS_ID = value;
                                                if ((_trackingMask & VisoesTrackingFields.VIS_ID) != 0UL)
                                                    _logger.DomainValueChanged("Visoes", "VIS_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int VIS_PLANID
                                    {
                                        get => _inner.VIS_PLANID;
                                        set
                                        {
                                            if (_inner.VIS_PLANID != value)
                                            {
                                                _inner.VIS_PLANID = value;
                                                if ((_trackingMask & VisoesTrackingFields.VIS_PLANID) != 0UL)
                                                    _logger.DomainValueChanged("Visoes", "VIS_PLANID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VIS_FORMULA
                                    {
                                        get => _inner.VIS_FORMULA;
                                        set
                                        {
                                            if (_inner.VIS_FORMULA != value)
                                            {
                                                _inner.VIS_FORMULA = value;
                                                if ((_trackingMask & VisoesTrackingFields.VIS_FORMULA) != 0UL)
                                                    _logger.DomainValueChanged("Visoes", "VIS_FORMULA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int CAB_ID
                                    {
                                        get => _inner.CAB_ID;
                                        set
                                        {
                                            if (_inner.CAB_ID != value)
                                            {
                                                _inner.CAB_ID = value;
                                                if ((_trackingMask & VisoesTrackingFields.CAB_ID) != 0UL)
                                                    _logger.DomainValueChanged("Visoes", "CAB_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VisoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Visoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VisoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Visoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VisoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Visoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VisoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Visoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration