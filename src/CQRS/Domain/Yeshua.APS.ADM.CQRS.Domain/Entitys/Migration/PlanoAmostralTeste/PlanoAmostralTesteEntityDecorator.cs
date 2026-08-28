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
                    public static class PlanoAmostralTesteTrackingFields
        {
            public const ulong GRP_TIPO = 1UL << 0;
            public const ulong TenantID = 1UL << 1;
            public const ulong Deleted = 1UL << 2;
            public const ulong Changed = 1UL << 3;
            public const ulong UserId = 1UL << 4;
            public const ulong PAT_ID = 1UL << 5;
            public const ulong PAT_QTD_CAIXAS_DE = 1UL << 6;
            public const ulong PAT_QTD_CAIXAS_ATE = 1UL << 7;
            public const ulong PAT_N_AMOSTRAGEM = 1UL << 8;
            public const ulong PAT_PERCENT_ESPECIF = 1UL << 9;
        }

        public partial class PlanoAmostralTesteDecorator : IPlanoAmostralTesteEntity
{

                        private readonly IPlanoAmostralTesteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PlanoAmostralTesteDecorator(IPlanoAmostralTesteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PlanoAmostralTesteDecorator(
                            IPlanoAmostralTesteEntity inner,
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
                                    public Decimal? GRP_TIPO
                                    {
                                        get => _inner.GRP_TIPO;
                                        set
                                        {
                                            if (_inner.GRP_TIPO != value)
                                            {
                                                _inner.GRP_TIPO = value;
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.GRP_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "GRP_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int PAT_ID
                                    {
                                        get => _inner.PAT_ID;
                                        set
                                        {
                                            if (_inner.PAT_ID != value)
                                            {
                                                _inner.PAT_ID = value;
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.PAT_ID) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "PAT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PAT_QTD_CAIXAS_DE
                                    {
                                        get => _inner.PAT_QTD_CAIXAS_DE;
                                        set
                                        {
                                            if (_inner.PAT_QTD_CAIXAS_DE != value)
                                            {
                                                _inner.PAT_QTD_CAIXAS_DE = value;
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.PAT_QTD_CAIXAS_DE) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "PAT_QTD_CAIXAS_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PAT_QTD_CAIXAS_ATE
                                    {
                                        get => _inner.PAT_QTD_CAIXAS_ATE;
                                        set
                                        {
                                            if (_inner.PAT_QTD_CAIXAS_ATE != value)
                                            {
                                                _inner.PAT_QTD_CAIXAS_ATE = value;
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.PAT_QTD_CAIXAS_ATE) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "PAT_QTD_CAIXAS_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? PAT_N_AMOSTRAGEM
                                    {
                                        get => _inner.PAT_N_AMOSTRAGEM;
                                        set
                                        {
                                            if (_inner.PAT_N_AMOSTRAGEM != value)
                                            {
                                                _inner.PAT_N_AMOSTRAGEM = value;
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.PAT_N_AMOSTRAGEM) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "PAT_N_AMOSTRAGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? PAT_PERCENT_ESPECIF
                                    {
                                        get => _inner.PAT_PERCENT_ESPECIF;
                                        set
                                        {
                                            if (_inner.PAT_PERCENT_ESPECIF != value)
                                            {
                                                _inner.PAT_PERCENT_ESPECIF = value;
                                                if ((_trackingMask & PlanoAmostralTesteTrackingFields.PAT_PERCENT_ESPECIF) != 0UL)
                                                    _logger.DomainValueChanged("PlanoAmostralTeste", "PAT_PERCENT_ESPECIF", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration