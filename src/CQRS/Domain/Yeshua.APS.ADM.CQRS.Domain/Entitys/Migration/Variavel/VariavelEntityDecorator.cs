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
                    public static class VariavelTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong VAR_ID = 1UL << 1;
            public const ulong VAR_DESCRICAO = 1UL << 2;
            public const ulong CON_ID = 1UL << 3;
            public const ulong VAR_MODO = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class VariavelDecorator : IVariavelEntity
{

                        private readonly IVariavelEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public VariavelDecorator(IVariavelEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public VariavelDecorator(
                            IVariavelEntity inner,
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
                                                if ((_trackingMask & VariavelTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int VAR_ID
                                    {
                                        get => _inner.VAR_ID;
                                        set
                                        {
                                            if (_inner.VAR_ID != value)
                                            {
                                                _inner.VAR_ID = value;
                                                if ((_trackingMask & VariavelTrackingFields.VAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "VAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VAR_DESCRICAO
                                    {
                                        get => _inner.VAR_DESCRICAO;
                                        set
                                        {
                                            if (_inner.VAR_DESCRICAO != value)
                                            {
                                                _inner.VAR_DESCRICAO = value;
                                                if ((_trackingMask & VariavelTrackingFields.VAR_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "VAR_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CON_ID
                                    {
                                        get => _inner.CON_ID;
                                        set
                                        {
                                            if (_inner.CON_ID != value)
                                            {
                                                _inner.CON_ID = value;
                                                if ((_trackingMask & VariavelTrackingFields.CON_ID) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "CON_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int VAR_MODO
                                    {
                                        get => _inner.VAR_MODO;
                                        set
                                        {
                                            if (_inner.VAR_MODO != value)
                                            {
                                                _inner.VAR_MODO = value;
                                                if ((_trackingMask & VariavelTrackingFields.VAR_MODO) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "VAR_MODO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VariavelTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VariavelTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VariavelTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VariavelTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Variavel", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration