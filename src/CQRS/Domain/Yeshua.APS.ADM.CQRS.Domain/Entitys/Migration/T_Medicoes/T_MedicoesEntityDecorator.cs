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
                    public static class T_MedicoesTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MED_ID = 1UL << 1;
            public const ulong IND_ID = 1UL << 2;
            public const ulong MET_ID = 1UL << 3;
            public const ulong UNI_ID = 1UL << 4;
            public const ulong MED_DATA = 1UL << 5;
            public const ulong MED_VALOR = 1UL << 6;
            public const ulong MED_AC_ANO = 1UL << 7;
            public const ulong MED_DATAMEDICAO = 1UL << 8;
            public const ulong MED_PONDERACAO = 1UL << 9;
            public const ulong DIM_ID = 1UL << 10;
            public const ulong DIM_DESCRICAO = 1UL << 11;
            public const ulong DIM_SUBDIMENSAO_ID = 1UL << 12;
            public const ulong DIM_SUB_DESCRICAO = 1UL << 13;
            public const ulong PER_ID = 1UL << 14;
            public const ulong PER_DESCRICAO = 1UL << 15;
            public const ulong FAT_ID = 1UL << 16;
            public const ulong FAT_DESCRICAO = 1UL << 17;
            public const ulong MED_SQL = 1UL << 18;
            public const ulong DOM_EMPRESA = 1UL << 19;
            public const ulong DOM_FILIAL = 1UL << 20;
            public const ulong MED_VALOR_DISPER = 1UL << 21;
            public const ulong TenantID = 1UL << 22;
            public const ulong Deleted = 1UL << 23;
            public const ulong Changed = 1UL << 24;
            public const ulong UserId = 1UL << 25;
        }

        public partial class T_MedicoesDecorator : IT_MedicoesEntity
{

                        private readonly IT_MedicoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_MedicoesDecorator(IT_MedicoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_MedicoesDecorator(
                            IT_MedicoesEntity inner,
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MED_ID
                                    {
                                        get => _inner.MED_ID;
                                        set
                                        {
                                            if (_inner.MED_ID != value)
                                            {
                                                _inner.MED_ID = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MED_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MED_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? IND_ID
                                    {
                                        get => _inner.IND_ID;
                                        set
                                        {
                                            if (_inner.IND_ID != value)
                                            {
                                                _inner.IND_ID = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.IND_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "IND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MET_ID
                                    {
                                        get => _inner.MET_ID;
                                        set
                                        {
                                            if (_inner.MET_ID != value)
                                            {
                                                _inner.MET_ID = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MET_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MET_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? UNI_ID
                                    {
                                        get => _inner.UNI_ID;
                                        set
                                        {
                                            if (_inner.UNI_ID != value)
                                            {
                                                _inner.UNI_ID = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime MED_DATA
                                    {
                                        get => _inner.MED_DATA;
                                        set
                                        {
                                            if (_inner.MED_DATA != value)
                                            {
                                                _inner.MED_DATA = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MED_DATA) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MED_DATA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MED_VALOR
                                    {
                                        get => _inner.MED_VALOR;
                                        set
                                        {
                                            if (_inner.MED_VALOR != value)
                                            {
                                                _inner.MED_VALOR = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MED_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MED_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MED_AC_ANO
                                    {
                                        get => _inner.MED_AC_ANO;
                                        set
                                        {
                                            if (_inner.MED_AC_ANO != value)
                                            {
                                                _inner.MED_AC_ANO = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MED_AC_ANO) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MED_AC_ANO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MED_DATAMEDICAO
                                    {
                                        get => _inner.MED_DATAMEDICAO;
                                        set
                                        {
                                            if (_inner.MED_DATAMEDICAO != value)
                                            {
                                                _inner.MED_DATAMEDICAO = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MED_DATAMEDICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MED_DATAMEDICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MED_PONDERACAO
                                    {
                                        get => _inner.MED_PONDERACAO;
                                        set
                                        {
                                            if (_inner.MED_PONDERACAO != value)
                                            {
                                                _inner.MED_PONDERACAO = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MED_PONDERACAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MED_PONDERACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DIM_ID
                                    {
                                        get => _inner.DIM_ID;
                                        set
                                        {
                                            if (_inner.DIM_ID != value)
                                            {
                                                _inner.DIM_ID = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.DIM_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "DIM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.DIM_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "DIM_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.DIM_SUBDIMENSAO_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "DIM_SUBDIMENSAO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DIM_SUB_DESCRICAO
                                    {
                                        get => _inner.DIM_SUB_DESCRICAO;
                                        set
                                        {
                                            if (_inner.DIM_SUB_DESCRICAO != value)
                                            {
                                                _inner.DIM_SUB_DESCRICAO = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.DIM_SUB_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "DIM_SUB_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.PER_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "PER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PER_DESCRICAO
                                    {
                                        get => _inner.PER_DESCRICAO;
                                        set
                                        {
                                            if (_inner.PER_DESCRICAO != value)
                                            {
                                                _inner.PER_DESCRICAO = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.PER_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "PER_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.FAT_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "FAT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.FAT_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "FAT_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MED_SQL
                                    {
                                        get => _inner.MED_SQL;
                                        set
                                        {
                                            if (_inner.MED_SQL != value)
                                            {
                                                _inner.MED_SQL = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MED_SQL) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MED_SQL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.DOM_EMPRESA) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "DOM_EMPRESA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.DOM_FILIAL) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "DOM_FILIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MED_VALOR_DISPER
                                    {
                                        get => _inner.MED_VALOR_DISPER;
                                        set
                                        {
                                            if (_inner.MED_VALOR_DISPER != value)
                                            {
                                                _inner.MED_VALOR_DISPER = value;
                                                if ((_trackingMask & T_MedicoesTrackingFields.MED_VALOR_DISPER) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "MED_VALOR_DISPER", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_MedicoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_Medicoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration