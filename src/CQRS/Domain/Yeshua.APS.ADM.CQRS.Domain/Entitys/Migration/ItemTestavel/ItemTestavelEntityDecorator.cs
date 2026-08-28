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
                    public static class ItemTestavelTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ITE_ID = 1UL << 1;
            public const ulong ITE_DESCRICAO = 1UL << 2;
            public const ulong ITE_OBS = 1UL << 3;
            public const ulong ITE_NUMERO_DE_TESTES = 1UL << 4;
            public const ulong ITE_CONDICIONAL_DE_AVALIACAO = 1UL << 5;
            public const ulong ITE_VALOR_DA_CONDICIONAL = 1UL << 6;
            public const ulong ITE_VALOR_CALCULADO_DA_CONDICIONAL = 1UL << 7;
            public const ulong ITE_TIPO_AVALIACAO_FINAL = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
        }

        public partial class ItemTestavelDecorator : IItemTestavelEntity
{

                        private readonly IItemTestavelEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ItemTestavelDecorator(IItemTestavelEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ItemTestavelDecorator(
                            IItemTestavelEntity inner,
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
                                                if ((_trackingMask & ItemTestavelTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int ITE_ID
                                    {
                                        get => _inner.ITE_ID;
                                        set
                                        {
                                            if (_inner.ITE_ID != value)
                                            {
                                                _inner.ITE_ID = value;
                                                if ((_trackingMask & ItemTestavelTrackingFields.ITE_ID) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "ITE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ITE_DESCRICAO
                                    {
                                        get => _inner.ITE_DESCRICAO;
                                        set
                                        {
                                            if (_inner.ITE_DESCRICAO != value)
                                            {
                                                _inner.ITE_DESCRICAO = value;
                                                if ((_trackingMask & ItemTestavelTrackingFields.ITE_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "ITE_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ITE_OBS
                                    {
                                        get => _inner.ITE_OBS;
                                        set
                                        {
                                            if (_inner.ITE_OBS != value)
                                            {
                                                _inner.ITE_OBS = value;
                                                if ((_trackingMask & ItemTestavelTrackingFields.ITE_OBS) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "ITE_OBS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ITE_NUMERO_DE_TESTES
                                    {
                                        get => _inner.ITE_NUMERO_DE_TESTES;
                                        set
                                        {
                                            if (_inner.ITE_NUMERO_DE_TESTES != value)
                                            {
                                                _inner.ITE_NUMERO_DE_TESTES = value;
                                                if ((_trackingMask & ItemTestavelTrackingFields.ITE_NUMERO_DE_TESTES) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "ITE_NUMERO_DE_TESTES", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ITE_CONDICIONAL_DE_AVALIACAO
                                    {
                                        get => _inner.ITE_CONDICIONAL_DE_AVALIACAO;
                                        set
                                        {
                                            if (_inner.ITE_CONDICIONAL_DE_AVALIACAO != value)
                                            {
                                                _inner.ITE_CONDICIONAL_DE_AVALIACAO = value;
                                                if ((_trackingMask & ItemTestavelTrackingFields.ITE_CONDICIONAL_DE_AVALIACAO) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "ITE_CONDICIONAL_DE_AVALIACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? ITE_VALOR_DA_CONDICIONAL
                                    {
                                        get => _inner.ITE_VALOR_DA_CONDICIONAL;
                                        set
                                        {
                                            if (_inner.ITE_VALOR_DA_CONDICIONAL != value)
                                            {
                                                _inner.ITE_VALOR_DA_CONDICIONAL = value;
                                                if ((_trackingMask & ItemTestavelTrackingFields.ITE_VALOR_DA_CONDICIONAL) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "ITE_VALOR_DA_CONDICIONAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ITE_VALOR_CALCULADO_DA_CONDICIONAL
                                    {
                                        get => _inner.ITE_VALOR_CALCULADO_DA_CONDICIONAL;
                                        set
                                        {
                                            if (_inner.ITE_VALOR_CALCULADO_DA_CONDICIONAL != value)
                                            {
                                                _inner.ITE_VALOR_CALCULADO_DA_CONDICIONAL = value;
                                                if ((_trackingMask & ItemTestavelTrackingFields.ITE_VALOR_CALCULADO_DA_CONDICIONAL) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "ITE_VALOR_CALCULADO_DA_CONDICIONAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ITE_TIPO_AVALIACAO_FINAL
                                    {
                                        get => _inner.ITE_TIPO_AVALIACAO_FINAL;
                                        set
                                        {
                                            if (_inner.ITE_TIPO_AVALIACAO_FINAL != value)
                                            {
                                                _inner.ITE_TIPO_AVALIACAO_FINAL = value;
                                                if ((_trackingMask & ItemTestavelTrackingFields.ITE_TIPO_AVALIACAO_FINAL) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "ITE_TIPO_AVALIACAO_FINAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItemTestavelTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItemTestavelTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItemTestavelTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ItemTestavelTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ItemTestavel", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration