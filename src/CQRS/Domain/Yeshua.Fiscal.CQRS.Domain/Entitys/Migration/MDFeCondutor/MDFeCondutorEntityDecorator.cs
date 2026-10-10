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
                    public static class MDFeCondutorTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MDFeSolicitacaoFiscalId = 1UL << 1;
            public const ulong Nome = 1UL << 2;
            public const ulong Documento = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
            public const ulong OperationalEntityId = 1UL << 8;
        }

        public static class MDFeCondutorOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MDFeSolicitacaoFiscalId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Nome = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification Documento = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class MDFeCondutorDecorator : IMDFeCondutorEntity
{

                        private readonly IMDFeCondutorEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MDFeCondutorDecorator(IMDFeCondutorEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MDFeCondutorDecorator(
                            IMDFeCondutorEntity inner,
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
                                                if ((_trackingMask & MDFeCondutorTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MDFeCondutor", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MDFeCondutorOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int MDFeSolicitacaoFiscalId
                                    {
                                        get => _inner.MDFeSolicitacaoFiscalId;
                                        set
                                        {
                                            if (_inner.MDFeSolicitacaoFiscalId != value)
                                            {
                                                _inner.MDFeSolicitacaoFiscalId = value;
                                                if ((_trackingMask & MDFeCondutorTrackingFields.MDFeSolicitacaoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeCondutor", "MDFeSolicitacaoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MDFeCondutorOperationalFields.MDFeSolicitacaoFiscalId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Nome
                                    {
                                        get => _inner.Nome;
                                        set
                                        {
                                            if (_inner.Nome != value)
                                            {
                                                _inner.Nome = value;
                                                if ((_trackingMask & MDFeCondutorTrackingFields.Nome) != 0UL)
                                                    _logger.DomainValueChanged("MDFeCondutor", "Nome", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MDFeCondutorOperationalFields.Nome, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Documento
                                    {
                                        get => _inner.Documento;
                                        set
                                        {
                                            if (_inner.Documento != value)
                                            {
                                                _inner.Documento = value;
                                                if ((_trackingMask & MDFeCondutorTrackingFields.Documento) != 0UL)
                                                    _logger.DomainValueChanged("MDFeCondutor", "Documento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MDFeCondutorOperationalFields.Documento, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MDFeCondutorTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MDFeCondutor", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MDFeCondutorOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MDFeCondutorTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MDFeCondutor", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MDFeCondutorOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MDFeCondutorTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MDFeCondutor", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MDFeCondutorOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & MDFeCondutorTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeCondutor", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, MDFeCondutorOperationalFields.UserId, _trackingExecutionIdentity);
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