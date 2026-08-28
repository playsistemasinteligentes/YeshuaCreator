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
                    public static class AuditoriaTrackingFields
        {
            public const ulong ID = 1UL << 0;
            public const ulong DATA = 1UL << 1;
            public const ulong USE_ID = 1UL << 2;
            public const ulong ROTINA = 1UL << 3;
            public const ulong HISTORICO = 1UL << 4;
            public const ulong CHAVE = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class AuditoriaDecorator : IAuditoriaEntity
{

                        private readonly IAuditoriaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public AuditoriaDecorator(IAuditoriaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public AuditoriaDecorator(
                            IAuditoriaEntity inner,
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
                                    public int ID
                                    {
                                        get => _inner.ID;
                                        set
                                        {
                                            if (_inner.ID != value)
                                            {
                                                _inner.ID = value;
                                                if ((_trackingMask & AuditoriaTrackingFields.ID) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DATA
                                    {
                                        get => _inner.DATA;
                                        set
                                        {
                                            if (_inner.DATA != value)
                                            {
                                                _inner.DATA = value;
                                                if ((_trackingMask & AuditoriaTrackingFields.DATA) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "DATA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int USE_ID
                                    {
                                        get => _inner.USE_ID;
                                        set
                                        {
                                            if (_inner.USE_ID != value)
                                            {
                                                _inner.USE_ID = value;
                                                if ((_trackingMask & AuditoriaTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROTINA
                                    {
                                        get => _inner.ROTINA;
                                        set
                                        {
                                            if (_inner.ROTINA != value)
                                            {
                                                _inner.ROTINA = value;
                                                if ((_trackingMask & AuditoriaTrackingFields.ROTINA) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "ROTINA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string HISTORICO
                                    {
                                        get => _inner.HISTORICO;
                                        set
                                        {
                                            if (_inner.HISTORICO != value)
                                            {
                                                _inner.HISTORICO = value;
                                                if ((_trackingMask & AuditoriaTrackingFields.HISTORICO) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "HISTORICO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CHAVE
                                    {
                                        get => _inner.CHAVE;
                                        set
                                        {
                                            if (_inner.CHAVE != value)
                                            {
                                                _inner.CHAVE = value;
                                                if ((_trackingMask & AuditoriaTrackingFields.CHAVE) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "CHAVE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & AuditoriaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & AuditoriaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & AuditoriaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & AuditoriaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Auditoria", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration