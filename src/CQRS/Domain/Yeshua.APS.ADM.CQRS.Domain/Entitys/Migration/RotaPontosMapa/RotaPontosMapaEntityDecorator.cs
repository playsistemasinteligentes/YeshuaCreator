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
                    public static class RotaPontosMapaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ROT_ID = 1UL << 1;
            public const ulong PON_ID_DESTINO = 1UL << 2;
            public const ulong PON_ID_ORIGEM = 1UL << 3;
            public const ulong ROT_CUSTO_TOTAL = 1UL << 4;
            public const ulong PON_ID_ROTEIRO = 1UL << 5;
            public const ulong ROT_ORDEM_ROTEIRO = 1UL << 6;
            public const ulong ROT_TIPO = 1UL << 7;
            public const ulong ROT_DISTANCIA = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
        }

        public partial class RotaPontosMapaDecorator : IRotaPontosMapaEntity
{

                        private readonly IRotaPontosMapaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RotaPontosMapaDecorator(IRotaPontosMapaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RotaPontosMapaDecorator(
                            IRotaPontosMapaEntity inner,
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
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_ID
                                    {
                                        get => _inner.ROT_ID;
                                        set
                                        {
                                            if (_inner.ROT_ID != value)
                                            {
                                                _inner.ROT_ID = value;
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.ROT_ID) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "ROT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PON_ID_DESTINO
                                    {
                                        get => _inner.PON_ID_DESTINO;
                                        set
                                        {
                                            if (_inner.PON_ID_DESTINO != value)
                                            {
                                                _inner.PON_ID_DESTINO = value;
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.PON_ID_DESTINO) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "PON_ID_DESTINO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PON_ID_ORIGEM
                                    {
                                        get => _inner.PON_ID_ORIGEM;
                                        set
                                        {
                                            if (_inner.PON_ID_ORIGEM != value)
                                            {
                                                _inner.PON_ID_ORIGEM = value;
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.PON_ID_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "PON_ID_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_CUSTO_TOTAL
                                    {
                                        get => _inner.ROT_CUSTO_TOTAL;
                                        set
                                        {
                                            if (_inner.ROT_CUSTO_TOTAL != value)
                                            {
                                                _inner.ROT_CUSTO_TOTAL = value;
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.ROT_CUSTO_TOTAL) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "ROT_CUSTO_TOTAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PON_ID_ROTEIRO
                                    {
                                        get => _inner.PON_ID_ROTEIRO;
                                        set
                                        {
                                            if (_inner.PON_ID_ROTEIRO != value)
                                            {
                                                _inner.PON_ID_ROTEIRO = value;
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.PON_ID_ROTEIRO) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "PON_ID_ROTEIRO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ROT_ORDEM_ROTEIRO
                                    {
                                        get => _inner.ROT_ORDEM_ROTEIRO;
                                        set
                                        {
                                            if (_inner.ROT_ORDEM_ROTEIRO != value)
                                            {
                                                _inner.ROT_ORDEM_ROTEIRO = value;
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.ROT_ORDEM_ROTEIRO) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "ROT_ORDEM_ROTEIRO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_TIPO
                                    {
                                        get => _inner.ROT_TIPO;
                                        set
                                        {
                                            if (_inner.ROT_TIPO != value)
                                            {
                                                _inner.ROT_TIPO = value;
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.ROT_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "ROT_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ROT_DISTANCIA
                                    {
                                        get => _inner.ROT_DISTANCIA;
                                        set
                                        {
                                            if (_inner.ROT_DISTANCIA != value)
                                            {
                                                _inner.ROT_DISTANCIA = value;
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.ROT_DISTANCIA) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "ROT_DISTANCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RotaPontosMapaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("RotaPontosMapa", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration