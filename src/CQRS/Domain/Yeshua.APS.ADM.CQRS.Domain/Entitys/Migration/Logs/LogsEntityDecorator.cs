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
                    public static class LogsTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong LOG_CHAVE = 1UL << 1;
            public const ulong LOG_CONTEXTO = 1UL << 2;
            public const ulong LOG_CONTEUDO = 1UL << 3;
            public const ulong LOG_ID = 1UL << 4;
            public const ulong LOG_EMISSAO = 1UL << 5;
            public const ulong OperationalEntityId = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
        }

        public partial class LogsDecorator : ILogsEntity
{

                        private readonly ILogsEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public LogsDecorator(ILogsEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public LogsDecorator(
                            ILogsEntity inner,
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
                                                if ((_trackingMask & LogsTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? LOG_CHAVE
                                    {
                                        get => _inner.LOG_CHAVE;
                                        set
                                        {
                                            if (_inner.LOG_CHAVE != value)
                                            {
                                                _inner.LOG_CHAVE = value;
                                                if ((_trackingMask & LogsTrackingFields.LOG_CHAVE) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "LOG_CHAVE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? LOG_CONTEXTO
                                    {
                                        get => _inner.LOG_CONTEXTO;
                                        set
                                        {
                                            if (_inner.LOG_CONTEXTO != value)
                                            {
                                                _inner.LOG_CONTEXTO = value;
                                                if ((_trackingMask & LogsTrackingFields.LOG_CONTEXTO) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "LOG_CONTEXTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string? LOG_CONTEUDO
                                    {
                                        get => _inner.LOG_CONTEUDO;
                                        set
                                        {
                                            if (_inner.LOG_CONTEUDO != value)
                                            {
                                                _inner.LOG_CONTEUDO = value;
                                                if ((_trackingMask & LogsTrackingFields.LOG_CONTEUDO) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "LOG_CONTEUDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int LOG_ID
                                    {
                                        get => _inner.LOG_ID;
                                        set
                                        {
                                            if (_inner.LOG_ID != value)
                                            {
                                                _inner.LOG_ID = value;
                                                if ((_trackingMask & LogsTrackingFields.LOG_ID) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "LOG_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? LOG_EMISSAO
                                    {
                                        get => _inner.LOG_EMISSAO;
                                        set
                                        {
                                            if (_inner.LOG_EMISSAO != value)
                                            {
                                                _inner.LOG_EMISSAO = value;
                                                if ((_trackingMask & LogsTrackingFields.LOG_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "LOG_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & LogsTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LogsTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LogsTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LogsTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Logs", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration