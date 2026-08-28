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
                    public static class PeriodicidadeTesteTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong PER_ID = 1UL << 1;
            public const ulong PER_QTD = 1UL << 2;
            public const ulong UNI_ID = 1UL << 3;
            public const ulong GRP_ID = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class PeriodicidadeTesteDecorator : IPeriodicidadeTesteEntity
{

                        private readonly IPeriodicidadeTesteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PeriodicidadeTesteDecorator(IPeriodicidadeTesteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PeriodicidadeTesteDecorator(
                            IPeriodicidadeTesteEntity inner,
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
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int PER_ID
                                    {
                                        get => _inner.PER_ID;
                                        set
                                        {
                                            if (_inner.PER_ID != value)
                                            {
                                                _inner.PER_ID = value;
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.PER_ID) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "PER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PER_QTD
                                    {
                                        get => _inner.PER_QTD;
                                        set
                                        {
                                            if (_inner.PER_QTD != value)
                                            {
                                                _inner.PER_QTD = value;
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.PER_QTD) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "PER_QTD", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UNI_ID
                                    {
                                        get => _inner.UNI_ID;
                                        set
                                        {
                                            if (_inner.UNI_ID != value)
                                            {
                                                _inner.UNI_ID = value;
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_ID
                                    {
                                        get => _inner.GRP_ID;
                                        set
                                        {
                                            if (_inner.GRP_ID != value)
                                            {
                                                _inner.GRP_ID = value;
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.GRP_ID) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "GRP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PeriodicidadeTesteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PeriodicidadeTeste", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration