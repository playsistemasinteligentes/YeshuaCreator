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
                    public static class ObjetoControlavelTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong OBJ_ID = 1UL << 1;
            public const ulong OBJ_DESCRICAO = 1UL << 2;
            public const ulong OBJ_TIPO = 1UL << 3;
            public const ulong OBJ_GRUPO = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class ObjetoControlavelDecorator : IObjetoControlavelEntity
{

                        private readonly IObjetoControlavelEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ObjetoControlavelDecorator(IObjetoControlavelEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ObjetoControlavelDecorator(
                            IObjetoControlavelEntity inner,
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
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OBJ_ID
                                    {
                                        get => _inner.OBJ_ID;
                                        set
                                        {
                                            if (_inner.OBJ_ID != value)
                                            {
                                                _inner.OBJ_ID = value;
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.OBJ_ID) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "OBJ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OBJ_DESCRICAO
                                    {
                                        get => _inner.OBJ_DESCRICAO;
                                        set
                                        {
                                            if (_inner.OBJ_DESCRICAO != value)
                                            {
                                                _inner.OBJ_DESCRICAO = value;
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.OBJ_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "OBJ_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OBJ_TIPO
                                    {
                                        get => _inner.OBJ_TIPO;
                                        set
                                        {
                                            if (_inner.OBJ_TIPO != value)
                                            {
                                                _inner.OBJ_TIPO = value;
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.OBJ_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "OBJ_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OBJ_GRUPO
                                    {
                                        get => _inner.OBJ_GRUPO;
                                        set
                                        {
                                            if (_inner.OBJ_GRUPO != value)
                                            {
                                                _inner.OBJ_GRUPO = value;
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.OBJ_GRUPO) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "OBJ_GRUPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ObjetoControlavelTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ObjetoControlavel", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration