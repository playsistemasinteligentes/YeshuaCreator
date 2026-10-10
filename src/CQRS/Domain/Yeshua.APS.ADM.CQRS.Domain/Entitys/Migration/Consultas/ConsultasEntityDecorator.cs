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
                    public static class ConsultasTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CON_CASAS_DECIMAIS = 1UL << 1;
            public const ulong CON_CONEXAO = 1UL << 2;
            public const ulong OperationalEntityId = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public static class ConsultasOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CON_CASAS_DECIMAIS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CON_CONEXAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class ConsultasDecorator : IConsultasEntity
{

                        private readonly IConsultasEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ConsultasDecorator(IConsultasEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ConsultasDecorator(
                            IConsultasEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingExecutionIdentity = context is null
                                ? default
                                : new Dominio.Operational.OperationalExecutionIdentity(
                                    context.RootOperationId,
                                    context.OperationId,
                                    context.ExecutionId,
                                    context.CausationId);
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
                                                if ((_trackingMask & ConsultasTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Consultas", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultasOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CON_CASAS_DECIMAIS
                                    {
                                        get => _inner.CON_CASAS_DECIMAIS;
                                        set
                                        {
                                            if (_inner.CON_CASAS_DECIMAIS != value)
                                            {
                                                _inner.CON_CASAS_DECIMAIS = value;
                                                if ((_trackingMask & ConsultasTrackingFields.CON_CASAS_DECIMAIS) != 0UL)
                                                    _logger.DomainValueChanged("Consultas", "CON_CASAS_DECIMAIS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultasOperationalFields.CON_CASAS_DECIMAIS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CON_CONEXAO
                                    {
                                        get => _inner.CON_CONEXAO;
                                        set
                                        {
                                            if (_inner.CON_CONEXAO != value)
                                            {
                                                _inner.CON_CONEXAO = value;
                                                if ((_trackingMask & ConsultasTrackingFields.CON_CONEXAO) != 0UL)
                                                    _logger.DomainValueChanged("Consultas", "CON_CONEXAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultasOperationalFields.CON_CONEXAO, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ConsultasTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Consultas", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultasOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ConsultasTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Consultas", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultasOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ConsultasTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Consultas", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultasOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ConsultasTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Consultas", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ConsultasOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration