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
                    public static class T_MAQUINAS_EQUIPESTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MAQ_ID = 1UL << 1;
            public const ulong EQU_ID = 1UL << 2;
            public const ulong CAL_ID = 1UL << 3;
            public const ulong CLI_ID = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class T_MAQUINAS_EQUIPESDecorator : IT_MAQUINAS_EQUIPESEntity
{

                        private readonly IT_MAQUINAS_EQUIPESEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_MAQUINAS_EQUIPESDecorator(IT_MAQUINAS_EQUIPESEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_MAQUINAS_EQUIPESDecorator(
                            IT_MAQUINAS_EQUIPESEntity inner,
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
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EQU_ID
                                    {
                                        get => _inner.EQU_ID;
                                        set
                                        {
                                            if (_inner.EQU_ID != value)
                                            {
                                                _inner.EQU_ID = value;
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.EQU_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "EQU_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CAL_ID
                                    {
                                        get => _inner.CAL_ID;
                                        set
                                        {
                                            if (_inner.CAL_ID != value)
                                            {
                                                _inner.CAL_ID = value;
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.CAL_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "CAL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_ID
                                    {
                                        get => _inner.CLI_ID;
                                        set
                                        {
                                            if (_inner.CLI_ID != value)
                                            {
                                                _inner.CLI_ID = value;
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MAQUINAS_EQUIPESTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_MAQUINAS_EQUIPES", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration