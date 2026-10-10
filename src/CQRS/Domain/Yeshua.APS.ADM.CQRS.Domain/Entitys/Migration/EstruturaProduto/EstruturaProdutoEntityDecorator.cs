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
                    public static class EstruturaProdutoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong EST_DATA_VALIDADE = 1UL << 1;
            public const ulong PRO_ID_PRODUTO = 1UL << 2;
            public const ulong PRO_ID_COMPONENTE = 1UL << 3;
            public const ulong EST_QUANT = 1UL << 4;
            public const ulong EST_DATA_INCLUSAO = 1UL << 5;
            public const ulong EST_BASE_PRODUCAO = 1UL << 6;
            public const ulong EST_TIPO_REQUISICAO = 1UL << 7;
            public const ulong EST_CODIGO_DE_EXCECAO = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
            public const ulong TenantID = 1UL << 10;
            public const ulong Deleted = 1UL << 11;
            public const ulong Changed = 1UL << 12;
            public const ulong UserId = 1UL << 13;
        }

        public static class EstruturaProdutoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EST_DATA_VALIDADE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PRO_ID_PRODUTO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PRO_ID_COMPONENTE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EST_QUANT = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EST_DATA_INCLUSAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EST_BASE_PRODUCAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EST_TIPO_REQUISICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EST_CODIGO_DE_EXCECAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class EstruturaProdutoDecorator : IEstruturaProdutoEntity
{

                        private readonly IEstruturaProdutoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public EstruturaProdutoDecorator(IEstruturaProdutoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public EstruturaProdutoDecorator(
                            IEstruturaProdutoEntity inner,
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
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime EST_DATA_VALIDADE
                                    {
                                        get => _inner.EST_DATA_VALIDADE;
                                        set
                                        {
                                            if (_inner.EST_DATA_VALIDADE != value)
                                            {
                                                _inner.EST_DATA_VALIDADE = value;
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.EST_DATA_VALIDADE) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "EST_DATA_VALIDADE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.EST_DATA_VALIDADE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string PRO_ID_PRODUTO
                                    {
                                        get => _inner.PRO_ID_PRODUTO;
                                        set
                                        {
                                            if (_inner.PRO_ID_PRODUTO != value)
                                            {
                                                _inner.PRO_ID_PRODUTO = value;
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.PRO_ID_PRODUTO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "PRO_ID_PRODUTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.PRO_ID_PRODUTO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string PRO_ID_COMPONENTE
                                    {
                                        get => _inner.PRO_ID_COMPONENTE;
                                        set
                                        {
                                            if (_inner.PRO_ID_COMPONENTE != value)
                                            {
                                                _inner.PRO_ID_COMPONENTE = value;
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.PRO_ID_COMPONENTE) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "PRO_ID_COMPONENTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.PRO_ID_COMPONENTE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal EST_QUANT
                                    {
                                        get => _inner.EST_QUANT;
                                        set
                                        {
                                            if (_inner.EST_QUANT != value)
                                            {
                                                _inner.EST_QUANT = value;
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.EST_QUANT) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "EST_QUANT", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.EST_QUANT, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime EST_DATA_INCLUSAO
                                    {
                                        get => _inner.EST_DATA_INCLUSAO;
                                        set
                                        {
                                            if (_inner.EST_DATA_INCLUSAO != value)
                                            {
                                                _inner.EST_DATA_INCLUSAO = value;
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.EST_DATA_INCLUSAO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "EST_DATA_INCLUSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.EST_DATA_INCLUSAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal EST_BASE_PRODUCAO
                                    {
                                        get => _inner.EST_BASE_PRODUCAO;
                                        set
                                        {
                                            if (_inner.EST_BASE_PRODUCAO != value)
                                            {
                                                _inner.EST_BASE_PRODUCAO = value;
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.EST_BASE_PRODUCAO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "EST_BASE_PRODUCAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.EST_BASE_PRODUCAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string EST_TIPO_REQUISICAO
                                    {
                                        get => _inner.EST_TIPO_REQUISICAO;
                                        set
                                        {
                                            if (_inner.EST_TIPO_REQUISICAO != value)
                                            {
                                                _inner.EST_TIPO_REQUISICAO = value;
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.EST_TIPO_REQUISICAO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "EST_TIPO_REQUISICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.EST_TIPO_REQUISICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string EST_CODIGO_DE_EXCECAO
                                    {
                                        get => _inner.EST_CODIGO_DE_EXCECAO;
                                        set
                                        {
                                            if (_inner.EST_CODIGO_DE_EXCECAO != value)
                                            {
                                                _inner.EST_CODIGO_DE_EXCECAO = value;
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.EST_CODIGO_DE_EXCECAO) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "EST_CODIGO_DE_EXCECAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.EST_CODIGO_DE_EXCECAO, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EstruturaProdutoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("EstruturaProduto", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EstruturaProdutoOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration