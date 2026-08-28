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
                    public static class SegmentoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong SEG_ID = 1UL << 1;
            public const ulong SEG_DESCRICAO = 1UL << 2;
            public const ulong SEG_ID_SEGUIMENTO_PAI = 1UL << 3;
            public const ulong GRS_ID = 1UL << 4;
            public const ulong SEG_INTEGRACAO_ERP = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class SegmentoDecorator : ISegmentoEntity
{

                        private readonly ISegmentoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public SegmentoDecorator(ISegmentoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public SegmentoDecorator(
                            ISegmentoEntity inner,
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
                                                if ((_trackingMask & SegmentoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEG_ID
                                    {
                                        get => _inner.SEG_ID;
                                        set
                                        {
                                            if (_inner.SEG_ID != value)
                                            {
                                                _inner.SEG_ID = value;
                                                if ((_trackingMask & SegmentoTrackingFields.SEG_ID) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "SEG_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEG_DESCRICAO
                                    {
                                        get => _inner.SEG_DESCRICAO;
                                        set
                                        {
                                            if (_inner.SEG_DESCRICAO != value)
                                            {
                                                _inner.SEG_DESCRICAO = value;
                                                if ((_trackingMask & SegmentoTrackingFields.SEG_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "SEG_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEG_ID_SEGUIMENTO_PAI
                                    {
                                        get => _inner.SEG_ID_SEGUIMENTO_PAI;
                                        set
                                        {
                                            if (_inner.SEG_ID_SEGUIMENTO_PAI != value)
                                            {
                                                _inner.SEG_ID_SEGUIMENTO_PAI = value;
                                                if ((_trackingMask & SegmentoTrackingFields.SEG_ID_SEGUIMENTO_PAI) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "SEG_ID_SEGUIMENTO_PAI", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRS_ID
                                    {
                                        get => _inner.GRS_ID;
                                        set
                                        {
                                            if (_inner.GRS_ID != value)
                                            {
                                                _inner.GRS_ID = value;
                                                if ((_trackingMask & SegmentoTrackingFields.GRS_ID) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "GRS_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEG_INTEGRACAO_ERP
                                    {
                                        get => _inner.SEG_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.SEG_INTEGRACAO_ERP != value)
                                            {
                                                _inner.SEG_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & SegmentoTrackingFields.SEG_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "SEG_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SegmentoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SegmentoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SegmentoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SegmentoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Segmento", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration