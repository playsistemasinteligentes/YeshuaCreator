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
                    public static class ObservacoesTrackingFields
        {
            public const ulong OBS_ID = 1UL << 0;
            public const ulong OBS_TIPO = 1UL << 1;
            public const ulong OBS_DESCRICAO = 1UL << 2;
            public const ulong CLI_ID = 1UL << 3;
            public const ulong MAQ_ID = 1UL << 4;
            public const ulong PRO_ID = 1UL << 5;
            public const ulong ROT_SEQ_TRANFORMACAO = 1UL << 6;
            public const ulong OBS_INTEGRACAO = 1UL << 7;
            public const ulong TenantID = 1UL << 8;
            public const ulong Deleted = 1UL << 9;
            public const ulong Changed = 1UL << 10;
            public const ulong UserId = 1UL << 11;
        }

        public partial class ObservacoesDecorator : IObservacoesEntity
{

                        private readonly IObservacoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ObservacoesDecorator(IObservacoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ObservacoesDecorator(
                            IObservacoesEntity inner,
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
                                    public int OBS_ID
                                    {
                                        get => _inner.OBS_ID;
                                        set
                                        {
                                            if (_inner.OBS_ID != value)
                                            {
                                                _inner.OBS_ID = value;
                                                if ((_trackingMask & ObservacoesTrackingFields.OBS_ID) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "OBS_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OBS_TIPO
                                    {
                                        get => _inner.OBS_TIPO;
                                        set
                                        {
                                            if (_inner.OBS_TIPO != value)
                                            {
                                                _inner.OBS_TIPO = value;
                                                if ((_trackingMask & ObservacoesTrackingFields.OBS_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "OBS_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OBS_DESCRICAO
                                    {
                                        get => _inner.OBS_DESCRICAO;
                                        set
                                        {
                                            if (_inner.OBS_DESCRICAO != value)
                                            {
                                                _inner.OBS_DESCRICAO = value;
                                                if ((_trackingMask & ObservacoesTrackingFields.OBS_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "OBS_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_ID
                                    {
                                        get => _inner.CLI_ID;
                                        set
                                        {
                                            if (_inner.CLI_ID != value)
                                            {
                                                _inner.CLI_ID = value;
                                                if ((_trackingMask & ObservacoesTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID
                                    {
                                        get => _inner.MAQ_ID;
                                        set
                                        {
                                            if (_inner.MAQ_ID != value)
                                            {
                                                _inner.MAQ_ID = value;
                                                if ((_trackingMask & ObservacoesTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID
                                    {
                                        get => _inner.PRO_ID;
                                        set
                                        {
                                            if (_inner.PRO_ID != value)
                                            {
                                                _inner.PRO_ID = value;
                                                if ((_trackingMask & ObservacoesTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? ROT_SEQ_TRANFORMACAO
                                    {
                                        get => _inner.ROT_SEQ_TRANFORMACAO;
                                        set
                                        {
                                            if (_inner.ROT_SEQ_TRANFORMACAO != value)
                                            {
                                                _inner.ROT_SEQ_TRANFORMACAO = value;
                                                if ((_trackingMask & ObservacoesTrackingFields.ROT_SEQ_TRANFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "ROT_SEQ_TRANFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OBS_INTEGRACAO
                                    {
                                        get => _inner.OBS_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.OBS_INTEGRACAO != value)
                                            {
                                                _inner.OBS_INTEGRACAO = value;
                                                if ((_trackingMask & ObservacoesTrackingFields.OBS_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "OBS_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ObservacoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ObservacoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ObservacoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ObservacoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Observacoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration