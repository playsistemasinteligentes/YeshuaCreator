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
                    public static class TemplatesGrupoMaquinaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong TEM_ID = 1UL << 1;
            public const ulong GMA_ID = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
        }

        public partial class TemplatesGrupoMaquinaDecorator : ITemplatesGrupoMaquinaEntity
{

                        private readonly ITemplatesGrupoMaquinaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TemplatesGrupoMaquinaDecorator(ITemplatesGrupoMaquinaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TemplatesGrupoMaquinaDecorator(
                            ITemplatesGrupoMaquinaEntity inner,
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
                                                if ((_trackingMask & TemplatesGrupoMaquinaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("TemplatesGrupoMaquina", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int TEM_ID
                                    {
                                        get => _inner.TEM_ID;
                                        set
                                        {
                                            if (_inner.TEM_ID != value)
                                            {
                                                _inner.TEM_ID = value;
                                                if ((_trackingMask & TemplatesGrupoMaquinaTrackingFields.TEM_ID) != 0UL)
                                                    _logger.DomainValueChanged("TemplatesGrupoMaquina", "TEM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GMA_ID
                                    {
                                        get => _inner.GMA_ID;
                                        set
                                        {
                                            if (_inner.GMA_ID != value)
                                            {
                                                _inner.GMA_ID = value;
                                                if ((_trackingMask & TemplatesGrupoMaquinaTrackingFields.GMA_ID) != 0UL)
                                                    _logger.DomainValueChanged("TemplatesGrupoMaquina", "GMA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemplatesGrupoMaquinaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("TemplatesGrupoMaquina", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemplatesGrupoMaquinaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("TemplatesGrupoMaquina", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemplatesGrupoMaquinaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("TemplatesGrupoMaquina", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & TemplatesGrupoMaquinaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("TemplatesGrupoMaquina", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration