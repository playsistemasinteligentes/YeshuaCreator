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
                    public static class ClpMedicoesHTrackingFields
        {
            public const ulong ID = 1UL << 0;
            public const ulong MAQUINA_ID = 1UL << 1;
            public const ulong DATA_INI = 1UL << 2;
            public const ulong DATA_FIM = 1UL << 3;
            public const ulong CLP_EMISSAO = 1UL << 4;
            public const ulong QTD = 1UL << 5;
            public const ulong GRUPO = 1UL << 6;
            public const ulong STATUS = 1UL << 7;
            public const ulong URN_ID = 1UL << 8;
            public const ulong URM_ID = 1UL << 9;
            public const ulong ID_LOTE_CLP = 1UL << 10;
            public const ulong OCO_ID = 1UL << 11;
            public const ulong FASE = 1UL << 12;
            public const ulong CLP_ORIGEM = 1UL << 13;
            public const ulong CLP_LOTE = 1UL << 14;
            public const ulong COMPACTA = 1UL << 15;
            public const ulong BOL_ID = 1UL << 16;
            public const ulong COR_SEQUENCIA = 1UL << 17;
            public const ulong TenantID = 1UL << 18;
            public const ulong Deleted = 1UL << 19;
            public const ulong Changed = 1UL << 20;
            public const ulong UserId = 1UL << 21;
        }

        public partial class ClpMedicoesHDecorator : IClpMedicoesHEntity
{

                        private readonly IClpMedicoesHEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ClpMedicoesHDecorator(IClpMedicoesHEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ClpMedicoesHDecorator(
                            IClpMedicoesHEntity inner,
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
                                    public int ID
                                    {
                                        get => _inner.ID;
                                        set
                                        {
                                            if (_inner.ID != value)
                                            {
                                                _inner.ID = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.ID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQUINA_ID
                                    {
                                        get => _inner.MAQUINA_ID;
                                        set
                                        {
                                            if (_inner.MAQUINA_ID != value)
                                            {
                                                _inner.MAQUINA_ID = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.MAQUINA_ID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "MAQUINA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DATA_INI
                                    {
                                        get => _inner.DATA_INI;
                                        set
                                        {
                                            if (_inner.DATA_INI != value)
                                            {
                                                _inner.DATA_INI = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.DATA_INI) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "DATA_INI", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DATA_FIM
                                    {
                                        get => _inner.DATA_FIM;
                                        set
                                        {
                                            if (_inner.DATA_FIM != value)
                                            {
                                                _inner.DATA_FIM = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.DATA_FIM) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "DATA_FIM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CLP_EMISSAO
                                    {
                                        get => _inner.CLP_EMISSAO;
                                        set
                                        {
                                            if (_inner.CLP_EMISSAO != value)
                                            {
                                                _inner.CLP_EMISSAO = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.CLP_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "CLP_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal QTD
                                    {
                                        get => _inner.QTD;
                                        set
                                        {
                                            if (_inner.QTD != value)
                                            {
                                                _inner.QTD = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.QTD) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "QTD", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? GRUPO
                                    {
                                        get => _inner.GRUPO;
                                        set
                                        {
                                            if (_inner.GRUPO != value)
                                            {
                                                _inner.GRUPO = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.GRUPO) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "GRUPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? STATUS
                                    {
                                        get => _inner.STATUS;
                                        set
                                        {
                                            if (_inner.STATUS != value)
                                            {
                                                _inner.STATUS = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.STATUS) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string URN_ID
                                    {
                                        get => _inner.URN_ID;
                                        set
                                        {
                                            if (_inner.URN_ID != value)
                                            {
                                                _inner.URN_ID = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.URN_ID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "URN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string URM_ID
                                    {
                                        get => _inner.URM_ID;
                                        set
                                        {
                                            if (_inner.URM_ID != value)
                                            {
                                                _inner.URM_ID = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.URM_ID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "URM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int ID_LOTE_CLP
                                    {
                                        get => _inner.ID_LOTE_CLP;
                                        set
                                        {
                                            if (_inner.ID_LOTE_CLP != value)
                                            {
                                                _inner.ID_LOTE_CLP = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.ID_LOTE_CLP) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "ID_LOTE_CLP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OCO_ID
                                    {
                                        get => _inner.OCO_ID;
                                        set
                                        {
                                            if (_inner.OCO_ID != value)
                                            {
                                                _inner.OCO_ID = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.OCO_ID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "OCO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FASE
                                    {
                                        get => _inner.FASE;
                                        set
                                        {
                                            if (_inner.FASE != value)
                                            {
                                                _inner.FASE = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.FASE) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "FASE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLP_ORIGEM
                                    {
                                        get => _inner.CLP_ORIGEM;
                                        set
                                        {
                                            if (_inner.CLP_ORIGEM != value)
                                            {
                                                _inner.CLP_ORIGEM = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.CLP_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "CLP_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CLP_LOTE
                                    {
                                        get => _inner.CLP_LOTE;
                                        set
                                        {
                                            if (_inner.CLP_LOTE != value)
                                            {
                                                _inner.CLP_LOTE = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.CLP_LOTE) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "CLP_LOTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COMPACTA
                                    {
                                        get => _inner.COMPACTA;
                                        set
                                        {
                                            if (_inner.COMPACTA != value)
                                            {
                                                _inner.COMPACTA = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.COMPACTA) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "COMPACTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string BOL_ID
                                    {
                                        get => _inner.BOL_ID;
                                        set
                                        {
                                            if (_inner.BOL_ID != value)
                                            {
                                                _inner.BOL_ID = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.BOL_ID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "BOL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_SEQUENCIA
                                    {
                                        get => _inner.COR_SEQUENCIA;
                                        set
                                        {
                                            if (_inner.COR_SEQUENCIA != value)
                                            {
                                                _inner.COR_SEQUENCIA = value;
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.COR_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "COR_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClpMedicoesHTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoesH", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration