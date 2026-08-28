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
                    public static class TemposLogisticosTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TMP_TIPO_TEMPO = 1UL << 1;
            public const ulong TMP_TIPO_CARGA = 1UL << 2;
            public const ulong TMP_TEMPO_MEDIO_UNITARIO = 1UL << 3;
            public const ulong CLI_ID = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class TemposLogisticosDecorator : ITemposLogisticosEntity
{

                        private readonly ITemposLogisticosEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TemposLogisticosDecorator(ITemposLogisticosEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TemposLogisticosDecorator(
                            ITemposLogisticosEntity inner,
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
                                                if ((_trackingMask & TemposLogisticosTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TMP_TIPO_TEMPO
                                    {
                                        get => _inner.TMP_TIPO_TEMPO;
                                        set
                                        {
                                            if (_inner.TMP_TIPO_TEMPO != value)
                                            {
                                                _inner.TMP_TIPO_TEMPO = value;
                                                if ((_trackingMask & TemposLogisticosTrackingFields.TMP_TIPO_TEMPO) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "TMP_TIPO_TEMPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TMP_TIPO_CARGA
                                    {
                                        get => _inner.TMP_TIPO_CARGA;
                                        set
                                        {
                                            if (_inner.TMP_TIPO_CARGA != value)
                                            {
                                                _inner.TMP_TIPO_CARGA = value;
                                                if ((_trackingMask & TemposLogisticosTrackingFields.TMP_TIPO_CARGA) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "TMP_TIPO_CARGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal TMP_TEMPO_MEDIO_UNITARIO
                                    {
                                        get => _inner.TMP_TEMPO_MEDIO_UNITARIO;
                                        set
                                        {
                                            if (_inner.TMP_TEMPO_MEDIO_UNITARIO != value)
                                            {
                                                _inner.TMP_TEMPO_MEDIO_UNITARIO = value;
                                                if ((_trackingMask & TemposLogisticosTrackingFields.TMP_TEMPO_MEDIO_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "TMP_TEMPO_MEDIO_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemposLogisticosTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemposLogisticosTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemposLogisticosTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemposLogisticosTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemposLogisticosTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TemposLogisticos", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration