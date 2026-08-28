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
                    public static class IndicadoresDimencoesTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong DIM_ID = 1UL << 1;
            public const ulong IND_ID = 1UL << 2;
            public const ulong DIM_DESCRICAO = 1UL << 3;
            public const ulong DIM_SQL = 1UL << 4;
            public const ulong DIM_CONEXAO = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class IndicadoresDimencoesDecorator : IIndicadoresDimencoesEntity
{

                        private readonly IIndicadoresDimencoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public IndicadoresDimencoesDecorator(IIndicadoresDimencoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public IndicadoresDimencoesDecorator(
                            IIndicadoresDimencoesEntity inner,
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
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int DIM_ID
                                    {
                                        get => _inner.DIM_ID;
                                        set
                                        {
                                            if (_inner.DIM_ID != value)
                                            {
                                                _inner.DIM_ID = value;
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.DIM_ID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "DIM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int IND_ID
                                    {
                                        get => _inner.IND_ID;
                                        set
                                        {
                                            if (_inner.IND_ID != value)
                                            {
                                                _inner.IND_ID = value;
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.IND_ID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "IND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DIM_DESCRICAO
                                    {
                                        get => _inner.DIM_DESCRICAO;
                                        set
                                        {
                                            if (_inner.DIM_DESCRICAO != value)
                                            {
                                                _inner.DIM_DESCRICAO = value;
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.DIM_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "DIM_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DIM_SQL
                                    {
                                        get => _inner.DIM_SQL;
                                        set
                                        {
                                            if (_inner.DIM_SQL != value)
                                            {
                                                _inner.DIM_SQL = value;
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.DIM_SQL) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "DIM_SQL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DIM_CONEXAO
                                    {
                                        get => _inner.DIM_CONEXAO;
                                        set
                                        {
                                            if (_inner.DIM_CONEXAO != value)
                                            {
                                                _inner.DIM_CONEXAO = value;
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.DIM_CONEXAO) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "DIM_CONEXAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresDimencoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresDimencoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration