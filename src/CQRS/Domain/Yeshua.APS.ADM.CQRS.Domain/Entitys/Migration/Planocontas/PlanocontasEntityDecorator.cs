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
                    public static class PlanocontasTrackingFields
        {
            public const ulong PLA_ID = 1UL << 0;
            public const ulong PLA_CODIGO = 1UL << 1;
            public const ulong PLA_DESCRICAO = 1UL << 2;
            public const ulong PLA_TIPO = 1UL << 3;
            public const ulong PLA_NATUREZA = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
        }

        public partial class PlanocontasDecorator : IPlanocontasEntity
{

                        private readonly IPlanocontasEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PlanocontasDecorator(IPlanocontasEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PlanocontasDecorator(
                            IPlanocontasEntity inner,
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
                                    public int PLA_ID
                                    {
                                        get => _inner.PLA_ID;
                                        set
                                        {
                                            if (_inner.PLA_ID != value)
                                            {
                                                _inner.PLA_ID = value;
                                                if ((_trackingMask & PlanocontasTrackingFields.PLA_ID) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "PLA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_CODIGO
                                    {
                                        get => _inner.PLA_CODIGO;
                                        set
                                        {
                                            if (_inner.PLA_CODIGO != value)
                                            {
                                                _inner.PLA_CODIGO = value;
                                                if ((_trackingMask & PlanocontasTrackingFields.PLA_CODIGO) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "PLA_CODIGO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_DESCRICAO
                                    {
                                        get => _inner.PLA_DESCRICAO;
                                        set
                                        {
                                            if (_inner.PLA_DESCRICAO != value)
                                            {
                                                _inner.PLA_DESCRICAO = value;
                                                if ((_trackingMask & PlanocontasTrackingFields.PLA_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "PLA_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int PLA_TIPO
                                    {
                                        get => _inner.PLA_TIPO;
                                        set
                                        {
                                            if (_inner.PLA_TIPO != value)
                                            {
                                                _inner.PLA_TIPO = value;
                                                if ((_trackingMask & PlanocontasTrackingFields.PLA_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "PLA_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLA_NATUREZA
                                    {
                                        get => _inner.PLA_NATUREZA;
                                        set
                                        {
                                            if (_inner.PLA_NATUREZA != value)
                                            {
                                                _inner.PLA_NATUREZA = value;
                                                if ((_trackingMask & PlanocontasTrackingFields.PLA_NATUREZA) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "PLA_NATUREZA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanocontasTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanocontasTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanocontasTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlanocontasTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Planocontas", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration