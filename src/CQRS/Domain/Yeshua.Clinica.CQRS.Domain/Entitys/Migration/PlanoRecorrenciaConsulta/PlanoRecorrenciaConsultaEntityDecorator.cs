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
                    public static class PlanoRecorrenciaConsultaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ProfissionalId = 1UL << 1;
            public const ulong Plano = 1UL << 2;
            public const ulong ConfirmacaoHash = 1UL << 3;
            public const ulong Resultado = 1UL << 4;
            public const ulong ExpiraEmUtc = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
            public const ulong OperationalEntityId = 1UL << 10;
        }

        public static class PlanoRecorrenciaConsultaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProfissionalId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Plano = Dominio.Operational.OperationalDataClassification.NeverCapture;
            public const Dominio.Operational.OperationalDataClassification ConfirmacaoHash = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Resultado = Dominio.Operational.OperationalDataClassification.NeverCapture;
            public const Dominio.Operational.OperationalDataClassification ExpiraEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class PlanoRecorrenciaConsultaDecorator : IPlanoRecorrenciaConsultaEntity
{

                        private readonly IPlanoRecorrenciaConsultaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PlanoRecorrenciaConsultaDecorator(IPlanoRecorrenciaConsultaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PlanoRecorrenciaConsultaDecorator(
                            IPlanoRecorrenciaConsultaEntity inner,
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
                                    public string? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int ProfissionalId
                                    {
                                        get => _inner.ProfissionalId;
                                        set
                                        {
                                            if (_inner.ProfissionalId != value)
                                            {
                                                _inner.ProfissionalId = value;
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.ProfissionalId) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "ProfissionalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.ProfissionalId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Plano
                                    {
                                        get => _inner.Plano;
                                        set
                                        {
                                            if (_inner.Plano != value)
                                            {
                                                _inner.Plano = value;
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.Plano) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "Plano", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.Plano, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ConfirmacaoHash
                                    {
                                        get => _inner.ConfirmacaoHash;
                                        set
                                        {
                                            if (_inner.ConfirmacaoHash != value)
                                            {
                                                _inner.ConfirmacaoHash = value;
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.ConfirmacaoHash) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "ConfirmacaoHash", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.ConfirmacaoHash, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Resultado
                                    {
                                        get => _inner.Resultado;
                                        set
                                        {
                                            if (_inner.Resultado != value)
                                            {
                                                _inner.Resultado = value;
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.Resultado) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "Resultado", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.Resultado, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime ExpiraEmUtc
                                    {
                                        get => _inner.ExpiraEmUtc;
                                        set
                                        {
                                            if (_inner.ExpiraEmUtc != value)
                                            {
                                                _inner.ExpiraEmUtc = value;
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.ExpiraEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "ExpiraEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.ExpiraEmUtc, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PlanoRecorrenciaConsultaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PlanoRecorrenciaConsulta", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PlanoRecorrenciaConsultaOperationalFields.UserId, _trackingExecutionIdentity);
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