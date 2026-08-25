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
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
        }

        public partial class MovimentacaoFinanceiraDecorator : IMovimentacaoFinanceiraEntity
{

                        private readonly IMovimentacaoFinanceiraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "PacienteId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "ServicoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "Valor", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "TipoMovimentacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "DataMovimentacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "SaldoAtual", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentacaoFinanceiraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                    _logger.DomainValueChanged("MovimentacaoFinanceira", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration