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
                    public static class IndicadoresFatosDimencoesTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong FAT_ID = 1UL << 1;
            public const ulong IND_ID = 1UL << 2;
            public const ulong DIM_ID = 1UL << 3;
            public const ulong FAT_DESCRICAO = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class IndicadoresFatosDimencoesDecorator : IIndicadoresFatosDimencoesEntity
{

                        private readonly IIndicadoresFatosDimencoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public IndicadoresFatosDimencoesDecorator(IIndicadoresFatosDimencoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public IndicadoresFatosDimencoesDecorator(
                            IIndicadoresFatosDimencoesEntity inner,
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
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FAT_ID
                                    {
                                        get => _inner.FAT_ID;
                                        set
                                        {
                                            if (_inner.FAT_ID != value)
                                            {
                                                _inner.FAT_ID = value;
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.FAT_ID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "FAT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.IND_ID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "IND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.DIM_ID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "DIM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FAT_DESCRICAO
                                    {
                                        get => _inner.FAT_DESCRICAO;
                                        set
                                        {
                                            if (_inner.FAT_DESCRICAO != value)
                                            {
                                                _inner.FAT_DESCRICAO = value;
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.FAT_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "FAT_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & IndicadoresFatosDimencoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("IndicadoresFatosDimencoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration