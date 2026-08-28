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
                    public static class PontosMapaTrackingFields
        {
            public const ulong PON_ID = 1UL << 0;
            public const ulong PON_DESCRICAO = 1UL << 1;
            public const ulong PON_TIPO = 1UL << 2;
            public const ulong PON_LATITUDE = 1UL << 3;
            public const ulong PON_LONGITUDE = 1UL << 4;
            public const ulong PON_DISTANCIA_KM = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class PontosMapaDecorator : IPontosMapaEntity
{

                        private readonly IPontosMapaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PontosMapaDecorator(IPontosMapaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PontosMapaDecorator(
                            IPontosMapaEntity inner,
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
                                    public string PON_ID
                                    {
                                        get => _inner.PON_ID;
                                        set
                                        {
                                            if (_inner.PON_ID != value)
                                            {
                                                _inner.PON_ID = value;
                                                if ((_trackingMask & PontosMapaTrackingFields.PON_ID) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "PON_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PON_DESCRICAO
                                    {
                                        get => _inner.PON_DESCRICAO;
                                        set
                                        {
                                            if (_inner.PON_DESCRICAO != value)
                                            {
                                                _inner.PON_DESCRICAO = value;
                                                if ((_trackingMask & PontosMapaTrackingFields.PON_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "PON_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PON_TIPO
                                    {
                                        get => _inner.PON_TIPO;
                                        set
                                        {
                                            if (_inner.PON_TIPO != value)
                                            {
                                                _inner.PON_TIPO = value;
                                                if ((_trackingMask & PontosMapaTrackingFields.PON_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "PON_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PON_LATITUDE
                                    {
                                        get => _inner.PON_LATITUDE;
                                        set
                                        {
                                            if (_inner.PON_LATITUDE != value)
                                            {
                                                _inner.PON_LATITUDE = value;
                                                if ((_trackingMask & PontosMapaTrackingFields.PON_LATITUDE) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "PON_LATITUDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PON_LONGITUDE
                                    {
                                        get => _inner.PON_LONGITUDE;
                                        set
                                        {
                                            if (_inner.PON_LONGITUDE != value)
                                            {
                                                _inner.PON_LONGITUDE = value;
                                                if ((_trackingMask & PontosMapaTrackingFields.PON_LONGITUDE) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "PON_LONGITUDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PON_DISTANCIA_KM
                                    {
                                        get => _inner.PON_DISTANCIA_KM;
                                        set
                                        {
                                            if (_inner.PON_DISTANCIA_KM != value)
                                            {
                                                _inner.PON_DISTANCIA_KM = value;
                                                if ((_trackingMask & PontosMapaTrackingFields.PON_DISTANCIA_KM) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "PON_DISTANCIA_KM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PontosMapaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PontosMapaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PontosMapaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PontosMapaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PontosMapa", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration