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
                    public static class InformacoesComplementaresTrackingFields
        {
            public const ulong INF_ID = 1UL << 0;
            public const ulong INF_DESCRICAO = 1UL << 1;
            public const ulong INF_VALOR = 1UL << 2;
            public const ulong MET_ID = 1UL << 3;
            public const ulong INF_DATA = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class InformacoesComplementaresDecorator : IInformacoesComplementaresEntity
{

                        private readonly IInformacoesComplementaresEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public InformacoesComplementaresDecorator(IInformacoesComplementaresEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public InformacoesComplementaresDecorator(
                            IInformacoesComplementaresEntity inner,
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
                                    public int INF_ID
                                    {
                                        get => _inner.INF_ID;
                                        set
                                        {
                                            if (_inner.INF_ID != value)
                                            {
                                                _inner.INF_ID = value;
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.INF_ID) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "INF_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string INF_DESCRICAO
                                    {
                                        get => _inner.INF_DESCRICAO;
                                        set
                                        {
                                            if (_inner.INF_DESCRICAO != value)
                                            {
                                                _inner.INF_DESCRICAO = value;
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.INF_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "INF_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal INF_VALOR
                                    {
                                        get => _inner.INF_VALOR;
                                        set
                                        {
                                            if (_inner.INF_VALOR != value)
                                            {
                                                _inner.INF_VALOR = value;
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.INF_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "INF_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MET_ID
                                    {
                                        get => _inner.MET_ID;
                                        set
                                        {
                                            if (_inner.MET_ID != value)
                                            {
                                                _inner.MET_ID = value;
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.MET_ID) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "MET_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string INF_DATA
                                    {
                                        get => _inner.INF_DATA;
                                        set
                                        {
                                            if (_inner.INF_DATA != value)
                                            {
                                                _inner.INF_DATA = value;
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.INF_DATA) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "INF_DATA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & InformacoesComplementaresTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("InformacoesComplementares", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration