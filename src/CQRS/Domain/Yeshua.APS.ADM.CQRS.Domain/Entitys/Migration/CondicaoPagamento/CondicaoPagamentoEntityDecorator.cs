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
                    public static class CondicaoPagamentoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CON_ID = 1UL << 1;
            public const ulong CON_DESCRICAO = 1UL << 2;
            public const ulong CON_PARCELAS = 1UL << 3;
            public const ulong CON_VALOR_ACRECIMO = 1UL << 4;
            public const ulong CON_INTEGRACAO_ERP = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class CondicaoPagamentoDecorator : ICondicaoPagamentoEntity
{

                        private readonly ICondicaoPagamentoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CondicaoPagamentoDecorator(ICondicaoPagamentoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CondicaoPagamentoDecorator(
                            ICondicaoPagamentoEntity inner,
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
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CON_ID
                                    {
                                        get => _inner.CON_ID;
                                        set
                                        {
                                            if (_inner.CON_ID != value)
                                            {
                                                _inner.CON_ID = value;
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.CON_ID) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "CON_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CON_DESCRICAO
                                    {
                                        get => _inner.CON_DESCRICAO;
                                        set
                                        {
                                            if (_inner.CON_DESCRICAO != value)
                                            {
                                                _inner.CON_DESCRICAO = value;
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.CON_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "CON_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CON_PARCELAS
                                    {
                                        get => _inner.CON_PARCELAS;
                                        set
                                        {
                                            if (_inner.CON_PARCELAS != value)
                                            {
                                                _inner.CON_PARCELAS = value;
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.CON_PARCELAS) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "CON_PARCELAS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CON_VALOR_ACRECIMO
                                    {
                                        get => _inner.CON_VALOR_ACRECIMO;
                                        set
                                        {
                                            if (_inner.CON_VALOR_ACRECIMO != value)
                                            {
                                                _inner.CON_VALOR_ACRECIMO = value;
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.CON_VALOR_ACRECIMO) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "CON_VALOR_ACRECIMO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CON_INTEGRACAO_ERP
                                    {
                                        get => _inner.CON_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.CON_INTEGRACAO_ERP != value)
                                            {
                                                _inner.CON_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.CON_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "CON_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CondicaoPagamentoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CondicaoPagamento", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration