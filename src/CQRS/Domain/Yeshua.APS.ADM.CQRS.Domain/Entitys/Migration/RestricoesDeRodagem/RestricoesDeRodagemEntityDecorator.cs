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
                    public static class RestricoesDeRodagemTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong RES_ID = 1UL << 1;
            public const ulong RES_TIPO = 1UL << 2;
            public const ulong RES_HORA_INI = 1UL << 3;
            public const ulong RES_HORA_FIM = 1UL << 4;
            public const ulong RES_VELOCIDADE_HORA_RUSH = 1UL << 5;
            public const ulong TVE_ID = 1UL << 6;
            public const ulong MAP_ID = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class RestricoesDeRodagemDecorator : IRestricoesDeRodagemEntity
{

                        private readonly IRestricoesDeRodagemEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RestricoesDeRodagemDecorator(IRestricoesDeRodagemEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RestricoesDeRodagemDecorator(
                            IRestricoesDeRodagemEntity inner,
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
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int RES_ID
                                    {
                                        get => _inner.RES_ID;
                                        set
                                        {
                                            if (_inner.RES_ID != value)
                                            {
                                                _inner.RES_ID = value;
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.RES_ID) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "RES_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string RES_TIPO
                                    {
                                        get => _inner.RES_TIPO;
                                        set
                                        {
                                            if (_inner.RES_TIPO != value)
                                            {
                                                _inner.RES_TIPO = value;
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.RES_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "RES_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string RES_HORA_INI
                                    {
                                        get => _inner.RES_HORA_INI;
                                        set
                                        {
                                            if (_inner.RES_HORA_INI != value)
                                            {
                                                _inner.RES_HORA_INI = value;
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.RES_HORA_INI) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "RES_HORA_INI", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string RES_HORA_FIM
                                    {
                                        get => _inner.RES_HORA_FIM;
                                        set
                                        {
                                            if (_inner.RES_HORA_FIM != value)
                                            {
                                                _inner.RES_HORA_FIM = value;
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.RES_HORA_FIM) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "RES_HORA_FIM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? RES_VELOCIDADE_HORA_RUSH
                                    {
                                        get => _inner.RES_VELOCIDADE_HORA_RUSH;
                                        set
                                        {
                                            if (_inner.RES_VELOCIDADE_HORA_RUSH != value)
                                            {
                                                _inner.RES_VELOCIDADE_HORA_RUSH = value;
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.RES_VELOCIDADE_HORA_RUSH) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "RES_VELOCIDADE_HORA_RUSH", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TVE_ID
                                    {
                                        get => _inner.TVE_ID;
                                        set
                                        {
                                            if (_inner.TVE_ID != value)
                                            {
                                                _inner.TVE_ID = value;
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.TVE_ID) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "TVE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAP_ID
                                    {
                                        get => _inner.MAP_ID;
                                        set
                                        {
                                            if (_inner.MAP_ID != value)
                                            {
                                                _inner.MAP_ID = value;
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.MAP_ID) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "MAP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RestricoesDeRodagemTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("RestricoesDeRodagem", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration