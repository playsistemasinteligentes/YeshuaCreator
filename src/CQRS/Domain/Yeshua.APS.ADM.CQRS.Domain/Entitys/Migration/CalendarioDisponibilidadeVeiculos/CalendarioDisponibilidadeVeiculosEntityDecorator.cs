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
                    public static class CalendarioDisponibilidadeVeiculosTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CDV_ID = 1UL << 1;
            public const ulong CDV_DATA_DE = 1UL << 2;
            public const ulong CDV_DATA_ATE = 1UL << 3;
            public const ulong CDV_SEGUNDA = 1UL << 4;
            public const ulong CDV_TERCA = 1UL << 5;
            public const ulong CDV_QUARTA = 1UL << 6;
            public const ulong CDV_QUINTA = 1UL << 7;
            public const ulong CDV_SEXTA = 1UL << 8;
            public const ulong CDV_SABADO = 1UL << 9;
            public const ulong CDV_DOMINGO = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
        }

        public partial class CalendarioDisponibilidadeVeiculosDecorator : ICalendarioDisponibilidadeVeiculosEntity
{

                        private readonly ICalendarioDisponibilidadeVeiculosEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CalendarioDisponibilidadeVeiculosDecorator(ICalendarioDisponibilidadeVeiculosEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CalendarioDisponibilidadeVeiculosDecorator(
                            ICalendarioDisponibilidadeVeiculosEntity inner,
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
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int CDV_ID
                                    {
                                        get => _inner.CDV_ID;
                                        set
                                        {
                                            if (_inner.CDV_ID != value)
                                            {
                                                _inner.CDV_ID = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_ID) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CDV_DATA_DE
                                    {
                                        get => _inner.CDV_DATA_DE;
                                        set
                                        {
                                            if (_inner.CDV_DATA_DE != value)
                                            {
                                                _inner.CDV_DATA_DE = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_DATA_DE) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_DATA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CDV_DATA_ATE
                                    {
                                        get => _inner.CDV_DATA_ATE;
                                        set
                                        {
                                            if (_inner.CDV_DATA_ATE != value)
                                            {
                                                _inner.CDV_DATA_ATE = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_DATA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_DATA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CDV_SEGUNDA
                                    {
                                        get => _inner.CDV_SEGUNDA;
                                        set
                                        {
                                            if (_inner.CDV_SEGUNDA != value)
                                            {
                                                _inner.CDV_SEGUNDA = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_SEGUNDA) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_SEGUNDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CDV_TERCA
                                    {
                                        get => _inner.CDV_TERCA;
                                        set
                                        {
                                            if (_inner.CDV_TERCA != value)
                                            {
                                                _inner.CDV_TERCA = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_TERCA) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_TERCA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CDV_QUARTA
                                    {
                                        get => _inner.CDV_QUARTA;
                                        set
                                        {
                                            if (_inner.CDV_QUARTA != value)
                                            {
                                                _inner.CDV_QUARTA = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_QUARTA) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_QUARTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CDV_QUINTA
                                    {
                                        get => _inner.CDV_QUINTA;
                                        set
                                        {
                                            if (_inner.CDV_QUINTA != value)
                                            {
                                                _inner.CDV_QUINTA = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_QUINTA) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_QUINTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CDV_SEXTA
                                    {
                                        get => _inner.CDV_SEXTA;
                                        set
                                        {
                                            if (_inner.CDV_SEXTA != value)
                                            {
                                                _inner.CDV_SEXTA = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_SEXTA) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_SEXTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CDV_SABADO
                                    {
                                        get => _inner.CDV_SABADO;
                                        set
                                        {
                                            if (_inner.CDV_SABADO != value)
                                            {
                                                _inner.CDV_SABADO = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_SABADO) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_SABADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CDV_DOMINGO
                                    {
                                        get => _inner.CDV_DOMINGO;
                                        set
                                        {
                                            if (_inner.CDV_DOMINGO != value)
                                            {
                                                _inner.CDV_DOMINGO = value;
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.CDV_DOMINGO) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "CDV_DOMINGO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CalendarioDisponibilidadeVeiculosTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CalendarioDisponibilidadeVeiculos", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration