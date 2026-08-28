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
                    public static class ItensOrcamentoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ITO_ID = 1UL << 1;
            public const ulong ORC_ID = 1UL << 2;
            public const ulong TIP_ID = 1UL << 3;
            public const ulong PRO_ID = 1UL << 4;
            public const ulong ITO_OBS = 1UL << 5;
            public const ulong ITO_QUANTIDADE = 1UL << 6;
            public const ulong ITO_CUSTO = 1UL << 7;
            public const ulong ITO_MARGEM = 1UL << 8;
            public const ulong ITO_VALOR_UNITARIO = 1UL << 9;
            public const ulong ITO_VERSSAO_CUSTO = 1UL << 10;
            public const ulong ITO_STATUS = 1UL << 11;
            public const ulong ITO_ERP_CUSTOS_FIXOS = 1UL << 12;
            public const ulong ITO_ERP_CUSTOS_VARIAVEIS = 1UL << 13;
            public const ulong ITO_ERP_DESPESAS_VAR_VENDA = 1UL << 14;
            public const ulong ITO_ERP_IMPOSTOS = 1UL << 15;
            public const ulong GRP_ID_COMPOSICAO = 1UL << 16;
            public const ulong ITO_LARGURA = 1UL << 17;
            public const ulong ITO_COMPRIMENTO = 1UL << 18;
            public const ulong TenantID = 1UL << 19;
            public const ulong Deleted = 1UL << 20;
            public const ulong Changed = 1UL << 21;
            public const ulong UserId = 1UL << 22;
        }

        public partial class ItensOrcamentoDecorator : IItensOrcamentoEntity
{

                        private readonly IItensOrcamentoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ItensOrcamentoDecorator(IItensOrcamentoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ItensOrcamentoDecorator(
                            IItensOrcamentoEntity inner,
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
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int ITO_ID
                                    {
                                        get => _inner.ITO_ID;
                                        set
                                        {
                                            if (_inner.ITO_ID != value)
                                            {
                                                _inner.ITO_ID = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ORC_ID
                                    {
                                        get => _inner.ORC_ID;
                                        set
                                        {
                                            if (_inner.ORC_ID != value)
                                            {
                                                _inner.ORC_ID = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ORC_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ORC_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TIP_ID
                                    {
                                        get => _inner.TIP_ID;
                                        set
                                        {
                                            if (_inner.TIP_ID != value)
                                            {
                                                _inner.TIP_ID = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.TIP_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "TIP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID
                                    {
                                        get => _inner.PRO_ID;
                                        set
                                        {
                                            if (_inner.PRO_ID != value)
                                            {
                                                _inner.PRO_ID = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ITO_OBS
                                    {
                                        get => _inner.ITO_OBS;
                                        set
                                        {
                                            if (_inner.ITO_OBS != value)
                                            {
                                                _inner.ITO_OBS = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_OBS) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_OBS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_QUANTIDADE
                                    {
                                        get => _inner.ITO_QUANTIDADE;
                                        set
                                        {
                                            if (_inner.ITO_QUANTIDADE != value)
                                            {
                                                _inner.ITO_QUANTIDADE = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_QUANTIDADE) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_QUANTIDADE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_CUSTO
                                    {
                                        get => _inner.ITO_CUSTO;
                                        set
                                        {
                                            if (_inner.ITO_CUSTO != value)
                                            {
                                                _inner.ITO_CUSTO = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_CUSTO) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_CUSTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_MARGEM
                                    {
                                        get => _inner.ITO_MARGEM;
                                        set
                                        {
                                            if (_inner.ITO_MARGEM != value)
                                            {
                                                _inner.ITO_MARGEM = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_MARGEM) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_MARGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_VALOR_UNITARIO
                                    {
                                        get => _inner.ITO_VALOR_UNITARIO;
                                        set
                                        {
                                            if (_inner.ITO_VALOR_UNITARIO != value)
                                            {
                                                _inner.ITO_VALOR_UNITARIO = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_VALOR_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_VALOR_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? ITO_VERSSAO_CUSTO
                                    {
                                        get => _inner.ITO_VERSSAO_CUSTO;
                                        set
                                        {
                                            if (_inner.ITO_VERSSAO_CUSTO != value)
                                            {
                                                _inner.ITO_VERSSAO_CUSTO = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_VERSSAO_CUSTO) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_VERSSAO_CUSTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ITO_STATUS
                                    {
                                        get => _inner.ITO_STATUS;
                                        set
                                        {
                                            if (_inner.ITO_STATUS != value)
                                            {
                                                _inner.ITO_STATUS = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_ERP_CUSTOS_FIXOS
                                    {
                                        get => _inner.ITO_ERP_CUSTOS_FIXOS;
                                        set
                                        {
                                            if (_inner.ITO_ERP_CUSTOS_FIXOS != value)
                                            {
                                                _inner.ITO_ERP_CUSTOS_FIXOS = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_ERP_CUSTOS_FIXOS) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_ERP_CUSTOS_FIXOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_ERP_CUSTOS_VARIAVEIS
                                    {
                                        get => _inner.ITO_ERP_CUSTOS_VARIAVEIS;
                                        set
                                        {
                                            if (_inner.ITO_ERP_CUSTOS_VARIAVEIS != value)
                                            {
                                                _inner.ITO_ERP_CUSTOS_VARIAVEIS = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_ERP_CUSTOS_VARIAVEIS) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_ERP_CUSTOS_VARIAVEIS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_ERP_DESPESAS_VAR_VENDA
                                    {
                                        get => _inner.ITO_ERP_DESPESAS_VAR_VENDA;
                                        set
                                        {
                                            if (_inner.ITO_ERP_DESPESAS_VAR_VENDA != value)
                                            {
                                                _inner.ITO_ERP_DESPESAS_VAR_VENDA = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_ERP_DESPESAS_VAR_VENDA) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_ERP_DESPESAS_VAR_VENDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_ERP_IMPOSTOS
                                    {
                                        get => _inner.ITO_ERP_IMPOSTOS;
                                        set
                                        {
                                            if (_inner.ITO_ERP_IMPOSTOS != value)
                                            {
                                                _inner.ITO_ERP_IMPOSTOS = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_ERP_IMPOSTOS) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_ERP_IMPOSTOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRP_ID_COMPOSICAO
                                    {
                                        get => _inner.GRP_ID_COMPOSICAO;
                                        set
                                        {
                                            if (_inner.GRP_ID_COMPOSICAO != value)
                                            {
                                                _inner.GRP_ID_COMPOSICAO = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.GRP_ID_COMPOSICAO) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "GRP_ID_COMPOSICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_LARGURA
                                    {
                                        get => _inner.ITO_LARGURA;
                                        set
                                        {
                                            if (_inner.ITO_LARGURA != value)
                                            {
                                                _inner.ITO_LARGURA = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITO_COMPRIMENTO
                                    {
                                        get => _inner.ITO_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.ITO_COMPRIMENTO != value)
                                            {
                                                _inner.ITO_COMPRIMENTO = value;
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.ITO_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "ITO_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItensOrcamentoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ItensOrcamento", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration