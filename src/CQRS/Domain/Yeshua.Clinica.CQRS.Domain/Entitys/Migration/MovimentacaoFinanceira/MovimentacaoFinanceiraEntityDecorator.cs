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
                    public static class MovimentacaoFinanceiraTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong PacienteId = 1UL << 1;
            public const ulong ServicoId = 1UL << 2;
            public const ulong Valor = 1UL << 3;
            public const ulong TipoMovimentacao = 1UL << 4;
            public const ulong DataMovimentacao = 1UL << 5;
            public const ulong SaldoAtual = 1UL << 6;
            public const ulong OperationalEntityId = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public static class MovimentacaoFinanceiraOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PacienteId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ServicoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Valor = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TipoMovimentacao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DataMovimentacao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SaldoAtual = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class MovimentacaoFinanceiraDecorator : IMovimentacaoFinanceiraEntity
{

                        private readonly IMovimentacaoFinanceiraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MovimentacaoFinanceiraDecorator(IMovimentacaoFinanceiraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MovimentacaoFinanceiraDecorator(
                            IMovimentacaoFinanceiraEntity inner,
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
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? PacienteId
                                    {
                                        get => _inner.PacienteId;
                                        set
                                        {
                                            if (_inner.PacienteId != value)
                                            {
                                                _inner.PacienteId = value;
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.PacienteId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "PacienteId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.PacienteId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ServicoId
                                    {
                                        get => _inner.ServicoId;
                                        set
                                        {
                                            if (_inner.ServicoId != value)
                                            {
                                                _inner.ServicoId = value;
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.ServicoId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "ServicoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.ServicoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal Valor
                                    {
                                        get => _inner.Valor;
                                        set
                                        {
                                            if (_inner.Valor != value)
                                            {
                                                _inner.Valor = value;
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.Valor) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "Valor", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.Valor, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int TipoMovimentacao
                                    {
                                        get => _inner.TipoMovimentacao;
                                        set
                                        {
                                            if (_inner.TipoMovimentacao != value)
                                            {
                                                _inner.TipoMovimentacao = value;
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.TipoMovimentacao) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "TipoMovimentacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.TipoMovimentacao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime DataMovimentacao
                                    {
                                        get => _inner.DataMovimentacao;
                                        set
                                        {
                                            if (_inner.DataMovimentacao != value)
                                            {
                                                _inner.DataMovimentacao = value;
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.DataMovimentacao) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "DataMovimentacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.DataMovimentacao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal SaldoAtual
                                    {
                                        get => _inner.SaldoAtual;
                                        set
                                        {
                                            if (_inner.SaldoAtual != value)
                                            {
                                                _inner.SaldoAtual = value;
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.SaldoAtual) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "SaldoAtual", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.SaldoAtual, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MovimentacaoFinanceiraOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration