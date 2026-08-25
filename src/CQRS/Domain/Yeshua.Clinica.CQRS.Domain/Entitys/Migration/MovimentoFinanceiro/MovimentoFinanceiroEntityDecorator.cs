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
                    public static class MovimentoFinanceiroTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong IdOrigem = 1UL << 1;
            public const ulong ContaDebitoId = 1UL << 2;
            public const ulong Valor = 1UL << 3;
            public const ulong DataMovimento = 1UL << 4;
            public const ulong DataVencimento = 1UL << 5;
            public const ulong Status = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
        }

        public partial class MovimentoFinanceiroDecorator : IMovimentoFinanceiroEntity
{

                        private readonly IMovimentoFinanceiroEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MovimentoFinanceiroDecorator(IMovimentoFinanceiroEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MovimentoFinanceiroDecorator(
                            IMovimentoFinanceiroEntity inner,
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
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string IdOrigem
                                    {
                                        get => _inner.IdOrigem;
                                        set
                                        {
                                            if (_inner.IdOrigem != value)
                                            {
                                                _inner.IdOrigem = value;
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.IdOrigem) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "IdOrigem", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int ContaDebitoId
                                    {
                                        get => _inner.ContaDebitoId;
                                        set
                                        {
                                            if (_inner.ContaDebitoId != value)
                                            {
                                                _inner.ContaDebitoId = value;
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.ContaDebitoId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "ContaDebitoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.Valor) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "Valor", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DataMovimento
                                    {
                                        get => _inner.DataMovimento;
                                        set
                                        {
                                            if (_inner.DataMovimento != value)
                                            {
                                                _inner.DataMovimento = value;
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.DataMovimento) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "DataMovimento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? DataVencimento
                                    {
                                        get => _inner.DataVencimento;
                                        set
                                        {
                                            if (_inner.DataVencimento != value)
                                            {
                                                _inner.DataVencimento = value;
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.DataVencimento) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "DataVencimento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoFinanceiroTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoFinanceiro", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration