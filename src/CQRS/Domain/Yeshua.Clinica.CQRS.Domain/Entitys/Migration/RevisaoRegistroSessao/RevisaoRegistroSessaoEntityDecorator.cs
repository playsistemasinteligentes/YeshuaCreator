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
                    public static class RevisaoRegistroSessaoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong SessaoId = 1UL << 1;
            public const ulong Versao = 1UL << 2;
            public const ulong AutorUserId = 1UL << 3;
            public const ulong RevisadoEm = 1UL << 4;
            public const ulong Motivo = 1UL << 5;
            public const ulong Registro = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
            public const ulong OperationalEntityId = 1UL << 11;
        }

        public static class RevisaoRegistroSessaoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SessaoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Versao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AutorUserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RevisadoEm = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Motivo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Registro = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class RevisaoRegistroSessaoDecorator : IRevisaoRegistroSessaoEntity
{

                        private readonly IRevisaoRegistroSessaoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RevisaoRegistroSessaoDecorator(IRevisaoRegistroSessaoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RevisaoRegistroSessaoDecorator(
                            IRevisaoRegistroSessaoEntity inner,
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
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int SessaoId
                                    {
                                        get => _inner.SessaoId;
                                        set
                                        {
                                            if (_inner.SessaoId != value)
                                            {
                                                _inner.SessaoId = value;
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.SessaoId) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "SessaoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.SessaoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int Versao
                                    {
                                        get => _inner.Versao;
                                        set
                                        {
                                            if (_inner.Versao != value)
                                            {
                                                _inner.Versao = value;
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.Versao) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "Versao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.Versao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int AutorUserId
                                    {
                                        get => _inner.AutorUserId;
                                        set
                                        {
                                            if (_inner.AutorUserId != value)
                                            {
                                                _inner.AutorUserId = value;
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.AutorUserId) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "AutorUserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.AutorUserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime RevisadoEm
                                    {
                                        get => _inner.RevisadoEm;
                                        set
                                        {
                                            if (_inner.RevisadoEm != value)
                                            {
                                                _inner.RevisadoEm = value;
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.RevisadoEm) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "RevisadoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.RevisadoEm, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Motivo
                                    {
                                        get => _inner.Motivo;
                                        set
                                        {
                                            if (_inner.Motivo != value)
                                            {
                                                _inner.Motivo = value;
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.Motivo) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "Motivo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.Motivo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Registro
                                    {
                                        get => _inner.Registro;
                                        set
                                        {
                                            if (_inner.Registro != value)
                                            {
                                                _inner.Registro = value;
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.Registro) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "Registro", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.Registro, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & RevisaoRegistroSessaoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("RevisaoRegistroSessao", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, RevisaoRegistroSessaoOperationalFields.UserId, _trackingExecutionIdentity);
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