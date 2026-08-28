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
                    public static class PlanoacaoTrackingFields
        {
            public const ulong PLA_ID = 1UL << 0;
            public const ulong PLA_DESCRICAO = 1UL << 1;
            public const ulong MET_ID = 1UL << 2;
            public const ulong PLA_STATUS = 1UL << 3;
            public const ulong PLA_DATA = 1UL << 4;
            public const ulong PLA_METAPERIODO = 1UL << 5;
            public const ulong PLA_VLRPERIODO = 1UL << 6;
            public const ulong PLA_METACULADO = 1UL << 7;
            public const ulong PLA_VLRACUMULADO = 1UL << 8;
            public const ulong PLA_REFERENCIA = 1UL << 9;
            public const ulong USE_ID = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
        }

        public partial class PlanoacaoDecorator : IPlanoacaoEntity
{

                        private readonly IPlanoacaoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PlanoacaoDecorator(IPlanoacaoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PlanoacaoDecorator(
                            IPlanoacaoEntity inner,
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
                                    public int PLA_ID
                                    {
                                        get => _inner.PLA_ID;
                                        set
                                        {
                                            if (_inner.PLA_ID != value)
                                            {
                                                _inner.PLA_ID = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_ID) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_DESCRICAO
                                    {
                                        get => _inner.PLA_DESCRICAO;
                                        set
                                        {
                                            if (_inner.PLA_DESCRICAO != value)
                                            {
                                                _inner.PLA_DESCRICAO = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MET_ID
                                    {
                                        get => _inner.MET_ID;
                                        set
                                        {
                                            if (_inner.MET_ID != value)
                                            {
                                                _inner.MET_ID = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.MET_ID) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "MET_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_STATUS
                                    {
                                        get => _inner.PLA_STATUS;
                                        set
                                        {
                                            if (_inner.PLA_STATUS != value)
                                            {
                                                _inner.PLA_STATUS = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? PLA_DATA
                                    {
                                        get => _inner.PLA_DATA;
                                        set
                                        {
                                            if (_inner.PLA_DATA != value)
                                            {
                                                _inner.PLA_DATA = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_DATA) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_DATA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_METAPERIODO
                                    {
                                        get => _inner.PLA_METAPERIODO;
                                        set
                                        {
                                            if (_inner.PLA_METAPERIODO != value)
                                            {
                                                _inner.PLA_METAPERIODO = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_METAPERIODO) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_METAPERIODO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_VLRPERIODO
                                    {
                                        get => _inner.PLA_VLRPERIODO;
                                        set
                                        {
                                            if (_inner.PLA_VLRPERIODO != value)
                                            {
                                                _inner.PLA_VLRPERIODO = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_VLRPERIODO) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_VLRPERIODO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_METACULADO
                                    {
                                        get => _inner.PLA_METACULADO;
                                        set
                                        {
                                            if (_inner.PLA_METACULADO != value)
                                            {
                                                _inner.PLA_METACULADO = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_METACULADO) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_METACULADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_VLRACUMULADO
                                    {
                                        get => _inner.PLA_VLRACUMULADO;
                                        set
                                        {
                                            if (_inner.PLA_VLRACUMULADO != value)
                                            {
                                                _inner.PLA_VLRACUMULADO = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_VLRACUMULADO) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_VLRACUMULADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_REFERENCIA
                                    {
                                        get => _inner.PLA_REFERENCIA;
                                        set
                                        {
                                            if (_inner.PLA_REFERENCIA != value)
                                            {
                                                _inner.PLA_REFERENCIA = value;
                                                if ((_trackingMask & PlanoacaoTrackingFields.PLA_REFERENCIA) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "PLA_REFERENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoacaoTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoacaoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoacaoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoacaoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoacaoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Planoacao", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration