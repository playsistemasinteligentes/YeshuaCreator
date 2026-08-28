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
                    public static class VincoTrackingFields
        {
            public const ulong VIN_ID = 1UL << 0;
            public const ulong VIN_DESCRICAO = 1UL << 1;
            public const ulong VIN_ID_DESLOCAMENTO = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
        }

        public partial class VincoDecorator : IVincoEntity
{

                        private readonly IVincoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public VincoDecorator(IVincoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public VincoDecorator(
                            IVincoEntity inner,
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
                                    public int VIN_ID
                                    {
                                        get => _inner.VIN_ID;
                                        set
                                        {
                                            if (_inner.VIN_ID != value)
                                            {
                                                _inner.VIN_ID = value;
                                                if ((_trackingMask & VincoTrackingFields.VIN_ID) != 0UL)
                                                    _logger.DomainValueChanged("Vinco", "VIN_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VIN_DESCRICAO
                                    {
                                        get => _inner.VIN_DESCRICAO;
                                        set
                                        {
                                            if (_inner.VIN_DESCRICAO != value)
                                            {
                                                _inner.VIN_DESCRICAO = value;
                                                if ((_trackingMask & VincoTrackingFields.VIN_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Vinco", "VIN_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VIN_ID_DESLOCAMENTO
                                    {
                                        get => _inner.VIN_ID_DESLOCAMENTO;
                                        set
                                        {
                                            if (_inner.VIN_ID_DESLOCAMENTO != value)
                                            {
                                                _inner.VIN_ID_DESLOCAMENTO = value;
                                                if ((_trackingMask & VincoTrackingFields.VIN_ID_DESLOCAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Vinco", "VIN_ID_DESLOCAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VincoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Vinco", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VincoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Vinco", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VincoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Vinco", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VincoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Vinco", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration