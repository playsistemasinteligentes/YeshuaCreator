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
                    public static class PlotagemTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong PLO_ID = 1UL << 1;
            public const ulong PLO_NOME = 1UL << 2;
            public const ulong PLO_DIMENSAO = 1UL << 3;
            public const ulong PLO_X = 1UL << 4;
            public const ulong PLO_Y = 1UL << 5;
            public const ulong PLO_Z = 1UL << 6;
            public const ulong PLO_GRAFICO = 1UL << 7;
            public const ulong CON_ID = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
        }

        public partial class PlotagemDecorator : IPlotagemEntity
{

                        private readonly IPlotagemEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PlotagemDecorator(IPlotagemEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PlotagemDecorator(
                            IPlotagemEntity inner,
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
                                                if ((_trackingMask & PlotagemTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int PLO_ID
                                    {
                                        get => _inner.PLO_ID;
                                        set
                                        {
                                            if (_inner.PLO_ID != value)
                                            {
                                                _inner.PLO_ID = value;
                                                if ((_trackingMask & PlotagemTrackingFields.PLO_ID) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "PLO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLO_NOME
                                    {
                                        get => _inner.PLO_NOME;
                                        set
                                        {
                                            if (_inner.PLO_NOME != value)
                                            {
                                                _inner.PLO_NOME = value;
                                                if ((_trackingMask & PlotagemTrackingFields.PLO_NOME) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "PLO_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLO_DIMENSAO
                                    {
                                        get => _inner.PLO_DIMENSAO;
                                        set
                                        {
                                            if (_inner.PLO_DIMENSAO != value)
                                            {
                                                _inner.PLO_DIMENSAO = value;
                                                if ((_trackingMask & PlotagemTrackingFields.PLO_DIMENSAO) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "PLO_DIMENSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLO_X
                                    {
                                        get => _inner.PLO_X;
                                        set
                                        {
                                            if (_inner.PLO_X != value)
                                            {
                                                _inner.PLO_X = value;
                                                if ((_trackingMask & PlotagemTrackingFields.PLO_X) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "PLO_X", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLO_Y
                                    {
                                        get => _inner.PLO_Y;
                                        set
                                        {
                                            if (_inner.PLO_Y != value)
                                            {
                                                _inner.PLO_Y = value;
                                                if ((_trackingMask & PlotagemTrackingFields.PLO_Y) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "PLO_Y", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLO_Z
                                    {
                                        get => _inner.PLO_Z;
                                        set
                                        {
                                            if (_inner.PLO_Z != value)
                                            {
                                                _inner.PLO_Z = value;
                                                if ((_trackingMask & PlotagemTrackingFields.PLO_Z) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "PLO_Z", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PLO_GRAFICO
                                    {
                                        get => _inner.PLO_GRAFICO;
                                        set
                                        {
                                            if (_inner.PLO_GRAFICO != value)
                                            {
                                                _inner.PLO_GRAFICO = value;
                                                if ((_trackingMask & PlotagemTrackingFields.PLO_GRAFICO) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "PLO_GRAFICO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CON_ID
                                    {
                                        get => _inner.CON_ID;
                                        set
                                        {
                                            if (_inner.CON_ID != value)
                                            {
                                                _inner.CON_ID = value;
                                                if ((_trackingMask & PlotagemTrackingFields.CON_ID) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "CON_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlotagemTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlotagemTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlotagemTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PlotagemTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Plotagem", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration