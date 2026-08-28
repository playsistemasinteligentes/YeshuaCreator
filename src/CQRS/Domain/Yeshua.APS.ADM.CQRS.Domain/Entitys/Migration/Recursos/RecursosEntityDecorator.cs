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
                    public static class RecursosTrackingFields
        {
            public const ulong REC_ID = 1UL << 0;
            public const ulong REC_DESCRICAO = 1UL << 1;
            public const ulong CAL_ID = 1UL << 2;
            public const ulong REC_CONTROL_IP = 1UL << 3;
            public const ulong GRE_ID = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class RecursosDecorator : IRecursosEntity
{

                        private readonly IRecursosEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RecursosDecorator(IRecursosEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RecursosDecorator(
                            IRecursosEntity inner,
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
                                    public string REC_ID
                                    {
                                        get => _inner.REC_ID;
                                        set
                                        {
                                            if (_inner.REC_ID != value)
                                            {
                                                _inner.REC_ID = value;
                                                if ((_trackingMask & RecursosTrackingFields.REC_ID) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "REC_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REC_DESCRICAO
                                    {
                                        get => _inner.REC_DESCRICAO;
                                        set
                                        {
                                            if (_inner.REC_DESCRICAO != value)
                                            {
                                                _inner.REC_DESCRICAO = value;
                                                if ((_trackingMask & RecursosTrackingFields.REC_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "REC_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RecursosTrackingFields.CAL_ID) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "CAL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REC_CONTROL_IP
                                    {
                                        get => _inner.REC_CONTROL_IP;
                                        set
                                        {
                                            if (_inner.REC_CONTROL_IP != value)
                                            {
                                                _inner.REC_CONTROL_IP = value;
                                                if ((_trackingMask & RecursosTrackingFields.REC_CONTROL_IP) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "REC_CONTROL_IP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRE_ID
                                    {
                                        get => _inner.GRE_ID;
                                        set
                                        {
                                            if (_inner.GRE_ID != value)
                                            {
                                                _inner.GRE_ID = value;
                                                if ((_trackingMask & RecursosTrackingFields.GRE_ID) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "GRE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RecursosTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RecursosTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RecursosTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RecursosTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Recursos", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration