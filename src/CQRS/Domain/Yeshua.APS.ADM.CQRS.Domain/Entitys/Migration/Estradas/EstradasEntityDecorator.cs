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
                    public static class EstradasTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong EST_ID = 1UL << 1;
            public const ulong EST_DESCRICAO = 1UL << 2;
            public const ulong EST_ID_LIGACAO_PONTO_A = 1UL << 3;
            public const ulong EST_ID_LIGACAO_PONTO_B = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class EstradasDecorator : IEstradasEntity
{

                        private readonly IEstradasEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public EstradasDecorator(IEstradasEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public EstradasDecorator(
                            IEstradasEntity inner,
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
                                                if ((_trackingMask & EstradasTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int EST_ID
                                    {
                                        get => _inner.EST_ID;
                                        set
                                        {
                                            if (_inner.EST_ID != value)
                                            {
                                                _inner.EST_ID = value;
                                                if ((_trackingMask & EstradasTrackingFields.EST_ID) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "EST_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EST_DESCRICAO
                                    {
                                        get => _inner.EST_DESCRICAO;
                                        set
                                        {
                                            if (_inner.EST_DESCRICAO != value)
                                            {
                                                _inner.EST_DESCRICAO = value;
                                                if ((_trackingMask & EstradasTrackingFields.EST_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "EST_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? EST_ID_LIGACAO_PONTO_A
                                    {
                                        get => _inner.EST_ID_LIGACAO_PONTO_A;
                                        set
                                        {
                                            if (_inner.EST_ID_LIGACAO_PONTO_A != value)
                                            {
                                                _inner.EST_ID_LIGACAO_PONTO_A = value;
                                                if ((_trackingMask & EstradasTrackingFields.EST_ID_LIGACAO_PONTO_A) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "EST_ID_LIGACAO_PONTO_A", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? EST_ID_LIGACAO_PONTO_B
                                    {
                                        get => _inner.EST_ID_LIGACAO_PONTO_B;
                                        set
                                        {
                                            if (_inner.EST_ID_LIGACAO_PONTO_B != value)
                                            {
                                                _inner.EST_ID_LIGACAO_PONTO_B = value;
                                                if ((_trackingMask & EstradasTrackingFields.EST_ID_LIGACAO_PONTO_B) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "EST_ID_LIGACAO_PONTO_B", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstradasTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstradasTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstradasTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & EstradasTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Estradas", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration