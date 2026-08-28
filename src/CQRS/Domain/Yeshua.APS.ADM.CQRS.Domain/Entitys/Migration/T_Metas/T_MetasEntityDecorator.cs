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
                    public static class T_MetasTrackingFields
        {
            public const ulong MET_ID = 1UL << 0;
            public const ulong MET_DTINICIO = 1UL << 1;
            public const ulong MET_DTFIM = 1UL << 2;
            public const ulong MET_ALVO = 1UL << 3;
            public const ulong MET_TIPOALVO = 1UL << 4;
            public const ulong IND_ID = 1UL << 5;
            public const ulong MET_RANGE01 = 1UL << 6;
            public const ulong MET_RANGE02 = 1UL << 7;
            public const ulong MET_RANGE03 = 1UL << 8;
            public const ulong DIM_ID = 1UL << 9;
            public const ulong FAT_ID = 1UL << 10;
            public const ulong DIM_SUBDIMENSAO_ID = 1UL << 11;
            public const ulong PER_ID = 1UL << 12;
            public const ulong DOM_EMPRESA = 1UL << 13;
            public const ulong DOM_FILIAL = 1UL << 14;
            public const ulong TenantID = 1UL << 15;
            public const ulong Deleted = 1UL << 16;
            public const ulong Changed = 1UL << 17;
            public const ulong UserId = 1UL << 18;
        }

        public partial class T_MetasDecorator : IT_MetasEntity
{

                        private readonly IT_MetasEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_MetasDecorator(IT_MetasEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_MetasDecorator(
                            IT_MetasEntity inner,
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
                                    public int MET_ID
                                    {
                                        get => _inner.MET_ID;
                                        set
                                        {
                                            if (_inner.MET_ID != value)
                                            {
                                                _inner.MET_ID = value;
                                                if ((_trackingMask & T_MetasTrackingFields.MET_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "MET_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MET_DTINICIO
                                    {
                                        get => _inner.MET_DTINICIO;
                                        set
                                        {
                                            if (_inner.MET_DTINICIO != value)
                                            {
                                                _inner.MET_DTINICIO = value;
                                                if ((_trackingMask & T_MetasTrackingFields.MET_DTINICIO) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "MET_DTINICIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MET_DTFIM
                                    {
                                        get => _inner.MET_DTFIM;
                                        set
                                        {
                                            if (_inner.MET_DTFIM != value)
                                            {
                                                _inner.MET_DTFIM = value;
                                                if ((_trackingMask & T_MetasTrackingFields.MET_DTFIM) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "MET_DTFIM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MET_ALVO
                                    {
                                        get => _inner.MET_ALVO;
                                        set
                                        {
                                            if (_inner.MET_ALVO != value)
                                            {
                                                _inner.MET_ALVO = value;
                                                if ((_trackingMask & T_MetasTrackingFields.MET_ALVO) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "MET_ALVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MET_TIPOALVO
                                    {
                                        get => _inner.MET_TIPOALVO;
                                        set
                                        {
                                            if (_inner.MET_TIPOALVO != value)
                                            {
                                                _inner.MET_TIPOALVO = value;
                                                if ((_trackingMask & T_MetasTrackingFields.MET_TIPOALVO) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "MET_TIPOALVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MetasTrackingFields.IND_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "IND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MET_RANGE01
                                    {
                                        get => _inner.MET_RANGE01;
                                        set
                                        {
                                            if (_inner.MET_RANGE01 != value)
                                            {
                                                _inner.MET_RANGE01 = value;
                                                if ((_trackingMask & T_MetasTrackingFields.MET_RANGE01) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "MET_RANGE01", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MET_RANGE02
                                    {
                                        get => _inner.MET_RANGE02;
                                        set
                                        {
                                            if (_inner.MET_RANGE02 != value)
                                            {
                                                _inner.MET_RANGE02 = value;
                                                if ((_trackingMask & T_MetasTrackingFields.MET_RANGE02) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "MET_RANGE02", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MET_RANGE03
                                    {
                                        get => _inner.MET_RANGE03;
                                        set
                                        {
                                            if (_inner.MET_RANGE03 != value)
                                            {
                                                _inner.MET_RANGE03 = value;
                                                if ((_trackingMask & T_MetasTrackingFields.MET_RANGE03) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "MET_RANGE03", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? DIM_ID
                                    {
                                        get => _inner.DIM_ID;
                                        set
                                        {
                                            if (_inner.DIM_ID != value)
                                            {
                                                _inner.DIM_ID = value;
                                                if ((_trackingMask & T_MetasTrackingFields.DIM_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "DIM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MetasTrackingFields.FAT_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "FAT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DIM_SUBDIMENSAO_ID
                                    {
                                        get => _inner.DIM_SUBDIMENSAO_ID;
                                        set
                                        {
                                            if (_inner.DIM_SUBDIMENSAO_ID != value)
                                            {
                                                _inner.DIM_SUBDIMENSAO_ID = value;
                                                if ((_trackingMask & T_MetasTrackingFields.DIM_SUBDIMENSAO_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "DIM_SUBDIMENSAO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PER_ID
                                    {
                                        get => _inner.PER_ID;
                                        set
                                        {
                                            if (_inner.PER_ID != value)
                                            {
                                                _inner.PER_ID = value;
                                                if ((_trackingMask & T_MetasTrackingFields.PER_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "PER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DOM_EMPRESA
                                    {
                                        get => _inner.DOM_EMPRESA;
                                        set
                                        {
                                            if (_inner.DOM_EMPRESA != value)
                                            {
                                                _inner.DOM_EMPRESA = value;
                                                if ((_trackingMask & T_MetasTrackingFields.DOM_EMPRESA) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "DOM_EMPRESA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DOM_FILIAL
                                    {
                                        get => _inner.DOM_FILIAL;
                                        set
                                        {
                                            if (_inner.DOM_FILIAL != value)
                                            {
                                                _inner.DOM_FILIAL = value;
                                                if ((_trackingMask & T_MetasTrackingFields.DOM_FILIAL) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "DOM_FILIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MetasTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MetasTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MetasTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MetasTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_Metas", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration