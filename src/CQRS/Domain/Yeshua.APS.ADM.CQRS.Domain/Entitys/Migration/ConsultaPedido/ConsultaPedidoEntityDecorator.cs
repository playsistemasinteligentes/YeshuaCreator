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
                    public static class ConsultaPedidoTrackingFields
        {
            public const ulong PedidoId = 1UL << 0;
            public const ulong ClienteId = 1UL << 1;
            public const ulong ClienteNome = 1UL << 2;
            public const ulong RazaoSocial = 1UL << 3;
            public const ulong ProdutoId = 1UL << 4;
            public const ulong ProdutoDescricao = 1UL << 5;
            public const ulong Status = 1UL << 6;
            public const ulong Estagio = 1UL << 7;
            public const ulong DataEntregaDe = 1UL << 8;
            public const ulong DataEntregaAte = 1UL << 9;
            public const ulong EmbarqueAlvo = 1UL << 10;
            public const ulong Quantidade = 1UL << 11;
            public const ulong SaldoAProduzir = 1UL << 12;
            public const ulong SaldoAExpedir = 1UL << 13;
            public const ulong CorFila = 1UL << 14;
            public const ulong PedidoCliente = 1UL << 15;
        }

        public static class ConsultaPedidoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification PedidoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ClienteId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ClienteNome = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification RazaoSocial = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProdutoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProdutoDescricao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Estagio = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DataEntregaDe = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DataEntregaAte = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EmbarqueAlvo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Quantidade = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SaldoAProduzir = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SaldoAExpedir = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CorFila = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PedidoCliente = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class ConsultaPedidoDecorator : IConsultaPedidoEntity
{

                        private readonly IConsultaPedidoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ConsultaPedidoDecorator(IConsultaPedidoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ConsultaPedidoDecorator(
                            IConsultaPedidoEntity inner,
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
                                    public string PedidoId
                                    {
                                        get => _inner.PedidoId;
                                        set
                                        {
                                            if (_inner.PedidoId != value)
                                            {
                                                _inner.PedidoId = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.PedidoId) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "PedidoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.PedidoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string ClienteId
                                    {
                                        get => _inner.ClienteId;
                                        set
                                        {
                                            if (_inner.ClienteId != value)
                                            {
                                                _inner.ClienteId = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.ClienteId) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "ClienteId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.ClienteId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string ClienteNome
                                    {
                                        get => _inner.ClienteNome;
                                        set
                                        {
                                            if (_inner.ClienteNome != value)
                                            {
                                                _inner.ClienteNome = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.ClienteNome) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "ClienteNome", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.ClienteNome, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? RazaoSocial
                                    {
                                        get => _inner.RazaoSocial;
                                        set
                                        {
                                            if (_inner.RazaoSocial != value)
                                            {
                                                _inner.RazaoSocial = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.RazaoSocial) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "RazaoSocial", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.RazaoSocial, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string ProdutoId
                                    {
                                        get => _inner.ProdutoId;
                                        set
                                        {
                                            if (_inner.ProdutoId != value)
                                            {
                                                _inner.ProdutoId = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.ProdutoId) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "ProdutoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.ProdutoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string ProdutoDescricao
                                    {
                                        get => _inner.ProdutoDescricao;
                                        set
                                        {
                                            if (_inner.ProdutoDescricao != value)
                                            {
                                                _inner.ProdutoDescricao = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.ProdutoDescricao) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "ProdutoDescricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.ProdutoDescricao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.Status, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Estagio
                                    {
                                        get => _inner.Estagio;
                                        set
                                        {
                                            if (_inner.Estagio != value)
                                            {
                                                _inner.Estagio = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.Estagio) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "Estagio", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.Estagio, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime DataEntregaDe
                                    {
                                        get => _inner.DataEntregaDe;
                                        set
                                        {
                                            if (_inner.DataEntregaDe != value)
                                            {
                                                _inner.DataEntregaDe = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.DataEntregaDe) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "DataEntregaDe", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.DataEntregaDe, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime DataEntregaAte
                                    {
                                        get => _inner.DataEntregaAte;
                                        set
                                        {
                                            if (_inner.DataEntregaAte != value)
                                            {
                                                _inner.DataEntregaAte = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.DataEntregaAte) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "DataEntregaAte", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.DataEntregaAte, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? EmbarqueAlvo
                                    {
                                        get => _inner.EmbarqueAlvo;
                                        set
                                        {
                                            if (_inner.EmbarqueAlvo != value)
                                            {
                                                _inner.EmbarqueAlvo = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.EmbarqueAlvo) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "EmbarqueAlvo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.EmbarqueAlvo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal Quantidade
                                    {
                                        get => _inner.Quantidade;
                                        set
                                        {
                                            if (_inner.Quantidade != value)
                                            {
                                                _inner.Quantidade = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.Quantidade) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "Quantidade", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.Quantidade, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal SaldoAProduzir
                                    {
                                        get => _inner.SaldoAProduzir;
                                        set
                                        {
                                            if (_inner.SaldoAProduzir != value)
                                            {
                                                _inner.SaldoAProduzir = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.SaldoAProduzir) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "SaldoAProduzir", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.SaldoAProduzir, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? SaldoAExpedir
                                    {
                                        get => _inner.SaldoAExpedir;
                                        set
                                        {
                                            if (_inner.SaldoAExpedir != value)
                                            {
                                                _inner.SaldoAExpedir = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.SaldoAExpedir) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "SaldoAExpedir", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.SaldoAExpedir, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CorFila
                                    {
                                        get => _inner.CorFila;
                                        set
                                        {
                                            if (_inner.CorFila != value)
                                            {
                                                _inner.CorFila = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.CorFila) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "CorFila", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.CorFila, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PedidoCliente
                                    {
                                        get => _inner.PedidoCliente;
                                        set
                                        {
                                            if (_inner.PedidoCliente != value)
                                            {
                                                _inner.PedidoCliente = value;
                                                if ((_trackingMask & ConsultaPedidoTrackingFields.PedidoCliente) != 0UL)
                                                    _logger.DomainValueChanged("ConsultaPedido", "PedidoCliente", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultaPedidoOperationalFields.PedidoCliente, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration