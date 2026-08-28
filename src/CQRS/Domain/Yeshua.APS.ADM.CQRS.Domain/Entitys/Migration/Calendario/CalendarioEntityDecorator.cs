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
                    public static class CalendarioTrackingFields
        {
            public const ulong CAL_ID = 1UL << 0;
            public const ulong CAL_DESCRICAO = 1UL << 1;
            public const ulong CAL_DIVIDE_DIA_EM = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
        }

        public partial class CalendarioDecorator : ICalendarioEntity
{

                        private readonly ICalendarioEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CalendarioDecorator(ICalendarioEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CalendarioDecorator(
                            ICalendarioEntity inner,
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
                                    public int CAL_ID
                                    {
                                        get => _inner.CAL_ID;
                                        set
                                        {
                                            if (_inner.CAL_ID != value)
                                            {
                                                _inner.CAL_ID = value;
                                                if ((_trackingMask & CalendarioTrackingFields.CAL_ID) != 0UL)
                                                    _logger.DomainValueChanged("Calendario", "CAL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAL_DESCRICAO
                                    {
                                        get => _inner.CAL_DESCRICAO;
                                        set
                                        {
                                            if (_inner.CAL_DESCRICAO != value)
                                            {
                                                _inner.CAL_DESCRICAO = value;
                                                if ((_trackingMask & CalendarioTrackingFields.CAL_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Calendario", "CAL_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CAL_DIVIDE_DIA_EM
                                    {
                                        get => _inner.CAL_DIVIDE_DIA_EM;
                                        set
                                        {
                                            if (_inner.CAL_DIVIDE_DIA_EM != value)
                                            {
                                                _inner.CAL_DIVIDE_DIA_EM = value;
                                                if ((_trackingMask & CalendarioTrackingFields.CAL_DIVIDE_DIA_EM) != 0UL)
                                                    _logger.DomainValueChanged("Calendario", "CAL_DIVIDE_DIA_EM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CalendarioTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Calendario", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CalendarioTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Calendario", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CalendarioTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Calendario", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CalendarioTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Calendario", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration