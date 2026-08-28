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
                    public static class MunicipioTrackingFields
        {
            public const ulong MUN_ID = 1UL << 0;
            public const ulong MUN_NOME = 1UL << 1;
            public const ulong UF_COD = 1UL << 2;
            public const ulong MUN_CODIGO_IBGE = 1UL << 3;
            public const ulong MUN_LATITUDE = 1UL << 4;
            public const ulong MUN_LONGITUDE = 1UL << 5;
            public const ulong MUN_ID_INTEGRACAO_ERP = 1UL << 6;
            public const ulong MUN_CODIGO_SIAFI = 1UL << 7;
            public const ulong MUN_CODIGO_CNPJ = 1UL << 8;
            public const ulong MUN_DISTANCIA_KM = 1UL << 9;
            public const ulong TenantID = 1UL << 10;
            public const ulong Deleted = 1UL << 11;
            public const ulong Changed = 1UL << 12;
            public const ulong UserId = 1UL << 13;
        }

        public partial class MunicipioDecorator : IMunicipioEntity
{

                        private readonly IMunicipioEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MunicipioDecorator(IMunicipioEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MunicipioDecorator(
                            IMunicipioEntity inner,
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
                                    public string MUN_ID
                                    {
                                        get => _inner.MUN_ID;
                                        set
                                        {
                                            if (_inner.MUN_ID != value)
                                            {
                                                _inner.MUN_ID = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_ID) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MUN_NOME
                                    {
                                        get => _inner.MUN_NOME;
                                        set
                                        {
                                            if (_inner.MUN_NOME != value)
                                            {
                                                _inner.MUN_NOME = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_NOME) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UF_COD
                                    {
                                        get => _inner.UF_COD;
                                        set
                                        {
                                            if (_inner.UF_COD != value)
                                            {
                                                _inner.UF_COD = value;
                                                if ((_trackingMask & MunicipioTrackingFields.UF_COD) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "UF_COD", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MUN_CODIGO_IBGE
                                    {
                                        get => _inner.MUN_CODIGO_IBGE;
                                        set
                                        {
                                            if (_inner.MUN_CODIGO_IBGE != value)
                                            {
                                                _inner.MUN_CODIGO_IBGE = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_CODIGO_IBGE) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_CODIGO_IBGE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MUN_LATITUDE
                                    {
                                        get => _inner.MUN_LATITUDE;
                                        set
                                        {
                                            if (_inner.MUN_LATITUDE != value)
                                            {
                                                _inner.MUN_LATITUDE = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_LATITUDE) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_LATITUDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MUN_LONGITUDE
                                    {
                                        get => _inner.MUN_LONGITUDE;
                                        set
                                        {
                                            if (_inner.MUN_LONGITUDE != value)
                                            {
                                                _inner.MUN_LONGITUDE = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_LONGITUDE) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_LONGITUDE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MUN_ID_INTEGRACAO_ERP
                                    {
                                        get => _inner.MUN_ID_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.MUN_ID_INTEGRACAO_ERP != value)
                                            {
                                                _inner.MUN_ID_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_ID_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_ID_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MUN_CODIGO_SIAFI
                                    {
                                        get => _inner.MUN_CODIGO_SIAFI;
                                        set
                                        {
                                            if (_inner.MUN_CODIGO_SIAFI != value)
                                            {
                                                _inner.MUN_CODIGO_SIAFI = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_CODIGO_SIAFI) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_CODIGO_SIAFI", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MUN_CODIGO_CNPJ
                                    {
                                        get => _inner.MUN_CODIGO_CNPJ;
                                        set
                                        {
                                            if (_inner.MUN_CODIGO_CNPJ != value)
                                            {
                                                _inner.MUN_CODIGO_CNPJ = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_CODIGO_CNPJ) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_CODIGO_CNPJ", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MUN_DISTANCIA_KM
                                    {
                                        get => _inner.MUN_DISTANCIA_KM;
                                        set
                                        {
                                            if (_inner.MUN_DISTANCIA_KM != value)
                                            {
                                                _inner.MUN_DISTANCIA_KM = value;
                                                if ((_trackingMask & MunicipioTrackingFields.MUN_DISTANCIA_KM) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "MUN_DISTANCIA_KM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MunicipioTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MunicipioTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MunicipioTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MunicipioTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Municipio", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration