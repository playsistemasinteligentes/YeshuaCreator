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
                    public static class PoliticaOnduladeiraTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong POL_ID = 1UL << 1;
            public const ulong POL_NIVEL = 1UL << 2;
            public const ulong POL_PROMOCAO = 1UL << 3;
            public const ulong POL_DIAS_ANTECIPACAO = 1UL << 4;
            public const ulong POL_METROS_LINEARES = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class PoliticaOnduladeiraDecorator : IPoliticaOnduladeiraEntity
{

                        private readonly IPoliticaOnduladeiraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PoliticaOnduladeiraDecorator(IPoliticaOnduladeiraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PoliticaOnduladeiraDecorator(
                            IPoliticaOnduladeiraEntity inner,
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
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int POL_ID
                                    {
                                        get => _inner.POL_ID;
                                        set
                                        {
                                            if (_inner.POL_ID != value)
                                            {
                                                _inner.POL_ID = value;
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.POL_ID) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "POL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? POL_NIVEL
                                    {
                                        get => _inner.POL_NIVEL;
                                        set
                                        {
                                            if (_inner.POL_NIVEL != value)
                                            {
                                                _inner.POL_NIVEL = value;
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.POL_NIVEL) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "POL_NIVEL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? POL_PROMOCAO
                                    {
                                        get => _inner.POL_PROMOCAO;
                                        set
                                        {
                                            if (_inner.POL_PROMOCAO != value)
                                            {
                                                _inner.POL_PROMOCAO = value;
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.POL_PROMOCAO) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "POL_PROMOCAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? POL_DIAS_ANTECIPACAO
                                    {
                                        get => _inner.POL_DIAS_ANTECIPACAO;
                                        set
                                        {
                                            if (_inner.POL_DIAS_ANTECIPACAO != value)
                                            {
                                                _inner.POL_DIAS_ANTECIPACAO = value;
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.POL_DIAS_ANTECIPACAO) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "POL_DIAS_ANTECIPACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? POL_METROS_LINEARES
                                    {
                                        get => _inner.POL_METROS_LINEARES;
                                        set
                                        {
                                            if (_inner.POL_METROS_LINEARES != value)
                                            {
                                                _inner.POL_METROS_LINEARES = value;
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.POL_METROS_LINEARES) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "POL_METROS_LINEARES", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & PoliticaOnduladeiraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PoliticaOnduladeira", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration