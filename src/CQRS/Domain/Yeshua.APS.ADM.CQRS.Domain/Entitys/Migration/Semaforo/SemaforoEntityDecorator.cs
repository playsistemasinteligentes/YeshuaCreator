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
                    public static class SemaforoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong SEM_ID = 1UL << 1;
            public const ulong SEM_STATUS = 1UL << 2;
            public const ulong SEM_ORIGEM = 1UL << 3;
            public const ulong SEM_EMISSAO = 1UL << 4;
            public const ulong SEM_ID_CONEXAO = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class SemaforoDecorator : ISemaforoEntity
{

                        private readonly ISemaforoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public SemaforoDecorator(ISemaforoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public SemaforoDecorator(
                            ISemaforoEntity inner,
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
                                                if ((_trackingMask & SemaforoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEM_ID
                                    {
                                        get => _inner.SEM_ID;
                                        set
                                        {
                                            if (_inner.SEM_ID != value)
                                            {
                                                _inner.SEM_ID = value;
                                                if ((_trackingMask & SemaforoTrackingFields.SEM_ID) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "SEM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEM_STATUS
                                    {
                                        get => _inner.SEM_STATUS;
                                        set
                                        {
                                            if (_inner.SEM_STATUS != value)
                                            {
                                                _inner.SEM_STATUS = value;
                                                if ((_trackingMask & SemaforoTrackingFields.SEM_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "SEM_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEM_ORIGEM
                                    {
                                        get => _inner.SEM_ORIGEM;
                                        set
                                        {
                                            if (_inner.SEM_ORIGEM != value)
                                            {
                                                _inner.SEM_ORIGEM = value;
                                                if ((_trackingMask & SemaforoTrackingFields.SEM_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "SEM_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? SEM_EMISSAO
                                    {
                                        get => _inner.SEM_EMISSAO;
                                        set
                                        {
                                            if (_inner.SEM_EMISSAO != value)
                                            {
                                                _inner.SEM_EMISSAO = value;
                                                if ((_trackingMask & SemaforoTrackingFields.SEM_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "SEM_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEM_ID_CONEXAO
                                    {
                                        get => _inner.SEM_ID_CONEXAO;
                                        set
                                        {
                                            if (_inner.SEM_ID_CONEXAO != value)
                                            {
                                                _inner.SEM_ID_CONEXAO = value;
                                                if ((_trackingMask & SemaforoTrackingFields.SEM_ID_CONEXAO) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "SEM_ID_CONEXAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SemaforoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SemaforoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SemaforoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & SemaforoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Semaforo", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration