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
                    public static class TempoSetupOnduladeiraTrackingFields
        {
            public const ulong TEM_ID = 1UL << 0;
            public const ulong OND_ID_DE = 1UL << 1;
            public const ulong OND_ID_PARA = 1UL << 2;
            public const ulong TEM_RESINA_DE = 1UL << 3;
            public const ulong TEM_RESINA_PARA = 1UL << 4;
            public const ulong TEM_TEMPO = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class TempoSetupOnduladeiraDecorator : ITempoSetupOnduladeiraEntity
{

                        private readonly ITempoSetupOnduladeiraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TempoSetupOnduladeiraDecorator(ITempoSetupOnduladeiraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TempoSetupOnduladeiraDecorator(
                            ITempoSetupOnduladeiraEntity inner,
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
                                    public int TEM_ID
                                    {
                                        get => _inner.TEM_ID;
                                        set
                                        {
                                            if (_inner.TEM_ID != value)
                                            {
                                                _inner.TEM_ID = value;
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.TEM_ID) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "TEM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OND_ID_DE
                                    {
                                        get => _inner.OND_ID_DE;
                                        set
                                        {
                                            if (_inner.OND_ID_DE != value)
                                            {
                                                _inner.OND_ID_DE = value;
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.OND_ID_DE) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "OND_ID_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OND_ID_PARA
                                    {
                                        get => _inner.OND_ID_PARA;
                                        set
                                        {
                                            if (_inner.OND_ID_PARA != value)
                                            {
                                                _inner.OND_ID_PARA = value;
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.OND_ID_PARA) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "OND_ID_PARA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TEM_RESINA_DE
                                    {
                                        get => _inner.TEM_RESINA_DE;
                                        set
                                        {
                                            if (_inner.TEM_RESINA_DE != value)
                                            {
                                                _inner.TEM_RESINA_DE = value;
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.TEM_RESINA_DE) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "TEM_RESINA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TEM_RESINA_PARA
                                    {
                                        get => _inner.TEM_RESINA_PARA;
                                        set
                                        {
                                            if (_inner.TEM_RESINA_PARA != value)
                                            {
                                                _inner.TEM_RESINA_PARA = value;
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.TEM_RESINA_PARA) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "TEM_RESINA_PARA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TEM_TEMPO
                                    {
                                        get => _inner.TEM_TEMPO;
                                        set
                                        {
                                            if (_inner.TEM_TEMPO != value)
                                            {
                                                _inner.TEM_TEMPO = value;
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.TEM_TEMPO) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "TEM_TEMPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TempoSetupOnduladeiraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TempoSetupOnduladeira", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration