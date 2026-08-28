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
                    public static class MapaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MAP_ID = 1UL << 1;
            public const ulong PON_ID = 1UL << 2;
            public const ulong PON_ID_VIZINHO = 1UL << 3;
            public const ulong MAP_DISTANCIA = 1UL << 4;
            public const ulong MAP_CUSTO_PEDAGIO_POR_EIXO = 1UL << 5;
            public const ulong ROD_ID = 1UL << 6;
            public const ulong MAP_ALTURA_ROD = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class MapaDecorator : IMapaEntity
{

                        private readonly IMapaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MapaDecorator(IMapaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MapaDecorator(
                            IMapaEntity inner,
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
                                                if ((_trackingMask & MapaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MAP_ID
                                    {
                                        get => _inner.MAP_ID;
                                        set
                                        {
                                            if (_inner.MAP_ID != value)
                                            {
                                                _inner.MAP_ID = value;
                                                if ((_trackingMask & MapaTrackingFields.MAP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "MAP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PON_ID
                                    {
                                        get => _inner.PON_ID;
                                        set
                                        {
                                            if (_inner.PON_ID != value)
                                            {
                                                _inner.PON_ID = value;
                                                if ((_trackingMask & MapaTrackingFields.PON_ID) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "PON_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PON_ID_VIZINHO
                                    {
                                        get => _inner.PON_ID_VIZINHO;
                                        set
                                        {
                                            if (_inner.PON_ID_VIZINHO != value)
                                            {
                                                _inner.PON_ID_VIZINHO = value;
                                                if ((_trackingMask & MapaTrackingFields.PON_ID_VIZINHO) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "PON_ID_VIZINHO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal MAP_DISTANCIA
                                    {
                                        get => _inner.MAP_DISTANCIA;
                                        set
                                        {
                                            if (_inner.MAP_DISTANCIA != value)
                                            {
                                                _inner.MAP_DISTANCIA = value;
                                                if ((_trackingMask & MapaTrackingFields.MAP_DISTANCIA) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "MAP_DISTANCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAP_CUSTO_PEDAGIO_POR_EIXO
                                    {
                                        get => _inner.MAP_CUSTO_PEDAGIO_POR_EIXO;
                                        set
                                        {
                                            if (_inner.MAP_CUSTO_PEDAGIO_POR_EIXO != value)
                                            {
                                                _inner.MAP_CUSTO_PEDAGIO_POR_EIXO = value;
                                                if ((_trackingMask & MapaTrackingFields.MAP_CUSTO_PEDAGIO_POR_EIXO) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "MAP_CUSTO_PEDAGIO_POR_EIXO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ROD_ID
                                    {
                                        get => _inner.ROD_ID;
                                        set
                                        {
                                            if (_inner.ROD_ID != value)
                                            {
                                                _inner.ROD_ID = value;
                                                if ((_trackingMask & MapaTrackingFields.ROD_ID) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "ROD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAP_ALTURA_ROD
                                    {
                                        get => _inner.MAP_ALTURA_ROD;
                                        set
                                        {
                                            if (_inner.MAP_ALTURA_ROD != value)
                                            {
                                                _inner.MAP_ALTURA_ROD = value;
                                                if ((_trackingMask & MapaTrackingFields.MAP_ALTURA_ROD) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "MAP_ALTURA_ROD", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MapaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MapaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MapaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MapaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Mapa", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration