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
                    public static class T_AGENDA_SCHEDULETrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong AGE_ID = 1UL << 1;
            public const ulong AGE_DATA_ESPECIFICA = 1UL << 2;
            public const ulong AGE_HORARIO_INICIO = 1UL << 3;
            public const ulong AGE_HORARIO_FIM = 1UL << 4;
            public const ulong AGE_SEGUNDA = 1UL << 5;
            public const ulong AGE_TERCA = 1UL << 6;
            public const ulong AGE_QUARTA = 1UL << 7;
            public const ulong AGE_QUINTA = 1UL << 8;
            public const ulong AGE_SEXTA = 1UL << 9;
            public const ulong AGE_SABADO = 1UL << 10;
            public const ulong AGE_DOMINGO = 1UL << 11;
            public const ulong AGE_INTERVALO = 1UL << 12;
            public const ulong AGE_ORDEM_EXECUCAO = 1UL << 13;
            public const ulong AGE_PARAMETROS = 1UL << 14;
            public const ulong AGE_EXCECAO = 1UL << 15;
            public const ulong AGE_DESCRICAO = 1UL << 16;
            public const ulong TenantID = 1UL << 17;
            public const ulong Deleted = 1UL << 18;
            public const ulong Changed = 1UL << 19;
            public const ulong UserId = 1UL << 20;
        }

        public partial class T_AGENDA_SCHEDULEDecorator : IT_AGENDA_SCHEDULEEntity
{

                        private readonly IT_AGENDA_SCHEDULEEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_AGENDA_SCHEDULEDecorator(IT_AGENDA_SCHEDULEEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_AGENDA_SCHEDULEDecorator(
                            IT_AGENDA_SCHEDULEEntity inner,
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
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int AGE_ID
                                    {
                                        get => _inner.AGE_ID;
                                        set
                                        {
                                            if (_inner.AGE_ID != value)
                                            {
                                                _inner.AGE_ID = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? AGE_DATA_ESPECIFICA
                                    {
                                        get => _inner.AGE_DATA_ESPECIFICA;
                                        set
                                        {
                                            if (_inner.AGE_DATA_ESPECIFICA != value)
                                            {
                                                _inner.AGE_DATA_ESPECIFICA = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_DATA_ESPECIFICA) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_DATA_ESPECIFICA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_HORARIO_INICIO
                                    {
                                        get => _inner.AGE_HORARIO_INICIO;
                                        set
                                        {
                                            if (_inner.AGE_HORARIO_INICIO != value)
                                            {
                                                _inner.AGE_HORARIO_INICIO = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_HORARIO_INICIO) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_HORARIO_INICIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_HORARIO_FIM
                                    {
                                        get => _inner.AGE_HORARIO_FIM;
                                        set
                                        {
                                            if (_inner.AGE_HORARIO_FIM != value)
                                            {
                                                _inner.AGE_HORARIO_FIM = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_HORARIO_FIM) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_HORARIO_FIM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_SEGUNDA
                                    {
                                        get => _inner.AGE_SEGUNDA;
                                        set
                                        {
                                            if (_inner.AGE_SEGUNDA != value)
                                            {
                                                _inner.AGE_SEGUNDA = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_SEGUNDA) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_SEGUNDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_TERCA
                                    {
                                        get => _inner.AGE_TERCA;
                                        set
                                        {
                                            if (_inner.AGE_TERCA != value)
                                            {
                                                _inner.AGE_TERCA = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_TERCA) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_TERCA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_QUARTA
                                    {
                                        get => _inner.AGE_QUARTA;
                                        set
                                        {
                                            if (_inner.AGE_QUARTA != value)
                                            {
                                                _inner.AGE_QUARTA = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_QUARTA) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_QUARTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_QUINTA
                                    {
                                        get => _inner.AGE_QUINTA;
                                        set
                                        {
                                            if (_inner.AGE_QUINTA != value)
                                            {
                                                _inner.AGE_QUINTA = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_QUINTA) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_QUINTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_SEXTA
                                    {
                                        get => _inner.AGE_SEXTA;
                                        set
                                        {
                                            if (_inner.AGE_SEXTA != value)
                                            {
                                                _inner.AGE_SEXTA = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_SEXTA) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_SEXTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_SABADO
                                    {
                                        get => _inner.AGE_SABADO;
                                        set
                                        {
                                            if (_inner.AGE_SABADO != value)
                                            {
                                                _inner.AGE_SABADO = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_SABADO) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_SABADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_DOMINGO
                                    {
                                        get => _inner.AGE_DOMINGO;
                                        set
                                        {
                                            if (_inner.AGE_DOMINGO != value)
                                            {
                                                _inner.AGE_DOMINGO = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_DOMINGO) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_DOMINGO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? AGE_INTERVALO
                                    {
                                        get => _inner.AGE_INTERVALO;
                                        set
                                        {
                                            if (_inner.AGE_INTERVALO != value)
                                            {
                                                _inner.AGE_INTERVALO = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_INTERVALO) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_INTERVALO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_ORDEM_EXECUCAO
                                    {
                                        get => _inner.AGE_ORDEM_EXECUCAO;
                                        set
                                        {
                                            if (_inner.AGE_ORDEM_EXECUCAO != value)
                                            {
                                                _inner.AGE_ORDEM_EXECUCAO = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_ORDEM_EXECUCAO) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_ORDEM_EXECUCAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_PARAMETROS
                                    {
                                        get => _inner.AGE_PARAMETROS;
                                        set
                                        {
                                            if (_inner.AGE_PARAMETROS != value)
                                            {
                                                _inner.AGE_PARAMETROS = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_PARAMETROS) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_PARAMETROS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_EXCECAO
                                    {
                                        get => _inner.AGE_EXCECAO;
                                        set
                                        {
                                            if (_inner.AGE_EXCECAO != value)
                                            {
                                                _inner.AGE_EXCECAO = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_EXCECAO) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_EXCECAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string AGE_DESCRICAO
                                    {
                                        get => _inner.AGE_DESCRICAO;
                                        set
                                        {
                                            if (_inner.AGE_DESCRICAO != value)
                                            {
                                                _inner.AGE_DESCRICAO = value;
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.AGE_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "AGE_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_AGENDA_SCHEDULETrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_AGENDA_SCHEDULE", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration