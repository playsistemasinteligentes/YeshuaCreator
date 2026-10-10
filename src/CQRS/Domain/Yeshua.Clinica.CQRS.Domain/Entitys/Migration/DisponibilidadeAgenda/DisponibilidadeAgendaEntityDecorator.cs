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
                    public static class DisponibilidadeAgendaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ProfissionalId = 1UL << 1;
            public const ulong DataHora = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
            public const ulong OperationalEntityId = 1UL << 7;
        }

        public static class DisponibilidadeAgendaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProfissionalId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DataHora = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class DisponibilidadeAgendaDecorator : IDisponibilidadeAgendaEntity
{

                        private readonly IDisponibilidadeAgendaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public DisponibilidadeAgendaDecorator(IDisponibilidadeAgendaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public DisponibilidadeAgendaDecorator(
                            IDisponibilidadeAgendaEntity inner,
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
                                                if ((_trackingMask & DisponibilidadeAgendaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("DisponibilidadeAgenda", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, DisponibilidadeAgendaOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ProfissionalId
                                    {
                                        get => _inner.ProfissionalId;
                                        set
                                        {
                                            if (_inner.ProfissionalId != value)
                                            {
                                                _inner.ProfissionalId = value;
                                                if ((_trackingMask & DisponibilidadeAgendaTrackingFields.ProfissionalId) != 0UL)
                                                    _logger.DomainValueChanged("DisponibilidadeAgenda", "ProfissionalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, DisponibilidadeAgendaOperationalFields.ProfissionalId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime DataHora
                                    {
                                        get => _inner.DataHora;
                                        set
                                        {
                                            if (_inner.DataHora != value)
                                            {
                                                _inner.DataHora = value;
                                                if ((_trackingMask & DisponibilidadeAgendaTrackingFields.DataHora) != 0UL)
                                                    _logger.DomainValueChanged("DisponibilidadeAgenda", "DataHora", _trackingTraceId, _trackingOperation, _trackingRecordId, value, DisponibilidadeAgendaOperationalFields.DataHora, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & DisponibilidadeAgendaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("DisponibilidadeAgenda", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, DisponibilidadeAgendaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & DisponibilidadeAgendaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("DisponibilidadeAgenda", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, DisponibilidadeAgendaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & DisponibilidadeAgendaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("DisponibilidadeAgenda", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, DisponibilidadeAgendaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & DisponibilidadeAgendaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("DisponibilidadeAgenda", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, DisponibilidadeAgendaOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration