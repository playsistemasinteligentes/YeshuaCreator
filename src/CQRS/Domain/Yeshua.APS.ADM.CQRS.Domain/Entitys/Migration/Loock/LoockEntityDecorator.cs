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
                    public static class LoockTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong LOO_ID = 1UL << 1;
            public const ulong LOO_DESCRICAO = 1UL << 2;
            public const ulong LOO_CONTEUDO = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public partial class LoockDecorator : ILoockEntity
{

                        private readonly ILoockEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public LoockDecorator(ILoockEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public LoockDecorator(
                            ILoockEntity inner,
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
                                                if ((_trackingMask & LoockTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Loock", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string LOO_ID
                                    {
                                        get => _inner.LOO_ID;
                                        set
                                        {
                                            if (_inner.LOO_ID != value)
                                            {
                                                _inner.LOO_ID = value;
                                                if ((_trackingMask & LoockTrackingFields.LOO_ID) != 0UL)
                                                    _logger.DomainValueChanged("Loock", "LOO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string LOO_DESCRICAO
                                    {
                                        get => _inner.LOO_DESCRICAO;
                                        set
                                        {
                                            if (_inner.LOO_DESCRICAO != value)
                                            {
                                                _inner.LOO_DESCRICAO = value;
                                                if ((_trackingMask & LoockTrackingFields.LOO_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Loock", "LOO_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string LOO_CONTEUDO
                                    {
                                        get => _inner.LOO_CONTEUDO;
                                        set
                                        {
                                            if (_inner.LOO_CONTEUDO != value)
                                            {
                                                _inner.LOO_CONTEUDO = value;
                                                if ((_trackingMask & LoockTrackingFields.LOO_CONTEUDO) != 0UL)
                                                    _logger.DomainValueChanged("Loock", "LOO_CONTEUDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LoockTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Loock", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LoockTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Loock", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LoockTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Loock", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LoockTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Loock", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration