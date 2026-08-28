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
                    public static class ParametrosDeCustoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong PAR_ID = 1UL << 1;
            public const ulong PRO_ID = 1UL << 2;
            public const ulong CUS_ID = 1UL << 3;
            public const ulong PAR_VALOR = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class ParametrosDeCustoDecorator : IParametrosDeCustoEntity
{

                        private readonly IParametrosDeCustoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ParametrosDeCustoDecorator(IParametrosDeCustoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ParametrosDeCustoDecorator(
                            IParametrosDeCustoEntity inner,
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
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int PAR_ID
                                    {
                                        get => _inner.PAR_ID;
                                        set
                                        {
                                            if (_inner.PAR_ID != value)
                                            {
                                                _inner.PAR_ID = value;
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.PAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "PAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID
                                    {
                                        get => _inner.PRO_ID;
                                        set
                                        {
                                            if (_inner.PRO_ID != value)
                                            {
                                                _inner.PRO_ID = value;
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CUS_ID
                                    {
                                        get => _inner.CUS_ID;
                                        set
                                        {
                                            if (_inner.CUS_ID != value)
                                            {
                                                _inner.CUS_ID = value;
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.CUS_ID) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "CUS_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PAR_VALOR
                                    {
                                        get => _inner.PAR_VALOR;
                                        set
                                        {
                                            if (_inner.PAR_VALOR != value)
                                            {
                                                _inner.PAR_VALOR = value;
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.PAR_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "PAR_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ParametrosDeCustoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ParametrosDeCusto", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration