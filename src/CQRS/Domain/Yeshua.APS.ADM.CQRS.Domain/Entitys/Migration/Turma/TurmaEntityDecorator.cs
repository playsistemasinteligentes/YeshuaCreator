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
                    public static class TurmaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Descricao = 1UL << 1;
            public const ulong TURM_HORA_INI_DIA1 = 1UL << 2;
            public const ulong TURM_HORA_FIM_DIA1 = 1UL << 3;
            public const ulong TURM_HORA_INI_DIA2 = 1UL << 4;
            public const ulong TURM_HORA_FIM_DIA2 = 1UL << 5;
            public const ulong TURM_HORA_INI_DIA3 = 1UL << 6;
            public const ulong TURM_HORA_FIM_DIA3 = 1UL << 7;
            public const ulong TURM_HORA_INI_DIA4 = 1UL << 8;
            public const ulong TURM_HORA_FIM_DIA4 = 1UL << 9;
            public const ulong TURM_HORA_INI_DIA5 = 1UL << 10;
            public const ulong TURM_HORA_FIM_DIA5 = 1UL << 11;
            public const ulong TURM_HORA_INI_DIA6 = 1UL << 12;
            public const ulong TURM_HORA_FIM_DIA6 = 1UL << 13;
            public const ulong TURM_HORA_INI_DIA7 = 1UL << 14;
            public const ulong TURM_HORA_FIM_DIA7 = 1UL << 15;
            public const ulong TenantID = 1UL << 16;
            public const ulong Deleted = 1UL << 17;
            public const ulong Changed = 1UL << 18;
            public const ulong UserId = 1UL << 19;
        }

        public partial class TurmaDecorator : ITurmaEntity
{

                        private readonly ITurmaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TurmaDecorator(ITurmaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TurmaDecorator(
                            ITurmaEntity inner,
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
                                    public string Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & TurmaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _inner.Descricao = value;
                                                if ((_trackingMask & TurmaTrackingFields.Descricao) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "Descricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_INI_DIA1
                                    {
                                        get => _inner.TURM_HORA_INI_DIA1;
                                        set
                                        {
                                            if (_inner.TURM_HORA_INI_DIA1 != value)
                                            {
                                                _inner.TURM_HORA_INI_DIA1 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_INI_DIA1) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_INI_DIA1", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_FIM_DIA1
                                    {
                                        get => _inner.TURM_HORA_FIM_DIA1;
                                        set
                                        {
                                            if (_inner.TURM_HORA_FIM_DIA1 != value)
                                            {
                                                _inner.TURM_HORA_FIM_DIA1 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_FIM_DIA1) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_FIM_DIA1", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_INI_DIA2
                                    {
                                        get => _inner.TURM_HORA_INI_DIA2;
                                        set
                                        {
                                            if (_inner.TURM_HORA_INI_DIA2 != value)
                                            {
                                                _inner.TURM_HORA_INI_DIA2 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_INI_DIA2) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_INI_DIA2", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_FIM_DIA2
                                    {
                                        get => _inner.TURM_HORA_FIM_DIA2;
                                        set
                                        {
                                            if (_inner.TURM_HORA_FIM_DIA2 != value)
                                            {
                                                _inner.TURM_HORA_FIM_DIA2 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_FIM_DIA2) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_FIM_DIA2", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_INI_DIA3
                                    {
                                        get => _inner.TURM_HORA_INI_DIA3;
                                        set
                                        {
                                            if (_inner.TURM_HORA_INI_DIA3 != value)
                                            {
                                                _inner.TURM_HORA_INI_DIA3 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_INI_DIA3) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_INI_DIA3", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_FIM_DIA3
                                    {
                                        get => _inner.TURM_HORA_FIM_DIA3;
                                        set
                                        {
                                            if (_inner.TURM_HORA_FIM_DIA3 != value)
                                            {
                                                _inner.TURM_HORA_FIM_DIA3 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_FIM_DIA3) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_FIM_DIA3", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_INI_DIA4
                                    {
                                        get => _inner.TURM_HORA_INI_DIA4;
                                        set
                                        {
                                            if (_inner.TURM_HORA_INI_DIA4 != value)
                                            {
                                                _inner.TURM_HORA_INI_DIA4 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_INI_DIA4) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_INI_DIA4", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_FIM_DIA4
                                    {
                                        get => _inner.TURM_HORA_FIM_DIA4;
                                        set
                                        {
                                            if (_inner.TURM_HORA_FIM_DIA4 != value)
                                            {
                                                _inner.TURM_HORA_FIM_DIA4 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_FIM_DIA4) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_FIM_DIA4", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_INI_DIA5
                                    {
                                        get => _inner.TURM_HORA_INI_DIA5;
                                        set
                                        {
                                            if (_inner.TURM_HORA_INI_DIA5 != value)
                                            {
                                                _inner.TURM_HORA_INI_DIA5 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_INI_DIA5) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_INI_DIA5", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_FIM_DIA5
                                    {
                                        get => _inner.TURM_HORA_FIM_DIA5;
                                        set
                                        {
                                            if (_inner.TURM_HORA_FIM_DIA5 != value)
                                            {
                                                _inner.TURM_HORA_FIM_DIA5 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_FIM_DIA5) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_FIM_DIA5", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_INI_DIA6
                                    {
                                        get => _inner.TURM_HORA_INI_DIA6;
                                        set
                                        {
                                            if (_inner.TURM_HORA_INI_DIA6 != value)
                                            {
                                                _inner.TURM_HORA_INI_DIA6 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_INI_DIA6) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_INI_DIA6", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_FIM_DIA6
                                    {
                                        get => _inner.TURM_HORA_FIM_DIA6;
                                        set
                                        {
                                            if (_inner.TURM_HORA_FIM_DIA6 != value)
                                            {
                                                _inner.TURM_HORA_FIM_DIA6 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_FIM_DIA6) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_FIM_DIA6", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_INI_DIA7
                                    {
                                        get => _inner.TURM_HORA_INI_DIA7;
                                        set
                                        {
                                            if (_inner.TURM_HORA_INI_DIA7 != value)
                                            {
                                                _inner.TURM_HORA_INI_DIA7 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_INI_DIA7) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_INI_DIA7", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? TURM_HORA_FIM_DIA7
                                    {
                                        get => _inner.TURM_HORA_FIM_DIA7;
                                        set
                                        {
                                            if (_inner.TURM_HORA_FIM_DIA7 != value)
                                            {
                                                _inner.TURM_HORA_FIM_DIA7 = value;
                                                if ((_trackingMask & TurmaTrackingFields.TURM_HORA_FIM_DIA7) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TURM_HORA_FIM_DIA7", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TurmaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TurmaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TurmaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TurmaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Turma", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration