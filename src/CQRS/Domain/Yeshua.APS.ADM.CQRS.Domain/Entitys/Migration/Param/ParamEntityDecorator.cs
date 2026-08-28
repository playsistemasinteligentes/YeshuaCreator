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
                    public static class ParamTrackingFields
        {
            public const ulong PAR_ID = 1UL << 0;
            public const ulong PAR_DESCRICAO = 1UL << 1;
            public const ulong PAR_VALOR_S = 1UL << 2;
            public const ulong PAR_VALOR_N = 1UL << 3;
            public const ulong PAR_VALOR_D = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class ParamDecorator : IParamEntity
{

                        private readonly IParamEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ParamDecorator(IParamEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ParamDecorator(
                            IParamEntity inner,
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
                                    public string PAR_ID
                                    {
                                        get => _inner.PAR_ID;
                                        set
                                        {
                                            if (_inner.PAR_ID != value)
                                            {
                                                _inner.PAR_ID = value;
                                                if ((_trackingMask & ParamTrackingFields.PAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("Param", "PAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PAR_DESCRICAO
                                    {
                                        get => _inner.PAR_DESCRICAO;
                                        set
                                        {
                                            if (_inner.PAR_DESCRICAO != value)
                                            {
                                                _inner.PAR_DESCRICAO = value;
                                                if ((_trackingMask & ParamTrackingFields.PAR_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Param", "PAR_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PAR_VALOR_S
                                    {
                                        get => _inner.PAR_VALOR_S;
                                        set
                                        {
                                            if (_inner.PAR_VALOR_S != value)
                                            {
                                                _inner.PAR_VALOR_S = value;
                                                if ((_trackingMask & ParamTrackingFields.PAR_VALOR_S) != 0UL)
                                                    _logger.DomainValueChanged("Param", "PAR_VALOR_S", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal PAR_VALOR_N
                                    {
                                        get => _inner.PAR_VALOR_N;
                                        set
                                        {
                                            if (_inner.PAR_VALOR_N != value)
                                            {
                                                _inner.PAR_VALOR_N = value;
                                                if ((_trackingMask & ParamTrackingFields.PAR_VALOR_N) != 0UL)
                                                    _logger.DomainValueChanged("Param", "PAR_VALOR_N", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime PAR_VALOR_D
                                    {
                                        get => _inner.PAR_VALOR_D;
                                        set
                                        {
                                            if (_inner.PAR_VALOR_D != value)
                                            {
                                                _inner.PAR_VALOR_D = value;
                                                if ((_trackingMask & ParamTrackingFields.PAR_VALOR_D) != 0UL)
                                                    _logger.DomainValueChanged("Param", "PAR_VALOR_D", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ParamTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Param", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ParamTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Param", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ParamTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Param", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ParamTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Param", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration