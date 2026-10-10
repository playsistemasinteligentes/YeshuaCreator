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
                    public static class T_IndicadoresTrackingFields
        {
            public const ulong IND_ID = 1UL << 0;
            public const ulong IND_DESCRICAO = 1UL << 1;
            public const ulong NEG_ID = 1UL << 2;
            public const ulong DESC_CALCULO = 1UL << 3;
            public const ulong IND_TIPOCOMPARADOR = 1UL << 4;
            public const ulong IND_GRAFICO = 1UL << 5;
            public const ulong IND_CONEXAO = 1UL << 6;
            public const ulong IND_DTCRIACAO = 1UL << 7;
            public const ulong RESPOSAVELIND = 1UL << 8;
            public const ulong RESPOSAVELCARGA = 1UL << 9;
            public const ulong PROCEXTRACAO = 1UL << 10;
            public const ulong PER_ID = 1UL << 11;
            public const ulong DIM_ID = 1UL << 12;
            public const ulong DOM_EMPRESA = 1UL << 13;
            public const ulong DOM_FILIAL = 1UL << 14;
            public const ulong TenantID = 1UL << 15;
            public const ulong Deleted = 1UL << 16;
            public const ulong Changed = 1UL << 17;
            public const ulong UserId = 1UL << 18;
            public const ulong OperationalEntityId = 1UL << 19;
        }

        public static class T_IndicadoresOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification IND_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IND_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification NEG_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DESC_CALCULO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IND_TIPOCOMPARADOR = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IND_GRAFICO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IND_CONEXAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IND_DTCRIACAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RESPOSAVELIND = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RESPOSAVELCARGA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PROCEXTRACAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PER_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DIM_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DOM_EMPRESA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DOM_FILIAL = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class T_IndicadoresDecorator : IT_IndicadoresEntity
{

                        private readonly IT_IndicadoresEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_IndicadoresDecorator(IT_IndicadoresEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_IndicadoresDecorator(
                            IT_IndicadoresEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingExecutionIdentity = context is null
                                ? default
                                : new Dominio.Operational.OperationalExecutionIdentity(
                                    context.RootOperationId,
                                    context.OperationId,
                                    context.ExecutionId,
                                    context.CausationId);
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public int IND_ID
                                    {
                                        get => _inner.IND_ID;
                                        set
                                        {
                                            if (_inner.IND_ID != value)
                                            {
                                                _inner.IND_ID = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.IND_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "IND_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.IND_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string IND_DESCRICAO
                                    {
                                        get => _inner.IND_DESCRICAO;
                                        set
                                        {
                                            if (_inner.IND_DESCRICAO != value)
                                            {
                                                _inner.IND_DESCRICAO = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.IND_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "IND_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.IND_DESCRICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int NEG_ID
                                    {
                                        get => _inner.NEG_ID;
                                        set
                                        {
                                            if (_inner.NEG_ID != value)
                                            {
                                                _inner.NEG_ID = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.NEG_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "NEG_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.NEG_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? DESC_CALCULO
                                    {
                                        get => _inner.DESC_CALCULO;
                                        set
                                        {
                                            if (_inner.DESC_CALCULO != value)
                                            {
                                                _inner.DESC_CALCULO = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.DESC_CALCULO) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "DESC_CALCULO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.DESC_CALCULO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int IND_TIPOCOMPARADOR
                                    {
                                        get => _inner.IND_TIPOCOMPARADOR;
                                        set
                                        {
                                            if (_inner.IND_TIPOCOMPARADOR != value)
                                            {
                                                _inner.IND_TIPOCOMPARADOR = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.IND_TIPOCOMPARADOR) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "IND_TIPOCOMPARADOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.IND_TIPOCOMPARADOR, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? IND_GRAFICO
                                    {
                                        get => _inner.IND_GRAFICO;
                                        set
                                        {
                                            if (_inner.IND_GRAFICO != value)
                                            {
                                                _inner.IND_GRAFICO = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.IND_GRAFICO) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "IND_GRAFICO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.IND_GRAFICO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? IND_CONEXAO
                                    {
                                        get => _inner.IND_CONEXAO;
                                        set
                                        {
                                            if (_inner.IND_CONEXAO != value)
                                            {
                                                _inner.IND_CONEXAO = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.IND_CONEXAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "IND_CONEXAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.IND_CONEXAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? IND_DTCRIACAO
                                    {
                                        get => _inner.IND_DTCRIACAO;
                                        set
                                        {
                                            if (_inner.IND_DTCRIACAO != value)
                                            {
                                                _inner.IND_DTCRIACAO = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.IND_DTCRIACAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "IND_DTCRIACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.IND_DTCRIACAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? RESPOSAVELIND
                                    {
                                        get => _inner.RESPOSAVELIND;
                                        set
                                        {
                                            if (_inner.RESPOSAVELIND != value)
                                            {
                                                _inner.RESPOSAVELIND = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.RESPOSAVELIND) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "RESPOSAVELIND", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.RESPOSAVELIND, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? RESPOSAVELCARGA
                                    {
                                        get => _inner.RESPOSAVELCARGA;
                                        set
                                        {
                                            if (_inner.RESPOSAVELCARGA != value)
                                            {
                                                _inner.RESPOSAVELCARGA = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.RESPOSAVELCARGA) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "RESPOSAVELCARGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.RESPOSAVELCARGA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PROCEXTRACAO
                                    {
                                        get => _inner.PROCEXTRACAO;
                                        set
                                        {
                                            if (_inner.PROCEXTRACAO != value)
                                            {
                                                _inner.PROCEXTRACAO = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.PROCEXTRACAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "PROCEXTRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.PROCEXTRACAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PER_ID
                                    {
                                        get => _inner.PER_ID;
                                        set
                                        {
                                            if (_inner.PER_ID != value)
                                            {
                                                _inner.PER_ID = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.PER_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "PER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.PER_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? DIM_ID
                                    {
                                        get => _inner.DIM_ID;
                                        set
                                        {
                                            if (_inner.DIM_ID != value)
                                            {
                                                _inner.DIM_ID = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.DIM_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "DIM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.DIM_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? DOM_EMPRESA
                                    {
                                        get => _inner.DOM_EMPRESA;
                                        set
                                        {
                                            if (_inner.DOM_EMPRESA != value)
                                            {
                                                _inner.DOM_EMPRESA = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.DOM_EMPRESA) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "DOM_EMPRESA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.DOM_EMPRESA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? DOM_FILIAL
                                    {
                                        get => _inner.DOM_FILIAL;
                                        set
                                        {
                                            if (_inner.DOM_FILIAL != value)
                                            {
                                                _inner.DOM_FILIAL = value;
                                                if ((_trackingMask & T_IndicadoresTrackingFields.DOM_FILIAL) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "DOM_FILIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.DOM_FILIAL, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & T_IndicadoresTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & T_IndicadoresTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & T_IndicadoresTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & T_IndicadoresTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_Indicadores", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, T_IndicadoresOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration