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
                    public static class ImpressoraTrackingFields
        {
            public const ulong IMP_ID = 1UL << 0;
            public const ulong IMP_IP = 1UL << 1;
            public const ulong IMP_NOME = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
        }

        public partial class ImpressoraDecorator : IImpressoraEntity
{

                        private readonly IImpressoraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ImpressoraDecorator(IImpressoraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ImpressoraDecorator(
                            IImpressoraEntity inner,
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
                                    public int IMP_ID
                                    {
                                        get => _inner.IMP_ID;
                                        set
                                        {
                                            if (_inner.IMP_ID != value)
                                            {
                                                _inner.IMP_ID = value;
                                                if ((_trackingMask & ImpressoraTrackingFields.IMP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Impressora", "IMP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string IMP_IP
                                    {
                                        get => _inner.IMP_IP;
                                        set
                                        {
                                            if (_inner.IMP_IP != value)
                                            {
                                                _inner.IMP_IP = value;
                                                if ((_trackingMask & ImpressoraTrackingFields.IMP_IP) != 0UL)
                                                    _logger.DomainValueChanged("Impressora", "IMP_IP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string IMP_NOME
                                    {
                                        get => _inner.IMP_NOME;
                                        set
                                        {
                                            if (_inner.IMP_NOME != value)
                                            {
                                                _inner.IMP_NOME = value;
                                                if ((_trackingMask & ImpressoraTrackingFields.IMP_NOME) != 0UL)
                                                    _logger.DomainValueChanged("Impressora", "IMP_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ImpressoraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Impressora", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ImpressoraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Impressora", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ImpressoraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Impressora", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ImpressoraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Impressora", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration