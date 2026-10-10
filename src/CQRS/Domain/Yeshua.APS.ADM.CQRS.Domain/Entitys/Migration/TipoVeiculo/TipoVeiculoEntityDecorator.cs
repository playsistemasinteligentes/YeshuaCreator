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
                    public static class TipoVeiculoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TIP_ID = 1UL << 1;
            public const ulong TIP_DESCRICAO = 1UL << 2;
            public const ulong TIP_QTD_DISPONIVEL = 1UL << 3;
            public const ulong TIP_VALOR_KM = 1UL << 4;
            public const ulong TIP_VALOR_DIARIA = 1UL << 5;
            public const ulong TIP_VALOR_AJUDANTE = 1UL << 6;
            public const ulong TIP_QTD_EIXOS = 1UL << 7;
            public const ulong TIP_VELOCIDADE_MEDIA = 1UL << 8;
            public const ulong TIP_CAPACIDADE_ALTURA = 1UL << 9;
            public const ulong TIP_CAPACIDADE_COMPRIMENTO = 1UL << 10;
            public const ulong TIP_CAPACIDADE_LARGURA = 1UL << 11;
            public const ulong TIP_CAPACIDADE_ALTURA_PESCOCO_E = 1UL << 12;
            public const ulong TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E = 1UL << 13;
            public const ulong TIP_CAPACIDADE_LARGURA_PESCOCO_E = 1UL << 14;
            public const ulong TIP_CAPACIDADE_ALTURA_PESCOCO_D = 1UL << 15;
            public const ulong TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D = 1UL << 16;
            public const ulong TIP_CAPACIDADE_LARGURA_PESCOCO_D = 1UL << 17;
            public const ulong TIP_CAPACIDADE_M3 = 1UL << 18;
            public const ulong OperationalEntityId = 1UL << 19;
            public const ulong TenantID = 1UL << 20;
            public const ulong Deleted = 1UL << 21;
            public const ulong Changed = 1UL << 22;
            public const ulong UserId = 1UL << 23;
        }

        public static class TipoVeiculoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_DESCRICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_QTD_DISPONIVEL = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_VALOR_KM = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_VALOR_DIARIA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_VALOR_AJUDANTE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_QTD_EIXOS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_VELOCIDADE_MEDIA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_ALTURA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_COMPRIMENTO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_LARGURA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_ALTURA_PESCOCO_E = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_LARGURA_PESCOCO_E = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_ALTURA_PESCOCO_D = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_LARGURA_PESCOCO_D = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TIP_CAPACIDADE_M3 = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class TipoVeiculoDecorator : ITipoVeiculoEntity
{

                        private readonly ITipoVeiculoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TipoVeiculoDecorator(ITipoVeiculoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TipoVeiculoDecorator(
                            ITipoVeiculoEntity inner,
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
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int TIP_ID
                                    {
                                        get => _inner.TIP_ID;
                                        set
                                        {
                                            if (_inner.TIP_ID != value)
                                            {
                                                _inner.TIP_ID = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_ID) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? TIP_DESCRICAO
                                    {
                                        get => _inner.TIP_DESCRICAO;
                                        set
                                        {
                                            if (_inner.TIP_DESCRICAO != value)
                                            {
                                                _inner.TIP_DESCRICAO = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_DESCRICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? TIP_QTD_DISPONIVEL
                                    {
                                        get => _inner.TIP_QTD_DISPONIVEL;
                                        set
                                        {
                                            if (_inner.TIP_QTD_DISPONIVEL != value)
                                            {
                                                _inner.TIP_QTD_DISPONIVEL = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_QTD_DISPONIVEL) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_QTD_DISPONIVEL", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_QTD_DISPONIVEL, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_VALOR_KM
                                    {
                                        get => _inner.TIP_VALOR_KM;
                                        set
                                        {
                                            if (_inner.TIP_VALOR_KM != value)
                                            {
                                                _inner.TIP_VALOR_KM = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_VALOR_KM) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_VALOR_KM", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_VALOR_KM, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_VALOR_DIARIA
                                    {
                                        get => _inner.TIP_VALOR_DIARIA;
                                        set
                                        {
                                            if (_inner.TIP_VALOR_DIARIA != value)
                                            {
                                                _inner.TIP_VALOR_DIARIA = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_VALOR_DIARIA) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_VALOR_DIARIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_VALOR_DIARIA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_VALOR_AJUDANTE
                                    {
                                        get => _inner.TIP_VALOR_AJUDANTE;
                                        set
                                        {
                                            if (_inner.TIP_VALOR_AJUDANTE != value)
                                            {
                                                _inner.TIP_VALOR_AJUDANTE = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_VALOR_AJUDANTE) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_VALOR_AJUDANTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_VALOR_AJUDANTE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_QTD_EIXOS
                                    {
                                        get => _inner.TIP_QTD_EIXOS;
                                        set
                                        {
                                            if (_inner.TIP_QTD_EIXOS != value)
                                            {
                                                _inner.TIP_QTD_EIXOS = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_QTD_EIXOS) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_QTD_EIXOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_QTD_EIXOS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_VELOCIDADE_MEDIA
                                    {
                                        get => _inner.TIP_VELOCIDADE_MEDIA;
                                        set
                                        {
                                            if (_inner.TIP_VELOCIDADE_MEDIA != value)
                                            {
                                                _inner.TIP_VELOCIDADE_MEDIA = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_VELOCIDADE_MEDIA) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_VELOCIDADE_MEDIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_VELOCIDADE_MEDIA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_ALTURA
                                    {
                                        get => _inner.TIP_CAPACIDADE_ALTURA;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_ALTURA != value)
                                            {
                                                _inner.TIP_CAPACIDADE_ALTURA = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_ALTURA) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_ALTURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_ALTURA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_COMPRIMENTO
                                    {
                                        get => _inner.TIP_CAPACIDADE_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_COMPRIMENTO != value)
                                            {
                                                _inner.TIP_CAPACIDADE_COMPRIMENTO = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_COMPRIMENTO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_LARGURA
                                    {
                                        get => _inner.TIP_CAPACIDADE_LARGURA;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_LARGURA != value)
                                            {
                                                _inner.TIP_CAPACIDADE_LARGURA = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_LARGURA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_E
                                    {
                                        get => _inner.TIP_CAPACIDADE_ALTURA_PESCOCO_E;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_ALTURA_PESCOCO_E != value)
                                            {
                                                _inner.TIP_CAPACIDADE_ALTURA_PESCOCO_E = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_ALTURA_PESCOCO_E) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_ALTURA_PESCOCO_E", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_ALTURA_PESCOCO_E, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E
                                    {
                                        get => _inner.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E != value)
                                            {
                                                _inner.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_E
                                    {
                                        get => _inner.TIP_CAPACIDADE_LARGURA_PESCOCO_E;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_LARGURA_PESCOCO_E != value)
                                            {
                                                _inner.TIP_CAPACIDADE_LARGURA_PESCOCO_E = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_LARGURA_PESCOCO_E) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_LARGURA_PESCOCO_E", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_LARGURA_PESCOCO_E, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_D
                                    {
                                        get => _inner.TIP_CAPACIDADE_ALTURA_PESCOCO_D;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_ALTURA_PESCOCO_D != value)
                                            {
                                                _inner.TIP_CAPACIDADE_ALTURA_PESCOCO_D = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_ALTURA_PESCOCO_D) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_ALTURA_PESCOCO_D", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_ALTURA_PESCOCO_D, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D
                                    {
                                        get => _inner.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D != value)
                                            {
                                                _inner.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_D
                                    {
                                        get => _inner.TIP_CAPACIDADE_LARGURA_PESCOCO_D;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_LARGURA_PESCOCO_D != value)
                                            {
                                                _inner.TIP_CAPACIDADE_LARGURA_PESCOCO_D = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_LARGURA_PESCOCO_D) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_LARGURA_PESCOCO_D", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_LARGURA_PESCOCO_D, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? TIP_CAPACIDADE_M3
                                    {
                                        get => _inner.TIP_CAPACIDADE_M3;
                                        set
                                        {
                                            if (_inner.TIP_CAPACIDADE_M3 != value)
                                            {
                                                _inner.TIP_CAPACIDADE_M3 = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TIP_CAPACIDADE_M3) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TIP_CAPACIDADE_M3", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TIP_CAPACIDADE_M3, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & TipoVeiculoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoVeiculoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoVeiculoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TipoVeiculoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TipoVeiculo", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TipoVeiculoOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration