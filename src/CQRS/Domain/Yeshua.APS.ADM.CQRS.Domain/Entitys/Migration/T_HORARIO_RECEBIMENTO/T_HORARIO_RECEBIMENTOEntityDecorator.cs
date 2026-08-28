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
                    public static class T_HORARIO_RECEBIMENTOTrackingFields
        {
            public const ulong HRE_DIA_DA_SEMANA = 1UL << 0;
            public const ulong HRE_HORA_INICIAL = 1UL << 1;
            public const ulong HRE_HORA_FINAL = 1UL << 2;
            public const ulong CLI_ID = 1UL << 3;
            public const ulong HRE_ID = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class T_HORARIO_RECEBIMENTODecorator : IT_HORARIO_RECEBIMENTOEntity
{

                        private readonly IT_HORARIO_RECEBIMENTOEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_HORARIO_RECEBIMENTODecorator(IT_HORARIO_RECEBIMENTOEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_HORARIO_RECEBIMENTODecorator(
                            IT_HORARIO_RECEBIMENTOEntity inner,
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
                                    public int HRE_DIA_DA_SEMANA
                                    {
                                        get => _inner.HRE_DIA_DA_SEMANA;
                                        set
                                        {
                                            if (_inner.HRE_DIA_DA_SEMANA != value)
                                            {
                                                _inner.HRE_DIA_DA_SEMANA = value;
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.HRE_DIA_DA_SEMANA) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "HRE_DIA_DA_SEMANA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime HRE_HORA_INICIAL
                                    {
                                        get => _inner.HRE_HORA_INICIAL;
                                        set
                                        {
                                            if (_inner.HRE_HORA_INICIAL != value)
                                            {
                                                _inner.HRE_HORA_INICIAL = value;
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.HRE_HORA_INICIAL) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "HRE_HORA_INICIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime HRE_HORA_FINAL
                                    {
                                        get => _inner.HRE_HORA_FINAL;
                                        set
                                        {
                                            if (_inner.HRE_HORA_FINAL != value)
                                            {
                                                _inner.HRE_HORA_FINAL = value;
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.HRE_HORA_FINAL) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "HRE_HORA_FINAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int HRE_ID
                                    {
                                        get => _inner.HRE_ID;
                                        set
                                        {
                                            if (_inner.HRE_ID != value)
                                            {
                                                _inner.HRE_ID = value;
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.HRE_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "HRE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_HORARIO_RECEBIMENTOTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_HORARIO_RECEBIMENTO", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration